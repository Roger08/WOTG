Module ModFonctions

    ' #################################
    ' ## Module des fonctions du jeu ##
    ' #################################

    ' - Trouve un slot disponible pour un nouveau client
    Public Function TrouverSlotOuvert() As Byte
        Dim temp As Byte

        For i = 1 To MAX_JOUEURS
            If Not JoueurTemp(i).Connecte Then
                temp = i
                Exit For
            End If
        Next

        Return (temp)
    End Function

    ' - Vérifie si le joueur n'est pas déjà connecté
    Public Function JoueurConnecté(ByVal pseudo As String) As Boolean
        Dim temp As Boolean = False

        For i = 0 To ListeIndex.Count - 1
            If JoueurTemp(ListeIndex(i)).EnJeu Then
                If Joueur(ListeIndex(i)).Nom = pseudo Then
                    temp = True
                    Exit For
                End If
            End If
        Next
        Return temp
    End Function

End Module
