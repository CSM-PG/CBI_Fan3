Public Class frmMain

#Region "Class Variables and Constants"
    ' Unit Strings
    Dim PRESSURE_UNITS As String() = New String() {"in.WG", "in.HG", "PSI"}
    Dim FLOW_UNITS As String() = New String() {"ft³/min", "m³/sec"}
    Dim TEMP_UNITS As String() = New String() {"°F", "°C"}
    Dim ELEV_UNITS As String() = New String() {"ft.", "m."}

    ' Unit Conversion Factors
    Dim INHG_TO_INWC As Double = 13.5951
    Dim PSI_TO_INWC As Double = 27.67991
    Dim CMS_TO_CFM As Double = 2119
    Dim M_TO_FT As Double = 3.281

    ' Program Constants
    Public DELIMITER As String = "~"
    Dim NO_FAN_STR As String = "***NO FANS MEETING THESE CRITERIA***"
    Public DEFAULT_DATAFILE As String = "CBI_Data.cbi"
    Dim STD_TEMP_STR As String = "70 °F"
    Dim STD_ELEV_STR As String = "0 ft."
    Dim DEFAULT_MIN_EFFI As Double = 0.75
    Dim ERROR_COLOR As Color = Color.IndianRed

    ' Programatically Defined Controls
    Dim WithEvents pudEffi As New PercentageUpDown()
    Dim tt As New ToolTip

    ' Variables to hold the current input values
    Dim valISP As Double = 0
    Dim valDSP As Double = 0
    Dim valFlow As Double = 0
    Dim valMinTemp As Double = 0
    Dim valMaxTemp As Double = 0
    Dim valElev As Double = 0

    ' Global variables
    Dim minEfficiency As Double = 0.75
    Dim worstEfficiency As Double = 1
    Dim suggestedFans As List(Of String()) = New List(Of String())
    Dim sortedDescending As Boolean = False ' For sorting the dgv by fan size
    Dim inputFromFile As String()
    Public fileLoaded As Boolean = False

