Module Programme

    Sub Main()
        ' - Dimension des tableaux
        ReDim Joueur(MAX_JOUEURS)
        ReDim JoueurTemp(MAX_JOUEURS)
        ReDim Classe(MAX_CLASSES)
        ReDim Race(MAX_RACES)
        ReDim Map(MAX_MAPS)

        ' - Chargement du serveur
        Call MOTD()
        Call ChargerBDD()
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
