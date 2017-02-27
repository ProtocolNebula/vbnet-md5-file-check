
Imports System
Imports System.Security
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim md5 As MD5File = New MD5File()

        If md5.compareFiles(TextBox1.Text, TextBox2.Text) Then
            MessageBox.Show("Are equal! :)")
        Else
            MessageBox.Show("Are different :(")
        End If
    End Sub

End Class
