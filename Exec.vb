Imports System.IO
Imports System.Text
Imports System.Threading
Imports Microsoft.Win32.SafeHandles

Module Exec
    Private Declare Function PeekNamedPipe Lib "kernel32.dll" _
        (hNamedPipe As SafeFileHandle, lpBuffer As IntPtr, nBufferSize As Integer, lpBytesRead As IntPtr, ByRef lpTotalBytesAvail As Integer, lpBytesLeftThisMessage As IntPtr) As Boolean

    Public Sub ExecCommandDetached(FileName As String, Arguments As String)
        ' Using cmd.exe and start command to detach process
        Dim p = New Process() With {
            .StartInfo = New ProcessStartInfo() With {
                .FileName = "cmd.exe",
                .Arguments = $"/s /c ""start ""{FileName}"" ""{FileName}"" {Arguments}""",
                .CreateNoWindow = True
            }
        }
        p.Start()
    End Sub

    Public Async Function ExecCommandSimple(FileName As String, Arguments As String, Optional PauseOnFail As Boolean = False, Optional cancellationToken As CancellationToken = Nothing) As Task(Of Integer)
        Dim fn = FileName, arg = Arguments
        If PauseOnFail Then
            fn = "cmd.exe"
            arg = $"/s /c ""wsl.exe {Arguments} || (pause & exit /b)"""
        End If
        Dim p = New Process() With {
            .StartInfo = New ProcessStartInfo() With {
                .FileName = fn,
                .Arguments = arg
            }
        }
        p.Start()
        Await Task.Run(Sub()
                           Do While Not p.HasExited
                               If Not IsNothing(cancellationToken) Then
                                   If cancellationToken.IsCancellationRequested Then
                                       p.Kill()
                                       Exit Do
                                   End If
                               End If
                               Thread.Yield()
                           Loop
                       End Sub, CancellationToken.None)
        Return p.ExitCode
    End Function

    Public Async Function ExecCommand(FileName As String, Arguments As String, Optional OnOutputReceived As Action(Of String) = Nothing, Optional cancellationToken As CancellationToken = Nothing) As Task(Of Integer)
        Dim p = New Process() With {
            .StartInfo = New ProcessStartInfo() With {
                .FileName = FileName,
                .Arguments = Arguments,
                .RedirectStandardOutput = True,
                .RedirectStandardError = True,
                .RedirectStandardInput = True,
                .StandardOutputEncoding = Encoding.Unicode,
                .CreateNoWindow = True
            }
        }
        p.Start()
        Do While Not p.HasExited
            If Not IsNothing(cancellationToken) Then
                If cancellationToken.IsCancellationRequested Then
                    p.Kill()
                    Exit Do
                End If
            End If
            Dim stream = CType(p.StandardOutput.BaseStream, FileStream)
            Dim totalAvail As Integer = 0
            Do While PeekNamedPipe(stream.SafeFileHandle, IntPtr.Zero, 0, IntPtr.Zero, totalAvail, IntPtr.Zero)
                'Do While p.StandardOutput.Peek() > -1
                Dim s As String = ""
                Do While PeekNamedPipe(stream.SafeFileHandle, IntPtr.Zero, 0, IntPtr.Zero, totalAvail, IntPtr.Zero)
                    'Do While p.StandardOutput.Peek() > -1
                    Dim buff = New Char() {Chr(0)}
                    Await p.StandardOutput.ReadAsync(buff, cancellationToken)
                    s += buff
                Loop
                OnOutputReceived?(s)
                Thread.Yield()
            Loop
            Thread.Yield()
        Loop
        Do While Not p.StandardOutput.EndOfStream
            Dim line = Await p.StandardOutput.ReadLineAsync()
            OnOutputReceived?(line + vbCrLf)
            Thread.Yield()
        Loop
        Return p.ExitCode
    End Function

    Public Async Function ExecCommandWithOutput(FileName As String, Arguments As String) As Task(Of String)
        Dim output As String = ""
        Await ExecCommand(FileName, Arguments, Sub(o)
                                                   output += o
                                               End Sub)
        Return output
    End Function
End Module
