Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class Mobil1
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
            Dim usr As User = Session("usr")
            Dim transaksi As String = "SELECT id_mobil, nama_mobil, harga, jenis_mobil, merk, no_mobil, status FROM mobil WHERE status='Tersedia'"
            Dim mobil = New MySqlCommand(transaksi, con)
            Dim readMobil As MySqlDataReader = mobil.ExecuteReader

            Dim tmp As String = "<table class='table table-hover table-striped'>"
            tmp = tmp & "<thead>"
            tmp = tmp & "<th>No</th>"
            tmp = tmp & "<th>Nama Mobil</th>"
            tmp = tmp & "<th>Harga Sewa</th>"
            tmp = tmp & "<th>Jenis</th>"
            tmp = tmp & "<th>Merk</th>"
            tmp = tmp & "<th>No Mobil</th>"
            tmp = tmp & "</thead>"
            tmp = tmp & "<tbody>"
            While readMobil.Read()
                tmp = tmp & "<tr>"
                tmp = tmp & "<td>" & readMobil.GetString(0) & "</td>"
                tmp = tmp & "<td>" & readMobil.GetString(1) & "</td>"
                tmp = tmp & "<td>" & readMobil.GetString(2) & "</td>"
                tmp = tmp & "<td>" & readMobil.GetString(3) & "</td>"
                tmp = tmp & "<td>" & readMobil.GetString(4) & "</td>"
                tmp = tmp & "<td>" & readMobil.GetString(5) & "</td>"
                tmp = tmp & "<td>" & readMobil.GetString(6) & "</td>"
                tmp = tmp & "<td><a href='Sewa.aspx?id=" & readMobil.GetString(0) & "' class='btn btn-sm btn-fill btn-primary'>Sewa</a></td>"
                tmp = tmp & "</tr>"
            End While
            tmp = tmp & "<tbody>"
            tmp = tmp & "</table>"

            kontenMobil.Text = tmp

            readMobil.Close()
            readMobil = Nothing
        Catch ex As Exception
            Response.Write("Error :" & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

End Class