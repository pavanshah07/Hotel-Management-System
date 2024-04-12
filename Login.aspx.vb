Imports System.Data.OleDb
Partial Class Login
    Inherits System.Web.UI.Page
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HMS\hoteldb.accdb")
    Dim cmd As New OleDbCommand
    Dim qry As String = ""

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_login.Click
        If txt_User.Text = "" Or txt_Password.Text = "" Then
            MsgBox("Please Enter The Staff Name and Password", MsgBoxStyle.Information)
        Else
            Try
                qry = "select id from LoginTbl where username='" & txt_User.Text & "' and password='" & txt_Password.Text & "'"
                cn.Open()
                cmd = New OleDbCommand(qry, cn)
                Dim id As Integer = cmd.ExecuteScalar
                If id > 0 Then
                    Session("username") = txt_User.Text
                    Response.Redirect("Home.aspx", False)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

       
    End Sub


 
End Class
