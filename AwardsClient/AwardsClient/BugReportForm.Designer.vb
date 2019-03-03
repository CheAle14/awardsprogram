<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BugReportForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.txtPrimary = New System.Windows.Forms.TextBox()
        Me.lblPrimary = New System.Windows.Forms.Label()
        Me.txtSecondary = New System.Windows.Forms.RichTextBox()
        Me.lblSecondary = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(203, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select what is primarily broken:"
        '
        'cboType
        '
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(15, 29)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(307, 24)
        Me.cboType.TabIndex = 1
        '
        'txtPrimary
        '
        Me.txtPrimary.Location = New System.Drawing.Point(15, 86)
        Me.txtPrimary.MaxLength = 32
        Me.txtPrimary.Name = "txtPrimary"
        Me.txtPrimary.Size = New System.Drawing.Size(307, 22)
        Me.txtPrimary.TabIndex = 2
        '
        'lblPrimary
        '
        Me.lblPrimary.AutoSize = True
        Me.lblPrimary.Location = New System.Drawing.Point(12, 66)
        Me.lblPrimary.Name = "lblPrimary"
        Me.lblPrimary.Size = New System.Drawing.Size(124, 17)
        Me.lblPrimary.TabIndex = 3
        Me.lblPrimary.Text = "(More specifc text)"
        '
        'txtSecondary
        '
        Me.txtSecondary.Location = New System.Drawing.Point(15, 139)
        Me.txtSecondary.MaxLength = 64
        Me.txtSecondary.Name = "txtSecondary"
        Me.txtSecondary.Size = New System.Drawing.Size(307, 96)
        Me.txtSecondary.TabIndex = 4
        Me.txtSecondary.Text = ""
        '
        'lblSecondary
        '
        Me.lblSecondary.AutoSize = True
        Me.lblSecondary.Location = New System.Drawing.Point(12, 119)
        Me.lblSecondary.Name = "lblSecondary"
        Me.lblSecondary.Size = New System.Drawing.Size(205, 17)
        Me.lblSecondary.TabIndex = 5
        Me.lblSecondary.Text = "Any additional text / information"
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(15, 242)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(307, 23)
        Me.btnSubmit.TabIndex = 6
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'BugReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 268)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.lblSecondary)
        Me.Controls.Add(Me.txtSecondary)
        Me.Controls.Add(Me.lblPrimary)
        Me.Controls.Add(Me.txtPrimary)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "BugReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bug Reporting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cboType As ComboBox
    Friend WithEvents txtPrimary As TextBox
    Friend WithEvents lblPrimary As Label
    Friend WithEvents txtSecondary As RichTextBox
    Friend WithEvents lblSecondary As Label
    Friend WithEvents btnSubmit As Button
End Class
