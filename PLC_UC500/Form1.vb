Imports System.IO.Ports
Public Class Form1
    Dim UC500class As New uc500Common '載入打字機類別
    Dim Marktable As New List(Of String) '打字資訊文字檔
    Dim txtlist As New Dictionary(Of Integer, ClassTextbox) '控制項陣列textbox
    Dim Radiolist As New Dictionary(Of Integer, RadioButton) '控制項陣列textbox
    Dim keystxt As List(Of Integer) '排列dictionary鍵值順序
    Dim keysradio As List(Of Integer) '排列dictionary鍵值順序
    Dim comPortuc500_flag As Boolean
    Dim comPortPLC_flag As Boolean

    '=========委派函數===============
    Dim Delegate_Write As Build_PLC_Command
    Dim Delegate_Read As Build_PLC_Command
    Dim A_TX, A_RX() As String
    Dim write_TX, write_RX As String
    '=================================

    Sub fileRead()
        Dim keytype As New ClassTxtWR()
        keytype.TxtRead_test2("MarkMode.txt", Marktable)
    End Sub

    Sub Findcontrol(ByVal controls As Control.ControlCollection)
        For Each Ctl As Control In controls
            Recursive(Ctl)
        Next
    End Sub
    Sub Recursive(Ctl As Control)
        '判斷是否有子控制項
        If Ctl.Controls.Count > 0 Then
            For Each Ctl1 As Control In Ctl.Controls
                Recursive(Ctl1)
            Next
        Else
            '若沒有就在這裡判斷控制項並結束遞迴
            If TypeOf Ctl Is ClassTextbox Then
                Dim TEMP_CTL As ClassTextbox = Ctl
                txtlist.Add(TEMP_CTL.boxFlag, TEMP_CTL)
            ElseIf TypeOf Ctl Is RadioButton Then
                Radiolist.Add(Ctl.TabIndex, Ctl)
            End If
        End If
    End Sub

    Sub InitialSet()

        For Each sp As String In SerialPort.GetPortNames
            PortUC500.Items.Add(sp)
            PortPLC.Items.Add(sp)
        Next

        Try
            PortUC500.Sorted = True
            PortPLC.Sorted = True
            PortUC500.SelectedIndex = 1
            PortPLC.SelectedIndex = 1
            PLCbaud.SelectedIndex = 0
            UC500baud.SelectedIndex = 0
        Catch ex As Exception
            UC500baud.SelectedIndex = 0
            PLCbaud.SelectedIndex = 0
        End Try
        If comPortuc500_flag = False Then
            btnCloseUC500.BackColor = Color.Red
        End If
        '============單行初始===============================================
        fileRead()
        Findcontrol(GroupBox3.Controls)
        keystxt = txtlist.Keys.ToList '排列dictionary鍵值順序
        keysradio = Radiolist.Keys.ToList
        keystxt.Sort()
        keysradio.Sort()

        For i = 0 To txtlist.Count - 1
            Dim tempsplit() As String = Split(Marktable(i + 1), ":")
            With txtlist.Item(keystxt(i))
                .setminimum = CSByte(tempsplit(1))
                .setmaximum = CSByte(tempsplit(2))
                .setType = CByte(tempsplit(3))
                .setfalg = True
                .Text = tempsplit(4)
            End With
            'If initialPLCcommFlag = True Then
            '    txtlist.Item(keys(i)).Text = CType(ClassShared.PLC2real(txtlist.Item(keys(i)).setType, txtlist.Item(keys(i)).getsinged, A_RX(keys(i) - keys(0))), String)
            'End If
        Next
        Dim initialradio() = Split(Marktable(0), ":")
        For i = 0 To Radiolist.Count - 1
            If i = initialradio(4) Then
                Radiolist.Item(keysradio(i)).Checked = True
                Exit For
            End If
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitialSet()
    End Sub


#Region "通訊連線"
    Private Sub btnconectUC500_Click(sender As Object, e As EventArgs) Handles btnconectUC500.Click

        Try
            Dim com = PortUC500.SelectedItem
            Dim baud = UC500baud.SelectedItem
            If UC500class.serialPORTopen(com, baud) Then
                btnconectUC500.BackColor = Color.Green
                btnCloseUC500.BackColor = Color.Gainsboro
                comPortuc500_flag = UC500class.getPortON_flag
            Else
                MsgBox("通訊失敗")
            End If
        Catch ex As Exception
            MsgBox("通訊失敗")
        End Try
    End Sub

    Private Sub btnCloseUC500_Click(sender As Object, e As EventArgs) Handles btnCloseUC500.Click
        If UC500class.serialPORTclose Then
            btnconectUC500.BackColor = Color.Gainsboro
            btnCloseUC500.BackColor = Color.Red
            comPortuc500_flag = UC500class.getPortON_flag
        Else
            MsgBox("通訊失敗")
        End If
    End Sub

    Private Sub btnconnectPLC_Click(sender As Object, e As EventArgs) Handles btnconnectPLC.Click

    End Sub
    Private Sub btnclosePLC_Click(sender As Object, e As EventArgs) Handles btnclosePLC.Click

    End Sub
#End Region

