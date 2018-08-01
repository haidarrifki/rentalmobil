Imports Microsoft.VisualBasic

Public Class User
    Private _id As String
    Private _username As String
    Private _password As String
    Private _nama As String

    'konstruktor
    Public Sub New()
        _id = ""
        _username = ""
        _password = ""
        _nama = ""
    End Sub

    Public Sub SetId(ByVal id As String)
        _id = id
    End Sub
    Public Sub SetUsername(ByVal username As String)
        _username = username
    End Sub

    Public Sub SetPassword(ByVal password As String)
        _password = password
    End Sub

    Public Sub SetNama(ByVal nama As String)
        _nama = nama
    End Sub
    Public Function GetId() As String
        Return _id
    End Function
    Public Function GetUsername() As String
        Return _username
    End Function

    Public Function GetPassword() As String
        Return _password
    End Function

    Public Function GetNama() As String
        Return _nama
    End Function

End Class
