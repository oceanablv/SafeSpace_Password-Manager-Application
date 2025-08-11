<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MPassword))
        PictureBox1 = New PictureBox()
        txtPassword = New TextBox()
        txtUsernameAccount = New TextBox()
        txtURLAccount = New TextBox()
        txtEmployeeID = New TextBox()
        btnBackToDashboard = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnEdit = New Button()
        btnAdd = New Button()
        lblPassword = New Label()
        lblUsernameAccount = New Label()
        lblURLAccount = New Label()
        lblEmployeeID = New Label()
        lblJudul = New Label()
        dgvAccounts = New DataGridView()
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
        PictureBox1.TabIndex = 8
        PictureBox1.TabStop = False
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(676, 184)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(190, 27)
        txtPassword.TabIndex = 40
        ' 
        ' txtUsernameAccount
        ' 
        txtUsernameAccount.Location = New Point(675, 129)
        txtUsernameAccount.Name = "txtUsernameAccount"
        txtUsernameAccount.Size = New Size(190, 27)
        txtUsernameAccount.TabIndex = 39
        ' 
        ' txtURLAccount
        ' 
        txtURLAccount.Location = New Point(252, 187)
        txtURLAccount.Name = "txtURLAccount"
        txtURLAccount.Size = New Size(189, 27)
        txtURLAccount.TabIndex = 38
        ' 
        ' txtEmployeeID
        ' 
        txtEmployeeID.Location = New Point(252, 128)
        txtEmployeeID.Name = "txtEmployeeID"
        txtEmployeeID.Size = New Size(189, 27)
        txtEmployeeID.TabIndex = 36
        ' 
        ' btnBackToDashboard
        ' 
        btnBackToDashboard.BackColor = Color.CornflowerBlue
        btnBackToDashboard.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnBackToDashboard.ForeColor = Color.Transparent
        btnBackToDashboard.Location = New Point(473, 336)
        btnBackToDashboard.Name = "btnBackToDashboard"
        btnBackToDashboard.Size = New Size(392, 39)
        btnBackToDashboard.TabIndex = 35
        btnBackToDashboard.Text = "Back To Dashboard"
        btnBackToDashboard.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = SystemColors.HotTrack
        btnUpdate.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnUpdate.ForeColor = Color.Transparent
        btnUpdate.Location = New Point(474, 291)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(392, 39)
        btnUpdate.TabIndex = 34
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Transparent
        btnDelete.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnDelete.ForeColor = Color.Brown
        btnDelete.Location = New Point(747, 243)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(119, 39)
        btnDelete.TabIndex = 33
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.Transparent
        btnEdit.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnEdit.ForeColor = Color.FromArgb(CByte(53), CByte(139), CByte(35))
        btnEdit.Location = New Point(610, 243)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(119, 39)
        btnEdit.TabIndex = 32
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.Transparent
        btnAdd.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnAdd.ForeColor = SystemColors.HotTrack
        btnAdd.Location = New Point(473, 243)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(119, 39)
        btnAdd.TabIndex = 31
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.BackColor = Color.Transparent
        lblPassword.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPassword.Location = New Point(474, 183)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(97, 28)
        lblPassword.TabIndex = 30
        lblPassword.Text = "Password"
        ' 
        ' lblUsernameAccount
        ' 
        lblUsernameAccount.AutoSize = True
        lblUsernameAccount.BackColor = Color.Transparent
        lblUsernameAccount.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsernameAccount.Location = New Point(473, 129)
        lblUsernameAccount.Name = "lblUsernameAccount"
        lblUsernameAccount.Size = New Size(184, 28)
        lblUsernameAccount.TabIndex = 29
        lblUsernameAccount.Text = "Username Account"
        ' 
        ' lblURLAccount
        ' 
        lblURLAccount.AutoSize = True
        lblURLAccount.BackColor = Color.Transparent
        lblURLAccount.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblURLAccount.Location = New Point(50, 182)
        lblURLAccount.Name = "lblURLAccount"
        lblURLAccount.Size = New Size(128, 28)
        lblURLAccount.TabIndex = 28
        lblURLAccount.Text = "URL Account"
        ' 
        ' lblEmployeeID
        ' 
        lblEmployeeID.AutoSize = True
        lblEmployeeID.BackColor = Color.Transparent
        lblEmployeeID.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEmployeeID.Location = New Point(50, 128)
        lblEmployeeID.Name = "lblEmployeeID"
        lblEmployeeID.Size = New Size(127, 28)
        lblEmployeeID.TabIndex = 26
        lblEmployeeID.Text = "Employee ID"
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.BackColor = Color.Transparent
        lblJudul.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblJudul.Location = New Point(466, 52)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(400, 41)
        lblJudul.TabIndex = 25
        lblJudul.Text = "Manage Employee Account"
        ' 
        ' dgvAccounts
        ' 
        dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAccounts.Location = New Point(51, 381)
        dgvAccounts.Name = "dgvAccounts"
        dgvAccounts.RowHeadersWidth = 51
        dgvAccounts.Size = New Size(815, 178)
        dgvAccounts.TabIndex = 41
        ' 
        ' MPassword
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(904, 589)
        Controls.Add(dgvAccounts)
        Controls.Add(txtPassword)
        Controls.Add(txtUsernameAccount)
        Controls.Add(txtURLAccount)
        Controls.Add(txtEmployeeID)
        Controls.Add(btnBackToDashboard)
        Controls.Add(btnUpdate)
        Controls.Add(btnDelete)
        Controls.Add(btnEdit)
        Controls.Add(btnAdd)
        Controls.Add(lblPassword)
        Controls.Add(lblUsernameAccount)
        Controls.Add(lblURLAccount)
        Controls.Add(lblEmployeeID)
        Controls.Add(lblJudul)
        Controls.Add(PictureBox1)
        Name = "MPassword"
        Text = "MPassword"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvAccounts, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsernameAccount As TextBox
    Friend WithEvents txtURLAccount As TextBox
    Friend WithEvents txtEmployeeID As TextBox
    Friend WithEvents btnBackToDashboard As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblUsernameAccount As Label
    Friend WithEvents lblURLAccount As Label
    Friend WithEvents lblEmployeeID As Label
    Friend WithEvents lblJudul As Label
    Friend WithEvents dgvAccounts As DataGridView
End Class
