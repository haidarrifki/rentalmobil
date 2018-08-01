Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class Mobil
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usr") Is Nothing Then
            Response.Redirect("../Login.aspx")
            Exit Sub
        End If

        Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
        Dim con As New MySqlConnection(koneksi)

        Try
            con.Open()
            Dim selectMobil As New MySqlCommand("SELECT * FROM mobil", con)
            Dim readMobil As MySqlDataReader = selectMobil.ExecuteReader

            Dim tmp As String = "<table class='table table-hover table-striped'>"
            tmp = tmp & "<thead>"
            tmp = tmp & "<th>ID</th>"
            tmp = tmp & "<th>Jenis</th>"
            tmp = tmp & "<th>No Mobil</th>"
            tmp = tmp & "<th>Merk</th>"
            tmp = tmp & "<th>Nama Mobil</th>"
            tmp = tmp & "<th>Harga</th>"
            tmp = tmp & "<th>Status</th>"
            tmp = tmp & "<th>Aksi</th>"
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
                tmp = tmp & "<td><a href=Mobil/delMobil.aspx?id=" & readMobil.GetString(0) & " class='btn btn-fill btn-danger btn-xs'>hapus</a> "
                tmp = tmp & "<a href=Mobil/editMobil.aspx?id=" & readMobil.GetString(0) & " class='btn btn-fill btn-success btn-xs'>edit</a> </td>"
                tmp = tmp & "</tr>"
            End While
            tmp = tmp & "<tbody>"
            tmp = tmp & "</table>"

            kontenMobil.Text = tmp

            readMobil.Close()
            readMobil = Nothing

            Dim selectSupir As New MySqlCommand("SELECT * FROM supir", con)
            Dim readSupir As MySqlDataReader = selectSupir.ExecuteReader

            Dim tmp2 As String = "<table class='table table-hover table-striped'>"
            tmp2 = tmp2 & "<thead>"
            tmp2 = tmp2 & "<th>ID</th>"
            tmp2 = tmp2 & "<th>Nama</th>"
            tmp2 = tmp2 & "<th>Telepon</th>"
            tmp2 = tmp2 & "<th>Alamat</th>"
            tmp2 = tmp2 & "<th>Status</th>"
            tmp2 = tmp2 & "<th>Aksi</th>"
            tmp2 = tmp2 & "</thead>"
            tmp2 = tmp2 & "<tbody>"
            While readSupir.Read()
                tmp2 = tmp2 & "<tr> "
                tmp2 = tmp2 & "<td>" & readSupir.GetString(0) & "</td>"
                tmp2 = tmp2 & "<td>" & readSupir.GetString(1) & "</td>"
                tmp2 = tmp2 & "<td>" & readSupir.GetString(2) & "</td>"
                tmp2 = tmp2 & "<td>" & readSupir.GetString(3) & "</td>"
                tmp2 = tmp2 & "<td>" & readSupir.GetString(4) & "</td>"
                tmp2 = tmp2 & "<td><a href=Supir/delSupir.aspx?id=" & readSupir.GetString(0) & " class='btn btn-fill btn-danger btn-xs'>hapus</a> "
                tmp2 = tmp2 & "<a href=Supir/editSupir.aspx?id=" & readSupir.GetString(0) & " class='btn btn-fill btn-success btn-xs'>edit</a> </td>"
                tmp2 = tmp2 & "</tr>"
            End While
            tmp2 = tmp2 & "<tbody>"
            tmp2 = tmp2 & "</table>"

            kontenSupir.Text = tmp2

            readSupir.Close()
            readSupir = Nothing
        Catch ex As Exception
            Response.Write("Error :" & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

End Class