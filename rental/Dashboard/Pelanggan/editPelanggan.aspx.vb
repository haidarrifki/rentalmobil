Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class editPelanggan
    Inherits System.Web.UI.Page

    Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
    Dim con As New MySqlConnection(koneksi)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usr") Is Nothing Then
            Response.Redirect("../../Login.aspx")
            Exit Sub
        End If

        If Not IsPostBack Then
            Try
                con.Open()

                Dim query As String = "SELECT * FROM pelanggan WHERE id_pelanggan = ?"
                Dim findAdmin = New MySqlCommand(query, con)
                Dim idAdmin = Request.Params("id")
                findAdmin.Parameters.AddWithValue("?", idAdmin)
                Dim reader As MySqlDataReader = findAdmin.ExecuteReader
                If reader.HasRows Then
                    reader.Read()
                    ktp.Text = reader.GetString(1)
                    nama.Text = reader.GetString(2)
                    email.Text = reader.GetString(3)
                    telp.Text = reader.GetString(4)
                    alamat.Text = reader.GetString(5)
                    username.Text = reader.GetString(6)
                Else
                    Response.Redirect("../Mobil.aspx")
                End If
                reader.Close()
            Catch ex As Exception
                Response.Write("Error: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            con.Open()

            Dim query As String = "UPDATE pelanggan SET no_ktp=@ktp, nama =@nama, email=@email, alamat=@alamat, no_telp=@telp, username=@username, password=@password WHERE id_pelanggan =@id"
            Dim updatePelanggan = New MySqlCommand(query, con)
            Dim idAdmin = Request.Params("id")
            password.Text = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "SHA1")
            updatePelanggan.Parameters.AddWithValue("@ktp", Me.ktp.Text)
            updatePelanggan.Parameters.AddWithValue("@nama", Me.nama.Text)
            updatePelanggan.Parameters.AddWithValue("@email", Me.email.Text)
            updatePelanggan.Parameters.AddWithValue("@alamat", Me.alamat.Text)
            updatePelanggan.Parameters.AddWithValue("@telp", Me.telp.Text)
            updatePelanggan.Parameters.AddWithValue("@username", Me.username.Text)
            updatePelanggan.Parameters.AddWithValue("@password", Me.password.Text)
            updatePelanggan.Parameters.AddWithValue("@id", idAdmin)
            Dim jmlRecord As Integer = updatePelanggan.ExecuteNonQuery
            If jmlRecord > 0 Then
                Response.Redirect("../User.aspx")
            Else
                Response.Write("Gagal Update Data")
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class