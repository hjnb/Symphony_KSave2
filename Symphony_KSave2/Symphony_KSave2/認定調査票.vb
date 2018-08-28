Imports System.Data.OleDb
Imports System.Text

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
        clearInputBox()

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
            recordList.Items.Add(rs.Fields("Ymd1").Value)
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
            .RowTemplate.Height = 25
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .DefaultCellStyle.Font = New Font("MS UI Gothic", 14, FontStyle.Bold)
            .DefaultCellStyle.BackColor = Color.FromArgb(145, 172, 244)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(145, 172, 244)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .BorderStyle = BorderStyle.None
            .GridColor = Color.FromArgb(236, 233, 216)
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
        dgv.dt.Columns.Add("Listing", Type.GetType("System.String"))
        dgv.dt.Columns.Add("Content", Type.GetType("System.String"))
        Dim row As DataRow
        For i = 0 To 59
            row = dgv.dt.NewRow()
            row(0) = ""
            row(1) = ""
            dgv.dt.Rows.Add(row)
        Next

        dgv.DataSource = dgv.dt

        With dgv
            With .Columns("Listing")
                .HeaderText = "項目"
                .Width = 47
            End With
            With .Columns("Content")
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

    End Sub

    Private Sub clearInputBox()
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
        clearInputBox()
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

End Class