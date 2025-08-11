Imports System.Xml
Imports MySql.Data.MySqlClient

Public Class MPassUser
    Private Const XML_FILE_PATH As String = "user_credentials.xml"
    Private xmlDoc As XmlDocument
    Private Const ConnStr As String = "server=localhost;user id=safespace;password=safespace123;database=employee_db"
    Private isEditing As Boolean = False

    ' Initialize XML storage
    Private Sub InitializeXmlStorage()
        xmlDoc = New XmlDocument()
        Try
            If Not System.IO.File.Exists(XML_FILE_PATH) Then
                ' Create new XML structure if file doesn't exist
                xmlDoc.LoadXml("<Credentials></Credentials>")
                xmlDoc.Save(XML_FILE_PATH)
            Else
                xmlDoc.Load(XML_FILE_PATH)
            End If
        Catch ex As Exception
            MessageBox.Show("Error initializing XML storage: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MPassUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Manage My Login"
        Me.CenterToScreen()
        InitializeXmlStorage()    ' Initialize XML storage
        SetupDataGrid()           ' Setup DataGridView
        LoadUserDataGrid()        ' Load data from both sources
        SetupInitialState()       ' Set initial form state

        ' Set logged in user ID
        txt_us_EmployeeID.Text = login.LoggedInUserID
    End Sub

    Private Sub SetupDataGrid()
        With dgvAccounts
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()
            .Columns.Add("UserID", "User ID")
            .Columns.Add("UserRole", "Role")
            .Columns.Add("URLAccount", "URL Account")
            .Columns.Add("EmployeeName", "Employee Name")
            .Columns.Add("UsernameAccount", "Account Username")
            .Columns.Add("Password", "Password")
            .Columns.Add("StorageType", "Storage Type") ' Added to show where credential is stored
        End With
    End Sub

    Private Sub LoadUserDataGrid()
        dgvAccounts.Rows.Clear()
        Application.DoEvents()

        ' Load MySQL data
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                ' Form: MPassUser
                ' Query untuk mengambil data user dari MySQL
                Dim query As String = "SELECT a.UserID, a.UserRole, a.URLAccount, e.Name as EmployeeName, 
                                     a.UsernameAccount, a.Password 
                                     FROM appuser a
                                     LEFT JOIN employee e ON a.UserID = e.ID
                                     WHERE a.UserID=@userid 
                                     ORDER BY a.URLAccount"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", login.LoggedInUserID)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            dgvAccounts.Rows.Add(
                                reader("UserID").ToString(),
                                reader("UserRole").ToString(),
                                If(reader("URLAccount") IsNot DBNull.Value, reader("URLAccount").ToString(), ""),
                                If(reader("EmployeeName") IsNot DBNull.Value, reader("EmployeeName").ToString(), ""),
                                If(reader("UsernameAccount") IsNot DBNull.Value, reader("UsernameAccount").ToString(), ""),
                                If(reader("Password") IsNot DBNull.Value, reader("Password").ToString(), ""),
                                "Database"
                            )
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Gagal memuat data MySQL: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        ' Load XML data
        Try
            If xmlDoc IsNot Nothing Then
                Dim credentials As XmlNodeList = xmlDoc.SelectNodes($"//Credential[@UserID='{login.LoggedInUserID}']")
                For Each cred As XmlNode In credentials
                    dgvAccounts.Rows.Add(
                        login.LoggedInUserID,
                        "User",
                        cred.SelectSingleNode("URLAccount")?.InnerText,
                        login.LoggedInUserName,
                        cred.SelectSingleNode("UsernameAccount")?.InnerText,
                        cred.SelectSingleNode("Password")?.InnerText,
                        "XML"
                    )
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data XML: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dgvAccounts.Refresh()
    End Sub

    Private Function AddUser() As Boolean
        If txt_us_URLAccount.Text.Contains("safespace") Then
            Return AddUserToMySQL()
        Else
            Return AddUserToXML()
        End If
    End Function

    Private Function AddUserToMySQL() As Boolean
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Dim query As String = "INSERT INTO appuser (UserID, UserRole, URLAccount, UsernameAccount, Password) 
                                     VALUES (@userid, @role, @urlaccount, @usernameaccount, @password)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", login.LoggedInUserID)
                    cmd.Parameters.AddWithValue("@role", login.LoggedInUserRole)
                    cmd.Parameters.AddWithValue("@urlaccount", txt_us_URLAccount.Text.Trim())
                    cmd.Parameters.AddWithValue("@usernameaccount", txt_us_UsernameAccount.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", txt_us_Password.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Password credential berhasil ditambahkan ke database!", "Sukses",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Catch ex As MySqlException
                If ex.Number = 1062 Then ' Duplicate entry
                    MessageBox.Show("Credential untuk URL ini sudah ada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Error MySQL: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Return False
            End Try
        End Using
    End Function

    Private Function AddUserToXML() As Boolean
        Try
            ' Check for duplicate URL
            Dim existingCred As XmlNode = xmlDoc.SelectSingleNode(
                $"//Credential[@UserID='{login.LoggedInUserID}']/URLAccount[text()='{txt_us_URLAccount.Text.Trim()}']")

            If existingCred IsNot Nothing Then
                MessageBox.Show("Credential untuk URL ini sudah ada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            ' Create new credential node
            Dim newCred As XmlElement = xmlDoc.CreateElement("Credential")
            newCred.SetAttribute("UserID", login.LoggedInUserID)

            ' Add child elements
            Dim urlElem As XmlElement = xmlDoc.CreateElement("URLAccount")
            urlElem.InnerText = txt_us_URLAccount.Text.Trim()
            newCred.AppendChild(urlElem)

            Dim userElem As XmlElement = xmlDoc.CreateElement("UsernameAccount")
            userElem.InnerText = txt_us_UsernameAccount.Text.Trim()
            newCred.AppendChild(userElem)

            Dim passElem As XmlElement = xmlDoc.CreateElement("Password")
            passElem.InnerText = txt_us_Password.Text.Trim()
            newCred.AppendChild(passElem)

            ' Add to document and save
            xmlDoc.DocumentElement.AppendChild(newCred)
            xmlDoc.Save(XML_FILE_PATH)

            MessageBox.Show("Password credential berhasil ditambahkan ke XML!", "Sukses",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Catch ex As Exception
            MessageBox.Show("Error XML: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
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
                If AddUser() Then
                    btnAdd.Text = "Add"
                    SetFieldsEnabled(False)
                    LoadUserDataGrid()
                    SetupInitialState()
                End If
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvAccounts.SelectedRows.Count > 0 Then
            SetFieldsEnabled(True)
            btnUpdate.Enabled = True
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            isEditing = True
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If ValidateInput() Then
            Dim storageType As String = dgvAccounts.SelectedRows(0).Cells("StorageType").Value.ToString()
            Dim success As Boolean = False

            If storageType = "Database" Then
                success = UpdateUserInMySQL()
            Else
                success = UpdateUserInXML()
            End If

            If success Then
                isEditing = False
                SetupInitialState()
                LoadUserDataGrid()
            End If
        End If
    End Sub
    'Form: MPassUser
    'Kode untuk mengupdate credential user di MySQL
    Private Function UpdateUserInMySQL() As Boolean
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Dim query As String = "UPDATE appuser 
                                 SET UsernameAccount=@usernameaccount, 
                                     Password=@password 
                                 WHERE UserID=@userid 
                                 AND URLAccount=@urlaccount"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", login.LoggedInUserID)
                    cmd.Parameters.AddWithValue("@urlaccount", txt_us_URLAccount.Text.Trim())
                    cmd.Parameters.AddWithValue("@usernameaccount", txt_us_UsernameAccount.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", txt_us_Password.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Password credential berhasil diupdate di database!", "Sukses",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Catch ex As Exception
                MessageBox.Show("Gagal update credential di database: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Private Function UpdateUserInXML() As Boolean
        Try
            ' Find the credential to update
            Dim credential As XmlNode = xmlDoc.SelectSingleNode(
            $"//Credential[@UserID='{login.LoggedInUserID}']/URLAccount[text()='{txt_us_URLAccount.Text.Trim()}']/..")

            If credential IsNot Nothing Then
                ' Update username and password
                credential.SelectSingleNode("UsernameAccount").InnerText = txt_us_UsernameAccount.Text.Trim()
                credential.SelectSingleNode("Password").InnerText = txt_us_Password.Text.Trim()

                ' Save changes
                xmlDoc.Save(XML_FILE_PATH)
                MessageBox.Show("Password credential berhasil diupdate di XML!", "Sukses",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                MessageBox.Show("Credential tidak ditemukan di XML!", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal update credential di XML: " & ex.Message, "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvAccounts.SelectedRows.Count > 0 Then
            If MessageBox.Show("Apakah Anda yakin ingin menghapus credential ini?",
                          "Konfirmasi Hapus",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim storageType As String = dgvAccounts.SelectedRows(0).Cells("StorageType").Value.ToString()
                Dim success As Boolean = False

                If storageType = "Database" Then
                    success = DeleteUserFromMySQL()
                Else
                    success = DeleteUserFromXML()
                End If

                If success Then
                    SetupInitialState()
                    LoadUserDataGrid()
                End If
            End If
        End If
    End Sub

    Private Function DeleteUserFromMySQL() As Boolean
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Dim query As String = "DELETE FROM appuser 
                                 WHERE UserID=@userid 
                                 AND URLAccount=@urlaccount"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", login.LoggedInUserID)
                    cmd.Parameters.AddWithValue("@urlaccount", txt_us_URLAccount.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Password credential berhasil dihapus dari database!", "Sukses",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Catch ex As Exception
                MessageBox.Show("Gagal menghapus credential dari database: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Private Function DeleteUserFromXML() As Boolean
        Try
            ' Find the credential to delete
            Dim credential As XmlNode = xmlDoc.SelectSingleNode(
            $"//Credential[@UserID='{login.LoggedInUserID}']/URLAccount[text()='{txt_us_URLAccount.Text.Trim()}']/..")

            If credential IsNot Nothing Then
                ' Remove the credential node
                credential.ParentNode.RemoveChild(credential)

                ' Save changes
                xmlDoc.Save(XML_FILE_PATH)
                MessageBox.Show("Password credential berhasil dihapus dari XML!", "Sukses",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                MessageBox.Show("Credential tidak ditemukan di XML!", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus credential dari XML: " & ex.Message, "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


    Private Sub SetFieldsEnabled(enabled As Boolean)
        txt_us_EmployeeID.Enabled = False
        txt_us_URLAccount.Enabled = enabled
        txt_us_UsernameAccount.Enabled = enabled
        txt_us_Password.Enabled = enabled
    End Sub

    Private Sub ClearFields()
        txt_us_URLAccount.Clear()
        txt_us_UsernameAccount.Clear()
        txt_us_Password.Clear()
    End Sub

    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txt_us_URLAccount.Text) OrElse
           String.IsNullOrWhiteSpace(txt_us_UsernameAccount.Text) OrElse
           String.IsNullOrWhiteSpace(txt_us_Password.Text) Then
            MessageBox.Show("URL Account, Username, dan Password wajib diisi.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub SetupInitialState()
        SetFieldsEnabled(False)
        btnUpdate.Enabled = False
        btnAdd.Text = "Add"
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        ClearFields()
    End Sub

    Private Sub btnBackToDashboard_Click(sender As Object, e As EventArgs) Handles btnBackToDashboard.Click
        DbUser.Show()
        Me.Hide()
    End Sub

    Private Sub dgvAccounts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvAccounts.SelectionChanged
        If dgvAccounts.SelectedRows.Count > 0 Then
            LoadSelectedUserToFields()
            btnEdit.Enabled = True
            btnDelete.Enabled = True
        Else
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub

    Private Sub LoadSelectedUserToFields()
        If dgvAccounts.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = dgvAccounts.SelectedRows(0)
            txt_us_EmployeeID.Text = row.Cells("UserID").Value.ToString()
            txt_us_URLAccount.Text = row.Cells("URLAccount").Value.ToString()
            txt_us_UsernameAccount.Text = row.Cells("UsernameAccount").Value.ToString()
            txt_us_Password.Text = row.Cells("Password").Value.ToString()
        End If
    End Sub
End Class
