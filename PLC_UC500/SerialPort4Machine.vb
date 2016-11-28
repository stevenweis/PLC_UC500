Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Public Class SerialPort4Machine


    Private RS232 As SerialPort
        Private Const MAXRETRY As Integer = 10

        Private Property PortName As String

        Private Property Parity As Parity

        '************************************************************
        ' this is the destructor
        '***************************************************************

        Protected Overrides Sub Finalize()

            RS232 = Nothing
            MyBase.Finalize()

        End Sub

        '***************************************************************
        ' this is the constructor
        '***************************************************************

        Public Sub New()

            RS232 = New SerialPort()

            RS232.PortName = "COM1"
            RS232.Parity = IO.Ports.Parity.None
            RS232.BaudRate = 115200
            RS232.StopBits = IO.Ports.StopBits.One
            RS232.DataBits = 8
            RS232.Handshake = IO.Ports.Handshake.None

            RS232.RtsEnable = False
            RS232.DtrEnable = False

            RS232.WriteBufferSize = 1000
            RS232.ReadBufferSize = 1000

            RS232.WriteTimeout = 100
            RS232.ReadTimeout = 100


        End Sub

        '***************************************************************
        ' these sets of SUB set the different values for the serial port communication
        '***************************************************************

        Public Sub SetBAUDRate(ByVal BAUD As Integer)
            RS232.BaudRate = BAUD
        End Sub
        Public Sub SetStopBits(ByVal StopBits As Integer)
            RS232.StopBits = StopBits
        End Sub
        Public Sub SetDataBits(ByVal DataBits As Integer)
            RS232.DataBits = DataBits
        End Sub
        Public Sub SetCommPort(ByVal CommPort As String)
            RS232.PortName() = CommPort
        End Sub
        Public Sub SetParity(ByVal Parity As Integer)
            RS232.Parity = Parity
        End Sub
        Public Sub SetFlowControl(ByVal Flowcontrol As Integer)
            RS232.Handshake = IO.Ports.Handshake.None
        End Sub


        '***************************************************************
        ' these sets of SUB get the different values for the serial port communication
        '***************************************************************

        Public Function GetBAUDRate() As String
            Return RS232.BaudRate
        End Function
        Public Function GetStopBits() As String
            Return RS232.StopBits

        End Function
        Public Function GetDataBits() As String
            Return RS232.DataBits
        End Function
        Public Function GetCommPort() As String
            Return RS232.PortName
        End Function
        Public Function GetParity() As String

            If (RS232.Parity = Parity.Even) Then
                Return "Even"
            End If

            If (RS232.Parity = Parity.Mark) Then
                Return "Mark"
            End If

            If (RS232.Parity = Parity.Odd) Then
                Return "Odd"
            End If

            If (RS232.Parity = Parity.None) Then
                Return "None"
            End If

            If (RS232.Parity = Parity.Even) Then
                Return "Even"
            End If

            Return "-1"

        End Function
        Public Function GetFlowControl() As String

            If (RS232.Handshake = Handshake.None) Then
                Return "None"
            End If

            If (RS232.Handshake = Handshake.RequestToSend) Then
                Return "RTS"
            End If

            If (RS232.Handshake = Handshake.RequestToSendXOnXOff) Then
                Return "RTS/XOn/XOff"
            End If

            If (RS232.Handshake = Handshake.XOnXOff) Then
                Return "XOn/XOff"
            End If

            Return "-1"


        End Function


        '***************************************************************
        ' these fuction are GENREAL for serial communication
        ' NOTE: ALL OF THESE FUNCTION RETURN A true IF IT WAS SUCCESSFUL
        '        OR A false IF THE FUNCTION FAILED.
        '***************************************************************
        Public Function OpenComm() As Boolean

            Dim IsCommOpen As Boolean = True
            'RS232.Encoding = Encoding.Unicode
            While IsCommOpen

                Try
                    CloseComm()
                    RS232.Open()
                    IsCommOpen = False

                Catch PortIsOpen As UnauthorizedAccessException
                    Return False
                Catch PortIsOpen As InvalidOperationException
                    Return False
                Catch BadSetting As ArgumentOutOfRangeException
                    Return False
                Catch BadPortName As ArgumentException
                    Return False
                Catch InvalidState As IOException
                    Return False
                End Try

            End While

            Return True

        End Function

        Public Function CloseComm() As Boolean
            Dim IsPortClosed As Boolean = True

            While IsPortClosed

                Try

                    RS232.Close()
                    IsPortClosed = False

                Catch PortNotOpen As InvalidOperationException
                    Return False
                End Try
                Return True
            End While

        End Function

        Public Function SendPacket(ByVal Packet2Send As String) As Boolean

            Dim PacketSent As Boolean = True
            RS232.DiscardInBuffer()
            RS232.DiscardInBuffer()

            While PacketSent
                Try
                    RS232.Write(Packet2Send)
                    'RS232.Write(,)
                    PacketSent = False

                Catch PortNotOpen As InvalidOperationException
                    Return False
                Catch NothingToSend As ArgumentNullException
                    Return False
                Catch TransmissionTimeout As TimeoutException
                    Return False
                End Try

            End While

            Return True 'if packet is sent return 0

        End Function

        Public Function GetChar(ByRef BufferChar As String)

            Dim TryAgain As Boolean = True
            Dim Buffer As Integer
            Do
                Try
                    Buffer = RS232.ReadChar()

                    TryAgain = False

                Catch PortNotOpen As InvalidOperationException
                    Return False
                Catch TimeOut As TimeoutException
                    Return False
                End Try

            Loop While (TryAgain = True)

            'now convert the serial data to a ascii char

            BufferChar = Chr(Buffer)
            'BufferChar = (Buffer)
            Return True 'if everything went well return a zero
        End Function

        Public Function Get2NewLine(ByRef BufferChar As String) As Boolean


            Dim GettingLine As Boolean = True

            Thread.Sleep(10)

            While GettingLine

                Try
                    BufferChar = RS232.ReadLine()
                    GettingLine = False

                Catch OperationTimeout As TimeoutException
                    Return False

                Catch InvalidOperationException As InvalidOperationException
                    Return False

                End Try

            End While

            Return True


        End Function

        Public Function Get2EndChar(ByRef CompleteStringfromBuffer As String, ByVal EndCode As String)

            Dim CharFromBuffer As String = ""
            Dim Done As Boolean

            Done = True
            Thread.Sleep(10)

            Do
                If (GetChar(CharFromBuffer) = False) Then
                    Return False
                    Exit Function

                End If

                If (CharFromBuffer = EndCode) Then

                    CompleteStringfromBuffer = CompleteStringfromBuffer + CharFromBuffer
                    Done = False

                Else

                    CompleteStringfromBuffer = CompleteStringfromBuffer + CharFromBuffer

                End If
            Loop While (Done = True)
            Return True
        End Function
