Module ModFonctions

    ' #################################
    ' ## Module des fonctions du jeu ##
    ' #################################

    ' - Trouve un slot disponible pour un nouveau client
    Public Function TrouverSlotOuvert() As Byte
        Dim temp As Byte

        For i = 0 To MAX_JOUEURS
            If Not JoueurTemp(i).Connecte Then
                temp = i
                Exit For
            End If
        Next

        Return (temp)
    End Function

End Module
