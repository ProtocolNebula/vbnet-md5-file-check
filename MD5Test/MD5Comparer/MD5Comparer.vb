Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

''' <summary>
''' Class for compare files with MD5
''' </summary>
''' <remarks></remarks>
Public Class MD5Comparer

    Private stringMD5 As MD5 = MD5.Create()
    Private fileMD5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
    Private _checkSubfolders As Boolean = True
    Private _sensitiveSubfolders As Boolean = True

    Private _lastHash1 As String
    Private _lastHash2 As String

    ''' <summary>
    ''' If is true it will check the subfolders when path is a folder.
    ''' True by default
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property checkSubfolders As Boolean
        Get
            Return _checkSubfolders
        End Get
        Set(value As Boolean)
            _checkSubfolders = value
        End Set
    End Property

    ''' <summary>
    ''' If is true, the name of the folders will affect to the end md5
    ''' checkSubfolders must be true
    ''' True by default
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property sensitiveSubfolders As Boolean
        Get
            Return _sensitiveSubfolders
        End Get
        Set(value As Boolean)
            _sensitiveSubfolders = value
        End Set
    End Property


    ''' <summary>
    ''' Returns the last MD5 used/generated for the first path/hash
    ''' If used a "compare hybrid" it will be the String (HASH) (1rst parameter)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property lastHash1 As String
        Get
            Return _lastHash1
        End Get
    End Property

    ''' <summary>
    ''' Returns the last MD5 used/generated for the first path/hash
    ''' If used a "compare hybrid" it will be the File/Folder (2nd parameter)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property lastHash2 As String
        Get
            Return _lastHash2
        End Get
    End Property



#Region "MD5 calculators"
    ''' <summary>
    ''' Returns a MD5 form a FILE. Maybe you need "getMD5Dir"
    ''' </summary>
    ''' <param name="path">Path to the file</param>
    ''' <returns>MD5 hash</returns>
    ''' <exception cref="MD5ComparerException">Throw error if path not exist or is not a file</exception>
    Public Function getMD5(ByVal path As String) As String
        'Only existing files!
        If Not System.IO.File.Exists(path) Then Throw New MD5ComparerException(path + " no exist or is not a file")

        Dim tmpHash() As Byte = New Byte() {}

        Try
            Using fs As FileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None)
                tmpHash = fileMD5.ComputeHash(fs)
            End Using
        Catch ex As Exception
            Throw New MD5ComparerException(ex.Message)
        End Try

        Return ByteArrayToString(tmpHash)
    End Function

    ''' <summary>
    ''' Get the MD5 of a content folder from an DirectoryInfo instance
    ''' WARNING: The name of every file will affect to the md5, not only the content
    ''' </summary>
    ''' <param name="dir"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getMD5Dir(ByVal dir As DirectoryInfo) As String
        Dim md5Checksum As StringBuilder = New StringBuilder()

        If dir.GetFiles.Count > 0 Then
            'Check all subfolders
            If checkSubfolders Then
                For Each subdir In dir.GetDirectories
                    If sensitiveSubfolders Then md5Checksum.Append(subdir.Name)
                    md5Checksum.Append(getMD5Dir(subdir))
                Next
            End If

            'Check all files
            For Each file In dir.GetFiles
                md5Checksum.Append(file.Name)
                md5Checksum.Append(getMD5(file.FullName))
            Next
        End If


        Return ByteArrayToString(
            stringMD5.ComputeHash(Encoding.UTF8.GetBytes(md5Checksum.ToString()))
        )

    End Function
#End Region

#Region "Public Comparators"

    'Generic

    ''' <summary>
    ''' Compare two paths (must be the same type)
    ''' </summary>
    ''' <param name="path1"></param>
    ''' <param name="path2"></param>
    ''' <returns>True if both are equal</returns>
    ''' <exception cref="MD5ComparerException">Throw error if some path not exist or are different types (file/folder)</exception>
    Public Function comparePath(ByVal path1 As String, ByVal path2 As String) As Boolean

        Dim path1Type As Integer = checkType(path1),
            path2Type As Integer = checkType(path2)

        If path1Type = 0 Or path1Type <> path2Type Then
            Throw New MD5ComparerException("Both path must exist and be the same type")
        End If

        If path1Type = 1 Then
            'Directory
            Return compare(New DirectoryInfo(path1), New DirectoryInfo(path2))
        End If

        Return compare(getMD5(path1), getMD5(path2))

    End Function

    ''' <summary>
    ''' Compare two MD5 hashes
    ''' </summary>
    ''' <param name="hash1"></param>
    ''' <param name="hash2"></param>
    ''' <returns>True if both are equal</returns>
    ''' <remarks></remarks>
    Public Function compare(ByVal hash1 As String, ByVal hash2 As String) As Boolean
        _lastHash1 = hash1
        _lastHash2 = hash2
        Return hash1 = hash2
    End Function


    'Files

    ''' <summary>
    ''' Compare a file with a hash
    ''' </summary>
    ''' <param name="hash"></param>
    ''' <param name="file"></param>
    ''' <returns>True if both are equal</returns>
    ''' <exception cref="Exception"></exception>
    Public Function compare(ByVal hash As String, ByVal file As FileInfo) As Boolean
        Return compare(hash, getMD5(file.FullName))
    End Function

    ''' <summary>
    ''' Compare two files
    ''' </summary>
    ''' <param name="file1"></param>
    ''' <param name="file2"></param>
    ''' <returns>True if both are equal</returns>
    ''' <exception cref="Exception"></exception>
    Public Function compare(ByVal file1 As FileInfo, ByVal file2 As FileInfo) As Boolean
        Return compare(getMD5(file1.FullName), getMD5(file2.FullName))
    End Function


    'Directories

    ''' <summary>
    ''' Compare a directory with a hash
    ''' </summary>
    ''' <param name="hash"></param>
    ''' <param name="dir"></param>
    ''' <returns>True if both are equal</returns>
    ''' <exception cref="Exception"></exception>
    Public Function compare(ByVal hash As String, ByVal dir As DirectoryInfo) As Boolean
        Return compare(hash, getMD5Dir(dir))
    End Function

    ''' <summary>
    ''' Compare two directories
    ''' </summary>
    ''' <param name="dir1"></param>
    ''' <param name="dir2"></param>
    ''' <returns>True if both are equal</returns>
    ''' <exception cref="Exception"></exception>
    Public Function compare(ByVal dir1 As DirectoryInfo, ByVal dir2 As DirectoryInfo) As Boolean
        Return compare(getMD5Dir(dir1), getMD5Dir(dir2))
    End Function
#End Region


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
            Return 2
        ElseIf System.IO.Directory.Exists(path) Then
            Return 1
        End If

        Return 0
    End Function
#End Region

End Class
