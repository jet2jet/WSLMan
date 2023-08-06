<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DistributionPage
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
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
        Dim LabelDistributionName As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DistributionPage))
        Dim LabelWSLVersion As System.Windows.Forms.Label
        Dim LabelDefaultUser As System.Windows.Forms.Label
        Dim LabelPackageName As System.Windows.Forms.Label
        Dim LabelBasePath As System.Windows.Forms.Label
        Dim LabelAutoMountRoot As System.Windows.Forms.Label
        Dim LabelAutoMountOptions As System.Windows.Forms.Label
        Dim LabelVhdFileName As System.Windows.Forms.Label
        Me.TextBoxDistributionName = New System.Windows.Forms.TextBox()
        Me.LabelWSLVersionValue = New System.Windows.Forms.Label()
        Me.TextBoxPackageName = New System.Windows.Forms.TextBox()
        Me.TextBoxBasePath = New System.Windows.Forms.TextBox()
        Me.ButtonChangeBasePath = New System.Windows.Forms.Button()
        Me.GroupBoxWslConfBoot = New System.Windows.Forms.GroupBox()
        Me.CheckBoxUseSystemd = New System.Windows.Forms.CheckBox()
        Me.LabelBootCommand = New System.Windows.Forms.Label()
        Me.TextBoxBootCommand = New System.Windows.Forms.TextBox()
        Me.CheckBoxDefaultBootCommand = New System.Windows.Forms.CheckBox()
        Me.GroupBoxWslConfAutoMount = New System.Windows.Forms.GroupBox()
        Me.CheckBoxAutoMountEnabled = New System.Windows.Forms.CheckBox()
        Me.CheckBoxMountFsTab = New System.Windows.Forms.CheckBox()
        Me.TextBoxAutoMountRoot = New System.Windows.Forms.TextBox()
        Me.CheckBoxDefaultAutoMountRoot = New System.Windows.Forms.CheckBox()
        Me.TextBoxAutoMountOptions = New System.Windows.Forms.TextBox()
        Me.CheckBoxDefaultAutoMountOptions = New System.Windows.Forms.CheckBox()
        Me.ButtonOpenConfiguration = New System.Windows.Forms.Button()
        Me.NumericDefaultUser = New System.Windows.Forms.NumericUpDown()
        Me.ButtonChangeDefaultUser = New System.Windows.Forms.Button()
        Me.ButtonSetAsDefault = New System.Windows.Forms.Button()
        Me.TextBoxVhdFileName = New System.Windows.Forms.TextBox()
        LabelDistributionName = New System.Windows.Forms.Label()
        LabelWSLVersion = New System.Windows.Forms.Label()
        LabelDefaultUser = New System.Windows.Forms.Label()
        LabelPackageName = New System.Windows.Forms.Label()
        LabelBasePath = New System.Windows.Forms.Label()
        LabelAutoMountRoot = New System.Windows.Forms.Label()
        LabelAutoMountOptions = New System.Windows.Forms.Label()
        LabelVhdFileName = New System.Windows.Forms.Label()
        Me.GroupBoxWslConfBoot.SuspendLayout()
        Me.GroupBoxWslConfAutoMount.SuspendLayout()
        CType(Me.NumericDefaultUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelDistributionName
        '
        resources.ApplyResources(LabelDistributionName, "LabelDistributionName")
        LabelDistributionName.Name = "LabelDistributionName"
        '
        'LabelWSLVersion
        '
        resources.ApplyResources(LabelWSLVersion, "LabelWSLVersion")
        LabelWSLVersion.Name = "LabelWSLVersion"
        '
        'LabelDefaultUser
        '
        resources.ApplyResources(LabelDefaultUser, "LabelDefaultUser")
        LabelDefaultUser.Name = "LabelDefaultUser"
        '
        'LabelPackageName
        '
        resources.ApplyResources(LabelPackageName, "LabelPackageName")
        LabelPackageName.Name = "LabelPackageName"
        '
        'LabelBasePath
        '
        resources.ApplyResources(LabelBasePath, "LabelBasePath")
        LabelBasePath.Name = "LabelBasePath"
        '
        'LabelAutoMountRoot
        '
        resources.ApplyResources(LabelAutoMountRoot, "LabelAutoMountRoot")
        LabelAutoMountRoot.Name = "LabelAutoMountRoot"
        '
        'LabelAutoMountOptions
        '
        resources.ApplyResources(LabelAutoMountOptions, "LabelAutoMountOptions")
        LabelAutoMountOptions.Name = "LabelAutoMountOptions"
        '
        'TextBoxDistributionName
        '
        resources.ApplyResources(Me.TextBoxDistributionName, "TextBoxDistributionName")
        Me.TextBoxDistributionName.Name = "TextBoxDistributionName"
        '
        'LabelWSLVersionValue
        '
        resources.ApplyResources(Me.LabelWSLVersionValue, "LabelWSLVersionValue")
        Me.LabelWSLVersionValue.Name = "LabelWSLVersionValue"
        '
        'TextBoxPackageName
        '
        resources.ApplyResources(Me.TextBoxPackageName, "TextBoxPackageName")
        Me.TextBoxPackageName.Name = "TextBoxPackageName"
        Me.TextBoxPackageName.ReadOnly = True
        '
        'TextBoxBasePath
        '
        resources.ApplyResources(Me.TextBoxBasePath, "TextBoxBasePath")
        Me.TextBoxBasePath.Name = "TextBoxBasePath"
        Me.TextBoxBasePath.ReadOnly = True
        '
        'ButtonChangeBasePath
        '
        resources.ApplyResources(Me.ButtonChangeBasePath, "ButtonChangeBasePath")
        Me.ButtonChangeBasePath.Name = "ButtonChangeBasePath"
        Me.ButtonChangeBasePath.UseVisualStyleBackColor = True
        '
        'GroupBoxWslConfBoot
        '
        Me.GroupBoxWslConfBoot.Controls.Add(Me.CheckBoxUseSystemd)
        Me.GroupBoxWslConfBoot.Controls.Add(Me.LabelBootCommand)
        Me.GroupBoxWslConfBoot.Controls.Add(Me.TextBoxBootCommand)
        Me.GroupBoxWslConfBoot.Controls.Add(Me.CheckBoxDefaultBootCommand)
        resources.ApplyResources(Me.GroupBoxWslConfBoot, "GroupBoxWslConfBoot")
        Me.GroupBoxWslConfBoot.Name = "GroupBoxWslConfBoot"
        Me.GroupBoxWslConfBoot.TabStop = False
        '
        'CheckBoxUseSystemd
        '
        resources.ApplyResources(Me.CheckBoxUseSystemd, "CheckBoxUseSystemd")
        Me.CheckBoxUseSystemd.Name = "CheckBoxUseSystemd"
        Me.CheckBoxUseSystemd.ThreeState = True
        Me.CheckBoxUseSystemd.UseVisualStyleBackColor = True
        '
        'LabelBootCommand
        '
        resources.ApplyResources(Me.LabelBootCommand, "LabelBootCommand")
        Me.LabelBootCommand.Name = "LabelBootCommand"
        '
        'TextBoxBootCommand
        '
        resources.ApplyResources(Me.TextBoxBootCommand, "TextBoxBootCommand")
        Me.TextBoxBootCommand.Name = "TextBoxBootCommand"
        '
        'CheckBoxDefaultBootCommand
        '
        resources.ApplyResources(Me.CheckBoxDefaultBootCommand, "CheckBoxDefaultBootCommand")
        Me.CheckBoxDefaultBootCommand.Name = "CheckBoxDefaultBootCommand"
        Me.CheckBoxDefaultBootCommand.UseVisualStyleBackColor = True
        '
        'GroupBoxWslConfAutoMount
        '
        Me.GroupBoxWslConfAutoMount.Controls.Add(Me.CheckBoxAutoMountEnabled)
        Me.GroupBoxWslConfAutoMount.Controls.Add(Me.CheckBoxMountFsTab)
        Me.GroupBoxWslConfAutoMount.Controls.Add(LabelAutoMountRoot)
        Me.GroupBoxWslConfAutoMount.Controls.Add(Me.TextBoxAutoMountRoot)
        Me.GroupBoxWslConfAutoMount.Controls.Add(Me.CheckBoxDefaultAutoMountRoot)
        Me.GroupBoxWslConfAutoMount.Controls.Add(LabelAutoMountOptions)
        Me.GroupBoxWslConfAutoMount.Controls.Add(Me.TextBoxAutoMountOptions)
        Me.GroupBoxWslConfAutoMount.Controls.Add(Me.CheckBoxDefaultAutoMountOptions)
        resources.ApplyResources(Me.GroupBoxWslConfAutoMount, "GroupBoxWslConfAutoMount")
        Me.GroupBoxWslConfAutoMount.Name = "GroupBoxWslConfAutoMount"
        Me.GroupBoxWslConfAutoMount.TabStop = False
        '
        'CheckBoxAutoMountEnabled
        '
        resources.ApplyResources(Me.CheckBoxAutoMountEnabled, "CheckBoxAutoMountEnabled")
        Me.CheckBoxAutoMountEnabled.Name = "CheckBoxAutoMountEnabled"
        Me.CheckBoxAutoMountEnabled.ThreeState = True
        Me.CheckBoxAutoMountEnabled.UseVisualStyleBackColor = True
        '
        'CheckBoxMountFsTab
        '
        resources.ApplyResources(Me.CheckBoxMountFsTab, "CheckBoxMountFsTab")
        Me.CheckBoxMountFsTab.Name = "CheckBoxMountFsTab"
        Me.CheckBoxMountFsTab.ThreeState = True
        Me.CheckBoxMountFsTab.UseVisualStyleBackColor = True
        '
        'TextBoxAutoMountRoot
        '
        resources.ApplyResources(Me.TextBoxAutoMountRoot, "TextBoxAutoMountRoot")
        Me.TextBoxAutoMountRoot.Name = "TextBoxAutoMountRoot"
        '
        'CheckBoxDefaultAutoMountRoot
        '
        resources.ApplyResources(Me.CheckBoxDefaultAutoMountRoot, "CheckBoxDefaultAutoMountRoot")
        Me.CheckBoxDefaultAutoMountRoot.Name = "CheckBoxDefaultAutoMountRoot"
        Me.CheckBoxDefaultAutoMountRoot.UseVisualStyleBackColor = True
        '
        'TextBoxAutoMountOptions
        '
        resources.ApplyResources(Me.TextBoxAutoMountOptions, "TextBoxAutoMountOptions")
        Me.TextBoxAutoMountOptions.Name = "TextBoxAutoMountOptions"
        '
        'CheckBoxDefaultAutoMountOptions
        '
        resources.ApplyResources(Me.CheckBoxDefaultAutoMountOptions, "CheckBoxDefaultAutoMountOptions")
        Me.CheckBoxDefaultAutoMountOptions.Name = "CheckBoxDefaultAutoMountOptions"
        Me.CheckBoxDefaultAutoMountOptions.UseVisualStyleBackColor = True
        '
        'ButtonOpenConfiguration
        '
        resources.ApplyResources(Me.ButtonOpenConfiguration, "ButtonOpenConfiguration")
        Me.ButtonOpenConfiguration.Name = "ButtonOpenConfiguration"
        Me.ButtonOpenConfiguration.UseVisualStyleBackColor = True
        '
        'NumericDefaultUser
        '
        resources.ApplyResources(Me.NumericDefaultUser, "NumericDefaultUser")
        Me.NumericDefaultUser.Maximum = New Decimal(New Integer() {-1, 0, 0, 0})
        Me.NumericDefaultUser.Name = "NumericDefaultUser"
        '
        'ButtonChangeDefaultUser
        '
        resources.ApplyResources(Me.ButtonChangeDefaultUser, "ButtonChangeDefaultUser")
        Me.ButtonChangeDefaultUser.Name = "ButtonChangeDefaultUser"
        Me.ButtonChangeDefaultUser.UseVisualStyleBackColor = True
        '
        'ButtonSetAsDefault
        '
        resources.ApplyResources(Me.ButtonSetAsDefault, "ButtonSetAsDefault")
        Me.ButtonSetAsDefault.Name = "ButtonSetAsDefault"
        Me.ButtonSetAsDefault.UseVisualStyleBackColor = True
        '
        'TextBoxVhdFileName
        '
        resources.ApplyResources(Me.TextBoxVhdFileName, "TextBoxVhdFileName")
        Me.TextBoxVhdFileName.Name = "TextBoxVhdFileName"
        '
        'LabelVhdFileName
        '
        resources.ApplyResources(LabelVhdFileName, "LabelVhdFileName")
        LabelVhdFileName.Name = "LabelVhdFileName"
        '
        'DistributionPage
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(LabelDistributionName)
        Me.Controls.Add(Me.TextBoxDistributionName)
        Me.Controls.Add(LabelWSLVersion)
        Me.Controls.Add(Me.LabelWSLVersionValue)
        Me.Controls.Add(LabelPackageName)
        Me.Controls.Add(Me.TextBoxPackageName)
        Me.Controls.Add(LabelDefaultUser)
        Me.Controls.Add(Me.NumericDefaultUser)
        Me.Controls.Add(Me.ButtonChangeDefaultUser)
        Me.Controls.Add(LabelBasePath)
        Me.Controls.Add(Me.TextBoxBasePath)
        Me.Controls.Add(LabelVhdFileName)
        Me.Controls.Add(Me.TextBoxVhdFileName)
        Me.Controls.Add(Me.ButtonChangeBasePath)
        Me.Controls.Add(Me.ButtonOpenConfiguration)
        Me.Controls.Add(Me.ButtonSetAsDefault)
        Me.Controls.Add(Me.GroupBoxWslConfBoot)
        Me.Controls.Add(Me.GroupBoxWslConfAutoMount)
        Me.Name = "DistributionPage"
        Me.GroupBoxWslConfBoot.ResumeLayout(False)
        Me.GroupBoxWslConfBoot.PerformLayout()
        Me.GroupBoxWslConfAutoMount.ResumeLayout(False)
        Me.GroupBoxWslConfAutoMount.PerformLayout()
        CType(Me.NumericDefaultUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelDistributionName As Label
    Friend WithEvents TextBoxDistributionName As TextBox
    Friend WithEvents LabelWSLVersionValue As Label
    Friend WithEvents LabelPackageName As Label
    Friend WithEvents TextBoxPackageName As TextBox
    Friend WithEvents LabelBasePath As Label
    Friend WithEvents TextBoxBasePath As TextBox
    Friend WithEvents ButtonChangeBasePath As Button
    Friend WithEvents GroupBoxWslConfBoot As GroupBox
    Friend WithEvents CheckBoxUseSystemd As CheckBox
    Friend WithEvents TextBoxBootCommand As TextBox
    Friend WithEvents LabelBootCommand As Label
    Friend WithEvents GroupBoxWslConfAutoMount As GroupBox
    Friend WithEvents TextBoxAutoMountOptions As TextBox
    Friend WithEvents TextBoxAutoMountRoot As TextBox
    Friend WithEvents CheckBoxMountFsTab As CheckBox
    Friend WithEvents CheckBoxAutoMountEnabled As CheckBox
    Friend WithEvents CheckBoxDefaultBootCommand As CheckBox
    Friend WithEvents CheckBoxDefaultAutoMountOptions As CheckBox
    Friend WithEvents CheckBoxDefaultAutoMountRoot As CheckBox
    Friend WithEvents ButtonOpenConfiguration As Button
    Friend WithEvents NumericDefaultUser As NumericUpDown
    Friend WithEvents ButtonChangeDefaultUser As Button
    Friend WithEvents ButtonSetAsDefault As Button
    Friend WithEvents TextBoxVhdFileName As TextBox
End Class
