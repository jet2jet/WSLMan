Imports System.IO
Imports System.Text.RegularExpressions

Module Passwd
    Public Structure PasswdUserItem
        Public Name As String
        Public Uid As Integer

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Structure

    Public Async Function LoadPasswd(DistributionName As String) As Task(Of IList(Of PasswdUserItem))
        Dim lines = Await File.ReadAllLinesAsync($"\\wsl.localhost\{DistributionName}\etc\passwd")
        Dim list As New List(Of PasswdUserItem)
        Dim rgLine As New Regex("^(.*?):(.*?):(.*?)(?::(.*?)(?::(.*?)(?::(.*?)(?::(.*))?)?)?)?$")
        For Each line In lines
            Dim m = rgLine.Match(line)
            If m IsNot Nothing Then
                Try
                    Dim uid = CInt(Val(m.Groups(3).Value))
                    list.Add(New PasswdUserItem() With {
                        .Name = m.Groups(1).Value,
                        .Uid = uid
                    })
                Catch
                End Try
            End If
        Next
        Return list
    End Function
End Module
