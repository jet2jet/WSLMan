Imports System.Threading
Imports WSLMan.My.Resources

Public Class ExecProgress
    Private IsProcessComplete As Boolean = False
    Private CancellationTokenSource As CancellationTokenSource
    Private _exitCode As Integer? = Nothing
    Private CommandLine As String

    Public Sub ShowExecute(Command As String, Arguments As String, Optional PauseOnFail As Boolean = False)
        IsProcessComplete = False
        CancellationTokenSource = New CancellationTokenSource()
        CommandLine = $"{Command} {Arguments}"
        _exitCode = Nothing
        ExecCommandSimple(
            Command,
            Arguments,
            PauseOnFail,
            CancellationTokenSource.Token
        ).ContinueWith(Sub(t)
                           If Not Created Then
                               _exitCode = t.Result
                               Exit Sub
                           End If
                           Invoke(Sub() OnComplete(t.Result))
                       End Sub)
        ShowDialog()
    End Sub

    Private Sub OnComplete(ExitCode As Integer)
        IsProcessComplete = True
        TextBoxProgress.Text = String.Format(Resources.ProcessExitedWithCode, ExitCode, CommandLine)
        TextBoxProgress.SelectionStart = 0
        TextBoxProgress.SelectionLength = 0
        TextBoxProgress.ScrollToCaret()
        ButtonAbort.Text = Resources.CloseText
        If ExitCode = 0 Then ButtonAbort.Focus()
    End Sub

    Private Sub ExecProgress_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBoxProgress.Text = String.Format(Resources.ExecutingMessage, CommandLine)
        TextBoxProgress.SelectionStart = 0
        TextBoxProgress.SelectionLength = 0
        TextBoxProgress.ScrollToCaret()
        If _exitCode IsNot Nothing Then
            OnComplete(CInt(_exitCode))
        End If
    End Sub

    Private Sub ButtonAbort_Click(sender As Object, e As EventArgs) Handles ButtonAbort.Click
        Close()
    End Sub

    Private Sub ExecProgress_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not IsProcessComplete Then
            If MessageBox.Show(Resources.AbortProcessPrompt, GetApplicationName(), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
                e.Cancel = True
                Exit Sub
            End If
            CancellationTokenSource.Cancel()
            e.Cancel = True
        End If
    End Sub
End Class
