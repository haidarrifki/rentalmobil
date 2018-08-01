Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class Riwayat
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usr") Is Nothing Then
            Response.Redirect("../LoginPelanggan.aspx")
            Exit Sub
        End If

        Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
        Dim con As New MySqlConnection(koneksi)
        con.Open()
        'Pembatalan Otomatis
        Dim findJatuhTempo = New MySqlCommand("SELECT a.jatuh_tempo, a.id_transaksi, a.id_mobil, (TIMESTAMPDIFF(HOUR, a.tgl_sewa, NOW())) AS tempo FROM transaksi a WHERE a.konfirmasi='0'", con)
        Dim hasilJatuhTempo As MySqlDataReader = findJatuhTempo.ExecuteReader()
        hasilJatuhTempo.Read()
        If hasilJatuhTempo.HasRows Then
            If hasilJatuhTempo.GetString(3) > 3 Then
                Dim updateTransaksi = New MySqlCommand("UPDATE transaksi SET pembatalan='1' WHERE id_transaksi=?", con)
                updateTransaksi.Parameters.AddWithValue("?", hasilJatuhTempo.GetString(1))
                updateTransaksi.ExecuteNonQuery()
                Dim updateMobil = New MySqlCommand("UPDATE mobil SET status='Tersedia' WHERE id_mobil=?", con)
                updateMobil.Parameters.AddWithValue("?", hasilJatuhTempo.GetString(2))
                updateMobil.ExecuteNonQuery()
            End If
        End If
        hasilJatuhTempo.Close()
        'Perhitungan denda otomatis
        Dim findDenda2 = New MySqlCommand("SELECT a.id_transaksi, (TIMESTAMPDIFF(HOUR, ADDDATE(a.tgl_ambil, INTERVAL a.lama DAY), a.tgl_kembali)) AS terlambat, 35000 * (TIMESTAMPDIFF(HOUR, ADDDATE(a.tgl_ambil, INTERVAL a.lama DAY), a.tgl_kembali)) AS denda FROM transaksi a", con)
        Dim hasilDenda As MySqlDataReader = findDenda2.ExecuteReader
        While hasilDenda.Read()
            If Not hasilDenda.IsDBNull(1) Then
                If hasilDenda.GetString(1) > 0 Then
                    Dim updateDenda = New MySqlCommand("UPDATE transaksi SET denda=@denda WHERE id_transaksi=?", con)
                    updateDenda.Parameters.AddWithValue("@denda", hasilDenda.GetString(1))
                    updateDenda.Parameters.AddWithValue("?", hasilDenda.GetString(0))
                    updateDenda.ExecuteNonQuery()
                End If
            End If
        End While
        hasilDenda.Close()

        Try
            Dim usr As User = Session("usr")
            Dim transaksi As String = "SELECT id_transaksi, total_harga, lama, jaminan, tgl_sewa, jatuh_tempo FROM transaksi WHERE id_pelanggan = ?"
            Dim findTransaksi = New MySqlCommand(transaksi, con)
            Dim idPelanggan = usr.GetId()
            findTransaksi.Parameters.AddWithValue("?", idPelanggan)
            Dim readTransaksi As MySqlDataReader = findTransaksi.ExecuteReader

            Dim tmp As String = "<table class='table table-hover table-striped'>"
            tmp = tmp & "<thead>"
            tmp = tmp & "<th>No</th>"
            tmp = tmp & "<th>Total</th>"
            tmp = tmp & "<th>Lama</th>"
            tmp = tmp & "<th>Jaminan</th>"
            tmp = tmp & "<th>Tanggal</th>"
            tmp = tmp & "<th>Jatuh Tempo</th>"
            tmp = tmp & "</thead>"
            tmp = tmp & "<tbody>"
            While readTransaksi.Read()
                tmp = tmp & "<tr>"
                tmp = tmp & "<td>" & readTransaksi.GetString(0) & "</td>"
                tmp = tmp & "<td>Rp." & readTransaksi.GetString(1) & "</td>"
                tmp = tmp & "<td>" & readTransaksi.GetString(2) & "</td>"
                tmp = tmp & "<td>" & readTransaksi.GetString(3) & "</td>"
                tmp = tmp & "<td>" & readTransaksi.GetString(4) & "</td>"
                tmp = tmp & "<td>" & readTransaksi.GetString(5) & "</td>"
                tmp = tmp & "<td><a href=DetailTransaksi.aspx/?id=" & readTransaksi.GetString(0) & " class='btn btn-fill btn-info btn-xs'>detail</a> "
                tmp = tmp & "</tr>"
            End While
            tmp = tmp & "<tbody>"
            tmp = tmp & "</table>"

            kontenTransaksi.Text = tmp

            readTransaksi.Close()
            readTransaksi = Nothing

            Dim denda As String = "SELECT id_transaksi, jaminan, tgl_ambil, tgl_kembali, total_harga, denda FROM transaksi WHERE id_pelanggan = ? AND denda <> ''"
            Dim finddenda = New MySqlCommand(denda, con)
            finddenda.Parameters.AddWithValue("?", idPelanggan)
            Dim readdenda As MySqlDataReader = finddenda.ExecuteReader

            Dim tmp2 As String = "<table class='table table-hover table-striped'>"
            tmp2 = tmp2 & "<thead>"
            tmp2 = tmp2 & "<th>No</th>"
            tmp2 = tmp2 & "<th>Jaminan</th>"
            tmp2 = tmp2 & "<th>Tanggal Ambil</th>"
            tmp2 = tmp2 & "<th>Tanggal Kembali</th>"
            tmp2 = tmp2 & "<th>Total Harga</th>"
            tmp2 = tmp2 & "<th>Total Denda</th>"
            tmp2 = tmp2 & "</thead>"
            tmp2 = tmp2 & "<tbody>"
            While readdenda.Read()
                tmp2 = tmp2 & "<tr>"
                tmp2 = tmp2 & "<td>" & readdenda.GetString(0) & "</td>"
                tmp2 = tmp2 & "<td>Rp." & readdenda.GetString(1) & "</td>"
                tmp2 = tmp2 & "<td>" & readdenda.GetString(2) & "</td>"
                tmp2 = tmp2 & "<td>" & readdenda.GetString(3) & "</td>"
                tmp2 = tmp2 & "<td>" & readdenda.GetString(4) & "</td>"
                tmp2 = tmp2 & "<td>" & readdenda.GetString(5) & "</td>"
                tmp2 = tmp2 & "<td><a href=DetailTransaksi.aspx/?id=" & readdenda.GetString(0) & " class='btn btn-fill btn-info btn-xs'>detail</a> "
                tmp2 = tmp2 & "</tr>"
            End While
            tmp2 = tmp2 & "<tbody>"
            tmp2 = tmp2 & "</table>"

            kontenDenda.Text = tmp2

            readdenda.Close()
            readdenda = Nothing
        Catch ex As Exception
            Response.Write("Error :" & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

End Class