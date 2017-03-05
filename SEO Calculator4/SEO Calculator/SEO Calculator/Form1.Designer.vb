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
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.GLabel4 = New gLabel.gLabel()
        Me.GLabel3 = New gLabel.gLabel()
        Me.GLabel2 = New gLabel.gLabel()
        Me.GLabel1 = New gLabel.gLabel()
        Me.ComboBox_Search_Engines = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.Button_Search = New CButtonLib.CButton()
        CType(Me.ComboBox_Format, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.ComboBox_Sorting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ComboBox_Search_Engines, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TextBox_Search.Text = "a;b;c;d;e"
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
        Me.KryptonPanel1.Location = New System.Drawing.Point(-2, -5)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(386, 221)
        Me.KryptonPanel1.StateNormal.Color1 = System.Drawing.Color.LightSteelBlue
        Me.KryptonPanel1.StateNormal.Color2 = System.Drawing.Color.Teal
        Me.KryptonPanel1.StateNormal.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed
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
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 199)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(386, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(114, 17)
        Me.ToolStripStatusLabel1.Text = "Calculating 1 of 10..."
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStripProgressBar1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(250, 16)
        Me.ToolStripProgressBar1.Value = 50
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
        Me.Button_Search.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_Search.FillType = CButtonLib.CButton.eFillType.Solid
        Me.Button_Search.FocalPoints.CenterPtX = 0.4710744!
        Me.Button_Search.FocalPoints.CenterPtY = 0.2941177!
        DesignerRectTracker2.IsActive = False
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Button_Search.FocusPtTracker = DesignerRectTracker2
        Me.Button_Search.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Button_Search.ImageIndex = 0
        Me.Button_Search.Location = New System.Drawing.Point(1, 155)
        Me.Button_Search.Name = "Button_Search"
        Me.Button_Search.Size = New System.Drawing.Size(385, 45)
        Me.Button_Search.TabIndex = 2
        Me.Button_Search.Text = "CALCULATE"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(384, 215)
        Me.Controls.Add(Me.KryptonPanel1)
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
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents GLabel5 As gLabel.gLabel
    Friend WithEvents ComboBox_Sorting As ComponentFactory.Krypton.Toolkit.KryptonComboBox

End Class
