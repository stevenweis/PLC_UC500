Imports Microsoft.VisualBasic.FileIO
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.Data.OleDb
'讀取外部txt,csv,xlx
Public Class ClassTxtWR
    Private Adata() As String
    Private present_folder As String
    Private data_folder As String
    Private dirpath As String = Application.StartupPath '執行路徑

#Region "建構"
    Public Sub New()
        Dim splitpath() As String = Split(dirpath, ":")
        present_folder = splitpath(0) + ":"
        data_folder = splitpath(1) + "\"
    End Sub

    Public Sub New(folder As String)
        Dim splitpath() As String = Split(dirpath, ":")
        present_folder = splitpath(0) + ":"
        data_folder = splitpath(1) + "\" + folder + "\"
    End Sub
    ''' <summary>
    ''' 可設定路徑
    ''' </summary>
    ''' <param name="folder_set">槽位</param>
    ''' <param name="folder">路徑</param>
    Public Sub New(ByVal folder_set As String, ByVal folder As String)
        present_folder = folder_set & ":\"
        data_folder = folder & "\"
    End Sub

#End Region


#Region "檔案讀取"

    ''' <summary>
    ''' 讀取文字檔
    ''' </summary>
    ''' <param name="file_name"> 讀取之檔名</param>
    ''' <returns> 矩陣string(以"," 分隔存成矩陣) </returns>

    Public Function TxtRead_Row(ByVal file_name As String) As String()
        'Dim path As String
        'path = CurDir()

        Dim O_file = My.Computer.FileSystem.OpenTextFileReader(present_folder + data_folder + file_name, Encoding.Default)
        Dim stringReader As String = ""
        Dim temp_str As String
        Do While O_file.Peek() >= 0
            temp_str = O_file.ReadLine()
            If stringReader = "" Then
                stringReader = temp_str
            Else
                stringReader = stringReader + temp_str
            End If
        Loop
        O_file.Close()
        Return Strings.Split(stringReader, Delimiter:=",")
    End Function

    ''' <summary>
    ''' 直接讀取文字檔()
    ''' </summary>
    ''' <param name="filename"> 文件檔名string </param>
    ''' <returns> 矩陣 string </returns>
    Public Function TxtRead_Col(ByVal filename As String) As String()
        'Dim path As String
        'Path = CurDir()

        Dim O_file = My.Computer.FileSystem.OpenTextFileReader(present_folder + data_folder + filename, Encoding.Default)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = O_file.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        O_file.Close()
        Dim a() As String = CType(arrText.ToArray(GetType(String)), String())
        Return a
    End Function

    ''' <summary>
    ''' 讀取文字檔
    ''' </summary>
    ''' <param name="filename"> 文件檔名string </param>
    ''' <param name="file"> 參考類型List(of string) </param>
    Public Sub TxtRead_test2(ByVal filename As String, ByRef file As List(Of String))
        'Dim path As String
        'Path = CurDir()
        Dim O_file = My.Computer.FileSystem.OpenTextFileReader(present_folder + data_folder + filename, Encoding.UTF8)
        Dim sLine As String = ""
        '       Dim arrText As New ArrayList()   
        Do
            sLine = O_file.ReadLine()
            If Not sLine Is Nothing Then
                file.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        O_file.Close()
    End Sub
    ''' <summary>
    ''' 讀取文字檔
    ''' </summary>
    ''' <param name="filename">文件檔名string</param>
    ''' <param name="file">參考類型Dictionary(Of Integer, String)</param>
    Public Sub TxtReadofDictionary(ByVal filename As String, ByRef file As Dictionary(Of Integer, String))
        Dim cnt As Integer
        Dim O_file = My.Computer.FileSystem.OpenTextFileReader(present_folder + data_folder + filename, Encoding.Default)
        Dim sLine As String = ""
        '       Dim arrText As New ArrayList()   
        Do
            sLine = O_file.ReadLine()
            If Not sLine Is Nothing Then
                cnt += 1
                file.Add(cnt, sLine)
            End If
        Loop Until sLine Is Nothing
        O_file.Close()

    End Sub
    ''' <summary>
    ''' List(Of String) 讀取文字檔(與第一行分離) 用於分開外掛檔 PLC通道參數
    ''' </summary>
    ''' <param name="filename"> 文件檔名 </param>
    ''' <param name="file"> 參考型 List(Of String) </param>
    ''' <param name="splititem">  參考型 String(PLC通道參數) </param>
    Public Sub TxtRead_splittest2(ByVal filename As String, ByRef file As List(Of String), ByRef splititem As String)
        'Dim path As String
        'Path = CurDir()
        Dim O_file = My.Computer.FileSystem.OpenTextFileReader(present_folder + data_folder + filename, Encoding.Default)
        Dim sLine As String = ""
        '       Dim arrText As New ArrayList()   
        Dim splitdm As Integer
        Do
            sLine = O_file.ReadLine()

            If Not sLine Is Nothing Then
                If splitdm = 0 Then
                    splititem = sLine
                    splitdm += 1
                Else
                    file.Add(sLine)
                End If
            End If
        Loop Until sLine Is Nothing
        O_file.Close()
        'Dim a() As String = CType(arrText.ToArray(GetType(String)), String())
        'Return a
    End Sub
    ''' <summary>
    ''' Dictionary(Of Integer, String) 讀取文字檔(與第一行分離) 用於分開外掛檔 PLC通道參數 
    ''' </summary>
    ''' <param name="filename"> 文件檔名 </param>
    ''' <param name="file">參考型 Dictionary(Of Integer, String)</param>
    ''' <param name="splititem"> 參考型 String(PLC通道參數) </param>
    Public Sub TxtRead_splitDictionary(ByVal filename As String, ByRef file As Dictionary(Of Integer, String), ByRef splititem As String)

        Dim O_file = My.Computer.FileSystem.OpenTextFileReader(present_folder + data_folder + filename, Encoding.Default)
        Dim sLine As String = ""
        Dim splitdm As Integer
        Do
            sLine = O_file.ReadLine()

            If Not sLine Is Nothing Then
                If splitdm = 0 Then
                    splititem = sLine
                    splitdm += 1
                Else
                    file.Add(Mid(sLine, 1, 3), Mid(sLine, 4, Len(sLine) - 3))
                End If
            End If
        Loop Until sLine Is Nothing
        O_file.Close()
        'Dim a() As String = CType(arrText.ToArray(GetType(String)), String())
        'Return a
    End Sub

    Public Sub TxtRead_test(ByVal filename As String, ByRef file As Dictionary(Of String, String))
        'Dim path As String
        'Path = CurDir()

        Dim O_file = My.Computer.FileSystem.OpenTextFileReader(present_folder + data_folder + filename, Encoding.Default)
        Dim sLine As String '= ""
        'Dim arrText As New ArrayList()
        Dim i As Integer
        Do
            sLine = O_file.ReadLine()
            If Not sLine = "" Then

                Dim temp_sline() As String = Strings.Split(sLine, ",")
                file.Add(temp_sline(0), temp_sline(1) & "," & temp_sline(2))

            End If
            i += 1
        Loop Until sLine Is Nothing
        O_file.Close()
        'Dim a() As String = CType(arrText.ToArray(GetType(String)), String())
        'Return a
    End Sub
    Public Sub TxtRead_dictionary4stute(ByVal filename As String, ByRef file As Dictionary(Of Integer, String))
        'Dim path As String
        'Path = CurDir()

        Dim O_file = My.Computer.FileSystem.OpenTextFileReader(present_folder + data_folder + filename, Encoding.Default)
        Dim sLine As String '= ""
        'Dim arrText As New ArrayList()
        Dim i As Integer
        Do
            sLine = O_file.ReadLine()
            If Not sLine = "" Then

                Dim temp_sline() As String = Strings.Split(sLine, ":")
                file.Add(temp_sline(0), temp_sline(1))

            End If
            i += 1
        Loop Until sLine Is Nothing
        O_file.Close()
    End Sub
    Public Sub TxtRead_DAT(ByVal filename As String, ByRef file As Dictionary(Of String, String))
        'Dim path As String
        'Path = CurDir()

        Dim O_file = My.Computer.FileSystem.OpenTextFileReader(present_folder + data_folder + filename, Encoding.Default)
        Dim sLine As String '= ""
        'Dim arrText As New ArrayList()
        Dim i As Integer
        Do
            sLine = O_file.ReadLine()
            If Not sLine = "" Then

                Dim temp_sline() As String = Strings.Split(sLine, ",")
                'file.Add(temp_sline(0), temp_sline(1) & "," & temp_sline(2) & "," & temp_sline(3) & "," & temp_sline(4))
                file.Add(temp_sline(0), sLine)
            End If
            i += 1
        Loop Until sLine Is Nothing
        O_file.Close()
        'Dim a() As String = CType(arrText.ToArray(GetType(String)), String())
        'Return a
    End Sub

    ''' <summary>
    ''' 讀取資料夾所有檔案
    ''' </summary>
    ''' <param name="file"> 參考值 泛型有鍵值 </param>
    Public Sub GETFILE_DAT(ByRef file As List(Of String))
        'Dim path As String
        'Path = CurDir()

        Dim O_file() = Directory.GetFiles(present_folder + data_folder) '檔案陣列
        For Each str As String In O_file
            Dim temp As String = str.Substring(str.LastIndexOf("\") + 1) '讀取檔名
            Dim temp_split() As String = Split(temp, ".")
            file.Add(temp)
        Next
    End Sub

    'Public Function TxtRead2_Col(ByRef filename As String) As String()
    '    'Dim MSTRconn_1 As String = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\TEST01\;Extended Properties='Text;HDR=NO;FMT=Delimited( );CharacterSet=65001'"
    '    Dim MSTRconn_1 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\Desktop\100萬筆資料;Extended Properties='Text;HDR=NO;FMT=Delimited( );CharacterSet=65001'"

    '    Dim Mstrsql_1 = "Select * from 7pin_L.txt"
    '    Dim Oconn_1 As New OleDbConnection(MSTRconn_1)
    '    Oconn_1.Open()
    '    Dim ODataAdapter_1 As New OleDbDataAdapter(Mstrsql_1, Oconn_1)

    '    Dim ODataSet_1 As DataSet = New DataSet
    '    ODataAdapter_1.Fill(ODataSet_1, "Table01")
    '    ' DataGridView1.DataSource = Nothing
    '    'DataGridView1.DataSource = ODataSet_1.Tables("Table01")
    '    Oconn_1.Close()
    '    ODataAdapter_1.Dispose()
    'End Function
#End Region
    '===============================================
    '讀取一維矩陣

#Region "檔案寫入"
    '======= CSV檔案 =================================
    '****一維陣列****
    ' 引數0 (行向量)
    ' 引數1 (列向量)
    Public Sub CsvWrite_1Dim(ByVal dataWrite() As String, ByVal type As Byte)

        Dim o_file = My.Computer.FileSystem.OpenTextFileWriter(present_folder + data_folder + "TestA.csv", False, Encoding.Default)
        Dim leng_data As Array = dataWrite
        Dim colstr As String = ""

        For Mrow = 0 To leng_data.Length - 1
            colstr = ""
            Select Case type
                Case "1"
                    If Mrow = leng_data.Length - 1 Then
                        colstr = dataWrite(Mrow)
                    Else
                        colstr = dataWrite(Mrow) + ","
                    End If
                Case "0"
                    colstr = ""
                    colstr = dataWrite(Mrow) + Chr(13) + Chr(10)
            End Select
            o_file.Write(colstr)
        Next
        o_file.Close()
        MsgBox("資料已寫入" + present_folder + data_folder + "TestA.csv！", 0 + 64, "OK")
    End Sub

    Public Sub datawrite(ByVal dataWrite As String, ByVal filename As String)

        Dim o_file = My.Computer.FileSystem.OpenTextFileWriter(present_folder + data_folder + filename, False, Encoding.Default)

        o_file.Write(dataWrite)
        o_file.Close()

    End Sub

    Public Sub Replacetxt(ByVal filename As String, ByVal data As String)
        My.Computer.FileSystem.CopyFile(present_folder + data_folder + filename, present_folder + data_folder + filename & "1")
        Dim o_file2 = My.Computer.FileSystem.OpenTextFileReader(present_folder + data_folder + filename, Encoding.Default)
        Dim o_file = My.Computer.FileSystem.OpenTextFileWriter(present_folder + data_folder + filename & "1", False, Encoding.Default)
        Dim tempstr() As String = Split(data, ",")
        Dim sLine As String = ""

        Dim writedata As String = ""
        Dim cnt As Integer

        Do
            sLine = o_file2.ReadLine()
            If Not sLine Is Nothing Then
                If cnt = tempstr(0) Then

                    Dim strjoint As String = ""
                    For i = 0 To tempstr.Length - 1
                        If i = 0 Or i = tempstr.Length - 1 Then
                            Continue For
                        Else
                            strjoint = strjoint & tempstr(i) & ","
                        End If
                    Next
                    writedata = writedata & strjoint & vbCrLf
                Else
                    writedata = writedata & sLine & vbCrLf
                End If
            End If
            cnt += 1
        Loop Until sLine Is Nothing
        o_file2.Close()
        o_file.Write(writedata)
        o_file.Close()

        My.Computer.FileSystem.DeleteFile(present_folder + data_folder + filename)
        My.Computer.FileSystem.RenameFile(present_folder + data_folder + filename & "1", filename)

        'MsgBox("資料已寫入" + present_folder + data_folder + "TestA.csv！", 0 + 64, "OK")
    End Sub

    '****二維陣列****
    Public Sub CsvWrite_2Dim(ByVal dataWrite(,) As String)
        Dim o_file = My.Computer.FileSystem.OpenTextFileWriter(present_folder + data_folder + "TestA.csv", False, Encoding.Default)
        Dim leng_data As Array = dataWrite
        Dim colstr As String = ""
        For Mrow As Integer = 0 To leng_data.GetLength(0) - 1
            For Mcol As Integer = 0 To leng_data.GetLength(1) - 1
                If Mcol = leng_data.GetLength(1) - 1 Then
                    colstr = dataWrite(Mrow, Mcol) + Chr(13) + Chr(10)
                Else
                    colstr = dataWrite(Mrow, Mcol) + ","  'vbTab
                End If
                o_file.Write(colstr)
            Next
        Next
        o_file.Close()
        MsgBox("資料已寫入" + present_folder + data_folder + "TestA.csv！", 0 + 64, "OK")
    End Sub

    '======= TXT檔案 =================================
    '****一維陣列****
    ' 引數0 (行向量)
    ' 引數1 (列向量)
    Public Sub TxtWrite_1Dim(ByVal dataWrite() As String, ByVal type As Byte)

        Dim o_file = My.Computer.FileSystem.OpenTextFileWriter(present_folder + data_folder + "TestA.txt", False, Encoding.Default)
        Dim leng_data As Array = dataWrite
        Dim colstr As String = ""

        For Mrow = 0 To leng_data.Length - 1
            colstr = ""
            Select Case type
                Case "1"
                    If Mrow = leng_data.Length - 1 Then
                        colstr = dataWrite(Mrow)
                    Else
                        colstr = dataWrite(Mrow) + ","
                    End If
                Case "0"
                    colstr = ""
                    colstr = dataWrite(Mrow) + Chr(13) + Chr(10)
            End Select
            o_file.Write(colstr)
        Next
        o_file.Close()
        MsgBox("資料已寫入" + present_folder + data_folder + "TestA.txt！", 0 + 64, "OK")
    End Sub
    '****二維陣列****
    Public Sub TxtWrite_2Dim(ByVal dataWrite(,) As String)
        Dim o_file = My.Computer.FileSystem.OpenTextFileWriter(present_folder + data_folder + "TestA.txt", False, Encoding.Default)
        Dim leng_data As Array = dataWrite
        Dim colstr As String = ""
        For Mrow As Integer = 0 To leng_data.GetLength(0) - 1
            For Mcol As Integer = 0 To leng_data.GetLength(1) - 1
                If Mcol = leng_data.GetLength(1) - 1 Then
                    colstr = dataWrite(Mrow, Mcol) + Chr(13) + Chr(10)
                Else
                    colstr = dataWrite(Mrow, Mcol) + ","  'vbTab
                End If
                o_file.Write(colstr)
            Next
        Next
        o_file.Close()
        MsgBox("資料已寫入" + present_folder + data_folder + "TestA.txt！", 0 + 64, "OK")
    End Sub

#End Region

    'Public Sub findkeytype(ByRef alltype() As String)
    '    Directory.GetFiles(Presetpathdrive & Presetpathlocation, "*.DAT")

    'End Sub


    '資料夾建立 預設C:\
    Public Sub file_folder_create()
        If My.Computer.FileSystem.DirectoryExists(present_folder + data_folder) = True Then
            MsgBox(present_folder + data_folder + " 資料夾已存在！", 0 + 64, "OK")
        Else
            My.Computer.FileSystem.CreateDirectory(present_folder + data_folder)
            MsgBox(present_folder + data_folder + " 資料夾已新增！", 0 + 64, "OK")
        End If
    End Sub

End Class
