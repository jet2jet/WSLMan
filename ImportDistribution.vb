Imports WSLMan.My.Resources

Public Class ImportDistribution
    Private inProgress As Boolean

    Private Sub UpdateImportButtonEnabled()
        Dim e = TextBoxFileName.Text.Length > 0 AndAlso
            TextBoxDistributionName.Text.Length > 0 AndAlso
            TextBoxInstallLocation.Text.Length > 0
        ButtonDoImport.Enabled = e AndAlso Not inProgress
    End Sub

    Private Sub ImportDistribution_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim inboxInstalled = IsInboxWSLInstalled()
        RadioWSL1.Enabled = inboxInstalled
        CheckBoxIsVhd.Enabled = IsVhdImportExportAvailable()
        If Not IsVhdImportExportAvailable() Then CheckBoxIsVhd.Checked = False
        inProgress = False
    End Sub

    Private Sub ImportDistribution_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If inProgress Then
            Beep()
            e.Cancel = True
        End If
    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBoxFileName.TextChanged,
        TextBoxDistributionName.TextChanged,
        TextBoxInstallLocation.TextChanged
        UpdateImportButtonEnabled()
    End Sub

    Private Sub ButtonOpenFileName_Click(sender As Object, e As EventArgs) Handles ButtonOpenFileName.Click
        With CommonOpenFileDialog
            .Filter = JoinFilter(Resources.FileDialogFilterTarFiles, Resources.FileDialogFilterHarddiskFiles, Resources.FileDialogFilterAllFiles)
            .FileName = TextBoxFileName.Text
            If .ShowDialog() <> DialogResult.OK Then Exit Sub
            TextBoxFileName.Text = .FileName
            CheckBoxIsVhd.Checked = .FileName.EndsWith(".vhdx", StringComparison.CurrentCultureIgnoreCase)
        End With
    End Sub

    Private Sub ButtonChangeInstallLocation_Click(sender As Object, e As EventArgs) Handles ButtonChangeInstallLocation.Click
        With CommonFolderDialog
            .SelectedPath = TextBoxInstallLocation.Text
            If .ShowDialog() <> DialogResult.OK Then Exit Sub
            TextBoxInstallLocation.Text = .SelectedPath
        End With
    End Sub

    Private Sub ButtonDoImport_Click(sender As Object, e As EventArgs) Handles ButtonDoImport.Click
        Dim fileName = TextBoxFileName.Text
        Dim vhdxOption = If(CheckBoxIsVhd.Enabled AndAlso CheckBoxIsVhd.Checked, " --vhd", "")
        Dim versionOption = If(RadioWSL1.Enabled AndAlso RadioWSL1.Checked, " --version 1", " --version 2")
        Dim distroName = TextBoxDistributionName.Text
        Dim location = TextBoxInstallLocation.Text
        If fileName Is Nothing OrElse fileName.Length = 0 OrElse
                distroName Is Nothing OrElse distroName.Length = 0 OrElse
                location Is Nothing OrElse location.Length = 0 Then
            Exit Sub
        End If
        inProgress = True
        ButtonDoImport.Enabled = False
        ButtonCancel.Enabled = False
        TextBoxProgress.Text = Resources.Installing
        TextBoxProgress.Visible = True
        ClientSize = New Size(ClientSize.Width, TextBoxProgress.Top + TextBoxProgress.Height + 16)
        Dim arguments = $"--import {distroName} ""{location}"" ""{fileName}""{versionOption}{vhdxOption}"
        Dim commandLine = $"wsl.exe {arguments}"
        ExecCommandSimple("wsl.exe", arguments, True).ContinueWith(
            Sub(t)
                Invoke(Sub()
                           inProgress = False
                           ButtonCancel.Enabled = True
                           If t.Result = 0 Then
                               MessageBox.Show(Resources.WSLImportDone, GetApplicationName(), MessageBoxButtons.OK, MessageBoxIcon.Information)
                               Close()
                           Else
                               TextBoxProgress.Text = String.Format(Resources.ProcessExitedWithCode, t.Result, commandLine)
                               ButtonDoImport.Enabled = True
                           End If
                       End Sub)
            End Sub)
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Close()
    End Sub
End Class
