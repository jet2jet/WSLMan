<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportDistributionInPlace
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
        Dim LabelFileName As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportDistributionInPlace))
        Dim LabelDistributionName As System.Windows.Forms.Label
        Me.TextBoxProgress = New System.Windows.Forms.TextBox()
        Me.TextBoxFileName = New System.Windows.Forms.TextBox()
        Me.ButtonOpenFileName = New System.Windows.Forms.Button()
        Me.TextBoxDistributionName = New System.Windows.Forms.TextBox()
        Me.ButtonDoImport = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        LabelFileName = New System.Windows.Forms.Label()
        LabelDistributionName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelFileName
        '
        resources.ApplyResources(LabelFileName, "LabelFileName")
        LabelFileName.Name = "LabelFileName"
        '
        'LabelDistributionName
        '
        resources.ApplyResources(LabelDistributionName, "LabelDistributionName")
        LabelDistributionName.Name = "LabelDistributionName"
        '
        'TextBoxProgress
        '
        Me.TextBoxProgress.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.TextBoxProgress, "TextBoxProgress")
        Me.TextBoxProgress.Name = "TextBoxProgress"
        Me.TextBoxProgress.ReadOnly = True
        '
        'TextBoxFileName
        '
        resources.ApplyResources(Me.TextBoxFileName, "TextBoxFileName")
        Me.TextBoxFileName.Name = "TextBoxFileName"
        '
        'ButtonOpenFileName
        '
        resources.ApplyResources(Me.ButtonOpenFileName, "ButtonOpenFileName")
        Me.ButtonOpenFileName.Name = "ButtonOpenFileName"
        Me.ButtonOpenFileName.UseVisualStyleBackColor = True
        '
        'TextBoxDistributionName
        '
        resources.ApplyResources(Me.TextBoxDistributionName, "TextBoxDistributionName")
        Me.TextBoxDistributionName.Name = "TextBoxDistributionName"
        '
        'ButtonDoImport
        '
        resources.ApplyResources(Me.ButtonDoImport, "ButtonDoImport")
        Me.ButtonDoImport.Name = "ButtonDoImport"
        Me.ButtonDoImport.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        resources.ApplyResources(Me.ButtonCancel, "ButtonCancel")
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ImportDistributionInPlace
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TextBoxProgress)
        Me.Controls.Add(LabelFileName)
        Me.Controls.Add(Me.TextBoxFileName)
        Me.Controls.Add(Me.ButtonOpenFileName)
        Me.Controls.Add(LabelDistributionName)
        Me.Controls.Add(Me.TextBoxDistributionName)
        Me.Controls.Add(Me.ButtonDoImport)
        Me.Controls.Add(Me.ButtonCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImportDistributionInPlace"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxProgress As TextBox
    Friend WithEvents TextBoxFileName As TextBox
    Friend WithEvents ButtonOpenFileName As Button
    Friend WithEvents TextBoxDistributionName As TextBox
    Friend WithEvents ButtonDoImport As Button
    Friend WithEvents ButtonCancel As Button
End Class
