<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim DesignerRectTracker1 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim CBlendItems1 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker2 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Me.ComboBox_Format = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.TextBox_Search = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.GLabel5 = New gLabel.gLabel()
        Me.ComboBox_Sorting = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel_Calculating = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GLabel4 = New gLabel.gLabel()
        Me.GLabel3 = New gLabel.gLabel()
        Me.GLabel2 = New gLabel.gLabel()
        Me.GLabel1 = New gLabel.gLabel()
        Me.ComboBox_Search_Engines = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.Button_Search = New CButtonLib.CButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_Calculator = New System.Windows.Forms.TabPage()
        Me.TabPage_Options = New System.Windows.Forms.TabPage()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.PictureBox_HTML_Forecolor = New System.Windows.Forms.PictureBox()
        Me.PictureBox_HTML_Backcolor = New System.Windows.Forms.PictureBox()
        Me.Label_Separator = New gLabel.gLabel()
        Me.Label_HTML_Forecolor = New gLabel.gLabel()
        Me.Label_HTML_Backcolor = New gLabel.gLabel()
        Me.TextBox_Separator = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        CType(Me.ComboBox_Format, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.ComboBox_Sorting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ComboBox_Search_Engines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_Calculator.SuspendLayout()
        Me.TabPage_Options.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.PictureBox_HTML_Forecolor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_HTML_Backcolor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox_Format
        '
        Me.ComboBox_Format.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboBox_Format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Format.DropDownWidth = 121
        Me.ComboBox_Format.Items.AddRange(New Object() {"Plain Text", "WebBrowser"})
        Me.ComboBox_Format.Location = New System.Drawing.Point(125, 92)
        Me.ComboBox_Format.Name = "ComboBox_Format"
        Me.ComboBox_Format.Size = New System.Drawing.Size(239, 21)
        Me.ComboBox_Format.TabIndex = 0
        Me.ComboBox_Format.Text = "WebBrowser"
        '
        'TextBox_Search
        '
        Me.TextBox_Search.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox_Search.Location = New System.Drawing.Point(125, 39)
        Me.TextBox_Search.Name = "TextBox_Search"
        Me.TextBox_Search.Size = New System.Drawing.Size(239, 20)
        Me.TextBox_Search.TabIndex = 1
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.GLabel5)
        Me.KryptonPanel1.Controls.Add(Me.ComboBox_Sorting)
        Me.KryptonPanel1.Controls.Add(Me.StatusStrip1)
        Me.KryptonPanel1.Controls.Add(Me.GLabel4)
        Me.KryptonPanel1.Controls.Add(Me.GLabel3)
        Me.KryptonPanel1.Controls.Add(Me.GLabel2)
        Me.KryptonPanel1.Controls.Add(Me.GLabel1)
        Me.KryptonPanel1.Controls.Add(Me.ComboBox_Search_Engines)
        Me.KryptonPanel1.Controls.Add(Me.Button_Search)
        Me.KryptonPanel1.Controls.Add(Me.ComboBox_Format)
        Me.KryptonPanel1.Controls.Add(Me.TextBox_Search)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(3, 3)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(386, 222)
        Me.KryptonPanel1.StateNormal.Color1 = System.Drawing.Color.LightSteelBlue
        Me.KryptonPanel1.StateNormal.Color2 = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.KryptonPanel1.StateNormal.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonPanel1.TabIndex = 2
        '
        'GLabel5
        '
        Me.GLabel5.BackColor = System.Drawing.Color.Transparent
        Me.GLabel5.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.GLabel5.ForeColor = System.Drawing.Color.Black
        Me.GLabel5.Glow = 4
        Me.GLabel5.GlowColor = System.Drawing.Color.Cornsilk
        Me.GLabel5.Location = New System.Drawing.Point(18, 119)
        Me.GLabel5.Name = "GLabel5"
        Me.GLabel5.Size = New System.Drawing.Size(99, 21)
        Me.GLabel5.TabIndex = 10
        Me.GLabel5.Text = "Sort results by..."
        Me.GLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox_Sorting
        '
        Me.ComboBox_Sorting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboBox_Sorting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Sorting.DropDownWidth = 121
        Me.ComboBox_Sorting.Items.AddRange(New Object() {"Ascending by search term", "Descending by search term", "Ascending by result count", "Descending by result count"})
        Me.ComboBox_Sorting.Location = New System.Drawing.Point(125, 119)
        Me.ComboBox_Sorting.Name = "ComboBox_Sorting"
        Me.ComboBox_Sorting.Size = New System.Drawing.Size(239, 21)
        Me.ComboBox_Sorting.TabIndex = 9
        Me.ComboBox_Sorting.Text = "Descending by result count"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.ToolStripStatusLabel_Calculating})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 200)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(386, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStripProgressBar1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(200, 16)
        '
        'ToolStripStatusLabel_Calculating
        '
        Me.ToolStripStatusLabel_Calculating.Name = "ToolStripStatusLabel_Calculating"
        Me.ToolStripStatusLabel_Calculating.Size = New System.Drawing.Size(16, 17)
        Me.ToolStripStatusLabel_Calculating.Text = "..."
        '
        'GLabel4
        '
        Me.GLabel4.BackColor = System.Drawing.Color.Transparent
        Me.GLabel4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.GLabel4.ForeColor = System.Drawing.Color.Black
        Me.GLabel4.Glow = 4
        Me.GLabel4.GlowColor = System.Drawing.Color.Cornsilk
        Me.GLabel4.Location = New System.Drawing.Point(21, 38)
        Me.GLabel4.Name = "GLabel4"
        Me.GLabel4.Size = New System.Drawing.Size(96, 21)
        Me.GLabel4.TabIndex = 7
        Me.GLabel4.Text = "Search Terms"
        Me.GLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GLabel3
        '
        Me.GLabel3.BackColor = System.Drawing.Color.Transparent
        Me.GLabel3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.GLabel3.ForeColor = System.Drawing.Color.Black
        Me.GLabel3.Glow = 4
        Me.GLabel3.GlowColor = System.Drawing.Color.Cornsilk
        Me.GLabel3.Location = New System.Drawing.Point(18, 92)
        Me.GLabel3.Name = "GLabel3"
        Me.GLabel3.Size = New System.Drawing.Size(99, 21)
        Me.GLabel3.TabIndex = 6
        Me.GLabel3.Text = "Display results in..."
        Me.GLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GLabel2
        '
        Me.GLabel2.BackColor = System.Drawing.Color.Transparent
        Me.GLabel2.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.GLabel2.ForeColor = System.Drawing.Color.Black
        Me.GLabel2.Glow = 0
        Me.GLabel2.GlowColor = System.Drawing.Color.BurlyWood
        Me.GLabel2.Location = New System.Drawing.Point(125, 15)
        Me.GLabel2.Name = "GLabel2"
        Me.GLabel2.Size = New System.Drawing.Size(239, 21)
        Me.GLabel2.TabIndex = 5
        Me.GLabel2.Text = "Use ; character to delimit multiple search patterns"
        Me.GLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GLabel1
        '
        Me.GLabel1.BackColor = System.Drawing.Color.Transparent
        Me.GLabel1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.GLabel1.ForeColor = System.Drawing.Color.Black
        Me.GLabel1.Glow = 4
        Me.GLabel1.GlowColor = System.Drawing.Color.Cornsilk
        Me.GLabel1.Location = New System.Drawing.Point(19, 65)
        Me.GLabel1.Name = "GLabel1"
        Me.GLabel1.Size = New System.Drawing.Size(98, 21)
        Me.GLabel1.TabIndex = 4
        Me.GLabel1.Text = "Search Engines"
        Me.GLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox_Search_Engines
        '
        Me.ComboBox_Search_Engines.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboBox_Search_Engines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Search_Engines.DropDownWidth = 121
        Me.ComboBox_Search_Engines.Items.AddRange(New Object() {"ALL", "Bing", "Google"})
        Me.ComboBox_Search_Engines.Location = New System.Drawing.Point(125, 65)
        Me.ComboBox_Search_Engines.Name = "ComboBox_Search_Engines"
        Me.ComboBox_Search_Engines.Size = New System.Drawing.Size(239, 21)
        Me.ComboBox_Search_Engines.TabIndex = 3
        Me.ComboBox_Search_Engines.Text = "Google"
        '
        'Button_Search
        '
        Me.Button_Search.BorderColor = System.Drawing.Color.Black
        DesignerRectTracker1.IsActive = False
        DesignerRectTracker1.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker1.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Button_Search.CenterPtTracker = DesignerRectTracker1
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.Black}
        CBlendItems1.iPoint = New Single() {0.0!, 0.5!, 1.0!}
        Me.Button_Search.ColorFillBlend = CBlendItems1
        Me.Button_Search.ColorFillSolid = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button_Search.Corners.All = 0
        Me.Button_Search.Corners.LowerLeft = 0
        Me.Button_Search.Corners.LowerRight = 0
        Me.Button_Search.Corners.UpperLeft = 0
        Me.Button_Search.Corners.UpperRight = 0
        Me.Button_Search.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_Search.Enabled = False
        Me.Button_Search.FillType = CButtonLib.CButton.eFillType.Solid
        Me.Button_Search.FocalPoints.CenterPtX = 0.4710744!
        Me.Button_Search.FocalPoints.CenterPtY = 0.2941177!
        DesignerRectTracker2.IsActive = False
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Button_Search.FocusPtTracker = DesignerRectTracker2
        Me.Button_Search.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Button_Search.ImageIndex = 0
        Me.Button_Search.Location = New System.Drawing.Point(0, 157)
        Me.Button_Search.Name = "Button_Search"
        Me.Button_Search.Size = New System.Drawing.Size(386, 45)
        Me.Button_Search.TabIndex = 2
        Me.Button_Search.Text = "CALCULATE"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage_Calculator)
        Me.TabControl1.Controls.Add(Me.TabPage_Options)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(400, 254)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage_Calculator
        '
        Me.TabPage_Calculator.Controls.Add(Me.KryptonPanel1)
        Me.TabPage_Calculator.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Calculator.Name = "TabPage_Calculator"
        Me.TabPage_Calculator.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Calculator.Size = New System.Drawing.Size(392, 228)
        Me.TabPage_Calculator.TabIndex = 0
        Me.TabPage_Calculator.Text = "Calculator"
        Me.TabPage_Calculator.UseVisualStyleBackColor = True
        '
        'TabPage_Options
        '
        Me.TabPage_Options.Controls.Add(Me.KryptonPanel2)
        Me.TabPage_Options.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Options.Name = "TabPage_Options"
        Me.TabPage_Options.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Options.Size = New System.Drawing.Size(392, 228)
        Me.TabPage_Options.TabIndex = 1
        Me.TabPage_Options.Text = "Options"
        Me.TabPage_Options.UseVisualStyleBackColor = True
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.PictureBox_HTML_Forecolor)
        Me.KryptonPanel2.Controls.Add(Me.PictureBox_HTML_Backcolor)
        Me.KryptonPanel2.Controls.Add(Me.Label_Separator)
        Me.KryptonPanel2.Controls.Add(Me.Label_HTML_Forecolor)
        Me.KryptonPanel2.Controls.Add(Me.Label_HTML_Backcolor)
        Me.KryptonPanel2.Controls.Add(Me.TextBox_Separator)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.Location = New System.Drawing.Point(3, 3)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Size = New System.Drawing.Size(386, 222)
        Me.KryptonPanel2.StateNormal.Color1 = System.Drawing.Color.LightSteelBlue
        Me.KryptonPanel2.StateNormal.Color2 = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.KryptonPanel2.StateNormal.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonPanel2.TabIndex = 3
        '
        'PictureBox_HTML_Forecolor
        '
        Me.PictureBox_HTML_Forecolor.BackColor = System.Drawing.Color.Black
        Me.PictureBox_HTML_Forecolor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox_HTML_Forecolor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox_HTML_Forecolor.Location = New System.Drawing.Point(125, 92)
        Me.PictureBox_HTML_Forecolor.Name = "PictureBox_HTML_Forecolor"
        Me.PictureBox_HTML_Forecolor.Size = New System.Drawing.Size(27, 21)
        Me.PictureBox_HTML_Forecolor.TabIndex = 12
        Me.PictureBox_HTML_Forecolor.TabStop = False
        '
        'PictureBox_HTML_Backcolor
        '
        Me.PictureBox_HTML_Backcolor.BackColor = System.Drawing.Color.Black
        Me.PictureBox_HTML_Backcolor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox_HTML_Backcolor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox_HTML_Backcolor.Location = New System.Drawing.Point(125, 65)
        Me.PictureBox_HTML_Backcolor.Name = "PictureBox_HTML_Backcolor"
        Me.PictureBox_HTML_Backcolor.Size = New System.Drawing.Size(27, 21)
        Me.PictureBox_HTML_Backcolor.TabIndex = 11
        Me.PictureBox_HTML_Backcolor.TabStop = False
        '
        'Label_Separator
        '
        Me.Label_Separator.BackColor = System.Drawing.Color.Transparent
        Me.Label_Separator.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label_Separator.ForeColor = System.Drawing.Color.Black
        Me.Label_Separator.Glow = 4
        Me.Label_Separator.GlowColor = System.Drawing.Color.Cornsilk
        Me.Label_Separator.Location = New System.Drawing.Point(21, 38)
        Me.Label_Separator.Name = "Label_Separator"
        Me.Label_Separator.Size = New System.Drawing.Size(96, 21)
        Me.Label_Separator.TabIndex = 7
        Me.Label_Separator.Text = "Pattern separator"
        Me.Label_Separator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_HTML_Forecolor
        '
        Me.Label_HTML_Forecolor.BackColor = System.Drawing.Color.Transparent
        Me.Label_HTML_Forecolor.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label_HTML_Forecolor.ForeColor = System.Drawing.Color.Black
        Me.Label_HTML_Forecolor.Glow = 4
        Me.Label_HTML_Forecolor.GlowColor = System.Drawing.Color.Cornsilk
        Me.Label_HTML_Forecolor.Location = New System.Drawing.Point(18, 92)
        Me.Label_HTML_Forecolor.Name = "Label_HTML_Forecolor"
        Me.Label_HTML_Forecolor.Size = New System.Drawing.Size(99, 21)
        Me.Label_HTML_Forecolor.TabIndex = 6
        Me.Label_HTML_Forecolor.Text = "HTML Forecolor"
        Me.Label_HTML_Forecolor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_HTML_Backcolor
        '
        Me.Label_HTML_Backcolor.BackColor = System.Drawing.Color.Transparent
        Me.Label_HTML_Backcolor.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label_HTML_Backcolor.ForeColor = System.Drawing.Color.Black
        Me.Label_HTML_Backcolor.Glow = 4
        Me.Label_HTML_Backcolor.GlowColor = System.Drawing.Color.Cornsilk
        Me.Label_HTML_Backcolor.Location = New System.Drawing.Point(19, 65)
        Me.Label_HTML_Backcolor.Name = "Label_HTML_Backcolor"
        Me.Label_HTML_Backcolor.Size = New System.Drawing.Size(98, 21)
        Me.Label_HTML_Backcolor.TabIndex = 4
        Me.Label_HTML_Backcolor.Text = "HTML Backcolor"
        Me.Label_HTML_Backcolor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox_Separator
        '
        Me.TextBox_Separator.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox_Separator.Location = New System.Drawing.Point(125, 39)
        Me.TextBox_Separator.Name = "TextBox_Separator"
        Me.TextBox_Separator.Size = New System.Drawing.Size(27, 20)
        Me.TextBox_Separator.TabIndex = 1
        Me.TextBox_Separator.Text = ";"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(400, 254)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SEO Calculator"
        CType(Me.ComboBox_Format, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.ComboBox_Sorting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ComboBox_Search_Engines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage_Calculator.ResumeLayout(False)
        Me.TabPage_Options.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.PictureBox_HTML_Forecolor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_HTML_Backcolor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox_Format As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents TextBox_Search As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Button_Search As CButtonLib.CButton
    Friend WithEvents GLabel4 As gLabel.gLabel
    Friend WithEvents GLabel3 As gLabel.gLabel
    Friend WithEvents GLabel2 As gLabel.gLabel
    Friend WithEvents GLabel1 As gLabel.gLabel
    Friend WithEvents ComboBox_Search_Engines As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel_Calculating As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents GLabel5 As gLabel.gLabel
    Friend WithEvents ComboBox_Sorting As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_Calculator As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_Options As System.Windows.Forms.TabPage
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Label_Separator As gLabel.gLabel
    Friend WithEvents Label_HTML_Forecolor As gLabel.gLabel
    Friend WithEvents Label_HTML_Backcolor As gLabel.gLabel
    Friend WithEvents TextBox_Separator As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents PictureBox_HTML_Backcolor As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox_HTML_Forecolor As System.Windows.Forms.PictureBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog

End Class
