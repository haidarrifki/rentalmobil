Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class Konfirmasi
    Inherits System.Web.UI.Page

    Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
    Dim con As New MySqlConnection(koneksi)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usr") Is Nothing Then
            Response.Redirect("../LoginPelanggan.aspx")
            Exit Sub
        End If
    End Sub

    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        con.Open()

        Try
            Dim idTransaksi As Integer = Request.Params("id")
            Dim saveKonfirmasi = New MySqlCommand("INSERT INTO konfirmasi(id_transaksi, bukti) VALUES (@id_transaksi, @bukti)", con)
            saveKonfirmasi.Parameters.AddWithValue("@id_transaksi", idTransaksi)
            saveKonfirmasi.Parameters.AddWithValue("@bukti", kode.Text)
            saveKonfirmasi.ExecuteNonQuery()

            Dim updateKonfirmasi = New MySqlCommand("UPDATE transaksi SET konfirmasi='1' WHERE id_transaksi = ?", con)
            updateKonfirmasi.Parameters.AddWithValue("?", idTransaksi)
            updateKonfirmasi.ExecuteNonQuery()

            Response.Redirect("../Riwayat.aspx")
        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class