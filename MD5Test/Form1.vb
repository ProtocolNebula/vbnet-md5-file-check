
Imports System
Imports System.Security
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim path1 As String = TextBox1.Text,
            path2 As String = TextBox2.Text

        Dim md5 As MD5File = New MD5File()

        Try
            If md5.compareFiles(path1, path2) Then
                MessageBox.Show("Are equal! :)")
            Else
                MessageBox.Show("Are different :(")
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR: " + ex.Message)
        End Try
        
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://github.com/ProtocolNebula/vbnet-md5-file-check")
    End Sub
End Class
