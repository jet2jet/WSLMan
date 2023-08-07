<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InstallDistribution
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
        Dim LabelDistribution As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InstallDistribution))
        Me.ButtonInstall = New System.Windows.Forms.Button()
        Me.LabelDistributionLoading = New System.Windows.Forms.Label()
        Me.ComboBoxDistribution = New System.Windows.Forms.ComboBox()
        Me.TextBoxInstallProgress = New System.Windows.Forms.TextBox()
        Me.ButtonClose = New System.Windows.Forms.Button()
        LabelDistribution = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelDistribution
        '
        resources.ApplyResources(LabelDistribution, "LabelDistribution")
        LabelDistribution.Name = "LabelDistribution"
        '
        'ButtonInstall
        '
        resources.ApplyResources(Me.ButtonInstall, "ButtonInstall")
        Me.ButtonInstall.Name = "ButtonInstall"
        Me.ButtonInstall.UseVisualStyleBackColor = True
        '
        'LabelDistributionLoading
        '
        resources.ApplyResources(Me.LabelDistributionLoading, "LabelDistributionLoading")
        Me.LabelDistributionLoading.Name = "LabelDistributionLoading"
        '
        'ComboBoxDistribution
        '
        Me.ComboBoxDistribution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDistribution.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBoxDistribution, "ComboBoxDistribution")
        Me.ComboBoxDistribution.Name = "ComboBoxDistribution"
        '
        'TextBoxInstallProgress
        '
        resources.ApplyResources(Me.TextBoxInstallProgress, "TextBoxInstallProgress")
        Me.TextBoxInstallProgress.Name = "TextBoxInstallProgress"
        Me.TextBoxInstallProgress.ReadOnly = True
        '
        'ButtonClose
        '
        resources.ApplyResources(Me.ButtonClose, "ButtonClose")
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'InstallDistribution
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.ButtonClose
        Me.Controls.Add(LabelDistribution)
        Me.Controls.Add(Me.ComboBoxDistribution)
        Me.Controls.Add(Me.LabelDistributionLoading)
        Me.Controls.Add(Me.ButtonInstall)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.TextBoxInstallProgress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InstallDistribution"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonInstall As Button
    Friend WithEvents LabelDistributionLoading As Label
    Friend WithEvents ComboBoxDistribution As ComboBox
    Friend WithEvents TextBoxInstallProgress As TextBox
    Friend WithEvents ButtonClose As Button
End Class
