<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        lblHello = New Label()
        lblWelcome = New Label()
        lblUsername = New Label()
        lblPassword = New Label()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        cbShowPassword = New CheckBox()
        btnLogin = New Button()
        btnExit = New Button()
        SuspendLayout()
        ' 
        ' lblHello
        ' 
        lblHello.AutoSize = True
        lblHello.BackColor = Color.Transparent
        lblHello.Font = New Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHello.Location = New Point(703, 85)
        lblHello.Name = "lblHello"
        lblHello.Size = New Size(127, 50)
        lblHello.TabIndex = 0
        lblHello.Text = "Hello!"
        lblHello.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.BackColor = Color.Transparent
        lblWelcome.Font = New Font("Segoe UI Variable Small Semibol", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblWelcome.Location = New Point(431, 135)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(399, 40)
        lblWelcome.TabIndex = 1
        lblWelcome.Text = "Welcome to The SafeSpace"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.BackColor = Color.Transparent
        lblUsername.Font = New Font("Segoe UI Variable Small", 13.8F)
        lblUsername.Location = New Point(443, 231)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(126, 31)
        lblUsername.TabIndex = 2
        lblUsername.Text = "Username:"
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.BackColor = Color.Transparent
        lblPassword.Font = New Font("Segoe UI Variable Small", 13.8F)
        lblPassword.Location = New Point(443, 285)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(116, 31)
        lblPassword.TabIndex = 3
        lblPassword.Text = "Password:"
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(600, 235)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(230, 27)
        txtUsername.TabIndex = 4
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(600, 285)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(230, 27)
        txtPassword.TabIndex = 5
        ' 
        ' cbShowPassword
        ' 
        cbShowPassword.AutoSize = True
        cbShowPassword.BackColor = Color.Transparent
        cbShowPassword.Location = New Point(698, 334)
        cbShowPassword.Name = "cbShowPassword"
        cbShowPassword.Size = New Size(132, 24)
        cbShowPassword.TabIndex = 6
        cbShowPassword.Text = "Show Password"
        cbShowPassword.UseVisualStyleBackColor = False
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(0), CByte(105), CByte(149))
        btnLogin.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(600, 377)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(230, 38)
        btnLogin.TabIndex = 7
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' btnExit
        ' 
        btnExit.BackColor = Color.FromArgb(CByte(166), CByte(42), CByte(42))
        btnExit.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnExit.ForeColor = Color.Transparent
        btnExit.Location = New Point(600, 421)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(230, 38)
        btnExit.TabIndex = 8
        btnExit.Text = "Exit"
        btnExit.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(904, 589)
        Controls.Add(btnExit)
        Controls.Add(btnLogin)
        Controls.Add(cbShowPassword)
        Controls.Add(txtPassword)
        Controls.Add(txtUsername)
        Controls.Add(lblPassword)
        Controls.Add(lblUsername)
        Controls.Add(lblWelcome)
        Controls.Add(lblHello)
        DoubleBuffered = True
        Name = "Form1"
        Text = "Login"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblHello As Label
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents cbShowPassword As CheckBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnExit As Button

End Class
