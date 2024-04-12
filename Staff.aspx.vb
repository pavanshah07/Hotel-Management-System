Imports System.Data.OleDb
Partial Class Staff
    Inherits System.Web.UI.Page
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HMS\hoteldb.accdb")

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim str As String
            Dim ans As Integer
            str = "insert into StaffTbl values(" & txt_StId.Text & ",'" & txt_StName.Text & "','" & txt_StPhone.Text & "','" & dp_StGender.SelectedItem.ToString() & "','" & txt_StPass.Text & "')"
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
            str = "update StaffTbl set StName = '" & txt_StName.Text & "',StPhone = " & txt_StPhone.Text & ",StGender = '" & dp_StGender.SelectedItem.ToString() & "',StPass = '" & txt_StPass.Text & "' where Stid = " & txt_StId.Text & ""
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
            str = "delete from StaffTbl where Stid = " & txt_StId.Text & ""
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
        txt_StId.Text = ""
        txt_StName.Text = ""
        txt_StPhone.Text = ""
        dp_StGender.SelectedIndex = -1
        txt_StPass.Text = ""
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            cn.Open()
            Dim str As String
            str = "select * from StaffTbl where Stid = " & txt_StId.Text & ""
            Dim cmd As New OleDbCommand(str, cn)
            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                txt_StName.Text = dr.Item(1).ToString()
                txt_StPhone.Text = dr.Item(2).ToString()
                dp_StGender.Text = dr.Item(3).ToString()
                txt_StPass.Text = dr.Item(4).ToString()
            End While
            MsgBox("Record Searched Successfully")
            GridView1.DataBind()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
