#Region " Uses "

Imports System.IO ' File.AppendAllText, File.WriteAllText, Path.Combine, Path.GetTempFileName, Path.GetTempPath
Imports System.Text.RegularExpressions ' RegEx.Match

#End Region

Public Class Main

#Region " Properties "

    ' [PROP] SearchPatterns
    Private ReadOnly Property Terms As String()
        Get
            Terms = (TextBox_Terms.Text & Separator).Split(Separator)
            Return Terms.Distinct().ToArray()
        End Get
    End Property

    ' [PROP] SearchEngine
    Private ReadOnly Property SearchEngine As Integer
        Get
            Return DirectCast(ComboBox_Engines.SelectedIndex, SearchEngines)
        End Get
    End Property

    ' [PROP] ResultFormat
    Private ReadOnly Property ResultFormat As Integer
        Get
            Return DirectCast(ComboBox_Format.SelectedIndex, ResultFormatting)
        End Get
    End Property

    ' [PROP] ResultSorting
    Private ReadOnly Property ResultSorting As Integer
        Get
            Return DirectCast(ComboBox_Sort.SelectedIndex, Sorting)
        End Get
    End Property

    ' [PROP] Separator
    Private ReadOnly Property Separator As Char
        Get
            If TextBox_Separator.TextLength <> 0 Then
                Return Convert.ToChar(TextBox_Separator.Text)
            Else
                Return Convert.ToChar(My.Settings.User_Separator)
            End If
        End Get
    End Property

    ' [PROP] HTML_BackColor
    Private ReadOnly Property HTML_BackColor As String
        Get
            Return ColorTranslator.ToHtml(PictureBox_HTML_Backcolor.BackColor)
        End Get
    End Property

    ' [PROP] HTML_ForeColor
    Private ReadOnly Property HTML_ForeColor As String
        Get
            Return ColorTranslator.ToHtml(PictureBox_HTML_Forecolor.BackColor)
        End Get
    End Property

#End Region

#Region " Enumerations "

    ' [ENUM] SearchEngines
    Private Enum SearchEngines As Integer
        ALL = 0
        BING = 1
        GOOGLE = 2
    End Enum

    ' [ENUM] Sorting
    Private Enum Sorting As Integer
        TERM_ASCENDING = 0
        TERM_DESCENDING = 1
        RESULT_ASCENDING = 2
        RESULT_DESCENDING = 3
    End Enum

    ' [ENUM] ResultFormatting
    Private Enum ResultFormatting As Integer
        TXT = 0
        HTML = 1
    End Enum

#End Region

