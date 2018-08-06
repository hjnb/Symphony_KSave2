Imports System.Reflection

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
End Class

