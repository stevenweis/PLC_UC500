'Imports System.IO.Ports
Module ModuleConnect_2
    Public PLC As New SerialPort4Machine

    Enum Memory_Area_Code_Bit
        Bit_CIO = &H30
        Bit_WR = &H31
        Bit_HR = &H32
        Bit_AR = &H33
        Bit_DM = &H2
        Bit_EM0 = &H20
        Bit_EM1 = &H21
        Bit_EM2 = &H22
        Bit_EM3 = &H23
    End Enum

    Enum Memory_Area_Code_Word
        Word_CIO = &HB0
        Word_WR = &HB1
        Word_HR = &HB2
        Word_AR = &HB3
        Word_DM = &H82
        Word_EM0 = &HA0
        Word_EM1 = &HA1
        Word_EM2 = &HA2
        Word_EM3 = &HA3
    End Enum

    'Dim Flag_Bit As Byte

    ' 委派建立Command code
    Delegate Function Build_PLC_Command(ByVal Info_Register() As String, ByRef Command_code As String) As Boolean

    'PLC_ReadDMCommand (0101)
    'PLC_ReadMutiCommand (0104)
    'PLC_WriteDMCommand (0103)
    'PLC__WriteMutiDMCommand (0102)
#Region "委派函數"
    Function PLC_ReadDMCommand(ByVal Info_Register() As String, ByRef Command_code As String) As Boolean
        Dim CommandCode As String
        Dim MemoryAreaCode As String
        Dim BeginningAddress As String
        Dim NumberOfItem As String

        CommandCode = "01" + "01" ' command code to read Data Memory
        MemoryAreaCode = Hex(Info_Register(1)).PadLeft(2, "0")

        ' 位址 + 位元
        BeginningAddress = Hex(Info_Register(2)).PadLeft(4, "0") & Hex(Info_Register(3)).PadLeft(2, "0")

        NumberOfItem = Hex(Info_Register(4)).PadLeft(4, "0")

        Command_code = CommandCode & MemoryAreaCode & BeginningAddress & NumberOfItem
        'Command_code = "010482001200082000200"
        If (Len(Command_code) < 16) Then
            Return False
            Exit Function
        End If

        Return True
    End Function

    Function PLC_ReadMutiCommand(ByVal Info_Register() As String, ByRef Command_code As String) As Boolean
        ' Info_Register(0) DM   資料型態
        ' Info_Register(1) 190  位置
        ' Info_Register(2) WORD 數值範圍
        ' Info_Register(3) 00   位數
        ' Info_Register(4) 2    讀取個數

        Dim CommandCode As String
        Dim MemoryAreaCode As String
        Dim BeginningAddress As String

        CommandCode = "01" + "04" ' command code to read Data Memory

        For i = 0 To Info_Register.Count - 1 Step 4
            MemoryAreaCode = Hex(Info_Register(i + 1)).PadLeft(2, "0")
            BeginningAddress = Hex(Info_Register(i + 2)).PadLeft(4, "0") & Hex(Info_Register(i + 3)).PadLeft(2, "0")

            CommandCode = CommandCode & MemoryAreaCode & BeginningAddress
        Next

        Command_code = CommandCode
        'If (Len(Command_code) < 16) Then
        '    Return False
        '    Exit Function
        'End If

        Return True
    End Function

    Function PLC_WriteDMCommand(ByVal Info_Register() As String, ByRef Command_code As String) As Boolean
        Dim CommandCode As String
        Dim MemoryAreaCode As String
        Dim BeginningAddress As String
        Dim NumberOfItem As String

        CommandCode = "01" + "02" ' command code to read Data Memory
        MemoryAreaCode = Hex(Info_Register(1)).PadLeft(2, "0")

        BeginningAddress = Hex(Info_Register(2)).PadLeft(4, "0") & Hex(Info_Register(3)).PadLeft(2, "0")

        NumberOfItem = Hex(Info_Register(4)).PadLeft(4, "0")

        Command_code = CommandCode & MemoryAreaCode & BeginningAddress & NumberOfItem
        If (Len(Command_code) < 16) Then
            Return False
            Exit Function
        End If

        Return True
    End Function

    Function PLC_WriteMutiCommand(ByVal Info_Register() As String, ByRef Command_code As String) As Boolean
        Dim CommandCode As String
        Dim MemoryAreaCode As String
        Dim BeginningAddress As String
        Dim NumberOfItem As String

        CommandCode = "01" + "03" ' command code to read Data Memory
        MemoryAreaCode = Hex(Info_Register(0)).PadLeft(2, "0")

        BeginningAddress = Hex(Info_Register(1)).PadLeft(4, "0") & Hex(Info_Register(3)).PadLeft(2, "0")

        NumberOfItem = Hex(Info_Register(4)).PadLeft(4, "0")

        Command_code = CommandCode & MemoryAreaCode & BeginningAddress & NumberOfItem
        If (Len(Command_code) < 16) Then
            Return False
            Exit Function
        End If

        Return True
    End Function
