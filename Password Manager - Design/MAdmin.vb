Imports MySql.Data.MySqlClient
Public Class MAdmin

    Private Const ConnStr As String = "server=localhost;user id=safespace;password=safespace123;database=employee_db"
    Private isEditing As Boolean = False

    Private Sub MAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGrid()
        LoadData()
        SetupInitialState()
    End Sub

    Private Sub SetupDataGrid()
        With dgvAdmins
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()
            .Columns.Add("AdminID", "Admin ID")
            .Columns.Add("EmployeeName", "Employee Name")
            .Columns.Add("UsernameAdmin", "Username Admin")
            .Columns.Add("PasswordAdmin", "Password Admin")
        End With
    End Sub

    Private Sub LoadData()
        dgvAdmins.Rows.Clear()
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Dim query As String = "SELECT a.AdminID, e.Name AS EmployeeName, a.UsernameAdmin, a.PasswordAdmin " &
                                      "FROM admin a LEFT JOIN employee e ON a.AdminID = e.ID"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            dgvAdmins.Rows.Add(reader("AdminID"), reader("EmployeeName"), reader("UsernameAdmin"), reader("PasswordAdmin"))
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Gagal memuat data admin: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub SetupInitialState()
        SetFieldsEnabled(False)
        btnUpdate.Enabled = False
        btnAdd.Text = "Add"
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub SetFieldsEnabled(enabled As Boolean)
        txtAdminID.Enabled = enabled AndAlso Not isEditing
        txtUsernameAdmin.Enabled = enabled
        txtPasswordAdmin.Enabled = enabled
    End Sub

    Private Sub ClearFields()
        txtAdminID.Clear()
        txtUsernameAdmin.Clear()
        txtPasswordAdmin.Clear()
    End Sub

    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtAdminID.Text) OrElse
           String.IsNullOrWhiteSpace(txtUsernameAdmin.Text) OrElse
           String.IsNullOrWhiteSpace(txtPasswordAdmin.Text) Then
            MessageBox.Show("Semua field wajib diisi!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If Not txtAdminID.Text.StartsWith("ADM") Then
            MessageBox.Show("Format Admin ID harus diawali 'ADM'.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

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
                AddNewAdmin()
                btnAdd.Text = "Add"
                SetupInitialState()
                LoadData()
            End If
        End If
    End Sub

    Private Sub AddNewAdmin()
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()

                ' Cek apakah ID pegawai sudah ada
                Dim checkEmpQuery As String = "SELECT COUNT(*) FROM employee WHERE ID = @id"
                Using checkCmd As New MySqlCommand(checkEmpQuery, conn)
                    checkCmd.Parameters.AddWithValue("@id", txtAdminID.Text.Trim())
                    Dim empCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If empCount = 0 Then
                        MessageBox.Show("ID pegawai tidak ditemukan. Silakan gunakan ID yang terdaftar di tabel employee.", "ID Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End Using

                ' Cek apakah ID admin sudah ada di tabel admin
                Dim checkAdminQuery As String = "SELECT COUNT(*) FROM admin WHERE AdminID = @id"
                Using checkCmd As New MySqlCommand(checkAdminQuery, conn)
                    checkCmd.Parameters.AddWithValue("@id", txtAdminID.Text.Trim())
                    Dim admCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If admCount > 0 Then
                        MessageBox.Show("Akun admin untuk ID ini sudah ada.", "Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End Using

                ' Insert ke tabel admin
                Dim insertAdminQuery As String = "INSERT INTO admin (AdminID, UsernameAdmin, PasswordAdmin) VALUES (@id, @username, @password)"
                Using cmdAdmin As New MySqlCommand(insertAdminQuery, conn)
                    cmdAdmin.Parameters.AddWithValue("@id", txtAdminID.Text.Trim())
                    cmdAdmin.Parameters.AddWithValue("@username", txtUsernameAdmin.Text.Trim())
                    cmdAdmin.Parameters.AddWithValue("@password", txtPasswordAdmin.Text.Trim())
                    cmdAdmin.ExecuteNonQuery()
                End Using

                MessageBox.Show("Akun admin berhasil dibuat!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Gagal menambahkan akun admin: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvAdmins.SelectedRows.Count > 0 Then
            isEditing = True
            SetFieldsEnabled(True)
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            btnUpdate.Enabled = True
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If ValidateInput() Then
            UpdateAdmin()
            isEditing = False
            SetupInitialState()
            LoadData()
        End If
    End Sub

    Private Sub UpdateAdmin()
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Dim query As String = "UPDATE admin SET UsernameAdmin=@username, PasswordAdmin=@password WHERE AdminID=@id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", txtAdminID.Text.Trim())
                    cmd.Parameters.AddWithValue("@username", txtUsernameAdmin.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", txtPasswordAdmin.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Admin berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Gagal update admin: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvAdmins.SelectedRows.Count > 0 AndAlso
           MessageBox.Show("Hapus admin ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DeleteAdmin()
            SetupInitialState()
            LoadData()
        End If
    End Sub

    Private Sub DeleteAdmin()
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Dim adminQuery As String = "DELETE FROM admin WHERE AdminID=@id"
                Using cmdAdmin As New MySqlCommand(adminQuery, conn)
                    cmdAdmin.Parameters.AddWithValue("@id", txtAdminID.Text.Trim())
                    cmdAdmin.ExecuteNonQuery()
                End Using

                MessageBox.Show("Admin berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Gagal menghapus admin: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        ClearFields()
    End Sub

    Private Sub dgvAdmins_SelectionChanged(sender As Object, e As EventArgs) Handles dgvAdmins.SelectionChanged
        If dgvAdmins.SelectedRows.Count > 0 Then
            With dgvAdmins.SelectedRows(0)
                txtAdminID.Text = .Cells(0).Value.ToString()
                txtUsernameAdmin.Text = .Cells(2).Value.ToString()
                txtPasswordAdmin.Text = .Cells(3).Value.ToString()
            End With
            btnEdit.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dashboard.Show()
        Me.Hide()
    End Sub

End Class
