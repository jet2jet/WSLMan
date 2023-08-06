Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.Win32
Imports WSLMan.My.Resources

Public Module Main
    Public ReadOnly CommonOpenFileDialog As New OpenFileDialog()
    Public ReadOnly CommonSaveFileDialog As New SaveFileDialog()
    Public ReadOnly CommonFolderDialog As New FolderBrowserDialog()

    Private _IsVhdImportExportAvailable As Boolean = False
    Private _IsImportInPlaceAvailable As Boolean = False
    Private _WSLInstallationStatus As WSLInstallation = WSLInstallation.None

    Public Structure WSLDistributionData
        Public Key As String
        Public DistributionName As String
        Public Version As Integer
        Public PackageFamilyName As String
        Public DefaultUid As Integer?
        Public BasePath As String
        Public VhdFileName As String
    End Structure

    Public Structure WSLStatusData
        Public DistributionName As String
        Public Status As String
    End Structure

    Public Enum WSLInstallation
        Unsupported = -1
        None = 0
        InboxWSL = 1
        StoreWSL = 2
    End Enum

    Private Const SYNCHRONIZE As Integer = &H100000
    Private Const FILE_READ_ATTRIBUTES As Integer = &H80
    Private Const FILE_SHARE_READ As Integer = &H1
    Private Const FILE_SHARE_WRITE As Integer = &H2
    Private Const FILE_DIRECTORY_FILE As Integer = &H1
    Private Const FILE_SYNCHRONOUS_IO_ALERT As Integer = &H10

    <StructLayout(LayoutKind.Sequential)>
    Private Structure UNICODE_STRING
        Public Length As Short
        Public MaximumLength As Short
        Public Buffer As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure OBJECT_ATTRIBUTES
        Public Length As Integer
        Public RootDirectory As IntPtr
        Public ObjectName As IntPtr
        Public Attributes As Integer
        Public SecurityDescriptor As IntPtr
        Public SecurityQualityOfService As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure IO_STATUS_BLOCK
        Public Status As IntPtr
        Public Information As IntPtr
    End Structure

    Private Enum FO_Func As Short
        FO_COPY = &H2
        FO_DELETE = &H3
        FO_MOVE = &H1
        FO_RENAME = &H4
    End Enum

    <StructLayout(LayoutKind.Sequential)>
    Private Structure SHFILEOPSTRUCT
        Public hwnd As IntPtr
        Public wFunc As FO_Func
        <MarshalAs(UnmanagedType.LPWStr)>
        Public pFrom As String
        <MarshalAs(UnmanagedType.LPWStr)>
        Public pTo As String
        Public fFlags As UShort
        Public fAnyOperationsAborted As Boolean
        Public hNameMappings As IntPtr
        <MarshalAs(UnmanagedType.LPWStr)>
        Public lpszProgressTitle As String
    End Structure

    Private Declare Unicode Function GetFinalPathNameByHandleW Lib "kernel32.dll" _
        (hFile As IntPtr, <MarshalAs(UnmanagedType.LPWStr)> lpszFilePath As String, cchFilePath As Integer, dwFlags As Integer) As Integer

    Private Declare Unicode Sub RtlInitUnicodeString Lib "ntdll.dll" _
        (ByRef DestinationString As UNICODE_STRING, <MarshalAs(UnmanagedType.LPWStr)> SourceString As String)
    Private Declare Unicode Sub RtlFreeUnicodeString Lib "ntdll.dll" _
        (ByRef UnicodeString As UNICODE_STRING)
    Private Declare Unicode Function RtlDosPathNameToNtPathName_U Lib "ntdll.dll" _
        (<MarshalAs(UnmanagedType.LPWStr)> DosName As String, ByRef NtName As UNICODE_STRING, ByVal PartNamePtr As IntPtr, ByVal RelativeNamePtr As IntPtr) As Boolean
    Private Declare Unicode Function NtOpenFile Lib "ntdll.dll" _
        (ByRef FileHandle As IntPtr, DesiredAccess As Integer, ByRef ObjectAttributes As OBJECT_ATTRIBUTES, ByRef IoStatusBlock As IO_STATUS_BLOCK, ShareAccess As Integer, OpenOptions As Integer) As Integer
    Private Declare Unicode Function NtClose Lib "ntdll.dll" (Handle As IntPtr) As Integer

    Private Declare Unicode Function SHFileOperation Lib "shell32.dll" Alias "SHFileOperationW" _
        (ByRef lpFileOp As SHFILEOPSTRUCT) As Integer

    Private Declare Unicode Function SearchPath Lib "kernel32.dll" Alias "SearchPathW" _
        (lpPath As String, lpFileName As String, lpExtension As String, nBufferLength As Integer,
         <MarshalAs(UnmanagedType.LPWStr)> lpBuffer As StringBuilder, ByRef lpFilePart As IntPtr) As Integer

    Private Sub InitializeObjectAttributes(ByRef InitializedAttributes As OBJECT_ATTRIBUTES, ObjectName As IntPtr, Attributes As Integer, RootDirectory As IntPtr, SecurityDescriptor As IntPtr)
        InitializedAttributes.Length = Marshal.SizeOf(InitializedAttributes)
        InitializedAttributes.RootDirectory = RootDirectory
        InitializedAttributes.Attributes = Attributes
        InitializedAttributes.ObjectName = ObjectName
        InitializedAttributes.SecurityDescriptor = SecurityDescriptor
        InitializedAttributes.SecurityQualityOfService = IntPtr.Zero
    End Sub

    <STAThread()>
    Public Function Main() As Integer
        Dim t = CheckWSLInstallation()
        t.Wait()
        _WSLInstallationStatus = t.Result
        If t.Result = WSLInstallation.Unsupported Then
            MessageBox.Show(Resources.WSLExeNotFoundMessage, GetApplicationName(), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 1
        ElseIf t.Result = WSLInstallation.None Then
            ShowInstallWSL()
        Else
            ShowMain()
        End If
        Application.Run()
        Return 0
    End Function

    Public Function GetApplicationName() As String
        Return My.Application.Info.Title
    End Function

    Private Async Function CheckWSLInstallation() As Task(Of WSLInstallation)
        Dim sb = New StringBuilder(260)
        Dim ptr As New IntPtr()
        If SearchPath(Nothing, "wsl.exe", Nothing, sb.Capacity, sb, ptr) = 0 Then
            Return WSLInstallation.Unsupported
        End If
        ' If WSL is not installed, 'wsl --status' will return exit code 50
        Dim r = Await ExecCommand("wsl.exe", "--status")
        If r = 50 Then
            Return WSLInstallation.None
        End If
        ' If inbox (not Microsoft Store) wsl is used, 'wsl --version' does not work (will return non-zero exit code)
        r = Await ExecCommand("wsl.exe", "--version")
        If r <> 0 Then
            Return WSLInstallation.InboxWSL
        End If
        Return WSLInstallation.StoreWSL
    End Function

    Public Function GetWSLInstallationStatus() As WSLInstallation
        Return _WSLInstallationStatus
    End Function

    Public Async Function UpdateWSLInstallationStatus() As Task
        Await CheckWSLInstallation()
    End Function

    Private Sub ShowInstallWSL()
        Dim f = New WSLMan.InstallWSL()
        f.Show()
    End Sub

    Public Sub ShowMain()
        Dim f = New WSLMan.MainForm()
        f.Show()
    End Sub

    Public Function IsInboxWSLInstalled() As Boolean
        Dim o = Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Component Based Servicing\Notifications\OptionalFeatures\Microsoft-Windows-Subsystem-Linux", "Selection", 0)
        Try
            Return CType(o, Integer) <> 0
        Catch
            Return False
        End Try
    End Function

    Public Function GetDefaultWSLVersion() As Integer
        Dim o = Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Lxss", "DefaultVersion", 2)
        Try
            Return CType(o, Integer)
        Catch
            Return 2
        End Try
    End Function

    Public Sub SetDefaultWSLVersion(Version As Integer)
        If GetDefaultWSLVersion() <> Version Then
            Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Lxss", "DefaultVersion", Version, RegistryValueKind.DWord)
        End If
    End Sub

    Public Function GetAllWSLDistributions() As List(Of WSLDistributionData)
        Dim list As New List(Of WSLDistributionData)
        Try
            Dim baseKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Lxss")
            Dim def As Object = Nothing
            Try
                def = baseKey.GetValue("DefaultDistribution")
            Catch
            End Try
            For Each keyName In baseKey.GetSubKeyNames()
                Dim thisKey = baseKey.OpenSubKey(keyName)
                Dim uid = thisKey.GetValue("DefaultUid", 0)
                Try
                    Dim s As New WSLDistributionData With {
                        .Key = keyName,
                        .DistributionName = If(CStr(thisKey.GetValue("DistributionName")), ""),
                        .Version = CInt(thisKey.GetValue("Version", 2)),
                        .DefaultUid = If(uid IsNot Nothing, CInt(uid), Nothing),
                        .PackageFamilyName = CStr(thisKey.GetValue("PackageFamilyName")),
                        .BasePath = CStr(thisKey.GetValue("BasePath")),
                        .VhdFileName = CStr(thisKey.GetValue("VhdFileName"))
                    }
                    If TypeOf def Is String AndAlso CStr(def) = keyName Then
                        list.Insert(0, s)
                    Else
                        list.Add(s)
                    End If
                Catch
                End Try
            Next
        Catch
        End Try
        Return list
    End Function

    Public Function IsWSLDefaultDistribution(Key As String) As Boolean
        Dim o = Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Lxss", "DefaultDistribution", "")
        Return TypeOf o Is String AndAlso CStr(o) = Key
    End Function

    Public Sub SetWSLDefaultDistribution(Key As String)
        Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Lxss", "DefaultDistribution", Key)
    End Sub

    Public Async Function GetWSLStatus() As Task(Of IList(Of WSLStatusData))
        Dim list As New List(Of WSLStatusData)
        Dim rgLine As New Regex("^\s*\*?\s*(.+?)\s+(.+?)\s+(.+)$")
        Dim lines = Await ExecCommandWithOutput("wsl.exe", "-l -v")
        ' Ignore first line
        For i = 1 To lines.Length - 1
            Dim m = rgLine.Match(lines(i))
            If m IsNot Nothing And m.Groups.Count >= 4 Then
                list.Add(New WSLStatusData() With {
                    .DistributionName = m.Groups(1).Value,
                    .Status = m.Groups(2).Value
                })
            End If
        Next
        Return list
    End Function

    Public Async Function TerminateWSL(DistributionName As String) As Task(Of Boolean)
        Dim r = Await ExecCommand("wsl.exe", $"--terminate {DistributionName}")
        Return r = 0
    End Function

    Private Function GetFinalPathNameByHandle(hFile As IntPtr) As String
        Dim s As String = ""
        Dim r = GetFinalPathNameByHandleW(hFile, s, 0, 0)
        If r > 0 Then
            s = New String(" "c, r)
            r = GetFinalPathNameByHandleW(hFile, s, r, 0)
            If r > 0 Then
                Return s.Substring(0, r)
            End If
        End If
        Return Nothing
    End Function

    Public Function NormalizePath(Path As String) As String
        Dim us As New UNICODE_STRING
        RtlDosPathNameToNtPathName_U(Path, us, IntPtr.Zero, IntPtr.Zero)
        Dim gcus = GCHandle.Alloc(us, GCHandleType.Pinned)
        Dim oa As New OBJECT_ATTRIBUTES
        InitializeObjectAttributes(oa, gcus.AddrOfPinnedObject(), 0, IntPtr.Zero, IntPtr.Zero)
        Dim iosb As New IO_STATUS_BLOCK
        Dim r As Integer
        Dim h As IntPtr
        Dim result = Path
        r = NtOpenFile(h, SYNCHRONIZE Or FILE_READ_ATTRIBUTES, oa, iosb, FILE_SHARE_READ Or FILE_SHARE_WRITE, FILE_DIRECTORY_FILE Or FILE_SYNCHRONOUS_IO_ALERT)
        If r = 0 Then
            result = GetFinalPathNameByHandle(h)
            If result.StartsWith("\\.\") OrElse result.StartsWith("\\?\") Then
                result = result.Substring(4)
            End If
#Disable Warning CA1806 ' メソッドの結果を無視しない
            NtClose(h)
#Enable Warning CA1806 ' メソッドの結果を無視しない
        End If
        gcus.Free()
        RtlFreeUnicodeString(us)
        Return result
    End Function

    Public Function CopyFilesInDirectory(hWndParent As IntPtr, FromPath As String, ToPath As String) As Boolean
        Dim sh As New SHFILEOPSTRUCT With {
            .hwnd = hWndParent,
            .wFunc = FO_Func.FO_COPY,
            .pFrom = Path.Join(FromPath, "*") + vbNullChar,
            .pTo = ToPath + vbNullChar,
            .fAnyOperationsAborted = True
        }
#Disable Warning CA1806 ' メソッドの結果を無視しない
        SHFileOperation(sh)
#Enable Warning CA1806 ' メソッドの結果を無視しない
        Return Not sh.fAnyOperationsAborted
    End Function

    Public Async Function RestartWslService() As Task
        Dim serviceName As String
        Dim e = Await ExecCommand("sc.exe", "query WslService")
        If e = 0 Then
            serviceName = "WslService"
        Else
            serviceName = "LxssService"
        End If
        Await ExecCommand("powershell.exe", $"Start-Process cmd.exe -Verb runas -ArgumentList @('/c', 'sc.exe', 'stop', '{serviceName}', '&', 'timeout', '/T', '2', '/NOBREAK', '&', 'sc.exe', 'start', '{serviceName}', '&', 'pause')")
    End Function

    Public Sub RestartWslServiceWithPrompt()
        If MessageBox.Show(Resources.WSLServiceNeedToRestart, GetApplicationName(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If
        RestartWslService().ContinueWith(Sub()
                                             ' do nothing
                                         End Sub)
    End Sub

    Public Function JoinFilter(ParamArray filters As String()) As String
        Dim r = ""
        For Each f In filters
            If r.Length > 0 AndAlso Not r.EndsWith("|"c) Then r += "|"c
            r += f
        Next
        Return r
    End Function

    Public Sub RebootSystem()
        ExecCommand("shutdown.exe", "/r /t 0").ContinueWith(Sub(t)
                                                                If t.Result <> 0 Then
                                                                    MessageBox.Show(Resources.FailedToRebootMessage, GetApplicationName(), MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                End If
                                                            End Sub)
    End Sub

    Public Sub OpenFolderInExplorer(Path As String)
        ExecCommandDetached("explorer.exe", $"""{Path}""")
    End Sub

    Public Sub OpenDistributionInExplorer(DistributionName As String)
        Dim subKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace")
        Dim linuxKey = subKey?.OpenSubKey("{B2B4A4D1-2754-4140-A2EB-9A76D9D7CDC6}")
        If linuxKey IsNot Nothing Then
            OpenFolderInExplorer($"::{"{B2B4A4D1-2754-4140-A2EB-9A76D9D7CDC6}"}\{DistributionName}")
            linuxKey.Close()
        Else
            OpenFolderInExplorer($"\\wsl.localhost\{DistributionName}")
        End If
        subKey?.Close()
    End Sub

    Public Async Function UpdateWSLCommandAvailability() As Task
        Dim o = Await ExecCommandWithOutput("wsl.exe", "--help")
        _IsVhdImportExportAvailable = o.Contains("--vhd")
        _IsImportInPlaceAvailable = o.Contains("--import-in-place")
    End Function

    Public Function IsVhdImportExportAvailable() As Boolean
        Return _IsVhdImportExportAvailable
    End Function

    Public Function IsImportInPlaceAvailable() As Boolean
        Return _IsImportInPlaceAvailable
    End Function
End Module
