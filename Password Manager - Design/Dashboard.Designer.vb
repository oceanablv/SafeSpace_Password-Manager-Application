<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        btnLogout = New Button()
        btnCreatePassword = New Button()
        btnManagePassword = New Button()
        btnManageEmployee = New Button()
        PictureBox1 = New PictureBox()
        lblDashboard = New Label()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        lblCreate = New Label()
        lblManage = New Label()
        lblConvertTo = New Label()
        btnConvertToExcel = New Button()
        PictureBox4 = New PictureBox()
        btnManageADmin = New Button()
        dgvActivityLogs = New DataGridView()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvActivityLogs, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.Brown
        btnLogout.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogout.ForeColor = Color.WhiteSmoke
        btnLogout.Location = New Point(739, 46)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(132, 35)
        btnLogout.TabIndex = 0
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnCreatePassword
        ' 
        btnCreatePassword.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCreatePassword.ForeColor = SystemColors.HotTrack
        btnCreatePassword.Location = New Point(84, 137)
        btnCreatePassword.Name = "btnCreatePassword"
        btnCreatePassword.Size = New Size(128, 33)
        btnCreatePassword.TabIndex = 1
        btnCreatePassword.Text = "Password"
        btnCreatePassword.UseVisualStyleBackColor = True
        ' 
        ' btnManagePassword
        ' 
        btnManagePassword.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnManagePassword.ForeColor = SystemColors.HotTrack
        btnManagePassword.Location = New Point(84, 267)
        btnManagePassword.Name = "btnManagePassword"
        btnManagePassword.Size = New Size(128, 33)
        btnManagePassword.TabIndex = 3
        btnManagePassword.Text = "Password"
        btnManagePassword.UseVisualStyleBackColor = True
        ' 
        ' btnManageEmployee
        ' 
        btnManageEmployee.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnManageEmployee.ForeColor = Color.FromArgb(CByte(53), CByte(139), CByte(35))
        btnManageEmployee.Location = New Point(84, 318)
        btnManageEmployee.Name = "btnManageEmployee"
        btnManageEmployee.Size = New Size(128, 33)
        btnManageEmployee.TabIndex = 5
        btnManageEmployee.Text = "Employee"
        btnManageEmployee.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.Location = New Point(50, 30)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(197, 63)
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' lblDashboard
        ' 
        lblDashboard.AutoSize = True
        lblDashboard.BackColor = Color.Transparent
        lblDashboard.Font = New Font("Segoe UI Variable Small", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDashboard.Location = New Point(291, 35)
        lblDashboard.Name = "lblDashboard"
        lblDashboard.Size = New Size(198, 46)
        lblDashboard.TabIndex = 8
        lblDashboard.Text = "Dashboard"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.WhiteSmoke
        PictureBox2.BorderStyle = BorderStyle.FixedSingle
        PictureBox2.Location = New Point(62, 113)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(183, 89)
        PictureBox2.TabIndex = 9
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.WhiteSmoke
        PictureBox3.BorderStyle = BorderStyle.FixedSingle
        PictureBox3.Location = New Point(62, 240)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(183, 181)
        PictureBox3.TabIndex = 10
        PictureBox3.TabStop = False
        ' 
        ' lblCreate
        ' 
        lblCreate.AutoSize = True
        lblCreate.BackColor = Color.Transparent
        lblCreate.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCreate.Location = New Point(77, 103)
        lblCreate.Name = "lblCreate"
        lblCreate.Size = New Size(53, 20)
        lblCreate.TabIndex = 11
        lblCreate.Text = "Create"
        ' 
        ' lblManage
        ' 
        lblManage.AutoSize = True
        lblManage.BackColor = Color.Transparent
        lblManage.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblManage.Location = New Point(77, 229)
        lblManage.Name = "lblManage"
        lblManage.Size = New Size(65, 20)
        lblManage.TabIndex = 12
        lblManage.Text = "Manage"
        ' 
        ' lblConvertTo
        ' 
        lblConvertTo.AutoSize = True
        lblConvertTo.BackColor = Color.Transparent
        lblConvertTo.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblConvertTo.Location = New Point(77, 453)
        lblConvertTo.Name = "lblConvertTo"
        lblConvertTo.Size = New Size(83, 20)
        lblConvertTo.TabIndex = 16
        lblConvertTo.Text = "Convert To"
        ' 
        ' btnConvertToExcel
        ' 
        btnConvertToExcel.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnConvertToExcel.ForeColor = Color.Brown
        btnConvertToExcel.Location = New Point(84, 486)
        btnConvertToExcel.Name = "btnConvertToExcel"
        btnConvertToExcel.Size = New Size(128, 33)
        btnConvertToExcel.TabIndex = 13
        btnConvertToExcel.Text = "Excel"
        btnConvertToExcel.UseVisualStyleBackColor = True
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.WhiteSmoke
        PictureBox4.BorderStyle = BorderStyle.FixedSingle
        PictureBox4.Location = New Point(62, 465)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(183, 76)
        PictureBox4.TabIndex = 15
        PictureBox4.TabStop = False
        ' 
        ' btnManageADmin
        ' 
        btnManageADmin.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnManageADmin.ForeColor = Color.Goldenrod
        btnManageADmin.Location = New Point(84, 370)
        btnManageADmin.Name = "btnManageADmin"
        btnManageADmin.Size = New Size(128, 33)
        btnManageADmin.TabIndex = 17
        btnManageADmin.Text = "Admin"
        btnManageADmin.UseVisualStyleBackColor = True
        ' 
        ' dgvActivityLogs
        ' 
        dgvActivityLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvActivityLogs.Location = New Point(291, 113)
        dgvActivityLogs.Name = "dgvActivityLogs"
        dgvActivityLogs.RowHeadersWidth = 51
        dgvActivityLogs.Size = New Size(580, 428)
        dgvActivityLogs.TabIndex = 18
        ' 
        ' Dashboard
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(904, 589)
        Controls.Add(dgvActivityLogs)
        Controls.Add(lblConvertTo)
        Controls.Add(lblManage)
        Controls.Add(lblCreate)
        Controls.Add(lblDashboard)
        Controls.Add(btnLogout)
        Controls.Add(btnManageEmployee)
        Controls.Add(btnManagePassword)
        Controls.Add(btnManageADmin)
        Controls.Add(btnCreatePassword)
        Controls.Add(btnConvertToExcel)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox4)
        Name = "Dashboard"
        Text = "Dashboard"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvActivityLogs, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnLogout As Button
    Friend WithEvents btnCreatePassword As Button
    Friend WithEvents btnManagePassword As Button
    Friend WithEvents btnManageEmployee As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblDashboard As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents lblCreate As Label
    Friend WithEvents lblManage As Label
    Friend WithEvents lblConvertTo As Label
    Friend WithEvents btnConvertToExcel As Button
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents btnManageADmin As Button
    Friend WithEvents dgvActivityLogs As DataGridView
End Class
