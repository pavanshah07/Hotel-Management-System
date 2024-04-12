Imports System.Data.OleDb

Partial Class Reservation
    Inherits System.Web.UI.Page
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HMS\hoteldb.accdb")

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim str As String
            Dim ans As Integer
            str = "insert into ReservationTbl values(" & txt_ResId.Text & "," & dp_Clid.Text & ",'" & txt_ClName.Text & "'," & dp_Rno.Text & ",'" & txt_DateIn.Text & "','" & txt_DateOut.Text & "')"
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
            str = "update ReservationTbl set Clientid = " & dp_Clid.SelectedItem.ToString() & ",ClientName = '" & txt_ClName.Text & "',RoomNo = " & dp_Rno.SelectedItem.ToString() & ",DateIn = '" & txt_DateIn.Text & "',DateOut = '" & txt_DateOut.Text & "' where Resid = " & txt_ResId.Text & ""
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
            str = "delete from ReservationTbl where Resid = " & txt_ResId.Text & ""
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
        txt_ResId.Text = ""
        dp_Clid.SelectedIndex = -1
        txt_ClName.Text = ""
        dp_Rno.SelectedIndex = -1
        txt_DateIn.Text = ""
        txt_DateOut.Text = ""
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            cn.Open()
            Dim str As String
            str = "select * from ReservationTbl where Resid = " & txt_ResId.Text & ""
            Dim cmd As New OleDbCommand(str, cn)
            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                dp_Clid.Text = dr.Item(1).ToString()
                txt_ClName.Text = dr.Item(2).ToString()
                dp_Rno.Text = dr.Item(3).ToString()
                txt_DateIn.Text = dr.Item(4).ToString()
                txt_DateOut.Text = dr.Item(5).ToString()
            End While
            MsgBox("Record Searched Successfully")
            GridView1.DataBind()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
