Module Programme

    Sub Main()
        ' - Dimension des tableaux
        ReDim Joueur(MAX_JOUEURS)
        ReDim JoueurTemp(MAX_JOUEURS)

        Call MOTD()
        Call Init()
        Console.Read()
    End Sub

#Region "Bienvenue"
    Public Sub MOTD()
        Console.WriteLine("Serveur Wrath Of The Gods (v. " & VersionServeur & ")")
        Console.WriteLine("-----------------------------------------")
        Console.WriteLine()
        Console.WriteLine()
    End Sub
#End Region

End Module
