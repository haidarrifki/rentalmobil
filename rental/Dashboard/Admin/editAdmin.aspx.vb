﻿Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class editAdmin
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

                Dim query As String = "SELECT * FROM admin WHERE id_admin = ?"
                Dim findAdmin = New MySqlCommand(query, con)
                Dim idAdmin = Request.Params("id")
                findAdmin.Parameters.AddWithValue("?", idAdmin)
                Dim reader As MySqlDataReader = findAdmin.ExecuteReader
                If reader.HasRows Then
                    reader.Read()
                    nama.Text = reader.GetString(1)
                    email.Text = reader.GetString(2)
                    alamat.Text = reader.GetString(3)
                    telp.Text = reader.GetString(4)
                    username.Text = reader.GetString(5)
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

            Dim query As String = "UPDATE admin SET nama =@nama, email=@email, alamat=@alamat, telp=@telp, username=@username, password=@password WHERE id_admin =@id"
            Dim updateAdmin = New MySqlCommand(query, con)
            Dim idAdmin = Request.Params("id")
            password.Text = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "SHA1")
            updateAdmin.Parameters.AddWithValue("@nama", Me.nama.Text)
            updateAdmin.Parameters.AddWithValue("@email", Me.email.Text)
            updateAdmin.Parameters.AddWithValue("@alamat", Me.alamat.Text)
            updateAdmin.Parameters.AddWithValue("@telp", Me.telp.Text)
            updateAdmin.Parameters.AddWithValue("@username", Me.username.Text)
            updateAdmin.Parameters.AddWithValue("@password", Me.password.Text)
            updateAdmin.Parameters.AddWithValue("@id", idAdmin)
            Dim jmlRecord As Integer = updateAdmin.ExecuteNonQuery
            If jmlRecord > 0 Then
                Response.Redirect("../User.aspx")
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