#End Region


    Function Delegate_PLC_Read(ByVal Info_Register As String, ByRef TX As String, ByRef RX() As String, ByVal PLC_Command As Build_PLC_Command) As Boolean
        ' *** EX: temp_split 規格 WORD,DM,190,00,2 ***
        ' WORD 暫存器大小 (可選擇 WORD.DWORD.BIT) 
        ' DM   暫存區(可選擇 CIO.WR.HR.AR.DM)
        ' 190  暫存器位置
        ' 00   BIT位數(只有暫存器大小選擇BIT才有用)*WORD.DWORD 接選擇00*
        ' 2    個數 (讀取知個數)

        'Dim temp_split = Strings.Split(Info_Register, ",")

        Dim data_split = Strings.Split(Info_Register, ",")
        Dim temp_split(data_split.Count - 1) As String
        Dim cnt As Integer = 0
        Dim Flag As Integer = 0
        For Each split As String In data_split
            Select Case split
                Case "WORD"
                    Flag = 0
                    temp_split(cnt) = 4 ' 取4位數
                    cnt += 1
                Case "DWORD"
                    Flag = 0
                    temp_split(cnt) = 8 ' 取8位數
                    cnt += 1
                Case "BIT"
                    Flag = 1
                    temp_split(cnt) = 2 ' 取2位數
                    cnt += 1
                Case Else
                    If Flag = 0 Then ' 資料格式 WORD
                        Select Case split
                            Case "CIO"
                                temp_split(cnt) = Memory_Area_Code_Word.Word_CIO
                            Case "WR"
                                temp_split(cnt) = Memory_Area_Code_Word.Word_WR
                            Case "HR"
                                temp_split(cnt) = Memory_Area_Code_Word.Word_HR
                            Case "AR"
                                temp_split(cnt) = Memory_Area_Code_Word.Word_AR
                            Case "DM"
                                temp_split(cnt) = Memory_Area_Code_Word.Word_DM
                            Case "EM0"
                                temp_split(cnt) = Memory_Area_Code_Word.Word_EM0
                            Case "EM1"
                                temp_split(cnt) = Memory_Area_Code_Word.Word_EM1
                            Case "EM2"
                                temp_split(cnt) = Memory_Area_Code_Word.Word_EM2
                            Case "EM3"
                                temp_split(cnt) = Memory_Area_Code_Word.Word_EM3
                        End Select
                        Flag = 2 ' 旗標非word或bit 格式
                    ElseIf Flag = 1 Then ' 資料格式 BIT
                        Select Case split
                            Case "CIO"
                                temp_split(cnt) = Memory_Area_Code_Bit.Bit_CIO
                            Case "WR"
                                temp_split(cnt) = Memory_Area_Code_Bit.Bit_WR
                            Case "HR"
                                temp_split(cnt) = Memory_Area_Code_Bit.Bit_HR
                            Case "AR"
                                temp_split(cnt) = Memory_Area_Code_Bit.Bit_AR
                            Case "DM"
                                temp_split(cnt) = Memory_Area_Code_Bit.Bit_DM
                            Case "EM0"
                                temp_split(cnt) = Memory_Area_Code_Bit.Bit_EM0
                            Case "EM1"
                                temp_split(cnt) = Memory_Area_Code_Bit.Bit_EM1
                            Case "EM2"
                                temp_split(cnt) = Memory_Area_Code_Bit.Bit_EM2
                            Case "EM3"
                                temp_split(cnt) = Memory_Area_Code_Bit.Bit_EM3
                        End Select
                        Flag = 2
                    Else
                        temp_split(cnt) = split
                    End If
                    cnt += 1

            End Select


        Next

        Dim HostLinkHeader As String = ""
        Dim HostLinkFCS As String = ""
        Dim HostLinkTerminator As String = ""

        Dim FINSDataMemoryReadCmd As String = ""
        Dim FINSRecievePacket As String = ""

        Dim CompleteReadDataMemoryCommand As String = ""
        'Dim CommandString As String = ""
        Dim RecieveReadDataMemoryResult As String = ""

        ' 標頭檔
        BuildHostLinkHeader(HostLinkHeader)
        PLC_Command.Invoke(temp_split, FINSDataMemoryReadCmd) ' 委派做Command code
        CompleteReadDataMemoryCommand = HostLinkHeader + FINSDataMemoryReadCmd

        'FINS COMMAND
        BuildHostLinkFCSData(CompleteReadDataMemoryCommand, HostLinkFCS)
        BuildHostLinkTerminator(HostLinkTerminator)

        '完整命令字串
        CompleteReadDataMemoryCommand = CompleteReadDataMemoryCommand + HostLinkFCS + HostLinkTerminator
        TX = CompleteReadDataMemoryCommand


        PLC.SendPacket(CompleteReadDataMemoryCommand) ' 完整字串傳送
        PLC.Get2EndChar(RecieveReadDataMemoryResult, Chr(13).ToString) ' 完整字串接收

        Dim ReponseString As String = ""
        ReponseString = RecieveReadDataMemoryResult ' 完整字串

        '檢查 數據長度 FCS HEADER 
        If (DisassembleHostLinkPacket(FINSRecievePacket, RecieveReadDataMemoryResult) = False) Then
            'MsgBox("Failed to Disassemble Read Data Memory Recieve Packet", MsgBoxStyle.OkOnly, "Error")
            Return False
            Exit Function
        End If

        '檢查 標頭檔 與 勘誤碼
        If (DisassembleReadDataMemoryRespose(RX, FINSRecievePacket, temp_split) = False) Then
            MsgBox("Failed to Retrieve Data Memory Value", MsgBoxStyle.OkOnly, "Error")
            Return False
            Exit Function
        End If
        'End Select
        Return True
    End Function

    Function Delegate_PLC_MutiRead(ByVal Info_Register As String, ByRef TX As String, ByRef RX() As String, ByVal PLC_Command As Build_PLC_Command) As Boolean
        ' *** EX: temp_split 規格 WORD,DM,190,00,2 ***
        ' WORD 暫存器大小 (可選擇 WORD.DWORD.BIT) 
        ' DM   暫存區(可選擇 CIO.WR.HR.AR.DM)
        ' 190  暫存器位置
        ' 00   BIT位數(只有暫存器大小選擇BIT才有用)*WORD.DWORD 接選擇00*
        ' 2    個數 (讀取知個數)
        Dim Flag As Integer = 0
        'Dim temp_list As New List(Of String)

        Dim cnt As Byte
        'For i = 0 To Info_Register.Count - 1
        Dim data_split = Strings.Split(Info_Register, ",")
        Dim temp_list(data_split.Count - 1) As String
        For Each split As String In data_split
                Select Case split
                    Case "WORD"
                        Flag = 0
                        temp_list(cnt) = 4 ' 取4位數

                    Case "DWORD"
                        Flag = 0
                        temp_list(cnt) = 8 ' 取8位數
                    Case "BIT"
                        Flag = 1
                        temp_list(cnt) = 2 ' 取2位數

                    Case Else
                        If Flag = 0 Then ' 資料格式 WORD
                            Select Case split
                                Case "CIO"
                                    temp_list(cnt) = Memory_Area_Code_Word.Word_CIO
                                Case "WR"
                                    temp_list(cnt) = Memory_Area_Code_Word.Word_WR
                                Case "HR"
                                    temp_list(cnt) = Memory_Area_Code_Word.Word_HR
                                Case "AR"
                                    temp_list(cnt) = Memory_Area_Code_Word.Word_AR
                                Case "DM"
                                    temp_list(cnt) = Memory_Area_Code_Word.Word_DM
                                Case "EM0"
                                    temp_list(cnt) = Memory_Area_Code_Word.Word_EM0
                                Case "EM1"
                                    temp_list(cnt) = Memory_Area_Code_Word.Word_EM1
                                Case "EM2"
                                    temp_list(cnt) = Memory_Area_Code_Word.Word_EM2
                                Case "EM3"
                                    temp_list(cnt) = Memory_Area_Code_Word.Word_EM3
                            End Select
                            Flag = 2 ' 旗標非word或bit 格式
                        ElseIf Flag = 1 Then ' 資料格式 BIT
                            Select Case split
                                Case "CIO"
                                    temp_list(cnt) = Memory_Area_Code_Bit.Bit_CIO
                                Case "WR"
                                    temp_list(cnt) = Memory_Area_Code_Bit.Bit_WR
                                Case "HR"
                                    temp_list(cnt) = Memory_Area_Code_Bit.Bit_HR
                                Case "AR"
                                    temp_list(cnt) = Memory_Area_Code_Bit.Bit_AR
                                Case "DM"
                                    temp_list(cnt) = Memory_Area_Code_Bit.Bit_DM
                                Case "EM0"
                                    temp_list(cnt) = Memory_Area_Code_Bit.Bit_EM0
                                Case "EM1"
                                    temp_list(cnt) = Memory_Area_Code_Bit.Bit_EM1
                                Case "EM2"
                                    temp_list(cnt) = Memory_Area_Code_Bit.Bit_EM2
                                Case "EM3"
                                    temp_list(cnt) = Memory_Area_Code_Bit.Bit_EM3
                            End Select
                            Flag = 2
                        Else
                            temp_list(cnt) = split

                        End If
                End Select
                cnt += 1
            Next
        'Next

        Dim HostLinkHeader As String = ""
        Dim HostLinkFCS As String = ""
        Dim HostLinkTerminator As String = ""

        Dim FINSDataMemoryReadCmd As String = ""
        Dim FINSRecievePacket As String = ""

        Dim CompleteReadDataMemoryCommand As String = ""
        'Dim CommandString As String = ""
        Dim RecieveReadDataMemoryResult As String = ""

        ' 標頭檔
        BuildHostLinkHeader(HostLinkHeader)
        PLC_Command.Invoke(temp_list, FINSDataMemoryReadCmd) ' 委派做Command code
        CompleteReadDataMemoryCommand = HostLinkHeader + FINSDataMemoryReadCmd

        'FINS COMMAND
        BuildHostLinkFCSData(CompleteReadDataMemoryCommand, HostLinkFCS)
        BuildHostLinkTerminator(HostLinkTerminator)

        '完整命令字串
        CompleteReadDataMemoryCommand = CompleteReadDataMemoryCommand + HostLinkFCS + HostLinkTerminator
        TX = CompleteReadDataMemoryCommand


        PLC.SendPacket(CompleteReadDataMemoryCommand) ' 完整字串傳送
        PLC.Get2EndChar(RecieveReadDataMemoryResult, Chr(13).ToString) ' 完整字串接收

        Dim ReponseString As String = ""
        ReponseString = RecieveReadDataMemoryResult ' 完整字串

        '檢查 數據長度 FCS HEADER 
        If (DisassembleHostLinkPacket(FINSRecievePacket, RecieveReadDataMemoryResult) = False) Then
            MsgBox("Failed to Disassemble Read Data Memory Recieve Packet", MsgBoxStyle.OkOnly, "Error")
            Return False
            Exit Function
        End If

        '檢查 標頭檔 與 勘誤碼
        If (DisassembleReadDataMemoryRespose(RX, FINSRecievePacket, temp_list) = False) Then
            MsgBox("Failed to Retrieve Data Memory Value", MsgBoxStyle.OkOnly, "Error")
            Return False
            Exit Function
        End If
        'End Select
        Return True
    End Function

    Function Delegate_PLC_Write(ByVal Info_Register As String, ByVal Write_Data As String, ByRef TX As String, ByRef RX As String, ByVal PLC_Command As Build_PLC_Command) As Boolean
        ' **** Writ_Data主要為外部數值轉換完再丟入 ****
        ' *** EX: temp_split 規格 WORD,DM,190,00,2 ***
        ' DM   暫存區(可選擇 CIO.WR.HR.AR.DM)
        ' 190  暫存器位置
        ' WORD 暫存器大小 (可選擇 WORD.DWORD.BIT) 
        ' 00   BIT位數(只有暫存器大小選擇BIT才有用)*WORD.DWORD 接選擇00*
        ' 2    個數 (讀取知個數)


        Dim data_split = Strings.Split(Info_Register, ",")
        Dim temp_split(data_split.Count - 1) As String
        Dim cnt As Integer = 0
        Dim Flag As Integer = 0
        For Each split As String In data_split
            Select Case split
                Case "WORD"
                    Flag = 0
                    temp_split(cnt) = 4 ' 取4位數
                    cnt += 1
                Case "DWORD"
                    Flag = 0
                    temp_split(cnt) = 8 ' 取8位數
                    cnt += 1
                Case "BIT"
                    Flag = 1
                    temp_split(cnt) = 2 ' 取2位數
                    cnt += 1
                Case Else
                    If Flag = 0 Then ' 資料格式 WORD
                        Select Case split
                            Case "CIO"
                                temp_split(cnt) = Memory_Area_Code_Word.Word_CIO
                            Case "WR"
                                temp_split(cnt) = Memory_Area_Code_Word.Word_WR
                            Case "HR"
                                temp_split(cnt) = Memory_Area_Code_Word.Word_HR
                            Case "AR"
                                temp_split(cnt) = Memory_Area_Code_Word.Word_AR
                            Case "DM"
                                temp_split(cnt) = Memory_Area_Code_Word.Word_DM
                        End Select
                        Flag = 2 ' 旗標非word或bit 格式
                    ElseIf Flag = 1 Then ' 資料格式 BIT
                        Select Case split
                            Case "CIO"
                                temp_split(cnt) = Memory_Area_Code_Bit.Bit_CIO
                            Case "WR"
                                temp_split(cnt) = Memory_Area_Code_Bit.Bit_WR
                            Case "HR"
                                temp_split(cnt) = Memory_Area_Code_Bit.Bit_HR
                            Case "AR"
                                temp_split(cnt) = Memory_Area_Code_Bit.Bit_AR
                            Case "DM"
                                temp_split(cnt) = Memory_Area_Code_Bit.Bit_DM
                        End Select
                        Flag = 2
                    Else
                        temp_split(cnt) = split
                    End If
                    cnt += 1

            End Select


        Next


        Dim HostLinkHeader As String = ""
        Dim HostLinkFCS As String = ""
        Dim HostLinkTerminator As String = ""

        Dim FINSDataMemoryWriteCmd As String = ""
        Dim FINSRecievePacket As String = ""

        Dim CompleteWriteDataMemoryCommand As String = ""
        'Dim CommandString As String = ""
        Dim RecieveWriteDataMemoryResult As String = ""

        ' 標頭檔
        BuildHostLinkHeader(HostLinkHeader)
        PLC_Command.Invoke(temp_split, FINSDataMemoryWriteCmd) ' 委派做Command code


        '加入寫入檔案 Write_Data
        Dim Command_data As String = ""
        If temp_split(0) = 4 Then 'WORD 4位
            Dim temp_data As String = ""
            For i As Integer = 0 To temp_split(4) - 1
                temp_data = Write_Data.Substring(0, temp_split(0))
                Write_Data = Write_Data.Substring(temp_split(0))
                Command_data = Command_data & temp_data
            Next

        ElseIf temp_split(0) = 8 Then ' DWORD 8位
            Dim temp_data As String = ""
            For i As Integer = 0 To (temp_split(4) / 2) - 1
                'If ((temp_split(4) / 2) - 1) = 1 And i = 1 Then
                'Exit For
                'End If
                temp_data = Write_Data.Substring(0, temp_split(0))
                Write_Data = Write_Data.Substring(temp_split(0))
                Command_data = Command_data & temp_data
            Next

        Else ' BIT 2位
            Dim temp_data As String = ""
            ' 判斷數據是否補成2位一組
            ' ex: Input 1 應補成 0
            If Len(Write_Data) <> temp_split(0) * temp_split(4) Then '未補
                For i As Integer = 0 To temp_split(4) - 1
                    temp_data = Mid(Write_Data, 1, 1).PadLeft(2, "0")
                    Write_Data = Mid(Write_Data, 2, Len(Write_Data) - 1)
                    Command_data = Command_data & temp_data
                Next

            Else '已補
                For i As Integer = 0 To temp_split(4) - 1
                    temp_data = Write_Data.Substring(0, temp_split(0))
                    Write_Data = Write_Data.Substring(temp_split(0))
                    Command_data = Command_data & temp_data
                Next
            End If

        End If


        CompleteWriteDataMemoryCommand = HostLinkHeader + FINSDataMemoryWriteCmd + Command_data
        'CompleteWriteDataMemoryCommand = "@00FA00000000023010001000130000000"

        'FINS COMMAND
        BuildHostLinkFCSData(CompleteWriteDataMemoryCommand, HostLinkFCS)
        BuildHostLinkTerminator(HostLinkTerminator)

        '完整命令字串
        CompleteWriteDataMemoryCommand = CompleteWriteDataMemoryCommand + HostLinkFCS + HostLinkTerminator
        TX = CompleteWriteDataMemoryCommand

        PLC.SendPacket(CompleteWriteDataMemoryCommand) ' 完整字串傳送
        PLC.Get2EndChar(RecieveWriteDataMemoryResult, Chr(13).ToString) ' 完整字串接收

        Dim ReponseString As String = ""
        ReponseString = RecieveWriteDataMemoryResult ' 完整字串
        RX = ReponseString
        '檢查 數據長度 FCS HEADER 
        If (DisassembleHostLinkPacket(FINSRecievePacket, RecieveWriteDataMemoryResult) = False) Then
            MsgBox("Failed to Disassemble Read Data Memory Recieve Packet", MsgBoxStyle.OkOnly, "Error")
            Return False
            Exit Function
        End If

        If (DisassembleWriteDataMemoryResponse(FINSRecievePacket) = False) Then
            MsgBox("Failed to Retrieve Data Memory Value", MsgBoxStyle.OkOnly, "Error")
            Return False
            Exit Function
        End If
        'End Select
        Return True
    End Function

    Public Function PLC_ProgramMode() As Boolean
        Dim HostLinkHeader As String = ""
        Dim CompleteReadDataMemoryCommand As String = ""
        Dim RecieveReadDataMemoryResult As String = ""

        BuildHostLinkHeader(HostLinkHeader)
        CompleteReadDataMemoryCommand = HostLinkHeader + "0402FFFF71*" + Chr(13).ToString
        PLC.SendPacket(CompleteReadDataMemoryCommand) ' 完整字串傳送
        PLC.Get2EndChar(RecieveReadDataMemoryResult, Chr(13).ToString) ' 完整字串接收
        If Len(RecieveReadDataMemoryResult) < 25 Then
            Return False
            Exit Function
        End If
        Return True
    End Function
    Public Function PLC_MonitorMode() As Boolean
        Dim HostLinkHeader As String = ""
        Dim CompleteReadDataMemoryCommand As String = ""
        Dim RecieveReadDataMemoryResult As String = ""

        BuildHostLinkHeader(HostLinkHeader)
        CompleteReadDataMemoryCommand = HostLinkHeader + "0401FFFF0270*" + Chr(13).ToString
        PLC.SendPacket(CompleteReadDataMemoryCommand) ' 完整字串傳送
        PLC.Get2EndChar(RecieveReadDataMemoryResult, Chr(13).ToString) ' 完整字串接收
        If Len(RecieveReadDataMemoryResult) < 25 Then
            Return False
            Exit Function
        End If
        Return True
    End Function

