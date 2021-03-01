Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Module pdfExport
    ' This module is for creating PDFs of the CBI Fan program input/output

    ' String Constants
    Dim PAGE_TITLE As String = "CBI Fan Design Criteria"
    Dim COMPANY_TEXT As String = "Clarke's Sheet Metal, Inc."
    Dim PARAM_TITLE As String = "Operating Requirements / Conditions"
    Dim PRESS_TEXT As String = "Pressure Requirements"
    Dim TEMP_TEXT As String = "Operating Temperature"
    Dim NO_FAN_TEXT As String = "***NO FANS MEETING SPECIFICATIONS***"
    Dim SELECT_TEXT As String = "Select a fan from the following list:"

    ' Table Constants
    Dim TABLE_MIN_X As Double = 30
    Dim TABLE_MIN_Y As Double = 250
    Dim TABLE_WIDTH As Double = 552
    Dim NUM_COLS As Integer = 8
    Dim COL_WEIGHTS = New Double() {10, 10, 10, 10, 15, 15, 10, 13}
    Dim ROW_HEIGHT As Double = 15
    Dim COL_HEADER_HEIGHT As Double = 20
    Dim HEADER_STRINGS = New String() {"Efficiency", "Fan Size", "RPM", "Max. RPM", "Min. Shaft HP", "Max. Shaft HP", "Motor HP", "dB (5 ft.)"}

    ' GFX Constants
    Dim BLACK As XColor = XColor.FromArgb(0, 0, 0)
    Dim BLUE As XColor = XColor.FromArgb(0, 0, 255)
    Dim GREEN As XColor = XColor.FromArgb(0, 255, 0)
    Dim BLACK_PEN As XPen = New XPen(BLACK)
    Dim BLUE_PEN As XPen = New XPen(BLUE)
    Dim GREEN_PEN As XPen = New XPen(GREEN)
    Dim BLACK_BRUSH As XBrush = XBrushes.Black
    Dim SHADE_BRUSH = New XSolidBrush(XColor.FromArgb(50, 0, 0, 0))
    Dim CENTER As XStringFormat = XStringFormats.Center
    Dim TOP_CENTER As XStringFormat = XStringFormats.TopCenter
    Dim TOP_LEFT As XStringFormat = XStringFormats.TopLeft
    Dim TOP_RIGHT As XStringFormat = XStringFormats.TopRight
    Dim CENTER_LEFT As XStringFormat = XStringFormats.CenterLeft
    Dim CENTER_RIGHT As XStringFormat = XStringFormats.CenterRight
    Dim BOTTOM_LEFT As XStringFormat = XStringFormats.BottomLeft
    Dim BOTTOM_RIGHT As XStringFormat = XStringFormats.BottomRight
    Dim TYPEFACE As String = "Verdana"
    Dim TITLE_FONT As XFont = New XFont(TYPEFACE, 16, XFontStyle.Bold)
    Dim SECT_FONT As XFont = New XFont(TYPEFACE, 13)
    Dim HEADER_FONT As XFont = New XFont(TYPEFACE, 11)
    Dim PARAM_FONT As XFont = New XFont(TYPEFACE, 10)

    ' Draw all rectangles? (for debugging/designing)
    Dim DRAW_ALL_RECTS As Boolean = False

    ' Design constants
    Dim pwidth As Double
    Dim pheight As Double
    Dim border As Double = 20
    Dim iborder As Double = border + 10
    Dim header_y_offset = 25
    Dim header_line_height As Double = 13
    Dim num_header_lines As Integer = 3
    Dim header_height = header_line_height * num_header_lines
    Dim param_table_y_offset = 20
    Dim param_table_row_height = 20

    Function createPDF(input As String(), tsp As String, ctsp As String, cflow As String, output As List(Of String()), selected_rows As List(Of Integer))
        ' Creates a pdf...
        ' OK, so id and desc should perhaps be combined into on arg 
        ' tsp is somewhere between an input and an output, but for now is left on its own...
        ' If display is true, an external process is started to view the PDF

        ' Extract input strings
        Dim id, desc As String
        id = input(0)
        desc = input(1)

        ' Create new PDF doc
        Dim doc As PdfDocument = New PdfDocument()
        doc.Info.Title = "CBI Fan Design"

        ' Create an empty page
        Dim page As PdfPage = doc.AddPage()
        pwidth = page.Width
        pheight = page.Height

        ' Create an XGraphics object for drawing
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)



        ' Create a rect the size of the page
        Dim bdr_rect As New XRect(New XPoint(), gfx.PageSize)

        ' Shrink bdr_rect by border size
        bdr_rect.Inflate(-border, -border)

        If DRAW_ALL_RECTS Then
            gfx.DrawRectangle(BLUE_PEN, bdr_rect)
        End If

        ' Place title
        gfx.DrawString(PAGE_TITLE, TITLE_FONT, BLACK_BRUSH, bdr_rect, TOP_CENTER)

        ' Header
        Dim headerP1 As New XPoint(iborder, header_y_offset + iborder)
        Dim headerP2 As New XPoint(pwidth - iborder, header_y_offset + iborder + header_height)
        Dim header_rect As New XRect(headerP1, headerP2)
        drawHeader(gfx, header_rect, id, desc)


        ' Design Parameters
        Dim paramP1 = offsetPoint(header_rect.BottomLeft, 0, param_table_y_offset)
        Dim paramP2 As XPoint = paramP1
        paramP2.Offset(header_rect.Width, 10 * param_table_row_height)
        Dim param_rect As New XRect(paramP1, paramP2)

        If DRAW_ALL_RECTS Then
            gfx.DrawRectangle(BLUE_PEN, param_rect)
        End If

        drawParameters(gfx, param_rect, input, tsp, ctsp, cflow)


        ' Fan Suggestions
        Dim msgP1 As XPoint = param_rect.BottomLeft
        Dim msgP2 As XPoint = param_rect.BottomRight
        msgP1.Offset(0, 20)
        msgP2.Offset(0, 40)
        Dim msg_rect As New XRect(msgP1, msgP2)

        If DRAW_ALL_RECTS Then
            gfx.DrawRectangle(BLUE_PEN, msg_rect)
        End If

        If output.Count > 0 Then
            gfx.DrawString(SELECT_TEXT, SECT_FONT, BLACK_BRUSH, msg_rect, TOP_CENTER)
            Dim p1 = msg_rect.BottomLeft
            p1.Offset(0, 20)
            drawTable(gfx, p1, output, selected_rows)
        Else
            gfx.DrawString(NO_FAN_TEXT, SECT_FONT, BLACK_BRUSH, msg_rect, TOP_CENTER)
        End If

        ' Save to file
        doc.Save("tmp.pdf")

        ' if display is true, start a viewer
        If True Then
            Process.Start("tmp.pdf")
        End If

    End Function

    Private Function drawHeader(gfx As XGraphics, rect As XRect, id As String, desc As String)

        If DRAW_ALL_RECTS Then
            gfx.DrawRectangle(GREEN_PEN, rect)
        End If

        '' Company label
        Dim companyP1 As XPoint = rect.TopLeft
        Dim companyP2 As XPoint = companyP1
        companyP2.Offset(150, header_line_height)
        Dim company_rect As New XRect(companyP1, companyP2)

        If DRAW_ALL_RECTS Then
            gfx.DrawRectangle(BLUE_PEN, company_rect)
        End If

        gfx.DrawString(COMPANY_TEXT, HEADER_FONT, BLACK_BRUSH, company_rect, CENTER_LEFT)

        '' Designed for
        Dim designP1 As XPoint = company_rect.BottomLeft
        Dim designP2 As XPoint = designP1
        designP2.Offset(150, header_line_height)
        Dim design_rect As New XRect(designP1, designP2)

        If DRAW_ALL_RECTS Then
            gfx.DrawRectangle(BLUE_PEN, design_rect)
        End If

        gfx.DrawString("Designed for: " + desc, HEADER_FONT, BLACK_BRUSH, design_rect, CENTER_LEFT)

        '' File reference
        Dim frefP1 As XPoint = design_rect.BottomLeft
        Dim frefP2 As XPoint = frefP1
        frefP2.Offset(150, header_line_height)
        Dim fref_rect As New XRect(frefP1, frefP2)

        If DRAW_ALL_RECTS Then
            gfx.DrawRectangle(BLUE_PEN, fref_rect)
        End If

        gfx.DrawString("File Reference: " + id, HEADER_FONT, BLACK_BRUSH, fref_rect, CENTER_LEFT)

        '' Date
        Dim dateP1 As XPoint = rect.TopLeft
        dateP1.Offset(451, 0)
        Dim dateP2 As XPoint = dateP1
        dateP2.Offset(100, header_line_height)
        Dim date_rect As New XRect(dateP1, dateP2)

        If DRAW_ALL_RECTS Then
            gfx.DrawRectangle(BLUE_PEN, date_rect)
        End If

        gfx.DrawString("Date:", HEADER_FONT, BLACK_BRUSH, date_rect, CENTER_LEFT)
        gfx.DrawString(Now.ToString("d"), HEADER_FONT, BLACK_BRUSH, date_rect, CENTER_RIGHT)

        '' Time
        Dim timeP1 As XPoint = date_rect.BottomLeft
        Dim timeP2 As XPoint = timeP1
        timeP2.Offset(100, header_line_height)
        Dim time_rect As New XRect(timeP1, timeP2)

        If DRAW_ALL_RECTS Then
            gfx.DrawRectangle(BLUE_PEN, time_rect)
        End If

        gfx.DrawString("Time:", HEADER_FONT, BLACK_BRUSH, time_rect, CENTER_LEFT)
        gfx.DrawString(Now.ToString("t"), HEADER_FONT, BLACK_BRUSH, time_rect, CENTER_RIGHT)
    End Function

    Private Function drawParameter(gfx As XGraphics, rect As XRect, input As String(), correctePressure As String, correctedFlow As String)
        'Dim isp, dsp, flow, minT, maxT, elev
        'isp = input(2)
        'dsp = input(3)
        'flow = input(4)
        'minT = input(5)
        'maxT = input(6)
        'elev = input(7)

        ''' Surrounding box
        'Dim pbox As XRect = rect
        'pbox.Offset(0, 9)
        'pbox.Height -= 9
        'Dim box_TL1 As XPoint = pbox.TopLeft
        'Dim box_BL As XPoint = pbox.BottomLeft
        'Dim box_TR1 As XPoint = pbox.TopRight
        'Dim box_BR As XPoint = pbox.BottomRight
        'Dim box_TL2 As XPoint = box_TL1
        'Dim box_TR2 As XPoint = box_TR1
        'box_TL2.Offset(150, 0)
        'box_TR2.Offset(-150, 0)
        'gfx.DrawLine(BLACK_PEN, box_TL1, box_TL2)
        'gfx.DrawLine(BLACK_PEN, box_TR2, box_TR1)
        'gfx.DrawLine(BLACK_PEN, box_TL1, box_BL)
        'gfx.DrawLine(BLACK_PEN, box_TR1, box_BR)
        'gfx.DrawLine(BLACK_PEN, box_BL, box_BR)

        ''' Pressure
        'Dim presP1 As XPoint = paramP1
        'presP1.Offset(35, 25)
        'Dim presP2 As XPoint = presP1
        'presP2.Offset(150, 60)
        'Dim pres_rect As New XRect(presP1, presP2)

        'If DRAW_ALL_RECTS Then
        '    gfx.DrawRectangle(BLUE_PEN, pres_rect)
        'End If

        'gfx.DrawString(PRESS_TEXT, PARAM_FONT, BLACK_BRUSH, pres_rect, TOP_CENTER)

        'Dim presv1P1 As XPoint = presP1
        'presv1P1.Offset(5, 15)
        'Dim presv1P2 As XPoint = presv1P1
        'presv1P2.Offset(140, 23)
        'Dim presv1_rect As New XRect(presv1P1, presv1P2)

        'If DRAW_ALL_RECTS Then
        '    gfx.DrawRectangle(BLUE_PEN, presv1_rect)
        'End If

        'gfx.DrawString("Inlet:", PARAM_FONT, BLACK_BRUSH, presv1_rect, TOP_LEFT)
        'gfx.DrawString(isp, PARAM_FONT, BLACK_BRUSH, presv1_rect, TOP_RIGHT)
        'gfx.DrawString("Discharge:", PARAM_FONT, BLACK_BRUSH, presv1_rect, BOTTOM_LEFT)
        'gfx.DrawString(dsp, PARAM_FONT, BLACK_BRUSH, presv1_rect, BOTTOM_RIGHT)

        'Dim sumP2 As XPoint = presv1P2
        'sumP2.Offset(0, 3)
        'Dim sumP1 As XPoint = sumP2
        'sumP1.Offset(-75, 0)

        'gfx.DrawLine(BLACK_PEN, sumP1, sumP2)

        'Dim presv2P1 As XPoint = presv1_rect.BottomLeft
        'presv2P1.Offset(0, 5)
        'Dim presv2P2 As XPoint = presv2P1
        'presv2P2.Offset(140, 12)
        'Dim presv2_rect As New XRect(presv2P1, presv2P2)

        'If DRAW_ALL_RECTS Then
        '    gfx.DrawRectangle(BLUE_PEN, presv2_rect)
        'End If

        'gfx.DrawString("Total:", PARAM_FONT, BLACK_BRUSH, presv2_rect, CENTER_LEFT)
        'gfx.DrawString(tsp, PARAM_FONT, BLACK_BRUSH, presv2_rect, TOP_RIGHT)

        ''' Temperature
        'Dim tempP1 As XPoint = paramP1
        'tempP1.Offset(215, 24)
        'Dim tempP2 As XPoint = tempP1
        'tempP2.Offset(120, 45)
        'Dim temp_rect As New XRect(tempP1, tempP2)

        'If DRAW_ALL_RECTS Then
        '    gfx.DrawRectangle(BLUE_PEN, temp_rect)
        'End If

        'gfx.DrawString(TEMP_TEXT, PARAM_FONT, BLACK_BRUSH, temp_rect, TOP_CENTER)

        'Dim tempvP1 As XPoint = tempP1
        'tempvP1.Offset(10, 17)
        'Dim tempvP2 As XPoint = tempvP1
        'tempvP2.Offset(100, 25)
        'Dim tempv_rect As New XRect(tempvP1, tempvP2)

        'If DRAW_ALL_RECTS Then
        '    gfx.DrawRectangle(BLUE_PEN, tempv_rect)
        'End If

        'gfx.DrawString("Minimum:", PARAM_FONT, BLACK_BRUSH, tempv_rect, TOP_LEFT)
        'gfx.DrawString(minT, PARAM_FONT, BLACK_BRUSH, tempv_rect, TOP_RIGHT)
        'gfx.DrawString("Maximum:", PARAM_FONT, BLACK_BRUSH, tempv_rect, BOTTOM_LEFT)
        'gfx.DrawString(maxT, PARAM_FONT, BLACK_BRUSH, tempv_rect, BOTTOM_RIGHT)


        '' Elev, flow, effi
        'Dim last3P1 As XPoint = paramP1
        'last3P1.Offset(375, 25)
        'Dim last3P2 As XPoint = last3P1
        'last3P2.Offset(150, 53)
        'Dim last3_rect As New XRect(last3P1, last3P2)

        'If DRAW_ALL_RECTS Then
        '    gfx.DrawRectangle(BLUE_PEN, last3_rect)
        'End If

        ''' Elevation
        'Dim elevP1 As XPoint = last3P1
        'elevP1.Offset(5, 5)
        'Dim elevP2 As XPoint = elevP1
        'elevP2.Offset(140, 12)
        'Dim elev_rect As New XRect(elevP1, elevP2)

        'If DRAW_ALL_RECTS Then
        '    gfx.DrawRectangle(BLUE_PEN, elev_rect)
        'End If

        'gfx.DrawString("Elevation:", PARAM_FONT, BLACK_BRUSH, elev_rect, CENTER_LEFT)
        'gfx.DrawString(elev, PARAM_FONT, BLACK_BRUSH, elev_rect, CENTER_RIGHT)

        ''' Flow
        'Dim flowP1 As XPoint = last3P1
        'flowP1.Offset(5, 20)
        'Dim flowP2 As XPoint = flowP1
        'flowP2.Offset(140, 12)
        'Dim flow_rect As New XRect(flowP1, flowP2)

        'If DRAW_ALL_RECTS Then
        '    gfx.DrawRectangle(BLUE_PEN, flow_rect)
        'End If

        'gfx.DrawString("Flow Rate:", PARAM_FONT, BLACK_BRUSH, flow_rect, CENTER_LEFT)
        'gfx.DrawString(flow, PARAM_FONT, BLACK_BRUSH, flow_rect, CENTER_RIGHT)

        ''' Efficiency
        'Dim effP1 As XPoint = last3P1
        'effP1.Offset(5, 35)
        'Dim effP2 As XPoint = effP1
        'effP2.Offset(140, 12)
        'Dim eff_rect As New XRect(effP1, effP2)

        'If DRAW_ALL_RECTS Then
        '    gfx.DrawRectangle(BLUE_PEN, eff_rect)
        'End If

        'gfx.DrawString("Min. Efficiency:", PARAM_FONT, BLACK_BRUSH, eff_rect, CENTER_LEFT)
        'gfx.DrawString(min_eff, PARAM_FONT, BLACK_BRUSH, eff_rect, CENTER_RIGHT)
    End Function

    Private Function drawParameters(gfx As XGraphics, rect As XRect, input As String(), tsp As String, correctedP As String, correctedF As String)
        Dim isp, dsp, flow, minT, maxT, elev, minE As String
        isp = input(2)
        dsp = input(3)
        flow = input(4)
        minT = input(5)
        maxT = input(6)
        elev = input(7)
        minE = input(8)

        Dim row_height = param_table_row_height
        Dim col1_width = 150
        Dim col2_width = 150
        Dim col3_width = 126
        Dim col4_width = 126

        Dim P, Q As XPoint

        ' Operating Requirements
        P = rect.TopLeft
        Q = offsetPoint(P, col1_width, 4 * row_height)
        Dim reqRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, reqRect)
        gfx.DrawString("Operating Requirements", PARAM_FONT, BLACK_BRUSH, reqRect, CENTER)

        '' Static Pressure
        P = reqRect.TopRight
        Q = offsetPoint(P, col2_width, 3 * row_height)
        Dim presRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, presRect)
        gfx.DrawString("Static Pressure", PARAM_FONT, BLACK_BRUSH, presRect, CENTER)

        ''' Inlet label
        P = presRect.TopRight
        Q = offsetPoint(P, col3_width, row_height)
        Dim ispLblRect As New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, ispLblRect)
        gfx.DrawString("Inlet", PARAM_FONT, BLACK_BRUSH, ispLblRect, CENTER)

        ''' Inlet Pressure
        P = ispLblRect.TopRight
        Q = offsetPoint(P, col4_width, row_height)
        Dim ispRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, ispRect)
        gfx.DrawString(isp, PARAM_FONT, BLACK_BRUSH, ispRect, CENTER)

        ''' Discharge label
        P = ispLblRect.BottomLeft
        Q = offsetPoint(P, col3_width, row_height)
        Dim dspLblRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, dspLblRect)
        gfx.DrawString("Discharge", PARAM_FONT, BLACK_BRUSH, dspLblRect, CENTER)

        ''' Discharge Pressure
        P = dspLblRect.TopRight
        Q = offsetPoint(P, col4_width, row_height)
        Dim dspRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, dspRect)
        gfx.DrawString(dsp, PARAM_FONT, BLACK_BRUSH, dspRect, CENTER)

        ''' Total label
        P = dspLblRect.BottomLeft
        Q = offsetPoint(P, col3_width, row_height)
        Dim tspLblRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, tspLblRect)
        gfx.DrawString("Total", PARAM_FONT, BLACK_BRUSH, tspLblRect, CENTER)

        ''' Total Pressure
        P = tspLblRect.TopRight
        Q = offsetPoint(P, col4_width, row_height)
        Dim tspRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, tspRect)
        gfx.DrawString(tsp, PARAM_FONT, BLACK_BRUSH, tspRect, CENTER)

        '' Flowrate label
        P = presRect.BottomLeft
        Q = offsetPoint(P, col2_width, row_height)
        Dim flowLblRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, flowLblRect)
        gfx.DrawString("Flowrate", PARAM_FONT, BLACK_BRUSH, flowLblRect, CENTER)

        '' Flowrate value
        P = flowLblRect.TopRight
        Q = offsetPoint(P, col3_width + col4_width, row_height)
        Dim flowRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, flowRect)
        gfx.DrawString(flow, PARAM_FONT, BLACK_BRUSH, flowRect, CENTER)

        ' Operating Conditions
        P = reqRect.BottomLeft
        Q = offsetPoint(P, col1_width, 4 * row_height)
        Dim condRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, condRect)
        gfx.DrawString("Operating Conditions", PARAM_FONT, BLACK_BRUSH, condRect, CENTER)

        '' Temperature
        P = condRect.TopRight
        Q = offsetPoint(P, col2_width, 2 * row_height)
        Dim tempRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, tempRect)
        gfx.DrawString("Temperature", PARAM_FONT, BLACK_BRUSH, tempRect, CENTER)

        ''' Min Temp lbl
        P = tempRect.TopRight
        Q = offsetPoint(P, col3_width, row_height)
        Dim minLblRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, minLblRect)
        gfx.DrawString("Miniumum", PARAM_FONT, BLACK_BRUSH, minLblRect, CENTER)

        ''' Min Temp val
        P = minLblRect.TopRight
        Q = offsetPoint(P, col4_width, row_height)
        Dim minRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, minRect)
        gfx.DrawString(minT, PARAM_FONT, BLACK_BRUSH, minRect, CENTER)

        ''' Max Temp lbl
        P = minLblRect.BottomLeft
        Q = offsetPoint(P, col3_width, row_height)
        Dim maxLblRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, maxLblRect)
        gfx.DrawString("Maximum", PARAM_FONT, BLACK_BRUSH, maxLblRect, CENTER)

        ''' Max Temp val
        P = maxLblRect.TopRight
        Q = offsetPoint(P, col4_width, row_height)
        Dim maxRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, maxRect)
        gfx.DrawString(maxT, PARAM_FONT, BLACK_BRUSH, maxRect, CENTER)

        '' Elevation lbl
        P = tempRect.BottomLeft
        Q = offsetPoint(P, col2_width, row_height)
        Dim elevLblRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, elevLblRect)
        gfx.DrawString("Elevation", PARAM_FONT, BLACK_BRUSH, elevLblRect, CENTER)

        '' Elevation val
        P = elevLblRect.TopRight
        Q = offsetPoint(P, col3_width + col4_width, row_height)
        Dim elevRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, elevRect)
        gfx.DrawString(elev, PARAM_FONT, BLACK_BRUSH, elevRect, CENTER)

        '' Min Efficiency lbl
        P = elevLblRect.BottomLeft
        Q = offsetPoint(P, col2_width, row_height)
        Dim effLblRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, effLblRect)
        gfx.DrawString("Min. Efficiency", PARAM_FONT, BLACK_BRUSH, effLblRect, CENTER)

        '' Min Efficiency val
        P = effLblRect.TopRight
        Q = offsetPoint(P, col3_width + col4_width, row_height)
        Dim effRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, effRect)
        gfx.DrawString(minE, PARAM_FONT, BLACK_BRUSH, effRect, CENTER)

        ' Corrected Requirements
        P = condRect.BottomLeft
        Q = offsetPoint(P, col1_width, 2 * row_height)
        Dim corrRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, corrRect)
        gfx.DrawString("Corrected Requirements", PARAM_FONT, BLACK_BRUSH, corrRect, CENTER)

        '' Pressure lbl
        P = corrRect.TopRight
        Q = offsetPoint(P, col2_width, row_height)
        Dim ctspLblRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, ctspLblRect)
        gfx.DrawString("Total Static Pressure", PARAM_FONT, BLACK_BRUSH, ctspLblRect, CENTER)

        '' Pressure val
        P = ctspLblRect.TopRight
        Q = offsetPoint(P, col3_width + col4_width, row_height)
        Dim ctspRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, ctspRect)
        gfx.DrawRectangle(SHADE_BRUSH, ctspRect)
        gfx.DrawString(correctedP, PARAM_FONT, BLACK_BRUSH, ctspRect, CENTER)

        '' Flow lbl
        P = ctspLblRect.BottomLeft
        Q = offsetPoint(P, col2_width, row_height)
        Dim cflowLblRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, cflowLblRect)
        gfx.DrawString("Flowrate", PARAM_FONT, BLACK_BRUSH, cflowLblRect, CENTER)

        '' Flow val
        P = cflowLblRect.TopRight
        Q = offsetPoint(P, col3_width + col4_width, row_height)
        Dim cflowRect = New XRect(P, Q)
        gfx.DrawRectangle(BLACK_PEN, cflowRect)
        gfx.DrawRectangle(SHADE_BRUSH, cflowRect)
        gfx.DrawString(correctedF, PARAM_FONT, BLACK_BRUSH, cflowRect, CENTER)

    End Function

    Private Function drawTable(gfx As XGraphics, p1 As XPoint, rows As List(Of String()), selected_rows As List(Of Integer))
        ' Draw the output table

        Dim HEADER_FONT As New XFont(TYPEFACE, 10)
        Dim CELL_FONT As New XFont(TYPEFACE, 9)


        Dim num_rows As Integer = rows.Count
        Dim table_height As Double = COL_HEADER_HEIGHT + num_rows * ROW_HEIGHT
        Dim p2 As XPoint = p1
        p2.Offset(TABLE_WIDTH, table_height)
        Dim table_rect As New XRect(p1, p2)

        ' Create colum header rectangles
        Dim header_rects(NUM_COLS) As XRect
        Dim col_widths = calcColWidths()
        Dim cur_point As XPoint = p1
        For c As Integer = 0 To NUM_COLS - 1
            Dim q As XPoint = cur_point
            q.Offset(col_widths(c), COL_HEADER_HEIGHT)
            header_rects(c) = New XRect(cur_point, q)
            cur_point.Offset(col_widths(c), 0)
        Next

        ' Create cell rectangles
        Dim cell_rects(NUM_COLS, num_rows) As XRect
        Dim start_point As XPoint = header_rects(0).BottomLeft
        For r As Integer = 0 To num_rows - 1
            cur_point = start_point
            For c As Integer = 0 To NUM_COLS - 1
                Dim q As XPoint = cur_point
                q.Offset(col_widths(c), ROW_HEIGHT)
                cell_rects(c, r) = New XRect(cur_point, q)
                cur_point.Offset(col_widths(c), 0)
            Next
            start_point.Offset(0, ROW_HEIGHT)
        Next

        ' Draw
        '' Boundary rectangle
        gfx.DrawRectangle(BLACK_PEN, table_rect)

        '' Headers and cells
        For c As Integer = 0 To NUM_COLS - 1
            ' Header
            gfx.DrawRectangle(BLACK_PEN, header_rects(c))
            gfx.DrawString(HEADER_STRINGS(c), HEADER_FONT, BLACK_BRUSH, header_rects(c), CENTER)

            ' Cells
            For r As Integer = 0 To num_rows - 1
                If inList(r, selected_rows) Then ' If the row is selected, shade
                    gfx.DrawRectangle(BLACK_PEN, SHADE_BRUSH, cell_rects(c, r))
                Else
                    gfx.DrawRectangle(BLACK_PEN, cell_rects(c, r))
                End If

                gfx.DrawString(rows(r)(c), CELL_FONT, BLACK_BRUSH, cell_rects(c, r), CENTER)
            Next
        Next

    End Function

    Private Function calcColWidths()
        ' Calculate the width of the table columns
        '' Could be done not at run time....but whatever
        Dim sum As Double = 0
        For Each w In COL_WEIGHTS
            sum += w
        Next
        Dim widths(COL_WEIGHTS.Length) As Double
        For c As Integer = 0 To COL_WEIGHTS.Length - 1
            widths(c) = TABLE_WIDTH * COL_WEIGHTS(c) / sum
        Next
        Return widths
    End Function

    Private Function inList(val As Integer, ls As List(Of Integer))
        ' Return true if val is in list
        For Each v In ls
            If val = v Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function offsetPoint(p As XPoint, dx As Double, dy As Double)
        p.Offset(dx, dy)
        Return p
    End Function
End Module
