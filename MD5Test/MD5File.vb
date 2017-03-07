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
        'Check types
        Dim path1Type As Integer = checkType(path1),
            path2Type As Integer = checkType(path2)

        If Not path1Type Or path1Type <> path2Type Then
            Throw New Exception("Both path must exist and be the same type")
        End If

        Dim md5Src As String = getMD5(path1),
            md5Dest As String = getMD5(path2)

        Return md5Src = md5Dest
    End Function

    ''' <summary>
    ''' Detect the type of path and compare it with a md5
    ''' </summary>
    ''' <param name="md5"></param>
    ''' <param name="path"></param>
    ''' <returns>True/False if md5 checks.
    ''' If the path no exist it returns false</returns>
    ''' <remarks></remarks>
    Public Function compare(ByVal md5 As String, ByVal path As String) As Boolean
        Dim type As Integer = checkType(path)

        If type = 1 Then
            Return compareFolder(md5, path)
        ElseIf type = 2 Then
            Return compareFile(md5, path)
        End If

        Return False

    End Function

    ''' <summary>
    ''' Compare a md5 hash with a file
    ''' </summary>
    ''' <param name="md5"></param>
    ''' <param name="path">Directory path</param>
    ''' <returns>Returns true if are equal. If file not exist return false</returns>
    Public Function compareFile(ByVal md5 As String, ByVal path As String) As Boolean
        Dim file As String = getMD5(path)

        Return file = md5
    End Function

    ''' <summary>
    ''' Compare a md5 hash with a content folder
    ''' It make an MD5 of all MD5 files.
    ''' Use this function if you DON'T NEED the new MD5
    ''' </summary>
    ''' <param name="md5"></param>
    ''' <param name="path">Directory path</param>
    ''' <returns>Returns true if are equal. If file not exist return false</returns>
    Public Function compareFolder(ByVal md5 As String, ByVal path As String) As Boolean
        Dim md5Checksum As StringBuilder = New StringBuilder()


        Return False
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


    Public Function getMD5Dir(ByVal path As String) As String
        Dim md5Checksum As StringBuilder = New StringBuilder()


    End Function


#Region "Helpers"
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

    ''' <summary>
    ''' Check if a path is File or Folder
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns>0=No exist, 1=Dir, 2=File</returns>
    ''' <remarks></remarks>
    Private Function checkType(path As String) As Integer
        If System.IO.File.Exists(path) Then
            Return 1
        ElseIf System.IO.File.Exists(path) Then
            Return 2
        End If

        Return 0
    End Function
#End Region

End Class
