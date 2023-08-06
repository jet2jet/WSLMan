Imports WSLMan.My.Resources

Public Class ExportDistribution
    Public DistributionName As String
    Public ExportTo As String
    Public ExportAsVhdx As Boolean

    Private Sub ExportDistribution_Load(sender As Object, e As EventArgs) Handles Me.Load
        LabelDistributionName.Text = DistributionName
        TextBoxExportTo.Text = ExportTo
        CheckBoxExportAsVhdx.Checked = ExportAsVhdx
    End Sub

    Private Sub ButtonChangeExportTo_Click(sender As Object, e As EventArgs) Handles ButtonChangeExportTo.Click
        With CommonSaveFileDialog
            .FileName = TextBoxExportTo.Text
            .Filter = JoinFilter(Resources.FileDialogFilterTarFiles, Resources.FileDialogFilterHarddiskFiles, Resources.FileDialogFilterAllFiles)
            .OverwritePrompt = True
            If .ShowDialog() <> DialogResult.OK Then Exit Sub
            TextBoxExportTo.Text = .FileName
            CheckBoxExportAsVhdx.Checked = .FileName.EndsWith(".vhdx", StringComparison.CurrentCultureIgnoreCase)
        End With
    End Sub

    Private Sub ButtonShutdownWSL_Click(sender As Object, e As EventArgs) Handles ButtonShutdownWSL.Click
        If TypeOf Owner Is MainForm Then
            Dim fmMainForm = CType(Owner, MainForm)
            fmMainForm.ShutdownWSL()
        End If
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ExportTo = TextBoxExportTo.Text
        ExportAsVhdx = CheckBoxExportAsVhdx.Checked
        Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Close()
    End Sub
End Class
