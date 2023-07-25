Imports System.Data.SqlClient
Public Class Salary
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
                EmpPostlbl.Text = dr(3).ToString()
                EmpNamelbl.Visible = True
                EmpPostlbl.Visible = True
            Next
            Con.Close()

        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Dim Main = New MainForm
        Main.Show()
    End Sub

    Private Sub Salary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FetchEmployeeData()
    End Sub
    Dim Dailypay
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If EmpPostlbl.Text = "" Then
            MsgBox("Select an Employee")
        ElseIf WorkedTb.Text = "" Or Convert.ToInt32(WorkedTb.Text) > 366 Then
            MsgBox("Enter a valid Number of Days")
        Else
            If EmpPostlbl.Text = "Manager" Then
                Dailypay = 1200
            ElseIf EmpPostlbl.Text = "Accountant" Then
                Dailypay = 1200
            ElseIf EmpPostlbl.Text = "Security" Then
                Dailypay = 600
            ElseIf EmpPostlbl.Text = "IT" Then
                Dailypay = 850
            Else
                Dailypay = 500
            End If
            Dim total = Dailypay * Convert.ToInt32(WorkedTb.Text)
            SalaryTb.Text = "Employee Id:   " + EmpIdTb.Text + vbCrLf + "Employee Name:  " + EmpNamelbl.Text + vbCrLf + "Employee Position:   " + EmpPostlbl.Text + vbCrLf + "Day Worked:   " + WorkedTb.Text + vbCrLf + "Daily Salary Rs:   " + Convert.ToString(Dailypay) + vbCrLf + "Total Amount Rs:  " + Convert.ToString(total)

        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Application.Exit()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub WorkedTb_TextChanged(sender As Object, e As EventArgs) Handles WorkedTb.TextChanged
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label8.Text = DateDiff(DateInterval.Day, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date) - TextBox1.Text
        WorkedTb.Text = DateDiff(DateInterval.Day, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date) - TextBox1.Text
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        EmpIdTb.Clear()
        WorkedTb.Clear()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SalaryTb_TextChanged(sender As Object, e As EventArgs) Handles MyBase.TextChanged

    End Sub

    Private Sub SalaryTb_TextChanged_1(sender As Object, e As EventArgs) Handles MyBaseTb.TextChanged

    End Sub
End Class