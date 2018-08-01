Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class editSupir
    Inherits System.Web.UI.Page

    Dim koneksi As String = ConfigurationManager.ConnectionStrings("koneksi").ConnectionString
    Dim con As New MySqlConnection(koneksi)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usr") Is Nothing Then
            Response.Redirect("../../Login.aspx")
            Exit Sub
        End If

        If Not IsPostBack Then
            Try
                con.Open()

                Dim query As String = "SELECT * FROM supir WHERE id_supir = ?"
                Dim findAdmin = New MySqlCommand(query, con)
                Dim idAdmin = Request.Params("id")
                findAdmin.Parameters.AddWithValue("?", idAdmin)
                Dim reader As MySqlDataReader = findAdmin.ExecuteReader
                If reader.HasRows Then
                    reader.Read()
                    nama.Text = reader.GetString(1)
                    telp.Text = reader.GetString(2)
                    alamat.Text = reader.GetString(3)
                    status_supir.Text = reader.GetString(4)
                Else
                    Response.Redirect("../Mobil.aspx")
                End If
                reader.Close()
            Catch ex As Exception
                Response.Write("Error: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            con.Open()

            Dim query As String = "UPDATE supir SET nama =@nama, telp=@telp, alamat=@alamat, status=@status WHERE id_supir =@id"
            Dim updateSupir = New MySqlCommand(query, con)
            Dim idAdmin = Request.Params("id")
            updateSupir.Parameters.AddWithValue("@nama", Me.nama.Text)
            updateSupir.Parameters.AddWithValue("@alamat", Me.alamat.Text)
            updateSupir.Parameters.AddWithValue("@telp", Me.telp.Text)
            updateSupir.Parameters.AddWithValue("@status", Me.status_supir.Text)
            updateSupir.Parameters.AddWithValue("@id", idAdmin)
            Dim jmlRecord As Integer = updateSupir.ExecuteNonQuery
            If jmlRecord > 0 Then
                Response.Redirect("../Mobil.aspx")
            Else
                Response.Write("Gagal Update Data")
            End If
        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class