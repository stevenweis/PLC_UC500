Public Class ClassTextbox
    Inherits TextBox
    Private _focused As Boolean
    Private minvalue As Single
    Private maxvalue As Single
    Private txtType As Byte
    Private _flagonoff As Boolean
    Private signed As Boolean
    Enum point
        three = 3
        two = 2
        none = 0
    End Enum
    Sub New()
        txtType = 1
        _flagonoff = False
    End Sub

    Public WriteOnly Property setfalg() As Boolean
        Set(ByVal value As Boolean)
            _flagonoff = value
        End Set
    End Property

    Public Property setType() As Byte
        Get
            Return txtType
        End Get
        Set(ByVal value As Byte)
            txtType = value
            determine()
        End Set
    End Property

    Public Property setmaximum() As Single
        Get
            Return maxvalue
        End Get
        Set(ByVal value As Single)
            maxvalue = value
        End Set
    End Property
    Public Property setminimum() As Single
        Get
            Return minvalue
        End Get
        Set(ByVal value As Single)
            If value < 0 Then
                signed = True
            Else
                signed = False
            End If
            minvalue = value
        End Set
    End Property
    Public ReadOnly Property getsinged() As Boolean
        Get
            Return signed
        End Get
    End Property

    Private flag As Integer
    Public Property boxFlag() As Integer
        Get
            Return flag
        End Get
        Set(ByVal value As Integer)
            flag = value
        End Set
    End Property


    Protected Overrides Sub OnEnter(e As EventArgs)
        MyBase.OnEnter(e)
        If MouseButtons = MouseButtons.None Then
            SelectAll()
            _focused = True
        End If

    End Sub

    Protected Overrides Sub OnLeave(e As EventArgs)
        MyBase.OnLeave(e)
        _focused = False
    End Sub

    Protected Overrides Sub OnMouseUp(mevent As MouseEventArgs)
        MyBase.OnMouseUp(mevent)
        If Not _focused Then
            If SelectionLength = 0 Then
                SelectAll()
            End If
            _focused = True
        End If
    End Sub

    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)

        Me.BackColor = Color.Red
        'MyBase.OnGotFocus(e)
    End Sub
    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        Me.BackColor = Color.FromArgb(255, 255, 255, 255)
    End Sub

    Dim firstclick As Boolean

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        If _flagonoff Then '確定限制
            'If firstclick = False And e.KeyCode = Keys.Enter Then

            '    'SendKeys.Send("{tab}")
            '    firstclick = True
            'Else
            '    Me.Text = ""
            'End If
            If e.KeyCode = Keys.Enter Then
                Try
                    Select Case txtType
                        Case 0 '小數3位
                            If CType(Me.Text, Single) <= CType(maxvalue, Single) And CType(Me.Text, Single) >= CType(minvalue, Single) Then
                                Dim strtemp As Single = Me.Text
                                Me.Text = strtemp.ToString("0.000")
                                SendKeys.Send("{tab}")

                            Else
                                MsgBox("Range " & minvalue.ToString("0.000") & "~" & maxvalue.ToString("0.000"))

                                Me.OnEnter(e)
                            End If
                            firstclick = False
                        Case 1 '沒有小數
                            If CType(Me.Text, Single) <= CType(maxvalue, Single) And CType(Me.Text, Single) >= CType(minvalue, Single) Then
                                Dim strtemp As Single = Me.Text
                                Me.Text = strtemp.ToString
                                SendKeys.Send("{tab}")

                            Else
                                MsgBox("Range " & minvalue.ToString & "~" & maxvalue.ToString)
                                Me.OnEnter(e)
                            End If
                            firstclick = False
                        Case 2 '小數2位
                            If CType(Me.Text, Single) <= CType(maxvalue, Single) And CType(Me.Text, Single) >= CType(minvalue, Single) Then
                                Dim strtemp As Single = Me.Text
                                Me.Text = strtemp.ToString("0.00")
                                SendKeys.Send("{tab}")

                            Else
                                MsgBox("Range " & minvalue.ToString("0.00") & "~" & maxvalue.ToString("0.00"))
                                Me.OnEnter(e)
                            End If
                            firstclick = False
                        Case 3 'BCD/HEX
                            Dim VALUE As ULong = ClassShared.Hex2Word(Me.Text)
                            Dim MAX As ULong = ClassShared.hex2DUdec(maxvalue)
                            Dim MIN As ULong = ClassShared.hex2DUdec(minvalue)
                            If VALUE <= MAX And VALUE >= MIN Then

                                Me.Text = Strings.UCase(Me.Text)
                                SendKeys.Send("{tab}")
                            Else
                                MsgBox("Range " & minvalue.ToString & "~" & maxvalue.ToString)
                                Me.OnEnter(e)
                            End If
                            firstclick = False
                           ' Me.Text = Me.Text
                        Case 6 '打字專用
                            If CType(Me.Text, Single) <= CType(maxvalue, Single) And CType(Me.Text, Single) >= CType(minvalue, Single) Then
                                Dim strtemp As Single = Me.Text
                                Me.Text = strtemp.ToString("0.00")
                                SendKeys.Send("{tab}")

                            Else
                                MsgBox("Range " & minvalue.ToString("0.00") & "~" & maxvalue.ToString("0.00"))
                                Me.OnEnter(e)
                            End If
                            firstclick = False
                        Case 10
                            SendKeys.Send("{tab}")
                            firstclick = False
                    End Select

                Catch ex As Exception
                    MsgBox("Please enter the right value !")
                End Try
            ElseIf firstclick = False Then
                Me.Text = ""
                firstclick = True
            End If

        End If

        'End If
    End Sub



    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        'MyBase.OnKeyPress(e)
        'Me.Text = e.KeyChar
        'If firstclick = False Then
        '    Me.Text = ""
        '    firstclick = True
        'End If
        If firstclick = True Then


            Select Case txtType
                Case 0 ' 小數點3位
                    If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then 'Backspace:
                        '輸入的小數點為唯一
                        If e.KeyChar = "." And InStr(Me.Text, ".") > 0 Then
                            e.Handled = True
                        Else
                            '小數最多3位
                            If e.KeyChar <> Chr(8) And InStr(Me.Text, ".") > 0 Then
                                Dim sAry() As String = Me.Text.Split(".")
                                If sAry(1).Length >= point.three Then
                                    e.Handled = True
                                Else
                                    e.Handled = False
                                End If
                            Else
                                e.Handled = False
                            End If
                        End If
                        '輸入的負號是否在第一位
                    ElseIf e.KeyChar = "-" And Me.Text = "" Then
                        e.Handled = False
                    Else
                        e.Handled = True
                    End If

                Case 1 '無小數點
                    If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then 'Backspace:
                        '輸入的負號是否在第一位
                    ElseIf e.KeyChar = "-" And Me.Text = "" Then
                        e.Handled = False
                    Else
                        e.Handled = True
                    End If

                Case 2 '小數點2位
                    If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then 'Backspace:
                        '輸入的小數點為唯一
                        If e.KeyChar = "." And InStr(Me.Text, ".") > 0 Then
                            e.Handled = True
                        Else
                            '小數最多2位
                            If e.KeyChar <> Chr(8) And InStr(Me.Text, ".") > 0 Then
                                Dim sAry() As String = Me.Text.Split(".")
                                If sAry(1).Length >= point.two Then
                                    e.Handled = True
                                Else
                                    e.Handled = False
                                End If
                            Else
                                e.Handled = False
                            End If
                        End If
                        '輸入的負號是否在第一位
                    ElseIf e.KeyChar = "-" And Me.Text = "" Then
                        e.Handled = False
                    Else
                        e.Handled = True
                    End If

                Case 3
                    If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or (e.KeyChar >= Chr(65) And e.KeyChar <= Chr(70)) Or (e.KeyChar >= Chr(97) And e.KeyChar <= Chr(102)) Then 'Backspace:
                        '輸入的負號是否在第一位
                    ElseIf e.KeyChar = "-" And Me.Text = "" Then
                        e.Handled = False
                    Else
                        e.Handled = True
                    End If

                Case 6
                    If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then 'Backspace:
                        '輸入的小數點為唯一
                        If e.KeyChar = "." And InStr(Me.Text, ".") > 0 Then
                            e.Handled = True
                        Else
                            '小數最多2位
                            If e.KeyChar <> Chr(8) And InStr(Me.Text, ".") > 0 Then
                                Dim sAry() As String = Me.Text.Split(".")
                                If sAry(1).Length >= point.two Then
                                    e.Handled = True
                                Else
                                    e.Handled = False
                                End If
                            Else
                                e.Handled = False
                            End If
                        End If
                        '輸入的負號是否在第一位
                    ElseIf e.KeyChar = "-" And Me.Text = "" Then
                        e.Handled = False
                    Else
                        e.Handled = True
                    End If
            End Select
        End If
    End Sub

    Sub determine()
        Select Case txtType
            Case 0 '小數3位
                Me.MaxLength = Len(CStr(maxvalue)) + 5
            Case 1 '沒有小數
                Me.MaxLength = Len(CStr(maxvalue))
            Case 2 '小數2位
                Me.MaxLength = Len(CStr(maxvalue)) + 3
            Case 3 'BCD/HEX
                Me.MaxLength = Len(CStr(maxvalue))
            Case 6 '打字機專用
                Me.MaxLength = Len(CStr(maxvalue)) + 5
            Case 10
                Me.MaxLength = 255
        End Select

    End Sub




End Class
