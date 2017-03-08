
Imports System
Imports System.Security
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim path1 As String = TextBox1.Text,
            path2 As String = TextBox2.Text

        Dim md5 As MD5Comparer = New MD5Comparer()

        md5.checkSubfolders = chkCompareSubfolders.Checked
        md5.sensitiveSubfolders = chkSensitiveSubfolders.Checked

        Try
            If md5.comparePath(path1, path2) Then
                MessageBox.Show("Are equal! :)")
            Else
                MessageBox.Show("Are different :(")
            End If

            MessageBox.Show("HASH 1: " & md5.lastHash1 & vbCrLf &
                            "HASH 2: " & md5.lastHash2)
        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)
        End Try

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://github.com/ProtocolNebula/vbnet-md5-file-check")
    End Sub

    Private Sub chkCompareSubfolders_CheckedChanged(sender As Object, e As EventArgs) Handles chkCompareSubfolders.CheckedChanged
        chkSensitiveSubfolders.Enabled = chkCompareSubfolders.Checked
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkSensitiveSubfolders.Enabled = chkCompareSubfolders.Checked
    End Sub
End Class
