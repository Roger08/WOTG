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
    End Enum
End Module