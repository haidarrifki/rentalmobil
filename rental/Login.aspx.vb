Imports System.Configuration
Imports MySql.Data.MySqlClient
Partial Class Login
    Inherits System.Web.UI.Page
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
        Dim con As New MySqlConnection(koneksi)
        Try
            con.Open()
            password.Text = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "SHA1")
            Dim cmd As New MySqlCommand("SELECT * FROM admin WHERE username='" & username.Text & "' AND password = '" & password.Text & "'", con)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            reader.Read()

            If reader.HasRows Then
                Dim usr As User = New User()

                usr.SetId(reader.GetString(0))
                usr.SetUsername(username.Text)
                usr.SetPassword(password.Text)
                usr.SetNama(username.Text)

                Session("usr") = usr

                Response.Redirect("Dashboard/Mobil.aspx")
            Else
                username.Text = ""
                password.Text = ""
                pesan.Text = "<div class='alert alert-danger center-block text-center'>Username atau password salah</div>"
            End If
        Catch ex As Exception
            pesan.Text = "Error: " & ex.Message
        Finally
            con.Close()
        End Try
    End Sub
End Class