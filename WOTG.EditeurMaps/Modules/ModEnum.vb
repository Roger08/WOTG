Module ModEnum

    ' ##################
    ' ## Enumerations ##
    ' ##################

    Public Enum PaquetClient As Byte
        Connexion
        Inscription
        CreationPersonnage
        ' Paquets éditeurs
        EConnexion
        EMSauvegarde
    End Enum

    Public Enum PaquetServeur As Byte
        RepConnexion
        BonMSG
        MauvaisMSG
        EnvoieJoueur
        EnvoieRace
        EnvoieClasse
        RepEMSauvegarde
    End Enum
End Module