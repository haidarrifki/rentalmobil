Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class addUser
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usr") Is Nothing Then
            Response.Redirect("../../Login.aspx")
            Exit Sub
        End If
    End Sub

    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
        Dim con As New MySqlConnection(koneksi)

        Try
            con.Open()
            Dim query As String
            query = "INSERT INTO admin (nama, email, alamat, telp, username, password) VALUES (@nama, @email, @alamat, @telp, @username, @password)"
            Dim saveAdmin = New MySqlCommand(query, con)
            password.Text = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "SHA1")
            saveAdmin.Parameters.AddWithValue("@nama", Me.nama.Text)
            saveAdmin.Parameters.AddWithValue("@email", Me.email.Text)
            saveAdmin.Parameters.AddWithValue("@alamat", Me.alamat.Text)
            saveAdmin.Parameters.AddWithValue("@telp", Me.telp.Text)
            saveAdmin.Parameters.AddWithValue("@username", Me.username.Text)
            saveAdmin.Parameters.AddWithValue("@password", Me.password.Text)
            Dim jmlRecord As Integer = saveAdmin.ExecuteNonQuery()
            If jmlRecord > 0 Then
                Response.Redirect("../User.aspx")
            Else
                Response.Write("Gagal Simpan Data")
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class