<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MPassUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MPassUser))
        PictureBox1 = New PictureBox()
        dgvAccounts = New DataGridView()
        txt_us_Password = New TextBox()
        txt_us_UsernameAccount = New TextBox()
        txt_us_URLAccount = New TextBox()
        txt_us_EmployeeID = New TextBox()
        btnBackToDashboard = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnEdit = New Button()
        btnAdd = New Button()
        lblPassword = New Label()
        lblUsernameAccount = New Label()
        lblURLAccount = New Label()
        lblEmployeeID = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvAccounts, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.Location = New Point(50, 30)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(197, 63)
        PictureBox1.TabIndex = 27
        PictureBox1.TabStop = False
        ' 
        ' dgvAccounts
        ' 
        dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAccounts.Location = New Point(50, 371)
        dgvAccounts.Name = "dgvAccounts"
        dgvAccounts.RowHeadersWidth = 51
        dgvAccounts.Size = New Size(815, 178)
        dgvAccounts.TabIndex = 57
        ' 
        ' txt_us_Password
        ' 
        txt_us_Password.Location = New Point(675, 174)
        txt_us_Password.Name = "txt_us_Password"
        txt_us_Password.Size = New Size(190, 27)
        txt_us_Password.TabIndex = 56
        ' 
        ' txt_us_UsernameAccount
        ' 
        txt_us_UsernameAccount.Location = New Point(674, 119)
        txt_us_UsernameAccount.Name = "txt_us_UsernameAccount"
        txt_us_UsernameAccount.Size = New Size(190, 27)
        txt_us_UsernameAccount.TabIndex = 55
        ' 
        ' txt_us_URLAccount
        ' 
        txt_us_URLAccount.Location = New Point(251, 177)
        txt_us_URLAccount.Name = "txt_us_URLAccount"
        txt_us_URLAccount.Size = New Size(189, 27)
        txt_us_URLAccount.TabIndex = 54
        ' 
        ' txt_us_EmployeeID
        ' 
        txt_us_EmployeeID.Location = New Point(251, 118)
        txt_us_EmployeeID.Name = "txt_us_EmployeeID"
        txt_us_EmployeeID.Size = New Size(189, 27)
        txt_us_EmployeeID.TabIndex = 52
        ' 
        ' btnBackToDashboard
        ' 
        btnBackToDashboard.BackColor = Color.CornflowerBlue
        btnBackToDashboard.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnBackToDashboard.ForeColor = Color.Transparent
        btnBackToDashboard.Location = New Point(472, 326)
        btnBackToDashboard.Name = "btnBackToDashboard"
        btnBackToDashboard.Size = New Size(392, 39)
        btnBackToDashboard.TabIndex = 51
        btnBackToDashboard.Text = "Back To Dashboard"
        btnBackToDashboard.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = SystemColors.HotTrack
        btnUpdate.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnUpdate.ForeColor = Color.Transparent
        btnUpdate.Location = New Point(473, 281)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(392, 39)
        btnUpdate.TabIndex = 50
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Transparent
        btnDelete.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnDelete.ForeColor = Color.Brown
        btnDelete.Location = New Point(746, 233)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(119, 39)
        btnDelete.TabIndex = 49
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.Transparent
        btnEdit.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnEdit.ForeColor = Color.FromArgb(CByte(53), CByte(139), CByte(35))
        btnEdit.Location = New Point(609, 233)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(119, 39)
        btnEdit.TabIndex = 48
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.Transparent
        btnAdd.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnAdd.ForeColor = SystemColors.HotTrack
        btnAdd.Location = New Point(472, 233)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(119, 39)
        btnAdd.TabIndex = 47
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.BackColor = Color.Transparent
        lblPassword.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPassword.Location = New Point(473, 173)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(97, 28)
        lblPassword.TabIndex = 46
        lblPassword.Text = "Password"
        ' 
        ' lblUsernameAccount
        ' 
        lblUsernameAccount.AutoSize = True
        lblUsernameAccount.BackColor = Color.Transparent
        lblUsernameAccount.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsernameAccount.Location = New Point(472, 119)
        lblUsernameAccount.Name = "lblUsernameAccount"
        lblUsernameAccount.Size = New Size(184, 28)
        lblUsernameAccount.TabIndex = 45
        lblUsernameAccount.Text = "Username Account"
        ' 
        ' lblURLAccount
        ' 
        lblURLAccount.AutoSize = True
        lblURLAccount.BackColor = Color.Transparent
        lblURLAccount.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblURLAccount.Location = New Point(49, 172)
        lblURLAccount.Name = "lblURLAccount"
        lblURLAccount.Size = New Size(128, 28)
        lblURLAccount.TabIndex = 44
        lblURLAccount.Text = "URL Account"
        ' 
        ' lblEmployeeID
        ' 
        lblEmployeeID.AutoSize = True
        lblEmployeeID.BackColor = Color.Transparent
        lblEmployeeID.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEmployeeID.Location = New Point(49, 118)
        lblEmployeeID.Name = "lblEmployeeID"
        lblEmployeeID.Size = New Size(127, 28)
        lblEmployeeID.TabIndex = 42
        lblEmployeeID.Text = "Employee ID"
        ' 
        ' MPassUser
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(904, 589)
        Controls.Add(dgvAccounts)
        Controls.Add(txt_us_Password)
        Controls.Add(txt_us_UsernameAccount)
        Controls.Add(txt_us_URLAccount)
        Controls.Add(txt_us_EmployeeID)
        Controls.Add(btnBackToDashboard)
        Controls.Add(btnUpdate)
        Controls.Add(btnDelete)
        Controls.Add(btnEdit)
        Controls.Add(btnAdd)
        Controls.Add(lblPassword)
        Controls.Add(lblUsernameAccount)
        Controls.Add(lblURLAccount)
        Controls.Add(lblEmployeeID)
        Controls.Add(PictureBox1)
        Name = "MPassUser"
        Text = "MPassUser"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvAccounts, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents dgvAccounts As DataGridView
    Friend WithEvents txt_us_Password As TextBox
    Friend WithEvents txt_us_UsernameAccount As TextBox
    Friend WithEvents txt_us_URLAccount As TextBox
    Friend WithEvents txt_us_EmployeeID As TextBox
    Friend WithEvents btnBackToDashboard As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblUsernameAccount As Label
    Friend WithEvents lblURLAccount As Label
    Friend WithEvents lblEmployeeID As Label
End Class
