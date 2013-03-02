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
        FenetreRendu.SetFramerateLimit(35)

        For i = 0 To 6
            CoucheRendu(i) = New RenderTexture(MAX_MAPX * 32, MAX_MAPY * 32)
        Next

        ReDim Map(MAX_MAPS)
        For i = 0 To MAX_MAPS
            ReDim Map(i).Cases(MAX_MAPX, MAX_MAPY)
        Next

        ReDim imgTiles(255)

        ' - Chargement des fichiers
        Call ChargerTiles()
        Call ChargerNomMaps()
        Call ChargerMap(MapActuelle)

        ' Chargement du moteur de texte
        PoliceJeu = New Font("C:\Windows\Fonts\Arial.ttf")

        ' Mise en place des couches
        For i = 0 To 6
            Call DessinerCouche(i)
        Next

        ' Dessin de la grille
        CoucheGrille = New RenderTexture(MAX_MAPX * 32, MAX_MAPY * 32)
        CoucheGrille.Clear(New Color(0, 0, 0, 0))
        sprtTiles = New Sprite(imgTiles(TotalTiles))
        sprtTiles.TextureRect = New IntRect(0, 0, 32, 32)

        For x = 0 To MAX_MAPX
            For y = 0 To MAX_MAPY
                sprtTiles.Position = New Vector2f(x * 32, y * 32)
                CoucheGrille.Draw(sprtTiles)
            Next
        Next

        sprtTiles.Dispose()

        ' - Chargement de la selection du tiles
        Canvas.Parent = frmEditeur.picTiles
        RecSelect.Parent = Canvas
        RecSelect.Width = 32
        RecSelect.Height = 32
        RecSelect.BorderColor = Drawing.Color.DarkGreen
        RecSelect.Location = New Point(0, 0)

        frmEditeur.ToolStripButton6.Checked = True
        frmEditeur.ToolStripButton5.Checked = True
        frmEditeur.SolToolStripMenuItem.Checked = True
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
                TotalTiles = i
                Exit For
            End If
        Next

        imgTiles(TotalTiles) = New Texture(Application.StartupPath & "/Graphique/Tilesets/Outils.png")

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

                ' Affichage des couches inférieures
                For i = 0 To 3
                    Call AfficherCouche(i)
                Next

                ' Affichage des couches supérieures
                For i = 4 To 6
                    Call AfficherCouche(i)
                Next

                ' Affichage de la grille
                If Grille Then
                    Call AfficherGrille()
                End If

                ' Affichage du tiles selectionné ou des attributs
                If Not frmEditeur.lstTiles.Text = "Attributs" Then
                    Call AfficherPreviTiles()
                Else
                    For x = 0 To MAX_MAPY
                        For y = 0 To MAX_MAPX
                            If Not x < 0 And Not x > 30 And Not y < 0 And Not y > 30 Then
                                'Call DessinerAttribut(Map(MapActuelle).Cases(x, y).Attribut, x - Camera.X, y - Camera.Y)
                            End If
                        Next
                    Next
                End If

                FenetreRendu.Display()
                FPS += 1

            End If

                Application.DoEvents()
        End While

        MsgBox("Connexion avec le serveur perdue ! Merci de le signaler à l'équipe du jeu.", MsgBoxStyle.Critical, "Erreur fatale")
        End
    End Sub

