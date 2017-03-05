<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Dim CBlendItems1 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker2 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Me.ComboBox_Format = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.TextBox_Terms = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.Panel_Calculator = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Label_Sort = New gLabel.gLabel()
        Me.ComboBox_Sort = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel_Calculating = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label_Terms_Title = New gLabel.gLabel()
        Me.Label_Format = New gLabel.gLabel()
        Me.Label_Engines_Title = New gLabel.gLabel()
        Me.ComboBox_Engines = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.Button_Calculate = New CButtonLib.CButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_Calculator = New System.Windows.Forms.TabPage()
        Me.TabPage_Options = New System.Windows.Forms.TabPage()
        Me.Panel_Options = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.PictureBox_HTML_Forecolor = New System.Windows.Forms.PictureBox()
        Me.PictureBox_HTML_Backcolor = New System.Windows.Forms.PictureBox()
        Me.Label_Separator = New gLabel.gLabel()
        Me.Label_HTML_Forecolor = New gLabel.gLabel()
        Me.Label_HTML_Backcolor = New gLabel.gLabel()
        Me.TextBox_Separator = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        CType(Me.ComboBox_Format, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_Calculator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Calculator.SuspendLayout()
        CType(Me.ComboBox_Sort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ComboBox_Engines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_Calculator.SuspendLayout()
        Me.TabPage_Options.SuspendLayout()
        CType(Me.Panel_Options, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Options.SuspendLayout()
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
        Me.ComboBox_Format.Location = New System.Drawing.Point(120, 69)
        Me.ComboBox_Format.Name = "ComboBox_Format"
        Me.ComboBox_Format.Size = New System.Drawing.Size(239, 21)
        Me.ComboBox_Format.TabIndex = 3
        '
        'TextBox_Terms
        '
        Me.TextBox_Terms.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox_Terms.Location = New System.Drawing.Point(120, 16)
        Me.TextBox_Terms.Name = "TextBox_Terms"
        Me.TextBox_Terms.Size = New System.Drawing.Size(239, 20)
        Me.TextBox_Terms.StateCommon.Content.Color1 = System.Drawing.Color.Gray
        Me.TextBox_Terms.TabIndex = 6
        '
        'Panel_Calculator
        '
        Me.Panel_Calculator.Controls.Add(Me.Label_Sort)
        Me.Panel_Calculator.Controls.Add(Me.ComboBox_Sort)
        Me.Panel_Calculator.Controls.Add(Me.StatusStrip1)
        Me.Panel_Calculator.Controls.Add(Me.Label_Terms_Title)
        Me.Panel_Calculator.Controls.Add(Me.Label_Format)
        Me.Panel_Calculator.Controls.Add(Me.Label_Engines_Title)
        Me.Panel_Calculator.Controls.Add(Me.ComboBox_Engines)
        Me.Panel_Calculator.Controls.Add(Me.Button_Calculate)
        Me.Panel_Calculator.Controls.Add(Me.ComboBox_Format)
        Me.Panel_Calculator.Controls.Add(Me.TextBox_Terms)
        Me.Panel_Calculator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Calculator.Location = New System.Drawing.Point(3, 3)
        Me.Panel_Calculator.Name = "Panel_Calculator"
        Me.Panel_Calculator.Size = New System.Drawing.Size(374, 197)
        Me.Panel_Calculator.StateNormal.Color1 = System.Drawing.Color.LightSteelBlue
        Me.Panel_Calculator.StateNormal.Color2 = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel_Calculator.StateNormal.ColorAngle = 90.0!
        Me.Panel_Calculator.StateNormal.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed
        Me.Panel_Calculator.TabIndex = 0
        '
        'Label_Sort
        '
        Me.Label_Sort.BackColor = System.Drawing.Color.Transparent
        Me.Label_Sort.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label_Sort.ForeColor = System.Drawing.Color.Black
        Me.Label_Sort.Glow = 2
        Me.Label_Sort.GlowColor = System.Drawing.Color.Cornsilk
        Me.Label_Sort.Location = New System.Drawing.Point(15, 96)
        Me.Label_Sort.Name = "Label_Sort"
        Me.Label_Sort.Size = New System.Drawing.Size(99, 21)
        Me.Label_Sort.TabIndex = 4
        Me.Label_Sort.Text = "Sort results by..."
        Me.Label_Sort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox_Sort
        '
        Me.ComboBox_Sort.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboBox_Sort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Sort.DropDownWidth = 121
        Me.ComboBox_Sort.Items.AddRange(New Object() {"Ascending by search term", "Descending by search term", "Ascending by result count", "Descending by result count"})
        Me.ComboBox_Sort.Location = New System.Drawing.Point(120, 96)
        Me.ComboBox_Sort.Name = "ComboBox_Sort"
        Me.ComboBox_Sort.Size = New System.Drawing.Size(239, 21)
        Me.ComboBox_Sort.TabIndex = 5
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.ToolStripStatusLabel_Calculating})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 176)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(377, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStripProgressBar1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(190, 16)
        Me.ToolStripProgressBar1.Visible = False
        '
        'ToolStripStatusLabel_Calculating
        '
        Me.ToolStripStatusLabel_Calculating.Name = "ToolStripStatusLabel_Calculating"
        Me.ToolStripStatusLabel_Calculating.Size = New System.Drawing.Size(16, 17)
        Me.ToolStripStatusLabel_Calculating.Text = "..."
        '
        'Label_Terms_Title
        '
        Me.Label_Terms_Title.BackColor = System.Drawing.Color.Transparent
        Me.Label_Terms_Title.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label_Terms_Title.ForeColor = System.Drawing.Color.Black
        Me.Label_Terms_Title.Glow = 2
        Me.Label_Terms_Title.GlowColor = System.Drawing.Color.Cornsilk
        Me.Label_Terms_Title.Location = New System.Drawing.Point(15, 15)
        Me.Label_Terms_Title.Name = "Label_Terms_Title"
        Me.Label_Terms_Title.Size = New System.Drawing.Size(99, 21)
        Me.Label_Terms_Title.TabIndex = 9
        Me.Label_Terms_Title.Text = "Search Terms"
        Me.Label_Terms_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_Format
        '
        Me.Label_Format.BackColor = System.Drawing.Color.Transparent
        Me.Label_Format.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label_Format.ForeColor = System.Drawing.Color.Black
        Me.Label_Format.Glow = 2
        Me.Label_Format.GlowColor = System.Drawing.Color.Cornsilk
        Me.Label_Format.Location = New System.Drawing.Point(15, 69)
        Me.Label_Format.Name = "Label_Format"
        Me.Label_Format.Size = New System.Drawing.Size(99, 21)
        Me.Label_Format.TabIndex = 2
        Me.Label_Format.Text = "Display results in..."
        Me.Label_Format.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_Engines_Title
        '
        Me.Label_Engines_Title.BackColor = System.Drawing.Color.Transparent
        Me.Label_Engines_Title.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label_Engines_Title.ForeColor = System.Drawing.Color.Black
        Me.Label_Engines_Title.Glow = 2
        Me.Label_Engines_Title.GlowColor = System.Drawing.Color.Cornsilk
        Me.Label_Engines_Title.Location = New System.Drawing.Point(15, 42)
        Me.Label_Engines_Title.Name = "Label_Engines_Title"
        Me.Label_Engines_Title.Size = New System.Drawing.Size(99, 21)
        Me.Label_Engines_Title.TabIndex = 0
        Me.Label_Engines_Title.Text = "Search Engines"
        Me.Label_Engines_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox_Engines
        '
        Me.ComboBox_Engines.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboBox_Engines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Engines.DropDownWidth = 121
        Me.ComboBox_Engines.Items.AddRange(New Object() {"ALL", "Bing", "Google"})
        Me.ComboBox_Engines.Location = New System.Drawing.Point(120, 42)
        Me.ComboBox_Engines.Name = "ComboBox_Engines"
        Me.ComboBox_Engines.Size = New System.Drawing.Size(239, 21)
        Me.ComboBox_Engines.TabIndex = 1
        '
        'Button_Calculate
        '
        Me.Button_Calculate.BorderColor = System.Drawing.Color.Black
        DesignerRectTracker1.IsActive = False
        DesignerRectTracker1.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker1.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Button_Calculate.CenterPtTracker = DesignerRectTracker1
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.Black}
        CBlendItems1.iPoint = New Single() {0.0!, 0.5!, 1.0!}
        Me.Button_Calculate.ColorFillBlend = CBlendItems1
        Me.Button_Calculate.ColorFillSolid = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button_Calculate.Corners.All = 0
        Me.Button_Calculate.Corners.LowerLeft = 0
        Me.Button_Calculate.Corners.LowerRight = 0
        Me.Button_Calculate.Corners.UpperLeft = 0
        Me.Button_Calculate.Corners.UpperRight = 0
        Me.Button_Calculate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_Calculate.Enabled = False
        Me.Button_Calculate.FillType = CButtonLib.CButton.eFillType.Solid
        Me.Button_Calculate.FocalPoints.CenterPtX = 0.4710744!
        Me.Button_Calculate.FocalPoints.CenterPtY = 0.2941177!
        DesignerRectTracker2.IsActive = False
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Button_Calculate.FocusPtTracker = DesignerRectTracker2
        Me.Button_Calculate.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Button_Calculate.ImageIndex = 0
        Me.Button_Calculate.Location = New System.Drawing.Point(-3, 131)
        Me.Button_Calculate.Name = "Button_Calculate"
        Me.Button_Calculate.Size = New System.Drawing.Size(377, 45)
        Me.Button_Calculate.TabIndex = 8
        Me.Button_Calculate.Text = ""
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage_Calculator)
        Me.TabControl1.Controls.Add(Me.TabPage_Options)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(388, 229)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage_Calculator
        '
        Me.TabPage_Calculator.Controls.Add(Me.Panel_Calculator)
        Me.TabPage_Calculator.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Calculator.Name = "TabPage_Calculator"
        Me.TabPage_Calculator.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Calculator.Size = New System.Drawing.Size(380, 203)
        Me.TabPage_Calculator.TabIndex = 0
        Me.TabPage_Calculator.Text = "Calculator"
        Me.TabPage_Calculator.UseVisualStyleBackColor = True
        '
        'TabPage_Options
        '
        Me.TabPage_Options.Controls.Add(Me.Panel_Options)
        Me.TabPage_Options.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Options.Name = "TabPage_Options"
        Me.TabPage_Options.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Options.Size = New System.Drawing.Size(380, 203)
        Me.TabPage_Options.TabIndex = 1
        Me.TabPage_Options.Text = "Options"
        Me.TabPage_Options.UseVisualStyleBackColor = True
        '
        'Panel_Options
        '
        Me.Panel_Options.Controls.Add(Me.PictureBox_HTML_Forecolor)
        Me.Panel_Options.Controls.Add(Me.PictureBox_HTML_Backcolor)
        Me.Panel_Options.Controls.Add(Me.Label_Separator)
        Me.Panel_Options.Controls.Add(Me.Label_HTML_Forecolor)
        Me.Panel_Options.Controls.Add(Me.Label_HTML_Backcolor)
        Me.Panel_Options.Controls.Add(Me.TextBox_Separator)
        Me.Panel_Options.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Options.Location = New System.Drawing.Point(3, 3)
        Me.Panel_Options.Name = "Panel_Options"
        Me.Panel_Options.Size = New System.Drawing.Size(374, 197)
        Me.Panel_Options.StateNormal.Color1 = System.Drawing.Color.LightSteelBlue
        Me.Panel_Options.StateNormal.Color2 = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel_Options.StateNormal.ColorAngle = 90.0!
        Me.Panel_Options.StateNormal.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed
        Me.Panel_Options.TabIndex = 3
        '
        'PictureBox_HTML_Forecolor
        '
        Me.PictureBox_HTML_Forecolor.BackColor = System.Drawing.Color.Black
        Me.PictureBox_HTML_Forecolor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox_HTML_Forecolor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox_HTML_Forecolor.Location = New System.Drawing.Point(120, 69)
        Me.PictureBox_HTML_Forecolor.Name = "PictureBox_HTML_Forecolor"
        Me.PictureBox_HTML_Forecolor.Size = New System.Drawing.Size(27, 21)
        Me.PictureBox_HTML_Forecolor.TabIndex = 12
        Me.PictureBox_HTML_Forecolor.TabStop = False
        Me.PictureBox_HTML_Forecolor.Tag = "ForeColor"
        '
        'PictureBox_HTML_Backcolor
        '
        Me.PictureBox_HTML_Backcolor.BackColor = System.Drawing.Color.Black
        Me.PictureBox_HTML_Backcolor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox_HTML_Backcolor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox_HTML_Backcolor.Location = New System.Drawing.Point(120, 42)
        Me.PictureBox_HTML_Backcolor.Name = "PictureBox_HTML_Backcolor"
        Me.PictureBox_HTML_Backcolor.Size = New System.Drawing.Size(27, 21)
        Me.PictureBox_HTML_Backcolor.TabIndex = 11
        Me.PictureBox_HTML_Backcolor.TabStop = False
        Me.PictureBox_HTML_Backcolor.Tag = "BackColor"
        '
        'Label_Separator
        '
        Me.Label_Separator.BackColor = System.Drawing.Color.Transparent
        Me.Label_Separator.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label_Separator.ForeColor = System.Drawing.Color.Black
        Me.Label_Separator.Glow = 2
        Me.Label_Separator.GlowColor = System.Drawing.Color.Cornsilk
        Me.Label_Separator.Location = New System.Drawing.Point(15, 15)
        Me.Label_Separator.Name = "Label_Separator"
        Me.Label_Separator.Size = New System.Drawing.Size(99, 21)
        Me.Label_Separator.TabIndex = 7
        Me.Label_Separator.Text = "Pattern separator"
        Me.Label_Separator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_HTML_Forecolor
        '
        Me.Label_HTML_Forecolor.BackColor = System.Drawing.Color.Transparent
        Me.Label_HTML_Forecolor.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label_HTML_Forecolor.ForeColor = System.Drawing.Color.Black
        Me.Label_HTML_Forecolor.Glow = 2
        Me.Label_HTML_Forecolor.GlowColor = System.Drawing.Color.Cornsilk
        Me.Label_HTML_Forecolor.Location = New System.Drawing.Point(15, 69)
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
        Me.Label_HTML_Backcolor.Glow = 2
        Me.Label_HTML_Backcolor.GlowColor = System.Drawing.Color.Cornsilk
        Me.Label_HTML_Backcolor.Location = New System.Drawing.Point(15, 42)
        Me.Label_HTML_Backcolor.Name = "Label_HTML_Backcolor"
        Me.Label_HTML_Backcolor.Size = New System.Drawing.Size(99, 21)
        Me.Label_HTML_Backcolor.TabIndex = 4
        Me.Label_HTML_Backcolor.Text = "HTML Backcolor"
        Me.Label_HTML_Backcolor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox_Separator
        '
        Me.TextBox_Separator.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox_Separator.Location = New System.Drawing.Point(120, 16)
        Me.TextBox_Separator.Name = "TextBox_Separator"
        Me.TextBox_Separator.Size = New System.Drawing.Size(27, 20)
        Me.TextBox_Separator.TabIndex = 1
        Me.TextBox_Separator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(388, 229)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SEO Calculator"
        CType(Me.ComboBox_Format, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_Calculator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Calculator.ResumeLayout(False)
        Me.Panel_Calculator.PerformLayout()
        CType(Me.ComboBox_Sort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ComboBox_Engines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage_Calculator.ResumeLayout(False)
        Me.TabPage_Options.ResumeLayout(False)
        CType(Me.Panel_Options, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Options.ResumeLayout(False)
        Me.Panel_Options.PerformLayout()
        CType(Me.PictureBox_HTML_Forecolor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_HTML_Backcolor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox_Format As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents TextBox_Terms As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents Panel_Calculator As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Button_Calculate As CButtonLib.CButton
    Friend WithEvents Label_Terms_Title As gLabel.gLabel
    Friend WithEvents Label_Format As gLabel.gLabel
    Friend WithEvents Label_Engines_Title As gLabel.gLabel
    Friend WithEvents ComboBox_Engines As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel_Calculating As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label_Sort As gLabel.gLabel
    Friend WithEvents ComboBox_Sort As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_Calculator As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_Options As System.Windows.Forms.TabPage
    Friend WithEvents Panel_Options As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Label_Separator As gLabel.gLabel
    Friend WithEvents Label_HTML_Forecolor As gLabel.gLabel
    Friend WithEvents Label_HTML_Backcolor As gLabel.gLabel
    Friend WithEvents TextBox_Separator As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents PictureBox_HTML_Backcolor As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox_HTML_Forecolor As System.Windows.Forms.PictureBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog

End Class
