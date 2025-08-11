Public Class CPassword
    Private ReadOnly _parentForm As Form
    Private ReadOnly _random As New Random()

    ' Constructor that accepts the parent form
    Public Sub New(parent As Form)
        InitializeComponent()
        _parentForm = parent
    End Sub

    ' Designer requires a parameterless constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Inisialisasi form dan pengaturan default
    Private Sub CPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudLength.Minimum = 6
        nudLength.Maximum = 20
        nudLength.Value = 8

        cbUppercase.Checked = True
        cbLowercase.Checked = True
        cbDigits.Checked = True
        cbSymbols.Checked = False
    End Sub

    ' Handler tombol Generate Password
    Private Sub btnGeneratePassword_Click(sender As Object, e As EventArgs) Handles btnGeneratePassword.Click
        If Not (cbUppercase.Checked Or cbDigits.Checked Or cbLowercase.Checked Or cbSymbols.Checked) Then
            MessageBox.Show("Please select at least one character type!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        txtPassword.Text = GeneratePassword()
        UpdatePasswordStrength()
    End Sub

    ' Handler tombol Copy ke Clipboard
    Private Sub btnSaveToClipboard_Click(sender As Object, e As EventArgs) Handles btnSaveToClipboard.Click
        If String.IsNullOrEmpty(txtPassword.Text) Then
            MessageBox.Show("Please generate a password first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Clipboard.SetText(txtPassword.Text)
        MessageBox.Show("Password copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Kembali ke parent dashboard/user form
    Private Sub btnBackToDashboard_Click(sender As Object, e As EventArgs) Handles btnBackToDashboard.Click
        If _parentForm IsNot Nothing Then
            _parentForm.Show()
        End If
        Me.Close()
    End Sub

    ' Pastikan kembali ke parent form jika user menutup form dengan X
    Private Sub CPassword_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If _parentForm IsNot Nothing AndAlso Not _parentForm.Visible Then
            _parentForm.Show()
        End If
    End Sub

    ' Fungsi generate password berdasarkan kriteria terpilih

    ' CPassword.vb
    Private Function GeneratePassword() As String
        Dim chars As New List(Of Char)
        Dim password As New System.Text.StringBuilder()

        If cbUppercase.Checked Then chars.AddRange("ABCDEFGHIJKLMNOPQRSTUVWXYZ")
        If cbLowercase.Checked Then chars.AddRange("abcdefghijklmnopqrstuvwxyz")
        If cbDigits.Checked Then chars.AddRange("0123456789")
        If cbSymbols.Checked Then chars.AddRange("!@#$%^&*()_+-=[]{}|;:,.<>?")

        For i As Integer = 1 To CInt(nudLength.Value)
            password.Append(chars(_random.Next(0, chars.Count)))
        Next

        Return password.ToString()
    End Function

    ' Evaluasi dan update indikator kekuatan password
    Private Sub UpdatePasswordStrength()
        Dim strength As Integer = 0
        Dim password As String = txtPassword.Text

        If password.Length >= 8 Then strength += 1
        If password.Length >= 12 Then strength += 1
        If password.Any(Function(c) Char.IsUpper(c)) Then strength += 1
        If password.Any(Function(c) Char.IsLower(c)) Then strength += 1
        If password.Any(Function(c) Char.IsDigit(c)) Then strength += 1
        If password.Any(Function(c) Not Char.IsLetterOrDigit(c)) Then strength += 1

        Select Case strength
            Case 0 To 2
                lblStrength.Text = "Weak"
                lblStrength.ForeColor = Color.Red
            Case 3 To 4
                lblStrength.Text = "Moderate"
                lblStrength.ForeColor = Color.Orange
            Case 5 To 6
                lblStrength.Text = "Strong"
                lblStrength.ForeColor = Color.Green
        End Select
    End Sub

    ' Handler perubahan teks password
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If Not String.IsNullOrEmpty(txtPassword.Text) Then
            UpdatePasswordStrength()
        Else
            lblStrength.Text = "..."
            lblStrength.ForeColor = Color.Black
        End If
    End Sub
End Class