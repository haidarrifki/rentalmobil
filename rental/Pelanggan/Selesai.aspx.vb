Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class Selesai
    Inherits System.Web.UI.Page

    Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
    Dim con As New MySqlConnection(koneksi)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usr") Is Nothing Then
            Response.Redirect("../LoginPelanggan.aspx")
            Exit Sub
        End If

        con.Open()
        Dim usr As User = Session("usr")
        Dim idUser = usr.GetId()
        Dim idMobil As Integer = Request.Params("id_mobil")
        Dim idTransaksi As Integer = Request.Params("id_transaksi")

        Dim findMobil = New MySqlCommand("SELECT harga FROM mobil WHERE id_mobil=?", con)
        findMobil.Parameters.AddWithValue("?", idMobil)
        Dim hasilMobil As MySqlDataReader = findMobil.ExecuteReader
        hasilMobil.Read()
        Dim harga_mobil As String = hasilMobil.GetString(0)
        hasilMobil.Close()

        Dim findUser = New MySqlCommand("SELECT nama, email FROM pelanggan WHERE id_pelanggan=?", con)
        findUser.Parameters.AddWithValue("?", idUser)
        Dim hasilUser As MySqlDataReader = findUser.ExecuteReader
        hasilUser.Read()
        Dim nama_pelanggan As String = hasilUser.GetString(0)
        Dim email_pelanggan As String = hasilUser.GetString(1)
        hasilUser.Close()

        Dim jasa_supir = ""
        Dim lama = ""
        Dim tgl_ambil = ""
        Dim total_harga = ""
        Dim jatuh_tempo = ""
        Dim jaminan = ""

        Dim findTransaksi = New MySqlCommand("SELECT jasa_supir, lama, tgl_ambil, total_harga, jatuh_tempo, jaminan FROM detail_transaksi JOIN transaksi USING(id_transaksi) JOIN supir USING(id_supir) WHERE id_transaksi = ?", con)
        findTransaksi.Parameters.AddWithValue("?", idTransaksi)
        Dim hasilTransaksi As MySqlDataReader = findTransaksi.ExecuteReader
        If hasilTransaksi.HasRows Then
            hasilTransaksi.Read()
            jasa_supir = hasilTransaksi.GetString(0)
            lama = hasilTransaksi.GetString(1)
            tgl_ambil = hasilTransaksi.GetString(2)
            total_harga = hasilTransaksi.GetString(3)
            jatuh_tempo = hasilTransaksi.GetString(4)
            jaminan = hasilTransaksi.GetString(5)
            hasilTransaksi.Close()
        Else
            Dim transaksi = New MySqlCommand("SELECT lama, tgl_ambil, total_harga, jatuh_tempo, jaminan FROM transaksi WHERE id_transaksi = ?", con)
            transaksi.Parameters.AddWithValue("?", idTransaksi)
            Dim hasilTransaksi2 As MySqlDataReader = transaksi.ExecuteReader
            hasilTransaksi2.Read()
            jasa_supir = "0"
            lama = hasilTransaksi.GetString(0)
            tgl_ambil = hasilTransaksi.GetString(1)
            total_harga = hasilTransaksi.GetString(2)
            jatuh_tempo = hasilTransaksi.GetString(3)
            jaminan = hasilTransaksi.GetString(4)
            hasilTransaksi2.Close()
        End If

        Dim tmp As String = "<table class='table table-bordered'>"
        tmp = tmp & "<thead>"
        tmp = tmp & "<tr><th>Nama Pelanggan</th><td>: " & nama_pelanggan & "</td></tr>"
        tmp = tmp & "<tr><th>Email</th><td>: " & email_pelanggan & "</td></tr>"
        tmp = tmp & "<tr><th>Harga Supir</th><td>: " & jasa_supir & "</td></tr>"
        tmp = tmp & "<tr><th>Lama Sewa</th><td>: " & lama & " Hari</td></tr>"
        tmp = tmp & "<tr><th>Tanggal Ambil</th><td>: " & tgl_ambil & "</td></tr>"
        tmp = tmp & "<tr><th>Total Bayar</th><td>: Rp." & total_harga & "</td></tr>"
        tmp = tmp & "<tr><th>Jatuh Tempo Pembayaran</th><td>: " & jatuh_tempo & "</td></tr>"
        tmp = tmp & "<tr><th>Jaminan</th><td>: " & jaminan & "</td></tr>"
        tmp = tmp & "</thead>"
        tmp = tmp & "</table>"

        kontenTransaksi.Text = tmp
    End Sub
End Class