#Region " Variables "

    ' Temporary files:
    ReadOnly Results_File_Html As String = Path.Combine(Path.GetTempPath(), "SEO Calculator.html")
    ReadOnly Results_File_Txt As String = Path.Combine(Path.GetTempPath(), "SEO Calculator.txt")
    ReadOnly Palette_Image As String = Path.Combine(Path.GetTempPath(), "SEO Palette.png")

    ' Lists:
    Private Bing_Results_List As New List(Of Tuple(Of String, String, Long))
    Private Google_Results_List As New List(Of Tuple(Of String, String, Long))

    ' Progress Counter
    Private IndexPattern As Integer = 0

    ' Textbox Terms Hint:
    Private Terms_Hint As String = _
    String.Format("Use ""{0}"" character to separate multiple terms.", My.Settings.User_Separator)

    ' POST queries:
    ReadOnly Bing_Query As String = "http://www.bing.com/search?q="
    ReadOnly Google_Query As String = "http://www.google.com/search?q="

    ' Regular Expressions:
    ReadOnly Bing_RegEx_Results_A As String = "id=""count"">.+?<"
    ReadOnly Bing_RegEx_Results_B As String = "[\d\.]+"

    ReadOnly Google_RegEx_Results_A As String = "[^#]resultStats.+?<"
    ReadOnly Google_RegEx_Results_B As String = "[\d\,]+"

    ' Rule of three
    Private RuleOf3 As Double = 0.0
    Private RuleOf3_Lowest As Tuple(Of Long, String)
    Private RuleOf3_Greatest As Tuple(Of Long, String)

    ' RGB Table Rule of three
    Private Red As Integer = 0
    Private Green As Integer = 0

    'Html file Strings:
    ReadOnly HTML_Header As String = _
    "<html><head></head><body><!--- SEO Calculator By Elektro H@cker & IkillNukes -->" & _
     Environment.NewLine & Environment.NewLine

    ReadOnly HTML_DocumentBackColor As String = _
     "<body style=""background-color:{0};"">" & _
     Environment.NewLine & Environment.NewLine

    ReadOnly HTML_Search_Engine_Title As String = _
    "<h2 style=""color:{0};"">{1} Results:</h2><br>" & _
     Environment.NewLine & Environment.NewLine

    ReadOnly HTML_Result_Format As String = _
    "<b style=""color:{0};"">The search ""{1}"" has obtained <font style=""color: {2} ;""> {3} results.</font></b><br>" & _
     Environment.NewLine & Environment.NewLine

    ReadOnly HTML_Palette_String As String = _
    " <br><span style=""color:{0};font-family:Arial;font-size:12px;margin-top:-12px;position:relative;padding-right:12px;""> {1} ( {2} )</span><img src=""file:///{3}"" style=""width:54px; height:29px;""><span style=""color:{0};font-family:Arial;font-size:12px;margin-top:-12px;position:relative;padding-left:12px;"" /> {4} ( {5} )</span> <br>" & _
     Environment.NewLine & Environment.NewLine

    ReadOnly HTML_End As String = _
    "</body></html>"

    'Txt file Strings:
    ReadOnly TXT_Header As String = _
    ".:: SEO Calculator By Elektro H@cker & IkillNukes ::." & Environment.NewLine & _
    "    =============================================    " & Environment.NewLine & Environment.NewLine

    ReadOnly TXT_Search_Engine_Title As String = _
    "{0} Results:" & _
    Environment.NewLine & Environment.NewLine

    ReadOnly TXT_Result_Format As String = _
    "The search ""{0}"" has obtained {1} results." _
    & Environment.NewLine & Environment.NewLine

    ReadOnly TXT_Palette_String As String = _
    "Maximum: {0} ({1}) ""{2}""" & Environment.NewLine & _
    "Minimum: {3} ({4}) ""{5}""" & Environment.NewLine & _
    Environment.NewLine & Environment.NewLine

#End Region

#Region " EventHandlers "

#Region " Load /Close "

    ' Load
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_User_Settings()
    End Sub

    ' Shown
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TextBox_Terms.Text = Terms_Hint
    End Sub

#End Region

#Region " Calculator TabPage "

    ' TextBox Terms [KeyPress]
    Private Sub TextBox_Terms_KeyPress(sender As Object, e As KeyPressEventArgs) _
    Handles TextBox_Terms.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Button_Calculate.PerformClick()
        End If

    End Sub

    ' TextBox Terms [TextChanged]
    Private Sub TextBox_Terms_TextChanged(sender As Object, e As EventArgs) _
    Handles TextBox_Terms.TextChanged

        Button_Calculate.Enabled = IIf(Terms.Count > 1 AndAlso Not sender.text = Terms_Hint, True, False)

        ToolStripProgressBar1.Maximum = Terms.Count - 1

        ToolStripStatusLabel_Calculating.Text = _
        IIf(Terms.Count > 1 AndAlso Not sender.text = Terms_Hint, _
            String.Format("Ready to search {0} patterns...", (Terms.Count - 1).ToString), _
            String.Empty)

    End Sub

    ' TextBox Terms [ENTER] [LEAVE]
    Private Sub TextBox_Terms_Set_Hint(sender As Object, e As EventArgs) _
    Handles TextBox_Terms.Enter, TextBox_Terms.Leave

        If sender.Text = Terms_Hint Then
            sender.StateCommon.Content.Color1 = Nothing
            sender.text = String.Empty
        ElseIf sender.Text = String.Empty Then
            sender.StateCommon.Content.Color1 = Color.Gray
            sender.text = Terms_Hint
        End If

    End Sub

    ' ComboBox Search Engines [SelectedIndexChanged]
    Private Sub ComboBox_Search_Engines_SelectedIndexChanged(sender As Object, e As EventArgs) _
    Handles ComboBox_Engines.SelectedIndexChanged
        My.Settings.User_Engines = sender.SelectedIndex
    End Sub

    ' ComboBox Format [SelectedIndexChanged]
    Private Sub ComboBox_Format_SelectedIndexChanged(sender As Object, e As EventArgs) _
    Handles ComboBox_Format.SelectedIndexChanged
        My.Settings.User_Results = sender.SelectedIndex
    End Sub

    ' ComboBox Sorting [SelectedIndexChanged]
    Private Sub ComboBox_Sorting_SelectedIndexChanged(sender As Object, e As EventArgs) _
    Handles ComboBox_Sort.SelectedIndexChanged
        My.Settings.User_Sort = sender.SelectedIndex
    End Sub

    ' Button Calculate [EnabledChanged]
    Private Sub Button_Calculate_EnabledChanged(sender As Object, e As EventArgs) _
    Handles Button_Calculate.EnabledChanged

        sender.ColorFillSolid = IIf(sender.enabled, Color.Black, Color.DimGray)
        sender.Text = IIf(sender.enabled, "SEARCH", String.Empty)
        sender.UpdateDimBlends()

    End Sub

    ' Button Calculate [ClickButtonArea]
    Private Sub Button_Calculate_ClickButtonArea(sender As Object, e As EventArgs) _
    Handles Button_Calculate.ClickButtonArea

        ToolStripProgressBar1.Visible = True
        Generate_Results_Lists(ResultSorting)
        Display_Results(ResultFormat, {Bing_Results_List, Google_Results_List})
        IndexPattern = 0
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel_Calculating.Text = "Finished!"
        ToolStripProgressBar1.Visible = False

    End Sub

