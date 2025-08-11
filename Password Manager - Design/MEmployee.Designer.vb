<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MEmployee
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MEmployee))
        PictureBox1 = New PictureBox()
        cmbRole = New ComboBox()
        lblRole = New Label()
        dgvEmployees = New DataGridView()
        txtEmail = New TextBox()
        txtPhoneNumber = New TextBox()
        txtDivision = New TextBox()
        txtEmployeeName = New TextBox()
        txtEmployeeID = New TextBox()
        btnBackToDashboard = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnEdit = New Button()
        btnAdd = New Button()
        lblEmail = New Label()
        lblPhoneNumber = New Label()
        lblDivision = New Label()
        lblEmployeeName = New Label()
        lblEmployeeID = New Label()
        lblJudul = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvEmployees, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.Location = New Point(50, 30)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(197, 63)
        PictureBox1.TabIndex = 25
        PictureBox1.TabStop = False
        ' 
        ' cmbRole
        ' 
        cmbRole.FormattingEnabled = True
        cmbRole.Location = New Point(242, 278)
        cmbRole.Name = "cmbRole"
        cmbRole.Size = New Size(189, 28)
        cmbRole.TabIndex = 67
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.BackColor = Color.Transparent
        lblRole.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRole.Location = New Point(46, 278)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(51, 28)
        lblRole.TabIndex = 66
        lblRole.Text = "Role"
        ' 
        ' dgvEmployees
        ' 
        dgvEmployees.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvEmployees.Location = New Point(46, 383)
        dgvEmployees.Name = "dgvEmployees"
        dgvEmployees.RowHeadersWidth = 51
        dgvEmployees.Size = New Size(813, 190)
        dgvEmployees.TabIndex = 63
        ' 
        ' txtEmail
        ' 
        txtEmail.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtEmail.Location = New Point(670, 189)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(189, 27)
        txtEmail.TabIndex = 62
        ' 
        ' txtPhoneNumber
        ' 
        txtPhoneNumber.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtPhoneNumber.Location = New Point(670, 137)
        txtPhoneNumber.Name = "txtPhoneNumber"
        txtPhoneNumber.Size = New Size(189, 27)
        txtPhoneNumber.TabIndex = 61
        ' 
        ' txtDivision
        ' 
        txtDivision.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtDivision.Location = New Point(242, 233)
        txtDivision.Name = "txtDivision"
        txtDivision.Size = New Size(189, 27)
        txtDivision.TabIndex = 60
        ' 
        ' txtEmployeeName
        ' 
        txtEmployeeName.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtEmployeeName.Location = New Point(242, 189)
        txtEmployeeName.Name = "txtEmployeeName"
        txtEmployeeName.Size = New Size(189, 27)
        txtEmployeeName.TabIndex = 59
        ' 
        ' txtEmployeeID
        ' 
        txtEmployeeID.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtEmployeeID.Location = New Point(242, 137)
        txtEmployeeID.Name = "txtEmployeeID"
        txtEmployeeID.Size = New Size(189, 27)
        txtEmployeeID.TabIndex = 58
        ' 
        ' btnBackToDashboard
        ' 
        btnBackToDashboard.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnBackToDashboard.BackColor = Color.CornflowerBlue
        btnBackToDashboard.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnBackToDashboard.ForeColor = Color.Transparent
        btnBackToDashboard.Location = New Point(469, 323)
        btnBackToDashboard.Name = "btnBackToDashboard"
        btnBackToDashboard.Size = New Size(390, 39)
        btnBackToDashboard.TabIndex = 57
        btnBackToDashboard.Text = "Back To Dashboard"
        btnBackToDashboard.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnUpdate.BackColor = SystemColors.HotTrack
        btnUpdate.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnUpdate.ForeColor = Color.Transparent
        btnUpdate.Location = New Point(469, 278)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(392, 39)
        btnUpdate.TabIndex = 56
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnDelete.BackColor = Color.Transparent
        btnDelete.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnDelete.ForeColor = Color.Brown
        btnDelete.Location = New Point(742, 233)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(119, 39)
        btnDelete.TabIndex = 55
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnEdit.BackColor = Color.Transparent
        btnEdit.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnEdit.ForeColor = Color.FromArgb(CByte(53), CByte(139), CByte(35))
        btnEdit.Location = New Point(607, 233)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(119, 39)
        btnEdit.TabIndex = 54
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' btnAdd
        ' 
        btnAdd.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnAdd.BackColor = Color.White
        btnAdd.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
        btnAdd.ForeColor = SystemColors.HotTrack
        btnAdd.Location = New Point(470, 233)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(119, 39)
        btnAdd.TabIndex = 53
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' lblEmail
        ' 
        lblEmail.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblEmail.AutoSize = True
        lblEmail.BackColor = Color.Transparent
        lblEmail.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEmail.Location = New Point(470, 185)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(68, 28)
        lblEmail.TabIndex = 52
        lblEmail.Text = "E-Mail"
        ' 
        ' lblPhoneNumber
        ' 
        lblPhoneNumber.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblPhoneNumber.AutoSize = True
        lblPhoneNumber.BackColor = Color.Transparent
        lblPhoneNumber.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPhoneNumber.Location = New Point(470, 136)
        lblPhoneNumber.Name = "lblPhoneNumber"
        lblPhoneNumber.Size = New Size(152, 28)
        lblPhoneNumber.TabIndex = 51
        lblPhoneNumber.Text = "Phone Number"
        ' 
        ' lblDivision
        ' 
        lblDivision.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblDivision.AutoSize = True
        lblDivision.BackColor = Color.Transparent
        lblDivision.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDivision.Location = New Point(46, 233)
        lblDivision.Name = "lblDivision"
        lblDivision.Size = New Size(84, 28)
        lblDivision.TabIndex = 50
        lblDivision.Text = "Division"
        ' 
        ' lblEmployeeName
        ' 
        lblEmployeeName.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblEmployeeName.AutoSize = True
        lblEmployeeName.BackColor = Color.Transparent
        lblEmployeeName.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEmployeeName.Location = New Point(46, 185)
        lblEmployeeName.Name = "lblEmployeeName"
        lblEmployeeName.Size = New Size(161, 28)
        lblEmployeeName.TabIndex = 49
        lblEmployeeName.Text = "Employee Name"
        ' 
        ' lblEmployeeID
        ' 
        lblEmployeeID.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblEmployeeID.AutoSize = True
        lblEmployeeID.BackColor = Color.Transparent
        lblEmployeeID.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEmployeeID.Location = New Point(46, 136)
        lblEmployeeID.Name = "lblEmployeeID"
        lblEmployeeID.Size = New Size(127, 28)
        lblEmployeeID.TabIndex = 48
        lblEmployeeID.Text = "Employee ID"
        ' 
        ' lblJudul
        ' 
        lblJudul.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblJudul.AutoSize = True
        lblJudul.BackColor = Color.Transparent
        lblJudul.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblJudul.Location = New Point(582, 52)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(277, 41)
        lblJudul.TabIndex = 47
        lblJudul.Text = "Manage Employee"
        ' 
        ' MEmployee
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(904, 589)
        Controls.Add(cmbRole)
        Controls.Add(lblRole)
        Controls.Add(dgvEmployees)
        Controls.Add(txtEmail)
        Controls.Add(txtPhoneNumber)
        Controls.Add(txtDivision)
        Controls.Add(txtEmployeeName)
        Controls.Add(txtEmployeeID)
        Controls.Add(btnBackToDashboard)
        Controls.Add(btnUpdate)
        Controls.Add(btnDelete)
        Controls.Add(btnEdit)
        Controls.Add(btnAdd)
        Controls.Add(lblEmail)
        Controls.Add(lblPhoneNumber)
        Controls.Add(lblDivision)
        Controls.Add(lblEmployeeName)
        Controls.Add(lblEmployeeID)
        Controls.Add(lblJudul)
        Controls.Add(PictureBox1)
        Name = "MEmployee"
        Text = "MEmployee"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvEmployees, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cmbRole As ComboBox
    Friend WithEvents lblRole As Label
    Friend WithEvents dgvEmployees As DataGridView
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents txtDivision As TextBox
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents txtEmployeeID As TextBox
    Friend WithEvents btnBackToDashboard As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblPhoneNumber As Label
    Friend WithEvents lblDivision As Label
    Friend WithEvents lblEmployeeName As Label
    Friend WithEvents lblEmployeeID As Label
    Friend WithEvents lblJudul As Label
End Class
