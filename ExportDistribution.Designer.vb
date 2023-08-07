<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportDistribution
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportDistribution))
        Dim LabelExportTo As System.Windows.Forms.Label
        Dim LabelExportVhdxNotice As System.Windows.Forms.Label
        Me.LabelDistributionName = New System.Windows.Forms.Label()
        Me.TextBoxExportTo = New System.Windows.Forms.TextBox()
        Me.ButtonChangeExportTo = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.CheckBoxExportAsVhdx = New System.Windows.Forms.CheckBox()
        Me.ButtonShutdownWSL = New System.Windows.Forms.Button()
        LabelDistribution = New System.Windows.Forms.Label()
        LabelExportTo = New System.Windows.Forms.Label()
        LabelExportVhdxNotice = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelDistribution
        '
        resources.ApplyResources(LabelDistribution, "LabelDistribution")
        LabelDistribution.Name = "LabelDistribution"
        '
        'LabelExportTo
        '
        resources.ApplyResources(LabelExportTo, "LabelExportTo")
        LabelExportTo.Name = "LabelExportTo"
        '
        'LabelExportVhdxNotice
        '
        resources.ApplyResources(LabelExportVhdxNotice, "LabelExportVhdxNotice")
        LabelExportVhdxNotice.Name = "LabelExportVhdxNotice"
        '
        'LabelDistributionName
        '
        resources.ApplyResources(Me.LabelDistributionName, "LabelDistributionName")
        Me.LabelDistributionName.Name = "LabelDistributionName"
        '
        'TextBoxExportTo
        '
        resources.ApplyResources(Me.TextBoxExportTo, "TextBoxExportTo")
        Me.TextBoxExportTo.Name = "TextBoxExportTo"
        '
        'ButtonChangeExportTo
        '
        resources.ApplyResources(Me.ButtonChangeExportTo, "ButtonChangeExportTo")
        Me.ButtonChangeExportTo.Name = "ButtonChangeExportTo"
        Me.ButtonChangeExportTo.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        resources.ApplyResources(Me.ButtonOK, "ButtonOK")
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        resources.ApplyResources(Me.ButtonCancel, "ButtonCancel")
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'CheckBoxExportAsVhdx
        '
        resources.ApplyResources(Me.CheckBoxExportAsVhdx, "CheckBoxExportAsVhdx")
        Me.CheckBoxExportAsVhdx.Name = "CheckBoxExportAsVhdx"
        Me.CheckBoxExportAsVhdx.UseVisualStyleBackColor = True
        '
        'ButtonShutdownWSL
        '
        resources.ApplyResources(Me.ButtonShutdownWSL, "ButtonShutdownWSL")
        Me.ButtonShutdownWSL.Name = "ButtonShutdownWSL"
        Me.ButtonShutdownWSL.UseVisualStyleBackColor = True
        '
        'ExportDistribution
        '
        Me.AcceptButton = Me.ButtonOK
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.ButtonCancel
        Me.Controls.Add(LabelDistribution)
        Me.Controls.Add(Me.LabelDistributionName)
        Me.Controls.Add(LabelExportTo)
        Me.Controls.Add(Me.TextBoxExportTo)
        Me.Controls.Add(Me.ButtonChangeExportTo)
        Me.Controls.Add(Me.CheckBoxExportAsVhdx)
        Me.Controls.Add(LabelExportVhdxNotice)
        Me.Controls.Add(Me.ButtonShutdownWSL)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.ButtonCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ExportDistribution"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelDistributionName As Label
    Friend WithEvents TextBoxExportTo As TextBox
    Friend WithEvents ButtonChangeExportTo As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents CheckBoxExportAsVhdx As CheckBox
    Friend WithEvents ButtonShutdownWSL As Button
End Class
