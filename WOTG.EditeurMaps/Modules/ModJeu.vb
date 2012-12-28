Imports System.Threading
Imports SFML.Graphics
Imports SFML.Window
Imports System.IO

Module ModJeu

    ' ###########################################
    ' ## Module de gestion graphique et du jeu ##
    ' ###########################################

    ' - Initialisation du moteur graphique
    Public Sub InitGraph()
        FenetreRendu = New RenderWindow(frmEditeur.PicJeu.Handle)
        FenetreRendu.SetFramerateLimit(50)

        ReDim Map(MAX_MAPS)
        For i = 0 To MAX_MAPS
            ReDim Map(i).Cases(MAX_MAPX, MAX_MAPY)
        Next
        ReDim imgTiles(255)

        ' - Chargement des fichiers
        Call ChargerTiles()

        ' Chargement du moteur de texte
        PoliceJeu = New Font("C:\Windows\Fonts\Arial.ttf")

        ' - Charger la selection du tiles
        Canvas.Parent = frmEditeur.picTiles
        RecSelect.Parent = Canvas
        RecSelect.Width = 32
        RecSelect.Height = 32
        RecSelect.BorderColor = Drawing.Color.DarkGreen
        RecSelect.Location = New Point(0, 0)

        frmEditeur.ToolStripButton6.Checked = True
        frmEditeur.ToolStripButton5.Checked = True
        MapActuelle = Joueur(MonIndex).Map

        ' Chargement des données binaires depuis FTP

        frmEditeur.tmrFPS.Enabled = True
        EnJeu = True
    End Sub

    ' - Décharger le moteur graphique
    Public Sub DechargGraph()
        FenetreRendu.Dispose()

        For i = 0 To TotalTiles
            imgTiles(i).Dispose()
        Next
    End Sub

    ' - Charge les tilsets
    Public Sub ChargerTiles()
        For i = 0 To 255
            If File.Exists(Application.StartupPath & "/Graphique/Tilesets/" & i & ".png") Then
                imgTiles(i) = New Texture(Application.StartupPath & "/Graphique/Tilesets/" & i & ".png")
                frmEditeur.lstTiles.Items.Add("Tilesets/" & i & ".png")
            Else
                TotalTiles = (i - 1)
                Exit For
            End If
        Next

        frmEditeur.lstTiles.Items.Add("Attributs")

        ' - Afficher un tile
        frmEditeur.lstTiles.SelectedIndex = 0
    End Sub

    ' - Boucle de rafraichissement du jeu
    Public Sub Gameloop()

        While _Socket.Connected

            ' Traitement des paquets
            Call RecevoirPaquets()

            ' Affichage graphique
            If EnJeu Then
                FenetreRendu.Clear(New Color(160, 160, 160))

                FenetreRendu.Display()
                FPS += 1
            End If

            Application.DoEvents()
        End While

        MsgBox("Connexion avec le serveur perdue ! Merci de le signaler à l'équipe du jeu.", MsgBoxStyle.Critical, "Erreur fatale")
        End
    End Sub

End Module