#Region "utf8"
        Public Function SendDataUTF_8(ByVal Packet2Send() As Byte) As Boolean

            Dim PacketSent As Boolean = True
            RS232.DiscardInBuffer()
            RS232.DiscardInBuffer()
            Try
                RS232.Write(Packet2Send, 0, Packet2Send.Length)
            Catch ex As Exception
                '這邊你可以自訂發生例外的處理程序
                MsgBox(String.Format("出問題啦:{0}", ex.ToString()))

                Return False
            End Try
            'Next
            Return True
        End Function

        Public Function Get2EndChar_UTF8(ByRef tempList As List(Of Byte), ByVal EndCode As String)

            Dim CharFromBuffer As Byte
            Dim Done As Boolean

            Done = True
            Thread.Sleep(10)
            Do
                If (GetChar_UTF8(CharFromBuffer) = False) Then
                    Return False
                    Exit Function
                End If

                If (Chr(CharFromBuffer).ToString = EndCode) Then '最後一碼
                    tempList.Add(CharFromBuffer)
                    If CharFromBuffer = 0 Then
                        Return True
                    End If
                    'checkFlag = CharFromBuffer '站存
                    Continue Do
                    'Done = False
                Else
                    tempList.Add(CharFromBuffer)
                End If
            Loop While (Done = True)
            Return True
        End Function
        Public Function GetChar_UTF8(ByRef BufferChar As Byte)
            Dim TryAgain As Boolean = True
            Dim Buffer As Integer
            Do
                Try
                    Buffer = RS232.ReadByte
                    TryAgain = False
                Catch PortNotOpen As InvalidOperationException
                    Return False
                Catch TimeOut As TimeoutException
                    Return False
                End Try

            Loop While (TryAgain = True)

            'now convert the serial data to a ascii char
            BufferChar = Buffer
            Return True 'if everything went well return a zero
        End Function

#End Region

    End Class

