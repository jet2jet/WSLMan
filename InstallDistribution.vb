Imports System.Text.RegularExpressions
Imports WSLMan.My.Resources

Public Class InstallDistribution
    Private Structure DistributionItem
        Public Key As String
        Public Description As String

        Public Overrides Function ToString() As String
            Return $"{Description} ({Key})"
        End Function
    End Structure

    Private Sub LoadDistributions(Output As String)
        Dim inDistributionList = False
        Dim rgItem = New Regex("^(.*?)\s+(.*)$")
        For Each Line In Output.Split(vbLf)
            Line = Line.Trim()
            If inDistributionList Then
                Dim m = rgItem.Match(Line)
                If m IsNot Nothing AndAlso m.Groups.Count = 3 AndAlso m.Groups(1).Value <> "" Then
                    ComboBoxDistribution.Items.Add(
                        New DistributionItem() With {.Key = m.Groups(1).Value, .Description = m.Groups(2).Value}
                    )
                End If
            Else
                If Line.StartsWith("NAME", StringComparison.OrdinalIgnoreCase) Then
                    inDistributionList = True
                End If
            End If
        Next
        Invoke(Sub()
                   LabelDistributionLoading.Visible = False
                   ComboBoxDistribution.SelectedIndex = 0
                   ComboBoxDistribution.Visible = True
                   ButtonInstall.Enabled = True
               End Sub)
    End Sub

    Private Sub InstallDistribution_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExecCommandWithOutput("wsl.exe", "--list --online").ContinueWith(Sub(t) LoadDistributions(t.Result))
    End Sub

    Private Sub ButtonInstall_Click(sender As Object, e As EventArgs) Handles ButtonInstall.Click
        Dim d = CType(ComboBoxDistribution.SelectedItem, DistributionItem?)
        If Not d.HasValue Then Exit Sub
        ButtonInstall.Enabled = False
        TextBoxInstallProgress.Text = Resources.Installing
        TextBoxInstallProgress.Visible = True
        ClientSize = New Size(ClientSize.Width, TextBoxInstallProgress.Top + TextBoxInstallProgress.Height + 16)
        Dim arguments = $"--install --distribution {d.Value.Key} -n"
        Dim commandLine = $"wsl.exe {arguments}"
        ExecCommandSimple("wsl.exe", arguments, True).ContinueWith(
            Sub(t)
                If t.Result = 0 Then
                    Invoke(Sub()
                               MessageBox.Show(Resources.DistributionInstallDone, GetApplicationName(), MessageBoxButtons.OK, MessageBoxIcon.Information)
                               ExecCommandDetached("wsl.exe", $"--install --distribution {d.Value.Key}")
                               Close()
                           End Sub)
                Else
                    Invoke(Sub()
                               TextBoxInstallProgress.Text = String.Format(Resources.ProcessExitedWithCode, t.Result, commandLine)
                               ButtonInstall.Enabled = True
                           End Sub)
                End If
            End Sub)
    End Sub
End Class
