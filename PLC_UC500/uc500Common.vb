Imports System.Text

Public Class uc500Common
    Private CommandTX As String '傳送指令(TX)
    Private ReciveRX As New List(Of Byte) '接收指令(RX)
    Dim UC500serialport As New SerialPort4Machine
    Private PortON_flag As Boolean
    Private particularMode As Byte

    Public Enum MarkType
        Vertical = 0 '垂直
        horizontal = 1 '水平
        Vertical_Reverse = 2 '垂直反向
        horizontal_Reverse = 3 '水平反向
        Vertical_twoLine = 4 '垂直二行
        horizontal_twoLine = 5 '水平二行
        Vertical_Reverse_twoLine = 6 '垂直反向二行
        horizontal_Reverse_twoLine = 7 '水平反向二行
        'Arc = 4 '圓弧
        'Arc_Reverse = 5 '圓弧反向
    End Enum

    ''' <summary>
    ''' 通訊阜開啟旗標
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property getPortON_flag() As Boolean
        Get
            Return PortON_flag
        End Get
    End Property

    ''' <summary>
    ''' 得到TX資料
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property getcommandTX() As String
        Get
            Return CommandTX
        End Get
    End Property
    ''' <summary>
    ''' RX資料
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property getReciveRX() As List(Of Byte)
        Get
            Return ReciveRX
        End Get
    End Property
    Public WriteOnly Property GetMode() As Byte
        Set(ByVal value As Byte)
            particularMode = value
        End Set
    End Property

#Region " Events "

#End Region

