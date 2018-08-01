Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class editMobil
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

                Dim query As String = "SELECT * FROM mobil WHERE id_mobil = ?"
                Dim findAdmin = New MySqlCommand(query, con)
                Dim idAdmin = Request.Params("id")
                findAdmin.Parameters.AddWithValue("?", idAdmin)
                Dim reader As MySqlDataReader = findAdmin.ExecuteReader
                If reader.HasRows Then
                    reader.Read()
                    jenis_mobil.Text = reader.GetString(1)
                    no_mobil.Text = reader.GetString(2)
                    merk.Text = reader.GetString(3)
                    nama.Text = reader.GetString(4)
                    harga.Text = reader.GetString(5)
                    status_mobil.Text = reader.GetString(6)
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

            Dim query As String = "UPDATE mobil SET jenis_mobil =@jenis_mobil, no_mobil=@no_mobil, merk=@merk, nama_mobil=@nama_mobil, harga=@harga, status=@status WHERE id_mobil =@id"
            Dim updateMobil = New MySqlCommand(query, con)
            Dim idMobil = Request.Params("id")
            updateMobil.Parameters.AddWithValue("@jenis_mobil", Me.jenis_mobil.Text)
            updateMobil.Parameters.AddWithValue("@no_mobil", Me.no_mobil.Text)
            updateMobil.Parameters.AddWithValue("@merk", Me.merk.Text)
            updateMobil.Parameters.AddWithValue("@nama_mobil", Me.nama.Text)
            updateMobil.Parameters.AddWithValue("@harga", Me.harga.Text)
            updateMobil.Parameters.AddWithValue("@status", Me.status_mobil.Text)
            updateMobil.Parameters.AddWithValue("@id", idMobil)
            Dim jmlRecord As Integer = updateMobil.ExecuteNonQuery
            If jmlRecord > 0 Then
                Response.Redirect("../Mobil.aspx")
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