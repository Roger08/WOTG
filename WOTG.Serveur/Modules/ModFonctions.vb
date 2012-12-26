Imports System.IO

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

    ' - Obtient le nombre total de clients connectés
    Public Function TotalClients() As Byte
        Dim temp As Byte

        temp = ListeIndex.Count

        Return temp
    End Function

    ' - Obtient le nombre total de joueurs
    Public Function TotalJoueurs() As Byte
        Dim temp As Byte

        For i = 0 To ListeIndex.Count - 1
            If JoueurTemp(ListeIndex(i)).EnJeu Then
                temp += 1
            End If
        Next

        Return temp
    End Function

    ' - Verifie si le pseudo est déjà prit
    Public Function PseudoLibre(ByVal pseudo As String) As Boolean
        Dim temp As Boolean = True

        Dim Persos() As String = File.ReadAllLines("Comptes/ListePersos.txt")

        For i = 0 To Persos.Length - 1
            If Persos(i).ToLower = pseudo.ToLower Then
                temp = False
                Return (temp)
            End If
        Next

        Return temp
    End Function

    ' - Vérifie si un joueur est banni
    Public Function EstBanni(ByVal pseudo As String) As Boolean
        Dim temp As Boolean = False

        Dim Bannis() As String = File.ReadAllLines("Comptes/Bannis.txt")

        For i = 0 To Bannis.Length - 1
            If Bannis(i).ToLower = pseudo.ToLower Then
                temp = True
                Return (temp)
            End If
        Next

        Return (temp)
    End Function

    ' - Vérifie si l'ip est bannie
    Public Function IPBannie(ByVal IP As String) As Boolean
        Dim temp As Boolean = False

        Dim Bannis() As String = File.ReadAllLines("Comptes/IPBannies.txt")

        For i = 0 To Bannis.Length - 1
            If Bannis(i) = IP Then
                temp = True
                Return (temp)
            End If
        Next

        Return (temp)
    End Function
End Module