#End Region

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Check for datafile, create it if it doesn't exist
        If Not FileIO.FileSystem.FileExists(DEFAULT_DATAFILE) Then
            IO.File.Create(DEFAULT_DATAFILE).Close()
        End If

        ' Set up controls
        setUpControls()

    End Sub

    Private Sub setUpControls()
        ' Set up unit dropdowns
        '' ISP / DSP
        For Each unit In PRESSURE_UNITS
            cmbISP.Items.Add(unit)
            cmbDSP.Items.Add(unit)
        Next
        cmbISP.SelectedIndex = 0
        cmbDSP.SelectedIndex = 0
        '' Min / max temp
        For Each unit In TEMP_UNITS
            cmbMinTemp.Items.Add(unit)
            cmbMaxTemp.Items.Add(unit)
        Next
        cmbMinTemp.SelectedIndex = 0
        cmbMaxTemp.SelectedIndex = 0
        '' Flowrate
        For Each unit In FLOW_UNITS
            cmbFlow.Items.Add(unit)
        Next
        cmbFlow.SelectedIndex = 0
        '' Elevation
        For Each unit In ELEV_UNITS
            cmbElev.Items.Add(unit)
        Next
        cmbElev.SelectedIndex = 0

        ' Set up custom sorting for dgvFans
        '' The "size" column (col 1) needs custom sorting
        dgvFans.Columns(1).SortMode = DataGridViewColumnSortMode.Programmatic

        ' Change width of dgv row header (20 seems to look good)
        dgvFans.RowHeadersWidth = 20

        ' Add PercentUpDown control
        With pudEffi
            .Size = New Size(45, 15)
            .Value = DEFAULT_MIN_EFFI
            .Anchor = AnchorStyles.Left
        End With
        TableLayoutPanel10.Controls.Add(pudEffi)

        ' Clear labels
        lblMessage.Text = ""
        lblNoFan.Text = ""

        ' Tool tip
        tt.InitialDelay = 500
    End Sub

    Private Sub setControlValid(control As Object, msg As String, color As Color)
        control.BackColor = color
        tt.SetToolTip(control, msg)
    End Sub

    Private Sub listFans()

        ' Check than all fields are valid
        If Not validateInput() Then
            Exit Sub
        End If

        ' Clear no-fan label
        lblNoFan.Text = ""

        ' Clear current data
        dgvFans.Rows.Clear()

        ' Call
        Dim inputs = {valISP, valDSP, valFlow, valMinTemp, valMaxTemp, valElev}
        Dim correctPressure = rbActual.Checked And cbPressure.Checked
        Dim correctFlow = rbActual.Checked And cbFlow.Checked
        suggestedFans = FanCalculations.suggestFans(inputs, correctPressure, correctFlow)

        ' Set correctedVal label
        Dim corrections = correctedStrings()
        Dim ctsp = corrections(1)
        Dim cflow = corrections(2)
        lblCorrectedVals.Text = "Pressure: " + ctsp + "    Flow: " + cflow

        If suggestedFans.Count = 0 Then
            lblNoFan.Text = NO_FAN_STR
            Exit Sub
        End If

        ' Add results to datagrid and find worst efficiency
        Dim worst As Double = 1
        For Each fan In suggestedFans
            Dim eff As Double = CDbl(fan(0).Substring(0, fan(0).Length - 1) / 100)
            If eff < worst Then
                worst = eff
            End If
            dgvFans.Rows.Add(fan)
        Next
        worstEfficiency = worst

        ' if worst < min efficiency, set min to worst
        If worstEfficiency > minEfficiency Then
            pudEffi.Value = worstEfficiency
        End If

        ' Filter results by minEfficiency
        filterOutput()
    End Sub

    Private Sub filterOutput()
        ' If the dgv is empty, leave
        If suggestedFans.Count <= 0 Then
            Exit Sub
        End If

        For Each row In dgvFans.Rows
            Dim eff_str = row.Cells(0).Value
            eff_str = eff_str.substring(0, eff_str.Length - 1)
            If CDbl(eff_str) / 100 < worstEfficiency Then
                row.visible = False
            Else
                row.visible = True
            End If
        Next

        ' If no rows are currently displayed, warn user
        If dgvFans.Rows.GetRowCount(DataGridViewElementStates.Visible) = 0 Then
            lblNoFan.Text = NO_FAN_STR
        Else
            lblNoFan.Text = ""
        End If
    End Sub

    Private Sub saveToFile()
        ' Data to save
        Dim id As String = txtID.Text
        Dim desc As String = txtDesc.Text
        Dim isp As String = txtISP.Text
        Dim isp_u As String = cmbISP.SelectedIndex
        Dim dsp As String = txtDSP.Text
        Dim dsp_u As String = cmbDSP.SelectedIndex
        Dim flow As String = txtFlow.Text
        Dim flow_u As String = cmbFlow.SelectedIndex
        Dim minT As String = txtMinTemp.Text
        Dim minT_u As String = cmbMinTemp.SelectedIndex
        Dim maxT As String = txtMaxTemp.Text
        Dim maxT_u As String = cmbMaxTemp.SelectedIndex
        Dim elev As String = txtElev.Text
        Dim elev_u As String = cmbElev.SelectedIndex
        Dim min_effi As String = pudEffi.Value
        Dim data_line As String = Join({id, desc, isp, isp_u, dsp, dsp_u, flow, flow_u, minT, minT_u, maxT, maxT_u, elev, elev_u, min_effi}, DELIMITER)

        ' Get all lines in the file
        Dim lines = IO.File.ReadAllLines(DEFAULT_DATAFILE)
        Dim edit_line As Integer = -1

        ' See if there's already an entry for this id
        For i = 0 To lines.Length - 1
            If lines(i).Split(DELIMITER)(0) = id Then
                edit_line = i
            End If
        Next

        ' Change / Add line
        If edit_line >= 0 Then
            If MsgBox("An entry for " + id + " already exists. Would you like to modify it?", vbYesNo) = vbYes Then
                lines(edit_line) = data_line
            Else
                Exit Sub
            End If
        Else
            Array.Resize(lines, lines.Length + 1)
            lines(lines.Length - 1) = data_line
        End If

        ' Update message label
        lblMessage.Text = "Changes saved to file."

        ' Indicate file loaded
        fileLoaded = True

        ' Rewrite file
        IO.File.WriteAllLines(DEFAULT_DATAFILE, lines)
    End Sub

    Public Sub sendToPDF()
        ' Get the necessary info and call the createPDF function

        ' Get args for pdf creation
        Dim input As String() = collectInputStrings()
        Dim output As List(Of String()) = collectOutputStrings()
        Dim selectedRows As List(Of Integer) = selectedVisibleRows()
        Dim corrections = correctedStrings()
        Dim tspStr, correctedP, correctedF As String
        tspStr = corrections(0)
        correctedP = corrections(1)
        correctedF = corrections(2)

        pdfExport.createPDF(input, tspStr, correctedP, correctedF, output, selectedRows)

    End Sub

    Private Function collectInputStrings() As String()
        Dim id, desc, isp, dsp, flow, minT, maxT, elev, minEff As String

        id = txtID.Text
        desc = txtDesc.Text
        isp = Format(valISP, "0.0") + " " + cmbISP.Text
        dsp = Format(valDSP, "0.0") + " " + cmbDSP.Text
        flow = Format(valFlow, "N0") + " " + cmbFlow.Text
        minT = txtMinTemp.Text + " " + cmbMinTemp.Text
        maxT = txtMaxTemp.Text + " " + cmbMaxTemp.Text
        elev = Format(valElev, "N0") + " " + cmbElev.Text
        minEff = FormatPercent(minEfficiency, 0)

        If rbStandard.Checked Then
            minT = STD_TEMP_STR
            maxT = STD_TEMP_STR
            elev = STD_ELEV_STR
        End If

        Return New String() {id, desc, isp, dsp, flow, minT, maxT, elev, minEff}
    End Function

    Private Function collectOutputStrings() As List(Of String())
        ' Get the current contents of the datagrid as a list fo arrays of strings
        Dim rows = New List(Of String())
        For Each row In dgvFans.Rows
            If Not row.Visible Then
                Continue For
            End If
            Dim currentRow(8) As String
            For j As Integer = 0 To dgvFans.Columns.Count - 1
                currentRow(j) = row.Cells(j).Value.ToString()
            Next
            rows.Add(currentRow)
        Next

        Return rows
    End Function

    Private Function correctedStrings() As String()
        Dim tspVal = valISP + valDSP
        Dim ctspVal = tspVal

        If rbActual.Checked And cbPressure.Checked Then
            ctspVal = FanCalculations.correctedPressure(tspVal, valMaxTemp, valElev)
        End If

        Dim tspDisplayVal, ctspDisplayVal
        Select Case cmbISP.SelectedIndex
            Case 0
                tspDisplayVal = tspVal
                ctspDisplayVal = ctspVal
            Case 1
                tspDisplayVal = tspVal / convertPressure(1, PRESSURE_UNITS(1))
                ctspDisplayVal = ctspVal / convertPressure(1, PRESSURE_UNITS(1))
            Case 2
                tspDisplayVal = tspVal / convertPressure(1, PRESSURE_UNITS(2))
                ctspDisplayVal = ctspVal / convertPressure(1, PRESSURE_UNITS(2))
        End Select
        Dim tspStr = Format(tspDisplayVal, "0.0") + " " + cmbISP.Text
        Dim ctspStr = Format(ctspDisplayVal, "0.0") + " " + cmbISP.Text

        Dim cflowVal = valFlow
        If rbActual.Checked And cbFlow.Checked Then
            cflowVal = FanCalculations.correctedFlow(valFlow, valMaxTemp, valElev)
        End If

        Dim cflowDisplayVal
        Select Case cmbFlow.SelectedIndex
            Case 0
                cflowDisplayVal = cflowVal
            Case 1
                cflowDisplayVal = cflowVal / convertFlow(1, FLOW_UNITS(1))
            Case 2
                cflowDisplayVal = cflowVal / convertFlow(1, FLOW_UNITS(2))
        End Select
        Dim cflowStr = Format(cflowDisplayVal, "N0") + " " + cmbFlow.Text

        Return {tspStr, ctspStr, cflowStr}

    End Function

    Private Function selectedVisibleRows()
        ' Return the apparent index fo selected rows (that is, the index as they currently appear on the dgv)
        Dim i As Integer = 0
        Dim selected As New List(Of Integer)
        For Each row In dgvFans.Rows
            If Not row.Visible Then
                Continue For
            End If
            If row.Selected Then
                selected.Add(i)
            End If
            i += 1
        Next
        Return selected
    End Function

    Private Sub loadFromFile()
        frmSelectSys.Show(Me)

    End Sub

    Public Sub setSystem(line As String)
        Dim data = line.Split(DELIMITER)

        inputFromFile = data

        txtID.Text = data(0)
        txtDesc.Text = data(1)
        txtISP.Text = data(2)
        cmbISP.SelectedIndex = Int(data(3))
        txtDSP.Text = data(4)
        cmbDSP.SelectedIndex = Int(data(5))
        txtFlow.Text = data(6)
        cmbFlow.SelectedIndex = Int(data(7))
        txtMinTemp.Text = data(8)
        cmbMinTemp.SelectedIndex = Int(data(9))
        txtMaxTemp.Text = data(10)
        cmbMaxTemp.SelectedIndex = Int(data(11))
        txtElev.Text = data(12)
        cmbElev.SelectedIndex = data(13)
        pudEffi.Value = CDbl(data(14))

    End Sub

    Private Function sameAsFile()
        If Not fileLoaded Then
            Return False
        End If
        Dim data = inputFromFile
        Return (txtID.Text = data(0)) And (txtDesc.Text = data(1)) And
               (txtISP.Text = data(2)) And (cmbISP.SelectedIndex = data(3)) And
               (txtDSP.Text = data(4)) And (cmbDSP.SelectedIndex = data(5)) And
               (txtFlow.Text = data(6)) And (cmbFlow.SelectedIndex = data(7)) And
               (txtMinTemp.Text = data(8)) And (cmbMinTemp.SelectedIndex = data(9)) And
               (txtMaxTemp.Text = data(10)) And (cmbMaxTemp.SelectedIndex = data(11)) And
               (txtElev.Text = data(12)) And (cmbElev.SelectedIndex = data(13)) And
               (minEfficiency = data(14))
    End Function

