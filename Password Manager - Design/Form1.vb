Imports MySql.Data.MySqlClient

Public Class Form1
    Private loginAttempts(2) As LoginAttempt
    Private currentAttempt As Integer = 0
    Private ReadOnly MaxAttempts As Integer = 3

    Private Const ConnStr As String = "server=localhost;user id=safespace;password=safespace123;database=employee_db"

    Private Structure LoginAttempt
        Public Username As String
        Public Timestamp As DateTime
        Public Success As Boolean
        Public LoginType As String
    End Structure

    Public Shared LoggedInUserID As String = ""
    Public Shared LoggedInUserName As String = ""
    Public Shared LoggedInUserRole As String = ""

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        txtPassword.UseSystemPasswordChar = True
        cbShowPassword.Checked = False
        ClearInputs()
        currentAttempt = 0
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
           String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Username dan password wajib diisi!", "Kesalahan Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Not ValidateInputs() Then Return

        If currentAttempt >= MaxAttempts Then
            MessageBox.Show("Percobaan login melebihi batas maksimum. Silakan coba lagi nanti.", "Login Diblokir",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Application.Exit()
            Return
        End If

        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()

                ' LOGIN ADMIN
                Dim queryAdmin As String = "
                    SELECT 
                        a.AdminID AS UserID,
                        'Admin' AS UserRole,
                        a.UsernameAdmin AS UserName,
                        a.PasswordAdmin
                    FROM admin a
                    WHERE a.UsernameAdmin = @username 
                    AND a.PasswordAdmin = @password"

                Using cmd As New MySqlCommand(queryAdmin, conn)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            LoggedInUserID = reader("UserID").ToString()
                            LoggedInUserRole = reader("UserRole").ToString()
                            LoggedInUserName = reader("UserName").ToString()
                            HandleSuccessfulLogin("Admin")
                            Return
                        End If
                    End Using
                End Using

                ' LOGIN USER BIASA
                Dim queryUser As String = "
                    SELECT 
                        u.UserID,
                        u.UsernameAccount,
                        u.Password,
                        u.URLAccount,
                        e.Name AS UserName,
                        e.Role AS UserRole
                    FROM appuser u
                    LEFT JOIN employee e ON u.UserID = e.ID
                    WHERE u.UsernameAccount = @username
                    AND u.Password = @password
                    AND u.URLAccount = 'SafeSpace'"

                Using cmd As New MySqlCommand(queryUser, conn)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            LoggedInUserID = reader("UserID").ToString()
                            LoggedInUserRole = reader("UserRole").ToString()
                            LoggedInUserName = If(reader("UserName") IsNot DBNull.Value,
                                                  reader("UserName").ToString(),
                                                  reader("UsernameAccount").ToString())
                            HandleSuccessfulLogin("User")
                            Return
                        End If
                    End Using
                End Using

                HandleFailedLogin()

            Catch ex As Exception
                MessageBox.Show("Terjadi kesalahan saat login: " & ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                RecordLoginAttempt(txtUsername.Text.Trim(), False, "Unknown")
            End Try
        End Using
    End Sub

    Private Sub HandleSuccessfulLogin(loginType As String)
        RecordLoginAttempt(txtUsername.Text.Trim(), True, loginType)
        ClearInputs()

        If LoggedInUserRole.ToLower() = "admin" Then
            Dashboard.Show()
        Else
            DbUser.Show()
        End If

        Me.Hide()
    End Sub

    Private Sub HandleFailedLogin()
        RecordLoginAttempt(txtUsername.Text.Trim(), False, "Failed")
        Dim remainingAttempts As Integer = MaxAttempts - currentAttempt
        MessageBox.Show($"Username atau password salah. Sisa percobaan: {remainingAttempts}.",
                        "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        txtPassword.Clear()
        txtPassword.Focus()
    End Sub

    Private Sub RecordLoginAttempt(username As String, success As Boolean, loginType As String)
        If currentAttempt < loginAttempts.Length Then
            loginAttempts(currentAttempt) = New LoginAttempt With {
                .Username = username,
                .Timestamp = DateTime.Now,
                .Success = success,
                .LoginType = loginType
            }
            currentAttempt += 1
        End If
    End Sub

    Private Sub ClearInputs()
        txtUsername.Clear()
        txtPassword.Clear()
        txtUsername.Focus()
    End Sub

    Private Sub cbShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles cbShowPassword.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not cbShowPassword.Checked
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        DisplayLoginHistory()
        Application.Exit()
    End Sub

    Private Sub DisplayLoginHistory()
        If currentAttempt = 0 Then Return

        Dim history As String = "Riwayat Login:" & vbCrLf & vbCrLf

        For i As Integer = 0 To currentAttempt - 1
            history &= $"Percobaan {i + 1}:" & vbCrLf
            history &= $"Username: {loginAttempts(i).Username}" & vbCrLf
            history &= $"Waktu: {loginAttempts(i).Timestamp}" & vbCrLf
            history &= $"Tipe: {loginAttempts(i).LoginType}" & vbCrLf
            history &= $"Status: {If(loginAttempts(i).Success, "Berhasil", "Gagal")}" & vbCrLf & vbCrLf
        Next

        MessageBox.Show(history, "Riwayat Login", MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
    End Sub
End Class
