Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Xml

Public Class DbUser
    ' String koneksi ke database MySQL
    Private Const ConnStr As String = "server=localhost;user id=safespace;password=safespace123;database=employee_db"

    ' Struktur untuk mencatat log aktivitas login user
    Private Structure LoginLog
        Public UserID As String
        Public Action As String
        Public Details As String
        Public Timestamp As DateTime
        Public Success As Boolean
    End Structure

    ' List untuk menyimpan riwayat log login user
    Private loginLogs As New List(Of LoginLog)

    ' Event saat form dimuat
    Private Sub DbUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "SafeSpace - User Dashboard"
        Me.CenterToScreen()
        SetupLoginColumns()
        LogLoginActivity("Login", "User mengakses dashboard", True)
        DisplayLoginHistory()
    End Sub

    ' Fungsi untuk mencatat aktivitas login ke list log
    Private Sub LogLoginActivity(action As String, details As String, success As Boolean)
        loginLogs.Add(New LoginLog With {
            .UserID = login.LoggedInUserID,
            .Action = action,
            .Details = details,
            .Timestamp = DateTime.Now,
            .Success = success
        })
        DisplayLoginHistory()
    End Sub

    Private Sub SetupLoginColumns()
        With dgvAccountsUser
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()
            .Columns.Add("Timestamp", "Waktu")
            .Columns.Add("UserID", "User ID")
            .Columns.Add("Action", "Jenis Aktivitas")
            .Columns.Add("Details", "Detail")
            .Columns.Add("Success", "Status")

            .Columns("Timestamp").Width = 150
            .Columns("UserID").Width = 100
            .Columns("Action").Width = 120
            .Columns("Details").Width = 250
            .Columns("Success").Width = 80
        End With
    End Sub

    Private Sub DisplayLoginHistory()
        dgvAccountsUser.Rows.Clear()
        For Each log In loginLogs
            dgvAccountsUser.Rows.Add(
                log.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"),
                log.UserID,
                log.Action,
                log.Details,
                If(log.Success, "Success", "Failed")
            )
        Next

        For Each row As DataGridViewRow In dgvAccountsUser.Rows
            Dim status As String = row.Cells("Success").Value.ToString()
            If status = "Failed" Then
                row.Cells("Success").Style.ForeColor = Color.Red
            ElseIf status = "Success" Then
                row.Cells("Success").Style.ForeColor = Color.Green
            End If
        Next

        If dgvAccountsUser.Rows.Count > 0 Then
            dgvAccountsUser.FirstDisplayedScrollingRowIndex = dgvAccountsUser.Rows.Count - 1
            dgvAccountsUser.Rows(dgvAccountsUser.Rows.Count - 1).Selected = True
        End If
    End Sub

    Private Sub btnCreatePassword_Click(sender As Object, e As EventArgs) Handles btnCreatePassword.Click
        Try
            LogLoginActivity("Navigasi", "Akses form Create Password", True)
            Dim cpw As New CPassword(Me)
            cpw.Show()
            Me.Hide()
        Catch ex As Exception
            LogLoginActivity("Error", "Gagal akses Create Password: " & ex.Message, False)
            MessageBox.Show("Gagal akses Create Password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnManagePassword_Click(sender As Object, e As EventArgs) Handles btnManagePassword.Click
        Try
            LogLoginActivity("Navigasi", "Akses form Manage Password", True)
            MPassUser.Show()
            Me.Hide()
        Catch ex As Exception
            LogLoginActivity("Error", "Gagal akses Manage Password: " & ex.Message, False)
            MessageBox.Show("Gagal akses Manage Password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConvertToExcel_Click(sender As Object, e As EventArgs) Handles btnConvertToExcel.Click
        Try
            LogLoginActivity("Export", "Mulai export data ke Excel", True)
            ExportToExcel()
        Catch ex As Exception
            LogLoginActivity("Export", "Gagal export data: " & ex.Message, False)
            MessageBox.Show("Gagal export ke Excel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportToExcel()
        Dim excelApp As Microsoft.Office.Interop.Excel.Application = Nothing
        Dim workbook As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim loginSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
        Dim credSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            excelApp = New Microsoft.Office.Interop.Excel.Application()
            workbook = excelApp.Workbooks.Add()

            ' Export Login History
            loginSheet = workbook.Sheets(1)
            loginSheet.Name = "Login History"
            ExportLoginHistory(loginSheet)

            ' Export Credentials
            credSheet = workbook.Sheets.Add(After:=loginSheet)
            credSheet.Name = "Credentials"
            ExportCredentials(credSheet)

            ' Save dialog
            Dim saveDialog As New SaveFileDialog With {
                .Filter = "Excel Files (*.xlsx)|*.xlsx",
                .DefaultExt = "xlsx",
                .FileName = $"SafeSpace_Export_{login.LoggedInUserID}_{DateTime.Now:yyyyMMdd_HHmmss}"
            }

            If saveDialog.ShowDialog() = DialogResult.OK Then
                workbook.SaveAs(saveDialog.FileName)
                MessageBox.Show("Data berhasil diexport!", "Export Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Throw
        Finally
            If workbook IsNot Nothing Then
                workbook.Close(False)
                Runtime.InteropServices.Marshal.ReleaseComObject(workbook)
            End If
            If excelApp IsNot Nothing Then
                excelApp.Quit()
                Runtime.InteropServices.Marshal.ReleaseComObject(excelApp)
            End If
            If loginSheet IsNot Nothing Then
                Runtime.InteropServices.Marshal.ReleaseComObject(loginSheet)
            End If
            If credSheet IsNot Nothing Then
                Runtime.InteropServices.Marshal.ReleaseComObject(credSheet)
            End If

            Me.Cursor = Cursors.Default
            Me.Enabled = True
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    Private Sub ExportLoginHistory(sheet As Microsoft.Office.Interop.Excel.Worksheet)
        ' Login History Headers
        Dim loginHeaders() As String = {"Waktu", "User ID", "Jenis Aktivitas", "Detail", "Status"}

        For i As Integer = 0 To loginHeaders.Length - 1
            sheet.Cells(1, i + 1) = loginHeaders(i)
        Next

        ' Format Login History Headers
        sheet.Range("A1:E1").Font.Bold = True
        sheet.Range("A1:E1").Interior.Color = RGB(200, 200, 200)

        ' Export Login History Data
        Dim row As Integer = 2
        For Each dgvRow As DataGridViewRow In dgvAccountsUser.Rows
            sheet.Cells(row, 1) = dgvRow.Cells("Timestamp").Value.ToString()
            sheet.Cells(row, 2) = dgvRow.Cells("UserID").Value.ToString()
            sheet.Cells(row, 3) = dgvRow.Cells("Action").Value.ToString()
            sheet.Cells(row, 4) = dgvRow.Cells("Details").Value.ToString()
            sheet.Cells(row, 5) = dgvRow.Cells("Success").Value.ToString()
            row += 1
        Next

        sheet.Columns.AutoFit()
        If row > 2 Then
            sheet.Range($"A1:E{row - 1}").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        End If
    End Sub

    Private Sub ExportCredentials(sheet As Microsoft.Office.Interop.Excel.Worksheet)
        ' Credentials Headers
        Dim credHeaders() As String = {"User ID", "Storage Type", "URL Account", "Username Account", "Password", "User Role"}

        For i As Integer = 0 To credHeaders.Length - 1
            sheet.Cells(1, i + 1) = credHeaders(i)
        Next

        ' Format Credentials Headers
        sheet.Range("A1:F1").Font.Bold = True
        sheet.Range("A1:F1").Interior.Color = RGB(200, 200, 200)

        Dim row As Integer = 2

        ' Get MySQL Credentials
        Using conn As New MySqlConnection(ConnStr)
            Try
                conn.Open()
                Dim query As String = "SELECT UserID, URLAccount, UsernameAccount, Password, UserRole 
                                     FROM appuser 
                                     WHERE UserID = @userid"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", login.LoggedInUserID)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            sheet.Cells(row, 1) = reader("UserID").ToString()
                            sheet.Cells(row, 2) = "Database"
                            sheet.Cells(row, 3) = If(reader("URLAccount") IsNot DBNull.Value, reader("URLAccount").ToString(), "")
                            sheet.Cells(row, 4) = If(reader("UsernameAccount") IsNot DBNull.Value, reader("UsernameAccount").ToString(), "")
                            sheet.Cells(row, 5) = If(reader("Password") IsNot DBNull.Value, reader("Password").ToString(), "")
                            sheet.Cells(row, 6) = If(reader("UserRole") IsNot DBNull.Value, reader("UserRole").ToString(), "")
                            row += 1
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading MySQL data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        ' Get XML Credentials
        Dim xmlFilePath As String = "user_credentials.xml"
        If System.IO.File.Exists(xmlFilePath) Then
            Try
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(xmlFilePath)
                Dim credentials As XmlNodeList = xmlDoc.SelectNodes($"//Credential[@UserID='{login.LoggedInUserID}']")

                For Each cred As XmlNode In credentials
                    sheet.Cells(row, 1) = login.LoggedInUserID
                    sheet.Cells(row, 2) = "XML"
                    sheet.Cells(row, 3) = cred.SelectSingleNode("URLAccount")?.InnerText
                    sheet.Cells(row, 4) = cred.SelectSingleNode("UsernameAccount")?.InnerText
                    sheet.Cells(row, 5) = cred.SelectSingleNode("Password")?.InnerText
                    sheet.Cells(row, 6) = "User"
                    row += 1
                Next
            Catch ex As Exception
                MessageBox.Show("Error loading XML data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        sheet.Columns.AutoFit()
        If row > 2 Then
            sheet.Range($"A1:F{row - 1}").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            LogLoginActivity("Logout", "User logout", True)
            System.Threading.Thread.Sleep(1000)
            Form1.Show()
            Me.Close()
        End If
    End Sub

    Private Sub DbUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If Not TypeOf ActiveForm Is login Then
                LogLoginActivity("Exit", "Aplikasi ditutup", True)
                System.Threading.Thread.Sleep(1000)
                Application.Exit()
            End If
        End If
    End Sub
End Class