#Region "Conversion Functions"
    Private Function convertPressure(pres As Double, fromUnit As String) As Double
        Select Case fromUnit
            Case PRESSURE_UNITS(0)
                Return pres
            Case PRESSURE_UNITS(1)
                Return pres * INHG_TO_INWC
            Case PRESSURE_UNITS(2)
                Return pres * PSI_TO_INWC
        End Select
    End Function

    Private Function convertFlow(flow As Double, fromUnit As String) As Double
        Select Case fromUnit
            Case FLOW_UNITS(0)
                Return flow
            Case FLOW_UNITS(1)
                Return flow * CMS_TO_CFM
        End Select
    End Function

    Private Function convertTemp(temp As Double, fromUnit As String) As Double
        Select Case fromUnit
            Case TEMP_UNITS(0)
                Return temp
            Case TEMP_UNITS(1)
                Return temp * 9 / 5 + 32
        End Select
    End Function

    Private Function convertElev(elev As Double, fromUnit As String) As Double
        Select Case fromUnit
            Case ELEV_UNITS(0)
                Return elev
            Case ELEV_UNITS(1)
                Return elev * M_TO_FT
        End Select
    End Function
#End Region

#Region "Input Validation"

    Private Function validateInput() As Boolean
        Dim errorString As String = ""
        If Not validateISP() Then
            errorString += "Inlet Static Pressure, "
        End If
        If Not validateDSP() Then
            errorString += "Discharge Static Pressure, "
        End If
        If Not validateFlow() Then
            errorString += "Flow Rate, "
        End If
        If Not validateMinTemp() Then
            errorString += "Minimum Temperature, "
        End If
        If Not validateMaxTemp() Then
            errorString += "Maximum Temperature, "
        End If
        If Not validateElev() Then
            errorString += "Elevation, "
        End If

        If errorString.Length > 0 Then
            Dim fullString = "Invalid input for: " + errorString.Remove(errorString.Length - 2, 2) + "."
            MsgBox(fullString, MsgBoxStyle.OkOnly, "Error")
            Return False
        End If

        Return True
    End Function

    Private Function validateISP() As Boolean
        If Not IsNumeric(txtISP.Text) Then
            If txtISP.Text = "" Then
                setControlValid(txtISP, "Enter an Inlet Static Pressure", ERROR_COLOR)
            Else
                setControlValid(txtISP, "Inlet Static Pressure must be a number", ERROR_COLOR)
            End If
            Return False
        End If
        ' Convert to a number
        Dim val As Double
        Try
            Double.TryParse(txtISP.Text, val)
        Catch ex As Exception
            setControlValid(txtISP, "Enter a valid Inlet Static Pressure", ERROR_COLOR)
            Return False
        End Try
        ' Make sure it's negative
        If val < 0 Then
            setControlValid(txtISP, "Inlet Static Pressure must be positive", ERROR_COLOR)
            Return False
        End If
        ' Value must be good, convert to base units and save
        valISP = convertPressure(val, cmbISP.SelectedItem)
        setControlValid(txtISP, "", Color.White)
        Return True
    End Function

    Private Function validateDSP() As Boolean
        If Not IsNumeric(txtDSP.Text) Then
            If txtDSP.Text = "" Then
                setControlValid(txtDSP, "Enter an Discharge Static Pressure", ERROR_COLOR)
            Else
                setControlValid(txtDSP, "Discharge Static Pressure must be a number", ERROR_COLOR)
            End If
            Return False
        End If
        ' Convert to a number
        Dim val As Double
        Try
            Double.TryParse(txtDSP.Text, val)
        Catch ex As Exception
            setControlValid(txtDSP, "Enter a valid Discharge Static Pressure", ERROR_COLOR)
            Return False
        End Try
        ' Make sure it's positive
        If val < 0 Then
            setControlValid(txtDSP, "Discharge Static Pressure must be negative", ERROR_COLOR)
            Return False
        End If
        ' Value must be good, convert to base units and save
        valDSP = convertPressure(val, cmbDSP.SelectedItem)
        setControlValid(txtDSP, "", Color.White)
        Return True
    End Function

    Private Function validateFlow() As Boolean
        If Not IsNumeric(txtDSP.Text) Then
            If txtFlow.Text = "" Then
                setControlValid(txtFlow, "Enter a Flow Rate", ERROR_COLOR)
            Else
                setControlValid(txtFlow, "Flow Rate must be a number", ERROR_COLOR)
            End If
            Return False
        End If
        ' Convert to a number
        Dim val As Double
        Try
            Double.TryParse(txtFlow.Text, val)
        Catch ex As Exception
            setControlValid(txtFlow, "Enter a valid Flow Rate", ERROR_COLOR)
            Return False
        End Try
        ' Make sure it's positive
        If val < 0 Then
            setControlValid(txtFlow, "Flow Rate must be positive", ERROR_COLOR)
            Return False
        End If
        ' Value must be good, convert to base units and save
        valFlow = convertFlow(val, cmbFlow.SelectedItem)
        setControlValid(txtFlow, "", Color.White)
        Return True
    End Function

    Private Function validateMinTemp() As Boolean
        If Not IsNumeric(txtMinTemp.Text) Then
            If txtMinTemp.Text = "" Then
                setControlValid(txtMinTemp, "Enter a minimum temperature", ERROR_COLOR)
            Else
                setControlValid(txtMinTemp, "Minimum temperature must be a number", ERROR_COLOR)
            End If
            Return False
        End If
        ' Convert to a number
        Dim val As Double
        Try
            Double.TryParse(txtMinTemp.Text, val)
        Catch ex As Exception
            setControlValid(txtMinTemp, "Enter a valid minimum temperature", ERROR_COLOR)
            Return False
        End Try
        ' Value must be good, convert to base units and save
        valMinTemp = convertTemp(val, cmbMinTemp.SelectedItem)
        setControlValid(txtMinTemp, "", Color.White)
        Return True
    End Function

    Private Function validateMaxTemp() As Boolean
        If Not IsNumeric(txtMaxTemp.Text) Then
            If txtMaxTemp.Text = "" Then
                setControlValid(txtMaxTemp, "Enter a Maximum temperature", ERROR_COLOR)
            Else
                setControlValid(txtMaxTemp, "Maximum temperature must be a number", ERROR_COLOR)
            End If
            Return False
        End If
        ' Convert to a number
        Dim val As Double
        Try
            Double.TryParse(txtMaxTemp.Text, val)
        Catch ex As Exception
            setControlValid(txtMaxTemp, "Enter a valid Maximum temperature", ERROR_COLOR)
            Return False
        End Try
        ' Convert to base units
        val = convertTemp(val, cmbMaxTemp.SelectedItem)
        ' Make sure it's not less than min
        If val < valMinTemp Then
            setControlValid(txtMaxTemp, "Maximum temperature cannont be less than minimum", ERROR_COLOR)
            Return False
        End If
        ' Value must be good, save
        valMaxTemp = val
        setControlValid(txtMaxTemp, "", Color.White)
        Return True
    End Function

    Private Function validateElev()
        If Not IsNumeric(txtElev.Text) Then
            If txtElev.Text = "" Then
                setControlValid(txtElev, "Enter an elevation", ERROR_COLOR)
            Else
                setControlValid(txtElev, "Elevation must be number", ERROR_COLOR)
            End If
            Return False
        End If
        ' Convert to a number
        Dim val As Double
        Try
            Double.TryParse(txtElev.Text, val)
        Catch ex As Exception
            setControlValid(txtElev, "Enter a valid elevation", ERROR_COLOR)
            Return False
        End Try
        ' Must be good, convert to base units and save
        valElev = convertElev(val, cmbElev.SelectedItem)
        setControlValid(txtElev, "", Color.White)
        Return True
    End Function
