Imports Microsoft.Reporting.WinForms
Imports System.Drawing.Printing

Public Class 印刷フォーム

    Private paramList As List(Of ReportParameter)

    Public Sub New(paramList As List(Of ReportParameter))
        InitializeComponent()
        Me.paramList = paramList

    End Sub

    Private Sub 印刷フォーム_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Symphony_KSave2.レポート.rdlc"
        Me.ReportViewer1.LocalReport.SetParameters(paramList)
        Me.ReportViewer1.RefreshReport()

        Dim ps As PageSettings = New PageSettings() 'プリンタ設定オブジェクト

        '余白の設定
        ps.Margins.Left = CInt(1 / 10 / 2.54 * 100) '約10mm
        ps.Margins.Right = CInt(1 / 10 / 2.54 * 100) '
        ps.Margins.Top = CInt(1 / 10 / 2.54 * 100) '
        ps.Margins.Bottom = CInt(1 / 10 / 2.54 * 100) '

        Me.ReportViewer1.SetPageSettings(ps)
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    End Sub
End Class