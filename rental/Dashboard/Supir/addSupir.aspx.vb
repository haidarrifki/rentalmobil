Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class addSupir
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usr") Is Nothing Then
            Response.Redirect("../../Login.aspx")
            Exit Sub
        End If
    End Sub

    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
        Dim con As New MySqlConnection(koneksi)

        Try
            con.Open()
            Dim query As String
            query = "INSERT INTO supir (nama, telp, alamat, status) VALUES (@nama, @telp, @alamat, @status)"
            Dim saveSupir = New MySqlCommand(query, con)
            saveSupir.Parameters.AddWithValue("@nama", Me.nama.Text)
            saveSupir.Parameters.AddWithValue("@alamat", Me.alamat.Text)
            saveSupir.Parameters.AddWithValue("@telp", Me.telp.Text)
            saveSupir.Parameters.AddWithValue("@status", Me.status.Text)
            Dim jmlRecord As Integer = saveSupir.ExecuteNonQuery()
            If jmlRecord > 0 Then
                Response.Redirect("../Mobil.aspx")
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