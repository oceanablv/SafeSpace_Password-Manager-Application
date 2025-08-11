<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CPassword))
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        nudLength = New NumericUpDown()
        cbUppercase = New CheckBox()
        cbDigits = New CheckBox()
        cbLowercase = New CheckBox()
        cbSymbols = New CheckBox()
        txtPassword = New TextBox()
        Label3 = New Label()
        btnGeneratePassword = New Button()
        btnSaveToClipboard = New Button()
        lblStrength = New Label()
        btnBackToDashboard = New Button()
        PictureBox2 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudLength, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.Location = New Point(50, 30)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(197, 63)
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(499, 41)
        Label1.Name = "Label1"
        Label1.Size = New Size(356, 41)
        Label1.TabIndex = 10
        Label1.Text = "Generate Your Password"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(50, 133)
        Label2.Name = "Label2"
        Label2.Size = New Size(254, 28)
        Label2.TabIndex = 11
        Label2.Text = "Length of password (6-20)"
        ' 
        ' nudLength
        ' 
        nudLength.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        nudLength.Location = New Point(323, 134)
        nudLength.Name = "nudLength"
        nudLength.Size = New Size(125, 30)
        nudLength.TabIndex = 12
        ' 
        ' cbUppercase
        ' 
        cbUppercase.AutoSize = True
        cbUppercase.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        cbUppercase.Location = New Point(124, 191)
        cbUppercase.Name = "cbUppercase"
        cbUppercase.Size = New Size(112, 27)
        cbUppercase.TabIndex = 13
        cbUppercase.Text = "Uppercase"
        cbUppercase.UseVisualStyleBackColor = True
        ' 
        ' cbDigits
        ' 
        cbDigits.AutoSize = True
        cbDigits.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        cbDigits.Location = New Point(124, 242)
        cbDigits.Name = "cbDigits"
        cbDigits.Size = New Size(75, 27)
        cbDigits.TabIndex = 14
        cbDigits.Text = "Digits"
        cbDigits.UseVisualStyleBackColor = True
        ' 
        ' cbLowercase
        ' 
        cbLowercase.AutoSize = True
        cbLowercase.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        cbLowercase.Location = New Point(251, 191)
        cbLowercase.Name = "cbLowercase"
        cbLowercase.Size = New Size(111, 27)
        cbLowercase.TabIndex = 15
        cbLowercase.Text = "Lowercase"
        cbLowercase.UseVisualStyleBackColor = True
        ' 
        ' cbSymbols
        ' 
        cbSymbols.AutoSize = True
        cbSymbols.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        cbSymbols.Location = New Point(251, 242)
        cbSymbols.Name = "cbSymbols"
        cbSymbols.Size = New Size(96, 27)
        cbSymbols.TabIndex = 16
        cbSymbols.Text = "Symbols"
        cbSymbols.UseVisualStyleBackColor = True
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(50, 296)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(398, 27)
        txtPassword.TabIndex = 17
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(101, 347)
        Label3.Name = "Label3"
        Label3.Size = New Size(95, 28)
        Label3.TabIndex = 18
        Label3.Text = "Strength:"
        ' 
        ' btnGeneratePassword
        ' 
        btnGeneratePassword.BackColor = Color.Transparent
        btnGeneratePassword.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnGeneratePassword.ForeColor = Color.Brown
        btnGeneratePassword.Location = New Point(50, 400)
        btnGeneratePassword.Name = "btnGeneratePassword"
        btnGeneratePassword.Size = New Size(195, 37)
        btnGeneratePassword.TabIndex = 19
        btnGeneratePassword.Text = "Generate Password"
        btnGeneratePassword.UseVisualStyleBackColor = False
        ' 
        ' btnSaveToClipboard
        ' 
        btnSaveToClipboard.BackColor = Color.Transparent
        btnSaveToClipboard.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnSaveToClipboard.ForeColor = Color.FromArgb(CByte(53), CByte(139), CByte(35))
        btnSaveToClipboard.Location = New Point(251, 400)
        btnSaveToClipboard.Name = "btnSaveToClipboard"
        btnSaveToClipboard.Size = New Size(197, 37)
        btnSaveToClipboard.TabIndex = 20
        btnSaveToClipboard.Text = "Save to Clipboard"
        btnSaveToClipboard.UseVisualStyleBackColor = False
        ' 
        ' lblStrength
        ' 
        lblStrength.BackColor = Color.Transparent
        lblStrength.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStrength.Location = New Point(211, 348)
        lblStrength.Name = "lblStrength"
        lblStrength.Size = New Size(237, 27)
        lblStrength.TabIndex = 21
        lblStrength.Text = "..."
        ' 
        ' btnBackToDashboard
        ' 
        btnBackToDashboard.BackColor = Color.CornflowerBlue
        btnBackToDashboard.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnBackToDashboard.ForeColor = Color.Transparent
        btnBackToDashboard.Location = New Point(50, 443)
        btnBackToDashboard.Name = "btnBackToDashboard"
        btnBackToDashboard.Size = New Size(398, 37)
        btnBackToDashboard.TabIndex = 23
        btnBackToDashboard.Text = "Back to Dashboard"
        btnBackToDashboard.UseVisualStyleBackColor = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), Image)
        PictureBox2.Location = New Point(499, 133)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(356, 347)
        PictureBox2.TabIndex = 22
        PictureBox2.TabStop = False
        ' 
        ' CPassword
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(904, 589)
        Controls.Add(btnBackToDashboard)
        Controls.Add(btnSaveToClipboard)
        Controls.Add(btnGeneratePassword)
        Controls.Add(txtPassword)
        Controls.Add(cbSymbols)
        Controls.Add(cbLowercase)
        Controls.Add(cbDigits)
        Controls.Add(cbUppercase)
        Controls.Add(nudLength)
        Controls.Add(lblStrength)
        Controls.Add(Label1)
        Controls.Add(Label2)
        Controls.Add(Label3)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox2)
        Name = "CPassword"
        Text = "CPassword"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(nudLength, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents nudLength As NumericUpDown
    Friend WithEvents cbUppercase As CheckBox
    Friend WithEvents cbDigits As CheckBox
    Friend WithEvents cbLowercase As CheckBox
    Friend WithEvents cbSymbols As CheckBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnGeneratePassword As Button
    Friend WithEvents btnSaveToClipboard As Button
    Friend WithEvents lblStrength As Label
    Friend WithEvents btnBackToDashboard As Button
    Friend WithEvents PictureBox2 As PictureBox
End Class
