Public Class topForm

    'データベースのパス
    Public dbFilePath As String = My.Application.Info.DirectoryPath & "\KSave2.mdb"
    Public DB_KSave2 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFilePath

    'エクセルのパス
    Public excelFilePass As String = My.Application.Info.DirectoryPath & "\書式.xls"

    '.iniファイルのパス
    Public iniFilePath As String = My.Application.Info.DirectoryPath & "\KSave2.ini"

    'フォーム
    Private surveySlipForm As 認定調査票
    Private masterForm As マスタ

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        btnTarget.Visible = False
        initPrintState()
    End Sub

    Private Sub topForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'データベース、エクセル、構成ファイルの存在チェック
        If Not System.IO.File.Exists(dbFilePath) Then
            MsgBox("データベースファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(excelFilePass) Then
            MsgBox("エクセルファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(iniFilePath) Then
            MsgBox("構成ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub btnMaster_Click(sender As System.Object, e As System.EventArgs) Handles btnMaster.Click
        btnTarget.Visible = True
    End Sub

    Private Sub btnTarget_Click(sender As System.Object, e As System.EventArgs) Handles btnTarget.Click
        If IsNothing(masterForm) OrElse masterForm.IsDisposed Then
            masterForm = New マスタ()
            masterForm.Owner = Me
            masterForm.Show()
        End If
    End Sub

    Private Sub btnSurveySlip_Click(sender As System.Object, e As System.EventArgs) Handles btnSurveySlip.Click
        If IsNothing(surveySlipForm) OrElse surveySlipForm.IsDisposed Then
            surveySlipForm = New 認定調査票()
            surveySlipForm.Owner = Me
            surveySlipForm.Show()
        End If
    End Sub

    Private Sub initPrintState()
        Dim state As String = Util.getIniString("System", "Printer", iniFilePath)
        If state = "Y" Then
            rbtnPrint.Checked = True
        Else
            rbtnPreview.Checked = True
        End If
    End Sub

    Private Sub rbtnPreview_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnPreview.CheckedChanged
        If rbtnPreview.Checked = True Then
            Util.putIniString("System", "Printer", "N", iniFilePath)
        End If
    End Sub

    Private Sub rbtnPrint_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnPrint.CheckedChanged
        If rbtnPrint.Checked = True Then
            Util.putIniString("System", "Printer", "Y", iniFilePath)
        End If
    End Sub
End Class
