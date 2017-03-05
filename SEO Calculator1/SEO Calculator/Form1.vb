#Region " Uses "

Imports System.Text.RegularExpressions
Imports System.IO

#End Region

Public Class Form1

#Region " Properties "

    Public ReadOnly Property SearchPatterns As String()
        Get
            Return TextBox_Search.Text.Split(";")
        End Get
    End Property

    Public ReadOnly Property SearchEngine As Integer
        Get
            Return DirectCast(ComboBox_Search_Engines.SelectedIndex, SearchEngines)
        End Get
    End Property

    Public ReadOnly Property ResultFormat As Integer
        Get
            Return DirectCast(ComboBox_Format.SelectedIndex, ResultFormatting)
        End Get
    End Property

#End Region

#Region " Enumerations "

    Public Enum SearchEngines As Integer
        ALL = 0
        BING = 1
        GOOGLE = 2
    End Enum

    Public Enum ResultFormatting As Integer
        TEXT = 0
        HTML = 1
    End Enum

#End Region

#Region " Variables "

    Dim strStreamWriter As StreamWriter = Nothing
    Dim strStreamW As Stream = Nothing
    Dim PathArchivo As String

    Dim Bing_Query As String = "http://www.bing.com/search?q="
    Dim Google_Query As String = "http://www.google.com/search?q="

    Dim Bing_Source As String = String.Empty
    Dim Google_Source As String = String.Empty

    Dim Bing_RegEx_Results_A As String = "id=""count"">.+?<"
    Dim Bing_RegEx_Results_B As String = "[\d\.]+"

    Dim Google_RegEx_Results_A As String = "[^#]resultStats.+?<"
    Dim Google_RegEx_Results_B As String = "[\d\,]+"

    Dim Results_List As New List(Of Tuple(Of String, String, Long))

#End Region

