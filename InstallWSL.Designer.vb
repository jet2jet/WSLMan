<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InstallWSL
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim LabelInstallInfo As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InstallWSL))
        Dim LabelInstallNote As System.Windows.Forms.Label
        Me.ButtonInstall = New System.Windows.Forms.Button()
        Me.TextBoxInstallProgress = New System.Windows.Forms.TextBox()
        LabelInstallInfo = New System.Windows.Forms.Label()
        LabelInstallNote = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelInstallInfo
        '
        resources.ApplyResources(LabelInstallInfo, "LabelInstallInfo")
        LabelInstallInfo.Name = "LabelInstallInfo"
        '
        'LabelInstallNote
        '
        resources.ApplyResources(LabelInstallNote, "LabelInstallNote")
        LabelInstallNote.Name = "LabelInstallNote"
        '
        'ButtonInstall
        '
        resources.ApplyResources(Me.ButtonInstall, "ButtonInstall")
        Me.ButtonInstall.Name = "ButtonInstall"
        Me.ButtonInstall.UseVisualStyleBackColor = True
        '
        'TextBoxInstallProgress
        '
        resources.ApplyResources(Me.TextBoxInstallProgress, "TextBoxInstallProgress")
        Me.TextBoxInstallProgress.Name = "TextBoxInstallProgress"
        Me.TextBoxInstallProgress.ReadOnly = True
        '
        'InstallWSL
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.TextBoxInstallProgress)
        Me.Controls.Add(Me.ButtonInstall)
        Me.Controls.Add(LabelInstallNote)
        Me.Controls.Add(LabelInstallInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "InstallWSL"
        Me.ShowIcon = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonInstall As Button
    Friend WithEvents TextBoxInstallProgress As TextBox
End Class
