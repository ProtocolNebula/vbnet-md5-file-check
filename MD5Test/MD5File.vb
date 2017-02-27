Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

''' <summary>
''' Class for compare files with MD5
''' </summary>
''' <remarks></remarks>
Public Class MD5File

    ''' <summary>
    ''' Compare two files
    ''' If date is different it can be true, depending meta tags
    ''' TAKE CARE: If both files NOT EXIST, it return true
    ''' </summary>
    ''' <param name="path1"></param>
    ''' <param name="path2"></param>
    ''' <returns>Boolean if the md5 checks, false if one file not exist or not check</returns>
    ''' <remarks></remarks>
    Public Function compareFiles(ByVal path1 As String, ByVal path2 As String) As Boolean
        Dim md5Src As String = getMD5(path1)
        Dim md5Dest As String = getMD5(path2)

        Return md5Src = md5Dest
    End Function

    ''' <summary>
    ''' Compare a md5 hash with a file
    ''' </summary>
    ''' <param name="md5"></param>
    ''' <param name="path"></param>
    ''' <returns>Returns true if are equal. If file not exist return false</returns>
    Public Function compareFile(ByVal md5 As String, ByVal path As String) As Boolean
        Dim file As String = getMD5(path)

        Return file = md5
    End Function


    ''' <summary>
    ''' Returns a file MD5
    ''' </summary>
    ''' <param name="path">Path to the file</param>
    ''' <returns>MD5 hash</returns>
    Public Function getMD5(ByVal path As String) As String
        Dim tmpHash() As Byte = New Byte() {}
        Try
            Using fs As FileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None)
                tmpHash = New MD5CryptoServiceProvider().ComputeHash(fs)
            End Using

        Catch ex As Exception
            Return Nothing
        End Try

        Return ByteArrayToString(tmpHash)
    End Function

    ''' <summary>
    ''' Convert a Byte Array to String
    ''' </summary>
    ''' <param name="arrInput"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ByteArrayToString(ByVal arrInput() As Byte) As String
        Dim i As Integer
        Dim sOutput As New StringBuilder(arrInput.Length)
        For i = 0 To arrInput.Length - 1
            sOutput.Append(arrInput(i).ToString("X2"))
        Next
        Return sOutput.ToString()
    End Function
End Class
