Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class addMobil
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
            query = "INSERT INTO mobil (jenis_mobil, no_mobil, merk, nama_mobil, harga, status) VALUES (@jenis_mobil, @no_mobil, @merk, @nama_mobil, @harga, @status)"
            Dim saveMobil = New MySqlCommand(query, con)
            saveMobil.Parameters.AddWithValue("@jenis_mobil", Me.jenis_mobil.Text)
            saveMobil.Parameters.AddWithValue("@no_mobil", Me.no_mobil.Text)
            saveMobil.Parameters.AddWithValue("@merk", Me.merk.Text)
            saveMobil.Parameters.AddWithValue("@nama_mobil", Me.nama.Text)
            saveMobil.Parameters.AddWithValue("@harga", Me.harga.Text)
            saveMobil.Parameters.AddWithValue("@status", Me.status_mobil.Text)
            Dim jmlRecord As Integer = saveMobil.ExecuteNonQuery()
            If jmlRecord > 0 Then
                Response.Redirect("../Mobil.aspx")
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