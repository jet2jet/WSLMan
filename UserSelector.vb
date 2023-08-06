Imports System.ComponentModel

Public Class UserSelector
    Private Distribution As String
    Private SelectedUser As Integer

    Private Sub UserSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        LabelLoading.Visible = True
        ComboBoxUser.Visible = False
        ComboBoxUser.Items.Clear()
        ButtonOK.Enabled = False
        LoadPasswd(Distribution).ContinueWith(
            Sub(t)
                Invoke(Sub()
                           If Visible = False Then Exit Sub
                           Dim found = False
                           For Each item In t.Result
                               Dim i = ComboBoxUser.Items.Add(item)
                               If item.Uid = SelectedUser Then
                                   ComboBoxUser.SelectedIndex = i
                                   found = True
                               End If
                           Next
                           LabelLoading.Visible = False
                           ComboBoxUser.Visible = True
                           ButtonOK.Enabled = True
                           If Not found Then ComboBoxUser.Text = CStr(SelectedUser)
                       End Sub)
            End Sub)
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Dim uid As Integer = 0, found = False
        For Each item_ In ComboBoxUser.Items
            Dim item = CType(item_, PasswdUserItem)
            If item.Name = ComboBoxUser.Text Then
                uid = item.Uid
                found = True
                Exit For
            ElseIf IsNumeric(ComboBoxUser.Text) Then
                Try
                    If item.Uid = CInt(ComboBoxUser.Text) Then
                        uid = item.Uid
                        ComboBoxUser.SelectedItem = item
                        found = True
                        Exit For
                    End If
                Catch
                End Try
            End If
        Next
        If Not found Then
            If Not IsNumeric(ComboBoxUser.Text) Then
                Beep()
                Exit Sub
            End If
            Try
                uid = CInt(ComboBoxUser.Text)
            Catch
                Beep()
                Exit Sub
            End Try
        End If
        SelectedUser = uid
        Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Close()
    End Sub

    Public Shadows Function Show(Distribution As String, SelectedUser As Integer) As Integer?
        Me.Distribution = Distribution
        Me.SelectedUser = SelectedUser
        If ShowDialog() = DialogResult.Cancel Then
            Return Nothing
        End If
        Return Me.SelectedUser
    End Function
End Class