#End Region

#Region "Click Events"

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        loadFromFile()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        saveToFile()
    End Sub

    Private Sub btnListFans_Click(sender As Object, e As EventArgs) Handles btnListFans.Click
        listFans()
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        sendToPDF()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtISP.Text = ""
        cmbISP.SelectedIndex = 0
        txtDSP.Text = ""
        cmbDSP.SelectedIndex = 0
        txtFlow.Text = ""
        cmbFlow.SelectedIndex = 0
        txtMinTemp.Text = ""
        cmbMinTemp.SelectedIndex = 0
        txtMaxTemp.Text = ""
        cmbMaxTemp.SelectedIndex = 0
        txtElev.Text = ""
        cmbElev.SelectedIndex = 0
    End Sub
#End Region

#Region "Other Events"
    Private Sub dgvFans_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvFans.ColumnHeaderMouseClick
        ' If the size column header is clikced, do a custom sort
        ' --The whole "sortedDescending" variable thing is probably not necessary, but IDK the correct way to do this...
        If e.ColumnIndex = 1 Then
            If sortedDescending Then
                dgvFans.Sort(New sizeStrCompareAsc)
                sortedDescending = False
                dgvFans.Columns(1).HeaderCell.SortGlyphDirection = SortOrder.Descending
            Else
                dgvFans.Sort(New sizeStrCompareDesc)
                sortedDescending = True
                dgvFans.Columns(1).HeaderCell.SortGlyphDirection = SortOrder.Ascending
            End If
        Else
            dgvFans.Columns(1).HeaderCell.SortGlyphDirection = SortOrder.None
        End If
    End Sub

    Private Sub dgvFans_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles dgvFans.SortCompare
        If e.Column.Index = 1 Then
            Exit Sub
        End If
        Dim txt1, txt2
        If e.Column.Index = 0 Then
            txt1 = e.CellValue1.Substring(0, e.CellValue1.Length - 1)
            txt2 = e.CellValue2.Substring(0, e.CellValue2.Length - 1)
        Else
            txt1 = e.CellValue1
            txt2 = e.CellValue2
        End If

        Dim val1, val2 As Double
        Double.TryParse(txt1, val1)
        Double.TryParse(txt2, val2)

        If val1 < val2 Then
            e.SortResult = 1
        Else
            e.SortResult = -1
        End If
        e.Handled = True
    End Sub

    Private Sub pudEffi_ValueChanged(sender As Object, e As EventArgs) Handles pudEffi.ValueChanged
        ' Set the global var to the new value
        minEfficiency = pudEffi.Value

        ' Filter the dgv for the new min effi
        filterOutput()
    End Sub

    Private Sub rbStandard_CheckedChanged(sender As Object, e As EventArgs) Handles rbStandard.CheckedChanged
        If rbStandard.Checked Then
            txtMinTemp.Enabled = False
            cmbMinTemp.Enabled = False
            txtMaxTemp.Enabled = False
            cmbMaxTemp.Enabled = False
            txtElev.Enabled = False
            cmbElev.Enabled = False
            lblCorrect.Visible = False
            cbPressure.Visible = False
            cbFlow.Visible = False
            lblCorrectedValuesLabel.Visible = False
            lblCorrectedVals.Visible = False
        Else
            txtMinTemp.Enabled = True
            cmbMinTemp.Enabled = True
            txtMaxTemp.Enabled = True
            cmbMaxTemp.Enabled = True
            txtElev.Enabled = True
            cmbElev.Enabled = True
            lblCorrect.Visible = True
            cbPressure.Visible = True
            cbFlow.Visible = True
            lblCorrectedValuesLabel.Visible = True
            lblCorrectedVals.Visible = True
        End If
    End Sub

    Private Sub cbPressure_CheckedChanged(sender As Object, e As EventArgs) Handles cbPressure.CheckedChanged
        If Not cbPressure.Checked Then
            If Not cbFlow.Checked Then
                cbFlow.Checked = True
            End If
        End If
    End Sub

    Private Sub cbFlow_CheckedChanged(sender As Object, e As EventArgs) Handles cbFlow.CheckedChanged
        If Not cbFlow.Checked Then
            If Not cbPressure.Checked Then
                cbPressure.Checked = True
            End If
        End If
    End Sub

    Private Sub inputChanged(sender As Object, e As EventArgs) _
        Handles txtISP.TextChanged, cmbISP.SelectedIndexChanged,
                txtDSP.TextChanged, cmbDSP.SelectedIndexChanged,
                txtFlow.TextChanged, cmbFlow.SelectedIndexChanged,
                txtMinTemp.TextChanged, cmbMinTemp.SelectedIndexChanged,
                txtMaxTemp.TextChanged, cmbMaxTemp.SelectedIndexChanged,
                txtElev.TextChanged, cmbElev.SelectedIndexChanged
        If Not fileLoaded Then
            Exit Sub
        End If
        If Not sameAsFile() Then
            lblMessage.Text = "Unsaved Changes"
        Else
            lblMessage.Text = ""
        End If
    End Sub

