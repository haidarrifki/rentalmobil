Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class Sewa
    Inherits System.Web.UI.Page

    Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
    Dim con As New MySqlConnection(koneksi)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usr") Is Nothing Then
            Response.Redirect("../LoginPelanggan.aspx")
            Exit Sub
        End If
        con.Open()
    End Sub

    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim usr As User = Session("usr")

        Dim tgl As Date = DateTime.Now
        Dim tglAmbil = tgl.AddDays(lama.Text)

        Dim mobil As String = "SELECT harga FROM mobil WHERE id_mobil = ?"
        Dim findMobil = New MySqlCommand(mobil, con)
        Dim idMobil = Request.Params("id")
        findMobil.Parameters.AddWithValue("?", idMobil)
        Dim readMobil As MySqlDataReader = findMobil.ExecuteReader
        readMobil.Read()

        Dim hargaSupir As Integer = 0
        Dim idUser = usr.GetId()
        Dim jatuhTempo = tgl.AddHours(+3)
        If supir.Text = "Ya" Then
            hargaSupir = 50000
        End If
        Dim totalBayar = hargaSupir + (readMobil.GetString(0) * lama.Text)

        readMobil.Close()

        Try
            Dim query As String
            query = "INSERT INTO transaksi (id_pelanggan, id_mobil, tgl_sewa, tgl_ambil, lama, total_harga, jaminan, jatuh_tempo, konfirmasi, pembatalan) " & _
                    " VALUES (@id_pelanggan, @id_mobil, @tgl_sewa, @tgl_ambil, @lama, @total_harga, @jaminan, @jatuh_tempo, @konfirmasi, @pembatalan)"
            Dim saveTransaksi = New MySqlCommand(query, con)

            saveTransaksi.Parameters.AddWithValue("@id_pelanggan", idUser)
            saveTransaksi.Parameters.AddWithValue("@id_mobil", idMobil)
            saveTransaksi.Parameters.AddWithValue("@tgl_sewa", tgl)
            saveTransaksi.Parameters.AddWithValue("@tgl_ambil", tglAmbil)
            saveTransaksi.Parameters.AddWithValue("@lama", Me.lama.Text)
            saveTransaksi.Parameters.AddWithValue("@total_harga", totalBayar)
            saveTransaksi.Parameters.AddWithValue("@jaminan", Me.jaminan.Text)
            saveTransaksi.Parameters.AddWithValue("@jatuh_tempo", jatuhTempo)
            saveTransaksi.Parameters.AddWithValue("@konfirmasi", "0")
            saveTransaksi.Parameters.AddWithValue("@pembatalan", "0")

            Dim jmlRecord As Integer = saveTransaksi.ExecuteNonQuery()

            Dim getTransaksi As String = "SELECT MAX(id_transaksi) FROM transaksi"
            Dim findTransaksi = New MySqlCommand(getTransaksi, con)
            Dim readTransaksi As MySqlDataReader = findTransaksi.ExecuteReader

            readTransaksi.Read()
            Dim idTransaksi As Integer = readTransaksi.GetString(0)
            readTransaksi.Close()

            If jmlRecord > 0 Then
                If supir.Text = "Ya" Then
                    Dim getSupir As String = "SELECT id_supir FROM supir WHERE status='Tersedia' LIMIT 1"
                    Dim findSupir = New MySqlCommand(getSupir, con)
                    Dim readSupir As MySqlDataReader = findSupir.ExecuteReader

                    readSupir.Read()
                    Dim idSupir As Integer = readSupir.GetString(0)
                    readSupir.Close()

                    hargaSupir = 50000
                    Dim querySupir As String = "INSERT INTO detail_transaksi(id_transaksi, id_supir, jasa_supir) VALUES (@id_transaksi, @id_supir, @jasa_supir)"
                    Dim saveSupir = New MySqlCommand(querySupir, con)

                    saveSupir.Parameters.AddWithValue("@id_transaksi", idTransaksi)
                    saveSupir.Parameters.AddWithValue("@id_supir", idSupir)
                    saveSupir.Parameters.AddWithValue("@jasa_supir", hargaSupir)
                    saveSupir.ExecuteNonQuery()
                End If

                Dim queryUpdate As String = "UPDATE mobil SET status = 'Tidak Tersedia' WHERE id_mobil = ?"
                Dim updatestatus = New MySqlCommand(queryUpdate, con)
                updatestatus.Parameters.AddWithValue("?", idMobil)
                updatestatus.ExecuteNonQuery()

                Response.Redirect("Selesai.aspx/?id_mobil=" & idMobil & "&id_transaksi=" & idTransaksi)
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