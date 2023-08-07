<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportDistribution
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportDistribution))
        Dim LabelDistributionName As System.Windows.Forms.Label
        Dim LabelInstallLocation As System.Windows.Forms.Label
        Dim LabelWSLVersion As System.Windows.Forms.Label
        Me.TextBoxFileName = New System.Windows.Forms.TextBox()
        Me.ButtonOpenFileName = New System.Windows.Forms.Button()
        Me.TextBoxDistributionName = New System.Windows.Forms.TextBox()
        Me.TextBoxInstallLocation = New System.Windows.Forms.TextBox()
        Me.ButtonChangeInstallLocation = New System.Windows.Forms.Button()
        Me.CheckBoxIsVhd = New System.Windows.Forms.CheckBox()
        Me.RadioWSL2 = New System.Windows.Forms.RadioButton()
        Me.RadioWSL1 = New System.Windows.Forms.RadioButton()
        Me.ButtonDoImport = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.TextBoxProgress = New System.Windows.Forms.TextBox()
        LabelFileName = New System.Windows.Forms.Label()
        LabelDistributionName = New System.Windows.Forms.Label()
        LabelInstallLocation = New System.Windows.Forms.Label()
        LabelWSLVersion = New System.Windows.Forms.Label()
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
        'LabelInstallLocation
        '
        resources.ApplyResources(LabelInstallLocation, "LabelInstallLocation")
        LabelInstallLocation.Name = "LabelInstallLocation"
        '
        'LabelWSLVersion
        '
        resources.ApplyResources(LabelWSLVersion, "LabelWSLVersion")
        LabelWSLVersion.Name = "LabelWSLVersion"
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
        'TextBoxInstallLocation
        '
        resources.ApplyResources(Me.TextBoxInstallLocation, "TextBoxInstallLocation")
        Me.TextBoxInstallLocation.Name = "TextBoxInstallLocation"
        '
        'ButtonChangeInstallLocation
        '
        resources.ApplyResources(Me.ButtonChangeInstallLocation, "ButtonChangeInstallLocation")
        Me.ButtonChangeInstallLocation.Name = "ButtonChangeInstallLocation"
        Me.ButtonChangeInstallLocation.UseVisualStyleBackColor = True
        '
        'CheckBoxIsVhd
        '
        resources.ApplyResources(Me.CheckBoxIsVhd, "CheckBoxIsVhd")
        Me.CheckBoxIsVhd.Name = "CheckBoxIsVhd"
        Me.CheckBoxIsVhd.UseVisualStyleBackColor = True
        '
        'RadioWSL2
        '
        resources.ApplyResources(Me.RadioWSL2, "RadioWSL2")
        Me.RadioWSL2.Checked = True
        Me.RadioWSL2.Name = "RadioWSL2"
        Me.RadioWSL2.TabStop = True
        Me.RadioWSL2.UseVisualStyleBackColor = True
        '
        'RadioWSL1
        '
        resources.ApplyResources(Me.RadioWSL1, "RadioWSL1")
        Me.RadioWSL1.Name = "RadioWSL1"
        Me.RadioWSL1.UseVisualStyleBackColor = True
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
        'TextBoxProgress
        '
        Me.TextBoxProgress.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.TextBoxProgress, "TextBoxProgress")
        Me.TextBoxProgress.Name = "TextBoxProgress"
        Me.TextBoxProgress.ReadOnly = True
        '
        'ImportDistribution
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.ButtonCancel
        Me.Controls.Add(Me.TextBoxProgress)
        Me.Controls.Add(LabelFileName)
        Me.Controls.Add(Me.TextBoxFileName)
        Me.Controls.Add(Me.ButtonOpenFileName)
        Me.Controls.Add(Me.CheckBoxIsVhd)
        Me.Controls.Add(LabelDistributionName)
        Me.Controls.Add(Me.TextBoxDistributionName)
        Me.Controls.Add(LabelInstallLocation)
        Me.Controls.Add(Me.TextBoxInstallLocation)
        Me.Controls.Add(Me.ButtonChangeInstallLocation)
        Me.Controls.Add(LabelWSLVersion)
        Me.Controls.Add(Me.RadioWSL1)
        Me.Controls.Add(Me.RadioWSL2)
        Me.Controls.Add(Me.ButtonDoImport)
        Me.Controls.Add(Me.ButtonCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImportDistribution"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelFileName As Label
    Friend WithEvents TextBoxFileName As TextBox
    Friend WithEvents ButtonOpenFileName As Button
    Friend WithEvents TextBoxDistributionName As TextBox
    Friend WithEvents TextBoxInstallLocation As TextBox
    Friend WithEvents ButtonChangeInstallLocation As Button
    Friend WithEvents CheckBoxIsVhd As CheckBox
    Friend WithEvents RadioWSL2 As RadioButton
    Friend WithEvents RadioWSL1 As RadioButton
    Friend WithEvents ButtonDoImport As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents TextBoxProgress As TextBox
End Class