#End Region

End Class

Public Class PercentageUpDown
    Inherits NumericUpDown
    ' Super nifty little class I stole from here: https://www.codeproject.com/Articles/16758/PercentageUpDown-Control

    Public Overrides Sub DownButton()
        If Not Me.ReadOnly And Me.Value > Me.Minimum Then
            MyBase.DownButton()
        End If
    End Sub

    Public Overrides Sub UpButton()
        If Not Me.ReadOnly Then
            MyBase.UpButton()
        End If
    End Sub

    Public Overrides Property Text() As String
        Get
            Return MyBase.Text.TrimEnd("%")
        End Get
        Set(ByVal Value As String)
            MyBase.Text = Value & "%"
        End Set
    End Property

    <System.ComponentModel.Category("Data"),
         System.ComponentModel.DefaultValue(0.0)>
    Public Shadows Property Value() As Double
        Get
            Return MyBase.Value / 100
        End Get
        Set(ByVal Value As Double)
            MyBase.Value = Value * 100
        End Set
    End Property
End Class

Class sizeStrCompareAsc
    Implements IComparer
    ' For sorting by fan size (ascending order)

    Function transformSizeStr(sizeStr As String)
        ' Example: turns "44-3" into "344"
        Return sizeStr.Substring(3, 1) + sizeStr.Substring(0, 2)
    End Function

    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        Dim str_x = transformSizeStr(x.Cells(1).Value)
        Dim str_y = transformSizeStr(y.Cells(1).Value)
        If str_x > str_y Then
            Return 1
        End If
        Return -1
    End Function
End Class

Class sizeStrCompareDesc
    Implements IComparer
    ' For sorting by fan size (descending order)
    ' I'm sure there's a way to do there without using two different compareres
    ' for asc and desc order...but I'm not to great with VB, and this way works so...

    Function transformSizeStr(sizeStr As String)
        ' Example: turns "44-3" into "344"
        Return sizeStr.Substring(3, 1) + sizeStr.Substring(0, 2)
    End Function

    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        Dim str_x = transformSizeStr(x.Cells(1).Value)
        Dim str_y = transformSizeStr(y.Cells(1).Value)
        If str_x < str_y Then
            Return 1
        End If
        Return -1
    End Function
End Class

Class otherCompareAsc
    Implements IComparer

    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        Throw New NotImplementedException()
    End Function
End Class