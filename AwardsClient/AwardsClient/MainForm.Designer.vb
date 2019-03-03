<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.first_panel_load = New System.Windows.Forms.Panel()
        Me.lblFirstPanelDisplay = New System.Windows.Forms.Label()
        Me.contactServerTimer = New System.Windows.Forms.Timer(Me.components)
        Me.second_panel_prompt = New System.Windows.Forms.Panel()
        Me.lblOpeningMessage = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblPrompt = New System.Windows.Forms.Label()
        Me.lblNumRemain = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.lblFirstDisplay = New System.Windows.Forms.Label()
        Me.lblSecondDisplay = New System.Windows.Forms.Label()
        Me.txtQueryFirst = New System.Windows.Forms.TextBox()
        Me.txtQuerySecond = New System.Windows.Forms.TextBox()
        Me.FirstDisplayPanel = New System.Windows.Forms.Panel()
        Me.SecondDisplayPanel = New System.Windows.Forms.Panel()
        Me.finalPromptPanel = New System.Windows.Forms.Panel()
        Me.cmdConfirm = New System.Windows.Forms.Button()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblQueryFirst = New System.Windows.Forms.Label()
        Me.lblQuerySecond = New System.Windows.Forms.Label()
        Me.btnBugReport = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.first_panel_load.SuspendLayout()
        Me.second_panel_prompt.SuspendLayout()
        Me.finalPromptPanel.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'first_panel_load
        '
        Me.first_panel_load.Controls.Add(Me.PictureBox2)
        Me.first_panel_load.Controls.Add(Me.lblFirstPanelDisplay)
        Me.first_panel_load.Font = New System.Drawing.Font("MS Reference Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.first_panel_load.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.first_panel_load.Location = New System.Drawing.Point(955, 12)
        Me.first_panel_load.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.first_panel_load.Name = "first_panel_load"
        Me.first_panel_load.Size = New System.Drawing.Size(215, 175)
        Me.first_panel_load.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.AwardsClient.My.Resources.Resources.logo
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(215, 76)
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'lblFirstPanelDisplay
        '
        Me.lblFirstPanelDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFirstPanelDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstPanelDisplay.Location = New System.Drawing.Point(0, 0)
        Me.lblFirstPanelDisplay.Name = "lblFirstPanelDisplay"
        Me.lblFirstPanelDisplay.Size = New System.Drawing.Size(215, 175)
        Me.lblFirstPanelDisplay.TabIndex = 0
        Me.lblFirstPanelDisplay.Text = "Hey"
        Me.lblFirstPanelDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'contactServerTimer
        '
        Me.contactServerTimer.Interval = 1000
        '
        'second_panel_prompt
        '
        Me.second_panel_prompt.Controls.Add(Me.PictureBox1)
        Me.second_panel_prompt.Controls.Add(Me.lblOpeningMessage)
        Me.second_panel_prompt.Controls.Add(Me.btnStart)
        Me.second_panel_prompt.Font = New System.Drawing.Font("MS Reference Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.second_panel_prompt.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.second_panel_prompt.Location = New System.Drawing.Point(955, 247)
        Me.second_panel_prompt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.second_panel_prompt.Name = "second_panel_prompt"
        Me.second_panel_prompt.Size = New System.Drawing.Size(233, 175)
        Me.second_panel_prompt.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.AwardsClient.My.Resources.Resources.logo
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(233, 62)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'lblOpeningMessage
        '
        Me.lblOpeningMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOpeningMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpeningMessage.Location = New System.Drawing.Point(0, 0)
        Me.lblOpeningMessage.Name = "lblOpeningMessage"
        Me.lblOpeningMessage.Size = New System.Drawing.Size(233, 147)
        Me.lblOpeningMessage.TabIndex = 1
        Me.lblOpeningMessage.Text = "Hello!"
        Me.lblOpeningMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnStart
        '
        Me.btnStart.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnStart.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnStart.Location = New System.Drawing.Point(0, 147)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(233, 28)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "I'm ready, lets begin"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblPrompt
        '
        Me.lblPrompt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblPrompt.Font = New System.Drawing.Font("MS Reference Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrompt.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblPrompt.Location = New System.Drawing.Point(0, 31)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.Size = New System.Drawing.Size(800, 44)
        Me.lblPrompt.TabIndex = 2
        Me.lblPrompt.Text = "Prompt"
        Me.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumRemain
        '
        Me.lblNumRemain.Font = New System.Drawing.Font("MS Reference Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumRemain.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblNumRemain.Location = New System.Drawing.Point(12, 8)
        Me.lblNumRemain.Location = New System.Drawing.Point(12, 9)
        Me.lblNumRemain.Name = "lblNumRemain"
        Me.lblNumRemain.Size = New System.Drawing.Size(72, 23)
        Me.lblNumRemain.TabIndex = 3
        Me.lblNumRemain.Text = "99/99"
        Me.lblNumRemain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("MS Reference Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(709, 382)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(117, 57)
        Me.btnNext.TabIndex = 5
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnPrevious.Font = New System.Drawing.Font("MS Reference Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevious.Location = New System.Drawing.Point(12, 382)
        Me.btnPrevious.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(117, 57)
        Me.btnPrevious.TabIndex = 5
        Me.btnPrevious.Text = "Previous"
        Me.btnPrevious.UseVisualStyleBackColor = False
        Me.btnPrevious.Visible = False
        '
        'lblFirstDisplay
        '
        Me.lblFirstDisplay.Font = New System.Drawing.Font("MS Reference Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstDisplay.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblFirstDisplay.Location = New System.Drawing.Point(56, 78)
        Me.lblFirstDisplay.Name = "lblFirstDisplay"
        Me.lblFirstDisplay.Size = New System.Drawing.Size(208, 31)
        Me.lblFirstDisplay.TabIndex = 6
        Me.lblFirstDisplay.Text = "First choice"
        Me.lblFirstDisplay.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSecondDisplay
        '
        Me.lblSecondDisplay.Font = New System.Drawing.Font("MS Reference Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecondDisplay.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSecondDisplay.Location = New System.Drawing.Point(495, 78)
        Me.lblSecondDisplay.Name = "lblSecondDisplay"
        Me.lblSecondDisplay.Size = New System.Drawing.Size(208, 31)
        Me.lblSecondDisplay.TabIndex = 7
        Me.lblSecondDisplay.Text = "Second choice"
        Me.lblSecondDisplay.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtQueryFirst
        '
        Me.txtQueryFirst.Font = New System.Drawing.Font("MS Reference Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQueryFirst.ForeColor = System.Drawing.Color.Black
        Me.txtQueryFirst.Location = New System.Drawing.Point(12, 111)
        Me.txtQueryFirst.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtQueryFirst.MaxLength = 20
        Me.txtQueryFirst.Name = "txtQueryFirst"
        Me.txtQueryFirst.ShortcutsEnabled = False
        Me.txtQueryFirst.Size = New System.Drawing.Size(297, 23)
        Me.txtQueryFirst.TabIndex = 0
        '
        'txtQuerySecond
        '
        Me.txtQuerySecond.Font = New System.Drawing.Font("MS Reference Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuerySecond.ForeColor = System.Drawing.Color.Black
        Me.txtQuerySecond.Location = New System.Drawing.Point(448, 111)
        Me.txtQuerySecond.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtQuerySecond.MaxLength = 20
        Me.txtQuerySecond.Name = "txtQuerySecond"
        Me.txtQuerySecond.ShortcutsEnabled = False
        Me.txtQuerySecond.Size = New System.Drawing.Size(297, 23)
        Me.txtQuerySecond.TabIndex = 2
        '
        'FirstDisplayPanel
        '
        Me.FirstDisplayPanel.AutoScroll = True
        Me.FirstDisplayPanel.Font = New System.Drawing.Font("MS Reference Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FirstDisplayPanel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.FirstDisplayPanel.Location = New System.Drawing.Point(12, 139)
        Me.FirstDisplayPanel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FirstDisplayPanel.Name = "FirstDisplayPanel"
        Me.FirstDisplayPanel.Size = New System.Drawing.Size(299, 229)
        Me.FirstDisplayPanel.TabIndex = 1
        '
        'SecondDisplayPanel
        '
        Me.SecondDisplayPanel.AutoScroll = True
        Me.SecondDisplayPanel.Font = New System.Drawing.Font("MS Reference Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SecondDisplayPanel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.SecondDisplayPanel.Location = New System.Drawing.Point(448, 139)
        Me.SecondDisplayPanel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SecondDisplayPanel.Name = "SecondDisplayPanel"
        Me.SecondDisplayPanel.Size = New System.Drawing.Size(299, 228)
        Me.SecondDisplayPanel.TabIndex = 3
        '
        'finalPromptPanel
        '
        Me.finalPromptPanel.BackColor = System.Drawing.Color.Transparent
        Me.finalPromptPanel.Controls.Add(Me.cmdConfirm)
        Me.finalPromptPanel.Controls.Add(Me.cmdBack)
        Me.finalPromptPanel.Controls.Add(Me.DataGridView1)
        Me.finalPromptPanel.Font = New System.Drawing.Font("MS Reference Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.finalPromptPanel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.finalPromptPanel.Location = New System.Drawing.Point(1653, 112)
        Me.finalPromptPanel.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.finalPromptPanel.Name = "finalPromptPanel"
        Me.finalPromptPanel.Size = New System.Drawing.Size(461, 303)
        Me.finalPromptPanel.TabIndex = 16
        '
        'cmdConfirm
        '
        Me.cmdConfirm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdConfirm.Font = New System.Drawing.Font("MS Reference Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConfirm.ForeColor = System.Drawing.Color.Black
        Me.cmdConfirm.Location = New System.Drawing.Point(0, 254)
        Me.cmdConfirm.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.cmdConfirm.Name = "cmdConfirm"
        Me.cmdConfirm.Size = New System.Drawing.Size(461, 0)
        Me.cmdConfirm.TabIndex = 1
        Me.cmdConfirm.Text = "Confirm" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.cmdConfirm.UseVisualStyleBackColor = True
        '
        'cmdBack
        '
        Me.cmdBack.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdBack.ForeColor = System.Drawing.Color.Black
        Me.cmdBack.Location = New System.Drawing.Point(0, 254)
        Me.cmdBack.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(461, 49)
        Me.cmdBack.TabIndex = 2
        Me.cmdBack.Text = "Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.IndianRed
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.IndianRed
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS Reference Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.IndianRed
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.IndianRed
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS Reference Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCoral
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(461, 254)
        Me.DataGridView1.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Category"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "First Choice:"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Second Choice:"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'lblQueryFirst
        '
        Me.lblQueryFirst.AutoSize = True
        Me.lblQueryFirst.Font = New System.Drawing.Font("MS Reference Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueryFirst.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblQueryFirst.Location = New System.Drawing.Point(316, 114)
        Me.lblQueryFirst.Name = "lblQueryFirst"
        Me.lblQueryFirst.Size = New System.Drawing.Size(92, 18)
        Me.lblQueryFirst.TabIndex = 9
        Me.lblQueryFirst.Text = "Searching..."
        Me.lblQueryFirst.Visible = False
        '
        'lblQuerySecond
        '
        Me.lblQuerySecond.AutoSize = True
        Me.lblQuerySecond.Font = New System.Drawing.Font("MS Reference Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuerySecond.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblQuerySecond.Location = New System.Drawing.Point(752, 117)
        Me.lblQuerySecond.Name = "lblQuerySecond"
        Me.lblQuerySecond.Size = New System.Drawing.Size(92, 18)
        Me.lblQuerySecond.TabIndex = 11
        Me.lblQuerySecond.Text = "Searching..."
        Me.lblQuerySecond.Visible = False
        '
        'Button1
        '
        Me.btnBugReport.BackColor = System.Drawing.Color.LightCoral
        Me.btnBugReport.Location = New System.Drawing.Point(319, 394)
        Me.btnBugReport.Name = "Button1"
        Me.btnBugReport.Size = New System.Drawing.Size(125, 28)
        Me.btnBugReport.TabIndex = 17
        Me.btnBugReport.Text = "Report a bug"
        Me.btnBugReport.UseVisualStyleBackColor = False
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.AwardsClient.My.Resources.Resources.logo
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(233, 62)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.AwardsClient.My.Resources.Resources.logo
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(215, 76)
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.IndianRed
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1444, 452)
        Me.Controls.Add(Me.btnBugReport)
        Me.Controls.Add(Me.finalPromptPanel)
        Me.Controls.Add(Me.SecondDisplayPanel)
        Me.Controls.Add(Me.FirstDisplayPanel)
        Me.Controls.Add(Me.txtQuerySecond)
        Me.Controls.Add(Me.txtQueryFirst)
        Me.Controls.Add(Me.lblQuerySecond)
        Me.Controls.Add(Me.lblQueryFirst)
        Me.Controls.Add(Me.lblSecondDisplay)
        Me.Controls.Add(Me.lblFirstDisplay)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.lblNumRemain)
        Me.Controls.Add(Me.lblPrompt)
        Me.Controls.Add(Me.second_panel_prompt)
        Me.Controls.Add(Me.first_panel_load)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(861, 481)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Year 11 Awards"
        Me.first_panel_load.ResumeLayout(False)
        Me.second_panel_prompt.ResumeLayout(False)
        Me.finalPromptPanel.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents first_panel_load As Panel
    Friend WithEvents lblFirstPanelDisplay As Label
    Friend WithEvents contactServerTimer As Timer
    Friend WithEvents second_panel_prompt As Panel
    Friend WithEvents btnStart As Button
    Friend WithEvents lblOpeningMessage As Label
    Friend WithEvents lblPrompt As Label
    Friend WithEvents lblNumRemain As Label
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents lblFirstDisplay As Label
    Friend WithEvents lblSecondDisplay As Label
    Friend WithEvents txtQueryFirst As TextBox
    Friend WithEvents txtQuerySecond As TextBox
    Friend WithEvents FirstDisplayPanel As Panel
    Friend WithEvents SecondDisplayPanel As Panel
    Friend WithEvents finalPromptPanel As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents cmdConfirm As Button
    Friend WithEvents cmdBack As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblQueryFirst As Label
    Friend WithEvents lblQuerySecond As Label
    Friend WithEvents btnBugReport As Button
End Class
