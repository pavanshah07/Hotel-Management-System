
Partial Class AdminLogin
    Inherits System.Web.UI.Page

    Protected Sub btn_login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_login.Click
        If txt_pass.Text = "" Then
            MsgBox("Please Enter Password then Login", MsgBoxStyle.Information)
        ElseIf txt_pass.Text = "Admin" Then
            Response.Redirect("Client.aspx")
            txt_pass.Text = ""
        Else
            MsgBox("Wrong Password", MsgBoxStyle.Exclamation)
            txt_pass.Text = ""
        End If
    End Sub
End Class
