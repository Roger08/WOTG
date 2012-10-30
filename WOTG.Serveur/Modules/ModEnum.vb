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
        RepInscription
        BonMSG
        MauvaisMSG
    End Enum
End Module