#Region "HEADER & FINS COMMAND"
    Public Function BuildHostLinkHeader(ByRef HostLinkerHeader As String) As Boolean

        Dim Prefix As String
        Dim UnitNumber As String
        Dim HeaderCode As String
        Dim ResponseWaitTime As String
        Dim InfoCntrlField As String
        Dim RSV As String
        Dim GatewayCnt As String
        Dim DestNetworkAdd As String
        Dim DestNodeAdd As String
        Dim DestUnitAdd As String
        Dim SourceNetworkAdd As String
        Dim SourceNodeAdd As String
        Dim SourceUnitAdd As String
        Dim SourceID As String


        Prefix = "@"
        UnitNumber = "00"
        HeaderCode = "FA"
        ResponseWaitTime = "0" ' times 10msec
        InfoCntrlField = "00"
        RSV = "00"
        GatewayCnt = "07"
        DestNetworkAdd = "00"
        DestNodeAdd = "00"
        DestUnitAdd = "00"
        SourceNetworkAdd = "00"
        SourceNodeAdd = "00"
        SourceUnitAdd = "00"
        SourceID = "00"

        'HostLinkerHeader = Prefix + UnitNumber + HeaderCode + ResponseWaitTime + InfoCntrlField + RSV + GatewayCnt + DestNetworkAdd + DestNodeAdd +DestUnitAdd + SourceNetworkAdd + SourceNodeAdd + SourceUnitAdd + SourceID
        HostLinkerHeader = Prefix + UnitNumber + HeaderCode + ResponseWaitTime + InfoCntrlField + DestUnitAdd + SourceUnitAdd + SourceID

        Return True
    End Function



    Public Function BuildHostLinkFCSData(ByVal CommandString As String, ByRef FCSData As String) As Boolean

        Dim FCSCheckSum As Integer
        Dim NumberOfCar As Integer
        Dim Index As Integer

        FCSCheckSum = 0

        NumberOfCar = CommandString.Length


        For Index = 1 To (NumberOfCar) Step 1

            FCSCheckSum = FCSCheckSum Xor Asc(Mid(CommandString, Index, 1))

        Next Index

        FCSData = Hex(FCSCheckSum).PadLeft(2, "0")

        Return True
    End Function


    Public Function BuildHostLinkTerminator(ByRef HostLinkTerminator As String) As Boolean

        HostLinkTerminator = "*" + Chr(13).ToString
        Return True
    End Function
