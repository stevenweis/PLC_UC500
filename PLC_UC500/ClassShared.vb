Public Class ClassShared

#Region "Method1 Numerical"
    ''' <summary>
    ''' Conver Bool to Byte
    ''' </summary>
    Protected Shared Function Bool2byte(ByVal arr_bool As Boolean) As Byte
        If arr_bool Then Return 1
        Return 0
    End Function

    ''' <summary>
    ''' Conver Bool Array to Byte
    ''' </summary>
    Protected Shared Function Bool2byte(ByVal arr_bool As Boolean()) As Byte()
        Dim arr_out As Byte() = New Byte() {}
        If arr_bool Is Nothing Then Return arr_out
        arr_out = New Byte(UBound(arr_bool) \ 8) {}
        Dim I As Integer = LBound(arr_bool), u_b As Integer = UBound(arr_bool)
        Do
            arr_out(I \ 8) = arr_out(I \ 8) Or IIf(arr_bool(I), 2 ^ (I Mod 8), 0)
            I += 1
        Loop While (Not (I > u_b))
        Return arr_out
    End Function

    ''' <summary>
    ''' Conver Bool to Word
    ''' </summary>
    Protected Shared Function Bool2Word(ByVal arr_bool As Boolean) As UShort
        If arr_bool Then Return 1
        Return 0
    End Function

    ''' <summary>
    ''' Conver Bool Array to Word
    ''' </summary>
    Protected Shared Function Bool2Word(ByVal arr_bool As Boolean()) As UShort()
        Dim arr_out As UShort() = New UShort() {}
        If arr_bool Is Nothing Then Return arr_out
        arr_out = New UShort(UBound(arr_bool) \ 16) {}
        Dim I As Integer = LBound(arr_bool), u_b As Integer = UBound(arr_bool)
        Do
            arr_out(I \ 16) = arr_out(I \ 16) Or IIf(arr_bool(I), 2 ^ (I Mod 16), 0)
            I += 1
        Loop While (Not (I > u_b))
        Return arr_out
    End Function

    ''' <summary>
    ''' Conver BoolArr to Hex
    ''' </summary>
    Protected Shared Function BoolArr2Hex(ByVal arr_bool As Boolean()) As String
        Dim str_out As String = ""
        Dim arr_size As Integer = IIf((arr_bool.Length Mod 16) = 0, arr_bool.Length - 1, ((1 + (arr_bool.Length \ 16)) * 16) - 1)
        Dim arr_bool_temp As Boolean() = New Boolean(arr_size) {}
        Array.Copy(arr_bool, LBound(arr_bool), arr_bool_temp, 0, arr_bool.Length)
        Dim I As Integer = 0, u_b As Integer = UBound(arr_bool_temp)
        Dim arr_temp As Boolean() = New Boolean(15) {}
        Do
            Array.Copy(arr_bool_temp, I, arr_temp, 0, 16)
            str_out = str_out & UShort2hex(Bool2Word(arr_temp)(0))
            I += 16
        Loop While (Not (I > u_b))
        Return str_out
    End Function

    ''' <summary>
    ''' Conver Byte to Hex
    ''' </summary>
    Protected Shared Function Byte2Hex(ByVal value As Byte) As String
        Return Hex(value).PadLeft(2, "0"c)
    End Function

    ''' <summary>
    ''' Conver ByteArr to Hex
    ''' </summary>
    Protected Shared Function ByteArr2Hex(ByVal arr_value As Byte()) As String
        Dim I As Integer = 0
        Dim arr_size As Integer = IIf((arr_value.Length Mod 2) = 0, arr_value.Length - 1, arr_value.Length)
        Dim arr_byte As Byte() = New Byte(arr_size) {}
        Array.Copy(arr_value, LBound(arr_value), arr_byte, 0, arr_value.Length)
        Dim str_out As String = ""
        Dim u_b As Integer = UBound(arr_byte)
        Do
            str_out = str_out & Byte2Hex(arr_byte(I))
            I += 1
        Loop While (Not (I > u_b))
        Return str_out
    End Function

    ''' <summary>
    ''' Conver Char to Byte
    ''' </summary>
    Protected Shared Function Char2Byte(ByVal element As Char) As Byte
        Return CByte(AscW(element))
    End Function

    ''' <summary>
    ''' Convert Double to Hex
    ''' </summary>
    Protected Shared Function Double2Hex(ByVal Value As Double) As String
        Try
            Dim ByteArr(7) As Byte
            ByteArr = BitConverter.GetBytes(Value)
            Double2Hex = ByteArr(1).ToString("X2") & ByteArr(0).ToString("X2") & ByteArr(3).ToString("X2") & ByteArr(2).ToString("X2") & ByteArr(5).ToString("X2") & ByteArr(4).ToString("X2") & ByteArr(7).ToString("X2") & ByteArr(6).ToString("X2")
        Catch ex As Exception
            Return ("0000000000000000")
        End Try
    End Function

    ''' <summary>
    ''' Convert DoubleArr to Hex
    ''' </summary>
    Protected Shared Function DoubleArr2Hex(ByVal arr_double As Double()) As String
        Dim I As Integer = LBound(arr_double), u_b As Integer = UBound(arr_double)
        Dim str_out As String = ""
        Do
            str_out = str_out & Double2Hex(arr_double(I))
            I += 1
        Loop While Not (I > u_b)
        Return str_out
    End Function


    ''' <summary>
    ''' Convert Hexadecimal to Byte
    ''' </summary>
    Protected Shared Function Hex2Byte(ByVal Data As String) As Byte
        Dim value As Integer
        value = Convert.ToByte(Data.Substring(0, 2), 16)
        Return CByte(value)
    End Function

    ''' <summary>
    ''' Convert Hexadecimal to Bytee Array
    ''' </summary>
    Protected Shared Function Hex2ByteArr(ByVal str_data As String) As Byte()
        Dim I As Integer = 1
        Dim arr_size As Integer = (str_data.Length \ 2) * 2 + IIf((str_data.Length Mod 2) = 0, 0, 2)
        str_data = str_data.PadLeft(arr_size, "0"c)
        arr_size = arr_size / 2
        Dim arr_byte As Byte() = New Byte(arr_size - 1) {}
        While Not (I > str_data.Length)
            arr_byte((I - 1) / 2) = Hex2Byte(Mid$(str_data, I, 2))
            I += 2
        End While
        Return arr_byte
    End Function

    ''' <summary>
    ''' Convert Hexadecimal to Bool Array
    ''' </summary>
    Protected Shared Function Hex2BoolArr(ByVal str_data As String) As Boolean()
        If Trim(str_data) = "" Then Return New Boolean() {False}
        Dim J As Integer = 0, I As Integer = 1, Offset As Integer = 0
        Dim temp_short As UShort = 0
        Dim arr_size As Integer = (str_data.Length \ 4) * 4 + IIf((str_data.Length Mod 4) = 0, 0, 4)
        str_data = str_data.PadLeft(arr_size, "0"c)
        arr_size = (arr_size * 4) - 1
        Dim arr_bool As Boolean() = New Boolean(arr_size) {}
        While Not (I > str_data.Length)
            temp_short = Hex2Word(Mid$(str_data, I, 4))
            J = 0
            Offset = 4 * (I - 1)
            While J < 16
                arr_bool(Offset + J) = (temp_short And (2 ^ J)) >> J
                J += 1
            End While
            I += 4
        End While
        Return arr_bool
    End Function

    ''' <summary>
    ''' Convert Hexadecimal to Double
    ''' </summary>
    Protected Shared Function Hex2Double(ByVal hexValue As String) As Double
        Try
            hexValue = hexValue.Substring(0, 16)
            hexValue = hexValue.PadLeft(16, "0"c)
            Dim i As Integer = 0
            Dim bArray(7) As Byte
            For i = 6 To 0 Step -2
                bArray(i + 1) = CInt("&H" & Mid$(hexValue, (i * 2) + 1, 2))
                bArray(i) = CInt("&H" & Mid$(hexValue, (i * 2) + 3, 2))
            Next
            Array.Reverse(bArray)
            Return BitConverter.ToDouble(bArray, 0)
        Catch ex As Exception
            Return (0.0)
        End Try
    End Function

    ''' <summary>
    ''' Convert Hexadecimal to Double Array
    ''' </summary>
    Protected Shared Function Hex2DoubleArr(ByVal str_data As String) As Double()
        Dim I As Integer = 1
        Dim arr_size As Integer = (str_data.Length \ 16) * 16 + IIf((str_data.Length Mod 16) = 0, 0, 16)
        str_data = str_data.PadLeft(arr_size, "0"c)
        arr_size = arr_size / 16
        Dim arr_double As Double() = New Double(arr_size - 1) {}
        While Not (I > str_data.Length)
            arr_double(I / 16) = Hex2Double(Mid$(str_data, I, 16))
            I += 16
        End While
        Return arr_double
    End Function

    ''' <summary>
    ''' Convert Hexadecimal to Integer
    ''' </summary>
    Public Shared Function Hex2Int(ByVal hexvalue As String) As Integer
        'Dim tempstr As String = Mid(hexvalue, 1, 4)
        Try
            hexvalue = hexvalue.Substring(0, 8)
            hexvalue = hexvalue.PadLeft(8, "0"c)
            'hexvalue = Mid(hexvalue, 5, 4) & tempstr
            Dim i As Integer = 0
            Dim bArray(3) As Byte
            For i = 2 To 0 Step -2
                bArray(i + 1) = CInt("&H" & Mid$(hexvalue, (i * 2) + 1, 2))
                bArray(i) = CInt("&H" & Mid$(hexvalue, (i * 2) + 3, 2))
            Next
            Array.Reverse(bArray)
            Return BitConverter.ToInt32(bArray, 0)
        Catch ex As Exception
            Return (0)
        End Try
    End Function

    ''' <summary>
    ''' Convert Hexadecimal to Integer Array
    ''' </summary>
    Protected Shared Function Hex2IntArr(ByVal str_data As String) As Integer()
        Dim I As Integer = 1
        Dim data As Integer = (str_data.Length \ 8) * 8 + IIf((str_data.Length Mod 8) = 0, 0, 8)
        str_data = str_data.PadLeft(data, "0"c)
        data = data / 8
        Dim arr_integer As Integer() = New Integer(data - 1) {}
        While Not (I > str_data.Length)
            arr_integer(I / 8) = Hex2Int(Mid$(str_data, I, 8))
            I += 8
        End While
        Return arr_integer
    End Function

    ''' <summary>
    ''' Convert Hexadecimal to Short
    ''' </summary>
    Public Shared Function Hex2Short(ByVal Data As String) As Short
        Dim value As Integer
        value = Convert.ToInt16(Data, 16)
        Return CShort(value)
    End Function

    ''' <summary>
    ''' Convert Hexadecimal to Short Array
    ''' </summary>
    Public Shared Function Hex2ShortArr(ByVal str_Data As String) As Short()
        Dim I As Integer = 1
        Dim data As Integer = (str_Data.Length \ 4) * 4 + IIf((str_Data.Length Mod 4) = 0, 0, 4)
        str_Data = str_Data.PadLeft(data, "0"c)
        data = data / 4
        Dim arr_short As Short() = New Short(data - 1) {}
        While Not (I > str_Data.Length)
            arr_short(I / 4) = Hex2Short(Mid$(str_Data, I, 4))
            I += 4
        End While
        Return arr_short
    End Function

    ''' <summary>
    ''' Convert Hexadecimal to Single
    ''' </summary>
    Public Shared Function Hex2Single(ByVal hexValue As String) As Single
        Try
            hexValue = hexValue.Substring(0, 8)
            hexValue = hexValue.PadLeft(8, "0"c)
            Dim i As Integer = 0
            Dim bArray(3) As Byte
            For i = 2 To 0 Step -2
                bArray(i + 1) = CInt("&H" & Mid$(hexValue, (i * 2) + 1, 2))
                bArray(i) = CInt("&H" & Mid$(hexValue, (i * 2) + 3, 2))
            Next

            Array.Reverse(bArray)
            Return BitConverter.ToSingle(bArray, 0)
        Catch ex As Exception
            Return (0.0)
        End Try
    End Function

    ''' <summary>
    ''' Convert Hexadecimal to Single Array
    ''' </summary>
    Protected Shared Function Hex2SingleArr(ByVal str_data As String) As Single()
        Dim I As Integer = 1
        Dim data As Integer = (str_data.Length \ 8) * 8 + IIf((str_data.Length Mod 8) = 0, 0, 8)
        str_data = str_data.PadLeft(data, "0"c)
        data = data / 8
        Dim arr_single As Single() = New Single(data - 1) {}
        While Not (I > str_data.Length)
            arr_single(I / 8) = Hex2Single(Mid$(str_data, I, 8))
            I += 8
        End While
        Return arr_single
    End Function

    ''' <summary>
    ''' Convert Hexadecimal to Word
    ''' </summary>
    Public Shared Function Hex2Word(ByVal Data As String) As UShort
        Dim value As Integer
        value = Convert.ToUInt16(Data, 16)
        Return CUShort(value)
    End Function

    ''' <summary>
    ''' Convert Hexadecimal to Word
    ''' </summary>
    Protected Shared Function Hex2WordArr(ByVal str_Data As String) As UShort()
        Dim I As Integer = 1
        Dim data As Integer = (str_Data.Length \ 4) * 4 + IIf((str_Data.Length Mod 4) = 0, 0, 4)
        str_Data = str_Data.PadLeft(data, "0"c)
        data = data / 4
        Dim arr_ushort As UShort() = New UShort(data - 1) {}
        While Not (I > str_Data.Length)
            arr_ushort(I / 4) = Hex2Word(Mid$(str_Data, I, 4))
            I += 4
        End While
        Return arr_ushort
    End Function

    ''' <summary>
    ''' Convert Integer to Hexadecimal
    ''' </summary>
    Public Shared Function Int2Hex(ByVal Data As Integer, Optional ByVal PadNum As Integer = 8) As String
        Try
            Dim ByteArr(4) As Byte
            ByteArr = BitConverter.GetBytes(Data)
            Int2Hex = ByteArr(1).ToString("X2") & ByteArr(0).ToString("X2") & ByteArr(3).ToString("X2") & ByteArr(2).ToString("X2")
            Int2Hex = Int2Hex.PadLeft(PadNum, "0"c)
        Catch ex As Exception
            Return ("00000000")
        End Try
    End Function

    ''' <summary>
    ''' Convert UInteger to Hexadecimal
    ''' </summary>
    Public Shared Function UInt2Hex(ByVal Data As UInteger, Optional ByVal PadNum As Integer = 8) As String
        Try
            Dim ByteArr(4) As Byte
            ByteArr = BitConverter.GetBytes(Data)
            UInt2Hex = ByteArr(1).ToString("X2") & ByteArr(0).ToString("X2") & ByteArr(3).ToString("X2") & ByteArr(2).ToString("X2")
            UInt2Hex = UInt2Hex.PadLeft(PadNum, "0"c)
        Catch ex As Exception
            Return ("00000000")
        End Try
    End Function

    ''' <summary>
    ''' Convert Integer to Hexadecimal
    ''' </summary>
    Protected Shared Function IntArr2Hex(ByVal arr_int As Integer()) As String
        Dim I As Integer = LBound(arr_int), u_b As Integer = UBound(arr_int)
        Dim str_out As String = ""
        Do
            str_out = str_out & Int2Hex(arr_int(I))
            I += 1
        Loop While Not (I > u_b)
        Return str_out
    End Function

    ''' <summary>
    ''' Convert Int32 to Hex
    ''' </summary>
    Protected Shared Function Integer2Hex(ByVal IntegerValue As Integer) As String
        Try
            Dim ByteArr(4) As Byte
            ByteArr = BitConverter.GetBytes(IntegerValue)
            Integer2Hex = ByteArr(1).ToString("X2") & ByteArr(0).ToString("X2") & ByteArr(3).ToString("X2") & ByteArr(2).ToString("X2")
        Catch ex As Exception
            Return ("00000000")
        End Try
    End Function

    ''' <summary>
    ''' Convert Int32Arr to Hex
    ''' </summary>
    Protected Shared Function IntegerArr2Hex(ByVal arr_int As Integer()) As String
        Dim I As Integer = LBound(arr_int), u_b As Integer = UBound(arr_int)
        Dim str_out As String = ""
        Do
            str_out = str_out & Integer2Hex(arr_int(I))
            I += 1
        Loop While Not (I > u_b)
        Return str_out
    End Function

    ''' <summary>
    ''' Convert UShort to Hexadecimal
    ''' </summary>    
    Public Shared Function UShort2hex(ByVal value As UShort) As String
        Return Hex(value).PadLeft(4, "0"c)
    End Function

    ''' <summary>
    ''' Convert UShortArr to Hexadecimal
    ''' </summary>    
    Protected Shared Function UShortArr2hex(ByVal arr_ushort As UShort()) As String
        Dim I As Integer = LBound(arr_ushort), u_b As Integer = UBound(arr_ushort)
        Dim str_out As String = ""
        Do
            str_out = str_out & UShort2hex(arr_ushort(I))
            I += 1
        Loop While Not (I > u_b)
        Return str_out
    End Function

    ''' <summary>
    ''' Convert Short to Hexadecimal
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function Short2Hex(ByVal Data As Integer, Optional ByVal PadNum As Integer = 4) As String
        Try
            Dim ByteArr(4) As Byte
            ByteArr = BitConverter.GetBytes(Data)
            Short2Hex = ByteArr(1).ToString("X2") & ByteArr(0).ToString("X2")
            Short2Hex = Short2Hex.PadLeft(PadNum, "0"c)
        Catch ex As Exception
            Return ("0000")
        End Try
    End Function

    '=====================================
    '8位Hex,16進位值轉成10進位: 32 bit --> dec
    '考慮2補數之正負數
    '有符號 -2147483648~2147483647
    '=====================================
    Public Shared Function hex2Ddec(ByVal hexd As String) As Integer
        Dim val As Long
        val = CDec("&h0" + hexd)
        If val >= 2147483648 Then
            val = val - 4294967296
        End If
        Return CInt(val)
    End Function
    '======================================
    '======================================
    '8位Hex,16進位值轉成10進位: 32 bit --> dec
    '無符號 0~4294967295
    Public Shared Function hex2DUdec(ByVal hexd As String) As UInteger
        Dim val As UInteger
        If Len(hexd) > 8 Then
            hexd = Right(hexd, 8)
        End If
        val = CDec("&h0" + hexd)
        Return val
    End Function
    '========================================


    Public Shared Function format6(Angle As String) As String

        Dim b As Single
        Dim c As String
        Dim w1 As String
        Dim i As Integer

        b = Val(Angle) * 100

        c = CStr(b)
        w1 = ""
        For i = Len(c) To 1 Step -1
            w1 = w1 & Hex(Asc(Mid(c, i, 1)))
        Next i

        For i = 1 To 12 - Len(c) * 2
            w1 = "0" & w1
        Next i

        Return w1
    End Function


    ''' <summary>
    ''' PLC轉換至電腦觀看
    ''' </summary>
    ''' <param name="type"> 格式碼(0,1,2,3,6) </param> *0:小數3位  *1:沒有小數點  *3:小數2位  *6:打字機格式
    ''' <param name="data"> 數值 </param>
    ''' <returns></returns>

    Public Shared Function PLC2real(ByVal type As Byte, ByVal signed As Boolean, ByVal data As String) As String 'Single
        Dim transferstr As String = ""

        If signed = True Then '有符號

            Select Case type
                Case 0
                    transferstr = (Hex2Short(data) / 1000).ToString("0.000")
                Case 1
                    transferstr = Hex2Short(data)
                Case 2
                    transferstr = (Hex2Short(data) / 100).ToString("0.00")
                Case 3
                    transferstr = CInt(data)
                Case 6
                    transferstr = Hex2Short(data) / 100
            End Select

        Else '無符號
            Select Case type

                Case 0
                    transferstr = (Hex2Word(data) / 1000).ToString("0.000")
                Case 1
                    transferstr = Hex2Word(data)
                Case 2
                    transferstr = (Hex2Word(data) / 100).ToString("0.00")
                Case 3
                    transferstr = CInt(data)
                Case 6
                    transferstr = Hex2Short(data) / 100
            End Select
        End If

        Return transferstr 'CSng(transferstr)
    End Function

    ''' <summary>
    ''' 電腦轉換至PLC
    ''' </summary>
    ''' <param name="type"> 格式碼(0,1,2,3,6) </param> *0:小數3位  *1:沒有小數點  *3:小數2位  *6:打字機格式
    ''' <param name="data"> 數值 </param>
    ''' <returns></returns>
    Public Shared Function real2PLC(ByVal type As Byte, ByVal signed As Boolean, ByVal data As String) As String
        Dim transferstr As String = ""

        If signed = True Then '有符號

            Select Case type
                Case 0
                    transferstr = Short2Hex(data * 1000)
                Case 1
                    transferstr = Short2Hex(data)
                Case 2
                    transferstr = Short2Hex(data * 100)
                Case 3
                    transferstr = data.PadLeft(4, "0"c)
                Case 6
                    transferstr = Short2Hex(data * 100)
            End Select

        Else '無符號
            Select Case type

                Case 0
                    transferstr = UShort2hex(data * 1000)
                Case 1
                    transferstr = UShort2hex(data)
                Case 2
                    transferstr = UShort2hex(data * 100)
                Case 3
                    transferstr = data.PadLeft(4, "0"c)
                Case 6
                    transferstr = Short2Hex(data * 100)
            End Select
        End If

        Return transferstr
    End Function

