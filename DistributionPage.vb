Imports System.IO
Imports Microsoft.Win32
Imports WSLMan.My.Resources

Public Class DistributionPage
    Public Data As WSLDistributionData
    Public TabPage As TabPage
    Private IsLoading As Boolean = False
    Private BaseWslConfContent As String()
    Private _minimumHeightConfClosed As Integer
    Private _minimumHeightConfOpened As Integer

    Public ReadOnly Property MinimumHeight() As Integer
        Get
            Return If(GroupBoxWslConfBoot.Visible, _minimumHeightConfOpened, _minimumHeightConfClosed)
        End Get
    End Property

    Private Function GetWslConfPath() As String
        Return $"\\wsl.localhost\{Data.DistributionName}\etc\wsl.conf"
    End Function

    Private Async Function InitWslConf() As Task
        Invoke(Sub()
                   GroupBoxWslConfBoot.Visible = False
                   GroupBoxWslConfAutoMount.Visible = False
               End Sub)
        Dim content As String()
        Dim fileName = GetWslConfPath()
        If Not File.Exists(fileName) Then
            content = Array.Empty(Of String)()
        Else
            content = Await File.ReadAllLinesAsync(fileName)
        End If

        Invoke(Sub()
                   Dim osVer = Environment.OSVersion.Version
                   Dim IsWindows11 = (osVer.Major > 10 OrElse (osVer.Major = 10 AndAlso osVer.Build >= 22000))
                   Dim bootSystemd = ConfReadBooleanValue(content, "boot", "systemd")
                   CheckBoxUseSystemd.CheckState = If(bootSystemd Is Nothing, CheckState.Indeterminate, If(bootSystemd, CheckState.Checked, CheckState.Unchecked))
                   Dim bootCommand = ConfReadValue(content, "boot", "command")
                   ' Enable only under Windows 11 or later
                   CheckBoxDefaultBootCommand.Enabled = IsWindows11
                   CheckBoxDefaultBootCommand.Checked = bootCommand Is Nothing
                   TextBoxBootCommand.Enabled = IsWindows11 AndAlso bootCommand IsNot Nothing
                   TextBoxBootCommand.Text = If(bootCommand, "")
                   Dim autoMountEnabled = ConfReadBooleanValue(content, "automount", "enabled")
                   CheckBoxAutoMountEnabled.CheckState = If(autoMountEnabled Is Nothing, CheckState.Indeterminate, If(autoMountEnabled, CheckState.Checked, CheckState.Unchecked))
                   Dim mountFsTab = ConfReadBooleanValue(content, "automount", "mountFsTab")
                   CheckBoxMountFsTab.CheckState = If(mountFsTab Is Nothing, CheckState.Indeterminate, If(mountFsTab, CheckState.Checked, CheckState.Unchecked))
                   Dim autoMountRoot = ConfReadValue(content, "automount", "root")
                   CheckBoxDefaultAutoMountRoot.Checked = autoMountRoot Is Nothing
                   TextBoxAutoMountRoot.Enabled = autoMountRoot IsNot Nothing
                   TextBoxAutoMountRoot.Text = If(autoMountRoot, "")
                   Dim autoMountOptions = ConfReadValue(content, "automount", "options")
                   CheckBoxDefaultAutoMountOptions.Checked = autoMountOptions Is Nothing
                   TextBoxAutoMountOptions.Enabled = autoMountOptions IsNot Nothing
                   TextBoxAutoMountOptions.Text = If(autoMountOptions, "")

                   GroupBoxWslConfBoot.Visible = True
                   GroupBoxWslConfAutoMount.Visible = True
                   BaseWslConfContent = content
               End Sub)
    End Function

    Public Sub InitForm()
        TextBoxDistributionName.Text = Data.DistributionName
        LabelWSLVersionValue.Text = CStr(Data.Version)
        TextBoxPackageName.Text = If(Data.PackageFamilyName, "")
        NumericDefaultUser.Value = If(Data.DefaultUid, 0)
        TextBoxBasePath.Text = Data.BasePath
        TextBoxVhdFileName.Text = If(Data.VhdFileName, "")
        TextBoxVhdFileName.Enabled = IsImportInPlaceAvailable()
        ButtonSetAsDefault.Enabled = Not IsWSLDefaultDistribution(Data.Key)
    End Sub

    Public Sub OnShutdownWSL()
        ButtonOpenConfiguration.Text = Resources.DistributionPageButtonOpenConf
        ButtonOpenConfiguration.Enabled = True
        GroupBoxWslConfBoot.Visible = False
        GroupBoxWslConfAutoMount.Visible = False
    End Sub

    Public Sub OnUpdateWSLCommandAvailability()
        TextBoxVhdFileName.Enabled = IsImportInPlaceAvailable()
    End Sub

    Private Sub UpdateWslConfBase(Writer As Action(Of IList(Of String)))
        If IsLoading Then Exit Sub
        Dim fileName = GetWslConfPath()
        Dim content = New List(Of String)(BaseWslConfContent)
        Writer(content)
        ' If data is equal, then do nothing
        If content.SequenceEqual(BaseWslConfContent) Then
            Exit Sub
        End If
        File.WriteAllLines(fileName, content)
    End Sub

    Private Sub UpdateWslConf(Section As String, Name As String, Value As String, UseDefault As Boolean)
        UpdateWslConfBase(Sub(content) ConfWriteOrRemoveValue(content, Section, Name, Value, UseDefault))
    End Sub

    Private Sub UpdateWslConfBoolean(Section As String, Name As String, Value As CheckState)
        UpdateWslConfBase(Sub(content) ConfWriteOrRemoveBooleanValue(content, Section, Name, Value))
    End Sub

    Private Async Function DoCopyBasePath(FromPath As String, ToPath As String) As Task(Of Boolean)