#End Region

#Region "SerialPort & Transceiver"

#End Region

#Region "Reciever check"
    Public Function DisassembleHostLinkPacket(ByRef FINSPacket As String, ByVal ResponsePacket As String) As Boolean

        Dim FCSDataFromResponsePacket As String
        Dim FCSData2TestAgainst As String = ""


        ' check the Packet length (minimum packet length is 27)
        ' CPU unit durectly connected to the HOST COMPUTER

        If (ResponsePacket.Length < 27) Then
            Return False
            Exit Function
        End If

        ' lets remove the terminator from the packet
        ResponsePacket = ResponsePacket.Remove((ResponsePacket.Length - 2), 2)

        'let remove the FCSData from the packet and store it
        FCSDataFromResponsePacket = ResponsePacket.Substring((ResponsePacket.Length - 2), 2)
        ResponsePacket = ResponsePacket.Remove((ResponsePacket.Length - 2), 2)

        BuildHostLinkFCSData(ResponsePacket, FCSData2TestAgainst)

        ' test the FCS checksum
        If (Not (FCSData2TestAgainst = FCSDataFromResponsePacket)) Then
            Return False
            Exit Function

        End If

        'Now let remove Host Link Header
        ' 拿掉頭檔
        FINSPacket = ResponsePacket.Substring(15)

        Return True
        Exit Function

    End Function


    Public Function DisassembleReadDataMemoryRespose(ByRef ReadDMValue() As String, ByVal ReadDMResponse As String, ByVal Data_Info() As String) As Boolean

        Dim CommandCode As String
        Dim EndCode As String
        Dim Data As String


        CommandCode = ReadDMResponse.Substring(0, 4) '指令碼 0101 or 0104
        ReadDMResponse = ReadDMResponse.Substring(4)

        EndCode = ReadDMResponse.Substring(0, 4) '結束碼 0000(正常)
        ReadDMResponse = ReadDMResponse.Substring(4) '數據字串

        Data = ReadDMResponse.Substring(0)

        'Check Command Code
        If Not ((CommandCode = "0101") Or (CommandCode = "0104")) Then
            Return False
            Exit Function
        End If


        If (Not (EndCode = "0000")) Then
            Return False
            Exit Function
        End If
        '重新排列字串
        'ReOrderDataMemoryValue(Data)


        Select Case CommandCode
            Case "0101"
                If Data_Info(0) = 4 Then ' 資料格式WORD 
                    Dim Array_RX(Data_Info(4) - 1) As String
                    For i = 0 To Data_Info(4) - 1
                        Array_RX(i) = Data.Substring(0, Data_Info(0))
                        Data = Data.Substring(Data_Info(0))
                    Next
                    ReadDMValue = Array_RX

                ElseIf Data_Info(0) = 8 Then ' 資料格式 DWORD
                    Dim Array_RX((Data_Info(4) / 2) - 1) As String
                    For i = 0 To (Data_Info(4) / 2) - 1
                        Array_RX(i) = Data.Substring(0, Data_Info(0))
                        ReOrderDataMemoryValue(Array_RX(i))
                        Data = Data.Substring(Data_Info(0))
                    Next
                    ReadDMValue = Array_RX

                Else ' 資料格式 BIT
                    Dim Array_RX(0) As String
                    For i = 0 To Data_Info(4) - 1

                        Data = Data.Remove(i, 1)

                    Next
                    Array_RX(0) = Data
                    ReadDMValue = Array_RX
                End If
            Case "0104"
                Dim Array_RX((Data_Info.Count / 4) - 1) As String
                Dim cnt As Byte

                For i = 0 To Data_Info.Count - 1 Step 4
                    Dim length = Data_Info(i)
                    Dim start As Byte = 2
                    Array_RX(cnt) = Data.Substring(start, Data_Info(i))
                    start = start + Data_Info(i) + 2
                    Data = Data.Substring(start - 2)
                    cnt += 1
                Next
                ReadDMValue = Array_RX
        End Select


        Return True

    End Function

    Public Function DisassembleWriteDataMemoryResponse(ByVal WriteDMRespose As String) As Boolean


        Dim CommandCode As String
        Dim EndCode As String


        CommandCode = WriteDMRespose.Substring(0, 4)
        WriteDMRespose = WriteDMRespose.Substring(4)

        EndCode = WriteDMRespose.Substring(0, 4)
        WriteDMRespose = WriteDMRespose.Substring(4)


        'Check Command Code
        If (Not (CommandCode = "0102")) Then
            Return False
            Exit Function
        End If


        If (Not (EndCode = "0000")) Then
            Return False
            Exit Function
        End If


        Return True

    End Function


    Private Function ReOrderDataMemoryValue(ByRef Value4DataMemory As String)

        Dim OrginalValue As String
        Dim Iternation As Integer

        OrginalValue = Value4DataMemory

        Value4DataMemory = ""

        For Iternation = ((OrginalValue.Length) / 4) To 1 Step -1

            Value4DataMemory = Value4DataMemory + OrginalValue.Substring((OrginalValue.Length - 4), 4)
            OrginalValue = OrginalValue.Remove((OrginalValue.Length - 4), 4)

        Next

        Return True

    End Function
#End Region


End Module