#End Region

#Region "Method2 others"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="controls"></param>
    ''' <returns></returns>
    Public Shared Function Findcontrol(ByVal controls As Control.ControlCollection) As List(Of Control)
        Dim listofcomp As New List(Of Control)
        For Each Ctl As Control In controls
            Recursive(Ctl, listofcomp)
        Next
        Return listofcomp
    End Function

    Shared Sub Recursive(Ctl As Control, ByRef listcomp As List(Of Control))
        '判斷是否有子控制項
        If Ctl.Controls.Count > 0 Then
            For Each Ctl1 As Control In Ctl.Controls
                Recursive(Ctl1, listcomp)
            Next
        Else
            '若沒有就在這裡判斷控制項並結束遞迴
            listcomp.Add(Ctl)
        End If
    End Sub
    '=============================================================================

    ''' <summary>
    ''' 建立控制項陣列
    ''' </summary>
    ''' <param name="controls"> 尋找控制項 </param>
    ''' <param name="componentlist1"> 控制項陣列1 (Dictionary(Of Integer, Control) )</param>
    ''' <param name="componentlist2"> 控制項陣列2 (Dictionary(Of Integer, Control) )</param>
    Public Shared Sub FindcontrolDictionary(ByVal controls As Control.ControlCollection, ByRef componentlist1 As Dictionary(Of Integer, Control), ByRef componentlist2 As Dictionary(Of Integer, Control))
        ' Dim listofcomp As New Dictionary(Of Integer, Control)
        For Each Ctl As Control In controls
            Recursive(Ctl, componentlist1, componentlist2)
        Next

    End Sub

    Shared Sub Recursive(Ctl As Control, ByRef componentlist1 As Dictionary(Of Integer, Control), ByRef componentlist2 As Dictionary(Of Integer, Control))
        '判斷是否有子控制項
        If Ctl.Controls.Count > 0 Then
            For Each Ctl1 As Control In Ctl.Controls
                Recursive(Ctl1, componentlist1, componentlist2)
            Next
        Else
            '若沒有就在這裡判斷控制項並結束遞迴
            If TypeOf Ctl Is Label Then
                If Ctl.Tag = 1 Then
                    componentlist1.Add(Ctl.TabIndex, Ctl)
                End If
            ElseIf TypeOf Ctl Is TextBox Then
                If Ctl.Tag = 1 Then
                    componentlist2.Add(Ctl.TabIndex, Ctl)
                End If
            End If
        End If
    End Sub
    '=========================================================================



    Public Shared Sub CheckExist(ByVal compareFrom As Form, ByVal existform As Control.ControlCollection)
        '檢查MdiChild是否已開啟,若已開啟,就不要再開了,而是將它帶到front
        Dim f As Form
        'MsgBox(Me)
        For Each f In existform
            If Not f.GetType().Equals(compareFrom.GetType()) Then
                Try
                    f.Close()
                    f.Dispose()
                Catch ex As Exception

                End Try

            End If
        Next
    End Sub

#End Region
End Class
