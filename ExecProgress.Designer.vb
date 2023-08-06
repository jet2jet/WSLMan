<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExecProgress
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExecProgress))
        Me.ButtonAbort = New System.Windows.Forms.Button()
        Me.TextBoxProgress = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ButtonAbort
        '
        resources.ApplyResources(Me.ButtonAbort, "ButtonAbort")
        Me.ButtonAbort.Name = "ButtonAbort"
        Me.ButtonAbort.UseVisualStyleBackColor = True
        '
        'TextBoxProgress
        '
        Me.TextBoxProgress.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.TextBoxProgress, "TextBoxProgress")
        Me.TextBoxProgress.Name = "TextBoxProgress"
        Me.TextBoxProgress.ReadOnly = True
        '
        'ExecProgress
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonAbort
        Me.Controls.Add(Me.TextBoxProgress)
        Me.Controls.Add(Me.ButtonAbort)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ExecProgress"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonAbort As Button
    Friend WithEvents TextBoxProgress As TextBox
End Class
