Imports System.Text.RegularExpressions

Module Conf
    Private ReadOnly rgComment As New Regex("#.*$")
    Private ReadOnly rgSection As New Regex("^\s*\[(.*?)\]")
    Private ReadOnly rgKeyValue As New Regex("^\s*(.+?)\s*=\s*(.*?)\s*$")

    Public Function ConfReadValue(Content As IList(Of String), Section As String, Name As String) As String
        Dim isMatchSection As Boolean = False
        For Each line In Content
            line = rgComment.Replace(line, "")
            Dim m = rgSection.Match(line)
            If m IsNot Nothing And m.Groups.Count >= 2 Then
                isMatchSection = String.Compare(Section, m.Groups(1).Value, True) = 0
            ElseIf isMatchSection Then
                m = rgKeyValue.Match(line)
                If m IsNot Nothing And m.Groups.Count >= 3 Then
                    If String.Compare(Name, m.Groups(1).Value, True) = 0 Then
                        Return m.Groups(2).Value.Replace("\\", "\")
                    End If
                End If
            End If
        Next
        Return Nothing
    End Function

    Public Function ConfReadBooleanValue(Content As IList(Of String), Section As String, Name As String) As Boolean?
        Dim value = ConfReadValue(Content, Section, Name)
        If value Is Nothing Then
            Return Nothing
        End If
        value = value.ToLower()
        If value = "true" Then
            Return True
        ElseIf value = "false" Then
            Return False
        End If
        If IsNumeric(value) Then
            Return CDbl(value) <> 0
        End If
        Return Nothing
    End Function

    Public Sub ConfWriteValue(Content As IList(Of String), Section As String, Name As String, Value As String)
        Dim isMatchSection As Boolean = False
        Value = Value.Replace("\", "\\")
        For i = 0 To Content.Count - 1
            Dim line = Content(i)
            line = rgComment.Replace(line, "")
            Dim m = rgSection.Match(line)
            If m IsNot Nothing And m.Groups.Count >= 2 Then
                If isMatchSection Then
                    ' Insert to the last of the section
                    Content.Insert(i, $"{Name}={Value}")
                    Exit Sub
                End If
                isMatchSection = String.Compare(Section, m.Groups(1).Value, True) = 0
            ElseIf isMatchSection Then
                m = rgKeyValue.Match(line)
                If m IsNot Nothing And m.Groups.Count >= 3 Then
                    If String.Compare(Name, m.Groups(1).Value, True) = 0 Then
                        Content(i) = $"{Name}={Value}"
                        Exit Sub
                    End If
                End If
            End If
        Next
        If Not isMatchSection Then
            ' Add section
            Content.Add($"[{Section}]")
        End If
        ' Insert to the last of the section
        Content.Add($"{Name}={Value}")
    End Sub

    Public Sub ConfRemoveValue(Content As IList(Of String), Section As String, Name As String)
        Dim isMatchSection As Boolean = False
        Dim i = 0
        Do While i < Content.Count
            Dim line = Content(i)
            line = rgComment.Replace(line, "")
            Dim m = rgSection.Match(line)
            If m IsNot Nothing And m.Groups.Count >= 2 Then
                isMatchSection = String.Compare(Section, m.Groups(1).Value, True) = 0
            ElseIf isMatchSection Then
                m = rgKeyValue.Match(line)
                If m IsNot Nothing And m.Groups.Count >= 3 Then
                    If String.Compare(Name, m.Groups(1).Value, True) = 0 Then
                        Content.RemoveAt(i)
                        i -= 1
                    End If
                End If
            End If
            i += 1
        Loop
    End Sub

    Public Sub ConfWriteOrRemoveValue(Content As IList(Of String), Section As String, Name As String, Value As String, UseDefault As Boolean)
        If UseDefault Then
            ConfRemoveValue(Content, Section, Name)
        Else
            ConfWriteValue(Content, Section, Name, Value)
        End If
    End Sub

    Public Sub ConfWriteBooleanValue(Content As IList(Of String), Section As String, Name As String, Value As Boolean)
        If ConfReadBooleanValue(Content, Section, Name) = Value Then
            Return
        End If
        ConfWriteValue(Content, Section, Name, If(Value, "true", "false"))
    End Sub

    Public Sub ConfWriteOrRemoveBooleanValue(Content As IList(Of String), Section As String, Name As String, Value As CheckState)
        If Value = CheckState.Indeterminate Then
            ConfRemoveValue(Content, Section, Name)
        Else
            ConfWriteBooleanValue(Content, Section, Name, Value = CheckState.Checked)
        End If
    End Sub
End Module
