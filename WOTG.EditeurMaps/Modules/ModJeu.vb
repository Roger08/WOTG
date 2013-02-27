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

                ' Affichage des couches inférieures
                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        If Not x < 0 And Not x > 30 And Not y < 0 And Not y > 30 Then
                            With Map(MapActuelle).Cases(x, y)

                                If .Sol <> 0 Then
                                    Call AfficherCase(MapActuelle, x, y, 0)
                                End If

                                If .Inf1 <> 0 Then
                                    Call AfficherCase(MapActuelle, x, y, 1)
                                End If

                                If .Inf2 <> 0 Then
                                    Call AfficherCase(MapActuelle, x, y, 2)
                                End If

                                If .Inf3 <> 0 Then
                                    Call AfficherCase(MapActuelle, x, y, 3)
                                End If


                            End With
                        End If
                    Next
                Next

                ' Affichage des couches supérieures
                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        If Not x < 0 And Not x > 30 And Not y < 0 And Not y > 30 Then
                            With Map(MapActuelle).Cases(x, y)

                                If .Sup1 <> 0 Then
                                    Call AfficherCase(MapActuelle, x, y, 4)
                                End If

                                If .Sup2 <> 0 Then
                                    Call AfficherCase(MapActuelle, x, y, 5)
                                End If

                                If .Sup3 <> 0 Then
                                    Call AfficherCase(MapActuelle, x, y, 6)
                                End If

                            End With
                        End If
                    Next
                Next

            FenetreRendu.Display()
            FPS += 1
            End If

            Application.DoEvents()
        End While

        MsgBox("Connexion avec le serveur perdue ! Merci de le signaler à l'équipe du jeu.", MsgBoxStyle.Critical, "Erreur fatale")
        End
    End Sub

#Region "Fonctions graphiques diverses"

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
        FenetreRendu.Draw(sprtTiles)
        sprtTiles.Dispose()
    End Sub
#End Region

End Module
