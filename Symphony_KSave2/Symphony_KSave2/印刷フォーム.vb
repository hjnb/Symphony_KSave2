Imports Microsoft.Reporting.WinForms

Public Class 印刷フォーム

    Private paramList As List(Of ReportParameter)

    Public Sub New(paramList As List(Of ReportParameter))
        InitializeComponent()
        Me.paramList = paramList

    End Sub

    Private Sub 印刷フォーム_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.LocalReport.SetParameters(paramList)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class