#Region "各參數屬性"
    Private MarkMode As String '打字模式(L OR C)
    Private Markspeed As Byte '打字速度
    Private Movespeed As Byte '移動速度
    Private QC As Byte '品質
    '=============================================
    Private MarkX As String '打標位置1_X
    Private MarkY As String '打標位置1_Y
    Private MarkX_two As String '打標位置2_X
    Private MarkY_two As String '打標位置2_Y
    Private lineSpace As String ' 行間距
    '=============================================
    Private MarkForce As String '打字力道
    'Private MarkPoint As String '打字點數(每mm)
    Private Heigth As String '字高
    Private Width As Byte '字寬
    Private Between As Byte '間距
    Private Angle_L As String '角度(L線性模式)
    Private Angle_C As String '角度(C圓弧模式)
    Private radius_C As String '半徑(C圓弧模式)
    Private CorW_C As String '順逆時針(C圓弧模式)

    Private offsetAngle As SByte '角度微調
    Private Font As Byte
    Private line1 As String = "[V0]" '
    Private line2 As String = "[V1]" '

    Private lineCnt As Byte = 1 '行數(1 = 一行, 2 = 兩行)
    ''' <summary>
    ''' 每行幾個字
    ''' </summary>
    Public WriteOnly Property setlinecnt() As Byte
        Set(ByVal value As Byte)
            lineCnt = value
        End Set
    End Property

    ''' <summary>
    ''' 打字模式(L , C)
    ''' </summary>
    ''' <returns></returns>
    Public Property setMarkMode() As String
        Get
            Return MarkMode
        End Get
        Set(ByVal value As String)
            MarkMode = value
        End Set
    End Property
    ''' <summary>
    ''' 打字速度
    ''' </summary>
    ''' <returns></returns>
    Public Property setMarkspeed() As Byte
        Get
            Return Markspeed
        End Get
        Set(ByVal value As Byte)
            If value > 100 Then
                Markspeed = 100
            Else
                Markspeed = value
            End If
        End Set
    End Property
    ''' <summary>
    ''' 移動速度
    ''' </summary>
    ''' <returns></returns>
    Public Property setMovespeed() As Byte
        Get
            Return Movespeed
        End Get
        Set(ByVal value As Byte)

            If value > 100 Then
                Movespeed = 100
            Else
                Movespeed = value
            End If
        End Set
    End Property
    ''' <summary>
    ''' 打字品質
    ''' </summary>
    ''' <returns></returns>
    Public Property setQC() As Byte
        Get
            Return QC
        End Get
        Set(ByVal value As Byte)

            If value > 100 Then
                QC = 100
            Else
                QC = value
            End If
        End Set
    End Property
    '==========打字位置=====================================
    ''' <summary>
    ''' 位置1 X軸
    ''' </summary>
    ''' <returns></returns>
    Public Property setMarkX() As String
        Get
            Return MarkX
        End Get
        Set(ByVal value As String)
            MarkX = value
        End Set
    End Property
    ''' <summary>
    ''' 位置1 Y軸
    ''' </summary>
    ''' <returns></returns>
    Public Property setMarkY() As String
        Get
            Return MarkY
        End Get
        Set(ByVal value As String)
            MarkY = value
        End Set
    End Property
    ''' <summary>
    ''' 位置2 X軸
    ''' </summary>
    ''' <returns></returns>
    Public Property setMarkX_two() As String
        Get
            Return MarkX_two
        End Get
        Set(ByVal value As String)
            MarkX_two = value
        End Set
    End Property
    ''' <summary>
    ''' 位置2 Y軸
    ''' </summary>
    ''' <returns></returns>
    Public Property setMarkY_two() As String
        Get
            Return MarkY_two
        End Get
        Set(ByVal value As String)
            MarkY_two = value
        End Set
    End Property
    ''' <summary>
    ''' 兩行間距
    ''' </summary>
    ''' <returns></returns>
    Public Property setLineSpace() As String
        Get
            Return lineSpace
        End Get
        Set(ByVal value As String)
            lineSpace = value
        End Set
    End Property
    '==============================================
    ''' <summary>
    ''' 打字力道
    ''' </summary>
    ''' <returns></returns>
    Public Property setMarkForce() As String
        Get
            Return MarkForce
        End Get
        Set(ByVal value As String)
            MarkForce = value
        End Set
    End Property

    '''' <summary>
    '''' 每mm點數
    '''' </summary>
    '''' <returns></returns>
    'Public Property setMarkPoint() As String
    '    Get
    '        Return MarkPoint
    '    End Get
    '    Set(ByVal value As String)
    '        MarkPoint = value
    '    End Set
    'End Property

    ''' <summary>
    ''' 字高
    ''' </summary>
    ''' <returns></returns>
    Public Property setHeigth() As String
        Get
            Return Heigth
        End Get
        Set(ByVal value As String)
            Heigth = value
        End Set
    End Property

    ''' <summary>
    ''' 字寬
    ''' </summary>
    ''' <returns></returns>
    Public Property setWidth() As String
        Get
            Return Width / 50
        End Get
        Set(ByVal value As String)
            'If value > 100 Then
            '    Width = 100
            'Else
            '    Width = value
            'End If
            Width = (50 * value)
        End Set
    End Property

    ''' <summary>
    ''' 字間距
    ''' </summary>
    ''' <returns></returns>
    Public Property setBetween() As String
        Get
            Return (Between / 200) * (Width / 50)
        End Get
        Set(ByVal value As String)
            Between = 200 * (value / (Width / 50))
        End Set
    End Property

    ''' <summary>
    ''' 角度(L模式)
    ''' </summary>
    ''' <returns></returns>
    Public Property setAngle_L() As String
        Get
            Return Angle_L
        End Get
        Set(ByVal value As String)
            Angle_L = value
        End Set
    End Property
    ''' <summary>
    ''' 角度微調(L模式)
    ''' </summary>
    ''' <returns></returns>
    Public Property setOffsetAngle() As SByte
        Get
            Return offsetAngle
        End Get
        Set(ByVal value As SByte)
            offsetAngle = value
        End Set
    End Property
    ''' <summary>
    ''' 角度微調(L模式)
    ''' </summary>
    ''' <returns></returns>
    Public Property setFont() As Byte
        Get
            Return Font
        End Get
        Set(ByVal value As Byte)
            Font = value
        End Set
    End Property

    ''' <summary>
    ''' 角度(C模式)
    ''' </summary>
    ''' <returns></returns>
    Public Property setAngle_C() As String
        Get
            Return Angle_C
        End Get
        Set(ByVal value As String)
            Angle_C = value
        End Set
    End Property

    ''' <summary>
    ''' 半徑(C模式)
    ''' </summary>
    ''' <returns></returns>
    Public Property setradius_C() As String
        Get
            Return radius_C
        End Get
        Set(ByVal value As String)
            radius_C = value
        End Set
    End Property

    ''' <summary>
    ''' 順逆時針(C模式)
    ''' </summary>
    ''' <returns></returns>
    Public Property setCorW_C() As String
        Get
            Return CorW_C
        End Get
        Set(ByVal value As String)
            CorW_C = value
        End Set
    End Property
    ''' <summary>
    ''' 第一行字串
    ''' </summary>
    ''' <returns></returns>
    Public Property setline1() As String
        Get
            Return line1
        End Get
        Set(ByVal value As String)
            line1 = value
        End Set
    End Property
    ''' <summary>
    ''' 第二行字串
    ''' </summary>
    ''' <returns></returns>
    Public Property setline2() As String
        Get
            Return line2
        End Get
        Set(ByVal value As String)
            line2 = value
        End Set
    End Property
#End Region

#Region "編碼及解碼"
    Private Function GetSendBuffer(ByVal content As String) As Byte()
        Dim dataBytes() As Byte = Encoding.UTF8.GetBytes(content)
        Return dataBytes
    End Function
    Private Sub Encode_Tx(txStr As String)
        Dim cmdTmep As String = ""
        Dim _temp = txStr.ToArray
        For i = 0 To _temp.Count - 1
            If Asc(_temp(i)) < 32 Then
                cmdTmep = cmdTmep & "[" & Asc(_temp(i)) & "]"
            Else
                cmdTmep = cmdTmep & _temp(i)
            End If
        Next
        CommandTX = CommandTX & cmdTmep
    End Sub

    Private Function DisplayText(ByVal buffer As Byte()) As String
        Dim STR As String = ""
        Dim UTF8 As Encoding = Encoding.UTF8
        'Dim temp = String.Format(Encoding.UTF8.GetString(buffer))

        Dim asciiChars(UTF8.GetCharCount(buffer, 0, buffer.Length) - 1) As Char
        UTF8.GetChars(buffer, 0, buffer.Length, asciiChars, 0)
        For I = 0 To asciiChars.Count - 1

            If Asc(asciiChars(I)) = 13 Then
                STR = STR & Chr(13).ToString
            ElseIf Asc(asciiChars(I)) = 10 Then
                STR = STR & Chr(10).ToString
            ElseIf Asc(asciiChars(I)) > 31 Then
                STR = STR & asciiChars(I)
            End If
        Next
        Return STR

    End Function
    Private Sub DisplayInfo(ByVal buffer As Byte())
        Dim STR As String = ""
        Dim UTF8 As Encoding = Encoding.UTF8
        'Dim temp = String.Format(Encoding.UTF8.GetString(buffer))

        Dim asciiChars(UTF8.GetCharCount(buffer, 0, buffer.Length) - 1) As Char
        UTF8.GetChars(buffer, 0, buffer.Length, asciiChars, 0)
        For I = 0 To asciiChars.Count - 1

            If Asc(asciiChars(I)) = 13 Then
                STR = STR & Chr(13).ToString
            ElseIf Asc(asciiChars(I)) = 10 Then
                STR = STR & Chr(10).ToString
            ElseIf Asc(asciiChars(I)) > 31 Then
                STR = STR & asciiChars(I)
            End If
        Next
    End Sub

    Private Function DisplayList(ByVal buffer As Byte()) As List(Of String)
        Dim STR As String = ""
        Dim ListTxt As New List(Of String)
        Dim UTF8 As Encoding = Encoding.UTF8

        Dim utf8Chars(UTF8.GetCharCount(buffer, 0, buffer.Length) - 1) As Char
        UTF8.GetChars(buffer, 0, buffer.Length, utf8Chars, 0)
        For I = 0 To utf8Chars.Count - 1

            If Asc(utf8Chars(I)) = 13 Then
                If utf8Chars(I - 1) = "l" Or utf8Chars(I - 1) = "L" Then
                    ListTxt.Add(STR)
                End If
            ElseIf Asc(utf8Chars(I)) = 10 Then
                STR = ""
            ElseIf Asc(utf8Chars(I)) > 31 Then
                STR = STR & utf8Chars(I)
            End If
        Next

        Return ListTxt

    End Function
#End Region

#Region "通訊阜開啟"
    Public Function serialPORTopen(COM As String, BAUD As Integer) As Boolean
        UC500serialport.SetCommPort(COM)
        UC500serialport.SetBAUDRate(BAUD)
        If UC500serialport.OpenComm() Then
            PortON_flag = True
            Return True
        End If
        Return False
    End Function
    Public Function serialPORTclose() As Boolean
        If UC500serialport.CloseComm() Then
            PortON_flag = False
            Return True
        End If
        Return False
    End Function
#End Region

#Region " uc500 command str"
    ''' <summary>
    ''' PF command(打字檔傳送)
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    Public Function PFCommandStr(ByVal fileName As String) As String
        Dim title As String = "TML(Technifor-UC500-9/11/2016-TML V0.12)"
        Dim pfstr As String = "PF " + Chr(34) + fileName + Chr(34) + " R "
        Dim LENGTH_STR As Integer

        Dim HEAD, MAIN, FOOTER As String
        Dim pfCommand As String
        HeaderStructure(HEAD)
        MainStructure(MAIN)
        FooterStructure(FOOTER)
        pfCommand = title + Chr(13) + Chr(10) + HEAD + MAIN + FOOTER

        Dim TX_HEAD = GetSendBuffer(pfstr) '轉成UTF-8(頭檔)
        Dim TX_FILE = GetSendBuffer(pfCommand) '轉成UTF-8(內文)

        Dim result(TX_FILE.Length + 3) As Byte
        result(0) = 239
        result(1) = 187
        result(2) = 191
        result(result.Count - 1) = 13
        Array.Copy(TX_FILE, 0, result, 3, TX_FILE.Length)
        LENGTH_STR = result.Count - 1 + TX_HEAD.Count

        Dim fin_result(result.Count + TX_HEAD.Count + 3) As Byte
        If LENGTH_STR >= 256 Then
            LENGTH_STR = LENGTH_STR - 256
            fin_result(2) = 1
        Else
            fin_result(2) = 0
        End If
        fin_result(0) = 27
        fin_result(1) = 0
        fin_result(3) = LENGTH_STR
        Array.Copy(TX_HEAD, 0, fin_result, 4, TX_HEAD.Length)
        Array.Copy(result, 0, fin_result, TX_HEAD.Length + 4, result.Length)
        Dim cmdstr As String
        For I = 0 To fin_result.Count - 1
            Dim TEMP = fin_result(I)
            cmdstr = cmdstr & "[" & TEMP & "]"
        Next
        CommandTX = cmdstr


        If PortON_flag = True Then
            ReciveRX.Clear()
            Dim ValueFlag As Boolean = True
            UC500serialport.SendDataUTF_8(fin_result)
            Do
                UC500serialport.Get2EndChar_UTF8(ReciveRX, Chr(13.ToString))
                If ReciveRX(ReciveRX.Count - 1) = 13 Then
                    ValueFlag = False
                End If
            Loop While (ValueFlag = True)

            Return DisplayText(ReciveRX.ToArray)
        End If
    End Function
    ''' <summary>
    ''' ParticularCommand(PLC專用模式)
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    Public Function ParticularCommand(ByVal fileName As String) As String
        Dim title As String = "TML(Technifor-UC500-9/11/2016-TML V0.12)"
        Dim pfstr As String = "PF " + Chr(34) + fileName + Chr(34) + " R "
        Dim LENGTH_STR As Integer

        Dim HEAD, MAIN, FOOTER As String
        Dim pfCommand As String
        selectmode(particularMode)
        HeaderStructure(HEAD)
        MainStructure(MAIN)
        FooterStructure(FOOTER)
        pfCommand = title + Chr(13) + Chr(10) + HEAD + MAIN + FOOTER
        Dim TX_HEAD = GetSendBuffer(pfstr) '轉成UTF-8(頭檔)
        Dim TX_FILE = GetSendBuffer(pfCommand) '轉成UTF-8(內文)

        Dim result(TX_FILE.Length + 3) As Byte
        result(0) = 239
        result(1) = 187
        result(2) = 191
        result(result.Count - 1) = 13
        Array.Copy(TX_FILE, 0, result, 3, TX_FILE.Length)
        LENGTH_STR = result.Count - 1 + TX_HEAD.Count

        Dim fin_result(result.Count + TX_HEAD.Count + 3) As Byte
        If LENGTH_STR >= 256 Then
            LENGTH_STR = LENGTH_STR - 256
            fin_result(2) = 1
        Else
            fin_result(2) = 0
        End If
        fin_result(0) = 27
        fin_result(1) = 0
        fin_result(3) = LENGTH_STR
        Array.Copy(TX_HEAD, 0, fin_result, 4, TX_HEAD.Length)
        Array.Copy(result, 0, fin_result, TX_HEAD.Length + 4, result.Length)
        Dim cmdstr As String
        For I = 0 To fin_result.Count - 1
            Dim TEMP = fin_result(I)
            cmdstr = cmdstr & "[" & TEMP & "]"
        Next
        CommandTX = cmdstr


        If PortON_flag = True Then
            ReciveRX.Clear()
            Dim ValueFlag As Boolean = True
            UC500serialport.SendDataUTF_8(fin_result)
            Do
                UC500serialport.Get2EndChar_UTF8(ReciveRX, Chr(13.ToString))
                If ReciveRX(ReciveRX.Count - 1) = 13 Then
                    ValueFlag = False
                End If
            Loop While (ValueFlag = True)

            Return DisplayText(ReciveRX.ToArray)
        End If
    End Function

    ''' <summary>
    ''' GO command(打字啟動)
    ''' </summary>
    ''' <returns></returns>
    Public Function GOCommand() As String

        Dim HEAD As String = "GO"
        Dim TX = Chr(27) & Chr(0) & Chr(0) & Chr(Len(HEAD)) & HEAD & Chr(13)
        Encode_Tx(TX)
        Dim SentTX = GetSendBuffer(TX)
        If PortON_flag = True Then
            ReciveRX.Clear()
            UC500serialport.SendDataUTF_8(SentTX)
            UC500serialport.Get2EndChar_UTF8(ReciveRX, Chr(13.ToString))

            Return DisplayText(ReciveRX.ToArray)
        End If

    End Function
    ''' <summary>
    ''' AM command(停止打字)
    ''' </summary>
    ''' <returns></returns>
    Public Function AMCommand() As String

        Dim HEAD As String = "AM"
        Dim TX = Chr(27) & Chr(0) & Chr(0) & Chr(Len(HEAD)) & HEAD & Chr(13)
        Encode_Tx(TX)
        Dim SentTX = GetSendBuffer(TX)

        If PortON_flag = True Then
            ReciveRX.Clear()
            UC500serialport.SendDataUTF_8(SentTX)
            UC500serialport.Get2EndChar_UTF8(ReciveRX, Chr(13.ToString))

            Return DisplayText(ReciveRX.ToArray)
        End If
    End Function
    ''' <summary>
    ''' AD command(故障排除)
    ''' </summary>
    ''' <returns></returns>
    Public Function ADCommand() As String

        Dim HEAD As String = "AD"
        Dim TX = Chr(27) & Chr(0) & Chr(0) & Chr(Len(HEAD)) & HEAD & Chr(13)
        Encode_Tx(TX)
        Dim SentTX = GetSendBuffer(TX)

        If PortON_flag = True Then
            ReciveRX.Clear()
            UC500serialport.SendDataUTF_8(SentTX)
            UC500serialport.Get2EndChar_UTF8(ReciveRX, Chr(13.ToString))

            Return DisplayText(ReciveRX.ToArray)
        End If
    End Function
    ''' <summary>
    ''' ST command(機器狀態)
    ''' </summary>
    ''' <returns></returns>
    Public Function STCommand() As String

        Dim HEAD As String = "ST"
        Dim TX = Chr(27) & Chr(0) & Chr(0) & Chr(Len(HEAD)) & HEAD & Chr(13)
        Encode_Tx(TX)
        Dim SentTX = GetSendBuffer(TX)

        If PortON_flag = True Then
            ReciveRX.Clear()
            UC500serialport.SendDataUTF_8(SentTX)
            UC500serialport.Get2EndChar_UTF8(ReciveRX, Chr(13.ToString))

            Return DisplayText(ReciveRX.ToArray)
        End If
    End Function
    ''' <summary>
    ''' OG command(回原點)
    ''' </summary>
    ''' <returns></returns>
    Public Function OGCommand() As String

        Dim HEAD As String = "OG"
        Dim TX = Chr(27) & Chr(0) & Chr(0) & Chr(Len(HEAD)) & HEAD & Chr(13)
        Encode_Tx(TX)
        Dim SentTX = GetSendBuffer(TX)

        If PortON_flag = True Then
            ReciveRX.Clear()

            UC500serialport.SendDataUTF_8(SentTX)
            UC500serialport.Get2EndChar_UTF8(ReciveRX, Chr(13.ToString))

            Return DisplayText(ReciveRX.ToArray)
        End If
    End Function
    ''' <summary>
    ''' VS command(參數修改)
    ''' </summary>
    ''' <returns></returns>
    Public Function VSCommand(ByVal num As Byte, ByVal value As String) As String

        Dim HEAD As String = "VS " & num & Chr(32) & Chr(34) & value & Chr(34)
        Dim TX = Chr(27) & Chr(0) & Chr(0) & Chr(Len(HEAD)) & HEAD & Chr(13)
        Encode_Tx(TX)
        Dim SentTX = GetSendBuffer(TX)


        If PortON_flag = True Then
            ReciveRX.Clear()
            UC500serialport.SendDataUTF_8(SentTX)
            UC500serialport.Get2EndChar_UTF8(ReciveRX, Chr(13.ToString))
            Return DisplayText(ReciveRX.ToArray)
        Else
            MsgBox("通訊錯誤")
        End If
    End Function
    ''' <summary>
    ''' LD command(文檔載入)
    ''' </summary>
    ''' <param name="fileName">檔名</param>
    ''' <param name="times">打字次數</param>
    ''' <param name="mode">打字模式(A=自動, N=正常, S=模擬)</param>
    ''' <returns></returns>
    Public Function LDCommand(ByVal fileName As String, ByVal times As Integer, ByVal mode As String) As String
        Dim HEAD As String
        Select Case mode
            Case "A"
                HEAD = "LD " & Chr(34) & fileName & Chr(34) & " 0 " & mode
            Case "S"
                HEAD = "LD " & Chr(34) & fileName & Chr(34) & " 1 " & mode
            Case "N"
                HEAD = "LD " & Chr(34) & fileName & Chr(34) & Chr(32) & times & Chr(32) & mode
        End Select
        '  27 + 0 + 0 + 2 + LD "打標文件名稱.tml" 打標次數(0~9999) 打標模式(A,N,S,SS) + 13 (LD) "0"表示無限次
        Dim TX = Chr(27) & Chr(0) & Chr(0) & Chr(Len(HEAD)) & HEAD & Chr(13)
        Encode_Tx(TX)
        Dim SentTX = GetSendBuffer(TX)

        If PortON_flag = True Then
            ReciveRX.Clear()
            UC500serialport.SendDataUTF_8(SentTX)
            UC500serialport.Get2EndChar_UTF8(ReciveRX, Chr(13.ToString))
            Return DisplayText(ReciveRX.ToArray)
        End If

    End Function
    ''' <summary>
    ''' GI command(機器資訊)
    ''' </summary>
    ''' <returns></returns>
    Public Function GICommand() As String
        ' 27 + 0 + 0 + 2 + GI * + 13 
        Dim HEAD As String = "GI *"
        Dim TX = Chr(27) & Chr(0) & Chr(0) & Chr(Len(HEAD)) & HEAD & Chr(13)
        Encode_Tx(TX)
        Dim SentTX = GetSendBuffer(TX)
        '=======================
        If PortON_flag = True Then
            ReciveRX.Clear()
            Dim RX_FINAL As New List(Of Byte)
            UC500serialport.SendDataUTF_8(SentTX)
            Dim ValueFlag As Boolean = True
            Do
                UC500serialport.Get2EndChar_UTF8(ReciveRX, Chr(13.ToString))
                If ReciveRX(ReciveRX.Count - 1) = 13 Then
                    ValueFlag = False
                End If
            Loop While (ValueFlag = True)

            For Each value In ReciveRX
                If value > 127 Then
                    Continue For
                Else
                    RX_FINAL.Add(value)
                End If
            Next
            Return DisplayText(RX_FINAL.ToArray)
        End If
    End Function

    ''' <summary>
    ''' GF command(文本內容)
    ''' </summary>
    ''' <returns></returns>
    Public Function GFCommand(ByVal fileName As String) As String
        Dim HEAD As String = "GF " + Chr(34) + fileName + Chr(34) + " R"
        Dim str As String
        Dim TX = Chr(27) & Chr(0) & Chr(0) & Chr(Len(HEAD)) & HEAD & Chr(13)
        Dim SentTX = GetSendBuffer(TX)
        Encode_Tx(TX)
        'Txt_Sent.Text = str
        '=======================
        If PortON_flag = True Then
            ReciveRX.Clear()
            Dim RX_FINAL As New List(Of Byte)
            UC500serialport.SendDataUTF_8(SentTX)
            UC500serialport.Get2EndChar_UTF8(ReciveRX, Chr(13.ToString))
            For Each value In ReciveRX
                If value > 127 Then
                    Continue For
                Else
                    RX_FINAL.Add(value)
                End If
            Next
            Return DisplayText(RX_FINAL.ToArray)
        End If
    End Function

    ''' <summary>
    ''' LS command(打字機 所有文件)
    ''' </summary>
    ''' <returns></returns>
    Public Function LSCommand() As List(Of String)
        Dim HEAD As String = "LS *.tml"
        Dim TX = Chr(27) & Chr(0) & Chr(0) & Chr(Len(HEAD)) & HEAD & Chr(13)
        Encode_Tx(TX)
        Dim SentTX = GetSendBuffer(TX)

        If PortON_flag = True Then
            ReciveRX.Clear()
            UC500serialport.SendDataUTF_8(SentTX)
            UC500serialport.Get2EndChar_UTF8(ReciveRX, Chr(13.ToString))

            Return DisplayList(ReciveRX.ToArray)
        End If
    End Function

    ''' <summary>
    ''' RM command(打字機 所有文件)
    ''' </summary>
    ''' <returns></returns>
    Public Function RMCommand(ByVal fileName As String) As String
        Dim HEAD As String = "RM " + Chr(34) + fileName + Chr(34)
        Dim TX = Chr(27) & Chr(0) & Chr(0) & Chr(Len(HEAD)) & HEAD & Chr(13)
        Dim SentTX = GetSendBuffer(TX)
        Encode_Tx(TX)
        '=======================

        If PortON_flag = True Then
            ReciveRX.Clear()
            UC500serialport.SendDataUTF_8(SentTX)
            UC500serialport.Get2EndChar_UTF8(ReciveRX, Chr(13.ToString))
            Return DisplayText(ReciveRX.ToArray)
        End If
    End Function
