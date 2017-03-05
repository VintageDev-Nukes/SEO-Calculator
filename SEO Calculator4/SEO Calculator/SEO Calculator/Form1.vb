#Region " Uses "

Imports System.IO ' File.AppendAllText, Path.Combine, Path.GetTempFileName, Path.GetTempPath
Imports System.Text.RegularExpressions ' RegEx.Match

#End Region

Public Class Form1

#Region " Properties "

    ' [PROP] SearchPatterns
    Private ReadOnly Property SearchPatterns As String()
        Get
            Return TextBox_Search.Text.Split(";")
        End Get
    End Property

    ' [PROP] SearchEngine
    Private ReadOnly Property SearchEngine As Integer
        Get
            Return DirectCast(ComboBox_Search_Engines.SelectedIndex, SearchEngines)
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
            Return DirectCast(ComboBox_Sorting.SelectedIndex, Sorting)
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
    ReadOnly Results_File_Html As String = ".\ResultadosHTML-" & 1 & ".html" ' (TEST) Aquí siempre puedes ponerle un Textbox con un FolderBrowser pa poner donde se va a gustdar... :P
    ReadOnly Results_File_Txt As String = ".\ResultadosTXT-" & 1 & ".txt"
    ' ReadOnly Results_File As String = Path.GetTempFileName()
    ReadOnly Palette_Image As String = ".\palette.png" ' Path.Combine(Path.GetTempPath(), "SEO_Palette.png")

    ' Lists:
    Private Bing_Results_List As New List(Of Tuple(Of String, String, Long))
    Private Google_Results_List As New List(Of Tuple(Of String, String, Long))

    ' POST queries:
    ReadOnly Bing_Query As String = "http://www.bing.com/search?q="
    ReadOnly Google_Query As String = "http://www.google.com/search?q="

    ' Regular Expressions:
    ReadOnly Bing_RegEx_Results_A As String = "id=""count"">.+?<"
    ReadOnly Bing_RegEx_Results_B As String = "[\d\.]+"

    ReadOnly Google_RegEx_Results_A As String = "[^#]resultStats.+?<"
    ReadOnly Google_RegEx_Results_B As String = "[\d\,]+"

    ' Rule of three
    Private RuleOf3 As Double
    Private RuleOf3_Lowest As Tuple(Of Long, String)
    Private RuleOf3_Greatest As Tuple(Of Long, String)

    ' RGB Table Rule of three
    Private Red As Integer
    Private Green As Integer

    'Html file Strings:
    ReadOnly HTML_Header As String = _
    "<html><head></head><body><!--- SEO Calculator By Elektro H@cker & IkillNukes -->" & _
     Environment.NewLine & Environment.NewLine

    ReadOnly HTML_BackColor As String = _
     "<body style=""background-color:{0};"">" & _
     Environment.NewLine & Environment.NewLine

    ReadOnly HTML_Search_Engine_Title As String = _
    "<h2>{0} Results:</h2><br>" & _
     Environment.NewLine & Environment.NewLine

    ReadOnly HTML_Result_Format As String = _
    "<b style=""color:#ffffff;"">The search ""{0}"" has obtained <font style=""color: {1} ;""> {2} results.</font></b><br>" & _
     Environment.NewLine & Environment.NewLine

    ReadOnly HTML_Palette_String As String = _
    " <br><span style=""font-family:Arial;font-size:8px;margin-top:-5px;position:relative;padding-right:5px;""> {0} ( {1} )</span><img src=""{2}"" style=""width:54px; height:29px;""><span style=""font-family:Arial;font-size:8px;margin-top:-5px;position:relative;padding-left:5px;"" /> {3} ( {4} )</span> <br>" & _
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

    ' TextBox Search [KeyPress]
    Private Sub TextBox_Search_KeyPress(sender As Object, e As KeyPressEventArgs) _
    Handles TextBox_Search.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Button_Search.PerformClick()
        End If

    End Sub

    ' TextBox Search [TextChanged]
    Private Sub TextBox_Search_TextChanged(sender As Object, e As EventArgs) _
    Handles TextBox_Search.TextChanged

        Button_Search.Enabled = IIf(sender.textlength <> 0, True, False)

    End Sub

    ' Button Search [EnabledChanged]
    Private Sub Button_Search_EnabledChanged(sender As Object, e As EventArgs) _
    Handles Button_Search.EnabledChanged

        sender.ColorFillSolid = IIf(sender.enabled, Color.Black, Color.Gray)
        sender.UpdateDimBlends()

    End Sub

    ' Button_Search [ClickButtonArea]
    Private Sub Button_Search_ClickButtonArea(sender As Object, e As EventArgs) _
    Handles Button_Search.ClickButtonArea

        Generate_Results_Lists(ResultSorting)
        Display_Results(ResultFormat, {Bing_Results_List, Google_Results_List})

    End Sub

#End Region

#Region " Procedures "

    ' Generate Result Lists
    Private Sub Generate_Results_Lists(ByVal Sorting As Sorting)

        Bing_Results_List.Clear()
        Google_Results_List.Clear()

        For Each Pattern In Me.SearchPatterns

            Select Case SearchEngine

                Case Is = SearchEngines.ALL
                    Bing_Results_List.Add(Tuple.Create("BING", Pattern, Get_Bing_Results(Pattern)))
                    Google_Results_List.Add(Tuple.Create("GOOGLE", Pattern, Get_Google_Results(Pattern)))

                Case Is = SearchEngines.BING
                    Bing_Results_List.Add(Tuple.Create("BING", Pattern, Get_Bing_Results(Pattern)))

                Case Is = SearchEngines.GOOGLE
                    Google_Results_List.Add(Tuple.Create("GOOGLE", Pattern, Get_Google_Results(Pattern)))

            End Select

        Next Pattern

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

    ' Number Abbreviation Function
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

#End Region






































    Private Sub Display_Results(ByVal ResultFormatting As ResultFormatting, ByVal Results_List As Array)

        Select Case ResultFormatting

            Case ResultFormatting.HTML ' WebBrowser

                ' Save the palette image to temp directory.
                My.Resources.RGB.Save(Palette_Image)

                ' Write the header title.
                File.WriteAllText(Results_File_Html, HTML_Header)

                ' Write the document back color.
                File.WriteAllText(Results_File_Html, String.Format(HTML_BackColor, ColorTranslator.ToHtml(Color.Black)))

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
                             String.Format(HTML_Search_Engine_Title, List.First.Item1))

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
                                 String.Format(HTML_Result_Format, Result.Item2, RGB_To_HTML(Red, Green, 0), Format_Number(Result.Item3)))

                        Next Result

                        ' Write the minimum and maximum stats.
                        File.AppendAllText(Results_File_Html, _
                             String.Format(HTML_Palette_String, _
                             Number_Abbreviation(RuleOf3_Greatest.Item1, False), _
                             Format_Number(RuleOf3_Greatest.Item1), _
                             "file:///" & Path.Combine(Application.StartupPath, "palette.png"), _
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

End Class