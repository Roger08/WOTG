Module ModConsoleText

    ' ####################################
    ' ## Gestion du texte de la console ##
    ' ####################################

    Public Sub Show(ByVal Message As String)
        Console.WriteLine("> " & Message)
    End Sub

    Public Sub Success(ByVal Message As String)
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("OK : " & Message)
        Console.ForegroundColor = ConsoleColor.DarkGray
    End Sub

    Public Sub Erreur(ByVal Message As String)
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("ERROR : " & Message)
        Console.ForegroundColor = ConsoleColor.DarkGray
    End Sub

    Public Sub Info(ByVal Message As String)
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine("INFO : " & Message)
        Console.ForegroundColor = ConsoleColor.DarkGray
    End Sub

    Public Sub ShowInfo(ByVal Message As String)
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.WriteLine("> " & Message)
        Console.ForegroundColor = ConsoleColor.DarkGray
    End Sub

    Public Sub ShowConnexion(ByVal Type As Byte, ByVal Message As String)
        If Type = 1 Then
            Console.ForegroundColor = ConsoleColor.DarkGreen
        ElseIf Type = 2 Then
            Console.ForegroundColor = ConsoleColor.DarkYellow
        End If
        Console.WriteLine("> " & Message)
        Console.ForegroundColor = ConsoleColor.DarkGray
    End Sub

    Public Sub ShowDeconnexion(ByVal Message As String)
        Console.ForegroundColor = ConsoleColor.DarkRed
        Console.WriteLine("> " & Message)
        Console.ForegroundColor = ConsoleColor.DarkGray
    End Sub
End Module
