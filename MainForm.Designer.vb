<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.LabelDefaultVersion = New System.Windows.Forms.Label()
        Me.LabelKernel = New System.Windows.Forms.Label()
        Me.LabelKernelCommandLine = New System.Windows.Forms.Label()
        Me.LabelSwapFile = New System.Windows.Forms.Label()
        Me.LabelVmIdleTimeout = New System.Windows.Forms.Label()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.PageSettings = New System.Windows.Forms.TabPage()
        Me.PanelSettings = New System.Windows.Forms.Panel()
        Me.GroupBoxGeneral = New System.Windows.Forms.GroupBox()
        Me.RadioWSL1 = New System.Windows.Forms.RadioButton()
        Me.RadioWSL2 = New System.Windows.Forms.RadioButton()
        Me.LabelInboxWSLNotInstalled = New System.Windows.Forms.Label()
        Me.LabelWSLUpdateIsRecommended = New System.Windows.Forms.Label()
        Me.GroupBoxConfiguration = New System.Windows.Forms.GroupBox()
        Me.TextBoxKernel = New System.Windows.Forms.TextBox()
        Me.ButtonKernelOpen = New System.Windows.Forms.Button()
        Me.CheckBoxDefaultKernel = New System.Windows.Forms.CheckBox()
        Me.TextBoxKernelCommandLine = New System.Windows.Forms.TextBox()
        Me.CheckBoxDefaultKernelCommandLine = New System.Windows.Forms.CheckBox()
        Me.LabelMemory = New System.Windows.Forms.Label()
        Me.TextBoxMemory = New System.Windows.Forms.TextBox()
        Me.CheckBoxDefaultMemory = New System.Windows.Forms.CheckBox()
        Me.LabelProcessors = New System.Windows.Forms.Label()
        Me.NumericProcessors = New System.Windows.Forms.NumericUpDown()
        Me.CheckBoxDefaultProcessors = New System.Windows.Forms.CheckBox()
        Me.LabelSwap = New System.Windows.Forms.Label()
        Me.TextBoxSwap = New System.Windows.Forms.TextBox()
        Me.CheckBoxDefaultSwap = New System.Windows.Forms.CheckBox()
        Me.TextBoxSwapFile = New System.Windows.Forms.TextBox()
        Me.ButtonSwapFileOpen = New System.Windows.Forms.Button()
        Me.CheckBoxDefaultSwapFile = New System.Windows.Forms.CheckBox()
        Me.CheckBoxLocalhostForwarding = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSafeMode = New System.Windows.Forms.CheckBox()
        Me.CheckBoxPageReporting = New System.Windows.Forms.CheckBox()
        Me.CheckBoxGUIApplications = New System.Windows.Forms.CheckBox()
        Me.CheckBoxDebugConsole = New System.Windows.Forms.CheckBox()
        Me.CheckBoxNestedVirtualization = New System.Windows.Forms.CheckBox()
        Me.NumericVmIdleTimeout = New System.Windows.Forms.NumericUpDown()
        Me.CheckBoxDefaultVmIdleTimeout = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuItemFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemUpdateWSL = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemUpdateWSLDefault = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemUpdateWSLFromWeb = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemUpdateWSLUsingPrerelease = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemShutdownWSL = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuItemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemDistribution = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemDistributionInstall = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemDistributionImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemDistributionImportInPlace = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuItemDistributionOpenShell = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemDistributionOpenInExplorer = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemDistributionExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemDistributionTerminate = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemDistributionUnregister = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabMain.SuspendLayout()
        Me.PageSettings.SuspendLayout()
        Me.PanelSettings.SuspendLayout()
        Me.GroupBoxGeneral.SuspendLayout()
        Me.GroupBoxConfiguration.SuspendLayout()
        CType(Me.NumericProcessors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericVmIdleTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelDefaultVersion
        '
        resources.ApplyResources(Me.LabelDefaultVersion, "LabelDefaultVersion")
        Me.LabelDefaultVersion.Name = "LabelDefaultVersion"
        Me.LabelDefaultVersion.UseCompatibleTextRendering = True
        '
        'LabelKernel
        '
        resources.ApplyResources(Me.LabelKernel, "LabelKernel")
        Me.LabelKernel.Name = "LabelKernel"
        Me.LabelKernel.UseCompatibleTextRendering = True
        '
        'LabelKernelCommandLine
        '
        resources.ApplyResources(Me.LabelKernelCommandLine, "LabelKernelCommandLine")
        Me.LabelKernelCommandLine.Name = "LabelKernelCommandLine"
        Me.LabelKernelCommandLine.UseCompatibleTextRendering = True
        '
        'LabelSwapFile
        '
        resources.ApplyResources(Me.LabelSwapFile, "LabelSwapFile")
        Me.LabelSwapFile.Name = "LabelSwapFile"
        '
        'LabelVmIdleTimeout
        '
        resources.ApplyResources(Me.LabelVmIdleTimeout, "LabelVmIdleTimeout")
        Me.LabelVmIdleTimeout.Name = "LabelVmIdleTimeout"
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.PageSettings)
        resources.ApplyResources(Me.TabMain, "TabMain")
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        '
        'PageSettings
        '
        Me.PageSettings.Controls.Add(Me.PanelSettings)
        resources.ApplyResources(Me.PageSettings, "PageSettings")
        Me.PageSettings.Name = "PageSettings"
        Me.PageSettings.UseVisualStyleBackColor = True
        '
        'PanelSettings
        '
        Me.PanelSettings.Controls.Add(Me.GroupBoxGeneral)
        Me.PanelSettings.Controls.Add(Me.GroupBoxConfiguration)
        resources.ApplyResources(Me.PanelSettings, "PanelSettings")
        Me.PanelSettings.Name = "PanelSettings"
        '
        'GroupBoxGeneral
        '
        Me.GroupBoxGeneral.Controls.Add(Me.LabelDefaultVersion)
        Me.GroupBoxGeneral.Controls.Add(Me.RadioWSL1)
        Me.GroupBoxGeneral.Controls.Add(Me.RadioWSL2)
        Me.GroupBoxGeneral.Controls.Add(Me.LabelInboxWSLNotInstalled)
        Me.GroupBoxGeneral.Controls.Add(Me.LabelWSLUpdateIsRecommended)
        resources.ApplyResources(Me.GroupBoxGeneral, "GroupBoxGeneral")
        Me.GroupBoxGeneral.Name = "GroupBoxGeneral"
        Me.GroupBoxGeneral.TabStop = False
        '
        'RadioWSL1
        '
        resources.ApplyResources(Me.RadioWSL1, "RadioWSL1")
        Me.RadioWSL1.Name = "RadioWSL1"
        Me.RadioWSL1.TabStop = True
        Me.RadioWSL1.UseVisualStyleBackColor = True
        '
        'RadioWSL2
        '
        resources.ApplyResources(Me.RadioWSL2, "RadioWSL2")
        Me.RadioWSL2.Name = "RadioWSL2"
        Me.RadioWSL2.TabStop = True
        Me.RadioWSL2.UseVisualStyleBackColor = True
        '
        'LabelInboxWSLNotInstalled
        '
        resources.ApplyResources(Me.LabelInboxWSLNotInstalled, "LabelInboxWSLNotInstalled")
        Me.LabelInboxWSLNotInstalled.Name = "LabelInboxWSLNotInstalled"
        Me.LabelInboxWSLNotInstalled.UseCompatibleTextRendering = True
        '
        'LabelWSLUpdateIsRecommended
        '
        resources.ApplyResources(Me.LabelWSLUpdateIsRecommended, "LabelWSLUpdateIsRecommended")
        Me.LabelWSLUpdateIsRecommended.Name = "LabelWSLUpdateIsRecommended"
        '
        'GroupBoxConfiguration
        '
        Me.GroupBoxConfiguration.Controls.Add(Me.LabelKernel)
        Me.GroupBoxConfiguration.Controls.Add(Me.TextBoxKernel)
        Me.GroupBoxConfiguration.Controls.Add(Me.ButtonKernelOpen)
        Me.GroupBoxConfiguration.Controls.Add(Me.CheckBoxDefaultKernel)
        Me.GroupBoxConfiguration.Controls.Add(Me.LabelKernelCommandLine)
        Me.GroupBoxConfiguration.Controls.Add(Me.TextBoxKernelCommandLine)
        Me.GroupBoxConfiguration.Controls.Add(Me.CheckBoxDefaultKernelCommandLine)
        Me.GroupBoxConfiguration.Controls.Add(Me.LabelMemory)
        Me.GroupBoxConfiguration.Controls.Add(Me.TextBoxMemory)
        Me.GroupBoxConfiguration.Controls.Add(Me.CheckBoxDefaultMemory)
        Me.GroupBoxConfiguration.Controls.Add(Me.LabelProcessors)
        Me.GroupBoxConfiguration.Controls.Add(Me.NumericProcessors)
        Me.GroupBoxConfiguration.Controls.Add(Me.CheckBoxDefaultProcessors)
        Me.GroupBoxConfiguration.Controls.Add(Me.LabelSwap)
        Me.GroupBoxConfiguration.Controls.Add(Me.TextBoxSwap)
        Me.GroupBoxConfiguration.Controls.Add(Me.CheckBoxDefaultSwap)
        Me.GroupBoxConfiguration.Controls.Add(Me.LabelSwapFile)
        Me.GroupBoxConfiguration.Controls.Add(Me.TextBoxSwapFile)
        Me.GroupBoxConfiguration.Controls.Add(Me.ButtonSwapFileOpen)
        Me.GroupBoxConfiguration.Controls.Add(Me.CheckBoxDefaultSwapFile)
        Me.GroupBoxConfiguration.Controls.Add(Me.CheckBoxLocalhostForwarding)
        Me.GroupBoxConfiguration.Controls.Add(Me.CheckBoxSafeMode)
        Me.GroupBoxConfiguration.Controls.Add(Me.CheckBoxPageReporting)
        Me.GroupBoxConfiguration.Controls.Add(Me.CheckBoxGUIApplications)
        Me.GroupBoxConfiguration.Controls.Add(Me.CheckBoxDebugConsole)
        Me.GroupBoxConfiguration.Controls.Add(Me.CheckBoxNestedVirtualization)
        Me.GroupBoxConfiguration.Controls.Add(Me.LabelVmIdleTimeout)
        Me.GroupBoxConfiguration.Controls.Add(Me.NumericVmIdleTimeout)
        Me.GroupBoxConfiguration.Controls.Add(Me.CheckBoxDefaultVmIdleTimeout)
        resources.ApplyResources(Me.GroupBoxConfiguration, "GroupBoxConfiguration")
        Me.GroupBoxConfiguration.Name = "GroupBoxConfiguration"
        Me.GroupBoxConfiguration.TabStop = False
        '
        'TextBoxKernel
        '
        resources.ApplyResources(Me.TextBoxKernel, "TextBoxKernel")
        Me.TextBoxKernel.Name = "TextBoxKernel"
        '
        'ButtonKernelOpen
        '
        resources.ApplyResources(Me.ButtonKernelOpen, "ButtonKernelOpen")
        Me.ButtonKernelOpen.Name = "ButtonKernelOpen"
        Me.ButtonKernelOpen.UseVisualStyleBackColor = True
        '
        'CheckBoxDefaultKernel
        '
        resources.ApplyResources(Me.CheckBoxDefaultKernel, "CheckBoxDefaultKernel")
        Me.CheckBoxDefaultKernel.Name = "CheckBoxDefaultKernel"
        Me.CheckBoxDefaultKernel.UseVisualStyleBackColor = True
        '
        'TextBoxKernelCommandLine
        '
        resources.ApplyResources(Me.TextBoxKernelCommandLine, "TextBoxKernelCommandLine")
        Me.TextBoxKernelCommandLine.Name = "TextBoxKernelCommandLine"
        '
        'CheckBoxDefaultKernelCommandLine
        '
        resources.ApplyResources(Me.CheckBoxDefaultKernelCommandLine, "CheckBoxDefaultKernelCommandLine")
        Me.CheckBoxDefaultKernelCommandLine.Name = "CheckBoxDefaultKernelCommandLine"
        Me.CheckBoxDefaultKernelCommandLine.UseVisualStyleBackColor = True
        '
        'LabelMemory
        '
        resources.ApplyResources(Me.LabelMemory, "LabelMemory")
        Me.LabelMemory.Name = "LabelMemory"
        Me.LabelMemory.UseCompatibleTextRendering = True
        '
        'TextBoxMemory
        '
        resources.ApplyResources(Me.TextBoxMemory, "TextBoxMemory")
        Me.TextBoxMemory.Name = "TextBoxMemory"
        '
        'CheckBoxDefaultMemory
        '
        resources.ApplyResources(Me.CheckBoxDefaultMemory, "CheckBoxDefaultMemory")
        Me.CheckBoxDefaultMemory.Name = "CheckBoxDefaultMemory"
        Me.CheckBoxDefaultMemory.UseVisualStyleBackColor = True
        '
        'LabelProcessors
        '
        resources.ApplyResources(Me.LabelProcessors, "LabelProcessors")
        Me.LabelProcessors.Name = "LabelProcessors"
        Me.LabelProcessors.UseCompatibleTextRendering = True
        '
        'NumericProcessors
        '
        resources.ApplyResources(Me.NumericProcessors, "NumericProcessors")
        Me.NumericProcessors.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.NumericProcessors.Name = "NumericProcessors"
        '
        'CheckBoxDefaultProcessors
        '
        resources.ApplyResources(Me.CheckBoxDefaultProcessors, "CheckBoxDefaultProcessors")
        Me.CheckBoxDefaultProcessors.Name = "CheckBoxDefaultProcessors"
        Me.CheckBoxDefaultProcessors.UseVisualStyleBackColor = True
        '
        'LabelSwap
        '
        resources.ApplyResources(Me.LabelSwap, "LabelSwap")
        Me.LabelSwap.Name = "LabelSwap"
        Me.LabelSwap.UseCompatibleTextRendering = True
        '
        'TextBoxSwap
        '
        resources.ApplyResources(Me.TextBoxSwap, "TextBoxSwap")
        Me.TextBoxSwap.Name = "TextBoxSwap"
        '
        'CheckBoxDefaultSwap
        '
        resources.ApplyResources(Me.CheckBoxDefaultSwap, "CheckBoxDefaultSwap")
        Me.CheckBoxDefaultSwap.Name = "CheckBoxDefaultSwap"
        Me.CheckBoxDefaultSwap.UseVisualStyleBackColor = True
        '
        'TextBoxSwapFile
        '
        resources.ApplyResources(Me.TextBoxSwapFile, "TextBoxSwapFile")
        Me.TextBoxSwapFile.Name = "TextBoxSwapFile"
        '
        'ButtonSwapFileOpen
        '
        resources.ApplyResources(Me.ButtonSwapFileOpen, "ButtonSwapFileOpen")
        Me.ButtonSwapFileOpen.Name = "ButtonSwapFileOpen"
        Me.ButtonSwapFileOpen.UseVisualStyleBackColor = True
        '
        'CheckBoxDefaultSwapFile
        '
        resources.ApplyResources(Me.CheckBoxDefaultSwapFile, "CheckBoxDefaultSwapFile")
        Me.CheckBoxDefaultSwapFile.Name = "CheckBoxDefaultSwapFile"
        Me.CheckBoxDefaultSwapFile.UseVisualStyleBackColor = True
        '
        'CheckBoxLocalhostForwarding
        '
        resources.ApplyResources(Me.CheckBoxLocalhostForwarding, "CheckBoxLocalhostForwarding")
        Me.CheckBoxLocalhostForwarding.Name = "CheckBoxLocalhostForwarding"
        Me.CheckBoxLocalhostForwarding.Tag = "localhostForwarding"
        Me.CheckBoxLocalhostForwarding.ThreeState = True
        Me.CheckBoxLocalhostForwarding.UseVisualStyleBackColor = True
        '
        'CheckBoxSafeMode
        '
        resources.ApplyResources(Me.CheckBoxSafeMode, "CheckBoxSafeMode")
        Me.CheckBoxSafeMode.Name = "CheckBoxSafeMode"
        Me.CheckBoxSafeMode.Tag = "safeMode"
        Me.CheckBoxSafeMode.ThreeState = True
        Me.CheckBoxSafeMode.UseVisualStyleBackColor = True
        '
        'CheckBoxPageReporting
        '
        resources.ApplyResources(Me.CheckBoxPageReporting, "CheckBoxPageReporting")
        Me.CheckBoxPageReporting.Name = "CheckBoxPageReporting"
        Me.CheckBoxPageReporting.Tag = "pageReporting"
        Me.CheckBoxPageReporting.ThreeState = True
        Me.CheckBoxPageReporting.UseVisualStyleBackColor = True
        '
        'CheckBoxGUIApplications
        '
        resources.ApplyResources(Me.CheckBoxGUIApplications, "CheckBoxGUIApplications")
        Me.CheckBoxGUIApplications.Name = "CheckBoxGUIApplications"
        Me.CheckBoxGUIApplications.Tag = "guiApplications"
        Me.CheckBoxGUIApplications.ThreeState = True
        Me.CheckBoxGUIApplications.UseVisualStyleBackColor = True
        '
        'CheckBoxDebugConsole
        '
        resources.ApplyResources(Me.CheckBoxDebugConsole, "CheckBoxDebugConsole")
        Me.CheckBoxDebugConsole.Name = "CheckBoxDebugConsole"
        Me.CheckBoxDebugConsole.Tag = "debugConsole"
        Me.CheckBoxDebugConsole.ThreeState = True
        Me.CheckBoxDebugConsole.UseVisualStyleBackColor = True
        '
        'CheckBoxNestedVirtualization
        '
        resources.ApplyResources(Me.CheckBoxNestedVirtualization, "CheckBoxNestedVirtualization")
        Me.CheckBoxNestedVirtualization.Name = "CheckBoxNestedVirtualization"
        Me.CheckBoxNestedVirtualization.Tag = "nestedVirtualization"
        Me.CheckBoxNestedVirtualization.ThreeState = True
        Me.CheckBoxNestedVirtualization.UseVisualStyleBackColor = True
        '
        'NumericVmIdleTimeout
        '
        resources.ApplyResources(Me.NumericVmIdleTimeout, "NumericVmIdleTimeout")
        Me.NumericVmIdleTimeout.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NumericVmIdleTimeout.Name = "NumericVmIdleTimeout"
        '
        'CheckBoxDefaultVmIdleTimeout
        '
        resources.ApplyResources(Me.CheckBoxDefaultVmIdleTimeout, "CheckBoxDefaultVmIdleTimeout")
        Me.CheckBoxDefaultVmIdleTimeout.Name = "CheckBoxDefaultVmIdleTimeout"
        Me.CheckBoxDefaultVmIdleTimeout.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(36, 36)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemFile, Me.MenuItemDistribution})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'MenuItemFile
        '
        Me.MenuItemFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemUpdateWSL, Me.MenuItemShutdownWSL, Me.ToolStripSeparator2, Me.MenuItemExit})
        Me.MenuItemFile.Name = "MenuItemFile"
        resources.ApplyResources(Me.MenuItemFile, "MenuItemFile")
        '
        'MenuItemUpdateWSL
        '
        Me.MenuItemUpdateWSL.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemUpdateWSLDefault, Me.MenuItemUpdateWSLFromWeb, Me.MenuItemUpdateWSLUsingPrerelease})
        Me.MenuItemUpdateWSL.Name = "MenuItemUpdateWSL"
        resources.ApplyResources(Me.MenuItemUpdateWSL, "MenuItemUpdateWSL")
        '
        'MenuItemUpdateWSLDefault
        '
        Me.MenuItemUpdateWSLDefault.Name = "MenuItemUpdateWSLDefault"
        resources.ApplyResources(Me.MenuItemUpdateWSLDefault, "MenuItemUpdateWSLDefault")
        '
        'MenuItemUpdateWSLFromWeb
        '
        Me.MenuItemUpdateWSLFromWeb.Name = "MenuItemUpdateWSLFromWeb"
        resources.ApplyResources(Me.MenuItemUpdateWSLFromWeb, "MenuItemUpdateWSLFromWeb")
        '
        'MenuItemUpdateWSLUsingPrerelease
        '
        Me.MenuItemUpdateWSLUsingPrerelease.Name = "MenuItemUpdateWSLUsingPrerelease"
        resources.ApplyResources(Me.MenuItemUpdateWSLUsingPrerelease, "MenuItemUpdateWSLUsingPrerelease")
        '
        'MenuItemShutdownWSL
        '
        Me.MenuItemShutdownWSL.Name = "MenuItemShutdownWSL"
        resources.ApplyResources(Me.MenuItemShutdownWSL, "MenuItemShutdownWSL")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'MenuItemExit
        '
        Me.MenuItemExit.Name = "MenuItemExit"
        resources.ApplyResources(Me.MenuItemExit, "MenuItemExit")
        '
        'MenuItemDistribution
        '
        Me.MenuItemDistribution.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemDistributionInstall, Me.MenuItemDistributionImport, Me.MenuItemDistributionImportInPlace, Me.ToolStripSeparator1, Me.MenuItemDistributionOpenShell, Me.MenuItemDistributionOpenInExplorer, Me.MenuItemDistributionExport, Me.MenuItemDistributionTerminate, Me.MenuItemDistributionUnregister})
        Me.MenuItemDistribution.Name = "MenuItemDistribution"
        resources.ApplyResources(Me.MenuItemDistribution, "MenuItemDistribution")
        '
        'MenuItemDistributionInstall
        '
        Me.MenuItemDistributionInstall.Name = "MenuItemDistributionInstall"
        resources.ApplyResources(Me.MenuItemDistributionInstall, "MenuItemDistributionInstall")
        '
        'MenuItemDistributionImport
        '
        Me.MenuItemDistributionImport.Name = "MenuItemDistributionImport"
        resources.ApplyResources(Me.MenuItemDistributionImport, "MenuItemDistributionImport")
        '
        'MenuItemDistributionImportInPlace
        '
        Me.MenuItemDistributionImportInPlace.Name = "MenuItemDistributionImportInPlace"
        resources.ApplyResources(Me.MenuItemDistributionImportInPlace, "MenuItemDistributionImportInPlace")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'MenuItemDistributionOpenShell
        '
        Me.MenuItemDistributionOpenShell.Name = "MenuItemDistributionOpenShell"
        resources.ApplyResources(Me.MenuItemDistributionOpenShell, "MenuItemDistributionOpenShell")
        '
        'MenuItemDistributionOpenInExplorer
        '
        Me.MenuItemDistributionOpenInExplorer.Name = "MenuItemDistributionOpenInExplorer"
        resources.ApplyResources(Me.MenuItemDistributionOpenInExplorer, "MenuItemDistributionOpenInExplorer")
        '
        'MenuItemDistributionExport
        '
        Me.MenuItemDistributionExport.Name = "MenuItemDistributionExport"
        resources.ApplyResources(Me.MenuItemDistributionExport, "MenuItemDistributionExport")
        '
        'MenuItemDistributionTerminate
        '
        Me.MenuItemDistributionTerminate.Name = "MenuItemDistributionTerminate"
        resources.ApplyResources(Me.MenuItemDistributionTerminate, "MenuItemDistributionTerminate")
        '
        'MenuItemDistributionUnregister
        '
        Me.MenuItemDistributionUnregister.Name = "MenuItemDistributionUnregister"
        resources.ApplyResources(Me.MenuItemDistributionUnregister, "MenuItemDistributionUnregister")
        '
        'MainForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.TabMain.ResumeLayout(False)
        Me.PageSettings.ResumeLayout(False)
        Me.PanelSettings.ResumeLayout(False)
        Me.GroupBoxGeneral.ResumeLayout(False)
        Me.GroupBoxGeneral.PerformLayout()
        Me.GroupBoxConfiguration.ResumeLayout(False)
        Me.GroupBoxConfiguration.PerformLayout()
        CType(Me.NumericProcessors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericVmIdleTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabMain As TabControl
    Friend WithEvents PageSettings As TabPage
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuItemFile As ToolStripMenuItem
    Friend WithEvents MenuItemExit As ToolStripMenuItem
    Friend WithEvents MenuItemDistribution As ToolStripMenuItem
    Friend WithEvents MenuItemDistributionInstall As ToolStripMenuItem
    Friend WithEvents MenuItemDistributionImport As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents MenuItemDistributionExport As ToolStripMenuItem
    Friend WithEvents MenuItemDistributionTerminate As ToolStripMenuItem
    Friend WithEvents MenuItemDistributionOpenShell As ToolStripMenuItem
    Friend WithEvents MenuItemDistributionImportInPlace As ToolStripMenuItem
    Friend WithEvents MenuItemShutdownWSL As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents MenuItemDistributionUnregister As ToolStripMenuItem
    Friend WithEvents MenuItemUpdateWSL As ToolStripMenuItem
    Friend WithEvents MenuItemUpdateWSLDefault As ToolStripMenuItem
    Friend WithEvents MenuItemUpdateWSLFromWeb As ToolStripMenuItem
    Friend WithEvents MenuItemUpdateWSLUsingPrerelease As ToolStripMenuItem
    Friend WithEvents MenuItemDistributionOpenInExplorer As ToolStripMenuItem
    Friend WithEvents PanelSettings As Panel
    Friend WithEvents GroupBoxConfiguration As GroupBox
    Friend WithEvents TextBoxKernel As TextBox
    Friend WithEvents ButtonKernelOpen As Button
    Friend WithEvents CheckBoxDefaultKernel As CheckBox
    Friend WithEvents TextBoxKernelCommandLine As TextBox
    Friend WithEvents CheckBoxDefaultKernelCommandLine As CheckBox
    Friend WithEvents LabelMemory As Label
    Friend WithEvents TextBoxMemory As TextBox
    Friend WithEvents CheckBoxDefaultMemory As CheckBox
    Friend WithEvents LabelProcessors As Label
    Friend WithEvents NumericProcessors As NumericUpDown
    Friend WithEvents CheckBoxDefaultProcessors As CheckBox
    Friend WithEvents LabelSwap As Label
    Friend WithEvents TextBoxSwap As TextBox
    Friend WithEvents CheckBoxDefaultSwap As CheckBox
    Friend WithEvents TextBoxSwapFile As TextBox
    Friend WithEvents ButtonSwapFileOpen As Button
    Friend WithEvents CheckBoxDefaultSwapFile As CheckBox
    Friend WithEvents CheckBoxLocalhostForwarding As CheckBox
    Friend WithEvents CheckBoxSafeMode As CheckBox
    Friend WithEvents CheckBoxPageReporting As CheckBox
    Friend WithEvents CheckBoxGUIApplications As CheckBox
    Friend WithEvents CheckBoxDebugConsole As CheckBox
    Friend WithEvents CheckBoxNestedVirtualization As CheckBox
    Friend WithEvents NumericVmIdleTimeout As NumericUpDown
    Friend WithEvents CheckBoxDefaultVmIdleTimeout As CheckBox
    Friend WithEvents GroupBoxGeneral As GroupBox
    Friend WithEvents RadioWSL1 As RadioButton
    Friend WithEvents RadioWSL2 As RadioButton
    Friend WithEvents LabelInboxWSLNotInstalled As Label
    Friend WithEvents LabelWSLUpdateIsRecommended As Label
    Friend WithEvents LabelKernel As Label
    Friend WithEvents LabelKernelCommandLine As Label
    Friend WithEvents LabelSwapFile As Label
    Friend WithEvents LabelVmIdleTimeout As Label
    Friend WithEvents LabelDefaultVersion As Label
End Class
