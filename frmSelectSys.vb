Public Class frmSelectSys

    Dim lines
    Private Sub frmSelectSys_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Center on main form
        Me.Location = New Point(frmMain.Location.X, frmMain.Location.Y)
        fillList()
        lstSystems.Sorted = True
    End Sub

    Private Sub fillList()
        lstSystems.Items.Clear()
        lines = IO.File.ReadAllLines(frmMain.DEFAULT_DATAFILE)
        For i = 0 To lines.Length - 1
            lstSystems.Items.Add(lines(i).Split(frmMain.DELIMITER)(0))
        Next
    End Sub

    Public Function getLine(id) As String
        lines = IO.File.ReadAllLines(frmMain.DEFAULT_DATAFILE)
        For Each line In lines
            If line.Split(frmMain.DELIMITER)(0) = id Then
                Return line
            End If
        Next
    End Function

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        If lstSystems.SelectedIndex >= 0 Then
            frmMain.setSystem(getLine(lstSystems.SelectedItem))
        Else
            Exit Sub
        End If

        frmMain.fileLoaded = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If lstSystems.SelectedIndex < 0 Then
            Exit Sub
        End If
        If MsgBox("Are you sure you want to delete " & lstSystems.SelectedItem, MsgBoxStyle.OkCancel, "Delete System") = vbCancel Then
            Exit Sub
        End If
        Dim oldLines = IO.File.ReadAllLines(frmMain.DEFAULT_DATAFILE)
        Dim newLines = New List(Of String)
        For Each line In oldLines
            If Not line.Split(frmMain.DELIMITER)(0) = lstSystems.SelectedItem Then
                newLines.Add(line)
            End If
        Next
        IO.File.WriteAllLines(frmMain.DEFAULT_DATAFILE, newLines)
        fillList()
    End Sub
End Class