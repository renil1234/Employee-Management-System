Imports System.Data.SqlClient
Public Class Employee
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\renil\Documents\EmployeeVbDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Application.Exit()
    End Sub
    Private Sub Populate()
        Con.Open()
        Dim sql = "select * from EmployeeTbl"
        Dim adapater As SqlDataAdapter
        adapater = New SqlDataAdapter(sql, Con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapater)
        Dim ds As DataSet
        ds = New DataSet
        adapater.Fill(ds)
        EmployeeDGV.DataSource = ds.Tables(0)
        Con.Close()

    End Sub

    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Con.Open()
        Dim Query As String
        Query = "insert into EmployeeTbl values('" & EmpName.Text & "','" & EmpAdd.Text & "','" & PosCB.SelectedItem.ToString() & "','" & EmpDOB.Value & "','" & EmpPhoneTB.Text & "','" & EmpEdCb.SelectedItem.ToString() & "','" & GendCB.SelectedItem.ToString().ToString & "'  )"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(Query, Con)
        cmd.ExecuteNonQuery()
        MsgBox("Employee Added")
        clear()
        Con.Close()
    End Sub
    Dim key = 0
    Private Sub clear()
        EmpName.Clear()
        PosCB.Text = ""
        GendCB.Text = ""
        EmpAdd.Text = ""
        key = 0
        EmpEdCb.Text = ""
        EmpPhoneTB.Text = ""
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If key = 0 Then
            MsgBox("Selected The Employee To Delete")
        Else
            Try
                Con.Open()
                Dim Query As String
                Query = "Delete from EmployeeTbl where EmpId = " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(Query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Employee Deleted Successfully")
                Con.Close()
                Populate()
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub

    Private Sub EmployeeDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles EmployeeDGV.CellMouseClick
        Dim row As DataGridViewRow = EmployeeDGV.Rows(e.RowIndex)
        key = Convert.ToUInt32(row.Cells(0).Value.ToString())
        EmpName.Text = row.Cells(1).Value.ToString()
        EmpAdd.Text = row.Cells(2).Value.ToString()
        PosCB.SelectedItem = row.Cells(3).Value.ToString()
        EmpDOB.Value = row.Cells(4).Value.ToString()
        EmpPhoneTB.Text = row.Cells(5).Value.ToString()
        EmpEdCb.SelectedItem = row.Cells(6).Value.ToString()
        GendCB.SelectedItem = row.Cells(7).Value.ToString()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If EmpName.Text = "" Or EmpPhoneTB.Text = "" Or EmpAdd.Text = "" Then
            MsgBox("Missing Information")
        Else
            Con.Open()
            Dim Query As String
            Query = "Update EmployeeTbl set EmpName='" & EmpName.Text & "',EmpAdd='" & EmpAdd.Text & "',EmpPos='" & PosCB.SelectedItem.ToString() & "',EmpDob='" & EmpDOB.Value & "',EmpPhone='" & EmpPhoneTB.Text & "',EmpEdu='" & EmpEdCb.SelectedItem.ToString() & "',EmpGend='" & GendCB.SelectedItem.ToString() & "' where EmpId=" & key
            MsgBox(Query)

            Dim cmd As New SqlCommand(Query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Employee Updated")
            Con.Close()
            Populate()
            clear()

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Dim Main = New MainForm
        Main.Show()
        clear()
    End Sub

    Private Sub EmployeeDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles EmployeeDGV.CellContentClick, EmployeeDGV.CellContentClick, EmployeeDGV.CellContentClick, EmployeeDGV.CellContentClick, EmployeeDGV.CellContentClick

    End Sub
End Class