<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MAdmin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MAdmin))
        PictureBox1 = New PictureBox()
        dgvAdmins = New DataGridView()
        txtAdminID = New TextBox()
        lblAdminID = New Label()
        btnBack = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnEdit = New Button()
        btnAdd = New Button()
        txtPasswordAdmin = New TextBox()
        txtUsernameAdmin = New TextBox()
        lblPassword = New Label()
        lblUsername = New Label()
        lblJudul = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvAdmins, ComponentModel.ISupportInitialize).BeginInit()
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
        ' dgvAdmins
        ' 
        dgvAdmins.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAdmins.Location = New Point(48, 379)
        dgvAdmins.Name = "dgvAdmins"
        dgvAdmins.RowHeadersWidth = 51
        dgvAdmins.Size = New Size(808, 198)
        dgvAdmins.TabIndex = 67
        ' 
        ' txtAdminID
        ' 
        txtAdminID.Location = New Point(202, 123)
        txtAdminID.Name = "txtAdminID"
        txtAdminID.Size = New Size(208, 27)
        txtAdminID.TabIndex = 65
        ' 
        ' lblAdminID
        ' 
        lblAdminID.AutoSize = True
        lblAdminID.BackColor = Color.Transparent
        lblAdminID.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAdminID.Location = New Point(48, 119)
        lblAdminID.Name = "lblAdminID"
        lblAdminID.Size = New Size(98, 28)
        lblAdminID.TabIndex = 63
        lblAdminID.Text = "Admin ID"
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.CornflowerBlue
        btnBack.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnBack.ForeColor = Color.Transparent
        btnBack.Location = New Point(464, 315)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(392, 39)
        btnBack.TabIndex = 62
        btnBack.Text = "Back To Dashboard"
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = SystemColors.HotTrack
        btnUpdate.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnUpdate.ForeColor = Color.Transparent
        btnUpdate.Location = New Point(466, 270)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(392, 39)
        btnUpdate.TabIndex = 61
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Transparent
        btnDelete.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnDelete.ForeColor = Color.Brown
        btnDelete.Location = New Point(739, 225)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(119, 39)
        btnDelete.TabIndex = 60
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.Transparent
        btnEdit.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnEdit.ForeColor = Color.FromArgb(CByte(53), CByte(139), CByte(35))
        btnEdit.Location = New Point(604, 225)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(119, 39)
        btnEdit.TabIndex = 59
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.White
        btnAdd.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnAdd.ForeColor = SystemColors.HotTrack
        btnAdd.Location = New Point(467, 225)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(119, 39)
        btnAdd.TabIndex = 58
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' txtPasswordAdmin
        ' 
        txtPasswordAdmin.Location = New Point(650, 177)
        txtPasswordAdmin.Name = "txtPasswordAdmin"
        txtPasswordAdmin.Size = New Size(208, 27)
        txtPasswordAdmin.TabIndex = 57
        ' 
        ' txtUsernameAdmin
        ' 
        txtUsernameAdmin.Location = New Point(650, 123)
        txtUsernameAdmin.Name = "txtUsernameAdmin"
        txtUsernameAdmin.Size = New Size(208, 27)
        txtUsernameAdmin.TabIndex = 56
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.BackColor = Color.Transparent
        lblPassword.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPassword.Location = New Point(454, 173)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(163, 28)
        lblPassword.TabIndex = 55
        lblPassword.Text = "Password Admin"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.BackColor = Color.Transparent
        lblUsername.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsername.Location = New Point(454, 119)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(170, 28)
        lblUsername.TabIndex = 54
        lblUsername.Text = "Username Admin"
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.BackColor = Color.Transparent
        lblJudul.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblJudul.Location = New Point(624, 52)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(234, 41)
        lblJudul.TabIndex = 53
        lblJudul.Text = "Manage Admin"
        ' 
        ' MAdmin
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(904, 589)
        Controls.Add(dgvAdmins)
        Controls.Add(txtAdminID)
        Controls.Add(btnBack)
        Controls.Add(btnUpdate)
        Controls.Add(btnDelete)
        Controls.Add(btnEdit)
        Controls.Add(btnAdd)
        Controls.Add(txtPasswordAdmin)
        Controls.Add(txtUsernameAdmin)
        Controls.Add(lblPassword)
        Controls.Add(lblUsername)
        Controls.Add(lblJudul)
        Controls.Add(lblAdminID)
        Controls.Add(PictureBox1)
        Name = "MAdmin"
        Text = "MAdmin"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvAdmins, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents dgvAdmins As DataGridView
    Friend WithEvents txtAdminID As TextBox
    Friend WithEvents lblAdminID As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtPasswordAdmin As TextBox
    Friend WithEvents txtUsernameAdmin As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblJudul As Label
End Class
