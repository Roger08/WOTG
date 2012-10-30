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

    Public Sub Fail(ByVal Message As String)
        Console.ForegroundColor = ConsoleColor.red
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
End Module
