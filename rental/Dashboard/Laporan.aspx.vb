Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class Laporan
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usr") Is Nothing Then
            Response.Redirect("../Login.aspx")
            Exit Sub
        End If

        Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
        Dim con As New MySqlConnection(koneksi)

        con.Open()
        Dim selectTransaksi As New MySqlCommand("SELECT id_transaksi, nama, nama_mobil, no_mobil, tgl_sewa, tgl_ambil, tgl_kembali, lama, total_harga FROM transaksi t JOIN mobil m USING(id_mobil) JOIN pelanggan p ON t.id_pelanggan=p.id_pelanggan", con)
        Dim readTransaksi As MySqlDataReader = selectTransaksi.ExecuteReader

        Dim tmp As String = "<table class='table table-hover table-striped'>"
        tmp = tmp & "<thead>"
        tmp = tmp & "<th>Nama Pelanggan</th>"
        tmp = tmp & "<th>Nama Mobil</th>"
        tmp = tmp & "<th>Nomor Mobil</th>"
        tmp = tmp & "<th>Tanggal Sewa</th>"
        tmp = tmp & "<th>Tanggal Ambil</th>"
        tmp = tmp & "<th>Tanggal Kembali</th>"
        tmp = tmp & "<th>Lama Sewa</th>"
        tmp = tmp & "<th>Total Harga</th>"
        tmp = tmp & "</thead>"
        tmp = tmp & "<tbody>"
        While readTransaksi.Read()
            tmp = tmp & "<tr> "
            tmp = tmp & "<td>" & readTransaksi.GetString(1) & "</td>"
            tmp = tmp & "<td>" & readTransaksi.GetString(2) & "</td>"
            tmp = tmp & "<td>" & readTransaksi.GetString(3) & "</td>"
            tmp = tmp & "<td>" & readTransaksi.GetString(4) & "</td>"
            tmp = tmp & "<td>" & readTransaksi.GetString(5) & "</td>"
            If readTransaksi.IsDBNull(6) Then
                tmp = tmp & "<td><b>Belum Dikembalikan</b></td>"
            Else
                tmp = tmp & "<td>" & readTransaksi.GetString(6) & "</td>"
            End If
            tmp = tmp & "<td>" & readTransaksi.GetString(7) & "</td>"
            tmp = tmp & "<td>Rp." & readTransaksi.GetString(8) & "</td>"
            If readTransaksi.IsDBNull(6) Then
                tmp = tmp & "<td><a href='Dikembalikan.aspx/?id=" & readTransaksi.GetString(0) & "' class='btn btn-xs btn-primary btn-fill'>Dikembalikan</a></td>"
            Else
                tmp = tmp & "<td>&nbsp;</td>"
            End If
            tmp = tmp & "</tr>"
        End While
        tmp = tmp & "<tbody>"
        tmp = tmp & "</table>"

        kontenLaporan.Text = tmp

        readTransaksi.Close()
        readTransaksi = Nothing

        Dim selectKonfirmasi As New MySqlCommand("SELECT nama, tgl_sewa, total_harga, bukti FROM transaksi JOIN pelanggan USING(id_pelanggan) JOIN konfirmasi USING(id_transaksi)", con)
        Dim readKonfirmasi As MySqlDataReader = selectKonfirmasi.ExecuteReader

        Dim tmp3 As String = "<table class='table table-hover table-striped'>"
        tmp3 = tmp3 & "<thead>"
        'tmp3 = tmp3 & "<th>No</th>"
        tmp3 = tmp3 & "<th>Nama</th>"
        tmp3 = tmp3 & "<th>Tanggal Sewa</th>"
        tmp3 = tmp3 & "<th>Total Harga</th>"
        tmp3 = tmp3 & "<th>Kode Unik Pembayaran</th>"
        tmp3 = tmp3 & "</thead>"
        tmp3 = tmp3 & "<tbody>"
        While readKonfirmasi.Read()
            tmp3 = tmp3 & "<tr> "
            tmp3 = tmp3 & "<td>" & readKonfirmasi.GetString(0) & "</td>"
            tmp3 = tmp3 & "<td>" & readKonfirmasi.GetString(1) & "</td>"
            tmp3 = tmp3 & "<td>Rp." & readKonfirmasi.GetString(2) & "</td>"
            tmp3 = tmp3 & "<td>" & readKonfirmasi.GetString(3) & "</td>"
            tmp3 = tmp3 & "</tr>"
        End While
        tmp3 = tmp3 & "<tbody>"
        tmp3 = tmp3 & "</table>"

        lapKonfirmasi.Text = tmp3

        readKonfirmasi.Close()
        readKonfirmasi = Nothing
    End Sub

End Class