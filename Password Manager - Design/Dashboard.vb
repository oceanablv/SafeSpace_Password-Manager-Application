Imports System.Data
Imports System.Xml
Imports System.Xml.Linq
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient

Public Class Dashboard
    Private Const ConnStr As String = "server=localhost;user id=safespace;password=safespace123;database=employee_db"
    Private ReadOnly logsXmlPath As String = "activity_logs.xml"

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "SafeSpace - Dashboard"
        Me.CenterToScreen()
        EnsureXmlFilesExist()
        SetupActivityLogsGrid()
        LoadActivityLogs()
    End Sub

    Private Sub EnsureXmlFilesExist()
        If Not System.IO.File.Exists(logsXmlPath) Then
            Dim doc As New XDocument(
                New XDeclaration("1.0", "utf-8", "yes"),
                New XElement("ActivityLogs")
            )
            doc.Save(logsXmlPath)
        End If
    End Sub

    Private Sub SetupActivityLogsGrid()
        With dgvActivityLogs
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()
            .Columns.Add("Timestamp", "Timestamp")
            .Columns.Add("UserID", "User ID")
            .Columns.Add("Activity", "Aktivitas")
            .Columns.Add("Details", "Detail")
        End With
    End Sub

    Private Sub LoadActivityLogs()
        Try
            Dim doc As XDocument = XDocument.Load(logsXmlPath)
            dgvActivityLogs.Rows.Clear()

            Dim logs = From log In doc.Root.Elements("Log")
                       Order By DateTime.Parse(log.Element("Timestamp").Value) Descending
                       Select log

            For Each log In logs
                dgvActivityLogs.Rows.Add(
                    log.Element("Timestamp").Value,
                    log.Element("UserID").Value,
                    log.Element("Activity").Value,
                    If(log.Element("Details")?.Value, "")
                )
            Next
        Catch ex As Exception
            MessageBox.Show("Gagal memuat log aktivitas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Sub LogActivity(userID As String, activity As String, Optional details As String = "")
        Try
            Dim doc As XDocument = XDocument.Load("activity_logs.xml")
            doc.Root.Add(New XElement("Log",
                New XElement("Timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                New XElement("UserID", userID),
                New XElement("Activity", activity),
                New XElement("Details", details)
            ))
            doc.Save("activity_logs.xml")
        Catch ex As Exception
            MessageBox.Show("Gagal mencatat aktivitas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportToExcel()
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            excelApp = New Excel.Application()
            workbook = excelApp.Workbooks.Add()
            conn = New MySqlConnection(ConnStr)
            conn.Open()

            ' --- Employees Sheet ---
            Dim employeeSheet As Excel.Worksheet = workbook.Sheets(1)
            employeeSheet.Name = "Employees"
            ExportEmployees(employeeSheet, conn)

            ' --- All Credentials Sheet ---
            Dim credSheet As Excel.Worksheet = workbook.Sheets.Add(After:=employeeSheet)
            credSheet.Name = "All Credentials"
            ExportAllCredentials(credSheet, conn)

            ' --- Admin Accounts Sheet ---
            Dim adminSheet As Excel.Worksheet = workbook.Sheets.Add(After:=credSheet)
            adminSheet.Name = "Admin Accounts"
            ExportAdminAccounts(adminSheet, conn)

            ' Save File
            Dim saveDialog As New SaveFileDialog With {
                .Filter = "Excel Files (*.xlsx)|*.xlsx",
                .DefaultExt = "xlsx",
                .FileName = $"SafeSpace_Export_{DateTime.Now:yyyyMMdd_HHmmss}"
            }

            If saveDialog.ShowDialog() = DialogResult.OK Then
                workbook.SaveAs(saveDialog.FileName)
                MessageBox.Show("Data berhasil diekspor ke Excel!", "Export Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LogActivity(login.LoggedInUserID, "Export Data", $"Data berhasil diekspor ke {saveDialog.FileName}")
            End If

        Catch ex As Exception
            MessageBox.Show($"Gagal ekspor ke Excel: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogActivity(login.LoggedInUserID, "Export Error", ex.Message)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            If workbook IsNot Nothing Then
                workbook.Close(False)
                Marshal.ReleaseComObject(workbook)
            End If
            If excelApp IsNot Nothing Then
                excelApp.Quit()
                Marshal.ReleaseComObject(excelApp)
            End If
            Me.Cursor = Cursors.Default
            Me.Enabled = True
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    Private Sub ExportEmployees(sheet As Excel.Worksheet, conn As MySqlConnection)
        Dim headers() As String = {"Employee ID", "Name", "Division", "Phone", "Email", "Role"}
        FormatHeaders(sheet, headers)

        Dim row As Integer = 2
        Dim query As String = "SELECT ID, Name, Division, Phone, Email, Role FROM employee ORDER BY ID"
        Using cmd As New MySqlCommand(query, conn)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    sheet.Cells(row, 1) = reader("ID").ToString()
                    sheet.Cells(row, 2) = reader("Name").ToString()
                    sheet.Cells(row, 3) = reader("Division").ToString()
                    sheet.Cells(row, 4) = reader("Phone").ToString()
                    sheet.Cells(row, 5) = reader("Email").ToString()
                    sheet.Cells(row, 6) = reader("Role").ToString()
                    row += 1
                End While
            End Using
        End Using
        FormatSheet(sheet, row - 1, headers.Length)
    End Sub

    Private Sub ExportAllCredentials(sheet As Excel.Worksheet, conn As MySqlConnection)
        Dim headers() As String = {"ID", "URL Account", "Username", "Password", "Role Type", "Storage Type"}
        FormatHeaders(sheet, headers)

        Dim row As Integer = 2

        ' Get User Credentials from Database
        Dim userQuery As String = "SELECT UserID as ID, URLAccount, UsernameAccount, Password, 'User' as RoleType FROM appuser ORDER BY UserID"
        Using cmd As New MySqlCommand(userQuery, conn)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    AddCredentialRow(sheet, row, reader, "Database", "User")
                    row += 1
                End While
            End Using
        End Using

        ' Get Admin Credentials from accountpassword table
        Dim adminQuery As String = "
        SELECT 
            EmployeeID as ID, 
            URLAccount, 
            UsernameAccount, 
            Password, 
            'Admin' as RoleType 
        FROM accountpassword 
        ORDER BY EmployeeID"

        Using cmd As New MySqlCommand(adminQuery, conn)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    AddCredentialRow(sheet, row, reader, "Database", "Admin")
                    row += 1
                End While
            End Using
        End Using

        ' Format sheet
        FormatSheet(sheet, row - 1, headers.Length)

        ' Color code based on role
        For i As Integer = 2 To row - 1
            If sheet.Cells(i, 5).Text = "Admin" Then
                sheet.Range(sheet.Cells(i, 1), sheet.Cells(i, 6)).Interior.Color = RGB(255, 200, 200)
            Else
                sheet.Range(sheet.Cells(i, 1), sheet.Cells(i, 6)).Interior.Color = RGB(200, 255, 200)
            End If
        Next
    End Sub
    Private Sub AddCredentialRow(sheet As Excel.Worksheet, row As Integer, reader As MySqlDataReader, storageType As String, roleType As String)
        sheet.Cells(row, 1) = reader("ID").ToString()
        sheet.Cells(row, 2) = If(reader("URLAccount") IsNot DBNull.Value, reader("URLAccount").ToString(), "")
        sheet.Cells(row, 3) = If(reader("UsernameAccount") IsNot DBNull.Value, reader("UsernameAccount").ToString(), "")
        sheet.Cells(row, 4) = If(reader("Password") IsNot DBNull.Value, reader("Password").ToString(), "")
        sheet.Cells(row, 5) = roleType
        sheet.Cells(row, 6) = storageType
    End Sub

    Private Sub ExportAdminAccounts(sheet As Excel.Worksheet, conn As MySqlConnection)
        Dim headers() As String = {"Admin ID", "Username Admin", "Password Admin"}
        FormatHeaders(sheet, headers)

        Dim row As Integer = 2
        Dim query As String = "SELECT AdminID, UsernameAdmin, PasswordAdmin FROM admin ORDER BY AdminID"
        Using cmd As New MySqlCommand(query, conn)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    sheet.Cells(row, 1) = reader("AdminID").ToString()
                    sheet.Cells(row, 2) = reader("UsernameAdmin").ToString()
                    sheet.Cells(row, 3) = reader("PasswordAdmin").ToString()
                    row += 1
                End While
            End Using
        End Using
        FormatSheet(sheet, row - 1, headers.Length)
    End Sub

    Private Sub FormatHeaders(sheet As Excel.Worksheet, headers() As String)
        For i As Integer = 0 To headers.Length - 1
            sheet.Cells(1, i + 1) = headers(i)
            sheet.Cells(1, i + 1).Interior.Color = RGB(200, 200, 200)
            sheet.Cells(1, i + 1).Font.Bold = True
        Next
    End Sub

    Private Sub FormatSheet(sheet As Excel.Worksheet, lastRow As Integer, columnCount As Integer)
        If lastRow > 1 Then
            sheet.Range(sheet.Cells(1, 1), sheet.Cells(lastRow, columnCount)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        End If
        sheet.Columns.AutoFit()
    End Sub

    Private Sub btnCreatePassword_Click(sender As Object, e As EventArgs) Handles btnCreatePassword.Click
        LogActivity(login.LoggedInUserID, "Akses Create Password")
        Dim cpw As New CPassword(Me)
        cpw.Show()
        Me.Hide()
    End Sub

    Private Sub btnManagePassword_Click(sender As Object, e As EventArgs) Handles btnManagePassword.Click
        LogActivity(login.LoggedInUserID, "Akses Manage Password")
        MPassword.Show()
        Me.Hide()
    End Sub

    Private Sub btnManageEmployee_Click(sender As Object, e As EventArgs) Handles btnManageEmployee.Click
        LogActivity(login.LoggedInUserID, "Akses Manage Employee")
        MEmployee.Show()
        Me.Hide()
    End Sub

    Private Sub btnManageAdmin_Click(sender As Object, e As EventArgs) Handles btnManageADmin.Click
        LogActivity(login.LoggedInUserID, "Akses Manage Admin")
        MAdmin.Show()
        Me.Hide()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            LogActivity(login.LoggedInUserID, "Logout")
            Form1.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnConvertToExcel.Click
        LogActivity(login.LoggedInUserID, "Ekspor Data ke Excel")
        ExportToExcel()
    End Sub

    Private Sub Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If Not TypeOf ActiveForm Is login Then
                Application.Exit()
            End If
        End If
    End Sub
End Class
