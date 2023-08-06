Imports System.Text.RegularExpressions
Imports WSLMan.My.Resources

Public Class InstallWSL
    Private Structure DistributionItem
        Public Key As String
        Public Description As String

        Public Overrides Function ToString() As String
            Return $"{Description} ({Key})"
        End Function
    End Structure

    Private Structure NoInstallDistributionItem
        Public Overrides Function ToString() As String
            Return Resources.NoInstallDistribution
        End Function
    End Structure

    Private Success As Boolean = False

    Private Sub InstallWSL_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Success Then
            ShowMain()
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub ButtonInstall_Click(sender As Object, e As EventArgs) Handles ButtonInstall.Click
        ButtonInstall.Enabled = False
        TextBoxInstallProgress.Text = Resources.Installing
        TextBoxInstallProgress.Visible = True
        ClientSize = New Size(ClientSize.Width, TextBoxInstallProgress.Top + TextBoxInstallProgress.Height + 16)
        Dim arguments = "--install --no-distribution"
        Dim commandLine = $"wsl.exe {arguments}"
        ExecCommandSimple("wsl.exe", arguments, True).ContinueWith(
            Sub(t)
                If t.Result = 0 Then
                    Success = True
                    Invoke(Sub()
                               If MessageBox.Show(Resources.WSLInstallDone, GetApplicationName(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                   RebootSystem()
                                   Application.Exit()
                               End If
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