#End Region

#Region "其他"
    Private Sub selectmode(mode)
        Select Case mode
            Case MarkType.horizontal '水平
                MarkMode = "L"
                lineCnt = 1
                Angle_L = 0 + offsetAngle
            Case MarkType.horizontal_Reverse '水平反向
                MarkMode = "L"
                lineCnt = 1
                Angle_L = 180 + offsetAngle
            Case MarkType.horizontal_twoLine '水平兩行
                MarkMode = "L"
                lineCnt = 2
                Angle_L = 0 + offsetAngle
                MarkX_two = MarkX
                MarkY_two = (CSng(MarkY) + CSng(lineSpace) + Heigth).ToString("0.00")
            Case MarkType.horizontal_Reverse_twoLine '水平兩反向
                MarkMode = "L"
                lineCnt = 2
                Angle_L = 180 + offsetAngle
                MarkX_two = MarkX
                MarkY_two = (MarkY - lineSpace - Heigth).ToString("0.00")
                If MarkY_two < 0 Then MarkY_two = "0.00"
            Case MarkType.Vertical '垂直
                MarkMode = "L"
                lineCnt = 1
                Angle_L = 90 + offsetAngle
            Case MarkType.Vertical_Reverse '垂直反向
                MarkMode = "L"
                lineCnt = 1
                Angle_L = 270 + offsetAngle
            Case MarkType.Vertical_twoLine '垂直兩行
                MarkMode = "L"
                lineCnt = 2
                Angle_L = 90 + offsetAngle
                MarkX_two = (CSng(MarkX) + CSng(lineSpace) + Heigth).ToString("0.00")
                MarkY_two = MarkY
            Case MarkType.Vertical_Reverse_twoLine '垂直兩行反向
                MarkMode = "L"
                lineCnt = 2
                Angle_L = 270 + offsetAngle
                MarkX_two = (MarkX - lineSpace - Heigth).ToString("0.00")
                MarkY_two = MarkY
                If MarkX_two < 0 Then MarkX_two = "0.00"
        End Select
        If Angle_L < 0 Then
            Angle_L += 360
        End If
    End Sub

    Private Sub HeaderStructure(ByRef HEAD_Str As String)
        Dim BHCom As String = "BH()"
        Dim OHCom As String = "OH(A,Y,2,1)"
        Dim EHCom As String = "EH()"
        'BH()+13+10+SP_STR+13+10+OH(A,Y,2,1)+13+10+EH()
        Dim SPCom As String = "SP(" & Markspeed & "," & Movespeed & "," & QC & ")"
        HEAD_Str = BHCom & Chr(13) & Chr(10) & SPCom & Chr(13) & Chr(10) & OHCom & Chr(13) & Chr(10) & EHCom & Chr(13) & Chr(10)
    End Sub

    Private Function MainStructure(ByRef MAIN_Str As String)
        Dim commandSTR As String
        Dim BMCom As String = "BM()"
        Dim EMCom As String = "EM()"
        Dim BBCom As String = ""
        Dim EBCom As String = "EB(C)"
        Dim MVCom As String = ""
        Dim FOCom As String = ""
        'Dim SPCom As String = ""
        Dim MPCom As String = ""
        Dim QLCom As String = ""
        Dim MKCom As String = ""
        For i = 1 To lineCnt
            BBCom = "BB(ON," & MarkMode & ",,L2R)"
            If i = 1 Then
                MVCom = "MV(" & MarkX & "," & MarkY & ")"
            Else
                MVCom = "MV(" & MarkX_two & "," & MarkY_two & ")"
            End If

            FOCom = "FO(" & Font & "," & Heigth & "," & Between & "," & Width & ",C,N,0,N)"

            Select Case MarkMode
                Case "L"
                    MPCom = "MP(" & Angle_L & ")"
                Case "C"
                    MPCom = "MP(" & Angle_C & "," & radius_C & ",100,O," & CorW_C & ")"
            End Select
            QLCom = "QL(" & MarkForce & ",3)"
            '================== 打字本文 ==========================
            If lineCnt = 2 Then '兩行
                If i = 1 Then
                    MKCom = "MK(" + Chr(34) + line1 + Chr(34) + ")"
                Else
                    MKCom = "MK(" + Chr(34) + line2 + Chr(34) + ")"
                End If
            Else '一行
                MKCom = "MK(" + Chr(34) + line1 + Chr(34) + ")"
            End If

            If i = 1 Then
                commandSTR = BBCom + Chr(13) + Chr(10) + MVCom + Chr(13) + Chr(10) + FOCom + Chr(13) + Chr(10) + MPCom + Chr(13) + Chr(10) + QLCom + Chr(13) + Chr(10) + MKCom + Chr(13) + Chr(10) + EBCom
            Else
                commandSTR = commandSTR + Chr(13) + Chr(10) + BBCom + Chr(13) + Chr(10) + MVCom + Chr(13) + Chr(10) + FOCom +
                    Chr(13) + Chr(10) + MPCom + Chr(13) + Chr(10) + QLCom + Chr(13) + Chr(10) + MKCom + Chr(13) + Chr(10) + EBCom
            End If

        Next

        MAIN_Str = BMCom + Chr(13) + Chr(10) + commandSTR + Chr(13) + Chr(10) + EMCom + Chr(13) + Chr(10)
    End Function
    Private Sub FooterStructure(ByRef FOOTER_Str As String)
        Dim BFCom As String = "BF()"
        Dim OHCom As String = "OH(A,Y,0,1)"
        Dim EFCom As String = "EF()"
        'BF()+13+10+OH(A,Y,0,)+13+10+EF()
        FOOTER_Str = BFCom + Chr(13) + Chr(10) + OHCom + Chr(13) + Chr(10) + EFCom + Chr(13) + Chr(10)
    End Sub
#End Region
End Class
