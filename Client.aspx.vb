Imports System.Data.OleDb
Partial Class Client
    Inherits System.Web.UI.Page
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HMS\hoteldb.accdb")

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim str As String
            Dim ans As Integer
            str = "insert into ClientTbl values(" & txt_Clid.Text & ",'" & txt_ClName.Text & "','" & dp_ClGen.SelectedItem.ToString() & "'," & txt_ClAge.Text & ",'" & txt_ClPhone.Text & "','" & dp_ClCoun.SelectedItem.ToString() & "')"
            cn.Open()
            Dim cmd As New OleDbCommand(str, cn)
            ans = cmd.ExecuteNonQuery()
            MsgBox("Record inserted successfully " & ans)
            GridView1.DataBind()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim str As String
            Dim ans As Integer
            str = "update ClientTbl set ClName = '" & txt_ClName.Text & "',ClGender = '" & dp_ClGen.SelectedItem.ToString() & "',ClAge = " & txt_ClAge.Text & ", ClPhone = " & txt_ClPhone.Text & ",ClCountry = '" & dp_ClCoun.SelectedItem.ToString() & "' where Clid = " & txt_Clid.Text & ""
            cn.Open()
            Dim cmd As New OleDbCommand(str, cn)
            ans = cmd.ExecuteNonQuery()
            MsgBox("Record Updated Successfully " & ans)
            GridView1.DataBind()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim str As String
            Dim ans As Integer
            str = "delete from ClientTbl where Clid = " & txt_Clid.Text & ""
            cn.Open()
            Dim cmd As New OleDbCommand(str, cn)
            ans = cmd.ExecuteNonQuery()
            MsgBox("No Of Records Are : " & ans)
            GridView1.DataBind()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        txt_Clid.Text = ""
        txt_ClName.Text = ""
        dp_ClGen.SelectedIndex = -1
        txt_ClAge.Text = ""
        txt_ClPhone.Text = ""
        dp_ClCoun.SelectedIndex = -1
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            cn.Open()
            Dim str As String
            str = "select * from ClientTbl where Clid = " & txt_Clid.Text & ""
            Dim cmd As New OleDbCommand(str, cn)
            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                txt_ClName.Text = dr.Item(1).ToString()
                dp_ClGen.Text = dr.Item(2).ToString()
                txt_ClAge.Text = dr.Item(3).ToString()
                txt_ClPhone.Text = dr.Item(4).ToString()
                dp_ClCoun.Text = dr.Item(5).ToString()
            End While
            MsgBox("Record Searched Successfully")
            GridView1.DataBind()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
