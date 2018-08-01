Imports System.Data
Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class User1
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
            Dim cmd1 As New MySqlCommand("SELECT * FROM admin", con)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader

            Dim tmp As String = "<table class='table table-hover table-striped'>"
            tmp = tmp & "<thead>"
            tmp = tmp & "<th>ID</th>"
            tmp = tmp & "<th>Nama</th>"
            tmp = tmp & "<th>Email</th>"
            tmp = tmp & "<th>Alamat</th>"
            tmp = tmp & "<th>Telepon</th>"
            tmp = tmp & "<th>Username</th>"
            tmp = tmp & "<th>Aksi</th>"
            tmp = tmp & "</thead>"
            tmp = tmp & "<tbody>"
            While reader1.Read()
                tmp = tmp & "<tr> "
                tmp = tmp & "<td>" & reader1.GetString(0) & "</td>"
                tmp = tmp & "<td>" & reader1.GetString(1) & "</td>"
                tmp = tmp & "<td>" & reader1.GetString(2) & "</td>"
                tmp = tmp & "<td>" & reader1.GetString(3) & "</td>"
                tmp = tmp & "<td>" & reader1.GetString(4) & "</td>"
                tmp = tmp & "<td>" & reader1.GetString(5) & "</td>"
                tmp = tmp & "<td><a href=Admin/delAdmin.aspx?id=" & reader1.GetString(0) & " class='btn btn-fill btn-danger btn-xs'>hapus</a>  "
                tmp = tmp & "<a href=Admin/editAdmin.aspx?id=" & reader1.GetString(0) & " class='btn btn-fill btn-success btn-xs'>edit</a> </td>"
                tmp = tmp & "</tr>"
            End While
            tmp = tmp & "<tbody>"
            tmp = tmp & "</table>"
            kontenAdmin.Text = tmp
            reader1.Close()
            reader1 = Nothing

            Dim cmd2 As New MySqlCommand("SELECT * FROM pelanggan", con)
            Dim reader2 As MySqlDataReader = cmd2.ExecuteReader
            Dim tmp2 As String = "<table class='table table-hover table-striped'>"
            tmp2 = tmp2 & "<thead>"
            tmp2 = tmp2 & "<th>ID</th>"
            tmp2 = tmp2 & "<th>No KTP</th>"
            tmp2 = tmp2 & "<th>Nama</th>"
            tmp2 = tmp2 & "<th>Email</th>"
            tmp2 = tmp2 & "<th>Telepon</th>"
            tmp2 = tmp2 & "<th>Alamat</th>"
            tmp2 = tmp2 & "<th>Username</th>"
            tmp2 = tmp2 & "<th>Aksi</th>"
            tmp2 = tmp2 & "</thead>"
            tmp2 = tmp2 & "<tbody>"
            While reader2.Read()
                tmp2 = tmp2 & "<tr> "
                tmp2 = tmp2 & "<td>" & reader2.GetString(0) & "</td>"
                tmp2 = tmp2 & "<td>" & reader2.GetString(1) & "</td>"
                tmp2 = tmp2 & "<td>" & reader2.GetString(2) & "</td>"
                tmp2 = tmp2 & "<td>" & reader2.GetString(3) & "</td>"
                tmp2 = tmp2 & "<td>" & reader2.GetString(4) & "</td>"
                tmp2 = tmp2 & "<td>" & reader2.GetString(5) & "</td>"
                tmp2 = tmp2 & "<td>" & reader2.GetString(6) & "</td>"
                tmp2 = tmp2 & "<td><a href=Pelanggan/delPelanggan.aspx?id=" & reader2.GetString(0) & " class='btn btn-fill btn-danger btn-xs'>hapus</a>  "
                tmp2 = tmp2 & "<a href=Pelanggan/editPelanggan.aspx?id=" & reader2.GetString(0) & " class='btn btn-fill btn-success btn-xs'>edit</a> </td>"
                tmp2 = tmp2 & "</tr>"
            End While
            tmp2 = tmp2 & "<tbody>"
            tmp2 = tmp2 & "</table>"
            kontenPelanggan.Text = tmp2
            reader2.Close()
            reader2 = Nothing
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    Response.Write("Cannot connect to server. Contact administrator")
                Case 1045
                    Response.Write("Invalid username/password, please try again")
            End Select
        Finally
            con.Close()
        End Try
    End Sub

End Class