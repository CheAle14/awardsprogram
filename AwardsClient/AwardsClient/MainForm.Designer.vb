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
        Me.lblMaleDisplay = New System.Windows.Forms.Label()
        Me.lblFemaleDisplay = New System.Windows.Forms.Label()
        Me.lblQueryMale = New System.Windows.Forms.Label()
        Me.lblQueryFemale = New System.Windows.Forms.Label()
        Me.txtQueryMale = New System.Windows.Forms.TextBox()
        Me.txtQueryFemale = New System.Windows.Forms.TextBox()
        Me.maleDisplayPanel = New System.Windows.Forms.Panel()
        Me.femaleDisplayPanel = New System.Windows.Forms.Panel()
        Me.finalPromptPanel = New System.Windows.Forms.Panel()
        Me.cmdConfirm = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.first_panel_load.SuspendLayout()
        Me.second_panel_prompt.SuspendLayout()
        Me.finalPromptPanel.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'first_panel_load
        '
        Me.first_panel_load.Controls.Add(Me.lblFirstPanelDisplay)
        Me.first_panel_load.Location = New System.Drawing.Point(716, 10)
        Me.first_panel_load.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.first_panel_load.Name = "first_panel_load"
        Me.first_panel_load.Size = New System.Drawing.Size(161, 142)
        Me.first_panel_load.TabIndex = 0
        '
        'lblFirstPanelDisplay
        '
        Me.lblFirstPanelDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFirstPanelDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstPanelDisplay.Location = New System.Drawing.Point(0, 0)
        Me.lblFirstPanelDisplay.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFirstPanelDisplay.Name = "lblFirstPanelDisplay"
        Me.lblFirstPanelDisplay.Size = New System.Drawing.Size(161, 142)
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
        Me.second_panel_prompt.Controls.Add(Me.lblOpeningMessage)
        Me.second_panel_prompt.Controls.Add(Me.btnStart)
        Me.second_panel_prompt.Location = New System.Drawing.Point(716, 201)
        Me.second_panel_prompt.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.second_panel_prompt.Name = "second_panel_prompt"
        Me.second_panel_prompt.Size = New System.Drawing.Size(175, 142)
        Me.second_panel_prompt.TabIndex = 1
        '
        'lblOpeningMessage
        '
        Me.lblOpeningMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOpeningMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpeningMessage.Location = New System.Drawing.Point(0, 0)
        Me.lblOpeningMessage.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblOpeningMessage.Name = "lblOpeningMessage"
        Me.lblOpeningMessage.Size = New System.Drawing.Size(175, 119)
        Me.lblOpeningMessage.TabIndex = 1
        Me.lblOpeningMessage.Text = "Hello!"
        Me.lblOpeningMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnStart
        '
        Me.btnStart.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnStart.Location = New System.Drawing.Point(0, 119)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(175, 23)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "I'm ready, lets begin"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblPrompt
        '
        Me.lblPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrompt.Location = New System.Drawing.Point(68, 7)
        Me.lblPrompt.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.Size = New System.Drawing.Size(552, 32)
        Me.lblPrompt.TabIndex = 2
        Me.lblPrompt.Text = "Prompt"
        Me.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumRemain
        '
        Me.lblNumRemain.Location = New System.Drawing.Point(9, 7)
        Me.lblNumRemain.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNumRemain.Name = "lblNumRemain"
        Me.lblNumRemain.Size = New System.Drawing.Size(54, 19)
        Me.lblNumRemain.TabIndex = 3
        Me.lblNumRemain.Text = "99/99"
        Me.lblNumRemain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(532, 310)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(88, 46)
        Me.btnNext.TabIndex = 4
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(9, 310)
        Me.btnPrevious.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(88, 46)
        Me.btnPrevious.TabIndex = 5
        Me.btnPrevious.Text = "Previous"
        Me.btnPrevious.UseVisualStyleBackColor = True
        Me.btnPrevious.Visible = False
        '
        'lblMaleDisplay
        '
        Me.lblMaleDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaleDisplay.Location = New System.Drawing.Point(9, 74)
        Me.lblMaleDisplay.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMaleDisplay.Name = "lblMaleDisplay"
        Me.lblMaleDisplay.Size = New System.Drawing.Size(156, 14)
        Me.lblMaleDisplay.TabIndex = 6
        Me.lblMaleDisplay.Text = "Male"
        Me.lblMaleDisplay.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFemaleDisplay
        '
        Me.lblFemaleDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFemaleDisplay.Location = New System.Drawing.Point(393, 74)
        Me.lblFemaleDisplay.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFemaleDisplay.Name = "lblFemaleDisplay"
        Me.lblFemaleDisplay.Size = New System.Drawing.Size(156, 14)
        Me.lblFemaleDisplay.TabIndex = 7
        Me.lblFemaleDisplay.Text = "Female"
        Me.lblFemaleDisplay.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblQueryMale
        '
        Me.lblQueryMale.AutoSize = True
        Me.lblQueryMale.Location = New System.Drawing.Point(170, 93)
        Me.lblQueryMale.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblQueryMale.Name = "lblQueryMale"
        Me.lblQueryMale.Size = New System.Drawing.Size(64, 13)
        Me.lblQueryMale.TabIndex = 9
        Me.lblQueryMale.Text = "Searching..."
        Me.lblQueryMale.Visible = False
        '
        'lblQueryFemale
        '
        Me.lblQueryFemale.AutoSize = True
        Me.lblQueryFemale.Location = New System.Drawing.Point(554, 93)
        Me.lblQueryFemale.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblQueryFemale.Name = "lblQueryFemale"
        Me.lblQueryFemale.Size = New System.Drawing.Size(64, 13)
        Me.lblQueryFemale.TabIndex = 11
        Me.lblQueryFemale.Text = "Searching..."
        Me.lblQueryFemale.Visible = False
        '
        'txtQueryMale
        '
        Me.txtQueryMale.Location = New System.Drawing.Point(9, 90)
        Me.txtQueryMale.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtQueryMale.MaxLength = 20
        Me.txtQueryMale.Name = "txtQueryMale"
        Me.txtQueryMale.Size = New System.Drawing.Size(157, 20)
        Me.txtQueryMale.TabIndex = 12
        '
        'txtQueryFemale
        '
        Me.txtQueryFemale.Location = New System.Drawing.Point(393, 90)
        Me.txtQueryFemale.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtQueryFemale.MaxLength = 20
        Me.txtQueryFemale.Name = "txtQueryFemale"
        Me.txtQueryFemale.Size = New System.Drawing.Size(157, 20)
        Me.txtQueryFemale.TabIndex = 13
        '
        'maleDisplayPanel
        '
        Me.maleDisplayPanel.AutoScroll = True
        Me.maleDisplayPanel.Location = New System.Drawing.Point(9, 113)
        Me.maleDisplayPanel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.maleDisplayPanel.Name = "maleDisplayPanel"
        Me.maleDisplayPanel.Size = New System.Drawing.Size(224, 186)
        Me.maleDisplayPanel.TabIndex = 14
        '
        'femaleDisplayPanel
        '
        Me.femaleDisplayPanel.Location = New System.Drawing.Point(393, 113)
        Me.femaleDisplayPanel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.femaleDisplayPanel.Name = "femaleDisplayPanel"
        Me.femaleDisplayPanel.Size = New System.Drawing.Size(224, 186)
        Me.femaleDisplayPanel.TabIndex = 15
        '
        'finalPromptPanel
        '
        Me.finalPromptPanel.Controls.Add(Me.cmdConfirm)
        Me.finalPromptPanel.Controls.Add(Me.DataGridView1)
        Me.finalPromptPanel.Location = New System.Drawing.Point(930, 74)
        Me.finalPromptPanel.Name = "finalPromptPanel"
        Me.finalPromptPanel.Size = New System.Drawing.Size(346, 246)
        Me.finalPromptPanel.TabIndex = 16
        '
        'cmdConfirm
        '
        Me.cmdConfirm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdConfirm.Location = New System.Drawing.Point(0, 225)
        Me.cmdConfirm.Name = "cmdConfirm"
        Me.cmdConfirm.Size = New System.Drawing.Size(346, 21)
        Me.cmdConfirm.TabIndex = 1
        Me.cmdConfirm.Text = "Confirm" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "or" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Shift Click to change your choices"
        Me.cmdConfirm.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(346, 225)
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
        Me.Column2.HeaderText = "Male selected:"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Female selected"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 366)
        Me.Controls.Add(Me.finalPromptPanel)
        Me.Controls.Add(Me.femaleDisplayPanel)
        Me.Controls.Add(Me.maleDisplayPanel)
        Me.Controls.Add(Me.txtQueryFemale)
        Me.Controls.Add(Me.txtQueryMale)
        Me.Controls.Add(Me.lblQueryFemale)
        Me.Controls.Add(Me.lblQueryMale)
        Me.Controls.Add(Me.lblFemaleDisplay)
        Me.Controls.Add(Me.lblMaleDisplay)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.lblNumRemain)
        Me.Controls.Add(Me.lblPrompt)
        Me.Controls.Add(Me.second_panel_prompt)
        Me.Controls.Add(Me.first_panel_load)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Year 11 Awards"
        Me.first_panel_load.ResumeLayout(False)
        Me.second_panel_prompt.ResumeLayout(False)
        Me.finalPromptPanel.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblMaleDisplay As Label
    Friend WithEvents lblFemaleDisplay As Label
    Friend WithEvents lblQueryMale As Label
    Friend WithEvents lblQueryFemale As Label
    Friend WithEvents txtQueryMale As TextBox
    Friend WithEvents txtQueryFemale As TextBox
    Friend WithEvents maleDisplayPanel As Panel
    Friend WithEvents femaleDisplayPanel As Panel
    Friend WithEvents finalPromptPanel As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents cmdConfirm As Button
End Class
