<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvQueue = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnRefreshQueue = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvVoters = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnRefreshVoters = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.boxSysops = New System.Windows.Forms.ListBox()
        Me.rtbAdminChat = New System.Windows.Forms.RichTextBox()
        Me.btnSendChat = New System.Windows.Forms.Button()
        Me.txtChat = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvQueue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvVoters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(962, 450)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvQueue)
        Me.TabPage1.Controls.Add(Me.btnRefreshQueue)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(792, 421)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Current Queue"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvQueue
        '
        Me.dgvQueue.AllowUserToAddRows = False
        Me.dgvQueue.AllowUserToDeleteRows = False
        Me.dgvQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQueue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dgvQueue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvQueue.Location = New System.Drawing.Point(3, 35)
        Me.dgvQueue.Name = "dgvQueue"
        Me.dgvQueue.ReadOnly = True
        Me.dgvQueue.RowHeadersVisible = False
        Me.dgvQueue.RowTemplate.Height = 24
        Me.dgvQueue.Size = New System.Drawing.Size(786, 383)
        Me.dgvQueue.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.FillWeight = 30.0!
        Me.Column1.HeaderText = "Position"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.FillWeight = 30.0!
        Me.Column2.HeaderText = "Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.FillWeight = 20.0!
        Me.Column3.HeaderText = "IP"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.FillWeight = 20.0!
        Me.Column4.HeaderText = "Kick?"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'btnRefreshQueue
        '
        Me.btnRefreshQueue.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRefreshQueue.Location = New System.Drawing.Point(3, 3)
        Me.btnRefreshQueue.Name = "btnRefreshQueue"
        Me.btnRefreshQueue.Size = New System.Drawing.Size(786, 32)
        Me.btnRefreshQueue.TabIndex = 0
        Me.btnRefreshQueue.Text = "Refresh"
        Me.btnRefreshQueue.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvVoters)
        Me.TabPage2.Controls.Add(Me.btnRefreshVoters)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(792, 421)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Current Voters"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvVoters
        '
        Me.dgvVoters.AllowUserToAddRows = False
        Me.dgvVoters.AllowUserToDeleteRows = False
        Me.dgvVoters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvVoters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVoters.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column6, Me.Column7})
        Me.dgvVoters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvVoters.Location = New System.Drawing.Point(3, 31)
        Me.dgvVoters.Name = "dgvVoters"
        Me.dgvVoters.ReadOnly = True
        Me.dgvVoters.RowHeadersVisible = False
        Me.dgvVoters.RowTemplate.Height = 24
        Me.dgvVoters.Size = New System.Drawing.Size(786, 387)
        Me.dgvVoters.TabIndex = 1
        '
        'Column5
        '
        Me.Column5.HeaderText = "IP"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Name"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Kick?"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'btnRefreshVoters
        '
        Me.btnRefreshVoters.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRefreshVoters.Location = New System.Drawing.Point(3, 3)
        Me.btnRefreshVoters.Name = "btnRefreshVoters"
        Me.btnRefreshVoters.Size = New System.Drawing.Size(786, 28)
        Me.btnRefreshVoters.TabIndex = 0
        Me.btnRefreshVoters.Text = "Refresh"
        Me.btnRefreshVoters.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(792, 421)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Manual Vote"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.SplitContainer2)
        Me.TabPage4.Controls.Add(Me.SplitContainer1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(954, 421)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "[Chat]"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Location = New System.Drawing.Point(0, 372)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(372, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sysops / Sysadmins"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'boxSysops
        '
        Me.boxSysops.Dock = System.Windows.Forms.DockStyle.Fill
        Me.boxSysops.FormattingEnabled = True
        Me.boxSysops.ItemHeight = 16
        Me.boxSysops.Location = New System.Drawing.Point(0, 0)
        Me.boxSysops.Name = "boxSysops"
        Me.boxSysops.Size = New System.Drawing.Size(372, 397)
        Me.boxSysops.TabIndex = 3
        '
        'rtbAdminChat
        '
        Me.rtbAdminChat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbAdminChat.Location = New System.Drawing.Point(0, 0)
        Me.rtbAdminChat.Name = "rtbAdminChat"
        Me.rtbAdminChat.Size = New System.Drawing.Size(578, 397)
        Me.rtbAdminChat.TabIndex = 2
        Me.rtbAdminChat.Text = ""
        '
        'btnSendChat
        '
        Me.btnSendChat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSendChat.Location = New System.Drawing.Point(0, 0)
        Me.btnSendChat.Name = "btnSendChat"
        Me.btnSendChat.Size = New System.Drawing.Size(289, 24)
        Me.btnSendChat.TabIndex = 1
        Me.btnSendChat.Text = "Button1"
        Me.btnSendChat.UseVisualStyleBackColor = True
        '
        'txtChat
        '
        Me.txtChat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChat.Location = New System.Drawing.Point(0, 0)
        Me.txtChat.Name = "txtChat"
        Me.txtChat.Size = New System.Drawing.Size(661, 22)
        Me.txtChat.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 397)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtChat)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSendChat)
        Me.SplitContainer1.Size = New System.Drawing.Size(954, 24)
        Me.SplitContainer1.SplitterDistance = 661
        Me.SplitContainer1.TabIndex = 5
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.rtbAdminChat)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.boxSysops)
        Me.SplitContainer2.Size = New System.Drawing.Size(954, 397)
        Me.SplitContainer2.SplitterDistance = 578
        Me.SplitContainer2.TabIndex = 6
        '
        'AdminForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(962, 450)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "AdminForm"
        Me.Text = "<> Form"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvQueue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvVoters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btnRefreshQueue As Button
    Friend WithEvents dgvQueue As DataGridView
    Friend WithEvents btnRefreshVoters As Button
    Friend WithEvents dgvVoters As DataGridView
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents btnSendChat As Button
    Friend WithEvents txtChat As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents boxSysops As ListBox
    Friend WithEvents rtbAdminChat As RichTextBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewButtonColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewButtonColumn
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
End Class
