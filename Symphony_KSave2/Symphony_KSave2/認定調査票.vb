Imports System.Data.OleDb
Imports System.Text
Imports ymdBox.ymdBox

Public Class 認定調査票

    Private Const INPUT_NUMBER As Integer = 1

    Public Sub New()
        InitializeComponent()
        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True
    End Sub

    Private Sub 認定調査票_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.Control = False Then
                Me.SelectNextControl(Me.ActiveControl, Not e.Shift, True, True, True)
            End If
        End If
    End Sub

    Private Sub 認定調査票_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '利用者リスト表示
        displayUserList()

        'dgv初期設定
        initDgvNumInput()
        initDgvSp(SpDgv1)
        initDgvSp(SpDgv2)
        initDgvSp(SpDgv3)
        initDgvSp(SpDgv4)
        initDgvSp(SpDgv5)
        initDgvSp(SpDgv6)
        initDgvSp(SpDgv7)

        '初期フォーカス
        dgvNumInput.Focus()
        SendKeys.Send("{ESC}")
        SendKeys.Send("{F2}")

        '入力ボックス設定
        settingInputBox()
        clearOverviewPageInputBox()

    End Sub

    Private Sub settingUserList()
        'DoubleBufferedプロパティをTrue
        Util.EnableDoubleBuffering(userList)

        'dgv設定
        With userList
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect 'クリック時に行選択
            .MultiSelect = False
            .ReadOnly = True
            .ColumnHeadersVisible = False
            .RowHeadersVisible = False
            .RowTemplate.Height = 14
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .ShowCellToolTips = False
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
        End With
    End Sub

    Private Sub displayUserList()
        settingUserList()

        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select Nam, Kana from UsrM order by Kana"
        cnn.Open(topForm.DB_KSave2)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "UsrM")
        userList.DataSource = ds.Tables(0)
        cnn.Close()

        userList.Columns("Kana").Visible = False
        userList.Columns("Nam").Width = 89
        userList.CurrentCell.Selected = False
    End Sub

    Private Sub displayRecordList(userNam As String)
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select distinct Ymd1 from Auth1 where Nam='" & userNam & "' order by Ymd1 Desc"
        cnn.Open(topForm.DB_KSave2)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        recordList.Items.Clear()
        While Not rs.EOF
            recordList.Items.Add(convADStrToWarekiStr(rs.Fields("Ymd1").Value))
            rs.MoveNext()
        End While
        rs.Close()
        cnn.Close()
    End Sub

    Private Sub userList_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles userList.CellMouseClick
        clearAllInputData()
        Dim userNam As String = userList("Nam", e.RowIndex).Value
        Dim userKana As String = userList("Kana", e.RowIndex).Value
        kanaLabel.Text = userKana
        userLabel.Text = userNam
        displayRecordList(userNam)
    End Sub

    Private Sub initDgvNumInput()
        Util.EnableDoubleBuffering(dgvNumInput)

        With dgvNumInput
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .MultiSelect = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersVisible = False
            .RowHeadersVisible = False
            .RowTemplate.Height = 29
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .DefaultCellStyle.Font = New Font("MS UI Gothic", 14, FontStyle.Bold)
            .DefaultCellStyle.BackColor = Color.FromArgb(145, 172, 244)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(145, 172, 244)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .BorderStyle = BorderStyle.None
            .GridColor = Color.FromArgb(236, 233, 216)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        '空セル作成
        Dim dt As New DataTable()
        For i As Integer = 1 To 6
            dt.Columns.Add("GDay" & i, Type.GetType("System.String"))
        Next
        dt.Columns.Add("GSpace1", Type.GetType("System.String"))
        For i As Integer = 1 To 4
            dt.Columns.Add("GAuto" & i, Type.GetType("System.String"))
        Next
        dt.Columns.Add("GSpace2", Type.GetType("System.String"))
        For i As Integer = 1 To 10
            dt.Columns.Add("GNum" & i, Type.GetType("System.String"))
        Next
        Dim row As DataRow = dt.NewRow()
        row("GAuto1") = "0"
        row("GAuto2") = "1"
        row("GAuto3") = "1"
        row("GAuto4") = "3"
        dt.Rows.Add(row)
        dgvNumInput.DataSource = dt

        With dgvNumInput
            For i = 1 To 6
                With .Columns("GDay" & i)
                    .Width = 23
                End With
            Next
            For i = 1 To 4
                With .Columns("GAuto" & i)
                    .Width = 23
                    .ReadOnly = True
                    .DefaultCellStyle.SelectionBackColor = Color.FromArgb(145, 172, 244)
                    .DefaultCellStyle.SelectionForeColor = Color.Black
                End With
            Next
            For i = 1 To 10
                With .Columns("GNum" & i)
                    .Width = 23
                End With
            Next
            For i = 1 To 2
                With .Columns("GSpace" & i)
                    .Width = 12
                    .ReadOnly = True
                    .DefaultCellStyle.BackColor = Color.FromArgb(236, 233, 216)
                    .DefaultCellStyle.SelectionBackColor = Color.FromArgb(236, 233, 216)
                End With
            Next
        End With
    End Sub

    Private Sub initDgvSp(dgv As SpDgv)
        Util.EnableDoubleBuffering(dgv)

        With dgv
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .MultiSelect = False
            .RowHeadersVisible = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersHeight = 19
            .RowTemplate.Height = 17
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
        End With

        '列追加、空の行追加
        dgv.dt.Columns.Add("Crr", Type.GetType("System.String"))
        dgv.dt.Columns.Add("Txt", Type.GetType("System.String"))
        Dim row As DataRow
        For i = 0 To 59
            row = dgv.dt.NewRow()
            row(0) = ""
            row(1) = ""
            dgv.dt.Rows.Add(row)
        Next

        dgv.DataSource = dgv.dt

        With dgv
            With .Columns("Crr")
                .HeaderText = "項目"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 47
            End With
            With .Columns("Txt")
                .HeaderText = "内容"
                .Width = 530
            End With
        End With

    End Sub

    Private Sub settingInputBox()
        '実施者ボックス
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select Nam from EtcM order by Num"
        cnn.Open(topForm.DB_KSave2)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        etcBox.Items.Clear()
        While Not rs.EOF
            etcBox.Items.Add(rs.Fields("Nam").Value)
            rs.MoveNext()
        End While
        rs.Close()
        cnn.Close()

        '所属機関ボックス
        companyBox.Items.AddRange({"特別養護老人ホーム シンフォニー", "居宅介護支援事業所 シンフォニー"})
        companyBox.ImeMode = Windows.Forms.ImeMode.Hiragana

        '実施場所自宅外ボックス
        houseTextBox.LimitLengthByte = 34 '全角17文字
        houseTextBox.ImeMode = Windows.Forms.ImeMode.Hiragana

        '前回認定結果ボックス
        certifiedResultBox.Items.AddRange({"非該当", "要支援1", "要支援2", "要介護1", "要介護2", "要介護3", "要介護4", "要介護5"})
        certifiedResultBox.ImeMode = Windows.Forms.ImeMode.Hiragana

        '現在所
        With currentPostCode1
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 3
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With
        With currentPostCode2
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 4
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With
        With currentAddress
            .LimitLengthByte = 60
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With
        With currentTel1
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 4
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With
        With currentTel2
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 4
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With
        With currentTel3
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 4
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With

        '家族等
        With familyPostCode1
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 3
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With
        With familyPostCode2
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 4
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With
        With familyAddress
            .LimitLengthByte = 60
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With
        With familyTel1
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 4
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With
        With familyTel2
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 4
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With
        With familyTel3
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 4
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With

        '氏名ボックス
        With namBox
            .LimitLengthByte = 16
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With

        '調査対象者との関係ボックス
        relationBox.Items.AddRange({"夫", "妻", "息子", "娘", "長男", "二男", "三男", "四男", "長女", "二女", "三女", "四女", "五女", "子の嫁", "子の夫", "兄", "弟", "姉", "妹", "父", "母", "孫", "伯父", "叔父", "伯母", "叔母", "知人", "その他", "姪", "甥"})
        relationBox.MaxDropDownItems = 8
        relationBox.IntegralHeight = False
        relationBox.ImeMode = Windows.Forms.ImeMode.Hiragana

        'txtNum1～txtNum21ボックス
        For i = 1 To 21
            If i = 13 Then
                Continue For
            End If
            With CType(overview3Panel.Controls("txtNum" & i), ExTextBox)
                .InputType = INPUT_NUMBER
                .LimitLengthByte = 4
                .ImeMode = Windows.Forms.ImeMode.Disable
                .TextAlign = HorizontalAlignment.Center
            End With
        Next

        '市町村特別給付
        With Gentxt1
            .LimitLengthByte = 90
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With

        '介護保険給付外の在宅サービス
        With Gentxt2
            .LimitLengthByte = 76
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With

        '施設連絡先
        With facilityNameBox
            .LimitLengthByte = 40
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With
        With facilityPostCode1
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 3
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With
        With facilityPostCode2
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 4
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With
        With facilityAddress
            .LimitLengthByte = 60
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With
        With facilityTel1
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 4
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With
        With facilityTel2
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 4
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With
        With facilityTel3
            .InputType = INPUT_NUMBER
            .LimitLengthByte = 4
            .ImeMode = Windows.Forms.ImeMode.Disable
            .TextAlign = HorizontalAlignment.Center
        End With

        '特記テキスト
        With spText1
            .Font = New Font("MS UI Gothic", 9.4)
            .LimitLengthByte = 128
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With
        With spText2
            .Font = New Font("MS UI Gothic", 9.4)
            .LimitLengthByte = 128
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With
        With spText3
            .Font = New Font("MS UI Gothic", 9.4)
            .LimitLengthByte = 128
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With
        With spText4
            .Font = New Font("MS UI Gothic", 9.4)
            .LimitLengthByte = 128
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With

    End Sub

    Private Sub clearOverviewPageInputBox()
        Dim todayStr As String = Today.ToString("yyyy/MM/dd")
        '番号
        For Each cell As DataGridViewCell In dgvNumInput.Rows(0).Cells
            If cell.ReadOnly = False Then
                cell.Value = ""
            End If
        Next
        '実施日
        dateYmdBox.setADStr(todayStr)
        '実施者
        etcBox.Text = ""
        '所属機関
        companyBox.Text = ""
        '実施場所
        rbtnHouseIn.Checked = False
        rbtnHouseOut.Checked = False
        houseTextBox.Text = ""
        '過去の認定
        rbtnFirstCount.Checked = False
        rbtnSecondCount.Checked = False
        lastCertifiedCheckBox.Checked = False
        lastCertifiedYmdBox.setADStr(todayStr)
        '前回認定結果
        certifiedResultBox.Text = ""
        '性別
        rbtnMan.Checked = False
        rbtnWoman.Checked = False
        '生年月日
        birthYmdBox.setADStr(todayStr)
        ageLabel.Text = ""
        '現在所
        currentPostCode1.Text = ""
        currentPostCode2.Text = ""
        currentAddress.Text = ""
        currentTel1.Text = ""
        currentTel2.Text = ""
        currentTel3.Text = ""
        '家族等
        familyPostCode1.Text = ""
        familyPostCode2.Text = ""
        familyAddress.Text = ""
        familyTel1.Text = ""
        familyTel2.Text = ""
        familyTel3.Text = ""
        '氏名
        namBox.Text = ""
        '調査対象者との関係
        relationBox.Text = ""
        '（介護予防）訪問介護（ホームヘルプサービス）
        checkGen1.Checked = False
        txtNum1.Text = ""
        '（介護予防）訪問入浴介護
        checkGen2.Checked = False
        txtNum2.Text = ""
        '（介護予防）訪問看護
        checkGen3.Checked = False
        txtNum3.Text = ""
        '（介護予防）訪問リハビリテーション
        checkGen4.Checked = False
        txtNum4.Text = ""
        '（介護予防）居宅療養管理指導
        checkGen5.Checked = False
        txtNum5.Text = ""
        '（介護予防）通所介護（デイサービス）
        checkGen6.Checked = False
        txtNum6.Text = ""
        '（介護予防）通所リハビリテーション（デイケア）
        checkGen7.Checked = False
        txtNum7.Text = ""
        '（介護予防）短期入所生活介護（特養等）
        checkGen8.Checked = False
        txtNum8.Text = ""
        '（介護予防）短期入所療養介護（老健・診療所）
        checkGen9.Checked = False
        txtNum9.Text = ""
        '（介護予防）特定施設入居者生活介護
        checkGen10.Checked = False
        txtNum10.Text = ""
        '（介護予防）福祉用具貸与
        checkGen11.Checked = False
        txtNum11.Text = ""
        '特定（介護予防）福祉用具販売
        checkGen12.Checked = False
        txtNum12.Text = ""
        '住宅改修
        checkGen13.Checked = False
        CheckNum13Exists.Checked = False
        CheckNum13None.Checked = False
        '夜間対応型訪問介護
        checkGen14.Checked = False
        txtNum14.Text = ""
        '（介護予防）認知症対応型通所介護
        checkGen15.Checked = False
        txtNum15.Text = ""
        '（介護予防）小規模多機能型居宅介護
        checkGen16.Checked = False
        txtNum16.Text = ""
        '（介護予防）認知症対応型共同生活介護
        checkGen17.Checked = False
        txtNum17.Text = ""
        '地域密着型特定施設入居者生活介護
        checkGen18.Checked = False
        txtNum18.Text = ""
        '地域密着型介護老人福祉施設入所者生活介護
        checkGen19.Checked = False
        txtNum19.Text = ""
        '定期巡回・随時対応型訪問介護看護
        checkGen20.Checked = False
        txtNum20.Text = ""
        '複合型サービス
        checkGen23.Checked = False
        txtNum21.Text = ""
        '市町村特別給付
        checkGen21.Checked = False
        Gentxt1.Text = ""
        '介護保険給付外の在宅サービス
        checkGen22.Checked = False
        Gentxt2.Text = ""
        '利用施設
        '介護老人福祉施設
        checkStay1.Checked = False
        '介護老人保健施設
        checkStay2.Checked = False
        '介護療養型医療施設
        checkStay3.Checked = False
        '認知症対応型共同生活介護適用施設（ｸﾞﾙｰﾌﾟﾎｰﾑ）
        checkStay4.Checked = False
        '特定施設入所者生活介護適用施設（ｹｱﾊｳｽ等）
        checkStay5.Checked = False
        '医療機関（医療保険適用療養病床）
        checkStay6.Checked = False
        '医療機関（療養病床以外）
        checkStay7.Checked = False
        'その他の施設
        checkStay8.Checked = False
        '施設連絡先
        facilityNameBox.Text = ""
        facilityPostCode1.Text = ""
        facilityPostCode2.Text = ""
        facilityAddress.Text = ""
        facilityTel1.Text = ""
        facilityTel2.Text = ""
        facilityTel3.Text = ""
        '特記テキスト
        spText1.Text = ""
        spText2.Text = ""
        spText3.Text = ""
        spText4.Text = ""

    End Sub

    Private Sub clearAllInputData()
        '概況調査タブの内容クリア
        clearOverviewPageInputBox()

        '特記事項タブの内容クリア
        SpDgv1.clearText()
        SpDgv2.clearText()
        SpDgv3.clearText()
        SpDgv4.clearText()
        SpDgv5.clearText()
        SpDgv6.clearText()
        SpDgv7.clearText()

        '基本調査タブの内容クリア
        For Each tp As TabPage In bsTab.TabPages
            For Each c As Control In tp.Controls
                If TypeOf c Is GroupBox Then
                    For Each ex As Control In c.Controls
                        If TypeOf ex Is ExCheckBox Then
                            DirectCast(ex, ExCheckBox).Checked = False
                        ElseIf TypeOf ex Is ExRadioButton Then
                            DirectCast(ex, ExRadioButton).Checked = False
                        End If
                    Next
                End If
            Next
        Next

    End Sub

    Private Sub displayUserData(nam As String, kana As String, ymd1 As String)
        clearAllInputData()
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select * from Auth1 where Nam='" & nam & "' and Ymd1='" & ymd1 & "'"
        cnn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cnn.Open(topForm.DB_KSave2)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)

        '概況調査タブの表示処理
        rs.Filter = "Gyo=61"
        '調査日
        For i = 1 To 6
            dgvNumInput("GDay" & i, 0).Value = Util.checkDBNullValue(rs.Fields("GDay" & i).Value)
        Next
        '被保険者番号
        For i = 1 To 10
            dgvNumInput("GNum" & i, 0).Value = Util.checkDBNullValue(rs.Fields("GNum" & i).Value)
        Next
        dateYmdBox.setADStr(Util.checkDBNullValue(rs.Fields("Ymd1").Value)) '実施日
        etcBox.Text = Util.checkDBNullValue(rs.Fields("Tanto").Value) '実施者
        companyBox.Text = Util.checkDBNullValue(rs.Fields("Kikan").Value) '所属機関
        '実施場所
        If Util.checkDBNullValue(rs.Fields("Home").Value) = "0" Then
            rbtnHouseIn.Checked = True '自宅内
        ElseIf Util.checkDBNullValue(rs.Fields("Home").Value) = "1" Then
            rbtnHouseOut.Checked = True '自宅外
            houseTextBox.Text = Util.checkDBNullValue(rs.Fields("Nonhm").Value) '自宅外の詳細
        End If
        '過去の認定
        If Util.checkDBNullValue(rs.Fields("Kako").Value) = "0" Then
            rbtnFirstCount.Checked = True '初回
        ElseIf Util.checkDBNullValue(rs.Fields("Kako").Value) = "1" Then
            rbtnSecondCount.Checked = True '2回目以降
        End If
        '前回認定
        If Util.checkDBNullValue(rs.Fields("Ymd2").Value) <> "" Then
            lastCertifiedCheckBox.Checked = True
            lastCertifiedYmdBox.setADStr(Util.checkDBNullValue(rs.Fields("Ymd2").Value))
        End If
        certifiedResultBox.Text = If(Util.checkDBNullValue(rs.Fields("Kai").Value) = "", "", certifiedResultBox.Items.Item(rs.Fields("Kai").Value)) '前回認定結果
        If Util.checkDBNullValue(rs.Fields("Sex").Value) = "0" Then
            rbtnMan.Checked = True '男
        ElseIf Util.checkDBNullValue(rs.Fields("Sex").Value) = "1" Then
            rbtnWoman.Checked = True '女
        End If
        birthYmdBox.setADStr(Util.checkDBNullValue(rs.Fields("Ymd3").Value)) '生年月日
        '現在所
        currentPostCode1.Text = Util.checkDBNullValue(rs.Fields("Pn11").Value)
        currentPostCode2.Text = Util.checkDBNullValue(rs.Fields("Pn12").Value)
        currentAddress.Text = Util.checkDBNullValue(rs.Fields("Ad1").Value)
        currentTel1.Text = Util.checkDBNullValue(rs.Fields("Tel11").Value)
        currentTel2.Text = Util.checkDBNullValue(rs.Fields("Tel12").Value)
        currentTel3.Text = Util.checkDBNullValue(rs.Fields("Tel13").Value)
        '家族等
        familyPostCode1.Text = Util.checkDBNullValue(rs.Fields("Pn21").Value)
        familyPostCode2.Text = Util.checkDBNullValue(rs.Fields("Pn22").Value)
        familyAddress.Text = Util.checkDBNullValue(rs.Fields("Ad2").Value)
        familyTel1.Text = Util.checkDBNullValue(rs.Fields("Tel21").Value)
        familyTel2.Text = Util.checkDBNullValue(rs.Fields("Tel22").Value)
        familyTel3.Text = Util.checkDBNullValue(rs.Fields("Tel23").Value)
        'Ⅲ
        namBox.Text = Util.checkDBNullValue(rs.Fields("Fa").Value) '氏名
        relationBox.Text = Util.checkDBNullValue(rs.Fields("Far").Value) '調査対象者との関係
        For i = 1 To 20
            'Gen1～20,Num1～20部分
            If Util.checkDBNullValue(rs.Fields("Gen" & i).Value) = "1" Then
                CType(overview3Panel.Controls("checkGen" & i), CheckBox).Checked = True
            End If
            If i <> 13 Then
                CType(overview3Panel.Controls("txtNum" & i), ExTextBox).Text = Util.checkDBNullValue(rs.Fields("Num" & i).Value)
            Else
                If Util.checkDBNullValue(rs.Fields("Num" & i).Value) = "1" Then
                    CheckNum13Exists.Checked = True
                ElseIf Util.checkDBNullValue(rs.Fields("Num" & i).Value) = "2" Then
                    CheckNum13None.Checked = True
                End If
            End If
        Next
        '複合型サービス
        If Util.checkDBNullValue(rs.Fields("Gen23").Value) = "1" Then
            checkGen23.Checked = True
        End If
        txtNum21.Text = Util.checkDBNullValue(rs.Fields("Num21").Value)
        '市町村特別給付
        If Util.checkDBNullValue(rs.Fields("Gen21").Value) = "1" Then
            checkGen21.Checked = True
        End If
        Gentxt1.Text = Util.checkDBNullValue(rs.Fields("Gentxt1").Value)
        '介護保険給付外の在宅サービス
        If Util.checkDBNullValue(rs.Fields("Gen22").Value) = "1" Then
            checkGen22.Checked = True
        End If
        Gentxt2.Text = Util.checkDBNullValue(rs.Fields("Gentxt2").Value)
        '利用施設
        For i = 1 To 8
            If Util.checkDBNullValue(rs.Fields("Stay" & i).Value) = "1" Then
                CType(facilityPanel.Controls("checkStay" & i), CheckBox).Checked = True
            End If
        Next
        '施設連絡先
        facilityNameBox.Text = Util.checkDBNullValue(rs.Fields("Name").Value) '連絡先
        facilityPostCode1.Text = Util.checkDBNullValue(rs.Fields("Pn31").Value)
        facilityPostCode2.Text = Util.checkDBNullValue(rs.Fields("Pn32").Value)
        facilityAddress.Text = Util.checkDBNullValue(rs.Fields("Ad3").Value)
        facilityTel1.Text = Util.checkDBNullValue(rs.Fields("Tel31").Value)
        facilityTel2.Text = Util.checkDBNullValue(rs.Fields("Tel32").Value)
        facilityTel3.Text = Util.checkDBNullValue(rs.Fields("Tel33").Value)
        'Ⅳ
        spText1.Text = Util.checkDBNullValue(rs.Fields("GTokki1").Value)
        spText2.Text = Util.checkDBNullValue(rs.Fields("GTokki2").Value)
        spText3.Text = Util.checkDBNullValue(rs.Fields("GTokki3").Value)
        spText4.Text = Util.checkDBNullValue(rs.Fields("GTokki4").Value)

        '特記事項タブの表示処理
        '1.身体機能・起居動作
        rs.Filter = "Sp=0 and Gyo>=4 and Gyo<>61"
        rs.Sort = "Gyo ASC"
        If rs.RecordCount >= 1 Then
            rs.MoveFirst()
            Dim i As Integer = 0
            While Not rs.EOF
                SpDgv1("Crr", i).Value = Util.checkDBNullValue(rs.Fields("Crr").Value)
                SpDgv1("Txt", i).Value = Util.checkDBNullValue(rs.Fields("Txt").Value)
                i += 1
                rs.MoveNext()
            End While
        End If
        '2.生活機能
        rs.Filter = "Sp=1 and Gyo>=5"
        rs.Sort = "Gyo ASC"
        If rs.RecordCount >= 1 Then
            rs.MoveFirst()
            Dim i As Integer = 0
            While Not rs.EOF
                SpDgv2("Crr", i).Value = Util.checkDBNullValue(rs.Fields("Crr").Value)
                SpDgv2("Txt", i).Value = Util.checkDBNullValue(rs.Fields("Txt").Value)
                i += 1
                rs.MoveNext()
            End While
        End If
        '3.認知機能
        rs.Filter = "Sp=2 and Gyo>=5"
        rs.Sort = "Gyo ASC"
        If rs.RecordCount >= 1 Then
            rs.MoveFirst()
            Dim i As Integer = 0
            While Not rs.EOF
                SpDgv3("Crr", i).Value = Util.checkDBNullValue(rs.Fields("Crr").Value)
                SpDgv3("Txt", i).Value = Util.checkDBNullValue(rs.Fields("Txt").Value)
                i += 1
                rs.MoveNext()
            End While
        End If
        '4.精神・行動障害
        rs.Filter = "Sp=3 and Gyo>=6"
        rs.Sort = "Gyo ASC"
        If rs.RecordCount >= 1 Then
            rs.MoveFirst()
            Dim i As Integer = 0
            While Not rs.EOF
                SpDgv4("Crr", i).Value = Util.checkDBNullValue(rs.Fields("Crr").Value)
                SpDgv4("Txt", i).Value = Util.checkDBNullValue(rs.Fields("Txt").Value)
                i += 1
                rs.MoveNext()
            End While
        End If
        '5.社会生活への適応
        rs.Filter = "Sp=4 and Gyo>=5"
        rs.Sort = "Gyo ASC"
        If rs.RecordCount >= 1 Then
            rs.MoveFirst()
            Dim i As Integer = 0
            While Not rs.EOF
                SpDgv5("Crr", i).Value = Util.checkDBNullValue(rs.Fields("Crr").Value)
                SpDgv5("Txt", i).Value = Util.checkDBNullValue(rs.Fields("Txt").Value)
                i += 1
                rs.MoveNext()
            End While
        End If
        '6.特別な医療
        rs.Filter = "Sp=5 and Gyo>=4"
        rs.Sort = "Gyo ASC"
        If rs.RecordCount >= 1 Then
            rs.MoveFirst()
            Dim i As Integer = 0
            While Not rs.EOF
                SpDgv6("Crr", i).Value = Util.checkDBNullValue(rs.Fields("Crr").Value)
                SpDgv6("Txt", i).Value = Util.checkDBNullValue(rs.Fields("Txt").Value)
                i += 1
                rs.MoveNext()
            End While
        End If
        '7.日常生活自立度
        rs.Filter = "Sp=6 and Gyo>=4"
        rs.Sort = "Gyo ASC"
        If rs.RecordCount >= 1 Then
            rs.MoveFirst()
            Dim i As Integer = 0
            While Not rs.EOF
                SpDgv7("Crr", i).Value = Util.checkDBNullValue(rs.Fields("Crr").Value)
                SpDgv7("Txt", i).Value = Util.checkDBNullValue(rs.Fields("Txt").Value)
                i += 1
                rs.MoveNext()
            End While
        End If
        rs.Close()

        '基本調査タブの表示処理
        sql = "select * from Auth2 where Nam='" & nam & "' and Ymd='" & ymd1 & "' order by Gyo"
        rs = New ADODB.Recordset
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)

        '1.身体機能・起居動作
        '1-1 麻痺等の有無
        rs.Find("Gyo=0")
        Ch2_1.Checked = If(Util.checkDBNullValue(rs.Fields("Ch2").Value) = 1, True, False)
        rs.Find("Gyo=1")
        Ch2_2.Checked = If(Util.checkDBNullValue(rs.Fields("Ch2").Value) = 1, True, False)
        rs.Find("Gyo=2")
        Ch2_3.Checked = If(Util.checkDBNullValue(rs.Fields("Ch2").Value) = 1, True, False)
        rs.Find("Gyo=3")
        Ch2_4.Checked = If(Util.checkDBNullValue(rs.Fields("Ch2").Value) = 1, True, False)
        rs.Find("Gyo=4")
        Ch2_5.Checked = If(Util.checkDBNullValue(rs.Fields("Ch2").Value) = 1, True, False)
        rs.Find("Gyo=5")
        Ch2_6.Checked = If(Util.checkDBNullValue(rs.Fields("Ch2").Value) = 1, True, False)
        '1-2 拘縮の有無
        rs.Find("Gyo=0", , ADODB.SearchDirectionEnum.adSearchBackward)
        Ch3_1.Checked = If(Util.checkDBNullValue(rs.Fields("Ch3").Value) = 1, True, False)
        rs.Find("Gyo=1")
        Ch3_2.Checked = If(Util.checkDBNullValue(rs.Fields("Ch3").Value) = 1, True, False)
        rs.Find("Gyo=2")
        Ch3_3.Checked = If(Util.checkDBNullValue(rs.Fields("Ch3").Value) = 1, True, False)
        rs.Find("Gyo=3")
        Ch3_4.Checked = If(Util.checkDBNullValue(rs.Fields("Ch3").Value) = 1, True, False)
        rs.Find("Gyo=4")
        Ch3_5.Checked = If(Util.checkDBNullValue(rs.Fields("Ch3").Value) = 1, True, False)
        '1-3 寝返り
        rs.Find("Gyo=0", , ADODB.SearchDirectionEnum.adSearchBackward)
        rb1_3_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=1")
        rb1_3_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=2")
        rb1_3_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '1-4 起き上がり
        rs.Find("Gyo=3")
        rb1_4_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=4")
        rb1_4_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=5")
        rb1_4_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '1-5 座位保持
        rs.Find("Gyo=6")
        rb1_5_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=7")
        rb1_5_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=8")
        rb1_5_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=9")
        rb1_5_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '1-6 両足での立位保持
        rs.Find("Gyo=10")
        rb1_6_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=11")
        rb1_6_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=12")
        rb1_6_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '1-7 歩行
        rs.Find("Gyo=13")
        rb1_7_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=14")
        rb1_7_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=15")
        rb1_7_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '1-8 立ち上がり
        rs.Find("Gyo=16")
        rb1_8_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=17")
        rb1_8_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=18")
        rb1_8_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '1-9 片足での立位保持
        rs.Find("Gyo=19")
        rb1_9_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=20")
        rb1_9_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=21")
        rb1_9_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '1-10 洗身
        rs.Find("Gyo=22")
        rb1_10_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=23")
        rb1_10_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=24")
        rb1_10_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=25")
        rb1_10_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '1-11 つめ切り
        rs.Find("Gyo=26")
        rb1_11_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=27")
        rb1_11_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=28")
        rb1_11_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '1-12 視力について
        rs.Find("Gyo=29")
        rb1_12_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=30")
        rb1_12_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=31")
        rb1_12_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=32")
        rb1_12_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=33")
        rb1_12_5.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '1-13 聴力について
        rs.Find("Gyo=34")
        rb1_13_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=35")
        rb1_13_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=36")
        rb1_13_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=37")
        rb1_13_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=38")
        rb1_13_5.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)

        '2.生活機能
        '2-1 移乗
        rs.Find("Gyo=39")
        rb2_1_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=40")
        rb2_1_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=41")
        rb2_1_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=42")
        rb2_1_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '2-2 移動
        rs.Find("Gyo=43")
        rb2_2_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=44")
        rb2_2_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=45")
        rb2_2_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=46")
        rb2_2_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '2-3 えん下
        rs.Find("Gyo=47")
        rb2_3_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=48")
        rb2_3_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=49")
        rb2_3_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '2-4 食事摂取
        rs.Find("Gyo=50")
        rb2_4_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=51")
        rb2_4_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=52")
        rb2_4_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=53")
        rb2_4_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '2-5 排尿
        rs.Find("Gyo=54")
        rb2_5_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=55")
        rb2_5_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=56")
        rb2_5_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=57")
        rb2_5_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '2-6 排便
        rs.Find("Gyo=58")
        rb2_6_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=59")
        rb2_6_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=60")
        rb2_6_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=61")
        rb2_6_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '2-7 口腔清潔
        rs.Find("Gyo=62")
        rb2_7_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=63")
        rb2_7_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=64")
        rb2_7_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '2-8 洗顔
        rs.Find("Gyo=65")
        rb2_8_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=66")
        rb2_8_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=67")
        rb2_8_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '2-9 整髪
        rs.Find("Gyo=68")
        rb2_9_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=69")
        rb2_9_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=70")
        rb2_9_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '2-10 上衣の着脱
        rs.Find("Gyo=71")
        rb2_10_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=72")
        rb2_10_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=73")
        rb2_10_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=74")
        rb2_10_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '2-11 ズボン等の着脱
        rs.Find("Gyo=75")
        rb2_11_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=76")
        rb2_11_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=77")
        rb2_11_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=78")
        rb2_11_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '2-12 外出頻度
        rs.Find("Gyo=79")
        rb2_12_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=80")
        rb2_12_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=81")
        rb2_12_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)

        '3.認知機能
        '3-1 意思の伝達
        rs.Find("Gyo=82")
        rb3_1_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=83")
        rb3_1_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=84")
        rb3_1_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=85")
        rb3_1_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '3-2 毎日の日課を理解
        rs.Find("Gyo=86")
        rb3_2_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=87")
        rb3_2_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '3-3 生年月日や年齢を言う
        rs.Find("Gyo=88")
        rb3_3_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=89")
        rb3_3_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '3-4 短期記憶（面接調査の直前に何をしていたのか思い出す）
        rs.Find("Gyo=90")
        rb3_4_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=91")
        rb3_4_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '3-5 自分の名前を言う
        rs.Find("Gyo=92")
        rb3_5_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=93")
        rb3_5_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '3-6 今の季節を理解
        rs.Find("Gyo=94")
        rb3_6_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=95")
        rb3_6_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '3-7 場所の理解（自分がいる場所を答える）
        rs.Find("Gyo=96")
        rb3_7_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=97")
        rb3_7_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '3-8 徘徊
        rs.Find("Gyo=98")
        rb3_8_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=99")
        rb3_8_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=100")
        rb3_8_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '3-9 外出すると戻れない
        rs.Find("Gyo=101")
        rb3_9_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=102")
        rb3_9_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=103")
        rb3_9_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)

        '4.精神・行動障害
        '4-1 物を盗られたなどと被害的になる
        rs.Find("Gyo=104")
        rb4_1_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=105")
        rb4_1_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=106")
        rb4_1_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '4-2 作話をすること
        rs.Find("Gyo=107")
        rb4_2_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=108")
        rb4_2_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=109")
        rb4_2_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '4-3 泣いたり、笑ったりして感情が不安定になる
        rs.Find("Gyo=110")
        rb4_3_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=111")
        rb4_3_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=112")
        rb4_3_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '4-4 昼夜の逆転
        rs.Find("Gyo=113")
        rb4_4_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=114")
        rb4_4_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=115")
        rb4_4_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '4-5 しつこく同じ話をする
        rs.Find("Gyo=116")
        rb4_5_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=117")
        rb4_5_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=118")
        rb4_5_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '4-6 大声を出す
        rs.Find("Gyo=119")
        rb4_6_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=120")
        rb4_6_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=121")
        rb4_6_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '4-7 介護に抵抗する
        rs.Find("Gyo=122")
        rb4_7_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=123")
        rb4_7_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=124")
        rb4_7_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '4-8 「家に帰る」等と言い落ち着きがない
        rs.Find("Gyo=125")
        rb4_8_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=126")
        rb4_8_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=127")
        rb4_8_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '4-9 一人で外に出たがり目が離せない
        rs.Find("Gyo=128")
        rb4_9_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=129")
        rb4_9_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=130")
        rb4_9_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '4-10 いろいろなものを集めたり、無断でもってくる
        rs.Find("Gyo=131")
        rb4_10_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=132")
        rb4_10_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=133")
        rb4_10_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '4-11 物を壊したり、衣類を破いたりする
        rs.Find("Gyo=134")
        rb4_11_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=135")
        rb4_11_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=136")
        rb4_11_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '4-12 ひどい物忘れ
        rs.Find("Gyo=137")
        rb4_12_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=138")
        rb4_12_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=139")
        rb4_12_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '4-13 意味もなく独り言や独り笑いをする
        rs.Find("Gyo=140")
        rb4_13_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=141")
        rb4_13_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=142")
        rb4_13_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '4-14 自分勝手に行動する
        rs.Find("Gyo=143")
        rb4_14_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=144")
        rb4_14_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=145")
        rb4_14_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '4-15 話がまとまらず、会話にならない
        rs.Find("Gyo=146")
        rb4_15_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=147")
        rb4_15_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=148")
        rb4_15_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)

        '5.社会生活への適応
        '5-1 薬の内服
        rs.Find("Gyo=149")
        rb5_1_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=150")
        rb5_1_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=151")
        rb5_1_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '5-2 金銭の管理
        rs.Find("Gyo=152")
        rb5_2_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=153")
        rb5_2_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=154")
        rb5_2_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '5-3 日常の意思決定
        rs.Find("Gyo=155")
        rb5_3_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=156")
        rb5_3_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=157")
        rb5_3_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=158")
        rb5_3_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '5-4 集団への不適応
        rs.Find("Gyo=159")
        rb5_4_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=160")
        rb5_4_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=161")
        rb5_4_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '5-5 買い物
        rs.Find("Gyo=162")
        rb5_5_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=163")
        rb5_5_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=164")
        rb5_5_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=165")
        rb5_5_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '5-6 簡単な調理
        rs.Find("Gyo=166")
        rb5_6_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=167")
        rb5_6_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=168")
        rb5_6_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=169")
        rb5_6_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)

        '6.特別な医療
        '点滴の管理
        rs.Find("Gyo=0", , ADODB.SearchDirectionEnum.adSearchBackward)
        Ch4_1.Checked = If(Util.checkDBNullValue(rs.Fields("Ch4").Value) = 1, True, False)
        '中心静脈栄養
        rs.Find("Gyo=1")
        Ch4_2.Checked = If(Util.checkDBNullValue(rs.Fields("Ch4").Value) = 1, True, False)
        '透析
        rs.Find("Gyo=2")
        Ch4_3.Checked = If(Util.checkDBNullValue(rs.Fields("Ch4").Value) = 1, True, False)
        'ストーマ（人工肛門）の処置
        rs.Find("Gyo=3")
        Ch4_4.Checked = If(Util.checkDBNullValue(rs.Fields("Ch4").Value) = 1, True, False)
        '酸素療法
        rs.Find("Gyo=4")
        Ch4_5.Checked = If(Util.checkDBNullValue(rs.Fields("Ch4").Value) = 1, True, False)
        'レスピレーター（人工呼吸器）
        rs.Find("Gyo=5")
        Ch4_6.Checked = If(Util.checkDBNullValue(rs.Fields("Ch4").Value) = 1, True, False)
        '気管切開の処置
        rs.Find("Gyo=6")
        Ch4_7.Checked = If(Util.checkDBNullValue(rs.Fields("Ch4").Value) = 1, True, False)
        '疼痛の看護
        rs.Find("Gyo=7")
        Ch4_8.Checked = If(Util.checkDBNullValue(rs.Fields("Ch4").Value) = 1, True, False)
        '経管栄養
        rs.Find("Gyo=8")
        Ch4_9.Checked = If(Util.checkDBNullValue(rs.Fields("Ch4").Value) = 1, True, False)
        'モニター測定（血圧、心拍、酸素飽和度等）
        rs.Find("Gyo=9")
        Ch4_10.Checked = If(Util.checkDBNullValue(rs.Fields("Ch4").Value) = 1, True, False)
        'じょくそうの処置
        rs.Find("Gyo=10")
        Ch4_11.Checked = If(Util.checkDBNullValue(rs.Fields("Ch4").Value) = 1, True, False)
        'カテーテル（コンドームカテーテル、留置カテーテル、ウロストーマ等）
        rs.Find("Gyo=11")
        Ch4_12.Checked = If(Util.checkDBNullValue(rs.Fields("Ch4").Value) = 1, True, False)

        '7.日常生活自立度
        '障害高齢者の日常生活自立度（寝たきり度）
        rs.Find("Gyo=170")
        rb7_1_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=171")
        rb7_1_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=172")
        rb7_1_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=173")
        rb7_1_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=174")
        rb7_1_5.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=175")
        rb7_1_6.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=176")
        rb7_1_7.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=177")
        rb7_1_8.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=178")
        rb7_1_9.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        '認知症高齢者の日常生活自立度
        rs.Find("Gyo=179")
        rb7_2_1.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=180")
        rb7_2_2.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=181")
        rb7_2_3.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=182")
        rb7_2_4.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=183")
        rb7_2_5.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=184")
        rb7_2_6.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=185")
        rb7_2_7.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)
        rs.Find("Gyo=186")
        rb7_2_8.Checked = If(Util.checkDBNullValue(rs.Fields("Opt4").Value) = 1, True, False)

        rs.Close()
        cnn.Close()
    End Sub

    Private Sub lastCertifiedCheckBox_CheckedChanged(sender As Object, e As System.EventArgs) Handles lastCertifiedCheckBox.CheckedChanged
        If lastCertifiedCheckBox.Checked = True Then
            lastCertifiedYmdBox.Visible = True
            lastCertifiedYmdBox.setADStr(Today.ToString("yyyy/MM/dd"))
        Else
            lastCertifiedYmdBox.Visible = False
        End If
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        clearOverviewPageInputBox()
    End Sub

    Private Sub btnCalcAge_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcAge.Click
        If birthYmdBox.getADStr() <> "" Then
            ageLabel.Text = birthYmdBox.getAge()
        End If
    End Sub

    Private Sub spText1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles spText1.KeyDown
        If e.KeyCode = Keys.Down Then
            spText2.Focus()
        End If
    End Sub

    Private Sub spText2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles spText2.KeyDown
        If e.KeyCode = Keys.Down Then
            spText3.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            spText1.Focus()
        End If
    End Sub

    Private Sub spText3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles spText3.KeyDown
        If e.KeyCode = Keys.Down Then
            spText4.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            spText2.Focus()
        End If
    End Sub

    Private Sub spText4_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles spText4.KeyDown
        If e.KeyCode = Keys.Up Then
            spText3.Focus()
        End If
    End Sub

    Private Sub spTabBtnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear1.Click, btnClear2.Click, btnClear3.Click, btnClear4.Click, btnClear5.Click, btnClear6.Click, btnClear7.Click
        Dim b As Button = CType(sender, Button)
        Dim tp As TabPage = b.Parent
        Dim num As String = b.Name.Substring(b.Name.Length - 1)
        CType(tp.Controls("SpDgv" & num), SpDgv).clearText()
    End Sub

    Private Sub spTabBtnRowInsert_Click(sender As System.Object, e As System.EventArgs) Handles btnRowInsert1.Click, btnRowInsert2.Click, btnRowInsert3.Click, btnRowInsert4.Click, btnRowInsert5.Click, btnRowInsert6.Click, btnRowInsert7.Click
        Dim b As Button = CType(sender, Button)
        Dim tp As TabPage = b.Parent
        Dim num As String = b.Name.Substring(b.Name.Length - 1)
        CType(tp.Controls("SpDgv" & num), SpDgv).rowInsert()
    End Sub

    Private Sub spTabBtnRowDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnRowDelete1.Click, btnRowDelete2.Click, btnRowDelete3.Click, btnRowDelete4.Click, btnRowDelete5.Click, btnRowDelete6.Click, btnRowDelete7.Click
        Dim b As Button = CType(sender, Button)
        Dim tp As TabPage = b.Parent
        Dim num As String = b.Name.Substring(b.Name.Length - 1)
        CType(tp.Controls("SpDgv" & num), SpDgv).rowDelete()
    End Sub

    Private Sub recordList_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles recordList.SelectedIndexChanged
        If Not IsNothing(recordList.SelectedItem) Then
            displayUserData(userLabel.Text, kanaLabel.Text, convWarekiStrToADStr(recordList.SelectedItem.ToString()))
        End If
    End Sub
End Class