#End Region

#Region " Options TabPage "

    ' TextBox Separator [Enter]
    Private Sub TextBox_Separator_Enter(sender As Object, e As EventArgs) Handles TextBox_Separator.MouseEnter
        If sender.ContextMenuStrip Is Nothing Then sender.ContextMenuStrip = New ContextMenuStrip
    End Sub

    ' TextBox Separator [KeyPress]
    Private Sub TextBox_Separator_KeyPress(sender As Object, e As KeyPressEventArgs) _
    Handles TextBox_Separator.KeyPress

        If sender.textlength = 0 _
        AndAlso e.KeyChar = Chr(22) Then
            e.Handled = True

        ElseIf sender.SelectionLength = 1 _
        AndAlso Not e.KeyChar = Chr(22) Then
            e.Handled = False

        ElseIf sender.textlength = 1 _
        AndAlso Not e.KeyChar = Convert.ToChar(Keys.Back) Then

            e.Handled = True

        ElseIf sender.textlength = 1 _
        AndAlso e.KeyChar = Convert.ToChar(Keys.Back) Then

            sender.ReadOnly = False

        End If


    End Sub

    ' TextBox Separator [TextChanged]
    Private Sub TextBox_Separator_TextChanged(sender As Object, e As EventArgs) _
    Handles TextBox_Separator.TextChanged

        If sender.textlength <> 0 Then
            My.Settings.User_Separator = Convert.ToChar(sender.text)
            If TextBox_Terms.TextLength = 0 OrElse TextBox_Terms.Text = Terms_Hint Then
                TextBox_Terms.Text = String.Format("Use ""{0}"" character to separate multiple terms.", sender.text)
                Button_Calculate.Enabled = False
                ToolStripStatusLabel_Calculating.Text = String.Empty
            End If

            Terms_Hint = String.Format("Use ""{0}"" character to separate multiple terms.", sender.text)

            Refresh_Textbox_Text(TextBox_Terms)

        End If

    End Sub

    ' TextBox Separator [Leave]
    Private Sub TextBox_Separator_Leave(sender As Object, e As EventArgs) _
    Handles TextBox_Separator.Leave
        If sender.textlength = 0 Then
            sender.text = My.Settings.User_Separator
        End If
    End Sub

    ' PictureBoxes HTML [Click]
    Private Sub PictureBoxes_HTML_Click(sender As Object, e As EventArgs) _
    Handles PictureBox_HTML_Backcolor.Click, _
            PictureBox_HTML_Forecolor.Click

        ColorDialog1.Color = sender.backcolor

        If ColorDialog1.ShowDialog() = DialogResult.OK Then

            sender.BackColor = ColorDialog1.Color

        End If

        Select Case sender.tag
            Case "BackColor" : My.Settings.User_HTML_BackColor = ColorDialog1.Color
            Case "ForeColor" : My.Settings.User_HTML_ForeColor = ColorDialog1.Color
        End Select

    End Sub

