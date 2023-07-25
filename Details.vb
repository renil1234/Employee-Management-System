Imports System.Data.SqlClient
Public Class Details
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\renil\Documents\EmployeeVbDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub FetchEmployeeData()
        If EmpIdTb.Text = "" Then
            MsgBox("Enter the Employee ID")
        Else
            Con.Open()
            Dim Query = "select * from EmployeeTbl where EmpId=" & EmpIdTb.Text & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(Query, Con)
            Dim dt As DataTable
            dt = New DataTable
            Dim sda As SqlDataAdapter
            sda = New SqlDataAdapter(cmd)
            sda.Fill(dt)
            For Each dr As DataRow In dt.Rows
                EmpNamelbl.Text = dr(1).ToString()
                EmpAddlbl.Text = dr(2).ToString()
                EmpPostlbl.Text = dr(3).ToString()
                EmpDoblbl.Text = dr(4).ToString()
                EmpPhone.Text = dr(5).ToString()
                EmpEdulbl.Text = dr(6).ToString()
                EmpGender.Text = dr(7).ToString()
                EmpNamelbl.Visible = True
                EmpPhone.Visible = True
                EmpAddlbl.Visible = True
                EmpDoblbl.Visible = True
                EmpEdulbl.Visible = True
                EmpGender.Visible = True
                EmpPostlbl.Visible = True
            Next
            Con.Close()

        End If
    End Sub
    Private Sub Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FetchEmployeeData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Dim Main = New MainForm
        Main.Show()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Application.Exit()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class