Imports System.Configuration
Imports MySql.Data.MySqlClient
Partial Class LoginPelanggan
    Inherits System.Web.UI.Page
    Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
    Dim con As New MySqlConnection(koneksi)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        Dim findDenda = New MySqlCommand("SELECT a.id_transaksi, (TIMESTAMPDIFF(HOUR, ADDDATE(a.tgl_ambil, INTERVAL a.lama DAY), a.tgl_kembali)) AS terlambat, 35000 * (TIMESTAMPDIFF(HOUR, ADDDATE(a.tgl_ambil, INTERVAL a.lama DAY), a.tgl_kembali)) AS denda FROM transaksi a", con)
        Dim hasilDenda As MySqlDataReader = findDenda.ExecuteReader
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
    End Sub
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            password.Text = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "SHA1")
            Dim cmd As New MySqlCommand("SELECT * FROM pelanggan WHERE username='" & username.Text & "' AND password = '" & password.Text & "'", con)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            reader.Read()

            If reader.HasRows Then
                Dim usr As User = New User()

                usr.SetId(reader.GetString(0))
                usr.SetUsername(username.Text)
                usr.SetPassword(password.Text)
                usr.SetNama(username.Text)

                Session("usr") = usr

                Response.Redirect("Pelanggan/Mobil.aspx")
            Else
                username.Text = ""
                password.Text = ""
                pesan.Text = "<div class='alert alert-danger center-block text-center'>Username atau password salah</div>"
            End If
        Catch ex As Exception
            pesan.Text = "Error: " & ex.Message
        Finally
            con.Close()
        End Try
    End Sub
End Class