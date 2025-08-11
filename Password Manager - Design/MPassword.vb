Imports MySql.Data.MySqlClient
Public Class MPassword
    Private Const ConnStr As String = "server=localhost;user id=safespace;password=safespace123;database=employee_db"
    Private isEditing As Boolean = False

    Private Sub MPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGrid()
        LoadData()
        SetupInitialState()
    End Sub

    Private Sub SetupDataGrid()
        With dgvAccounts
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()
            .Columns.Add("EmployeeID", "Employee ID")
            .Columns.Add("EmployeeName", "Employee Name")
            .Columns.Add("URLAccount", "URL Account")
            .Columns.Add("UsernameAccount", "Username Account")
            .Columns.Add("Password", "Password")
        End With
    End Sub

    ' Form: MPassword
    ' Kode untuk membaca data password dari database dan menampilkannya di DataGridView
    Private Sub LoadData()
        dgvAccounts.Rows.Clear()
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Dim query As String = "SELECT a.EmployeeID, e.Name AS EmployeeName, a.URLAccount, a.UsernameAccount, a.Password FROM accountpassword a LEFT JOIN employee e ON a.EmployeeID = e.ID"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            dgvAccounts.Rows.Add(reader("EmployeeID"), reader("EmployeeName"), reader("URLAccount"), reader("UsernameAccount"), reader("Password"))
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Gagal memuat data password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        txtEmployeeID.Enabled = enabled AndAlso Not isEditing
        txtURLAccount.Enabled = enabled
        txtUsernameAccount.Enabled = enabled
        txtPassword.Enabled = enabled
    End Sub

    Private Sub ClearFields()
        txtEmployeeID.Clear()
        txtURLAccount.Clear()
        txtUsernameAccount.Clear()
        txtPassword.Clear()
    End Sub

    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtEmployeeID.Text) OrElse
       String.IsNullOrWhiteSpace(txtURLAccount.Text) OrElse
       String.IsNullOrWhiteSpace(txtUsernameAccount.Text) OrElse
       String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Semua field wajib diisi!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If Not txtEmployeeID.Text.StartsWith("EMP") AndAlso Not txtEmployeeID.Text.StartsWith("ADM") AndAlso Not txtEmployeeID.Text.StartsWith("USR") Then
            MessageBox.Show("Format Employee ID tidak valid. Harus diawali dengan 'EMP', 'ADM', atau 'USR'.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                AddNewPassword()
                btnAdd.Text = "Add"
                SetupInitialState()
                LoadData()
            End If
        End If
    End Sub

    Private Sub AddNewPassword()
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Dim query As String = "INSERT INTO accountpassword (EmployeeID, URLAccount, UsernameAccount, Password, LastModified) VALUES (@eid, @url, @uname, @pass, @lastmod)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@eid", txtEmployeeID.Text.Trim())
                    cmd.Parameters.AddWithValue("@url", txtURLAccount.Text.Trim())
                    cmd.Parameters.AddWithValue("@uname", txtUsernameAccount.Text.Trim())
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim())
                    cmd.Parameters.AddWithValue("@lastmod", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Password account berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Gagal menambah password account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvAccounts.SelectedRows.Count > 0 Then
            isEditing = True
            SetFieldsEnabled(True)
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            btnUpdate.Enabled = True
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If ValidateInput() Then
            UpdatePassword()
            isEditing = False
            SetupInitialState()
            LoadData()
        End If
    End Sub

    Private Sub UpdatePassword()
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Dim query As String = "UPDATE accountpassword SET UsernameAccount=@uname, Password=@pass, LastModified=@lastmod WHERE EmployeeID=@eid AND URLAccount=@url"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@eid", txtEmployeeID.Text.Trim())
                    cmd.Parameters.AddWithValue("@url", txtURLAccount.Text.Trim())
                    cmd.Parameters.AddWithValue("@uname", txtUsernameAccount.Text.Trim())
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim())
                    cmd.Parameters.AddWithValue("@lastmod", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Password account berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Gagal update password account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvAccounts.SelectedRows.Count > 0 AndAlso
       MessageBox.Show("Hapus password account ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DeletePassword()
            SetupInitialState()
            LoadData()
        End If
    End Sub

    Private Sub DeletePassword()
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Dim query As String = "DELETE FROM accountpassword WHERE EmployeeID=@eid AND URLAccount=@url"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@eid", txtEmployeeID.Text.Trim())
                    cmd.Parameters.AddWithValue("@url", txtURLAccount.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Password account berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Gagal menghapus password account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        ClearFields()
    End Sub

    Private Sub dgvAccounts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvAccounts.SelectionChanged
        If dgvAccounts.SelectedRows.Count > 0 Then
            With dgvAccounts.SelectedRows(0)
                txtEmployeeID.Text = .Cells(0).Value.ToString()
                txtURLAccount.Text = .Cells(2).Value.ToString()
                txtUsernameAccount.Text = .Cells(3).Value.ToString()
                txtPassword.Text = .Cells(4).Value.ToString()
            End With
            btnEdit.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBackToDashboard.Click
        Dashboard.Show()
        Me.Hide()
    End Sub

End Class