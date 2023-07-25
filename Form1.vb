Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UidTB.Clear()
        PassTB.Clear()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If UidTB.Text = "" Or PassTB.Text = "" Then
            MsgBox("Enter The Id and Password")
        ElseIf UidTB.Text = "User" And PassTB.Text = "Password" Then
            Dim Main = New MainForm
            Main.Show()
            Me.Hide()
        Else
            MsgBox("Wrong User Name or Password")

        End If
    End Sub
End Class
