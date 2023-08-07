Imports System.IO
Imports WSLMan.My.Resources

Public Class MainForm
    Private IsLoading As Boolean = False
    Private BaseWslconfigContent As String()

    Public Sub ShutdownWSL()
        Dim exec = New ExecProgress()
        exec.ShowExecute("wsl.exe", "--shutdown")
        For Each page As TabPage In TabMain.TabPages
            If page.Controls.Count >= 1 Then
                Dim c = page.Controls(0)
                If TypeOf c Is DistributionPage Then
                    Dim d = CType(c, DistributionPage)
                    d.OnShutdownWSL()
                End If
            End If
        Next
    End Sub

    Private Sub ParseWslconfig()
        Dim content As String()
        Dim fileName = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".wslconfig")
        If Not File.Exists(fileName) Then
            content = Array.Empty(Of String)()
        Else
            content = File.ReadAllLines(fileName)
        End If

        Dim kernel = ConfReadValue(content, "wsl2", "kernel")
        CheckBoxDefaultKernel.Checked = kernel Is Nothing
        TextBoxKernel.Enabled = kernel IsNot Nothing
        TextBoxKernel.Text = If(kernel, "")
        ButtonKernelOpen.Enabled = kernel IsNot Nothing
        Dim kernelCmdline = ConfReadValue(content, "wsl2", "kernelCommandLine")
        CheckBoxDefaultKernelCommandLine.Checked = kernelCmdline Is Nothing
        TextBoxKernelCommandLine.Enabled = kernelCmdline IsNot Nothing
        TextBoxKernelCommandLine.Text = If(kernelCmdline, "")
        Dim memory = ConfReadValue(content, "wsl2", "memory")
        CheckBoxDefaultMemory.Checked = memory Is Nothing
        TextBoxMemory.Enabled = memory IsNot Nothing
        TextBoxMemory.Text = If(memory, "")
        Dim processors = ConfReadValue(content, "wsl2", "processors")
        CheckBoxDefaultProcessors.Checked = processors Is Nothing
        NumericProcessors.Enabled = processors IsNot Nothing
        NumericProcessors.Value = If(processors IsNot Nothing And IsNumeric(processors), CInt(processors), 0)
        Dim swap = ConfReadValue(content, "wsl2", "swap")
        CheckBoxDefaultSwap.Checked = swap Is Nothing
        TextBoxSwap.Enabled = swap IsNot Nothing
        TextBoxSwap.Text = swap
        Dim swapFile = ConfReadValue(content, "wsl2", "swapFile")
        CheckBoxDefaultSwapFile.Checked = swapFile Is Nothing
        TextBoxSwapFile.Enabled = swapFile IsNot Nothing
        ButtonSwapFileOpen.Enabled = swapFile IsNot Nothing
        TextBoxSwapFile.Text = If(swapFile, "")
        Dim localhostForwarding = ConfReadBooleanValue(content, "wsl2", "localhostForwarding")
        CheckBoxLocalhostForwarding.CheckState = If(localhostForwarding Is Nothing, CheckState.Indeterminate, If(localhostForwarding, CheckState.Checked, CheckState.Unchecked))
        Dim safeMode = ConfReadBooleanValue(content, "wsl2", "safeMode")
        CheckBoxSafeMode.CheckState = If(safeMode Is Nothing, CheckState.Indeterminate, If(safeMode, CheckState.Checked, CheckState.Unchecked))
        Dim pageReporting = ConfReadBooleanValue(content, "wsl2", "pageReporting")
        CheckBoxPageReporting.CheckState = If(pageReporting Is Nothing, CheckState.Indeterminate, If(pageReporting, CheckState.Checked, CheckState.Unchecked))
        Dim guiApplications = ConfReadBooleanValue(content, "wsl2", "guiApplications")
        CheckBoxGUIApplications.CheckState = If(guiApplications Is Nothing, CheckState.Indeterminate, If(guiApplications, CheckState.Checked, CheckState.Unchecked))
        Dim debugConsole = ConfReadBooleanValue(content, "wsl2", "debugConsole")
        CheckBoxDebugConsole.CheckState = If(debugConsole Is Nothing, CheckState.Indeterminate, If(debugConsole, CheckState.Checked, CheckState.Unchecked))
        Dim nestedVirtualization = ConfReadBooleanValue(content, "wsl2", "nestedVirtualization")
        CheckBoxNestedVirtualization.CheckState = If(nestedVirtualization Is Nothing, CheckState.Indeterminate, If(nestedVirtualization, CheckState.Checked, CheckState.Unchecked))
        Dim vmIdleTimeout = ConfReadValue(content, "wsl2", "vmIdleTimeout")
        CheckBoxDefaultVmIdleTimeout.Checked = vmIdleTimeout Is Nothing
        NumericVmIdleTimeout.Enabled = vmIdleTimeout IsNot Nothing
        NumericVmIdleTimeout.Value = If(vmIdleTimeout IsNot Nothing And IsNumeric(vmIdleTimeout), CInt(vmIdleTimeout), 0)

        BaseWslconfigContent = content
    End Sub

    Private Sub LoadDistributions()
        Dim currentIndex = 1
        Dim allDistributions = GetAllWSLDistributions()
        For Each s In allDistributions
            Dim found = False
            For i = 1 To TabMain.TabPages.Count - 1
                Dim p = TabMain.TabPages(i)
                Dim dp = CType(p.Controls(0), DistributionPage)
                If dp.Data.Key = s.Key Then
                    dp.Data = s
                    dp.InitForm()
                    If i <> currentIndex Then
                        TabMain.TabPages.RemoveAt(i)
                        TabMain.TabPages.Insert(currentIndex, p)
                    End If
                    found = True
                    Exit For
                End If
            Next
            If Not found Then
                Dim page As New TabPage() With {
                    .UseVisualStyleBackColor = True
                }
                Dim dp As New DistributionPage() With {
                    .Data = s,
                    .TabPage = page,
                    .Left = 0,
                    .Top = 0
                }
                page.Text = s.DistributionName
                page.Controls.Add(dp)
                AddHandler page.Resize, AddressOf PageDistribution_Resize
                TabMain.TabPages.Add(page)
            End If
            currentIndex += 1
        Next
        For i = TabMain.TabPages.Count - 1 To 1 Step -1
            Dim p = TabMain.TabPages(i)
            Dim dp = CType(p.Controls(0), DistributionPage)
            Dim found = False
            For Each s In allDistributions
                If dp.Data.Key = s.Key Then
                    found = True
                    Exit For
                End If
            Next
            If Not found Then
                TabMain.TabPages.RemoveAt(i)
            End If
        Next
    End Sub

    Private Sub SaveWslconfig()
        Dim fileName = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".wslconfig")
        Dim content = New List(Of String)(BaseWslconfigContent)

        ConfWriteOrRemoveValue(content, "wsl2", "kernel", TextBoxKernel.Text, CheckBoxDefaultKernel.Checked)
        ConfWriteOrRemoveValue(content, "wsl2", "kernelCommandLine", TextBoxKernelCommandLine.Text, CheckBoxDefaultKernelCommandLine.Checked)
        ConfWriteOrRemoveValue(content, "wsl2", "memory", TextBoxMemory.Text, CheckBoxDefaultMemory.Checked)
        ConfWriteOrRemoveValue(content, "wsl2", "processors", CStr(NumericProcessors.Value), CheckBoxDefaultProcessors.Checked)
        ConfWriteOrRemoveValue(content, "wsl2", "swap", TextBoxSwap.Text, CheckBoxDefaultSwap.Checked)
        ConfWriteOrRemoveValue(content, "wsl2", "swapFile", TextBoxSwapFile.Text, CheckBoxDefaultSwapFile.Checked)
        ConfWriteOrRemoveBooleanValue(content, "wsl2", "localhostForwarding", CheckBoxLocalhostForwarding.CheckState)
        ConfWriteOrRemoveBooleanValue(content, "wsl2", "safeMode", CheckBoxSafeMode.CheckState)
        ConfWriteOrRemoveBooleanValue(content, "wsl2", "pageReporting", CheckBoxPageReporting.CheckState)
        ConfWriteOrRemoveBooleanValue(content, "wsl2", "guiApplications", CheckBoxGUIApplications.CheckState)
        ConfWriteOrRemoveBooleanValue(content, "wsl2", "debugConsole", CheckBoxDebugConsole.CheckState)
        ConfWriteOrRemoveBooleanValue(content, "wsl2", "nestedVirtualization", CheckBoxNestedVirtualization.CheckState)
        ConfWriteOrRemoveValue(content, "wsl2", "vmIdleTimeout", CStr(NumericVmIdleTimeout.Value), CheckBoxDefaultVmIdleTimeout.Checked)

        ' If data is equal, then do nothing
        If content.SequenceEqual(BaseWslconfigContent) Then
            Exit Sub
        End If
        File.WriteAllLines(fileName, content)
    End Sub

    Private Sub UpdateWslconfigBase(Writer As Action(Of IList(Of String)))
        If IsLoading Then Exit Sub
        Dim fileName = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".wslconfig")
        Dim content = New List(Of String)(BaseWslconfigContent)
        Writer(content)
        ' If data is equal, then do nothing
        If content.SequenceEqual(BaseWslconfigContent) Then
            Exit Sub
        End If
        File.WriteAllLines(fileName, content)
    End Sub

    Private Sub UpdateWslconfig(Section As String, Name As String, Value As String, UseDefault As Boolean)
        UpdateWslconfigBase(Sub(content) ConfWriteOrRemoveValue(content, Section, Name, Value, UseDefault))
    End Sub

    Private Sub UpdateWslconfigBoolean(Section As String, Name As String, Value As CheckState)
        UpdateWslconfigBase(Sub(content) ConfWriteOrRemoveBooleanValue(content, Section, Name, Value))
    End Sub

    Private Sub LayoutForm()
        PanelSettings.SuspendLayout()
        GroupBoxGeneral.SuspendLayout()
        GroupBoxConfiguration.SuspendLayout()

        GroupBoxConfiguration.ClientSize = New Size(GroupBoxConfiguration.ClientSize.Width, NumericVmIdleTimeout.Bottom + 8)
        PanelSettings.ClientSize = New Size(PanelSettings.ClientSize.Width, GroupBoxConfiguration.Bottom + PanelSettings.Padding.Bottom)

        GroupBoxConfiguration.ResumeLayout()
        GroupBoxGeneral.ResumeLayout()
        PanelSettings.ResumeLayout()
        TabMain.ClientSize = New Size(TabMain.ClientSize.Width, PageSettings.Height)
        ClientSize = New Size(ClientSize.Width, TabMain.Height + 8)
    End Sub

    Private Sub InitForm()
        IsLoading = True
        Dim inboxInstalled = IsInboxWSLInstalled()
        Dim defVersion = GetDefaultWSLVersion()
        RadioWSL1.Enabled = inboxInstalled
        LabelInboxWSLNotInstalled.Visible = Not inboxInstalled
        LabelWSLUpdateIsRecommended.Visible = inboxInstalled AndAlso GetWSLInstallationStatus() <> WSLInstallation.StoreWSL
        RadioWSL2.Checked = defVersion = 2
        RadioWSL1.Checked = defVersion = 1
        ParseWslconfig()
        IsLoading = False

        UpdateWSLCommandAvailability().ContinueWith(
            Sub() Invoke(Sub()
                             MenuItemDistributionImportInPlace.Enabled = IsImportInPlaceAvailable()
                             For Each tabPage As TabPage In TabMain.TabPages
                                 If tabPage.Controls.Count >= 1 Then
                                     Dim c = tabPage.Controls(0)
                                     If TypeOf c Is DistributionPage Then
                                         Dim d = CType(c, DistributionPage)
                                         d.OnUpdateWSLCommandAvailability()
                                     End If
                                 End If
                             Next
                         End Sub))
    End Sub

    Private Function GetCurrentTabDistribution() As WSLDistributionData?
        Dim activePage = TabMain.SelectedTab
        If activePage Is Nothing OrElse activePage.Controls.Count < 1 Then
            Return Nothing
        End If
        Dim c = activePage.Controls(0)
        If TypeOf c IsNot DistributionPage Then
            Return Nothing
        End If
        Dim d = CType(c, DistributionPage)
        Return d.Data
    End Function

    Private Sub UpdateDistributionMenu()
        Dim isActiveDistribution = GetCurrentTabDistribution() IsNot Nothing
        MenuItemDistributionOpenShell.Enabled = isActiveDistribution
        MenuItemDistributionOpenInExplorer.Enabled = isActiveDistribution
        MenuItemDistributionExport.Enabled = isActiveDistribution
        MenuItemDistributionTerminate.Enabled = isActiveDistribution
        MenuItemDistributionUnregister.Enabled = isActiveDistribution
    End Sub

    Private Sub UpdateWSLUpdateMenu()
        Dim s = GetWSLInstallationStatus()
        MenuItemUpdateWSLUsingPrerelease.Enabled = s = WSLInstallation.StoreWSL
    End Sub

    Private Sub OnAfterUpdateWSL()
        InitForm()
    End Sub

    Private Sub MainForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Application.Exit()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = GetApplicationName()
        LayoutForm()
        InitForm()
        LoadDistributions()
        OnResizePageSettings()
        UpdateDistributionMenu()
        UpdateWSLUpdateMenu()
    End Sub

    Private Sub OnResizePageSettings()
        PageSettings.SuspendLayout()
        GroupBoxGeneral.SuspendLayout()
        GroupBoxConfiguration.SuspendLayout()
        Dim isOverflow = PageSettings.Height < PanelSettings.Bottom
        Dim innerWidth = PageSettings.ClientSize.Width - PanelSettings.Padding.Horizontal
        Dim halfWidth = CInt((innerWidth - PanelSettings.Padding.Horizontal - 8) / 2)
        Dim memProcSwapWidth = CInt((innerWidth - PanelSettings.Padding.Horizontal - 16) / 3)

        PanelSettings.Width = PageSettings.ClientSize.Width
        GroupBoxGeneral.Width = innerWidth
        GroupBoxConfiguration.Width = innerWidth

        TextBoxKernel.Width = innerWidth - CheckBoxDefaultKernel.Width - PanelSettings.Padding.Horizontal - 8 - ButtonKernelOpen.Width - 4
        ButtonKernelOpen.Left = TextBoxKernel.Right + 4
        CheckBoxDefaultKernel.Left = innerWidth - CheckBoxDefaultKernel.Width - PanelSettings.Padding.Right
        TextBoxKernelCommandLine.Width = innerWidth - CheckBoxDefaultKernelCommandLine.Width - PanelSettings.Padding.Horizontal - 8
        CheckBoxDefaultKernelCommandLine.Left = innerWidth - CheckBoxDefaultKernelCommandLine.Width - PanelSettings.Padding.Right

        CheckBoxDefaultSwap.Left = innerWidth - CheckBoxDefaultSwap.Width - PanelSettings.Padding.Right
        TextBoxMemory.Width = memProcSwapWidth - CheckBoxDefaultMemory.Width - 8
        CheckBoxDefaultMemory.Left = TextBoxMemory.Right + 8
        LabelProcessors.Left = CheckBoxDefaultMemory.Right + 8
        NumericProcessors.Left = CheckBoxDefaultMemory.Right + 8
        NumericProcessors.Width = memProcSwapWidth - CheckBoxDefaultProcessors.Width - 8
        CheckBoxDefaultProcessors.Left = NumericProcessors.Right + 8
        LabelSwap.Left = CheckBoxDefaultProcessors.Right + 8
        TextBoxSwap.Left = CheckBoxDefaultProcessors.Right + 8
        TextBoxSwap.Width = memProcSwapWidth - CheckBoxDefaultSwap.Width - 8

        TextBoxSwapFile.Width = innerWidth - CheckBoxDefaultSwapFile.Width - PanelSettings.Padding.Horizontal - 8 - ButtonSwapFileOpen.Width - 4
        ButtonSwapFileOpen.Left = TextBoxSwapFile.Right + 4
        CheckBoxDefaultSwapFile.Left = innerWidth - CheckBoxDefaultSwapFile.Width - PanelSettings.Padding.Right

        CheckBoxSafeMode.Left = CheckBoxLocalhostForwarding.Left + halfWidth + 8
        CheckBoxGUIApplications.Left = CheckBoxPageReporting.Left + halfWidth + 8
        CheckBoxNestedVirtualization.Left = CheckBoxDebugConsole.Left + halfWidth + 8

        NumericVmIdleTimeout.Width = halfWidth - 8 - CheckBoxDefaultVmIdleTimeout.Width
        CheckBoxDefaultVmIdleTimeout.Left = NumericVmIdleTimeout.Right + 8

        PageSettings.VerticalScroll.Visible = isOverflow
        PageSettings.HorizontalScroll.Visible = False
        GroupBoxGeneral.ResumeLayout()
        GroupBoxConfiguration.ResumeLayout()
        PageSettings.ResumeLayout()
    End Sub

    Private Sub PageSettings_Resize(sender As Object, e As EventArgs) Handles PageSettings.Resize
        OnResizePageSettings()
    End Sub

    Private Sub PageDistribution_Resize(sender As Object, e As EventArgs)
        Dim p = CType(sender, TabPage)
        Dim c = CType(p.Controls(0), DistributionPage)
        Dim w = p.ClientSize.Width
        Dim h = p.ClientSize.Height
        Dim isOverflow = h < c.MinimumHeight
        If isOverflow Then
            h = c.MinimumHeight
        End If
        c.Size = New Size(w, h)
        p.VerticalScroll.Visible = isOverflow
        p.HorizontalScroll.Visible = False
    End Sub

    Private Sub MainForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        InitForm()
        LoadDistributions()
        UpdateWSLUpdateMenu()
    End Sub

    Private Sub RadioWSL_CheckedChanged(sender As Object, e As EventArgs)
        If RadioWSL2.Checked OrElse RadioWSL1.Checked Then
            SetDefaultWSLVersion(If(RadioWSL2.Checked, 2, 1))
        End If
    End Sub

    Private Sub TextBoxKernel_LostFocus(sender As Object, e As EventArgs)
        UpdateWslconfig("wsl2", "kernel", TextBoxKernel.Text, CheckBoxDefaultKernel.Checked)
    End Sub

    Private Sub CheckBoxDefaultKernel_CheckedChanged(sender As Object, e As EventArgs)
        TextBoxKernel.Enabled = Not CheckBoxDefaultKernel.Checked
        ButtonKernelOpen.Enabled = Not CheckBoxDefaultKernel.Checked
        If CheckBoxDefaultKernel.Checked Then
            UpdateWslconfig("wsl2", "kernel", TextBoxKernel.Text, CheckBoxDefaultKernel.Checked)
        Else
            TextBoxKernel.Focus()
        End If
    End Sub

    Private Sub ButtonKernelOpen_Click(sender As Object, e As EventArgs)
        With CommonOpenFileDialog
            .Filter = Resources.FileDialogFilterAllFiles
            .FileName = TextBoxKernel.Text
            .Multiselect = False
            If .ShowDialog() = DialogResult.OK Then
                TextBoxKernel.Text = .FileName
                UpdateWslconfig("wsl2", "kernel", TextBoxKernel.Text, CheckBoxDefaultKernel.Checked)
            End If
        End With
    End Sub

    Private Sub TextBoxKernelCommandLine_LostFocus(sender As Object, e As EventArgs)
        UpdateWslconfig("wsl2", "kernelCommandLine", TextBoxKernelCommandLine.Text, CheckBoxDefaultKernelCommandLine.Checked)
    End Sub

    Private Sub CheckBoxDefaultKernelCommandLine_CheckedChanged(sender As Object, e As EventArgs)
        TextBoxKernelCommandLine.Enabled = Not CheckBoxDefaultKernelCommandLine.Checked
        If CheckBoxDefaultKernel.Checked Then
            UpdateWslconfig("wsl2", "kernelCommandLine", TextBoxKernelCommandLine.Text, CheckBoxDefaultKernelCommandLine.Checked)
        Else
            TextBoxKernelCommandLine.Focus()
        End If
    End Sub

    Private Sub TextBoxMemory_LostFocus(sender As Object, e As EventArgs)
        UpdateWslconfig("wsl2", "memory", TextBoxMemory.Text, CheckBoxDefaultMemory.Checked)
    End Sub

    Private Sub CheckBoxDefaultMemory_CheckedChanged(sender As Object, e As EventArgs)
        TextBoxMemory.Enabled = Not CheckBoxDefaultMemory.Checked
        If CheckBoxDefaultKernel.Checked Then
            UpdateWslconfig("wsl2", "memory", TextBoxMemory.Text, CheckBoxDefaultMemory.Checked)
        Else
            TextBoxMemory.Focus()
        End If
    End Sub

    Private Sub NumericProcessors_LostFocus(sender As Object, e As EventArgs)
        UpdateWslconfig("wsl2", "processors", NumericProcessors.Text, CheckBoxDefaultProcessors.Checked)
    End Sub

    Private Sub CheckBoxDefaultProcessors_CheckedChanged(sender As Object, e As EventArgs)
        NumericProcessors.Enabled = Not CheckBoxDefaultProcessors.Checked
        If CheckBoxDefaultProcessors.Checked Then
            UpdateWslconfig("wsl2", "processors", NumericProcessors.Text, CheckBoxDefaultProcessors.Checked)
        Else
            NumericProcessors.Focus()
        End If
    End Sub

    Private Sub TextBoxSwap_LostFocus(sender As Object, e As EventArgs)
        UpdateWslconfig("wsl2", "swap", TextBoxSwap.Text, CheckBoxDefaultSwap.Checked)
    End Sub

    Private Sub CheckBoxDefaultSwap_CheckedChanged(sender As Object, e As EventArgs)
        TextBoxSwap.Enabled = Not CheckBoxDefaultSwap.Checked
        If CheckBoxDefaultProcessors.Checked Then
            UpdateWslconfig("wsl2", "swap", TextBoxSwap.Text, CheckBoxDefaultSwap.Checked)
        Else
            TextBoxSwap.Focus()
        End If
    End Sub

    Private Sub TextBoxSwapFile_LostFocus(sender As Object, e As EventArgs)
        UpdateWslconfig("wsl2", "swapFile", TextBoxSwapFile.Text, CheckBoxDefaultSwapFile.Checked)
    End Sub

    Private Sub ButtonSwapFileOpen_Click(sender As Object, e As EventArgs)
        With CommonSaveFileDialog
            .Filter = JoinFilter(Resources.FileDialogFilterHarddiskFiles, Resources.FileDialogFilterAllFiles)
            .FileName = TextBoxSwapFile.Text
            .OverwritePrompt = True
            If .ShowDialog() = DialogResult.OK Then
                TextBoxSwapFile.Text = .FileName
                UpdateWslconfig("wsl2", "swapFile", TextBoxSwapFile.Text, CheckBoxDefaultSwapFile.Checked)
            End If
        End With
    End Sub

    Private Sub CheckBoxDefaultSwapFile_CheckedChanged(sender As Object, e As EventArgs)
        TextBoxSwapFile.Enabled = Not CheckBoxDefaultSwapFile.Checked
        ButtonSwapFileOpen.Enabled = Not CheckBoxDefaultSwapFile.Checked
        If CheckBoxDefaultSwapFile.Checked Then
            UpdateWslconfig("wsl2", "swapFile", TextBoxSwapFile.Text, CheckBoxDefaultSwapFile.Checked)
        Else
            TextBoxSwapFile.Focus()
        End If
    End Sub

    Private Sub NumericVmIdleTimeout_LostFocus(sender As Object, e As EventArgs)
        UpdateWslconfig("wsl2", "vmIdleTimeout", NumericVmIdleTimeout.Text, CheckBoxDefaultVmIdleTimeout.Checked)
    End Sub

    Private Sub CheckBoxDefaultVmIdleTimeout_CheckedChanged(sender As Object, e As EventArgs)
        NumericVmIdleTimeout.Enabled = Not CheckBoxDefaultVmIdleTimeout.Checked
        If CheckBoxDefaultVmIdleTimeout.Checked Then
            UpdateWslconfig("wsl2", "vmIdleTimeout", NumericVmIdleTimeout.Text, CheckBoxDefaultVmIdleTimeout.Checked)
        Else
            NumericVmIdleTimeout.Focus()
        End If
    End Sub

    Private Sub CheckBoxBooleanData_CheckStateChanged(sender As Object, e As EventArgs) Handles _
        CheckBoxGUIApplications.CheckStateChanged,
            CheckBoxDebugConsole.CheckStateChanged
        Dim c = CType(sender, CheckBox)
        If c.Tag Is Nothing Then Exit Sub
        UpdateWslconfigBoolean("wsl2", CStr(c.Tag), c.CheckState)
    End Sub

    Private Sub TabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabMain.SelectedIndexChanged
        UpdateDistributionMenu()
    End Sub

    Private Sub MenuItemShutdownWSL_Click(sender As Object, e As EventArgs) Handles MenuItemShutdownWSL.Click
        ShutdownWSL()
    End Sub

    Private Sub MenuItemExit_Click(sender As Object, e As EventArgs) Handles MenuItemExit.Click
        Close()
    End Sub

    Private Sub MenuItemDistributionInstall_Click(sender As Object, e As EventArgs) Handles MenuItemDistributionInstall.Click
        Dim dlg As New InstallDistribution()
        dlg.ShowDialog()
    End Sub

    Private Sub MenuItemDistributionImport_Click(sender As Object, e As EventArgs) Handles MenuItemDistributionImport.Click
        Dim dlg As New ImportDistribution()
        dlg.ShowDialog()
    End Sub

    Private Sub MenuItemDistributionImportInPlace_Click(sender As Object, e As EventArgs) Handles MenuItemDistributionImportInPlace.Click
        Dim dlg As New ImportDistributionInPlace()
        dlg.ShowDialog()
    End Sub

    Private Sub MenuItemDistributionOpenShell_Click(sender As Object, e As EventArgs) Handles MenuItemDistributionOpenShell.Click
        Dim _d = GetCurrentTabDistribution()
        If _d Is Nothing Then
            Exit Sub
        End If
        Dim d = _d.Value
        ExecCommandDetached("wsl.exe", $"-d {d.DistributionName} --cd ~")
    End Sub

    Private Sub MenuItemDistributionOpenInExplorer_Click(sender As Object, e As EventArgs) Handles MenuItemDistributionOpenInExplorer.Click
        Dim _d = GetCurrentTabDistribution()
        If _d Is Nothing Then
            Exit Sub
        End If
        Dim d = _d.Value
        OpenDistributionInExplorer(d.DistributionName)
    End Sub

    Private Sub MenuItemDistributionExport_Click(sender As Object, e As EventArgs) Handles MenuItemDistributionExport.Click
        Dim _d = GetCurrentTabDistribution()
        If _d Is Nothing Then
            Exit Sub
        End If
        Dim d = _d.Value
        Dim exportDialog As New ExportDistribution() With {
            .DistributionName = d.DistributionName
        }
        If exportDialog.ShowDialog(Me) <> DialogResult.OK Then
            Exit Sub
        End If

        Dim exec = New ExecProgress()
        exec.ShowExecute("wsl.exe", $"--export {d.DistributionName} ""{exportDialog.ExportTo}""{If(exportDialog.ExportAsVhdx, " --vhd", "")}", True)
    End Sub

    Private Sub MenuItemDistributionTerminate_Click(sender As Object, e As EventArgs) Handles MenuItemDistributionTerminate.Click
        Dim _d = GetCurrentTabDistribution()
        If _d Is Nothing Then
            Exit Sub
        End If
        Dim d = _d.Value
        If MessageBox.Show(String.Format(Resources.TerminateDistributionPrompt, d.DistributionName), GetApplicationName(), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
            Exit Sub
        End If

        Dim exec = New ExecProgress()
        exec.ShowExecute("wsl.exe", $"--terminate {d.DistributionName}")
    End Sub

    Private Sub MenuItemDistributionUnregister_Click(sender As Object, e As EventArgs) Handles MenuItemDistributionUnregister.Click
        Dim _d = GetCurrentTabDistribution()
        If _d Is Nothing Then
            Exit Sub
        End If
        Dim d = _d.Value
        If MessageBox.Show(String.Format(Resources.UnregisterConfirmPrompt, d.DistributionName), GetApplicationName(), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
            Exit Sub
        End If

        Dim exec = New ExecProgress()
        exec.ShowExecute("wsl.exe", $"--unregister {d.DistributionName}")
    End Sub

    Private Sub MenuItemUpdateWSLDefault_Click(sender As Object, e As EventArgs) Handles MenuItemUpdateWSLDefault.Click
        Dim exec = New ExecProgress()
        exec.ShowExecute("wsl.exe", "--update")
        OnAfterUpdateWSL()
    End Sub

    Private Sub MenuItemUpdateWSLFromWeb_Click(sender As Object, e As EventArgs) Handles MenuItemUpdateWSLFromWeb.Click
        Dim exec = New ExecProgress()
        exec.ShowExecute("wsl.exe", "--update --web-download")
        OnAfterUpdateWSL()
    End Sub

    Private Sub MenuItemUpdateWSLUsingPrerelease_Click(sender As Object, e As EventArgs) Handles MenuItemUpdateWSLUsingPrerelease.Click
        Dim exec = New ExecProgress()
        exec.ShowExecute("wsl.exe", "--update --pre-release")
        OnAfterUpdateWSL()
    End Sub
End Class
