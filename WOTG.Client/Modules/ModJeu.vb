Imports System.Threading

Module ModJeu

    ' ###########################################
    ' ## Module de gestion graphique et du jeu ##
    ' ###########################################

    ' - Boucle de rafraichissement du jeu
    Public Sub Gameloop()

        While _Socket.Connected

            ' Traitement des paquets
            Call RecevoirPaquets()

            ' Affichage graphique

            Application.DoEvents()
        End While
        MsgBox("Connexion avec le serveur perdue ! Merci de le signaler à l'équipe du jeu.", MsgBoxStyle.Critical, "Erreur fatale")
        End
    End Sub

End Module
