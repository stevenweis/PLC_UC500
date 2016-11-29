<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnmachinfo = New System.Windows.Forms.Button()
        Me.listMarkfile = New System.Windows.Forms.ListBox()
        Me.btnmarkinglist = New System.Windows.Forms.Button()
        Me.btngetfile = New System.Windows.Forms.Button()
        Me.btnCloseUC500 = New System.Windows.Forms.Button()
        Me.UC500baud = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtVar1 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnReadPLC = New System.Windows.Forms.Button()
        Me.btnAutorun = New System.Windows.Forms.Button()
        Me.btnOneProcess = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.labstatus = New System.Windows.Forms.Label()
        Me.btnorgin = New System.Windows.Forms.Button()
        Me.btnstopcheck = New System.Windows.Forms.Button()
        Me.btnstate = New System.Windows.Forms.Button()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnconectUC500 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PortUC500 = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSHOW = New System.Windows.Forms.Button()
        Me.txt_Receive = New System.Windows.Forms.RichTextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnsent = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.RadioButton13 = New System.Windows.Forms.RadioButton()
        Me.RadioButton14 = New System.Windows.Forms.RadioButton()
        Me.RadioButton15 = New System.Windows.Forms.RadioButton()
        Me.RadioButton16 = New System.Windows.Forms.RadioButton()
        Me.RadioButton9 = New System.Windows.Forms.RadioButton()
        Me.RadioButton10 = New System.Windows.Forms.RadioButton()
        Me.RadioButton11 = New System.Windows.Forms.RadioButton()
        Me.RadioButton12 = New System.Windows.Forms.RadioButton()
        Me.horizontal_Reverse_twoLine = New System.Windows.Forms.RadioButton()
        Me.horizontal_Reverse = New System.Windows.Forms.RadioButton()
        Me.horizontal_twoLine = New System.Windows.Forms.RadioButton()
        Me.horizontal = New System.Windows.Forms.RadioButton()
        Me.Vertical_Reverse_twoLine = New System.Windows.Forms.RadioButton()
        Me.Vertical_twoLine = New System.Windows.Forms.RadioButton()
        Me.Vertical_Reverse = New System.Windows.Forms.RadioButton()
        Me.Vertical = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PortPLC = New System.Windows.Forms.ComboBox()
        Me.btnclosePLC = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PLCbaud = New System.Windows.Forms.ComboBox()
        Me.btnconnectPLC = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Radio_S = New System.Windows.Forms.RadioButton()
        Me.Radio_N = New System.Windows.Forms.RadioButton()
        Me.Radio_A = New System.Windows.Forms.RadioButton()
        Me.txtMarkingCnt = New System.Windows.Forms.TextBox()
        Me.btnstart = New System.Windows.Forms.Button()
        Me.btnLD = New System.Windows.Forms.Button()
        Me.btnstop = New System.Windows.Forms.Button()
        Me.txtPerCnt = New PLC_UC500.ClassTextbox()
        Me.txtMarkForce = New PLC_UC500.ClassTextbox()
        Me.txtQC = New PLC_UC500.ClassTextbox()
        Me.txtMovespeed = New PLC_UC500.ClassTextbox()
        Me.txtMarkspeed = New PLC_UC500.ClassTextbox()
        Me.txtFont = New PLC_UC500.ClassTextbox()
        Me.txtHeigth = New PLC_UC500.ClassTextbox()
        Me.txtWidth = New PLC_UC500.ClassTextbox()
        Me.txtBetween = New PLC_UC500.ClassTextbox()
        Me.txtY = New PLC_UC500.ClassTextbox()
        Me.txtX = New PLC_UC500.ClassTextbox()
        Me.txtLineSpace = New PLC_UC500.ClassTextbox()
        Me.txtoffset = New PLC_UC500.ClassTextbox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnmachinfo)
        Me.GroupBox1.Controls.Add(Me.listMarkfile)
        Me.GroupBox1.Controls.Add(Me.btnmarkinglist)
        Me.GroupBox1.Controls.Add(Me.btngetfile)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 176)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(384, 142)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "打標機文件訊息"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(90, 102)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 35)
        Me.btnDelete.TabIndex = 15
        Me.btnDelete.Text = "刪除文件(RM)"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnmachinfo
        '
        Me.btnmachinfo.Location = New System.Drawing.Point(9, 21)
        Me.btnmachinfo.Name = "btnmachinfo"
        Me.btnmachinfo.Size = New System.Drawing.Size(75, 35)
        Me.btnmachinfo.TabIndex = 10
        Me.btnmachinfo.Text = "打字機資訊(GI)"
        Me.btnmachinfo.UseVisualStyleBackColor = True
        '
        'listMarkfile
        '
        Me.listMarkfile.FormattingEnabled = True
        Me.listMarkfile.ItemHeight = 12
        Me.listMarkfile.Location = New System.Drawing.Point(187, 24)
        Me.listMarkfile.Name = "listMarkfile"
        Me.listMarkfile.Size = New System.Drawing.Size(188, 112)
        Me.listMarkfile.TabIndex = 13
        '
        'btnmarkinglist
        '
        Me.btnmarkinglist.Location = New System.Drawing.Point(90, 21)
        Me.btnmarkinglist.Name = "btnmarkinglist"
        Me.btnmarkinglist.Size = New System.Drawing.Size(75, 35)
        Me.btnmarkinglist.TabIndex = 11
        Me.btnmarkinglist.Text = "文件列表(LS)"
        Me.btnmarkinglist.UseVisualStyleBackColor = True
        '
        'btngetfile
        '
        Me.btngetfile.Location = New System.Drawing.Point(90, 61)
        Me.btngetfile.Name = "btngetfile"
        Me.btngetfile.Size = New System.Drawing.Size(75, 35)
        Me.btngetfile.TabIndex = 9
        Me.btngetfile.Text = "文件內容(GF)"
        Me.btngetfile.UseVisualStyleBackColor = True
        '
        'btnCloseUC500
        '
        Me.btnCloseUC500.Location = New System.Drawing.Point(300, 48)
        Me.btnCloseUC500.Name = "btnCloseUC500"
        Me.btnCloseUC500.Size = New System.Drawing.Size(75, 23)
        Me.btnCloseUC500.TabIndex = 39
        Me.btnCloseUC500.Text = "close"
        Me.btnCloseUC500.UseVisualStyleBackColor = True
        '
        'UC500baud
        '
        Me.UC500baud.FormattingEnabled = True
        Me.UC500baud.Items.AddRange(New Object() {"115200", "19200", "9600"})
        Me.UC500baud.Location = New System.Drawing.Point(158, 17)
        Me.UC500baud.Name = "UC500baud"
        Me.UC500baud.Size = New System.Drawing.Size(121, 20)
        Me.UC500baud.TabIndex = 38
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(121, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 12)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "鲍率"
        '
        'txtVar1
        '
        Me.txtVar1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtVar1.Location = New System.Drawing.Point(23, 31)
        Me.txtVar1.MaxLength = 8
        Me.txtVar1.Name = "txtVar1"
        Me.txtVar1.Size = New System.Drawing.Size(102, 27)
        Me.txtVar1.TabIndex = 30
        Me.txtVar1.Text = "12345678"
        Me.txtVar1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 8)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 16)
        Me.Label23.TabIndex = 31
        Me.Label23.Text = "打字字串"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.TabControl1)
        Me.GroupBox4.Controls.Add(Me.btnReadPLC)
        Me.GroupBox4.Controls.Add(Me.Panel1)
        Me.GroupBox4.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox4.Controls.Add(Me.btnorgin)
        Me.GroupBox4.Controls.Add(Me.btnstopcheck)
        Me.GroupBox4.Controls.Add(Me.btnstate)
        Me.GroupBox4.Location = New System.Drawing.Point(400, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(598, 257)
        Me.GroupBox4.TabIndex = 36
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "打標動作"
        Me.GroupBox4.UseCompatibleTextRendering = True
        '
        'btnReadPLC
        '
        Me.btnReadPLC.Location = New System.Drawing.Point(90, 138)
        Me.btnReadPLC.Name = "btnReadPLC"
        Me.btnReadPLC.Size = New System.Drawing.Size(75, 33)
        Me.btnReadPLC.TabIndex = 61
        Me.btnReadPLC.Text = "讀取PLC資料"
        Me.btnReadPLC.UseVisualStyleBackColor = True
        '
        'btnAutorun
        '
        Me.btnAutorun.Location = New System.Drawing.Point(92, 10)
        Me.btnAutorun.Name = "btnAutorun"
        Me.btnAutorun.Size = New System.Drawing.Size(75, 33)
        Me.btnAutorun.TabIndex = 53
        Me.btnAutorun.Text = "自動運轉模擬"
        Me.btnAutorun.UseVisualStyleBackColor = True
        '
        'btnOneProcess
        '
        Me.btnOneProcess.Location = New System.Drawing.Point(6, 10)
        Me.btnOneProcess.Name = "btnOneProcess"
        Me.btnOneProcess.Size = New System.Drawing.Size(75, 33)
        Me.btnOneProcess.TabIndex = 52
        Me.btnOneProcess.Text = "一行程模擬"
        Me.btnOneProcess.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtVar1)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Location = New System.Drawing.Point(170, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(150, 65)
        Me.Panel1.TabIndex = 51
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Gold
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.labstatus, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(20, 17)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(64, 234)
        Me.TableLayoutPanel1.TabIndex = 23
        '
        'labstatus
        '
        Me.labstatus.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.labstatus.AutoSize = True
        Me.labstatus.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.labstatus.ForeColor = System.Drawing.Color.Red
        Me.labstatus.Location = New System.Drawing.Point(12, 109)
        Me.labstatus.Name = "labstatus"
        Me.labstatus.Size = New System.Drawing.Size(40, 16)
        Me.labstatus.TabIndex = 22
        Me.labstatus.Text = "狀態"
        '
        'btnorgin
        '
        Me.btnorgin.Location = New System.Drawing.Point(89, 56)
        Me.btnorgin.Name = "btnorgin"
        Me.btnorgin.Size = New System.Drawing.Size(75, 33)
        Me.btnorgin.TabIndex = 20
        Me.btnorgin.Text = "回原點" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(OG)"
        Me.btnorgin.UseVisualStyleBackColor = True
        '
        'btnstopcheck
        '
        Me.btnstopcheck.Location = New System.Drawing.Point(89, 96)
        Me.btnstopcheck.Name = "btnstopcheck"
        Me.btnstopcheck.Size = New System.Drawing.Size(75, 33)
        Me.btnstopcheck.TabIndex = 12
        Me.btnstopcheck.Text = "故障確認(AD)"
        Me.btnstopcheck.UseVisualStyleBackColor = True
        '
        'btnstate
        '
        Me.btnstate.Location = New System.Drawing.Point(89, 17)
        Me.btnstate.Name = "btnstate"
        Me.btnstate.Size = New System.Drawing.Size(75, 33)
        Me.btnstate.TabIndex = 28
        Me.btnstate.Text = "目前狀態(ST)"
        Me.btnstate.UseVisualStyleBackColor = True
        '
        'Label52
        '
        Me.Label52.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(3, 9)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(121, 12)
        Me.Label52.TabIndex = 61
        Me.Label52.Text = "每行字數(0=只有一行)"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 12)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "打標力度(0~100)%"
        '
        'btnconectUC500
        '
        Me.btnconectUC500.Location = New System.Drawing.Point(300, 15)
        Me.btnconectUC500.Name = "btnconectUC500"
        Me.btnconectUC500.Size = New System.Drawing.Size(75, 23)
        Me.btnconectUC500.TabIndex = 33
        Me.btnconectUC500.Text = "connect"
        Me.btnconectUC500.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "通訊阜"
        '
        'PortUC500
        '
        Me.PortUC500.FormattingEnabled = True
        Me.PortUC500.Location = New System.Drawing.Point(50, 17)
        Me.PortUC500.Name = "PortUC500"
        Me.PortUC500.Size = New System.Drawing.Size(65, 20)
        Me.PortUC500.TabIndex = 31
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSHOW)
        Me.GroupBox2.Controls.Add(Me.txt_Receive)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 324)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(384, 398)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "資料訊息"
        '
        'btnSHOW
        '
        Me.btnSHOW.Location = New System.Drawing.Point(9, 16)
        Me.btnSHOW.Name = "btnSHOW"
        Me.btnSHOW.Size = New System.Drawing.Size(75, 23)
        Me.btnSHOW.TabIndex = 4
        Me.btnSHOW.Text = "SHOW"
        Me.btnSHOW.UseVisualStyleBackColor = True
        '
        'txt_Receive
        '
        Me.txt_Receive.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txt_Receive.Location = New System.Drawing.Point(3, 45)
        Me.txt_Receive.Name = "txt_Receive"
        Me.txt_Receive.ReadOnly = True
        Me.txt_Receive.Size = New System.Drawing.Size(378, 350)
        Me.txt_Receive.TabIndex = 3
        Me.txt_Receive.Text = ""
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.btnsent)
        Me.GroupBox3.Controls.Add(Me.Panel5)
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel8)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel6)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupBox3.Location = New System.Drawing.Point(400, 270)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(598, 452)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "打標檔設定"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(17, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "打標模式"
        '
        'btnsent
        '
        Me.btnsent.Location = New System.Drawing.Point(463, 408)
        Me.btnsent.Name = "btnsent"
        Me.btnsent.Size = New System.Drawing.Size(75, 33)
        Me.btnsent.TabIndex = 54
        Me.btnsent.Text = "建立" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(PF)"
        Me.btnsent.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.RadioButton13)
        Me.Panel5.Controls.Add(Me.RadioButton14)
        Me.Panel5.Controls.Add(Me.RadioButton15)
        Me.Panel5.Controls.Add(Me.RadioButton16)
        Me.Panel5.Controls.Add(Me.RadioButton9)
        Me.Panel5.Controls.Add(Me.RadioButton10)
        Me.Panel5.Controls.Add(Me.RadioButton11)
        Me.Panel5.Controls.Add(Me.RadioButton12)
        Me.Panel5.Controls.Add(Me.horizontal_Reverse_twoLine)
        Me.Panel5.Controls.Add(Me.horizontal_Reverse)
        Me.Panel5.Controls.Add(Me.horizontal_twoLine)
        Me.Panel5.Controls.Add(Me.horizontal)
        Me.Panel5.Controls.Add(Me.Vertical_Reverse_twoLine)
        Me.Panel5.Controls.Add(Me.Vertical_twoLine)
        Me.Panel5.Controls.Add(Me.Vertical_Reverse)
        Me.Panel5.Controls.Add(Me.Vertical)
        Me.Panel5.Location = New System.Drawing.Point(41, 41)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(535, 91)
        Me.Panel5.TabIndex = 45
        '
        'RadioButton13
        '
        Me.RadioButton13.AutoSize = True
        Me.RadioButton13.Location = New System.Drawing.Point(371, 69)
        Me.RadioButton13.Name = "RadioButton13"
        Me.RadioButton13.Size = New System.Drawing.Size(127, 16)
        Me.RadioButton13.TabIndex = 15
        Me.RadioButton13.Tag = "1"
        Me.RadioButton13.Text = "圓弧(水平反向二行)"
        Me.RadioButton13.UseVisualStyleBackColor = True
        '
        'RadioButton14
        '
        Me.RadioButton14.AutoSize = True
        Me.RadioButton14.Location = New System.Drawing.Point(371, 29)
        Me.RadioButton14.Name = "RadioButton14"
        Me.RadioButton14.Size = New System.Drawing.Size(103, 16)
        Me.RadioButton14.TabIndex = 13
        Me.RadioButton14.Tag = "1"
        Me.RadioButton14.Text = "圓弧(水平二行)"
        Me.RadioButton14.UseVisualStyleBackColor = True
        '
        'RadioButton15
        '
        Me.RadioButton15.AutoSize = True
        Me.RadioButton15.Location = New System.Drawing.Point(371, 49)
        Me.RadioButton15.Name = "RadioButton15"
        Me.RadioButton15.Size = New System.Drawing.Size(127, 16)
        Me.RadioButton15.TabIndex = 14
        Me.RadioButton15.Tag = "1"
        Me.RadioButton15.Text = "圓弧(垂直反向二行)"
        Me.RadioButton15.UseVisualStyleBackColor = True
        '
        'RadioButton16
        '
        Me.RadioButton16.AutoSize = True
        Me.RadioButton16.Location = New System.Drawing.Point(371, 9)
        Me.RadioButton16.Name = "RadioButton16"
        Me.RadioButton16.Size = New System.Drawing.Size(103, 16)
        Me.RadioButton16.TabIndex = 12
        Me.RadioButton16.Tag = "1"
        Me.RadioButton16.Text = "圓弧(垂直二行)"
        Me.RadioButton16.UseVisualStyleBackColor = True
        '
        'RadioButton9
        '
        Me.RadioButton9.AutoSize = True
        Me.RadioButton9.Location = New System.Drawing.Point(243, 69)
        Me.RadioButton9.Name = "RadioButton9"
        Me.RadioButton9.Size = New System.Drawing.Size(103, 16)
        Me.RadioButton9.TabIndex = 11
        Me.RadioButton9.Tag = "1"
        Me.RadioButton9.Text = "圓弧(水平反向)"
        Me.RadioButton9.UseVisualStyleBackColor = True
        '
        'RadioButton10
        '
        Me.RadioButton10.AutoSize = True
        Me.RadioButton10.Location = New System.Drawing.Point(243, 29)
        Me.RadioButton10.Name = "RadioButton10"
        Me.RadioButton10.Size = New System.Drawing.Size(79, 16)
        Me.RadioButton10.TabIndex = 9
        Me.RadioButton10.Tag = "1"
        Me.RadioButton10.Text = "圓弧(水平)"
        Me.RadioButton10.UseVisualStyleBackColor = True
        '
        'RadioButton11
        '
        Me.RadioButton11.AutoSize = True
        Me.RadioButton11.Location = New System.Drawing.Point(243, 49)
        Me.RadioButton11.Name = "RadioButton11"
        Me.RadioButton11.Size = New System.Drawing.Size(103, 16)
        Me.RadioButton11.TabIndex = 10
        Me.RadioButton11.Tag = "1"
        Me.RadioButton11.Text = "圓弧(垂直反向)"
        Me.RadioButton11.UseVisualStyleBackColor = True
        '
        'RadioButton12
        '
        Me.RadioButton12.AutoSize = True
        Me.RadioButton12.Location = New System.Drawing.Point(243, 9)
        Me.RadioButton12.Name = "RadioButton12"
        Me.RadioButton12.Size = New System.Drawing.Size(79, 16)
        Me.RadioButton12.TabIndex = 8
        Me.RadioButton12.Tag = "1"
        Me.RadioButton12.Text = "圓弧(垂直)"
        Me.RadioButton12.UseVisualStyleBackColor = True
        '
        'horizontal_Reverse_twoLine
        '
        Me.horizontal_Reverse_twoLine.AutoSize = True
        Me.horizontal_Reverse_twoLine.Location = New System.Drawing.Point(119, 70)
        Me.horizontal_Reverse_twoLine.Name = "horizontal_Reverse_twoLine"
        Me.horizontal_Reverse_twoLine.Size = New System.Drawing.Size(95, 16)
        Me.horizontal_Reverse_twoLine.TabIndex = 7
        Me.horizontal_Reverse_twoLine.Tag = "1"
        Me.horizontal_Reverse_twoLine.Text = "水平反向二行"
        Me.horizontal_Reverse_twoLine.UseVisualStyleBackColor = True
        '
        'horizontal_Reverse
        '
        Me.horizontal_Reverse.AutoSize = True
        Me.horizontal_Reverse.Location = New System.Drawing.Point(10, 70)
        Me.horizontal_Reverse.Name = "horizontal_Reverse"
        Me.horizontal_Reverse.Size = New System.Drawing.Size(71, 16)
        Me.horizontal_Reverse.TabIndex = 3
        Me.horizontal_Reverse.Tag = "1"
        Me.horizontal_Reverse.Text = "水平反向"
        Me.horizontal_Reverse.UseVisualStyleBackColor = True
        '
        'horizontal_twoLine
        '
        Me.horizontal_twoLine.AutoSize = True
        Me.horizontal_twoLine.Location = New System.Drawing.Point(119, 30)
        Me.horizontal_twoLine.Name = "horizontal_twoLine"
        Me.horizontal_twoLine.Size = New System.Drawing.Size(71, 16)
        Me.horizontal_twoLine.TabIndex = 5
        Me.horizontal_twoLine.Tag = "1"
        Me.horizontal_twoLine.Text = "水平二行"
        Me.horizontal_twoLine.UseVisualStyleBackColor = True
        '
        'horizontal
        '
        Me.horizontal.AutoSize = True
        Me.horizontal.Location = New System.Drawing.Point(10, 30)
        Me.horizontal.Name = "horizontal"
        Me.horizontal.Size = New System.Drawing.Size(47, 16)
        Me.horizontal.TabIndex = 1
        Me.horizontal.Tag = "1"
        Me.horizontal.Text = "水平"
        Me.horizontal.UseVisualStyleBackColor = True
        '
        'Vertical_Reverse_twoLine
        '
        Me.Vertical_Reverse_twoLine.AutoSize = True
        Me.Vertical_Reverse_twoLine.Location = New System.Drawing.Point(119, 50)
        Me.Vertical_Reverse_twoLine.Name = "Vertical_Reverse_twoLine"
        Me.Vertical_Reverse_twoLine.Size = New System.Drawing.Size(95, 16)
        Me.Vertical_Reverse_twoLine.TabIndex = 6
        Me.Vertical_Reverse_twoLine.Tag = "1"
        Me.Vertical_Reverse_twoLine.Text = "垂直反向二行"
        Me.Vertical_Reverse_twoLine.UseVisualStyleBackColor = True
        '
        'Vertical_twoLine
        '
        Me.Vertical_twoLine.AutoSize = True
        Me.Vertical_twoLine.Location = New System.Drawing.Point(119, 10)
        Me.Vertical_twoLine.Name = "Vertical_twoLine"
        Me.Vertical_twoLine.Size = New System.Drawing.Size(71, 16)
        Me.Vertical_twoLine.TabIndex = 4
        Me.Vertical_twoLine.Tag = "1"
        Me.Vertical_twoLine.Text = "垂直二行"
        Me.Vertical_twoLine.UseVisualStyleBackColor = True
        '
        'Vertical_Reverse
        '
        Me.Vertical_Reverse.AutoSize = True
        Me.Vertical_Reverse.Location = New System.Drawing.Point(10, 50)
        Me.Vertical_Reverse.Name = "Vertical_Reverse"
        Me.Vertical_Reverse.Size = New System.Drawing.Size(71, 16)
        Me.Vertical_Reverse.TabIndex = 2
        Me.Vertical_Reverse.Tag = "1"
        Me.Vertical_Reverse.Text = "垂直反向"
        Me.Vertical_Reverse.UseVisualStyleBackColor = True
        '
        'Vertical
        '
        Me.Vertical.AutoSize = True
        Me.Vertical.Checked = True
        Me.Vertical.Location = New System.Drawing.Point(10, 10)
        Me.Vertical.Name = "Vertical"
        Me.Vertical.Size = New System.Drawing.Size(47, 16)
        Me.Vertical.TabIndex = 0
        Me.Vertical.TabStop = True
        Me.Vertical.Tag = "1"
        Me.Vertical.Text = "垂直"
        Me.Vertical.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.5!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.5!))
        Me.TableLayoutPanel8.Controls.Add(Me.txtPerCnt, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Label52, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Label24, 0, 2)
        Me.TableLayoutPanel8.Controls.Add(Me.Label25, 0, 1)
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(309, 310)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 3
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(229, 90)
        Me.TableLayoutPanel8.TabIndex = 3
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(3, 69)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(123, 12)
        Me.Label24.TabIndex = 41
        Me.Label24.Text = "順逆時針(C模式)(C,W)"
        Me.Label24.Visible = False
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 39)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(135, 12)
        Me.Label25.TabIndex = 28
        Me.Label25.Text = "半徑(圓弧)(0.50~1000.00)"
        Me.Label25.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.Location = New System.Drawing.Point(281, 294)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 13)
        Me.Label20.TabIndex = 44
        Me.Label20.Text = "打標參數"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.5!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.5!))
        Me.TableLayoutPanel4.Controls.Add(Me.txtMarkForce, 1, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.txtQC, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.txtMovespeed, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.txtMarkspeed, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label9, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Label10, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label12, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label15, 0, 2)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(41, 160)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(229, 116)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 12)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "打字速度(0~100)%"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 12)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "移動速度(0~100)%"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 12)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "打標質量(0~100)%"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.Location = New System.Drawing.Point(281, 144)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 13)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "字型"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.Location = New System.Drawing.Point(17, 144)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "打標品質"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.5!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.5!))
        Me.TableLayoutPanel6.Controls.Add(Me.txtFont, 1, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.Label17, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.Label16, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label29, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.txtHeigth, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.txtWidth, 1, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.txtBetween, 1, 2)
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(309, 160)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 4
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(229, 116)
        Me.TableLayoutPanel6.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 12)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "字型(0,2,3)"
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 37)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 12)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "字寬(mm)"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(115, 12)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "字高(0.50~100.00)mm"
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(3, 66)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(67, 12)
        Me.Label29.TabIndex = 27
        Me.Label29.Text = "字間距(mm)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.Location = New System.Drawing.Point(17, 294)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "打標位置"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.5!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.5!))
        Me.TableLayoutPanel5.Controls.Add(Me.txtY, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.txtX, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.Label26, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label27, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label6, 0, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.txtLineSpace, 1, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.txtoffset, 1, 3)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(41, 310)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 4
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(229, 125)
        Me.TableLayoutPanel5.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 12)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "行間距(mm)"
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(3, 9)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(132, 12)
        Me.Label26.TabIndex = 31
        Me.Label26.Text = "X軸座標 (0.00~50.00)mm"
        '
        'Label27
        '
        Me.Label27.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(3, 40)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(132, 12)
        Me.Label27.TabIndex = 30
        Me.Label27.Text = "Y軸座標 (0.00~20.00)mm"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 12)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "角度補償(-10~10)度"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.PortUC500)
        Me.GroupBox5.Controls.Add(Me.btnCloseUC500)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.UC500baud)
        Me.GroupBox5.Controls.Add(Me.btnconectUC500)
        Me.GroupBox5.Location = New System.Drawing.Point(10, 7)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(384, 78)
        Me.GroupBox5.TabIndex = 41
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "打字機連線"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.PortPLC)
        Me.GroupBox6.Controls.Add(Me.btnclosePLC)
        Me.GroupBox6.Controls.Add(Me.Label14)
        Me.GroupBox6.Controls.Add(Me.PLCbaud)
        Me.GroupBox6.Controls.Add(Me.btnconnectPLC)
        Me.GroupBox6.Location = New System.Drawing.Point(10, 92)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(384, 78)
        Me.GroupBox6.TabIndex = 42
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "PLC連線"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "通訊阜"
        '
        'PortPLC
        '
        Me.PortPLC.FormattingEnabled = True
        Me.PortPLC.Location = New System.Drawing.Point(50, 17)
        Me.PortPLC.Name = "PortPLC"
        Me.PortPLC.Size = New System.Drawing.Size(65, 20)
        Me.PortPLC.TabIndex = 31
        '
        'btnclosePLC
        '
        Me.btnclosePLC.Location = New System.Drawing.Point(300, 48)
        Me.btnclosePLC.Name = "btnclosePLC"
        Me.btnclosePLC.Size = New System.Drawing.Size(75, 23)
        Me.btnclosePLC.TabIndex = 39
        Me.btnclosePLC.Text = "close"
        Me.btnclosePLC.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(121, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 12)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "鲍率"
        '
        'PLCbaud
        '
        Me.PLCbaud.FormattingEnabled = True
        Me.PLCbaud.Items.AddRange(New Object() {"115200", "19200", "9600"})
        Me.PLCbaud.Location = New System.Drawing.Point(158, 17)
        Me.PLCbaud.Name = "PLCbaud"
        Me.PLCbaud.Size = New System.Drawing.Size(121, 20)
        Me.PLCbaud.TabIndex = 38
        '
        'btnconnectPLC
        '
        Me.btnconnectPLC.Location = New System.Drawing.Point(300, 15)
        Me.btnconnectPLC.Name = "btnconnectPLC"
        Me.btnconnectPLC.Size = New System.Drawing.Size(75, 23)
        Me.btnconnectPLC.TabIndex = 33
        Me.btnconnectPLC.Text = "connect"
        Me.btnconnectPLC.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(326, 15)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(269, 236)
        Me.TabControl1.TabIndex = 63
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.Radio_S)
        Me.TabPage1.Controls.Add(Me.Radio_N)
        Me.TabPage1.Controls.Add(Me.Radio_A)
        Me.TabPage1.Controls.Add(Me.txtMarkingCnt)
        Me.TabPage1.Controls.Add(Me.btnstart)
        Me.TabPage1.Controls.Add(Me.btnLD)
        Me.TabPage1.Controls.Add(Me.btnstop)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(261, 210)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "手動模擬"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnOneProcess)
        Me.TabPage2.Controls.Add(Me.btnAutorun)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(261, 210)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "自動模擬"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(16, 124)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(109, 12)
        Me.Label22.TabIndex = 76
        Me.Label22.Text = "打印次數(0=無限次)"
        '
        'Radio_S
        '
        Me.Radio_S.AutoSize = True
        Me.Radio_S.Location = New System.Drawing.Point(16, 100)
        Me.Radio_S.Name = "Radio_S"
        Me.Radio_S.Size = New System.Drawing.Size(53, 16)
        Me.Radio_S.TabIndex = 74
        Me.Radio_S.Text = "S模擬"
        Me.Radio_S.UseVisualStyleBackColor = True
        '
        'Radio_N
        '
        Me.Radio_N.AutoSize = True
        Me.Radio_N.Checked = True
        Me.Radio_N.Location = New System.Drawing.Point(16, 56)
        Me.Radio_N.Name = "Radio_N"
        Me.Radio_N.Size = New System.Drawing.Size(58, 16)
        Me.Radio_N.TabIndex = 72
        Me.Radio_N.TabStop = True
        Me.Radio_N.Text = "N 正常"
        Me.Radio_N.UseVisualStyleBackColor = True
        '
        'Radio_A
        '
        Me.Radio_A.AutoSize = True
        Me.Radio_A.Location = New System.Drawing.Point(16, 78)
        Me.Radio_A.Name = "Radio_A"
        Me.Radio_A.Size = New System.Drawing.Size(55, 16)
        Me.Radio_A.TabIndex = 73
        Me.Radio_A.Text = "A自動"
        Me.Radio_A.UseVisualStyleBackColor = True
        '
        'txtMarkingCnt
        '
        Me.txtMarkingCnt.Location = New System.Drawing.Point(16, 141)
        Me.txtMarkingCnt.Name = "txtMarkingCnt"
        Me.txtMarkingCnt.Size = New System.Drawing.Size(58, 22)
        Me.txtMarkingCnt.TabIndex = 75
        Me.txtMarkingCnt.Text = "0"
        '
        'btnstart
        '
        Me.btnstart.Location = New System.Drawing.Point(87, 11)
        Me.btnstart.Name = "btnstart"
        Me.btnstart.Size = New System.Drawing.Size(75, 33)
        Me.btnstart.TabIndex = 71
        Me.btnstart.Text = "打標" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(GO)"
        Me.btnstart.UseVisualStyleBackColor = True
        '
        'btnLD
        '
        Me.btnLD.Location = New System.Drawing.Point(6, 11)
        Me.btnLD.Name = "btnLD"
        Me.btnLD.Size = New System.Drawing.Size(75, 33)
        Me.btnLD.TabIndex = 69
        Me.btnLD.Text = "載入" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(LD)"
        Me.btnLD.UseVisualStyleBackColor = True
        '
        'btnstop
        '
        Me.btnstop.Location = New System.Drawing.Point(171, 11)
        Me.btnstop.Name = "btnstop"
        Me.btnstop.Size = New System.Drawing.Size(75, 33)
        Me.btnstop.TabIndex = 70
        Me.btnstop.Text = "停止打標(AM)"
        Me.btnstop.UseVisualStyleBackColor = True
        '
        'txtPerCnt
        '
        Me.txtPerCnt.boxFlag = 13
        Me.txtPerCnt.Location = New System.Drawing.Point(150, 3)
        Me.txtPerCnt.MaxLength = 1
        Me.txtPerCnt.Name = "txtPerCnt"
        Me.txtPerCnt.setmaximum = 0!
        Me.txtPerCnt.setminimum = 0!
        Me.txtPerCnt.setType = CType(1, Byte)
        Me.txtPerCnt.Size = New System.Drawing.Size(76, 22)
        Me.txtPerCnt.TabIndex = 0
        '
        'txtMarkForce
        '
        Me.txtMarkForce.boxFlag = 4
        Me.txtMarkForce.Location = New System.Drawing.Point(150, 90)
        Me.txtMarkForce.MaxLength = 1
        Me.txtMarkForce.Name = "txtMarkForce"
        Me.txtMarkForce.setmaximum = 0!
        Me.txtMarkForce.setminimum = 0!
        Me.txtMarkForce.setType = CType(1, Byte)
        Me.txtMarkForce.Size = New System.Drawing.Size(76, 22)
        Me.txtMarkForce.TabIndex = 3
        '
        'txtQC
        '
        Me.txtQC.boxFlag = 3
        Me.txtQC.Location = New System.Drawing.Point(150, 61)
        Me.txtQC.MaxLength = 1
        Me.txtQC.Name = "txtQC"
        Me.txtQC.setmaximum = 0!
        Me.txtQC.setminimum = 0!
        Me.txtQC.setType = CType(1, Byte)
        Me.txtQC.Size = New System.Drawing.Size(76, 22)
        Me.txtQC.TabIndex = 2
        '
        'txtMovespeed
        '
        Me.txtMovespeed.boxFlag = 2
        Me.txtMovespeed.Location = New System.Drawing.Point(150, 32)
        Me.txtMovespeed.MaxLength = 1
        Me.txtMovespeed.Name = "txtMovespeed"
        Me.txtMovespeed.setmaximum = 0!
        Me.txtMovespeed.setminimum = 0!
        Me.txtMovespeed.setType = CType(1, Byte)
        Me.txtMovespeed.Size = New System.Drawing.Size(76, 22)
        Me.txtMovespeed.TabIndex = 1
        '
        'txtMarkspeed
        '
        Me.txtMarkspeed.boxFlag = 1
        Me.txtMarkspeed.Location = New System.Drawing.Point(150, 3)
        Me.txtMarkspeed.MaxLength = 1
        Me.txtMarkspeed.Name = "txtMarkspeed"
        Me.txtMarkspeed.setmaximum = 0!
        Me.txtMarkspeed.setminimum = 0!
        Me.txtMarkspeed.setType = CType(1, Byte)
        Me.txtMarkspeed.Size = New System.Drawing.Size(76, 22)
        Me.txtMarkspeed.TabIndex = 0
        '
        'txtFont
        '
        Me.txtFont.boxFlag = 12
        Me.txtFont.Location = New System.Drawing.Point(150, 90)
        Me.txtFont.MaxLength = 1
        Me.txtFont.Name = "txtFont"
        Me.txtFont.setmaximum = 0!
        Me.txtFont.setminimum = 0!
        Me.txtFont.setType = CType(1, Byte)
        Me.txtFont.Size = New System.Drawing.Size(76, 22)
        Me.txtFont.TabIndex = 3
        '
        'txtHeigth
        '
        Me.txtHeigth.boxFlag = 9
        Me.txtHeigth.Location = New System.Drawing.Point(150, 3)
        Me.txtHeigth.MaxLength = 1
        Me.txtHeigth.Name = "txtHeigth"
        Me.txtHeigth.setmaximum = 0!
        Me.txtHeigth.setminimum = 0!
        Me.txtHeigth.setType = CType(1, Byte)
        Me.txtHeigth.Size = New System.Drawing.Size(76, 22)
        Me.txtHeigth.TabIndex = 0
        '
        'txtWidth
        '
        Me.txtWidth.boxFlag = 10
        Me.txtWidth.Location = New System.Drawing.Point(150, 32)
        Me.txtWidth.MaxLength = 1
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.setmaximum = 0!
        Me.txtWidth.setminimum = 0!
        Me.txtWidth.setType = CType(1, Byte)
        Me.txtWidth.Size = New System.Drawing.Size(76, 22)
        Me.txtWidth.TabIndex = 1
        '
        'txtBetween
        '
        Me.txtBetween.boxFlag = 11
        Me.txtBetween.Location = New System.Drawing.Point(150, 61)
        Me.txtBetween.MaxLength = 1
        Me.txtBetween.Name = "txtBetween"
        Me.txtBetween.setmaximum = 0!
        Me.txtBetween.setminimum = 0!
        Me.txtBetween.setType = CType(1, Byte)
        Me.txtBetween.Size = New System.Drawing.Size(76, 22)
        Me.txtBetween.TabIndex = 2
        '
        'txtY
        '
        Me.txtY.boxFlag = 6
        Me.txtY.Location = New System.Drawing.Point(150, 34)
        Me.txtY.MaxLength = 1
        Me.txtY.Name = "txtY"
        Me.txtY.setmaximum = 0!
        Me.txtY.setminimum = 0!
        Me.txtY.setType = CType(1, Byte)
        Me.txtY.Size = New System.Drawing.Size(76, 22)
        Me.txtY.TabIndex = 1
        '
        'txtX
        '
        Me.txtX.boxFlag = 5
        Me.txtX.Location = New System.Drawing.Point(150, 3)
        Me.txtX.MaxLength = 1
        Me.txtX.Name = "txtX"
        Me.txtX.setmaximum = 0!
        Me.txtX.setminimum = 0!
        Me.txtX.setType = CType(1, Byte)
        Me.txtX.Size = New System.Drawing.Size(76, 22)
        Me.txtX.TabIndex = 0
        '
        'txtLineSpace
        '
        Me.txtLineSpace.boxFlag = 7
        Me.txtLineSpace.Location = New System.Drawing.Point(150, 65)
        Me.txtLineSpace.MaxLength = 1
        Me.txtLineSpace.Name = "txtLineSpace"
        Me.txtLineSpace.setmaximum = 0!
        Me.txtLineSpace.setminimum = 0!
        Me.txtLineSpace.setType = CType(1, Byte)
        Me.txtLineSpace.Size = New System.Drawing.Size(76, 22)
        Me.txtLineSpace.TabIndex = 2
        '
        'txtoffset
        '
        Me.txtoffset.boxFlag = 8
        Me.txtoffset.Location = New System.Drawing.Point(150, 96)
        Me.txtoffset.MaxLength = 1
        Me.txtoffset.Name = "txtoffset"
        Me.txtoffset.setmaximum = 0!
        Me.txtoffset.setminimum = 0!
        Me.txtoffset.setType = CType(1, Byte)
        Me.txtoffset.Size = New System.Drawing.Size(76, 22)
        Me.txtoffset.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnmachinfo As Button
    Friend WithEvents listMarkfile As ListBox
    Friend WithEvents btnmarkinglist As Button
    Friend WithEvents btngetfile As Button
    Friend WithEvents btnCloseUC500 As Button
    Friend WithEvents UC500baud As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtVar1 As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnAutorun As Button
    Friend WithEvents btnOneProcess As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents labstatus As Label
    Friend WithEvents btnorgin As Button
    Friend WithEvents btnstopcheck As Button
    Friend WithEvents btnstate As Button
    Friend WithEvents Label52 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnconectUC500 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PortUC500 As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnSHOW As Button
    Friend WithEvents txt_Receive As RichTextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents RadioButton13 As RadioButton
    Friend WithEvents RadioButton14 As RadioButton
    Friend WithEvents RadioButton15 As RadioButton
    Friend WithEvents RadioButton16 As RadioButton
    Friend WithEvents RadioButton9 As RadioButton
    Friend WithEvents RadioButton10 As RadioButton
    Friend WithEvents RadioButton11 As RadioButton
    Friend WithEvents RadioButton12 As RadioButton
    Friend WithEvents horizontal_Reverse_twoLine As RadioButton
    Friend WithEvents horizontal_Reverse As RadioButton
    Friend WithEvents horizontal_twoLine As RadioButton
    Friend WithEvents horizontal As RadioButton
    Friend WithEvents Vertical_Reverse_twoLine As RadioButton
    Friend WithEvents Vertical_twoLine As RadioButton
    Friend WithEvents Vertical_Reverse As RadioButton
    Friend WithEvents Vertical As RadioButton
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents PortPLC As ComboBox
    Friend WithEvents btnclosePLC As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents PLCbaud As ComboBox
    Friend WithEvents btnconnectPLC As Button
    Friend WithEvents txtPerCnt As ClassTextbox
    Friend WithEvents txtMarkForce As ClassTextbox
    Friend WithEvents txtQC As ClassTextbox
    Friend WithEvents txtMovespeed As ClassTextbox
    Friend WithEvents txtMarkspeed As ClassTextbox
    Friend WithEvents txtFont As ClassTextbox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtHeigth As ClassTextbox
    Friend WithEvents txtWidth As ClassTextbox
    Friend WithEvents txtBetween As ClassTextbox
    Friend WithEvents txtY As ClassTextbox
    Friend WithEvents txtX As ClassTextbox
    Friend WithEvents txtLineSpace As ClassTextbox
    Friend WithEvents txtoffset As ClassTextbox
    Friend WithEvents btnsent As Button
    Friend WithEvents btnReadPLC As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label22 As Label
    Friend WithEvents Radio_S As RadioButton
    Friend WithEvents Radio_N As RadioButton
    Friend WithEvents Radio_A As RadioButton
    Friend WithEvents txtMarkingCnt As TextBox
    Friend WithEvents btnstart As Button
    Friend WithEvents btnLD As Button
    Friend WithEvents btnstop As Button
    Friend WithEvents TabPage2 As TabPage
End Class
