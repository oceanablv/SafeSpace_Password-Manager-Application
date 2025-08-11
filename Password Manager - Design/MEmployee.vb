Imports MySql.Data.MySqlClient
Public Class MEmployee
    ' String koneksi ke database MySQL
    Private Const ConnStr As String = "server=localhost;user id=safespace;password=safespace123;database=employee_db"
    Private isEditing As Boolean = False

    ' Fungsi untuk membuat username default berdasarkan nama karyawan
    Private Function GenerateDefaultUsername(employeeName As String) As String
        Dim nameParts = employeeName.Trim().Split(" "c)
        If nameParts.Length > 1 Then
            Return (nameParts(0).Substring(0, 1) & nameParts(nameParts.Length - 1)).ToLower()
        Else
            Return employeeName.ToLower()
        End If
    End Function

    ' Fungsi untuk membuat password default berdasarkan ID karyawan
    Private Function GenerateDefaultPassword(employeeId As String) As String
        Return employeeId.ToLower() & "123"
    End Function

    ' Event saat form dimuat
    Private Sub MEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        SetupDataGrid()      ' Siapkan tampilan tabel karyawan
        SetupRoleCombo()     ' Siapkan pilihan role
        LoadData()           ' Muat data karyawan dari database
        SetupInitialState()  ' Set tampilan awal form
    End Sub

    ' Form: MEmployee
    ' Mengisi ComboBox role dengan pilihan Admin dan User
    Private Sub SetupRoleCombo()
        cmbRole.Items.Clear()
        cmbRole.Items.Add("Admin")
        cmbRole.Items.Add("User")
        cmbRole.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' Konfigurasi DataGridView untuk menampilkan data karyawan
    Private Sub SetupDataGrid()
        With dgvEmployees
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()
            .Columns.Add("ID", "Employee ID")
            .Columns.Add("Name", "Employee Name")
            .Columns.Add("Division", "Division")
            .Columns.Add("Phone", "Phone Number")
            .Columns.Add("Email", "E-Mail")
            .Columns.Add("Role", "Role")
        End With
    End Sub

    ' Memuat data karyawan dari database ke DataGridView
    Private Sub LoadData()
        dgvEmployees.Rows.Clear()
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Dim query As String = "SELECT ID, Name, Division, Phone, Email, Role FROM employee"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            dgvEmployees.Rows.Add(
                                reader("ID"),
                                reader("Name"),
                                reader("Division"),
                                reader("Phone"),
                                reader("Email"),
                                reader("Role")
                            )
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Gagal memuat data karyawan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Set tampilan awal form (disable field, atur tombol)
    Private Sub SetupInitialState()
        SetFieldsEnabled(False)
        btnUpdate.Enabled = False
        btnAdd.Text = "Add"
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        cmbRole.SelectedIndex = -1
    End Sub

    ' Mengatur field input enable/disable
    Private Sub SetFieldsEnabled(enabled As Boolean)
        txtEmployeeID.Enabled = enabled AndAlso Not isEditing
        txtEmployeeName.Enabled = enabled
        txtDivision.Enabled = enabled
        txtPhoneNumber.Enabled = enabled
        txtEmail.Enabled = enabled
        cmbRole.Enabled = enabled
    End Sub

    ' Mengosongkan semua field input
    Private Sub ClearFields()
        txtEmployeeID.Clear()
        txtEmployeeName.Clear()
        txtDivision.Clear()
        txtPhoneNumber.Clear()
        txtEmail.Clear()
        cmbRole.SelectedIndex = -1
    End Sub

    ' Validasi input sebelum simpan/update data
    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtEmployeeID.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmployeeName.Text) OrElse
           String.IsNullOrWhiteSpace(txtDivision.Text) OrElse
           String.IsNullOrWhiteSpace(txtPhoneNumber.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           cmbRole.SelectedIndex = -1 Then
            MessageBox.Show("Semua field wajib diisi!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cmbRole.SelectedItem.ToString() = "Admin" Then
            If Not txtEmployeeID.Text.StartsWith("ADM") Then
                MessageBox.Show("ID Admin harus diawali dengan 'ADM'.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Else
            If Not txtEmployeeID.Text.StartsWith("USR") Then
                MessageBox.Show("ID User harus diawali dengan 'USR'.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If

        Return True
    End Function

    ' Event klik tombol Add/Save
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If btnAdd.Text = "Add" Then
            ClearFields()
            SetFieldsEnabled(True)
            btnAdd.Text = "Save"
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
        Else
            If ValidateInput() Then
                AddNewEmployee()
                btnAdd.Text = "Add"
                SetupInitialState()
                LoadData()
            End If
        End If
    End Sub
    ' Menambah data karyawan baru ke database dan membuat akun default
    Private Sub AddNewEmployee()
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        ' Membuat username dan password default
                        Dim defaultUsername As String = GenerateDefaultUsername(txtEmployeeName.Text)
                        Dim defaultPassword As String = GenerateDefaultPassword(txtEmployeeID.Text)

                        ' Insert ke tabel employee
                        Dim query As String = "INSERT INTO employee (ID, Name, Division, Phone, Email, Role) VALUES (@id, @name, @division, @phone, @email, @role)"
                        Using cmd As New MySqlCommand(query, conn, transaction)
                            cmd.Parameters.AddWithValue("@id", txtEmployeeID.Text.Trim())
                            cmd.Parameters.AddWithValue("@name", txtEmployeeName.Text.Trim())
                            cmd.Parameters.AddWithValue("@division", txtDivision.Text.Trim())
                            cmd.Parameters.AddWithValue("@phone", txtPhoneNumber.Text.Trim())
                            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
                            cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString())
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Check role and insert credentials to appropriate table
                        If cmbRole.SelectedItem.ToString() = "Admin" Then
                            ' Insert ke tabel admin untuk role Admin dengan nama kolom yang benar
                            Dim adminQuery As String = "INSERT INTO admin (AdminID, UsernameAdmin, PasswordAdmin) VALUES (@adminid, @username, @password)"
                            Using cmdAdmin As New MySqlCommand(adminQuery, conn, transaction)
                                cmdAdmin.Parameters.AddWithValue("@adminid", txtEmployeeID.Text.Trim())
                                cmdAdmin.Parameters.AddWithValue("@username", defaultUsername)
                                cmdAdmin.Parameters.AddWithValue("@password", defaultPassword)
                                cmdAdmin.ExecuteNonQuery()
                            End Using
                        Else
                            ' Insert ke tabel appuser untuk role User (tetap sama)
                            Dim userQuery As String = "INSERT INTO appuser (UserID, UserRole, URLAccount, UsernameAccount, Password) VALUES (@userid, @role, 'SafeSpace', @username, @password)"
                            Using cmdUser As New MySqlCommand(userQuery, conn, transaction)
                                cmdUser.Parameters.AddWithValue("@userid", txtEmployeeID.Text.Trim())
                                cmdUser.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString())
                                cmdUser.Parameters.AddWithValue("@username", defaultUsername)
                                cmdUser.Parameters.AddWithValue("@password", defaultPassword)
                                cmdUser.ExecuteNonQuery()
                            End Using
                        End If

                        transaction.Commit()
                        MessageBox.Show($"Karyawan berhasil ditambahkan!" & vbCrLf & vbCrLf &
                              $"Kredensial default:" & vbCrLf &
                              $"Username: {defaultUsername}" & vbCrLf &
                              $"Password: {defaultPassword}" & vbCrLf & vbCrLf &
                              "Silakan ganti kredensial ini saat login pertama.",
                              "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("Gagal menambah karyawan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Event klik tombol Edit
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvEmployees.SelectedRows.Count > 0 Then
            isEditing = True
            SetFieldsEnabled(True)
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            btnUpdate.Enabled = True
        End If
    End Sub

    ' Event klik tombol Update
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If ValidateInput() Then
            UpdateEmployee()
            isEditing = False
            SetupInitialState()
            LoadData()
        End If
    End Sub

    ' Update data karyawan di database
    Private Sub UpdateEmployee()
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim query As String = "UPDATE employee SET Name=@name, Division=@division, Phone=@phone, Email=@email, Role=@role WHERE ID=@id"
                        Using cmd As New MySqlCommand(query, conn, transaction)
                            cmd.Parameters.AddWithValue("@id", txtEmployeeID.Text.Trim())
                            cmd.Parameters.AddWithValue("@name", txtEmployeeName.Text.Trim())
                            cmd.Parameters.AddWithValue("@division", txtDivision.Text.Trim())
                            cmd.Parameters.AddWithValue("@phone", txtPhoneNumber.Text.Trim())
                            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
                            cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString())
                            cmd.ExecuteNonQuery()
                        End Using

                        transaction.Commit()
                        MessageBox.Show("Data karyawan berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("Gagal update karyawan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Event klik tombol Delete
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvEmployees.SelectedRows.Count > 0 AndAlso
           MessageBox.Show("Hapus karyawan ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DeleteEmployee()
            SetupInitialState()
            LoadData()
        End If
    End Sub
    ' Form: MEmployee
    ' Menghapus data karyawan dari database (termasuk dari appuser)
    Private Sub DeleteEmployee()
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        ' Check role and delete from appropriate table
                        If cmbRole.SelectedItem.ToString() = "Admin" Then
                            ' Delete from admin table with correct column name
                            Dim adminQuery As String = "DELETE FROM admin WHERE AdminID=@id"
                            Using cmdAdmin As New MySqlCommand(adminQuery, conn, transaction)
                                cmdAdmin.Parameters.AddWithValue("@id", txtEmployeeID.Text.Trim())
                                cmdAdmin.ExecuteNonQuery()
                            End Using
                        Else
                            ' Delete from appuser table (tetap sama)
                            Dim userQuery As String = "DELETE FROM appuser WHERE UserID=@id"
                            Using cmdUser As New MySqlCommand(userQuery, conn, transaction)
                                cmdUser.Parameters.AddWithValue("@id", txtEmployeeID.Text.Trim())
                                cmdUser.ExecuteNonQuery()
                            End Using
                        End If
                        ' Delete from employee table
                        Dim query As String = "DELETE FROM employee WHERE ID=@id"
                        Using cmd As New MySqlCommand(query, conn, transaction)
                            cmd.Parameters.AddWithValue("@id", txtEmployeeID.Text.Trim())
                            cmd.ExecuteNonQuery()
                        End Using

                        transaction.Commit()
                        MessageBox.Show("Karyawan berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("Gagal menghapus karyawan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        ClearFields()
    End Sub


    ' Event saat baris di DataGridView dipilih, tampilkan data ke field input
    Private Sub dgvEmployees_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEmployees.SelectionChanged
        If dgvEmployees.SelectedRows.Count > 0 Then
            With dgvEmployees.SelectedRows(0)
                txtEmployeeID.Text = .Cells(0).Value.ToString()
                txtEmployeeName.Text = .Cells(1).Value.ToString()
                txtDivision.Text = .Cells(2).Value.ToString()
                txtPhoneNumber.Text = .Cells(3).Value.ToString()
                txtEmail.Text = .Cells(4).Value.ToString()
                If .Cells(5).Value IsNot Nothing Then
                    cmbRole.SelectedItem = .Cells(5).Value.ToString()
                Else
                    cmbRole.SelectedIndex = -1
                End If
            End With
            btnEdit.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub

    ' Event klik tombol kembali ke Dashboard
    Private Sub btnBackToDashboard_Click(sender As Object, e As EventArgs) Handles btnBackToDashboard.Click
        Dashboard.Show()
        Me.Hide()
    End Sub

End Class