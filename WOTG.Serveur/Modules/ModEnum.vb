Module ModEnum

    ' ##################
    ' ## Enumerations ##
    ' ##################

    Public Enum PaquetClient As Byte
        Connexion
        Inscription
        CreationPersonnage
    End Enum

    Public Enum PaquetServeur As Byte
        RepConnexion
        BonMSG
        MauvaisMSG
        EnvoieJoueur
        EnvoieRace
        EnvoieClasse
    End Enum
End Module