#Region "打字命令"
    Private Sub btnstate_Click(sender As Object, e As EventArgs) Handles btnstate.Click
        If comPortuc500_flag = True Then
            labstatus.Text = UC500class.STCommand()
            'txt_Receive.Text = UC500class.getcommandTX
        End If

    End Sub

    Private Sub btnstop_Click(sender As Object, e As EventArgs)
        If comPortuc500_flag = True Then
            labstatus.Text = UC500class.AMCommand()
            'txt_Receive.Text = UC500class.getcommandTX
        End If

    End Sub

    Private Sub btnsent_Click(sender As Object, e As EventArgs) Handles btnsent.Click
        For i = 0 To Radiolist.Count - 1
            If Radiolist.Item(keysradio(i)).Checked = True Then
                UC500class.GetMode = i
                Exit For
            End If
        Next

        If comPortuc500_flag = True Then
            UC500class.setMarkspeed = txtMarkspeed.Text
            UC500class.setMovespeed = txtMovespeed.Text
            UC500class.setQC = txtQC.Text
            UC500class.setMarkForce = txtMarkForce.Text

            UC500class.setMarkX = txtX.Text
            UC500class.setMarkY = txtY.Text
            UC500class.setLineSpace = txtLineSpace.Text
            UC500class.setOffsetAngle = txtoffset.Text

            UC500class.setHeigth = txtHeigth.Text
            UC500class.setWidth = txtWidth.Text
            UC500class.setBetween = txtBetween.Text
            UC500class.setFont = txtFont.Text

            labstatus.Text = UC500class.ParticularCommand("MARK.tml")
            'txt_Receive.Text = UC500class.getcommandTX
        End If
    End Sub

    Private Sub btnLD_Click(sender As Object, e As EventArgs)
        If comPortuc500_flag = True Then
            labstatus.Text = UC500class.LDCommand("MARK.tml", txtMarkingCnt.Text, selectMode)
            'txt_Receive.Text = UC500class.getcommandTX
        End If
    End Sub

    Private Sub btnorgin_Click(sender As Object, e As EventArgs) Handles btnorgin.Click
        If comPortuc500_flag = True Then
            labstatus.Text = UC500class.OGCommand()
            'txt_Receive.Text = UC500class.getcommandTX
        End If

    End Sub
    Private Sub btnstopcheck_Click(sender As Object, e As EventArgs) Handles btnstopcheck.Click
        If comPortuc500_flag = True Then
            labstatus.Text = UC500class.ADCommand()
            'txt_Receive.Text = UC500class.getcommandTX
        End If

    End Sub

    Private Sub btnstart_Click(sender As Object, e As EventArgs)
        Select Case txtPerCnt.Text
            Case 0 '單行打字 
                UC500class.VSCommand(0, txtVar1.Text)
            Case Else '雙行打字
                Dim value = txtVar1.Text

                Dim line1 = Mid(txtVar1.Text, 1, txtPerCnt.Text)
                Dim line2 = Mid(txtVar1.Text, txtPerCnt.Text + 1, Len(txtVar1.Text) - txtPerCnt.Text)
                UC500class.VSCommand(0, line1)
                UC500class.VSCommand(1, line2)
        End Select
        '===================== 執行GO =====================================
        If comPortuc500_flag = True Then
            labstatus.Text = UC500class.GOCommand()
            'txt_Receive.Text = UC500class.getcommandTX
        End If

    End Sub

    Private Sub btnmachinfo_Click(sender As Object, e As EventArgs) Handles btnmachinfo.Click
        If comPortuc500_flag = True Then
            txt_Receive.Text = UC500class.GICommand()
            ' UC500class.getcommandTX
        End If
    End Sub

    Private Sub btnmarkinglist_Click(sender As Object, e As EventArgs) Handles btnmarkinglist.Click
        Dim FileList As New List(Of String)
        If comPortuc500_flag = True Then
            FileList = UC500class.LSCommand
            'txt_Receive.Text = UC500class.getcommandTX
        End If

        listMarkfile.Items.Clear()
        For Each list In FileList
            listMarkfile.Items.Add(list)
        Next
    End Sub

    Private Sub btngetfile_Click(sender As Object, e As EventArgs) Handles btngetfile.Click
        If listMarkfile.SelectedItem = "" Then
            MsgBox("先選擇檔案")
            Exit Sub
        End If
        '======= 封包通訊 ========================================
        If comPortuc500_flag = True Then
            Dim Str = UC500class.GFCommand(listMarkfile.SelectedItem)
            txt_Receive.Text = Str
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If listMarkfile.SelectedItem = "" Then
            MsgBox("先選擇檔案")
            Exit Sub
        End If
        '======= 封包通訊 ========================================
        If comPortuc500_flag = True Then
            labstatus.Text = UC500class.RMCommand(listMarkfile.SelectedItem)
            'txt_Receive.Text = UC500class.getcommandTX
        End If
    End Sub

    Private Sub btnSHOW_Click(sender As Object, e As EventArgs) Handles btnSHOW.Click
        txt_Receive.Text = ""
        txt_Receive.Text = UC500class.getcommandTX
    End Sub

#End Region

#Region "其他"
    Dim selectMode As String = "N"
    ''' <summary>
    ''' 自動模式選擇
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Radio_N_CheckedChanged(sender As Object, e As EventArgs)
        Dim Radio As RadioButton = CType(sender, RadioButton)
        If (Radio.Equals(Radio_N)) Then
            txtMarkingCnt.Enabled = True
            selectMode = "N"
        ElseIf (Radio.Equals(Radio_S)) Then
            txtMarkingCnt.Enabled = False
            txtMarkingCnt.Text = 1
            selectMode = "S"
        ElseIf (Radio.Equals(Radio_A)) Then
            txtMarkingCnt.Enabled = False
            txtMarkingCnt.Text = 0
            selectMode = "A"
        End If
    End Sub
#End Region

End Class
