<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 認定調査票
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.userList = New System.Windows.Forms.DataGridView()
        Me.kanaLabel = New System.Windows.Forms.Label()
        Me.userLabel = New System.Windows.Forms.Label()
        Me.recordList = New System.Windows.Forms.ListBox()
        Me.btnRegist = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.inputTab = New System.Windows.Forms.TabControl()
        Me.overviewPage = New System.Windows.Forms.TabPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.familyTel3 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.familyTel2 = New System.Windows.Forms.TextBox()
        Me.familyTel1 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.familyAddress = New System.Windows.Forms.TextBox()
        Me.familyPostCode2 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.familyPostCode1 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.currentTel3 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.currentTel2 = New System.Windows.Forms.TextBox()
        Me.currentTel1 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.currentAddress = New System.Windows.Forms.TextBox()
        Me.currentPostCode2 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.currentPostCode1 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ageLabel = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnCalcAge = New System.Windows.Forms.Button()
        Me.birthYmdBox = New ymdBox.ymdBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rbtnWoman = New System.Windows.Forms.RadioButton()
        Me.rbtnMan = New System.Windows.Forms.RadioButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.certifiedResultBox = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lastCertifiedYmdBox = New ymdBox.ymdBox()
        Me.lastCertifiedCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbtnSecondCount = New System.Windows.Forms.RadioButton()
        Me.rbtnFirstCount = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.houseTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbtnHouseOut = New System.Windows.Forms.RadioButton()
        Me.rbtnHouseIn = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.companyBox = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.etcBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dateYmdBox = New ymdBox.ymdBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.specialNotePage = New System.Windows.Forms.TabPage()
        Me.basicSurveyPage = New System.Windows.Forms.TabPage()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.namBox = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.relationBox = New System.Windows.Forms.ComboBox()
        Me.dgvNumInput = New Symphony_KSave2.ExDataGridView()
        CType(Me.userList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.inputTab.SuspendLayout()
        Me.overviewPage.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.dgvNumInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'userList
        '
        Me.userList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.userList.Location = New System.Drawing.Point(12, 85)
        Me.userList.Name = "userList"
        Me.userList.RowTemplate.Height = 21
        Me.userList.Size = New System.Drawing.Size(108, 324)
        Me.userList.TabIndex = 1000
        '
        'kanaLabel
        '
        Me.kanaLabel.AutoSize = True
        Me.kanaLabel.ForeColor = System.Drawing.Color.Blue
        Me.kanaLabel.Location = New System.Drawing.Point(12, 31)
        Me.kanaLabel.Name = "kanaLabel"
        Me.kanaLabel.Size = New System.Drawing.Size(0, 12)
        Me.kanaLabel.TabIndex = 1
        '
        'userLabel
        '
        Me.userLabel.AutoSize = True
        Me.userLabel.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.userLabel.ForeColor = System.Drawing.Color.Blue
        Me.userLabel.Location = New System.Drawing.Point(10, 52)
        Me.userLabel.Name = "userLabel"
        Me.userLabel.Size = New System.Drawing.Size(0, 19)
        Me.userLabel.TabIndex = 2
        '
        'recordList
        '
        Me.recordList.BackColor = System.Drawing.SystemColors.Control
        Me.recordList.FormattingEnabled = True
        Me.recordList.ItemHeight = 12
        Me.recordList.Location = New System.Drawing.Point(14, 424)
        Me.recordList.Name = "recordList"
        Me.recordList.Size = New System.Drawing.Size(106, 160)
        Me.recordList.TabIndex = 1001
        '
        'btnRegist
        '
        Me.btnRegist.Location = New System.Drawing.Point(32, 612)
        Me.btnRegist.Name = "btnRegist"
        Me.btnRegist.Size = New System.Drawing.Size(67, 30)
        Me.btnRegist.TabIndex = 1002
        Me.btnRegist.Text = "登　録"
        Me.btnRegist.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(32, 646)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(67, 30)
        Me.btnDelete.TabIndex = 1003
        Me.btnDelete.Text = "削　除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(32, 680)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(67, 30)
        Me.btnPrint.TabIndex = 1004
        Me.btnPrint.Text = "印　刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'inputTab
        '
        Me.inputTab.Controls.Add(Me.overviewPage)
        Me.inputTab.Controls.Add(Me.specialNotePage)
        Me.inputTab.Controls.Add(Me.basicSurveyPage)
        Me.inputTab.Location = New System.Drawing.Point(135, 12)
        Me.inputTab.Name = "inputTab"
        Me.inputTab.SelectedIndex = 0
        Me.inputTab.Size = New System.Drawing.Size(852, 800)
        Me.inputTab.TabIndex = 8
        '
        'overviewPage
        '
        Me.overviewPage.BackColor = System.Drawing.SystemColors.Control
        Me.overviewPage.Controls.Add(Me.relationBox)
        Me.overviewPage.Controls.Add(Me.Label30)
        Me.overviewPage.Controls.Add(Me.Panel6)
        Me.overviewPage.Controls.Add(Me.Label28)
        Me.overviewPage.Controls.Add(Me.Panel5)
        Me.overviewPage.Controls.Add(Me.Panel4)
        Me.overviewPage.Controls.Add(Me.Label17)
        Me.overviewPage.Controls.Add(Me.Label16)
        Me.overviewPage.Controls.Add(Me.ageLabel)
        Me.overviewPage.Controls.Add(Me.Label15)
        Me.overviewPage.Controls.Add(Me.btnCalcAge)
        Me.overviewPage.Controls.Add(Me.birthYmdBox)
        Me.overviewPage.Controls.Add(Me.Label14)
        Me.overviewPage.Controls.Add(Me.Panel3)
        Me.overviewPage.Controls.Add(Me.Label13)
        Me.overviewPage.Controls.Add(Me.certifiedResultBox)
        Me.overviewPage.Controls.Add(Me.Label12)
        Me.overviewPage.Controls.Add(Me.lastCertifiedYmdBox)
        Me.overviewPage.Controls.Add(Me.lastCertifiedCheckBox)
        Me.overviewPage.Controls.Add(Me.Label11)
        Me.overviewPage.Controls.Add(Me.Label10)
        Me.overviewPage.Controls.Add(Me.Panel2)
        Me.overviewPage.Controls.Add(Me.Label9)
        Me.overviewPage.Controls.Add(Me.Label8)
        Me.overviewPage.Controls.Add(Me.Label7)
        Me.overviewPage.Controls.Add(Me.houseTextBox)
        Me.overviewPage.Controls.Add(Me.Label6)
        Me.overviewPage.Controls.Add(Me.Panel1)
        Me.overviewPage.Controls.Add(Me.Label5)
        Me.overviewPage.Controls.Add(Me.companyBox)
        Me.overviewPage.Controls.Add(Me.Label4)
        Me.overviewPage.Controls.Add(Me.etcBox)
        Me.overviewPage.Controls.Add(Me.Label3)
        Me.overviewPage.Controls.Add(Me.dateYmdBox)
        Me.overviewPage.Controls.Add(Me.Label2)
        Me.overviewPage.Controls.Add(Me.Label1)
        Me.overviewPage.Controls.Add(Me.btnClear)
        Me.overviewPage.Controls.Add(Me.dgvNumInput)
        Me.overviewPage.Location = New System.Drawing.Point(4, 22)
        Me.overviewPage.Name = "overviewPage"
        Me.overviewPage.Padding = New System.Windows.Forms.Padding(3)
        Me.overviewPage.Size = New System.Drawing.Size(844, 774)
        Me.overviewPage.TabIndex = 0
        Me.overviewPage.Text = "概　況　調　査"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.Panel5.Controls.Add(Me.familyTel3)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.Label24)
        Me.Panel5.Controls.Add(Me.familyTel2)
        Me.Panel5.Controls.Add(Me.familyTel1)
        Me.Panel5.Controls.Add(Me.Label25)
        Me.Panel5.Controls.Add(Me.familyAddress)
        Me.Panel5.Controls.Add(Me.familyPostCode2)
        Me.Panel5.Controls.Add(Me.Label26)
        Me.Panel5.Controls.Add(Me.familyPostCode1)
        Me.Panel5.Controls.Add(Me.Label27)
        Me.Panel5.Location = New System.Drawing.Point(98, 228)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(734, 21)
        Me.Panel5.TabIndex = 41
        '
        'familyTel3
        '
        Me.familyTel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.familyTel3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.familyTel3.Location = New System.Drawing.Point(671, 1)
        Me.familyTel3.Name = "familyTel3"
        Me.familyTel3.Size = New System.Drawing.Size(62, 19)
        Me.familyTel3.TabIndex = 46
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(656, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(11, 12)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "-"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(575, 5)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(11, 12)
        Me.Label24.TabIndex = 38
        Me.Label24.Text = "-"
        '
        'familyTel2
        '
        Me.familyTel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.familyTel2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.familyTel2.Location = New System.Drawing.Point(590, 1)
        Me.familyTel2.Name = "familyTel2"
        Me.familyTel2.Size = New System.Drawing.Size(62, 19)
        Me.familyTel2.TabIndex = 44
        '
        'familyTel1
        '
        Me.familyTel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.familyTel1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.familyTel1.Location = New System.Drawing.Point(508, 1)
        Me.familyTel1.Name = "familyTel1"
        Me.familyTel1.Size = New System.Drawing.Size(62, 19)
        Me.familyTel1.TabIndex = 42
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(474, 4)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(29, 12)
        Me.Label25.TabIndex = 32
        Me.Label25.Text = "電話"
        '
        'familyAddress
        '
        Me.familyAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.familyAddress.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.familyAddress.Location = New System.Drawing.Point(156, 1)
        Me.familyAddress.Name = "familyAddress"
        Me.familyAddress.Size = New System.Drawing.Size(313, 19)
        Me.familyAddress.TabIndex = 41
        '
        'familyPostCode2
        '
        Me.familyPostCode2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.familyPostCode2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.familyPostCode2.Location = New System.Drawing.Point(83, 1)
        Me.familyPostCode2.Name = "familyPostCode2"
        Me.familyPostCode2.Size = New System.Drawing.Size(55, 19)
        Me.familyPostCode2.TabIndex = 40
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(70, 5)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(11, 12)
        Me.Label26.TabIndex = 32
        Me.Label26.Text = "-"
        '
        'familyPostCode1
        '
        Me.familyPostCode1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.familyPostCode1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.familyPostCode1.Location = New System.Drawing.Point(21, 1)
        Me.familyPostCode1.Name = "familyPostCode1"
        Me.familyPostCode1.Size = New System.Drawing.Size(46, 19)
        Me.familyPostCode1.TabIndex = 38
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(4, 5)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(17, 12)
        Me.Label27.TabIndex = 33
        Me.Label27.Text = "〒"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.Panel4.Controls.Add(Me.currentTel3)
        Me.Panel4.Controls.Add(Me.Label23)
        Me.Panel4.Controls.Add(Me.Label22)
        Me.Panel4.Controls.Add(Me.currentTel2)
        Me.Panel4.Controls.Add(Me.currentTel1)
        Me.Panel4.Controls.Add(Me.Label21)
        Me.Panel4.Controls.Add(Me.currentAddress)
        Me.Panel4.Controls.Add(Me.currentPostCode2)
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Controls.Add(Me.currentPostCode1)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Location = New System.Drawing.Point(98, 200)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(734, 21)
        Me.Panel4.TabIndex = 30
        '
        'currentTel3
        '
        Me.currentTel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.currentTel3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.currentTel3.Location = New System.Drawing.Point(671, 1)
        Me.currentTel3.Name = "currentTel3"
        Me.currentTel3.Size = New System.Drawing.Size(62, 19)
        Me.currentTel3.TabIndex = 40
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(656, 5)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 12)
        Me.Label23.TabIndex = 39
        Me.Label23.Text = "-"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(575, 5)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(11, 12)
        Me.Label22.TabIndex = 38
        Me.Label22.Text = "-"
        '
        'currentTel2
        '
        Me.currentTel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.currentTel2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.currentTel2.Location = New System.Drawing.Point(590, 1)
        Me.currentTel2.Name = "currentTel2"
        Me.currentTel2.Size = New System.Drawing.Size(62, 19)
        Me.currentTel2.TabIndex = 37
        '
        'currentTel1
        '
        Me.currentTel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.currentTel1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.currentTel1.Location = New System.Drawing.Point(508, 1)
        Me.currentTel1.Name = "currentTel1"
        Me.currentTel1.Size = New System.Drawing.Size(62, 19)
        Me.currentTel1.TabIndex = 36
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(474, 4)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(29, 12)
        Me.Label21.TabIndex = 32
        Me.Label21.Text = "電話"
        '
        'currentAddress
        '
        Me.currentAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.currentAddress.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.currentAddress.Location = New System.Drawing.Point(156, 1)
        Me.currentAddress.Name = "currentAddress"
        Me.currentAddress.Size = New System.Drawing.Size(313, 19)
        Me.currentAddress.TabIndex = 35
        '
        'currentPostCode2
        '
        Me.currentPostCode2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.currentPostCode2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.currentPostCode2.Location = New System.Drawing.Point(83, 1)
        Me.currentPostCode2.Name = "currentPostCode2"
        Me.currentPostCode2.Size = New System.Drawing.Size(55, 19)
        Me.currentPostCode2.TabIndex = 34
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(70, 5)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(11, 12)
        Me.Label20.TabIndex = 32
        Me.Label20.Text = "-"
        '
        'currentPostCode1
        '
        Me.currentPostCode1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.currentPostCode1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.currentPostCode1.Location = New System.Drawing.Point(21, 1)
        Me.currentPostCode1.Name = "currentPostCode1"
        Me.currentPostCode1.Size = New System.Drawing.Size(46, 19)
        Me.currentPostCode1.TabIndex = 32
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(4, 5)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(17, 12)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "〒"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(35, 234)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 12)
        Me.Label17.TabIndex = 29
        Me.Label17.Text = "6. 家族等"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(35, 204)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 12)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "5. 現在所"
        '
        'ageLabel
        '
        Me.ageLabel.AutoSize = True
        Me.ageLabel.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ageLabel.Location = New System.Drawing.Point(482, 164)
        Me.ageLabel.Name = "ageLabel"
        Me.ageLabel.Size = New System.Drawing.Size(0, 16)
        Me.ageLabel.TabIndex = 27
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(508, 167)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 12)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "歳 (数え年)"
        '
        'btnCalcAge
        '
        Me.btnCalcAge.Font = New System.Drawing.Font("MS UI Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCalcAge.Location = New System.Drawing.Point(406, 162)
        Me.btnCalcAge.Name = "btnCalcAge"
        Me.btnCalcAge.Size = New System.Drawing.Size(53, 20)
        Me.btnCalcAge.TabIndex = 25
        Me.btnCalcAge.Text = "年齢算出"
        Me.btnCalcAge.UseVisualStyleBackColor = True
        '
        'birthYmdBox
        '
        Me.birthYmdBox.boxType = 2
        Me.birthYmdBox.DateText = ""
        Me.birthYmdBox.EraLabelText = "H30"
        Me.birthYmdBox.EraText = ""
        Me.birthYmdBox.Location = New System.Drawing.Point(280, 156)
        Me.birthYmdBox.MonthLabelText = "08"
        Me.birthYmdBox.MonthText = ""
        Me.birthYmdBox.Name = "birthYmdBox"
        Me.birthYmdBox.Size = New System.Drawing.Size(110, 34)
        Me.birthYmdBox.TabIndex = 24
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(204, 168)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 12)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "4. 生年月日"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rbtnWoman)
        Me.Panel3.Controls.Add(Me.rbtnMan)
        Me.Panel3.Location = New System.Drawing.Point(86, 160)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(102, 25)
        Me.Panel3.TabIndex = 11
        '
        'rbtnWoman
        '
        Me.rbtnWoman.AutoSize = True
        Me.rbtnWoman.Location = New System.Drawing.Point(53, 4)
        Me.rbtnWoman.Name = "rbtnWoman"
        Me.rbtnWoman.Size = New System.Drawing.Size(35, 16)
        Me.rbtnWoman.TabIndex = 1
        Me.rbtnWoman.TabStop = True
        Me.rbtnWoman.Text = "女"
        Me.rbtnWoman.UseVisualStyleBackColor = True
        '
        'rbtnMan
        '
        Me.rbtnMan.AutoSize = True
        Me.rbtnMan.Location = New System.Drawing.Point(7, 4)
        Me.rbtnMan.Name = "rbtnMan"
        Me.rbtnMan.Size = New System.Drawing.Size(35, 16)
        Me.rbtnMan.TabIndex = 0
        Me.rbtnMan.TabStop = True
        Me.rbtnMan.Text = "男"
        Me.rbtnMan.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(35, 166)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 12)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "3. 性別"
        '
        'certifiedResultBox
        '
        Me.certifiedResultBox.FormattingEnabled = True
        Me.certifiedResultBox.Location = New System.Drawing.Point(629, 122)
        Me.certifiedResultBox.Name = "certifiedResultBox"
        Me.certifiedResultBox.Size = New System.Drawing.Size(116, 20)
        Me.certifiedResultBox.TabIndex = 21
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(534, 127)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 12)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "2. 前回認定結果"
        '
        'lastCertifiedYmdBox
        '
        Me.lastCertifiedYmdBox.boxType = 2
        Me.lastCertifiedYmdBox.DateText = ""
        Me.lastCertifiedYmdBox.EraLabelText = "H30"
        Me.lastCertifiedYmdBox.EraText = ""
        Me.lastCertifiedYmdBox.Location = New System.Drawing.Point(379, 116)
        Me.lastCertifiedYmdBox.MonthLabelText = "08"
        Me.lastCertifiedYmdBox.MonthText = ""
        Me.lastCertifiedYmdBox.Name = "lastCertifiedYmdBox"
        Me.lastCertifiedYmdBox.Size = New System.Drawing.Size(110, 34)
        Me.lastCertifiedYmdBox.TabIndex = 19
        Me.lastCertifiedYmdBox.Visible = False
        '
        'lastCertifiedCheckBox
        '
        Me.lastCertifiedCheckBox.AutoSize = True
        Me.lastCertifiedCheckBox.Location = New System.Drawing.Point(302, 126)
        Me.lastCertifiedCheckBox.Name = "lastCertifiedCheckBox"
        Me.lastCertifiedCheckBox.Size = New System.Drawing.Size(72, 16)
        Me.lastCertifiedCheckBox.TabIndex = 18
        Me.lastCertifiedCheckBox.Text = "前回認定"
        Me.lastCertifiedCheckBox.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(500, 127)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(9, 12)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = ")"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(290, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(9, 12)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "("
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbtnSecondCount)
        Me.Panel2.Controls.Add(Me.rbtnFirstCount)
        Me.Panel2.Location = New System.Drawing.Point(115, 120)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(169, 25)
        Me.Panel2.TabIndex = 11
        '
        'rbtnSecondCount
        '
        Me.rbtnSecondCount.AutoSize = True
        Me.rbtnSecondCount.Location = New System.Drawing.Point(85, 4)
        Me.rbtnSecondCount.Name = "rbtnSecondCount"
        Me.rbtnSecondCount.Size = New System.Drawing.Size(77, 16)
        Me.rbtnSecondCount.TabIndex = 1
        Me.rbtnSecondCount.TabStop = True
        Me.rbtnSecondCount.Text = "2回目以降"
        Me.rbtnSecondCount.UseVisualStyleBackColor = True
        '
        'rbtnFirstCount
        '
        Me.rbtnFirstCount.AutoSize = True
        Me.rbtnFirstCount.Location = New System.Drawing.Point(12, 4)
        Me.rbtnFirstCount.Name = "rbtnFirstCount"
        Me.rbtnFirstCount.Size = New System.Drawing.Size(47, 16)
        Me.rbtnFirstCount.TabIndex = 0
        Me.rbtnFirstCount.TabStop = True
        Me.rbtnFirstCount.Text = "初回"
        Me.rbtnFirstCount.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(35, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 12)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "1. 過去の認定"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 127)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 12)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Ⅱ"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(510, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(9, 12)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = ")"
        '
        'houseTextBox
        '
        Me.houseTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.houseTextBox.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.houseTextBox.Location = New System.Drawing.Point(280, 87)
        Me.houseTextBox.Name = "houseTextBox"
        Me.houseTextBox.Size = New System.Drawing.Size(226, 19)
        Me.houseTextBox.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(269, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(9, 12)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "("
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbtnHouseOut)
        Me.Panel1.Controls.Add(Me.rbtnHouseIn)
        Me.Panel1.Location = New System.Drawing.Point(115, 85)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(150, 25)
        Me.Panel1.TabIndex = 10
        '
        'rbtnHouseOut
        '
        Me.rbtnHouseOut.AutoSize = True
        Me.rbtnHouseOut.Location = New System.Drawing.Point(85, 4)
        Me.rbtnHouseOut.Name = "rbtnHouseOut"
        Me.rbtnHouseOut.Size = New System.Drawing.Size(59, 16)
        Me.rbtnHouseOut.TabIndex = 1
        Me.rbtnHouseOut.TabStop = True
        Me.rbtnHouseOut.Text = "自宅外"
        Me.rbtnHouseOut.UseVisualStyleBackColor = True
        '
        'rbtnHouseIn
        '
        Me.rbtnHouseIn.AutoSize = True
        Me.rbtnHouseIn.Location = New System.Drawing.Point(12, 4)
        Me.rbtnHouseIn.Name = "rbtnHouseIn"
        Me.rbtnHouseIn.Size = New System.Drawing.Size(59, 16)
        Me.rbtnHouseIn.TabIndex = 0
        Me.rbtnHouseIn.TabStop = True
        Me.rbtnHouseIn.Text = "自宅内"
        Me.rbtnHouseIn.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(35, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "4. 実施場所"
        '
        'companyBox
        '
        Me.companyBox.FormattingEnabled = True
        Me.companyBox.Location = New System.Drawing.Point(567, 49)
        Me.companyBox.Name = "companyBox"
        Me.companyBox.Size = New System.Drawing.Size(265, 20)
        Me.companyBox.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(492, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "3. 所属機関"
        '
        'etcBox
        '
        Me.etcBox.FormattingEnabled = True
        Me.etcBox.Location = New System.Drawing.Point(341, 49)
        Me.etcBox.Name = "etcBox"
        Me.etcBox.Size = New System.Drawing.Size(117, 20)
        Me.etcBox.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(279, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "2. 実施者"
        '
        'dateYmdBox
        '
        Me.dateYmdBox.boxType = 4
        Me.dateYmdBox.DateText = ""
        Me.dateYmdBox.EraLabelText = "H30"
        Me.dateYmdBox.EraText = ""
        Me.dateYmdBox.Location = New System.Drawing.Point(110, 43)
        Me.dateYmdBox.MonthLabelText = "08"
        Me.dateYmdBox.MonthText = ""
        Me.dateYmdBox.Name = "dateYmdBox"
        Me.dateYmdBox.Size = New System.Drawing.Size(145, 34)
        Me.dateYmdBox.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(35, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "1. 実施日"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ⅰ"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(779, 10)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(53, 29)
        Me.btnClear.TabIndex = 100
        Me.btnClear.Text = "クリア"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'specialNotePage
        '
        Me.specialNotePage.BackColor = System.Drawing.SystemColors.Control
        Me.specialNotePage.Location = New System.Drawing.Point(4, 22)
        Me.specialNotePage.Name = "specialNotePage"
        Me.specialNotePage.Padding = New System.Windows.Forms.Padding(3)
        Me.specialNotePage.Size = New System.Drawing.Size(844, 774)
        Me.specialNotePage.TabIndex = 1
        Me.specialNotePage.Text = "特　記　事　項"
        '
        'basicSurveyPage
        '
        Me.basicSurveyPage.BackColor = System.Drawing.SystemColors.Control
        Me.basicSurveyPage.Location = New System.Drawing.Point(4, 22)
        Me.basicSurveyPage.Name = "basicSurveyPage"
        Me.basicSurveyPage.Padding = New System.Windows.Forms.Padding(3)
        Me.basicSurveyPage.Size = New System.Drawing.Size(844, 774)
        Me.basicSurveyPage.TabIndex = 2
        Me.basicSurveyPage.Text = "基　本　調　査"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(13, 263)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(17, 12)
        Me.Label28.TabIndex = 101
        Me.Label28.Text = "Ⅲ"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.Panel6.Controls.Add(Me.namBox)
        Me.Panel6.Controls.Add(Me.Label29)
        Me.Panel6.Location = New System.Drawing.Point(88, 257)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(148, 21)
        Me.Panel6.TabIndex = 41
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(5, 4)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(29, 12)
        Me.Label29.TabIndex = 102
        Me.Label29.Text = "氏名"
        '
        'namBox
        '
        Me.namBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.namBox.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.namBox.Location = New System.Drawing.Point(41, 1)
        Me.namBox.Name = "namBox"
        Me.namBox.Size = New System.Drawing.Size(106, 19)
        Me.namBox.TabIndex = 48
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(254, 261)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(107, 12)
        Me.Label30.TabIndex = 102
        Me.Label30.Text = "調査対象者との関係"
        '
        'relationBox
        '
        Me.relationBox.FormattingEnabled = True
        Me.relationBox.Location = New System.Drawing.Point(367, 256)
        Me.relationBox.Name = "relationBox"
        Me.relationBox.Size = New System.Drawing.Size(75, 20)
        Me.relationBox.TabIndex = 50
        '
        'dgvNumInput
        '
        Me.dgvNumInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNumInput.Location = New System.Drawing.Point(15, 10)
        Me.dgvNumInput.Name = "dgvNumInput"
        Me.dgvNumInput.RowTemplate.Height = 21
        Me.dgvNumInput.Size = New System.Drawing.Size(493, 27)
        Me.dgvNumInput.TabIndex = 0
        '
        '認定調査票
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 824)
        Me.Controls.Add(Me.inputTab)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnRegist)
        Me.Controls.Add(Me.recordList)
        Me.Controls.Add(Me.userLabel)
        Me.Controls.Add(Me.kanaLabel)
        Me.Controls.Add(Me.userList)
        Me.Name = "認定調査票"
        Me.Text = "認定調査票"
        CType(Me.userList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.inputTab.ResumeLayout(False)
        Me.overviewPage.ResumeLayout(False)
        Me.overviewPage.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.dgvNumInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents userList As System.Windows.Forms.DataGridView
    Friend WithEvents kanaLabel As System.Windows.Forms.Label
    Friend WithEvents userLabel As System.Windows.Forms.Label
    Friend WithEvents recordList As System.Windows.Forms.ListBox
    Friend WithEvents btnRegist As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents inputTab As System.Windows.Forms.TabControl
    Friend WithEvents overviewPage As System.Windows.Forms.TabPage
    Friend WithEvents specialNotePage As System.Windows.Forms.TabPage
    Friend WithEvents basicSurveyPage As System.Windows.Forms.TabPage
    Friend WithEvents dgvNumInput As Symphony_KSave2.ExDataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents dateYmdBox As ymdBox.ymdBox
    Friend WithEvents etcBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents companyBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbtnHouseOut As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnHouseIn As System.Windows.Forms.RadioButton
    Friend WithEvents houseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lastCertifiedCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rbtnSecondCount As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnFirstCount As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lastCertifiedYmdBox As ymdBox.ymdBox
    Friend WithEvents certifiedResultBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rbtnWoman As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnMan As System.Windows.Forms.RadioButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ageLabel As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnCalcAge As System.Windows.Forms.Button
    Friend WithEvents birthYmdBox As ymdBox.ymdBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents currentPostCode1 As System.Windows.Forms.TextBox
    Friend WithEvents currentPostCode2 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents currentAddress As System.Windows.Forms.TextBox
    Friend WithEvents currentTel3 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents currentTel2 As System.Windows.Forms.TextBox
    Friend WithEvents currentTel1 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents familyTel3 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents familyTel2 As System.Windows.Forms.TextBox
    Friend WithEvents familyTel1 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents familyAddress As System.Windows.Forms.TextBox
    Friend WithEvents familyPostCode2 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents familyPostCode1 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents relationBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents namBox As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
End Class