#End Region

#Region " StatusStrip "

    ' ToolStripStatusLabel Calculating [TextChanged]
    Private Sub ToolStripStatusLabel_Calculating_TextChanged(sender As Object, e As EventArgs) _
    Handles ToolStripStatusLabel_Calculating.TextChanged

        Me.Refresh()

    End Sub

#End Region

#End Region

#Region " Procedures "

    ' Get URL SourceCode
    Private Function Get_URL_SourceCode(ByVal url As String) As String

        Try
            Return New StreamReader(Net.HttpWebRequest.Create(url).GetResponse().GetResponseStream()).ReadToEnd()
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return Nothing
        End Try

    End Function

    ' RGB To HTML
    Private Function RGB_To_HTML(ByVal R As Int16, ByVal G As Int16, ByVal B As Int16) As String
        Return ColorTranslator.ToHtml(Color.FromArgb(R, G, B))
    End Function

    ' Format Number
    Private Function Format_Number(ByVal Number As Object) As String

        Select Case Number.GetType()
            Case GetType(Int16), GetType(Int32), GetType(Int64)
                Return FormatNumber(Number, TriState.False)
            Case Else
                Return FormatNumber(Number, , TriState.False)
        End Select

    End Function

    ' Number Abbreviation
    Private Function Number_Abbreviation(ByVal Quantity As Object, _
                                        Optional ByVal Rounded As Boolean = True) As String

        Dim Abbreviation As String = String.Empty

        Select Case Quantity.GetType()

            Case GetType(Int16), GetType(Int32), GetType(Int64)
                Quantity = FormatNumber(Quantity, TriState.False)

            Case Else
                Quantity = FormatNumber(Quantity, , TriState.False)

        End Select

        Select Case Quantity.ToString.Count(Function(character As Char) character = Convert.ToChar("."))

            Case 0 : Return Quantity
            Case 1 : Abbreviation = "kilos"
            Case 2 : Abbreviation = "Millions"
            Case 3 : Abbreviation = "Billions"
            Case 4 : Abbreviation = "Trillions"
            Case 5 : Abbreviation = "Quadrillions"
            Case 6 : Abbreviation = "Quintuillions"
            Case 7 : Abbreviation = "Sextillions"
            Case 8 : Abbreviation = "Septillions"
            Case Else
                Return Quantity

        End Select

        Return IIf(Rounded, _
               String.Format("{0} {1}", StrReverse(StrReverse(Quantity).Substring(StrReverse(Quantity).LastIndexOf(".") + 1)), Abbreviation), _
               String.Format("{0} {1}", StrReverse(StrReverse(Quantity).Substring(StrReverse(Quantity).LastIndexOf(".") - 1)), Abbreviation))

    End Function

    ' Get Bing Results
    Private Function Get_Bing_Results(ByVal SearchPattern As String) As Long

        Dim Source As String = Get_URL_SourceCode(String.Format("{0}{1}", Bing_Query, SearchPattern))

        Return CLng(Convert.ToString(Regex.Match( _
                    Convert.ToString(Regex.Match( _
                    Source, Bing_RegEx_Results_A).Groups(0)), _
                    Bing_RegEx_Results_B).Groups(0) _
                    ).Replace(".", ""))

    End Function

    ' Get Google Results
    Private Function Get_Google_Results(ByVal SearchPattern As String) As Long

        Dim Source As String = Get_URL_SourceCode(String.Format("{0}{1}", Google_Query, SearchPattern))

        Return CLng(Convert.ToString(Regex.Match( _
                    Convert.ToString(Regex.Match( _
                    Source, Google_RegEx_Results_A).Groups(0)), _
                    Google_RegEx_Results_B).Groups(0) _
                    ).Replace(",", ""))

    End Function

    ' Generate Result Lists
    Private Sub Generate_Results_Lists(ByVal Sorting As Sorting)

        Bing_Results_List.Clear()
        Google_Results_List.Clear()

        For Each Term As String In Me.Terms

            If Term IsNot String.Empty Then

                Update_ToolStrip_Progress()

                Select Case SearchEngine

                    Case Is = SearchEngines.ALL
                        Bing_Results_List.Add(Tuple.Create("BING", Term, Get_Bing_Results(Term)))
                        Google_Results_List.Add(Tuple.Create("GOOGLE", Term, Get_Google_Results(Term)))

                    Case Is = SearchEngines.BING
                        Bing_Results_List.Add(Tuple.Create("BING", Term, Get_Bing_Results(Term)))

                    Case Is = SearchEngines.GOOGLE
                        Google_Results_List.Add(Tuple.Create("GOOGLE", Term, Get_Google_Results(Term)))

                End Select

            End If
        Next Term

        Select Case Sorting

            Case Sorting.RESULT_ASCENDING
                Bing_Results_List = Bing_Results_List.OrderBy(Function(Tuple) Tuple.Item3).ToList
                Google_Results_List = Google_Results_List.OrderBy(Function(Tuple) Tuple.Item3).ToList

            Case Sorting.RESULT_DESCENDING
                Bing_Results_List = Bing_Results_List.OrderBy(Function(Tuple) Tuple.Item3).Reverse.ToList
                Google_Results_List = Google_Results_List.OrderBy(Function(Tuple) Tuple.Item3).Reverse.ToList

            Case Sorting.TERM_ASCENDING
                Bing_Results_List = Bing_Results_List.OrderBy(Function(Tuple) Tuple.Item2).ToList
                Google_Results_List = Google_Results_List.OrderBy(Function(Tuple) Tuple.Item2).ToList

            Case Sorting.TERM_DESCENDING
                Bing_Results_List = Bing_Results_List.OrderBy(Function(Tuple) Tuple.Item2).Reverse.ToList
                Google_Results_List = Google_Results_List.OrderBy(Function(Tuple) Tuple.Item2).Reverse.ToList

        End Select

    End Sub

    ' Display Results
    Private Sub Display_Results(ByVal ResultFormatting As ResultFormatting, ByVal Results_List As Array)

        Select Case ResultFormatting

            Case ResultFormatting.HTML ' WebBrowser

                ' Save the palette image to temp directory.
                My.Resources.RGB.Save(Palette_Image)

                ' Write the header title.
                File.WriteAllText(Results_File_Html, HTML_Header)

                ' Write the document back color.
                File.WriteAllText(Results_File_Html, String.Format(HTML_DocumentBackColor, HTML_BackColor))

                ' Loop over each list.
                For Each List As List(Of Tuple(Of String, String, Long)) In Results_List

                    If List.Count <> 0 Then

                        ' Get the lowest and greatest result numbers to calculate the rule of 3.
                        RuleOf3_Lowest = _
                        Tuple.Create(List.OrderBy(Function(Tuple) Tuple.Item3).First.Item3, _
                                     List.OrderBy(Function(Tuple) Tuple.Item3).First.Item2)

                        RuleOf3_Greatest = _
                        Tuple.Create(List.OrderBy(Function(Tuple) Tuple.Item3).Last.Item3, _
                                     List.OrderBy(Function(Tuple) Tuple.Item3).Last.Item2)

                        ' Write the Search Engine title.
                        File.AppendAllText(Results_File_Html, _
                             String.Format(HTML_Search_Engine_Title, HTML_ForeColor, List.First.Item1))

                        ' Loop over each result in list.
                        For Each Result As Tuple(Of String, String, Long) In List

                            ' Calculate the rule of 3.
                            RuleOf3 = ((Result.Item3 - RuleOf3_Lowest.Item1) / (RuleOf3_Greatest.Item1 - RuleOf3_Lowest.Item1)) * 100

                            ' Set the result colors.
                            If RuleOf3 > 50 Then
                                Green = 255 - Math.Round(RuleOf3 * 2.55)
                                Red = 255
                            ElseIf RuleOf3 <= 50 Then
                                Red = Math.Round(RuleOf3 * 5.1)
                                Green = 255
                            End If

                            ' Write the search pattern and result quantity.
                            File.AppendAllText(Results_File_Html, _
                                 String.Format(HTML_Result_Format, _
                                 HTML_ForeColor, _
                                 Result.Item2, _
                                 RGB_To_HTML(Red, Green, 0), _
                                 Format_Number(Result.Item3)))

                        Next Result

                        ' Write the minimum and maximum stats.
                        File.AppendAllText(Results_File_Html, _
                             String.Format(HTML_Palette_String, _
                             HTML_ForeColor, _
                             Number_Abbreviation(RuleOf3_Greatest.Item1, False), _
                             Format_Number(RuleOf3_Greatest.Item1), _
                             Palette_Image, _
                             Number_Abbreviation(RuleOf3_Lowest.Item1, False), _
                             Format_Number(RuleOf3_Lowest.Item1)))

                    End If

                Next List

                ' Write the EndOfFile.
                File.AppendAllText(Results_File_Html, HTML_End)

                ' Start the file using Shell Execute.
                Process.Start(Results_File_Html)

            Case ResultFormatting.TXT ' Notepad

                ' Write the header title.
                File.WriteAllText(Results_File_Txt, TXT_Header)

                ' Loop over each list.
                For Each List As List(Of Tuple(Of String, String, Long)) In Results_List

                    If List.Count <> 0 Then

                        ' Write the Search Engine title.
                        File.AppendAllText(Results_File_Txt, _
                             String.Format(TXT_Search_Engine_Title, List.First.Item1))

                        ' Get the lowest and greatest result numbers to calculate the rule of 3.
                        RuleOf3_Lowest = _
                        Tuple.Create(List.OrderBy(Function(Tuple) Tuple.Item3).First.Item3, _
                                     List.OrderBy(Function(Tuple) Tuple.Item3).First.Item2)

                        RuleOf3_Greatest = _
                        Tuple.Create(List.OrderBy(Function(Tuple) Tuple.Item3).Last.Item3, _
                                     List.OrderBy(Function(Tuple) Tuple.Item3).Last.Item2)

                        ' Loop over each result in list.
                        For Each Result As Tuple(Of String, String, Long) In List

                            ' Write the search pattern and result quantity.
                            File.AppendAllText(Results_File_Txt, _
                                 String.Format(TXT_Result_Format, Result.Item2, Format_Number(Result.Item3)))

                        Next Result

                        ' Write the minimum and maximum stats.
                        File.AppendAllText(Results_File_Txt, _
                             String.Format(TXT_Palette_String, _
                             Number_Abbreviation(RuleOf3_Greatest.Item1, False), _
                             Format_Number(RuleOf3_Greatest.Item1), _
                             RuleOf3_Greatest.Item2, _
                             Number_Abbreviation(RuleOf3_Lowest.Item1, False), _
                             Format_Number(RuleOf3_Lowest.Item1), _
                             RuleOf3_Lowest.Item2))

                    End If

                Next List

                ' Start the file using Shell Execute.
                Process.Start(Results_File_Txt)

        End Select

    End Sub

    ' Update ToolStrip Progress
    Private Sub Update_ToolStrip_Progress()

        Threading.Interlocked.Increment(IndexPattern)
        Threading.Interlocked.Increment(ToolStripProgressBar1.Value)

        ToolStripStatusLabel_Calculating.Text = _
        String.Format("Processing {0} of {1} terms...", _
                      IndexPattern.ToString, (Terms.Count - 1).ToString)

    End Sub

    ' Load User Settings
    Private Sub Load_User_Settings()

        ComboBox_Format.SelectedIndex = My.Settings.User_Results
        ComboBox_Engines.SelectedIndex = My.Settings.User_Engines
        ComboBox_Sort.SelectedIndex = My.Settings.User_Sort
        TextBox_Separator.Text = My.Settings.User_Separator
        PictureBox_HTML_Backcolor.BackColor = My.Settings.User_HTML_BackColor
        PictureBox_HTML_Forecolor.BackColor = My.Settings.User_HTML_ForeColor

    End Sub

    ' Refresh Textbox Text
    Private Sub Refresh_Textbox_Text(ByVal TextBox As Object)
        Dim TempText As String = TextBox.Text
        TextBox.Clear()
        TextBox.Text = TempText
    End Sub

#End Region

End Class