<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DbUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DbUser))
        PictureBox1 = New PictureBox()
        lblTitle = New Label()
        btnLogout = New Button()
        Label2 = New Label()
        btnCreatePassword = New Button()
        PictureBox2 = New PictureBox()
        Label3 = New Label()
        btnManagePassword = New Button()
        PictureBox3 = New PictureBox()
        Label4 = New Label()
        btnConvertToExcel = New Button()
        PictureBox4 = New PictureBox()
        dgvAccountsUser = New DataGridView()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvAccountsUser, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.Location = New Point(50, 30)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(197, 63)
        PictureBox1.TabIndex = 26
        PictureBox1.TabStop = False
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.Transparent
        lblTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(293, 40)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(326, 41)
        lblTitle.TabIndex = 27
        lblTitle.Text = "Manage Your Account"
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.Brown
        btnLogout.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogout.ForeColor = Color.WhiteSmoke
        btnLogout.Location = New Point(676, 49)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(132, 35)
        btnLogout.TabIndex = 28
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(79, 116)
        Label2.Name = "Label2"
        Label2.Size = New Size(53, 20)
        Label2.TabIndex = 31
        Label2.Text = "Create"
        ' 
        ' btnCreatePassword
        ' 
        btnCreatePassword.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCreatePassword.ForeColor = SystemColors.HotTrack
        btnCreatePassword.Location = New Point(86, 150)
        btnCreatePassword.Name = "btnCreatePassword"
        btnCreatePassword.Size = New Size(128, 33)
        btnCreatePassword.TabIndex = 29
        btnCreatePassword.Text = "Password"
        btnCreatePassword.UseVisualStyleBackColor = True
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.WhiteSmoke
        PictureBox2.BorderStyle = BorderStyle.FixedSingle
        PictureBox2.Location = New Point(64, 126)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(183, 89)
        PictureBox2.TabIndex = 30
        PictureBox2.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(79, 241)
        Label3.Name = "Label3"
        Label3.Size = New Size(65, 20)
        Label3.TabIndex = 34
        Label3.Text = "Manage"
        ' 
        ' btnManagePassword
        ' 
        btnManagePassword.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnManagePassword.ForeColor = SystemColors.HotTrack
        btnManagePassword.Location = New Point(86, 275)
        btnManagePassword.Name = "btnManagePassword"
        btnManagePassword.Size = New Size(128, 33)
        btnManagePassword.TabIndex = 32
        btnManagePassword.Text = "Password"
        btnManagePassword.UseVisualStyleBackColor = True
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.WhiteSmoke
        PictureBox3.BorderStyle = BorderStyle.FixedSingle
        PictureBox3.Location = New Point(64, 251)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(183, 89)
        PictureBox3.TabIndex = 33
        PictureBox3.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(79, 373)
        Label4.Name = "Label4"
        Label4.Size = New Size(83, 20)
        Label4.TabIndex = 37
        Label4.Text = "Convert To"
        ' 
        ' btnConvertToExcel
        ' 
        btnConvertToExcel.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnConvertToExcel.ForeColor = Color.Brown
        btnConvertToExcel.Location = New Point(86, 406)
        btnConvertToExcel.Name = "btnConvertToExcel"
        btnConvertToExcel.Size = New Size(128, 33)
        btnConvertToExcel.TabIndex = 35
        btnConvertToExcel.Text = "Excel"
        btnConvertToExcel.UseVisualStyleBackColor = True
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.WhiteSmoke
        PictureBox4.BorderStyle = BorderStyle.FixedSingle
        PictureBox4.Location = New Point(64, 385)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(183, 76)
        PictureBox4.TabIndex = 36
        PictureBox4.TabStop = False
        ' 
        ' dgvAccountsUser
        ' 
        dgvAccountsUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAccountsUser.Location = New Point(293, 116)
        dgvAccountsUser.Name = "dgvAccountsUser"
        dgvAccountsUser.RowHeadersWidth = 51
        dgvAccountsUser.Size = New Size(515, 345)
        dgvAccountsUser.TabIndex = 38
        ' 
        ' DbUser
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(838, 498)
        Controls.Add(dgvAccountsUser)
        Controls.Add(btnConvertToExcel)
        Controls.Add(btnManagePassword)
        Controls.Add(btnCreatePassword)
        Controls.Add(btnLogout)
        Controls.Add(lblTitle)
        Controls.Add(Label2)
        Controls.Add(Label3)
        Controls.Add(Label4)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox4)
        Controls.Add(PictureBox3)
        Name = "DbUser"
        Text = "DashboardUser"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvAccountsUser, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCreatePassword As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnManagePassword As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnConvertToExcel As Button
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents dgvAccountsUser As DataGridView
End Class
