Public Class SpDgv
    Inherits DataGridView

    Public cellEnterFlg As Boolean = False
    Public selectedRowIndex As Integer = 0

    Public dt As New DataTable()

    Protected Overrides Function ProcessDialogKey(keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = Keys.Enter Then
            Return Me.ProcessTabKey(keyData)
        Else
            Return MyBase.ProcessDialogKey(keyData)
        End If
    End Function

    Protected Overrides Function ProcessDataGridViewKey(e As System.Windows.Forms.KeyEventArgs) As Boolean
        If e.KeyCode = Keys.Enter Then
            Return Me.ProcessTabKey(e.KeyCode)
        End If

        Dim tb As DataGridViewTextBoxEditingControl = CType(Me.EditingControl, DataGridViewTextBoxEditingControl)
        If Not IsNothing(tb) AndAlso ((e.KeyCode = Keys.Left AndAlso tb.SelectionStart = 0) OrElse (e.KeyCode = Keys.Right AndAlso tb.SelectionStart = tb.TextLength)) Then
            Return False
        Else
            Return MyBase.ProcessDataGridViewKey(e)
        End If
    End Function

    Public Sub clearText()
        For Each row As DataRow In dt.Rows
            row(0) = ""
            row(1) = ""
        Next
    End Sub

    Public Sub rowInsert()
        Dim row As DataRow = dt.NewRow()
        row(0) = ""
        row(1) = ""
        dt.Rows.InsertAt(row, selectedRowIndex)
        dt.Rows.RemoveAt(dt.Rows.Count - 1)
    End Sub

    Public Sub rowDelete()
        dt.Rows.RemoveAt(selectedRowIndex)
        Dim row As DataRow = dt.NewRow()
        row(0) = ""
        row(1) = ""
        dt.Rows.Add(row)
    End Sub

    Private Sub SpDgv_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellEnter
        If cellEnterFlg Then
            Me.BeginEdit(False)
            selectedRowIndex = e.RowIndex
        End If
    End Sub

    Private Sub SpDgv_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Me.CellMouseClick
        cellEnterFlg = True
        Me.BeginEdit(False)
        selectedRowIndex = e.RowIndex
    End Sub
End Class
