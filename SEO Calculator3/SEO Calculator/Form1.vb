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
        TEXT = 0
        HTML = 1
    End Enum

#End Region

#Region " Variables "

    ' Temporary files:
    ReadOnly Results_File_Html As String = ".\ResultadosHTML-" & DateTime_To_Unix(Date.Now) & ".html" ' (TEST) Aquí siempre puedes ponerle un Textbox con un FolderBrowser pa poner donde se va a gustdar... :P
    ReadOnly Results_File_Txt As String = ".\ResultadosTXT-" & DateTime_To_Unix(Date.Now) & ".txt"
    ' ReadOnly Results_File As String = Path.GetTempFileName()
    ReadOnly Palette_Image As String = Path.Combine(Path.GetTempPath(), "SEO_Palette.png")

    ' Lists:
    Private Bing_Results_List As New List(Of Tuple(Of String, Long))
    Private Google_Results_List As New List(Of Tuple(Of String, Long))

    ' POST queries:
    ReadOnly Bing_Query As String = "http://www.bing.com/search?q="
    ReadOnly Google_Query As String = "http://www.google.com/search?q="

    ' Regular Expressions:
    ReadOnly Bing_RegEx_Results_A As String = "id=""count"">.+?<"
    ReadOnly Bing_RegEx_Results_B As String = "[\d\.]+"

    ReadOnly Google_RegEx_Results_A As String = "[^#]resultStats.+?<"
    ReadOnly Google_RegEx_Results_B As String = "[\d\,]+"

    'Programa con el que se va abrir el Html
    Dim App_Html As String = "C:\Program Files (x86)\Mozilla Firefox\firefox.exe" 'Aquí siempre puedes meter un ComboBox y que browsee los navegadores... Lo haría yo, pero no quiero joder el diseño tan chulo que tienes... :P
    Dim App_Text As String = "C:\Windows\System32\notepad.exe"

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
        Display_Results(ResultFormat)

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
                    Bing_Results_List.Add(Tuple.Create(Pattern, Get_Bing_Results(Pattern)))
                    Google_Results_List.Add(Tuple.Create(Pattern, Get_Google_Results(Pattern)))

                Case Is = SearchEngines.BING
                    Bing_Results_List.Add(Tuple.Create(Pattern, Get_Bing_Results(Pattern)))

                Case Is = SearchEngines.GOOGLE
                    Google_Results_List.Add(Tuple.Create(Pattern, Get_Google_Results(Pattern)))

            End Select

        Next Pattern

        Select Case Sorting

            Case Sorting.RESULT_ASCENDING
                If Bing_Results_List.Count <> 0 Then _
                   Bing_Results_List = Bing_Results_List.OrderBy(Function(Tuple) Tuple.Item2).ToList

                If Google_Results_List.Count <> 0 Then _
                   Google_Results_List = Google_Results_List.OrderBy(Function(Tuple) Tuple.Item2).ToList

            Case Sorting.RESULT_DESCENDING
                If Bing_Results_List.Count <> 0 Then _
                   Bing_Results_List = Bing_Results_List.OrderBy(Function(Tuple) Tuple.Item2).Reverse.ToList

                If Google_Results_List.Count <> 0 Then _
                   Google_Results_List = Google_Results_List.OrderBy(Function(Tuple) Tuple.Item2).Reverse.ToList

            Case Sorting.TERM_ASCENDING
                If Bing_Results_List.Count <> 0 Then _
                   Bing_Results_List = Bing_Results_List.OrderBy(Function(Tuple) Tuple.Item1).ToList

                If Google_Results_List.Count <> 0 Then _
                   Google_Results_List = Google_Results_List.OrderBy(Function(Tuple) Tuple.Item1).ToList

            Case Sorting.TERM_DESCENDING
                If Bing_Results_List.Count <> 0 Then _
                   Bing_Results_List = Bing_Results_List.OrderBy(Function(Tuple) Tuple.Item1).Reverse.ToList

                If Google_Results_List.Count <> 0 Then _
                   Google_Results_List = Google_Results_List.OrderBy(Function(Tuple) Tuple.Item1).Reverse.ToList

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

    'Tu UnixTime
    Public Function DateTime_To_Unix(ByVal DateTime As DateTime) As Long
        Return DateDiff(DateInterval.Second, #1/1/1970#, DateTime)
    End Function

    Private Function Money_Abbreviation(ByVal Number As Object, _
                                    Optional ByVal Rounded As Boolean = True, _
                                    Optional ByVal OddSpeaking As Boolean = False) As String

        Dim Abbreviation As String = String.Empty

        Select Case Number.GetType()

            Case GetType(Int16), GetType(Int32), GetType(Int64)
                Number = FormatNumber(Number, TriState.False)

            Case Else
                Number = FormatNumber(Number, , TriState.False)

        End Select

        Select Case Number.ToString.Count(Function(character As Char) character = Convert.ToChar("."))

            Case 1 : Abbreviation = "k"
            Case 2 : Abbreviation = IIf(OddSpeaking, "KK", "M")
            Case 3 : Abbreviation = IIf(OddSpeaking, "KKK", "B")
            Case 4 : Abbreviation = IIf(OddSpeaking, "KKKK", "Tr")
                'Case 5 : Abbreviation = "Q"
                'Case 6 : Abbreviation = "Q"
                ' Case 7 : Abbreviation = "Q"
                'Case 8 : Abbreviation = "Q"

        End Select

        Return IIf(Rounded, _
               String.Format("{0} {1}", StrReverse(StrReverse(Number).Substring(StrReverse(Number).LastIndexOf(".") + 1)), Abbreviation), _
               String.Format("{0} {1}", StrReverse(StrReverse(Number).Substring(StrReverse(Number).LastIndexOf(".") - 1)), Abbreviation))

    End Function

#End Region

    Dim RuleOf3_Lowest As Long
    Dim RuleOf3_Greatest As Long
    Dim Final_String_Big As String
    Dim Final_String_Small As String
    Dim RuleOf3 As Double
    Dim red As Integer
    Dim green As Integer


    'Html:
    ReadOnly Results_File_Header As String = _
    "<html><head></head><body><!--- Algo de Body por aquí :D -->{0}"

    ReadOnly Results_File_Search_Engine_Title As String = _
    "<h2>Resultados de {0}:</h2><br>{1}"

    ReadOnly Results_File_Result_Format As String = _
    "<b>La b&uacute;squeda: "" {0} "", ha obtenido <font style=""color: {1} ;"">aproxim&aacute;damente {2} resultados.</font></b><br> {3}"

    ReadOnly Results_File_Palette_String As String = _
    " <br><span style=""font-family:Arial;font-size:8px;margin-top:-5px;position:relative;padding-right:5px;""> {0} ( {1} )</span><img src=""{2}"" style=""width:54px; height:29px;""><span style=""font-family:Arial;font-size:8px;margin-top:-5px;position:relative;padding-left:5px;"" /> {3} ( {4} )</span> <br> {5}"

    ReadOnly Results_File_End As String = _
    "</body></html>"

    'Texto:
    ReadOnly Results_File_Search_Engine_Title_Text As String = _
    "Resultados de {0}:" & Environment.NewLine & "{1}" & Environment.NewLine & Environment.NewLine

    ReadOnly Results_File_Result_Format_Text As String = _
    "La búsqueda: "" {0} "", ha obtenido aproximádamente {1} resultados. {2}" & Environment.NewLine

    ReadOnly Results_File_Palette_String_Text As String = _
    "Máximo: {0} ({1})" & Environment.NewLine & "Mínimo: {2} ({3})" & Environment.NewLine '& "Media total: {4} ({5})" ' La media te la dejo a ti, si la quieres hacer y si no, que le den xD



    Private Sub Display_Results(ByVal ResultFormatting As ResultFormatting)

        Dim Navegador As String
        Dim NavList As List(Of Tuple(Of String, Long))
        Dim SplitTxt As String

        Select Case True

            Case SearchEngine = SearchEngines.GOOGLE Or SearchEngine = SearchEngines.BING

                If SearchEngine = SearchEngines.GOOGLE Then
                    Navegador = "Google"
                    NavList = Google_Results_List
                    SplitTxt = "====================="
                End If

                If SearchEngine = SearchEngines.BING Then
                    Navegador = "Bing"
                    NavList = Bing_Results_List
                    SplitTxt = "==================="
                End If

                Select Case ResultFormatting

                    Case ResultFormatting.HTML ' WebBrowser

                        My.Resources.RGB.Save(Palette_Image) ' Save the palette image to temp directory.

                        ' Get the lowest and greatest result numbers to calculate the rule of three
                        RuleOf3_Lowest = NavList.OrderBy(Function(Tuple) Tuple.Item2).ToList().First.Item2
                        RuleOf3_Greatest = NavList.OrderBy(Function(Tuple) Tuple.Item2).ToList().Last.Item2

                        ' (TEST PURPOSSES) Display the Rule of three variables
                        'MsgBox(RuleOf3_Lowest)
                        'MsgBox(RuleOf3_Greatest)

                        ' Write the header into the file
                        File.WriteAllText(Results_File_Html, String.Format(Results_File_Header, Environment.NewLine & Environment.NewLine))

                        ' Append the Search Engine Title into the file
                        File.AppendAllText(Results_File_Html, _
                             String.Format(Results_File_Search_Engine_Title, Navegador, _
                                           Environment.NewLine & Environment.NewLine))

                        For Each Result As Tuple(Of String, Long) In NavList

                            RuleOf3 = ((Result.Item2 - RuleOf3_Lowest) / (RuleOf3_Greatest - RuleOf3_Lowest)) * 100

                            Select Case True

                                Case RuleOf3 > 50 : green = 255 - Math.Round(RuleOf3 * 2.55) : red = 255

                                Case RuleOf3 <= 50 : red = Math.Round(RuleOf3 * 5.1) : green = 255

                            End Select

                            File.AppendAllText(Results_File_Html, String.Format(Results_File_Result_Format, _
                                 Result.Item1, RGB_To_HTML(red, green, 0), Result.Item2, _
                                 Environment.NewLine & Environment.NewLine))

                        Next

                        File.AppendAllText(Results_File_Html, String.Format(Results_File_Palette_String, _
                             Money_Abbreviation(RuleOf3_Greatest), RuleOf3_Greatest.ToString("##,##"), Palette_Image, _
                            Money_Abbreviation(RuleOf3_Lowest), RuleOf3_Lowest.ToString("##,##"), "", Environment.NewLine))

                        File.AppendAllText(Results_File_Html, Results_File_End)

                        If MsgBox("El proceso ha terminado. ¿Desea abrir el archivo para ver los resultados?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                            Try : Process.Start(App_Html, Results_File_Html) : Catch : End Try
                        End If
                        'Try : Process.Start("C:\Program Files (x86)\Mozilla Firefox\firefox.exe", Results_File) : Catch : End Try

                    Case ResultFormatting.TEXT ' Notepad

                        ' Results_File = Path.GetTempFileName() ' Create a new unique temp file
                        ' Add the data into the file
                        ' Process.Start(Results_File) ' Open the file using ShellExecute asociated application

                        'Throw New Exception(" Te equivocaste de formato, ""TEXTO PLANO"" todavía no está implementado... ")
                        'Exit Sub

                        File.AppendAllText(Results_File_Txt, _
                             String.Format(Results_File_Search_Engine_Title_Text, Navegador, SplitTxt))

                        RuleOf3_Lowest = NavList.OrderBy(Function(Tuple) Tuple.Item2).ToList().First.Item2
                        RuleOf3_Greatest = NavList.OrderBy(Function(Tuple) Tuple.Item2).ToList().Last.Item2

                        For Each Result As Tuple(Of String, Long) In NavList

                            File.AppendAllText(Results_File_Txt, String.Format(Results_File_Result_Format_Text, _
                                 Result.Item1, Result.Item2.ToString("##,##"), _
                                 Environment.NewLine))

                        Next

                        File.AppendAllText(Results_File_Txt, String.Format(Results_File_Palette_String_Text, _
                            Money_Abbreviation(RuleOf3_Greatest), RuleOf3_Greatest.ToString("##,##"), _
                            Money_Abbreviation(RuleOf3_Lowest), RuleOf3_Lowest.ToString("##,##")))

                        If MsgBox("El proceso ha terminado. ¿Desea abrir el archivo para ver los resultados?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                            Try : Process.Start(App_Text, Results_File_Txt) : Catch : End Try
                        End If

                End Select

            Case SearchEngine = SearchEngines.ALL
                Select Case ResultFormatting

                    Case ResultFormatting.HTML ' WebBrowser

                        My.Resources.RGB.Save(Palette_Image) ' Save the palette image to temp directory.

                        ' Get the lowest and greatest result numbers to calculate the rule of three
                        RuleOf3_Lowest = Google_Results_List.OrderBy(Function(Tuple) Tuple.Item2).ToList().First.Item2
                        RuleOf3_Greatest = Google_Results_List.OrderBy(Function(Tuple) Tuple.Item2).ToList().Last.Item2

                        ' (TEST PURPOSSES) Display the Rule of three variables
                        'MsgBox(RuleOf3_Lowest)
                        'MsgBox(RuleOf3_Greatest)

                        ' Write the header into the file
                        File.WriteAllText(Results_File_Html, String.Format(Results_File_Header, Environment.NewLine & Environment.NewLine))

                        ' Append the Search Engine Title into the file
                        File.AppendAllText(Results_File_Html, _
                             String.Format(Results_File_Search_Engine_Title, "Google", _
                                           Environment.NewLine & Environment.NewLine))

                        For Each Result As Tuple(Of String, Long) In Google_Results_List

                            RuleOf3 = ((Result.Item2 - RuleOf3_Lowest) / (RuleOf3_Greatest - RuleOf3_Lowest)) * 100

                            Select Case True

                                Case RuleOf3 > 50 : green = 255 - Math.Round(RuleOf3 * 2.55) : red = 255

                                Case RuleOf3 <= 50 : red = Math.Round(RuleOf3 * 5.1) : green = 255

                            End Select

                            File.AppendAllText(Results_File_Html, String.Format(Results_File_Result_Format, _
                                 Result.Item1, RGB_To_HTML(red, green, 0), Result.Item2, _
                                 Environment.NewLine & Environment.NewLine))

                        Next

                        File.AppendAllText(Results_File_Html, String.Format(Results_File_Palette_String, _
                             Money_Abbreviation(RuleOf3_Greatest), RuleOf3_Greatest.ToString("##,##"), Palette_Image, _
                            Money_Abbreviation(RuleOf3_Lowest), RuleOf3_Lowest.ToString("##,##"), "<hr>", Environment.NewLine))

                        RuleOf3_Greatest = Nothing
                        RuleOf3_Lowest = Nothing

                        RuleOf3_Lowest = Bing_Results_List.OrderBy(Function(Tuple) Tuple.Item2).ToList().First.Item2
                        RuleOf3_Greatest = Bing_Results_List.OrderBy(Function(Tuple) Tuple.Item2).ToList().Last.Item2

                        ' (TEST PURPOSSES) Display the Rule of three variables
                        'MsgBox(RuleOf3_Lowest)
                        'MsgBox(RuleOf3_Greatest)

                        ' Append the Search Engine Title into the file
                        File.AppendAllText(Results_File_Html, _
                             String.Format(Results_File_Search_Engine_Title, "Bing", _
                                           Environment.NewLine & Environment.NewLine))

                        For Each Result As Tuple(Of String, Long) In Bing_Results_List

                            RuleOf3 = ((Result.Item2 - RuleOf3_Lowest) / (RuleOf3_Greatest - RuleOf3_Lowest)) * 100

                            Select Case True

                                Case RuleOf3 > 50 : green = 255 - Math.Round(RuleOf3 * 2.55) : red = 255

                                Case RuleOf3 <= 50 : red = Math.Round(RuleOf3 * 5.1) : green = 255

                            End Select

                            File.AppendAllText(Results_File_Html, String.Format(Results_File_Result_Format, _
                                 Result.Item1, RGB_To_HTML(red, green, 0), Result.Item2, _
                                 Environment.NewLine & Environment.NewLine))

                        Next

                        File.AppendAllText(Results_File_Html, String.Format(Results_File_Palette_String, _
                             Money_Abbreviation(RuleOf3_Greatest), RuleOf3_Greatest.ToString("##,##"), Palette_Image, _
                            Money_Abbreviation(RuleOf3_Lowest), RuleOf3_Lowest.ToString("##,##"), "", Environment.NewLine))

                        File.AppendAllText(Results_File_Html, Results_File_End)

                        If MsgBox("El proceso ha terminado. ¿Desea abrir el archivo para ver los resultados?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                            Try : Process.Start(App_Html, Results_File_Html) : Catch : End Try
                        End If
                        'Try : Process.Start("C:\Program Files (x86)\Mozilla Firefox\firefox.exe", Results_File) : Catch : End Try

                    Case ResultFormatting.TEXT ' Notepad

                        ' Results_File = Path.GetTempFileName() ' Create a new unique temp file
                        ' Add the data into the file
                        ' Process.Start(Results_File) ' Open the file using ShellExecute asociated application

                        'Throw New Exception(" Te equivocaste de formato, ""TEXTO PLANO"" todavía no está implementado... ")
                        'Exit Sub

                        File.AppendAllText(Results_File_Txt, _
                             String.Format(Results_File_Search_Engine_Title_Text, "Google", "====================="))

                        RuleOf3_Lowest = Google_Results_List.OrderBy(Function(Tuple) Tuple.Item2).ToList().First.Item2
                        RuleOf3_Greatest = Google_Results_List.OrderBy(Function(Tuple) Tuple.Item2).ToList().Last.Item2

                        For Each Result As Tuple(Of String, Long) In Google_Results_List

                            File.AppendAllText(Results_File_Txt, String.Format(Results_File_Result_Format_Text, _
                                 Result.Item1, Result.Item2.ToString("##,##"), _
                                 Environment.NewLine))

                        Next

                        File.AppendAllText(Results_File_Txt, String.Format(Results_File_Palette_String_Text, _
                        Money_Abbreviation(RuleOf3_Greatest), RuleOf3_Greatest.ToString("##,##"), _
                        Money_Abbreviation(RuleOf3_Lowest), RuleOf3_Lowest.ToString("##,##")))

                        File.AppendAllText(Results_File_Txt, Environment.NewLine & "=============================" & Environment.NewLine & Environment.NewLine)

                        RuleOf3_Greatest = Nothing
                        RuleOf3_Lowest = Nothing

                        File.AppendAllText(Results_File_Txt, _
                            String.Format(Results_File_Search_Engine_Title_Text, "Bing", "==================="))

                        RuleOf3_Lowest = Bing_Results_List.OrderBy(Function(Tuple) Tuple.Item2).ToList().First.Item2
                        RuleOf3_Greatest = Bing_Results_List.OrderBy(Function(Tuple) Tuple.Item2).ToList().Last.Item2

                        For Each Result As Tuple(Of String, Long) In Bing_Results_List

                            File.AppendAllText(Results_File_Txt, String.Format(Results_File_Result_Format_Text, _
                                 Result.Item1, Result.Item2.ToString("##,##"), _
                                 Environment.NewLine))

                        Next

                        File.AppendAllText(Results_File_Txt, String.Format(Results_File_Palette_String_Text, _
                            Money_Abbreviation(RuleOf3_Greatest), RuleOf3_Greatest.ToString("##,##"), _
                            Money_Abbreviation(RuleOf3_Lowest), RuleOf3_Lowest.ToString("##,##")))

                        If MsgBox("El proceso ha terminado. ¿Desea abrir el archivo para ver los resultados?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                            Try : Process.Start(App_Text, Results_File_Txt) : Catch : End Try
                        End If

                End Select


        End Select

    End Sub


End Class