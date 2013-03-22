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
        FenetreRendu = New RenderWindow(frmJeu.PicJeu.Handle)
        FenetreRendu.SetFramerateLimit(35)

        For i = 0 To 6
            CoucheRendu(4, i) = New RenderTexture(MAX_MAPX * 32, MAX_MAPY * 32)
        Next

        ReDim Map(MAX_MAPS)
        For i = 0 To MAX_MAPS
            ReDim Map(i).Cases(MAX_MAPX, MAX_MAPY)
        Next

        ReDim imgTiles(255)
        MapActuelle = Joueur(MonIndex).Map

        ' - Chargement des fichiers
        Call ChargerTiles()
        Call ChargerMap(MapActuelle)

        ' Chargement du moteur de texte
        PoliceJeu = New Font("C:\Windows\Fonts\Arial.ttf")

        ' Mise en place des couches
        For i = 0 To 6
            Call DessinerCouche(4, i)
        Next

        ' Chargement des données binaires depuis FTP

        ' frmEditeur.tmrFPS.Enabled = True

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
            Else
                TotalTiles = i
                Exit For
            End If
        Next

        imgTiles(TotalTiles) = New Texture(Application.StartupPath & "/Graphique/Tilesets/Outils.png")
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
                    Call AfficherCouche(4, i)
                Next

                ' Affichage des couches supérieures
                For i = 4 To 6
                    Call AfficherCouche(4, i)
                Next

                FenetreRendu.Display()
            End If

            Application.DoEvents()
        End While

        MsgBox("Connexion avec le serveur perdue ! Merci de le signaler à l'équipe du jeu.", MsgBoxStyle.Critical, "Erreur fatale")
        End
    End Sub

#Region "Dessin de la map"
    ' - Affichage de la couche
    Public Sub AfficherCouche(ByVal MapZone As Byte, ByVal couche As Byte)
        CoucheRendu(MapZone, couche).Display()
        FenetreRendu.Draw(New Sprite(CoucheRendu(MapZone, couche).Texture))
    End Sub

    ' - Dessin (refresh) de la couche
    Public Sub DessinerCouche(ByVal MapZone As Byte, ByVal Couche As Byte)

        CoucheRendu(MapZone, Couche).Clear(New Color(0, 0, 0, 0))

        ' Affichage des couches inférieures
        If Couche <= 3 Then
            For x = 0 To MAX_MAPX
                For y = 0 To MAX_MAPY
                    If Not x < 0 And Not x > 30 And Not y < 0 And Not y > 30 Then
                        With Map(MapActuelle).Cases(x, y)

                            If Couche = 0 Then
                                If .Sol <> 0 Then
                                    Call AfficherCase(MapActuelle, 4, x, y, 0)
                                End If
                            ElseIf Couche = 1 Then
                                If .Inf1 <> 0 Then
                                    Call AfficherCase(MapActuelle, 4, x, y, 1)
                                End If
                            ElseIf Couche = 2 Then
                                If .Inf2 <> 0 Then
                                    Call AfficherCase(MapActuelle, 4, x, y, 2)
                                End If
                            ElseIf Couche = 3 Then
                                If .Inf3 <> 0 Then
                                    Call AfficherCase(MapActuelle, 4, x, y, 3)
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
                                    Call AfficherCase(MapActuelle, 4, x, y, 4)
                                End If
                            ElseIf Couche = 5 Then
                                If .Sup2 <> 0 Then
                                    Call AfficherCase(MapActuelle, 4, x, y, 5)
                                End If
                            ElseIf Couche = 6 Then
                                If .Sup3 <> 0 Then
                                    Call AfficherCase(MapActuelle, 4, x, y, 6)
                                End If
                            End If

                        End With
                    End If
                Next
            Next
        End If
    End Sub

    ' - Affichage d'une case sur la map
    Public Sub AfficherCase(ByVal mapnum As Integer, ByVal mapzone As Byte, ByVal X As Byte, ByVal Y As Byte, ByVal Couche As Byte)
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
        CoucheRendu(Mapzone, Couche).Draw(sprtTiles)
        sprtTiles.Dispose()

    End Sub
#End Region
End Module