#Region " EventHandlers "

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

        Results_List.Clear() ' Clear the list items

        For Each Pattern In Me.SearchPatterns

            Select Case SearchEngine

                Case Is = SearchEngines.ALL
                    Results_List.Add(Tuple.Create(SearchEngines.BING.ToString, Pattern, Get_Bing_Results(Pattern)))
                    Results_List.Add(Tuple.Create(SearchEngines.GOOGLE.ToString, Pattern, Get_Google_Results(Pattern)))

                Case Is = SearchEngines.BING
                    Results_List.Add(Tuple.Create(SearchEngines.BING.ToString, Pattern, Get_Bing_Results(Pattern)))

                Case Is = SearchEngines.GOOGLE
                    Results_List.Add(Tuple.Create(SearchEngines.GOOGLE.ToString, Pattern, Get_Google_Results(Pattern)))

            End Select

        Next Pattern

        Results_List = Results_List.OrderBy(Function(X) X.Item3).ToList  ' Order the list by the results number in ascending mode.

        'Todo esto es lo que yo he modificado + algunas funciones...

        Dim tempBingResults As New List(Of Tuple(Of String, String, Long))
        tempBingResults = Results_List.Where(Function(Tuple) Tuple.Item1 = "BING").ToList()

        Dim tempGoogleResults As New List(Of Tuple(Of String, String, Long))
        tempGoogleResults = Results_List.Where(Function(Tuple) Tuple.Item1 = "GOOGLE").ToList()

        'For Each b In tempBingResults
        '    MsgBox(b.Item3)
        'Next

        'For Each g In tempGoogleResults
        '    MsgBox(g.Item3)
        'Next

        Dim largest As Int64
        Dim smallest As Int64
        Dim Final_String_Big As String
        Dim Final_String_Small As String

        'MsgBox(Results_List.Item(0).Item3) ' El valor más bajo de resultados
        'MsgBox(Results_List.Item(Results_List.Count - 1).Item3) ' El valor más alto de resultados
        'MsgBox(Results_List.Item(X).Item1) ' BING o GOOGLE
        'MsgBox(Results_List.Item(X).Item2) ' El patrón de búsqueda
        'MsgBox(Results_List.Item(X).Item3) ' El número de resultados

        Select Case True

            Case Is = SearchEngines.ALL

                PathArchivo = ".\Resultats-" & ToUnixTime(Date.Now) & ".html"

                Try

                    If File.Exists(PathArchivo) Then
                        strStreamW = File.Open(PathArchivo, FileMode.Append)
                    Else
                        strStreamW = File.Create(PathArchivo)
                    End If

                    strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

                    strStreamWriter.Write("<html>" & vbCrLf & "<head>" & vbCrLf & "</head>" & vbCrLf & "<body>" & vbCrLf & "<!--- Algo de Body por aquí :D -->" & vbCrLf & vbCrLf & "<h2>Resultados de Google:</h2><br>")

                    strStreamWriter.Close()

                    strStreamW = Nothing
                    strStreamWriter = Nothing

                Catch ex As Exception
                    MsgBox("[" & Date.Now & "] " & "Error al Guardar la información en el archivo.", MsgBoxStyle.Critical, "Error")
                    strStreamWriter.Close()
                End Try

                For X As Integer = 0 To tempGoogleResults.Count - 1
                    largest = tempGoogleResults.Item(tempGoogleResults.Count - 1).Item3
                    smallest = tempGoogleResults.Item(0).Item3

                    Dim reglade3 As Double = ((tempGoogleResults.Item(X).Item3 - smallest) / (largest - smallest)) * 100
                    Dim red As Double = 255
                    Dim green As Double = 255

                    Select Case True

                        Case reglade3 > 50
                            green = 255 - Math.Round(reglade3 * 2.55)

                        Case reglade3 <= 50
                            red = Math.Round(reglade3 * 5.1)

                    End Select

                    Try

                        If File.Exists(PathArchivo) Then
                            strStreamW = File.Open(PathArchivo, FileMode.Append)
                        Else
                            strStreamW = File.Create(PathArchivo)
                        End If

                        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

                        strStreamWriter.Write("<b>La b&uacute;squeda: """ & tempGoogleResults.Item(X).Item2 & """, ha obtenido <font style=""color:" & RGB2HTMLColor(red, green, 0) & ";"">aproxim&aacute;damente " & tempGoogleResults.Item(X).Item3 & " resultados.</font></b><br>")

                        strStreamWriter.Close()

                        strStreamW = Nothing
                        strStreamWriter = Nothing

                    Catch ex As Exception
                        MsgBox("[" & Date.Now & "] " & "Error al Guardar la información en el archivo.", MsgBoxStyle.Critical, "Error")
                        strStreamWriter.Close()
                    End Try

                Next

                Select Case True

                    Case smallest.ToString("##,##").Length >= 5 And Not smallest.ToString("##,##").Length >= 8
                        Final_String_Small = smallest.ToString("##,##").Replace(smallest.ToString("##,##").Substring(smallest.ToString("##,##").LastIndexOf(".")), "K")

                    Case smallest.ToString("##,##").Length >= 8 And Not smallest.ToString("##,##").Length >= 12
                        Final_String_Small = smallest.ToString("##,##").Replace(smallest.ToString("##,##").Substring(smallest.ToString("##,##").LastIndexOf(".") - 4), "M")

                    Case smallest.ToString("##,##").Length >= 12
                        Final_String_Small = smallest.ToString("##,##").Replace(smallest.ToString("##,##").Substring(smallest.ToString("##,##").LastIndexOf(".") - 8), "B")

                    Case Else
                        Final_String_Small = smallest.ToString("##,##")

                End Select

                Select Case True

                    Case largest.ToString("##,##").Length >= 5 And Not largest.ToString("##,##").Length >= 8
                        Final_String_Big = largest.ToString("##,##").Replace(largest.ToString("##,##").Substring(largest.ToString("##,##").LastIndexOf(".")), "K")

                    Case largest.ToString("##,##").Length >= 8 And Not largest.ToString("##,##").Length >= 12
                        Final_String_Big = largest.ToString("##,##").Replace(largest.ToString("##,##").Substring(largest.ToString("##,##").LastIndexOf(".") - 4), "M")

                    Case largest.ToString("##,##").Length >= 12
                        Final_String_Big = largest.ToString("##,##").Replace(largest.ToString("##,##").Substring(largest.ToString("##,##").LastIndexOf(".") - 8), "B")

                    Case Else
                        Final_String_Big = largest.ToString("##,##")

                End Select


                Try

                    If File.Exists(PathArchivo) Then
                        strStreamW = File.Open(PathArchivo, FileMode.Append)
                    Else
                        strStreamW = File.Create(PathArchivo)
                    End If

                    strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

                    strStreamWriter.Write("<br><span style=""font-family:Arial;font-size:8px;margin-top:-5px;position:relative;padding-right:5px;"">" & Final_String_Big & " (" & largest.ToString("##,##") & ")</span><img  src=""http://imageshack.us/a/img803/2489/13067304.png"" style=""width:54px; height:29px;""><span style=""font-family:Arial;font-size:8px;margin-top:-5px;position:relative;padding-left:5px;"">" & Final_String_Small & " (" & smallest.ToString("##,##") & ")</span>" & vbCrLf & "<br>" & vbCrLf & "<hr>")

                    strStreamWriter.Close()

                    strStreamW = Nothing
                    strStreamWriter = Nothing

                Catch ex As Exception
                    MsgBox("[" & Date.Now & "] " & "Error al Guardar la información en el archivo.", MsgBoxStyle.Critical, "Error")
                    strStreamWriter.Close()
                End Try

                Try

                    If File.Exists(PathArchivo) Then
                        strStreamW = File.Open(PathArchivo, FileMode.Append)
                    Else
                        strStreamW = File.Create(PathArchivo)
                    End If

                    strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

                    strStreamWriter.Write("<h2>Resultados de Bing:</h2><br>")

                    strStreamWriter.Close()

                    strStreamW = Nothing
                    strStreamWriter = Nothing

                Catch ex As Exception
                    MsgBox("[" & Date.Now & "] " & "Error al Guardar la información en el archivo.", MsgBoxStyle.Critical, "Error")
                    strStreamWriter.Close()
                End Try

                For X As Integer = 0 To tempBingResults.Count - 1
                    largest = tempBingResults.Item(Results_List.Count - 1).Item3
                    smallest = tempBingResults.Item(0).Item3

                    Dim reglade3 As Double = ((tempBingResults.Item(X).Item3 - smallest) / (largest - smallest)) * 100
                    Dim red As Double = 255
                    Dim green As Double = 255

                    Select Case True

                        Case reglade3 > 50
                            green = 255 - Math.Round(reglade3 * 2.55)

                        Case reglade3 <= 50
                            red = Math.Round(reglade3 * 5.1)

                    End Select

                    Try

                        If File.Exists(PathArchivo) Then
                            strStreamW = File.Open(PathArchivo, FileMode.Append)
                        Else
                            strStreamW = File.Create(PathArchivo)
                        End If

                        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

                        strStreamWriter.Write("<b>La b&uacute;squeda: """ & tempBingResults.Item(X).Item2 & """, ha obtenido <font style=""color:" & RGB2HTMLColor(red, green, 0) & ";"">aproxim&aacute;damente " & tempBingResults.Item(X).Item3 & " resultados.</font></b><br>")

                        strStreamWriter.Close()

                        strStreamW = Nothing
                        strStreamWriter = Nothing

                    Catch ex As Exception
                        MsgBox("[" & Date.Now & "] " & "Error al Guardar la información en el archivo.", MsgBoxStyle.Critical, "Error")
                        strStreamWriter.Close()
                    End Try

                Next

                Select Case True

                    Case smallest.ToString("##,##").Length >= 5 And Not smallest.ToString("##,##").Length >= 8
                        Final_String_Small = smallest.ToString("##,##").Replace(smallest.ToString("##,##").Substring(smallest.ToString("##,##").LastIndexOf(".")), "K")

                    Case smallest.ToString("##,##").Length >= 8 And Not smallest.ToString("##,##").Length >= 12
                        Final_String_Small = smallest.ToString("##,##").Replace(smallest.ToString("##,##").Substring(smallest.ToString("##,##").LastIndexOf(".") - 4), "M")

                    Case smallest.ToString("##,##").Length >= 12
                        Final_String_Small = smallest.ToString("##,##").Replace(smallest.ToString("##,##").Substring(smallest.ToString("##,##").LastIndexOf(".") - 8), "B")

                    Case Else
                        Final_String_Small = smallest.ToString("##,##")

                End Select

                Select Case True

                    Case largest.ToString("##,##").Length >= 5 And Not largest.ToString("##,##").Length >= 8
                        Final_String_Big = largest.ToString("##,##").Replace(largest.ToString("##,##").Substring(largest.ToString("##,##").LastIndexOf(".")), "K")

                    Case largest.ToString("##,##").Length >= 8 And Not largest.ToString("##,##").Length >= 12
                        Final_String_Big = largest.ToString("##,##").Replace(largest.ToString("##,##").Substring(largest.ToString("##,##").LastIndexOf(".") - 4), "M")

                    Case largest.ToString("##,##").Length >= 12
                        Final_String_Big = largest.ToString("##,##").Replace(largest.ToString("##,##").Substring(largest.ToString("##,##").LastIndexOf(".") - 8), "B")

                    Case Else
                        Final_String_Big = largest.ToString("##,##")

                End Select


                Try

                    If File.Exists(PathArchivo) Then
                        strStreamW = File.Open(PathArchivo, FileMode.Append)
                    Else
                        strStreamW = File.Create(PathArchivo)
                    End If

                    strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

                    strStreamWriter.Write("<br><span style=""font-family:Arial;font-size:8px;margin-top:-5px;position:relative;padding-right:5px;"">" & Final_String_Big & " (" & largest.ToString("##,##") & ")</span><img  src=""http://imageshack.us/a/img803/2489/13067304.png"" style=""width:54px; height:29px;""><span style=""font-family:Arial;font-size:8px;margin-top:-5px;position:relative;padding-left:5px;"">" & Final_String_Small & " (" & smallest.ToString("##,##") & ")</span>" & vbCrLf & "<br>" & vbCrLf & "<hr>")

                    strStreamWriter.Close()

                    strStreamW = Nothing
                    strStreamWriter = Nothing

                Catch ex As Exception
                    MsgBox("[" & Date.Now & "] " & "Error al Guardar la información en el archivo.", MsgBoxStyle.Critical, "Error")
                    strStreamWriter.Close()
                End Try

            Case Is = SearchEngines.BING Or SearchEngines.GOOGLE Or Not SearchEngines.ALL

                If SearchEngine = SearchEngines.GOOGLE Then
                    PathArchivo = ".\ResultatsdeGoogle-" & ToUnixTime(Date.Now) & ".html"
                ElseIf SearchEngine = SearchEngines.BING Then
                    PathArchivo = ".\ResultatsdeBing-" & ToUnixTime(Date.Now) & ".html"
                End If

                Try

                    If File.Exists(PathArchivo) Then
                        strStreamW = File.Open(PathArchivo, FileMode.Append)
                    Else
                        strStreamW = File.Create(PathArchivo)
                    End If

                    strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

                    strStreamWriter.Write("<html>" & vbCrLf & "<head>" & vbCrLf & "</head>" & vbCrLf & "<body>" & vbCrLf & "<!--- Algo de Body por aquí :D -->" & vbCrLf & vbCrLf)

                    strStreamWriter.Close()

                    strStreamW = Nothing
                    strStreamWriter = Nothing

                Catch ex As Exception
                    MsgBox("[" & Date.Now & "] " & "Error al Guardar la información en el archivo.", MsgBoxStyle.Critical, "Error")
                    strStreamWriter.Close()
                End Try

                For X As Integer = 0 To Results_List.Count - 1
                    largest = Results_List.Item(Results_List.Count - 1).Item3
                    smallest = Results_List.Item(0).Item3

                    Dim reglade3 As Double = ((Results_List.Item(X).Item3 - smallest) / (largest - smallest)) * 100
                    Dim red As Double = 255
                    Dim green As Double = 255

                    Select Case True

                        Case reglade3 > 50
                            green = 255 - Math.Round(reglade3 * 2.55)

                        Case reglade3 <= 50
                            red = Math.Round(reglade3 * 5.1)

                    End Select


                    Try

                        If File.Exists(PathArchivo) Then
                            strStreamW = File.Open(PathArchivo, FileMode.Append)
                        Else
                            strStreamW = File.Create(PathArchivo)
                        End If

                        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

                        strStreamWriter.Write("<b>La b&uacute;squeda: """ & Results_List.Item(X).Item2 & """, ha obtenido <font style=""color:" & RGB2HTMLColor(red, green, 0) & ";"">aproxim&aacute;damente " & Results_List.Item(X).Item3 & " resultados.</font></b><br>")

                        strStreamWriter.Close()

                        strStreamW = Nothing
                        strStreamWriter = Nothing

                    Catch ex As Exception
                        MsgBox("[" & Date.Now & "] " & "Error al Guardar la información en el archivo.", MsgBoxStyle.Critical, "Error")
                        strStreamWriter.Close()
                    End Try

                Next

                Select Case True

                    Case smallest.ToString("##,##").Length >= 5 And Not smallest.ToString("##,##").Length >= 8
                        Final_String_Small = smallest.ToString("##,##").Replace(smallest.ToString("##,##").Substring(smallest.ToString("##,##").LastIndexOf(".")), "K")

                    Case smallest.ToString("##,##").Length >= 8 And Not smallest.ToString("##,##").Length >= 12
                        Final_String_Small = smallest.ToString("##,##").Replace(smallest.ToString("##,##").Substring(smallest.ToString("##,##").LastIndexOf(".") - 4), "M")

                    Case smallest.ToString("##,##").Length >= 12
                        Final_String_Small = smallest.ToString("##,##").Replace(smallest.ToString("##,##").Substring(smallest.ToString("##,##").LastIndexOf(".") - 8), "B")

                    Case Else
                        Final_String_Small = smallest.ToString("##,##")

                End Select

                Select Case True

                    Case largest.ToString("##,##").Length >= 5 And Not largest.ToString("##,##").Length >= 8
                        Final_String_Big = largest.ToString("##,##").Replace(largest.ToString("##,##").Substring(largest.ToString("##,##").LastIndexOf(".")), "K")

                    Case largest.ToString("##,##").Length >= 8 And Not largest.ToString("##,##").Length >= 12
                        Final_String_Big = largest.ToString("##,##").Replace(largest.ToString("##,##").Substring(largest.ToString("##,##").LastIndexOf(".") - 4), "M")

                    Case largest.ToString("##,##").Length >= 12
                        Final_String_Big = largest.ToString("##,##").Replace(largest.ToString("##,##").Substring(largest.ToString("##,##").LastIndexOf(".") - 8), "B")

                    Case Else
                        Final_String_Big = largest.ToString("##,##")

                End Select


                Try

                    If File.Exists(PathArchivo) Then
                        strStreamW = File.Open(PathArchivo, FileMode.Append)
                    Else
                        strStreamW = File.Create(PathArchivo)
                    End If

                    strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

                    strStreamWriter.Write("<br><span style=""font-family:Arial;font-size:8px;margin-top:-5px;position:relative;padding-right:5px;"">" & Final_String_Big & " (" & largest.ToString("##,##") & ")</span><img  src=""http://imageshack.us/a/img803/2489/13067304.png"" style=""width:54px; height:29px;""><span style=""font-family:Arial;font-size:8px;margin-top:-5px;position:relative;padding-left:5px;"">" & Final_String_Small & " (" & smallest.ToString("##,##") & ")</span>")

                    strStreamWriter.Close()

                    strStreamW = Nothing
                    strStreamWriter = Nothing

                Catch ex As Exception
                    MsgBox("[" & Date.Now & "] " & "Error al Guardar la información en el archivo.", MsgBoxStyle.Critical, "Error")
                    strStreamWriter.Close()
                End Try

        End Select

        Try

            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Append)
            Else
                strStreamW = File.Create(PathArchivo)
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

            strStreamWriter.Write(vbCrLf & "</body>" & vbCrLf & "</html>")

            strStreamWriter.Close()

            strStreamW = Nothing
            strStreamWriter = Nothing

        Catch ex As Exception
            MsgBox("[" & Date.Now & "] " & "Error al Guardar la información en el archivo.", MsgBoxStyle.Critical, "Error")
            strStreamWriter.Close()
        End Try

        If MsgBox("El proceso ha terminado. ¿Desea abrir el archivo para ver los resultados?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
            'System.Diagnostics.Process.Start(PathArchivo) ' Aquí ya metele lo que tu veas... :P
        End If

        '========================

        Select Case ResultFormat

            Case Is = ResultFormatting.HTML

            Case Is = ResultFormatting.TEXT

        End Select

    End Sub

#End Region

#Region " Functions "

    ' Get Bing Results
    Private Function Get_Bing_Results(ByVal SearchPattern As String) As Long

        Bing_Source = Get_URL_SourceCode(String.Format("{0}{1}", Bing_Query, SearchPattern))

        Return CLng(Convert.ToString(Regex.Match( _
               Convert.ToString(Regex.Match( _
               Bing_Source, Bing_RegEx_Results_A).Groups(0)), _
               Bing_RegEx_Results_B).Groups(0) _
               ).Replace(".", ""))

    End Function

    ' Get Google Results
    Private Function Get_Google_Results(ByVal SearchPattern As String) As Long

        Google_Source = Get_URL_SourceCode(String.Format("{0}{1}", Google_Query, SearchPattern))

        Return CLng(Convert.ToString(Regex.Match( _
               Convert.ToString(Regex.Match( _
               Google_Source, Google_RegEx_Results_A).Groups(0)), _
               Google_RegEx_Results_B).Groups(0) _
               ).Replace(",", ""))

    End Function

    ' Get URL SourceCode
    Private Function Get_URL_SourceCode(ByVal url As String) As String

        Try
            Return New IO.StreamReader(Net.HttpWebRequest.Create(url).GetResponse().GetResponseStream()).ReadToEnd()
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return Nothing
        End Try

    End Function

    'Convert RGB colors to Hexadecimal
    Public Function RGB2HTMLColor(R As Byte, G As Byte, _
   B As Byte) As String


        'INPUT: Numeric (Base 10) Values for R, G, and B)

        'RETURNS:
        'A string that can be used as an HTML Color
        '(i.e., "#" + the Hexadecimal equivalent)

        Dim HexR, HexB, HexG As Object

        'R
        HexR = Hex(R)
        If Len(HexR) < 2 Then HexR = "0" & HexR

        'Get Green Hex
        HexG = Hex(G)
        If Len(HexG) < 2 Then HexG = "0" & HexG

        HexB = Hex(B)
        If Len(HexB) < 2 Then HexB = "0" & HexB

        RGB2HTMLColor = "#" & HexR & HexG & HexB

        Return RGB2HTMLColor

    End Function

    'ToUnixTime
    Function ToUnixTime(time As Date) As Long
        ToUnixTime = DateDiff("s", DateSerial(1970, 1, 1), time)
        Return ToUnixTime
    End Function

#End Region

End Class