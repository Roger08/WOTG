Module ModEnum

    ' ##################
    ' ## Enumerations ##
    ' ##################

    Public Enum PaquetClient As Byte
        Connexion
        Inscription
        CreationPersonnage
        JoueurMouv
        ' Paquets editeurs
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
        RepJoueurMouv
    End Enum
End Module
