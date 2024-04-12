Imports System.Data.OleDb
Partial Class Rooms
    Inherits System.Web.UI.Page
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HMS\hoteldb.accdb")

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim str As String
            Dim ans As Integer
            str = "insert into RoomTbl values(" & txt_Rid.Text & ",'" & txt_RPhone.Text & "','" & dp_Rtype.SelectedItem.ToString() & "','" & dp_RStatus.SelectedItem.ToString() & "')"
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
            str = "update RoomTbl set RPhone = '" & txt_RPhone.Text & "',RType = '" & dp_Rtype.SelectedItem.ToString() & "',RStatus = '" & dp_RStatus.SelectedItem.ToString() & "' where Rid = " & txt_Rid.Text & ""
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
            str = "delete from RoomTbl where Rid = " & txt_Rid.Text & ""
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
        txt_Rid.Text = ""
        txt_RPhone.Text = ""
        dp_Rtype.SelectedIndex = -1
        dp_RStatus.SelectedIndex = -1
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            cn.Open()
            Dim str As String
            str = "select * from RoomTbl where Rid = " & txt_Rid.Text & ""
            Dim cmd As New OleDbCommand(str, cn)
            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                txt_RPhone.Text = dr.Item(1).ToString()
                dp_Rtype.Text = dr.Item(2).ToString()
                dp_RStatus.Text = dr.Item(3).ToString()
            End While
            MsgBox("Record Searched Successfully")
            GridView1.DataBind()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
