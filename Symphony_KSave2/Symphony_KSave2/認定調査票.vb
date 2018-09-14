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
        '概況調査タブ
        clearOverviewPageInputBox()
        '特記事項タブ
        SpDgv1.clearText()
        SpDgv2.clearText()
        SpDgv3.clearText()
        SpDgv4.clearText()
        SpDgv5.clearText()
        SpDgv6.clearText()
        SpDgv7.clearText()

        '基本調査タブ

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

        '基本調査タブの表示処理


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