#Region "Fonctions graphiques diverses"

    ' - Affichage de la couche
    Public Sub AfficherCouche(ByVal couche As Byte)
        CoucheRendu(couche).Display()
        FenetreRendu.Draw(New Sprite(CoucheRendu(couche).Texture))
    End Sub

    ' - Dessin (refresh) de la couche
    Public Sub DessinerCouche(ByVal Couche As Byte)

        CoucheRendu(Couche).Clear(New Color(0, 0, 0, 0))

        ' Affichage des couches inférieures
        If Couche <= 3 Then
            For x = 0 To MAX_MAPX
                For y = 0 To MAX_MAPY
                    If Not x < 0 And Not x > 30 And Not y < 0 And Not y > 30 Then
                        With Map(MapActuelle).Cases(x, y)

                            If Couche = 0 Then
                                If .Sol <> 0 Then
                                    Call AfficherCase(MapActuelle, x, y, 0)
                                End If
                            ElseIf Couche = 1 Then
                                If .Inf1 <> 0 Then
                                    Call AfficherCase(MapActuelle, x, y, 1)
                                End If
                            ElseIf Couche = 2 Then
                                If .Inf2 <> 0 Then
                                    Call AfficherCase(MapActuelle, x, y, 2)
                                End If
                            ElseIf Couche = 3 Then
                                If .Inf3 <> 0 Then
                                    Call AfficherCase(MapActuelle, x, y, 3)
                                End If
                            End If

                        End With
                    End If
                Next
            Next

            ' Affichage des couches supérieures
        ElseIf Couche >= 4 Then
            For x = 0 To MAX_MAPX
                For y = 0 To MAX_MAPY
                    If Not x < 0 And Not x > 30 And Not y < 0 And Not y > 30 Then
                        With Map(MapActuelle).Cases(x, y)

                            If Couche = 4 Then
                                If .Sup1 <> 0 Then
                                    Call AfficherCase(MapActuelle, x, y, 4)
                                End If
                            ElseIf Couche = 5 Then
                                If .Sup2 <> 0 Then
                                    Call AfficherCase(MapActuelle, x, y, 5)
                                End If
                            ElseIf Couche = 6 Then
                                If .Sup3 <> 0 Then
                                    Call AfficherCase(MapActuelle, x, y, 6)
                                End If
                            End If

                        End With
                    End If
                Next
            Next
        End If
    End Sub

    ' - Affichage d'une case sur la map
    Public Sub AfficherCase(ByVal mapnum As Integer, ByVal X As Byte, ByVal Y As Byte, ByVal Couche As Byte)
        Dim tX As Byte
        Dim tY As Byte

        Select Case Couche
            Case 0 ' Sol
                sprtTiles = New Sprite(imgTiles(Map(mapnum).Cases(X, Y).SolSet))
                tX = DecodeX(Map(mapnum).Cases(X, Y).Sol)
                tY = DecodeY(Map(mapnum).Cases(X, Y).Sol)
            Case 1 ' Inf1
                sprtTiles = New Sprite(imgTiles(Map(mapnum).Cases(X, Y).Inf1Set))
                tX = DecodeX(Map(mapnum).Cases(X, Y).Inf1)
                tY = DecodeY(Map(mapnum).Cases(X, Y).Inf1)
            Case 2 ' Inf2
                sprtTiles = New Sprite(imgTiles(Map(mapnum).Cases(X, Y).Inf2Set))
                tX = DecodeX(Map(mapnum).Cases(X, Y).Inf2)
                tY = DecodeY(Map(mapnum).Cases(X, Y).Inf2)
            Case 3 ' Inf3
                sprtTiles = New Sprite(imgTiles(Map(mapnum).Cases(X, Y).Inf3Set))
                tX = DecodeX(Map(mapnum).Cases(X, Y).Inf3)
                tY = DecodeY(Map(mapnum).Cases(X, Y).Inf3)
            Case 4 ' Sup1
                sprtTiles = New Sprite(imgTiles(Map(mapnum).Cases(X, Y).Sup1Set))
                tX = DecodeX(Map(mapnum).Cases(X, Y).Sup1)
                tY = DecodeY(Map(mapnum).Cases(X, Y).Sup1)
            Case 5 ' Sup2
                sprtTiles = New Sprite(imgTiles(Map(mapnum).Cases(X, Y).Sup2Set))
                tX = DecodeX(Map(mapnum).Cases(X, Y).Sup2)
                tY = DecodeY(Map(mapnum).Cases(X, Y).Sup2)
            Case 6 ' Sup3
                sprtTiles = New Sprite(imgTiles(Map(mapnum).Cases(X, Y).Sup3Set))
                tX = DecodeX(Map(mapnum).Cases(X, Y).Sup3)
                tY = DecodeY(Map(mapnum).Cases(X, Y).Sup3)
        End Select

        sprtTiles.TextureRect = New IntRect(tX * 32, tY * 32, 32, 32)
        sprtTiles.Position = New Vector2f(X * 32, Y * 32)
        CoucheRendu(Couche).Draw(sprtTiles)
        sprtTiles.Dispose()

    End Sub

    ' - Prévisualisation du tiles avec alpha
    Sub AfficherPreviTiles()
        sprtTiles = New Sprite(imgTiles(frmEditeur.lstTiles.SelectedIndex))

        With sprtTiles
            .Position = New Vector2f(PicscreenX * 32, PicscreenY * 32)
            .TextureRect = New IntRect(RecSelect.Left, RecSelect.Top, RecSelect.Width, RecSelect.Height)
            .Color = New Color(255, 255, 255, 150)
        End With

        FenetreRendu.Draw(sprtTiles)
        sprtTiles.Dispose()
    End Sub

    ' - Dessine la grille sur la map
    Sub AfficherGrille()
        CoucheGrille.Display()
        FenetreRendu.Draw(New Sprite(CoucheGrille.Texture))
    End Sub
#End Region

End Module
