Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class addPelanggan
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
            query = "INSERT INTO pelanggan (no_ktp, nama, email, no_telp, alamat, username, password) VALUES (@no_ktp, @nama, @email, @telp, @alamat, @username, @password)"
            Dim savePelanggan = New MySqlCommand(query, con)
            password.Text = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "SHA1")
            savePelanggan.Parameters.AddWithValue("@no_ktp", Me.ktp.Text)
            savePelanggan.Parameters.AddWithValue("@nama", Me.nama.Text)
            savePelanggan.Parameters.AddWithValue("@email", Me.email.Text)
            savePelanggan.Parameters.AddWithValue("@alamat", Me.alamat.Text)
            savePelanggan.Parameters.AddWithValue("@telp", Me.telp.Text)
            savePelanggan.Parameters.AddWithValue("@username", Me.username.Text)
            savePelanggan.Parameters.AddWithValue("@password", Me.password.Text)
            Dim jmlRecord As Integer = savePelanggan.ExecuteNonQuery()
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