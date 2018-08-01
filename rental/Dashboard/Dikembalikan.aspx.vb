Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class Dikembalikan
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usr") Is Nothing Then
            Response.Redirect("../Login.aspx")
            Exit Sub
        End If

        Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
        Dim con As New MySqlConnection(koneksi)
        con.Open()

        Dim tgl As Date = DateTime.Now
        Dim idTransaksi As Integer = Request.Params("id")
        Dim findTransaksi = New MySqlCommand("SELECT id_mobil, id_supir FROM transaksi JOIN detail_transaksi USING(id_transaksi) WHERE id_transaksi=?", con)
        findTransaksi.Parameters.AddWithValue("?", idTransaksi)
        Dim hasilTransaksi As MySqlDataReader = findTransaksi.ExecuteReader
        hasilTransaksi.Read()

        Dim updateMobil = New MySqlCommand("UPDATE mobil SET status='Tersedia' WHERE id_mobil=?", con)
        updateMobil.Parameters.AddWithValue("?", hasilTransaksi.GetString(0))
        hasilTransaksi.Close()
        updateMobil.ExecuteNonQuery()

        Dim updateTransaksi = New MySqlCommand("UPDATE transaksi SET tgl_kembali=@tgl, status='1' WHERE id_transaksi = ?", con)
        updateTransaksi.Parameters.AddWithValue("tgl", tgl)
        updateTransaksi.Parameters.AddWithValue("?", idTransaksi)
        updateTransaksi.ExecuteNonQuery()

        Response.Redirect("../Laporan.aspx")
    End Sub
End Class