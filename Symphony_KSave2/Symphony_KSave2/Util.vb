Imports System.Reflection
Imports System.Runtime.InteropServices

Public Class Util
    ''' <summary>
    ''' コントロールのDoubleBufferedプロパティをTrueにする
    ''' </summary>
    ''' <param name="control">対象のコントロール</param>
    Public Shared Sub EnableDoubleBuffering(control As Control)
        control.GetType().InvokeMember( _
            "DoubleBuffered", _
            BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.SetProperty, _
            Nothing, _
            control, _
            New Object() {True})
    End Sub

    ''' <summary>
    ''' dgvのセルの値がNullかチェック、Nullの場合空文字を返す
    ''' </summary>
    ''' <param name="dgvCellValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function checkDBNullValue(dgvCellValue As Object) As String
        Return If(IsDBNull(dgvCellValue), "", dgvCellValue)
    End Function

    <DllImport("KERNEL32.DLL", CharSet:=CharSet.Auto)>
    Public Shared Function GetPrivateProfileString(
        ByVal lpAppName As String,
        ByVal lpKeyName As String, ByVal lpDefault As String,
        ByVal lpReturnedString As System.Text.StringBuilder, ByVal nSize As Integer,
        ByVal lpFileName As String) As Integer
    End Function

    <DllImport("KERNEL32.DLL", CharSet:=CharSet.Auto)>
    Public Shared Function WritePrivateProfileString(
        ByVal lpApplicationName As String,
        ByVal lpKeyName As String,
        ByVal lpString As String,
        ByVal lpFileName As String) As Long
    End Function

    Public Shared Function getIniString(ByVal lpSection As String, ByVal lpKeyName As String, ByVal lpFileName As String) As String
        Dim strValue As System.Text.StringBuilder = New System.Text.StringBuilder(1024)

        Dim sLen = GetPrivateProfileString(lpSection, lpKeyName, "", strValue, 1024, lpFileName)
        Dim str As String = strValue.ToString()

        Return str
    End Function

    Public Shared Function putIniString(ByVal lpSection As String, lpKeyName As String, ByVal lpValue As String, ByVal lpFileName As String) As Boolean
        If Not System.IO.File.Exists(lpFileName) Then
            Return False
        End If
        Dim result As Long = WritePrivateProfileString(lpSection, lpKeyName, lpValue, lpFileName)
        Return result <> 0
    End Function
End Class