OnStart:
        Dim list = Await GetWSLStatus()
        For Each d In list
            If d.DistributionName = Data.DistributionName Then
                If d.Status <> "Stopped" Then
                    If MessageBox.Show(Resources.WSLNotStoppedForChangingBasePath, GetApplicationName(), MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) = DialogResult.Cancel Then
                        Return False
                    End If
                    GoTo OnStart
                End If
            End If
        Next
        Return CopyFilesInDirectory(Handle, FromPath, ToPath)
    End Function

    Private Sub DoResize()
        SuspendLayout()
        GroupBoxWslConfBoot.SuspendLayout()
        GroupBoxWslConfAutoMount.SuspendLayout()
        Dim w = Width - Padding.Horizontal
        TextBoxDistributionName.Width = w - TextBoxDistributionName.Left
        TextBoxPackageName.Width = w - TextBoxPackageName.Left
        NumericDefaultUser.Width = w - NumericDefaultUser.Left - ButtonChangeDefaultUser.Width - 8
        ButtonChangeDefaultUser.Left = NumericDefaultUser.Right + 8
        TextBoxBasePath.Width = w - TextBoxBasePath.Left - ButtonChangeBasePath.Width - 8
        ButtonChangeBasePath.Left = TextBoxBasePath.Right + 8
        TextBoxVhdFileName.Width = w - TextBoxVhdFileName.Left

        GroupBoxWslConfBoot.Width = w
        TextBoxBootCommand.Width = w - TextBoxBootCommand.Left - CheckBoxDefaultBootCommand.Width - 16 * 2
        CheckBoxDefaultBootCommand.Left = w - CheckBoxDefaultBootCommand.Width - 16

        GroupBoxWslConfAutoMount.Width = w
        CheckBoxMountFsTab.Left = CheckBoxAutoMountEnabled.Left + CInt((w - 32 - 16) / 2) + 16
        TextBoxAutoMountRoot.Width = w - TextBoxAutoMountRoot.Left - CheckBoxDefaultAutoMountRoot.Width - 16 * 2
        CheckBoxDefaultAutoMountRoot.Left = w - CheckBoxDefaultAutoMountRoot.Width - 16
        TextBoxAutoMountOptions.Width = w - TextBoxAutoMountOptions.Left - CheckBoxDefaultAutoMountOptions.Width - 16 * 2
        CheckBoxDefaultAutoMountOptions.Left = w - CheckBoxDefaultAutoMountOptions.Width - 16

        GroupBoxWslConfAutoMount.ResumeLayout()
        GroupBoxWslConfBoot.ResumeLayout()
        ResumeLayout()
    End Sub

    Private Sub DistributionPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _minimumHeightConfClosed = ButtonOpenConfiguration.Bottom + Padding.Bottom
        _minimumHeightConfOpened = GroupBoxWslConfAutoMount.Bottom + Padding.Bottom
        ButtonOpenConfiguration.Text = Resources.DistributionPageButtonOpenConf
        ButtonOpenConfiguration.Enabled = True
        GroupBoxWslConfBoot.Visible = False
        GroupBoxWslConfAutoMount.Visible = False
        InitForm()
    End Sub

    Private Sub DistributionPage_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        DoResize()
    End Sub

    Private Sub TextBoxDistributionName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxDistributionName.KeyPress
        If e.KeyChar = " "c Then
            e.Handled = True
            Beep()
        End If
    End Sub

    Private Sub TextBoxDistributionName_LostFocus(sender As Object, e As EventArgs) Handles TextBoxDistributionName.LostFocus
        Dim name = TextBoxDistributionName.Text
        Dim strippedName = name.Replace(" ", "")
        If name <> strippedName Then
            TextBoxDistributionName.Text = strippedName
        End If
        If Data.DistributionName = strippedName Then Exit Sub
        Data.DistributionName = strippedName
        TabPage.Text = strippedName
        Registry.SetValue($"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Lxss\{Data.Key}", "DistributionName", strippedName)
    End Sub

    Private Sub NumericDefaultUser_LostFocus(sender As Object, e As EventArgs) Handles NumericDefaultUser.LostFocus
        Dim uid As Integer
        Try
            uid = CInt(NumericDefaultUser.Value)
        Catch
            Exit Sub
        End Try
        If Data.DefaultUid = uid Then Exit Sub
        Data.DefaultUid = uid
        Registry.SetValue($"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Lxss\{Data.Key}", "DefaultUid", uid, RegistryValueKind.DWord)
    End Sub

    Private Sub TextBoxVhdFileName_LostFocus(sender As Object, e As EventArgs) Handles TextBoxVhdFileName.LostFocus
        Dim fileName = TextBoxVhdFileName.Text
        If fileName.Length = 0 Then
            fileName = Nothing
        End If
        If Data.VhdFileName = fileName Then
            Exit Sub
        End If
        If fileName IsNot Nothing Then
            For Each c As Char In Path.GetInvalidPathChars()
                If fileName.Contains(c) Then
                    MessageBox.Show(Resources.InvalidValueMessage, GetApplicationName(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TextBoxVhdFileName.Focus()
                    Exit Sub
                End If
            Next
            If fileName.EndsWith(Path.DirectorySeparatorChar) Then
                MessageBox.Show(Resources.InvalidValueMessage, GetApplicationName(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TextBoxVhdFileName.Focus()
                Exit Sub
            End If
        End If
        Dim oldFile = Path.Join(Data.BasePath, If(Data.VhdFileName, "ext4.vhdx"))
        Try
            If File.Exists(oldFile) Then
                File.Move(oldFile, Path.Join(Data.BasePath, If(fileName, "ext4.vhdx")))
            End If
        Catch ex As Exception
            MessageBox.Show(String.Format(Resources.CannotChangeVhdFileName, ex.Message),
                            GetApplicationName(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBoxVhdFileName.Focus()
            Exit Sub
        End Try
        If fileName Is Nothing Then
            Dim key = Registry.CurrentUser.OpenSubKey($"Software\Microsoft\Windows\CurrentVersion\Lxss\{Data.Key}", True)
            key.DeleteValue("VhdFileName")
            key.Close()
        Else
            Registry.SetValue($"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Lxss\{Data.Key}", "VhdFileName", fileName)
        End If
    End Sub

    Private Sub ButtonChangeDefaultUser_Click(sender As Object, e As EventArgs) Handles ButtonChangeDefaultUser.Click
        Dim selector As New UserSelector()
        Dim uid = selector.Show(Data.DistributionName, If(Data.DefaultUid, 0))
        If uid Is Nothing Then Exit Sub
        If Data.DefaultUid = uid Then Exit Sub
        NumericDefaultUser.Value = CDec(uid)
        Data.DefaultUid = uid
        Registry.SetValue($"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Lxss\{Data.Key}", "DefaultUid", uid, RegistryValueKind.DWord)
    End Sub

    Private Sub ButtonChangeBasePath_Click(sender As Object, e As EventArgs) Handles ButtonChangeBasePath.Click
        Dim normalizedPreviousPath = NormalizePath(TextBoxBasePath.Text)
        With CommonFolderDialog
            .SelectedPath = normalizedPreviousPath
            .ShowNewFolderButton = True
            If .ShowDialog() = DialogResult.OK Then
                Dim normalizedSelectedPath = NormalizePath(.SelectedPath)
                If normalizedSelectedPath = normalizedPreviousPath Then Exit Sub
                If MessageBox.Show(Resources.ChangingBasePathPrompt, GetApplicationName(), MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK Then
                    ButtonChangeBasePath.Enabled = False
                    DoCopyBasePath(normalizedPreviousPath, normalizedSelectedPath) _
                        .ContinueWith(Sub(t)
                                          Invoke(Sub()
                                                     If t.Result Then
                                                         Registry.SetValue($"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Lxss\{Data.Key}", "BasePath", normalizedSelectedPath)
                                                         TextBoxBasePath.Text = normalizedSelectedPath
                                                     End If
                                                     RestartWslServiceWithPrompt()
                                                     If MessageBox.Show(Resources.OpenOldPathPrompt, GetApplicationName(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                                         OpenFolderInExplorer(normalizedPreviousPath)
                                                     End If
                                                     ButtonChangeBasePath.Enabled = True
                                                 End Sub)
                                      End Sub)
                End If
            End If
        End With
    End Sub

    Private Sub CheckBoxUseSystemd_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBoxUseSystemd.CheckStateChanged
        UpdateWslConfBoolean("boot", "systemd", CheckBoxUseSystemd.CheckState)
    End Sub

    Private Sub TextBoxBootCommand_LostFocus(sender As Object, e As EventArgs) Handles TextBoxBootCommand.LostFocus
        UpdateWslConf("boot", "command", TextBoxBootCommand.Text, CheckBoxDefaultBootCommand.Checked)
    End Sub

    Private Sub CheckBoxDefaultBootCommand_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDefaultBootCommand.CheckedChanged
        TextBoxBootCommand.Enabled = Not CheckBoxDefaultBootCommand.Checked
        If CheckBoxDefaultBootCommand.Checked Then
            UpdateWslConf("boot", "command", TextBoxBootCommand.Text, CheckBoxDefaultBootCommand.Checked)
        Else
            TextBoxBootCommand.Focus()
        End If
    End Sub

    Private Sub CheckBoxAutoMountEnabled_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBoxAutoMountEnabled.CheckStateChanged
        UpdateWslConfBoolean("automount", "enabled", CheckBoxAutoMountEnabled.CheckState)
    End Sub

    Private Sub CheckBoxMountFsTab_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBoxMountFsTab.CheckStateChanged
        UpdateWslConfBoolean("automount", "mountFsTab", CheckBoxMountFsTab.CheckState)
    End Sub

    Private Sub TextBoxAutoMountRoot_LostFocus(sender As Object, e As EventArgs) Handles TextBoxAutoMountRoot.LostFocus
        UpdateWslConf("automount", "root", TextBoxAutoMountRoot.Text, CheckBoxDefaultAutoMountRoot.Checked)
    End Sub

    Private Sub CheckBoxDefaultAutoMountRoot_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDefaultAutoMountRoot.CheckedChanged
        TextBoxAutoMountRoot.Enabled = Not CheckBoxDefaultAutoMountRoot.Checked
        If CheckBoxDefaultAutoMountRoot.Checked Then
            UpdateWslConf("automount", "root", TextBoxAutoMountRoot.Text, CheckBoxDefaultAutoMountRoot.Checked)
        Else
            TextBoxAutoMountRoot.Focus()
        End If
    End Sub

    Private Sub TextBoxAutoMountOptions_LostFocus(sender As Object, e As EventArgs) Handles TextBoxAutoMountOptions.LostFocus
        UpdateWslConf("automount", "options", TextBoxAutoMountOptions.Text, CheckBoxDefaultAutoMountOptions.Checked)
    End Sub

    Private Sub CheckBoxDefaultAutoMountOptions_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDefaultAutoMountOptions.CheckedChanged
        TextBoxAutoMountOptions.Enabled = Not CheckBoxDefaultAutoMountOptions.Checked
        If CheckBoxDefaultAutoMountOptions.Checked Then
            UpdateWslConf("automount", "options", TextBoxAutoMountOptions.Text, CheckBoxDefaultAutoMountOptions.Checked)
        Else
            TextBoxAutoMountOptions.Focus()
        End If
    End Sub

    Private Sub DistributionPage_ClientSizeChanged(sender As Object, e As EventArgs) Handles Me.ClientSizeChanged
        ' DoResize()
    End Sub

    Private Sub ButtonOpenConfiguration_Click(sender As Object, e As EventArgs) Handles ButtonOpenConfiguration.Click
        If GroupBoxWslConfBoot.Visible Then
            GroupBoxWslConfBoot.Visible = False
            GroupBoxWslConfAutoMount.Visible = False
            ButtonOpenConfiguration.Text = Resources.DistributionPageButtonOpenConf
        Else
            IsLoading = True
            ButtonOpenConfiguration.Enabled = False
            InitWslConf().ContinueWith(
                Sub() Invoke(
                    Sub()
                        IsLoading = False
                        GroupBoxWslConfBoot.Visible = True
                        GroupBoxWslConfAutoMount.Visible = True
                        ButtonOpenConfiguration.Enabled = True
                        ButtonOpenConfiguration.Text = Resources.DistributionPageButtonCloseConf
                    End Sub))
        End If
    End Sub

    Private Sub ButtonSetAsDefault_Click(sender As Object, e As EventArgs) Handles ButtonSetAsDefault.Click
        SetWSLDefaultDistribution(Data.Key)
        ButtonSetAsDefault.Enabled = False
    End Sub
End Class
