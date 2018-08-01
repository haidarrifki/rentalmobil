Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class delMobil
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usr") Is Nothing Then
            Response.Redirect("../../Login.aspx")
            Exit Sub
        End If

        Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
        Dim con As New MySqlConnection(koneksi)

        Try
            con.Open()
            Dim query As String
            query = "DELETE FROM mobil WHERE id_mobil = ?"
            Dim del = New MySqlCommand(query, con)
            Dim idMobil = Request.Params("id")
            del.Parameters.AddWithValue("?", idMobil)
            Dim jmlRecord As Integer = del.ExecuteNonQuery()
            If jmlRecord > 0 Then
                Response.Redirect("../Mobil.aspx")
            Else
                Response.Write("Gagal Hapus Data")
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

End Class