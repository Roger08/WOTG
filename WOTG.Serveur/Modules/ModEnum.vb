Module ModEnum

    ' ##################
    ' ## Enumerations ##
    ' ##################

    Public Enum PaquetClient As Byte
        Connexion
        Inscription
    End Enum

    Public Enum PaquetServeur As Byte
        RepConnexion
        BonMSG
        MauvaisMSG
        EnvoieJoueur
    End Enum
End Module
