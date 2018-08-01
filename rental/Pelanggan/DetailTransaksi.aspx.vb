Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class DetailTransaksi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usr") Is Nothing Then
            Response.Redirect("../LoginPelanggan.aspx")
            Exit Sub
        End If

        Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
        Dim con As New MySqlConnection(koneksi)

        Try
            con.Open()
            Dim detail As String = "SELECT t.id_transaksi, m.nama_mobil, t.lama, t.jaminan, t.total_harga, t.tgl_sewa, t.tgl_ambil, t.tgl_kembali, t.jatuh_tempo, t.status, t.konfirmasi, t.pembatalan FROM transaksi t JOIN pelanggan p USING(id_pelanggan) JOIN mobil m ON t.id_mobil=m.id_mobil WHERE id_transaksi = ?"
            Dim findDetail = New MySqlCommand(detail, con)
            Dim idTransaksi As Integer = Request.Params("id")
            findDetail.Parameters.AddWithValue("?", idTransaksi)
            Dim readDetail As MySqlDataReader = findDetail.ExecuteReader
            readDetail.Read()

            Dim tmp As String = "<table class='table'>"
            tmp = tmp & "<tbody>"
            tmp = tmp & "<tr><th style='width: 20%;'>Mobil</th><td>: " & readDetail.GetString(1) & "</td></tr>"
            tmp = tmp & "<tr><th>Lama</th><td>: " & readDetail.GetString(2) & " Hari</td></tr>"
            tmp = tmp & "<tr><th>Jaminan</th><td>: " & readDetail.GetString(3) & "</td></tr>"
            tmp = tmp & "<tr><th>Total</th><td>: Rp." & readDetail.GetString(4) & "</td></tr>"
            tmp = tmp & "<tr><th>Tanggal Sewa</th><td>: " & readDetail.GetString(5) & "</td></tr>"
            tmp = tmp & "<tr><th>Tanggal Ambil</th><td>: " & readDetail.GetString(6) & "</td></tr>"
            If readDetail.IsDBNull(7) Then
                tmp = tmp & "<tr><th>Tanggal Kembali</th><td>: <b>Belum</b></td></tr>"
            Else
                tmp = tmp & "<tr><th>Tanggal Kembali</th><td>: " & readDetail.GetString(7) & "</td></tr>"
            End If
            tmp = tmp & "<tr><th>Jatuh Tempo</th><td>: " & readDetail.GetString(8) & "</td></tr>"
            If readDetail.GetString(10) = "1" Then
                tmp = tmp & "<tr><th>Konfirmasi</th><td>: <label class='label label-success' style='color: #ffffff;'>Sudah</label></td></tr>"
            Else
                tmp = tmp & "<tr><th>Konfirmasi</th><td>: <label class='label label-danger' style='color: #ffffff;'>Belum</label></td></tr>"
            End If
            If readDetail.GetString(9) = "1" Then
                tmp = tmp & "<tr><th>Kembali</th><td>: <label class='label label-success' style='color: #ffffff;'>Sudah</label></td></tr>"
            Else
                tmp = tmp & "<tr><th>Kembali</th><td>: <label class='label label-danger' style='color: #ffffff;'>Belum</label></td></tr>"
            End If
            If readDetail.GetString(11) = "1" Then
                tmp = tmp & "<tr><th>Pembatalan</th><td>: <label class='label label-danger' style='color: #ffffff;'>Ya</label></td></tr>"
            Else
                tmp = tmp & "<tr><th>Pembatalan</th><td>: <label class='label label-success' style='color: #ffffff;'>Tidak</label></td></tr>"
            End If
            If readDetail.GetString(10) = "0" Then
                tmp = tmp & "<tr><th>&nbsp;</th><td><a href='../Konfirmasi.aspx/?id=" & readDetail.GetString(0) & "' class='btn btn-primary btn-sm btn-fill' style='margin-left: 10px;'>Konfirmasi</a></td></tr>"
            End If

            kontenDetail.Text = tmp

            readDetail.Close()
            readDetail = Nothing
        Catch ex As Exception
            Response.Write("Error :" & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

End Class