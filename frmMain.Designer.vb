<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbElev = New System.Windows.Forms.ComboBox()
        Me.cmbMaxTemp = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtMinTemp = New System.Windows.Forms.TextBox()
        Me.txtElev = New System.Windows.Forms.TextBox()
        Me.txtMaxTemp = New System.Windows.Forms.TextBox()
        Me.cmbMinTemp = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbFlow = New System.Windows.Forms.ComboBox()
        Me.cmbDSP = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtISP = New System.Windows.Forms.TextBox()
        Me.txtFlow = New System.Windows.Forms.TextBox()
        Me.txtDSP = New System.Windows.Forms.TextBox()
        Me.cmbISP = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbStandard = New System.Windows.Forms.RadioButton()
        Me.rbActual = New System.Windows.Forms.RadioButton()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblCorrect = New System.Windows.Forms.Label()
        Me.cbPressure = New System.Windows.Forms.CheckBox()
        Me.cbFlow = New System.Windows.Forms.CheckBox()
        Me.lblCorrectedValuesLabel = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblCorrectedVals = New System.Windows.Forms.Label()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnListFans = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblNoFan = New System.Windows.Forms.Label()
        Me.dgvFans = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnPDF = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        CType(Me.dgvFans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel10, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvFans, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPDF, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(906, 561)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.05605!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.94395!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 304.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel4, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblMessage, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox1, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(900, 77)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(297, 71)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "System Info."
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtID, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txtDesc, 1, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(291, 52)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "System ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtID
        '
        Me.txtID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtID.Location = New System.Drawing.Point(72, 3)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(216, 20)
        Me.txtID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Description:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDesc
        '
        Me.txtDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDesc.Location = New System.Drawing.Point(72, 29)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(216, 20)
        Me.txtDesc.TabIndex = 3
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnOpen, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnSave, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(306, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(74, 71)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(6, 6)
        Me.btnOpen.Margin = New System.Windows.Forms.Padding(6)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(62, 23)
        Me.btnOpen.TabIndex = 0
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(6, 41)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(6)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(62, 24)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(515, 32)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(39, 13)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Label3"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.CBI_Fan.My.Resources.Resources.FanGif
        Me.PictureBox1.Location = New System.Drawing.Point(821, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(76, 71)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 86)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(900, 160)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Design Parameters"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel6, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel9, 0, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(894, 141)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 3
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.33512!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.329753!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.33512!))
        Me.TableLayoutPanel6.Controls.Add(Me.TableLayoutPanel8, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.TableLayoutPanel7, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(888, 95)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 3
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.cmbElev, 2, 2)
        Me.TableLayoutPanel8.Controls.Add(Me.cmbMaxTemp, 2, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Label9, 0, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.Label10, 0, 2)
        Me.TableLayoutPanel8.Controls.Add(Me.txtMinTemp, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.txtElev, 1, 2)
        Me.TableLayoutPanel8.Controls.Add(Me.txtMaxTemp, 1, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.cmbMinTemp, 2, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(461, 3)
        Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 3
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(424, 92)
        Me.TableLayoutPanel8.TabIndex = 2
        '
        'cmbElev
        '
        Me.cmbElev.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbElev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbElev.FormattingEnabled = True
        Me.cmbElev.Location = New System.Drawing.Point(332, 65)
        Me.cmbElev.Name = "cmbElev"
        Me.cmbElev.Size = New System.Drawing.Size(89, 21)
        Me.cmbElev.TabIndex = 8
        '
        'cmbMaxTemp
        '
        Me.cmbMaxTemp.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMaxTemp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMaxTemp.FormattingEnabled = True
        Me.cmbMaxTemp.Location = New System.Drawing.Point(332, 34)
        Me.cmbMaxTemp.Name = "cmbMaxTemp"
        Me.cmbMaxTemp.Size = New System.Drawing.Size(89, 21)
        Me.cmbMaxTemp.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Minimum Operating Temp:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(133, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Maximum Operating Temp:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Plant Elevation:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMinTemp
        '
        Me.txtMinTemp.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMinTemp.CausesValidation = False
        Me.txtMinTemp.Location = New System.Drawing.Point(142, 5)
        Me.txtMinTemp.Name = "txtMinTemp"
        Me.txtMinTemp.Size = New System.Drawing.Size(184, 20)
        Me.txtMinTemp.TabIndex = 3
        '
        'txtElev
        '
        Me.txtElev.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtElev.CausesValidation = False
        Me.txtElev.Location = New System.Drawing.Point(142, 66)
        Me.txtElev.Name = "txtElev"
        Me.txtElev.Size = New System.Drawing.Size(184, 20)
        Me.txtElev.TabIndex = 5
        '
        'txtMaxTemp
        '
        Me.txtMaxTemp.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMaxTemp.CausesValidation = False
        Me.txtMaxTemp.Location = New System.Drawing.Point(142, 35)
        Me.txtMaxTemp.Name = "txtMaxTemp"
        Me.txtMaxTemp.Size = New System.Drawing.Size(184, 20)
        Me.txtMaxTemp.TabIndex = 4
        '
        'cmbMinTemp
        '
        Me.cmbMinTemp.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMinTemp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMinTemp.FormattingEnabled = True
        Me.cmbMinTemp.Location = New System.Drawing.Point(332, 4)
        Me.cmbMinTemp.Name = "cmbMinTemp"
        Me.cmbMinTemp.Size = New System.Drawing.Size(89, 21)
        Me.cmbMinTemp.TabIndex = 6
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 3
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.cmbFlow, 2, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.cmbDSP, 2, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.Label6, 0, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.txtISP, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.txtFlow, 1, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.txtDSP, 1, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.cmbISP, 2, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 3
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(423, 92)
        Me.TableLayoutPanel7.TabIndex = 0
        '
        'cmbFlow
        '
        Me.cmbFlow.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFlow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFlow.FormattingEnabled = True
        Me.cmbFlow.Location = New System.Drawing.Point(331, 65)
        Me.cmbFlow.Name = "cmbFlow"
        Me.cmbFlow.Size = New System.Drawing.Size(89, 21)
        Me.cmbFlow.TabIndex = 8
        '
        'cmbDSP
        '
        Me.cmbDSP.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDSP.FormattingEnabled = True
        Me.cmbDSP.Location = New System.Drawing.Point(331, 34)
        Me.cmbDSP.Name = "cmbDSP"
        Me.cmbDSP.Size = New System.Drawing.Size(89, 21)
        Me.cmbDSP.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Inlet Static Pressure:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Discharge Static Pressure:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Required Flowrate:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtISP
        '
        Me.txtISP.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtISP.CausesValidation = False
        Me.txtISP.Location = New System.Drawing.Point(141, 5)
        Me.txtISP.Name = "txtISP"
        Me.txtISP.Size = New System.Drawing.Size(184, 20)
        Me.txtISP.TabIndex = 3
        '
        'txtFlow
        '
        Me.txtFlow.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFlow.CausesValidation = False
        Me.txtFlow.Location = New System.Drawing.Point(141, 66)
        Me.txtFlow.Name = "txtFlow"
        Me.txtFlow.Size = New System.Drawing.Size(184, 20)
        Me.txtFlow.TabIndex = 5
        '
        'txtDSP
        '
        Me.txtDSP.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDSP.CausesValidation = False
        Me.txtDSP.Location = New System.Drawing.Point(141, 35)
        Me.txtDSP.Name = "txtDSP"
        Me.txtDSP.Size = New System.Drawing.Size(184, 20)
        Me.txtDSP.TabIndex = 4
        '
        'cmbISP
        '
        Me.cmbISP.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbISP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbISP.FormattingEnabled = True
        Me.cmbISP.Location = New System.Drawing.Point(331, 4)
        Me.cmbISP.Name = "cmbISP"
        Me.cmbISP.Size = New System.Drawing.Size(89, 21)
        Me.cmbISP.TabIndex = 6
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 5
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.FlowLayoutPanel2, 1, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.lblCorrectedValuesLabel, 2, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.btnClear, 4, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.lblCorrectedVals, 3, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(3, 104)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(888, 34)
        Me.TableLayoutPanel9.TabIndex = 1
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbStandard)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbActual)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 5)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(226, 26)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Conditions:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rbStandard
        '
        Me.rbStandard.AutoSize = True
        Me.rbStandard.Location = New System.Drawing.Point(68, 3)
        Me.rbStandard.Name = "rbStandard"
        Me.rbStandard.Size = New System.Drawing.Size(68, 17)
        Me.rbStandard.TabIndex = 1
        Me.rbStandard.Text = "Standard"
        Me.rbStandard.UseVisualStyleBackColor = True
        '
        'rbActual
        '
        Me.rbActual.AutoSize = True
        Me.rbActual.Checked = True
        Me.rbActual.Location = New System.Drawing.Point(142, 3)
        Me.rbActual.Name = "rbActual"
        Me.rbActual.Size = New System.Drawing.Size(55, 17)
        Me.rbActual.TabIndex = 2
        Me.rbActual.TabStop = True
        Me.rbActual.Text = "Actual"
        Me.rbActual.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.lblCorrect)
        Me.FlowLayoutPanel2.Controls.Add(Me.cbPressure)
        Me.FlowLayoutPanel2.Controls.Add(Me.cbFlow)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(235, 5)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(226, 26)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'lblCorrect
        '
        Me.lblCorrect.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCorrect.AutoSize = True
        Me.lblCorrect.Location = New System.Drawing.Point(3, 5)
        Me.lblCorrect.Name = "lblCorrect"
        Me.lblCorrect.Size = New System.Drawing.Size(44, 13)
        Me.lblCorrect.TabIndex = 0
        Me.lblCorrect.Text = "Correct:"
        Me.lblCorrect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbPressure
        '
        Me.cbPressure.AutoSize = True
        Me.cbPressure.Checked = True
        Me.cbPressure.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbPressure.Location = New System.Drawing.Point(53, 3)
        Me.cbPressure.Name = "cbPressure"
        Me.cbPressure.Size = New System.Drawing.Size(67, 17)
        Me.cbPressure.TabIndex = 1
        Me.cbPressure.Text = "Pressure"
        Me.cbPressure.UseVisualStyleBackColor = True
        '
        'cbFlow
        '
        Me.cbFlow.AutoSize = True
        Me.cbFlow.Location = New System.Drawing.Point(126, 3)
        Me.cbFlow.Name = "cbFlow"
        Me.cbFlow.Size = New System.Drawing.Size(66, 17)
        Me.cbFlow.TabIndex = 2
        Me.cbFlow.Text = "Flowrate"
        Me.cbFlow.UseVisualStyleBackColor = True
        '
        'lblCorrectedValuesLabel
        '
        Me.lblCorrectedValuesLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCorrectedValuesLabel.AutoSize = True
        Me.lblCorrectedValuesLabel.Location = New System.Drawing.Point(467, 10)
        Me.lblCorrectedValuesLabel.Name = "lblCorrectedValuesLabel"
        Me.lblCorrectedValuesLabel.Size = New System.Drawing.Size(91, 13)
        Me.lblCorrectedValuesLabel.TabIndex = 2
        Me.lblCorrectedValuesLabel.Text = "Corrected Values:"
        Me.lblCorrectedValuesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClear
        '
        Me.btnClear.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClear.Location = New System.Drawing.Point(810, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 28)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'lblCorrectedVals
        '
        Me.lblCorrectedVals.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCorrectedVals.AutoSize = True
        Me.lblCorrectedVals.Location = New System.Drawing.Point(564, 10)
        Me.lblCorrectedVals.Name = "lblCorrectedVals"
        Me.lblCorrectedVals.Size = New System.Drawing.Size(0, 13)
        Me.lblCorrectedVals.TabIndex = 4
        Me.lblCorrectedVals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 5
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.Controls.Add(Me.btnListFans, 0, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.Label7, 1, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.lblNoFan, 4, 0)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(3, 252)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(900, 27)
        Me.TableLayoutPanel10.TabIndex = 2
        '
        'btnListFans
        '
        Me.btnListFans.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnListFans.Location = New System.Drawing.Point(3, 3)
        Me.btnListFans.Name = "btnListFans"
        Me.btnListFans.Size = New System.Drawing.Size(75, 21)
        Me.btnListFans.TabIndex = 0
        Me.btnListFans.Text = "List Fans"
        Me.btnListFans.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(84, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Minimum Efficiency:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNoFan
        '
        Me.lblNoFan.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblNoFan.AutoSize = True
        Me.lblNoFan.Location = New System.Drawing.Point(190, 7)
        Me.lblNoFan.Name = "lblNoFan"
        Me.lblNoFan.Size = New System.Drawing.Size(45, 13)
        Me.lblNoFan.TabIndex = 2
        Me.lblNoFan.Text = "Label11"
        Me.lblNoFan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvFans
        '
        Me.dgvFans.AllowUserToAddRows = False
        Me.dgvFans.AllowUserToDeleteRows = False
        Me.dgvFans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFans.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFans.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFans.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvFans.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFans.Location = New System.Drawing.Point(3, 285)
        Me.dgvFans.Name = "dgvFans"
        Me.dgvFans.Size = New System.Drawing.Size(900, 244)
        Me.dgvFans.TabIndex = 3
        '
        'Column1
        '
        Me.Column1.HeaderText = "Efficiency"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Fan Size"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "RPM"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Max. RPM"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Min. Shaft HP"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Max. Shaft HP"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Motor HP"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "db (5 ft.)"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'btnPDF
        '
        Me.btnPDF.Location = New System.Drawing.Point(3, 535)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(75, 23)
        Me.btnPDF.TabIndex = 4
        Me.btnPDF.Text = "PDF"
        Me.btnPDF.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "CBI Fan Selection"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel10.PerformLayout()
        CType(Me.dgvFans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDesc As TextBox
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents btnOpen As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents lblMessage As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents cmbElev As ComboBox
    Friend WithEvents cmbMaxTemp As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtMinTemp As TextBox
    Friend WithEvents txtElev As TextBox
    Friend WithEvents txtMaxTemp As TextBox
    Friend WithEvents cmbMinTemp As ComboBox
    Friend WithEvents cmbFlow As ComboBox
    Friend WithEvents cmbDSP As ComboBox
    Friend WithEvents txtISP As TextBox
    Friend WithEvents txtFlow As TextBox
    Friend WithEvents txtDSP As TextBox
    Friend WithEvents cmbISP As ComboBox
    Friend WithEvents TableLayoutPanel10 As TableLayoutPanel
    Friend WithEvents btnListFans As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents lblNoFan As Label
    Friend WithEvents dgvFans As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents btnPDF As Button
    Friend WithEvents TableLayoutPanel9 As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents rbStandard As RadioButton
    Friend WithEvents rbActual As RadioButton
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents lblCorrect As Label
    Friend WithEvents cbPressure As CheckBox
    Friend WithEvents cbFlow As CheckBox
    Friend WithEvents btnClear As Button
    Friend WithEvents lblCorrectedVals As Label
    Friend WithEvents lblCorrectedValuesLabel As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
