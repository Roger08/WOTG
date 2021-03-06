﻿Public Class frmEditeur

    ' - Fermeture depuis croix
    Private Sub frmEditeur_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Voulez-vous vraiment quitter l'editeur ?", MsgBoxStyle.YesNo, "Attention") = MsgBoxResult.Yes Then
            Call SauvegarderOptions()
            Call DechargGraph()
            End
        Else
            e.Cancel = True
        End If
    End Sub

    ' - Chargement AVANT affichage
    Private Sub frmEditeur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call InitGraph()
    End Sub

    ' - Chargement APRES affichage
    Private Sub frmEditeur_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        frmLogin.Hide()
    End Sub

    ' - Fermeture depuis menu
    Private Sub QuitterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitterToolStripMenuItem.Click
        If MsgBox("Voulez-vous vraiment quitter l'editeur ?", MsgBoxStyle.YesNo, "Attention") = MsgBoxResult.Yes Then
            Call SauvegarderOptions()
            Call DechargGraph()
            End
        End If
    End Sub

    ' - Changement planche de tiles
    Private Sub lstTiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTiles.SelectedIndexChanged
        If Not lstTiles.Text = "Attributs" Then
            picTiles.ImageLocation = (Application.StartupPath & "/Graphique/" & lstTiles.Text)
            'frmAttributs.Visible = False
            ToolStripButton6.Enabled = True
            ToolStripButton7.Enabled = True
            ToolStripButton8.Enabled = True
            ToolStripButton9.Enabled = True
            ToolStripButton10.Enabled = True
            ToolStripButton11.Enabled = True
            ToolStripButton12.Enabled = True
        Else
            'frmAttributs.Visible = True
            ToolStripButton6.Enabled = False
            ToolStripButton7.Enabled = False
            ToolStripButton8.Enabled = False
            ToolStripButton9.Enabled = False
            ToolStripButton10.Enabled = False
            ToolStripButton11.Enabled = False
            ToolStripButton12.Enabled = False
        End If
    End Sub

    ' - Affichage des FPS
    Private Sub tmrFPS_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrFPS.Tick
        lblFPS.Text = "FPS : " & FPS
        FPS = 0

        If Minuteur = 180 Then
            EnJeu = False
            lblStatut.Text = "En veille"
            lblStatut.ForeColor = Drawing.Color.Red
        Else
            Minuteur += 1
        End If
    End Sub

    ' - Force l'éditeur à passer en basse consommation
    Private Sub MettreEnVeilleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MettreEnVeilleToolStripMenuItem.Click
        If EnJeu Then
            EnJeu = False
            lblStatut.Text = "En veille"
            lblStatut.ForeColor = Drawing.Color.Red
        End If
    End Sub

    ' - Force l'éditeur à passer en basse consommation
    Private Sub ToolStripButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton14.Click
        If EnJeu Then
            EnJeu = False
            lblStatut.Text = "En veille"
            lblStatut.ForeColor = Drawing.Color.Red
        End If
    End Sub

#Region "Gestion des touches"

    Private Sub lstTiles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstTiles.KeyDown
        Select Case e.KeyCode
            Case Keys.D1
                Call ChangeCouche0()

            Case Keys.D2
                Call ChangeCouche1()

            Case Keys.D3
                Call ChangeCouche2()

            Case Keys.D4
                Call ChangeCouche3()

            Case Keys.D5
                Call ChangeCouche4()

            Case Keys.D6
                Call ChangeCouche5()

            Case Keys.D7
                Call ChangeCouche6()

        End Select
    End Sub

#End Region

#Region "Gestion PicJeu"

    ' - La souris de baisse sur le picscreen
    Private Sub PicJeu_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicJeu.MouseDown
        PicscreenClic = True

        Call PlacerTiles(PicscreenX, PicscreenY)
        Call DessinerCouche(CoucheActuelle)
    End Sub

    ' - Mouvement de la souris sur le picscreen
    Private Sub PicJeu_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicJeu.MouseMove
        PicscreenX = Int(e.X / 32)
        PicscreenY = Int(e.Y / 32)

        lblPosition.Text = ("X : " & PicscreenX & " Y : " & PicscreenY)

        ' Indique l'activité de l'utilisateur
        Minuteur = 0
        If Not EnJeu Then
            EnJeu = True
            lblStatut.Text = "Actif"
            lblStatut.ForeColor = Drawing.Color.Green
        End If


        ' - Si la souris est baissé
        If PicscreenClic Then
            Call PlacerTiles(PicscreenX, PicscreenY)
            Call DessinerCouche(CoucheActuelle)
        End If
    End Sub

    ' - La souris de lève sur le picscreen
    Private Sub PicJeu_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicJeu.MouseUp
        PicscreenClic = False
    End Sub

#End Region

#Region "Séléction de tiles"

    ' - La souris se baisse sur les tiles
    Private Sub picTiles_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picTiles.MouseDown
        ' - Dit que la souris est appuyée
        TileCliqué = True

        TileClic = EncodeXY(Int(e.X / 32), Int(e.Y / 32))
        RecSelect.Location = New Point(Int(e.X / 32) * 32, Int(e.Y / 32) * 32)
        RecSelect.Width = 32
        RecSelect.Height = 32
    End Sub

    ' - La souris se déplace sur les tiles
    Private Sub picTiles_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picTiles.MouseMove
        If TileCliqué Then

            If Not (Int(e.X / 32) * 32 - RecSelect.Location.X) = 0 Or (Int(e.Y / 32) * 32 = RecSelect.Location.Y) = 0 Then
                RecSelect.Width = (Int(e.X / 32) * 32 - RecSelect.Location.X) + 32
                RecSelect.Height = (Int(e.Y / 32) * 32 - RecSelect.Location.Y) + 32
            Else
                RecSelect.Width = 32
                RecSelect.Height = 32
            End If

            TileClic = EncodeXY(Int(RecSelect.Left / 32), Int(RecSelect.Top / 32))
        End If
    End Sub

    ' - La souris se lève des tiles
    Private Sub picTiles_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picTiles.MouseUp
        ' - Dit que la souris est levée
        TileCliqué = False
    End Sub

#End Region

#Region "Changement de couche"

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        Call ChangeCouche0()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Call ChangeCouche1()
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        Call ChangeCouche2()
    End Sub

    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        Call ChangeCouche3()
    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        Call ChangeCouche4()
    End Sub

    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        Call ChangeCouche5()
    End Sub

    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click
        Call ChangeCouche6()
    End Sub

    Private Sub SolToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolToolStripMenuItem.Click
        Call ChangeCouche0()
    End Sub

    Private Sub Inf1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Inf1ToolStripMenuItem.Click
        Call ChangeCouche1()
    End Sub

    Private Sub Inf2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Inf2ToolStripMenuItem.Click
        Call ChangeCouche2()
    End Sub

    Private Sub Inf3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Inf3ToolStripMenuItem.Click
        Call ChangeCouche3()
    End Sub

    Private Sub SuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sup1ToolStripMenuItem.Click
        Call ChangeCouche4()
    End Sub

    Private Sub Supérieur2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sup2ToolStripMenuItem.Click
        Call ChangeCouche5()
    End Sub

    Private Sub Supérieur3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sup3ToolStripMenuItem.Click
        Call ChangeCouche6()
    End Sub

    Private Sub ChangeCouche0()
        CoucheActuelle = 0

        ToolStripButton6.Checked = True
        ToolStripButton7.Checked = False
        ToolStripButton8.Checked = False
        ToolStripButton9.Checked = False
        ToolStripButton10.Checked = False
        ToolStripButton11.Checked = False
        ToolStripButton12.Checked = False

        SolToolStripMenuItem.Checked = True
        Inf1ToolStripMenuItem.Checked = False
        Inf2ToolStripMenuItem.Checked = False
        Inf3ToolStripMenuItem.Checked = False
        Sup1ToolStripMenuItem.Checked = False
        Sup2ToolStripMenuItem.Checked = False
        Sup3ToolStripMenuItem.Checked = False
    End Sub

    Private Sub ChangeCouche1()
        CoucheActuelle = 1

        ToolStripButton6.Checked = False
        ToolStripButton7.Checked = True
        ToolStripButton8.Checked = False
        ToolStripButton9.Checked = False
        ToolStripButton10.Checked = False
        ToolStripButton11.Checked = False
        ToolStripButton12.Checked = False

        SolToolStripMenuItem.Checked = False
        Inf1ToolStripMenuItem.Checked = True
        Inf2ToolStripMenuItem.Checked = False
        Inf3ToolStripMenuItem.Checked = False
        Sup1ToolStripMenuItem.Checked = False
        Sup2ToolStripMenuItem.Checked = False
        Sup3ToolStripMenuItem.Checked = False
    End Sub

    Private Sub ChangeCouche2()
        CoucheActuelle = 2

        ToolStripButton6.Checked = False
        ToolStripButton7.Checked = False
        ToolStripButton8.Checked = True
        ToolStripButton9.Checked = False
        ToolStripButton10.Checked = False
        ToolStripButton11.Checked = False
        ToolStripButton12.Checked = False

        SolToolStripMenuItem.Checked = False
        Inf1ToolStripMenuItem.Checked = False
        Inf2ToolStripMenuItem.Checked = True
        Inf3ToolStripMenuItem.Checked = False
        Sup1ToolStripMenuItem.Checked = False
        Sup2ToolStripMenuItem.Checked = False
        Sup3ToolStripMenuItem.Checked = False
    End Sub

    Private Sub ChangeCouche3()
        CoucheActuelle = 3

        ToolStripButton6.Checked = False
        ToolStripButton7.Checked = False
        ToolStripButton8.Checked = False
        ToolStripButton9.Checked = True
        ToolStripButton10.Checked = False
        ToolStripButton11.Checked = False
        ToolStripButton12.Checked = False

        SolToolStripMenuItem.Checked = False
        Inf1ToolStripMenuItem.Checked = False
        Inf2ToolStripMenuItem.Checked = False
        Inf3ToolStripMenuItem.Checked = True
        Sup1ToolStripMenuItem.Checked = False
        Sup2ToolStripMenuItem.Checked = False
        Sup3ToolStripMenuItem.Checked = False
    End Sub

    Private Sub ChangeCouche4()
        CoucheActuelle = 4

        ToolStripButton6.Checked = False
        ToolStripButton7.Checked = False
        ToolStripButton8.Checked = False
        ToolStripButton9.Checked = False
        ToolStripButton10.Checked = True
        ToolStripButton11.Checked = False
        ToolStripButton12.Checked = False

        SolToolStripMenuItem.Checked = False
        Inf1ToolStripMenuItem.Checked = False
        Inf2ToolStripMenuItem.Checked = False
        Inf3ToolStripMenuItem.Checked = False
        Sup1ToolStripMenuItem.Checked = True
        Sup2ToolStripMenuItem.Checked = False
        Sup3ToolStripMenuItem.Checked = False
    End Sub

    Private Sub ChangeCouche5()
        CoucheActuelle = 5

        ToolStripButton6.Checked = False
        ToolStripButton7.Checked = False
        ToolStripButton8.Checked = False
        ToolStripButton9.Checked = False
        ToolStripButton10.Checked = False
        ToolStripButton11.Checked = True
        ToolStripButton12.Checked = False

        SolToolStripMenuItem.Checked = False
        Inf1ToolStripMenuItem.Checked = False
        Inf2ToolStripMenuItem.Checked = False
        Inf3ToolStripMenuItem.Checked = False
        Sup1ToolStripMenuItem.Checked = False
        Sup2ToolStripMenuItem.Checked = True
        Sup3ToolStripMenuItem.Checked = False
    End Sub

    Private Sub ChangeCouche6()
        CoucheActuelle = 6

        ToolStripButton6.Checked = False
        ToolStripButton7.Checked = False
        ToolStripButton8.Checked = False
        ToolStripButton9.Checked = False
        ToolStripButton10.Checked = False
        ToolStripButton11.Checked = False
        ToolStripButton12.Checked = True

        SolToolStripMenuItem.Checked = False
        Inf1ToolStripMenuItem.Checked = False
        Inf2ToolStripMenuItem.Checked = False
        Inf3ToolStripMenuItem.Checked = False
        Sup1ToolStripMenuItem.Checked = False
        Sup2ToolStripMenuItem.Checked = False
        Sup3ToolStripMenuItem.Checked = True
    End Sub

#End Region

#Region "Fonctions de mapping"

    ' - Gomme
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If Gomme Then
            ToolStripButton3.Checked = False
            Gomme = False
        Else
            ToolStripButton3.Checked = True
            Gomme = True
        End If
    End Sub

    ' - Grille
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        If Grille Then
            Grille = False
            ToolStripButton5.Checked = False
        Else
            Grille = True
            ToolStripButton5.Checked = True
        End If
    End Sub

    ' - Affichage de la grille
    Private Sub GrilleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrilleToolStripMenuItem.Click
        If Grille Then
            Grille = False
            ToolStripButton5.Checked = False
        Else
            Grille = True
            ToolStripButton5.Checked = True
        End If
    End Sub

    ' - Remplissage d'une couche
    Private Sub RemplirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemplirToolStripMenuItem.Click
        If MsgBox("Êtes-vous sur de vouloir remplir la couche ?", vbYesNo, "Attention") = MsgBoxResult.Yes Then
            For x = 0 To MAX_MAPX
                For y = 0 To MAX_MAPY
                    Call PlacerTiles(x, y)
                Next
            Next
            Call DessinerCouche(CoucheActuelle)
        End If
    End Sub

    ' - Vidage d'une couche
    Private Sub ViderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViderToolStripMenuItem.Click
        If MsgBox("Êtes-vous sur de vouloir vider la couche ?", MsgBoxStyle.YesNo, "Attention") = MsgBoxResult.Yes Then
            If CoucheActuelle = 0 Then ' Sol

                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        With Map(MapActuelle).Cases(x, y)
                            .SolSet = 0
                            .Sol = 0
                        End With
                    Next
                Next

            ElseIf CoucheActuelle = 1 Then ' Inf 1

                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        With Map(MapActuelle).Cases(x, y)
                            .Inf1Set = 0
                            .Inf1 = 0
                        End With
                    Next
                Next

            ElseIf CoucheActuelle = 2 Then ' Inf 2

                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        With Map(MapActuelle).Cases(x, y)
                            .Inf2Set = 0
                            .Inf2 = 0
                        End With
                    Next
                Next

            ElseIf CoucheActuelle = 3 Then ' Inf 3

                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        With Map(MapActuelle).Cases(x, y)
                            .Inf3Set = 0
                            .Inf3 = 0
                        End With
                    Next
                Next

            ElseIf CoucheActuelle = 4 Then ' Sup 1

                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        With Map(MapActuelle).Cases(x, y)
                            .Sup1Set = 0
                            .Sup1 = 0
                        End With
                    Next
                Next

            ElseIf CoucheActuelle = 5 Then ' Sup 2

                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        With Map(MapActuelle).Cases(x, y)
                            .Sup2Set = 0
                            .Sup2 = 0
                        End With
                    Next
                Next

            ElseIf CoucheActuelle = 6 Then ' Sup 3

                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        With Map(MapActuelle).Cases(x, y)
                            .Sup3Set = 0
                            .Sup3 = 0
                        End With
                    Next
                Next
            End If
        End If
        Call DessinerCouche(CoucheActuelle)
    End Sub
    ' - Remplissage d'une couche
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If MsgBox("Êtes-vous sur de vouloir remplir la couche ?", vbYesNo, "Attention") = MsgBoxResult.Yes Then
            For x = 0 To MAX_MAPX
                For y = 0 To MAX_MAPY
                    Call PlacerTiles(x, y)
                Next
            Next
            Call DessinerCouche(CoucheActuelle)
        End If
    End Sub

    ' - Vidage d'une couche
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If MsgBox("Êtes-vous sur de vouloir vider la couche ?", MsgBoxStyle.YesNo, "Attention") = MsgBoxResult.Yes Then
            If CoucheActuelle = 0 Then ' Sol

                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        With Map(MapActuelle).Cases(x, y)
                            .SolSet = 0
                            .Sol = 0
                        End With
                    Next
                Next

            ElseIf CoucheActuelle = 1 Then ' Inf 1

                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        With Map(MapActuelle).Cases(x, y)
                            .Inf1Set = 0
                            .Inf1 = 0
                        End With
                    Next
                Next

            ElseIf CoucheActuelle = 2 Then ' Inf 2

                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        With Map(MapActuelle).Cases(x, y)
                            .Inf2Set = 0
                            .Inf2 = 0
                        End With
                    Next
                Next

            ElseIf CoucheActuelle = 3 Then ' Inf 3

                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        With Map(MapActuelle).Cases(x, y)
                            .Inf3Set = 0
                            .Inf3 = 0
                        End With
                    Next
                Next

            ElseIf CoucheActuelle = 4 Then ' Sup 1

                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        With Map(MapActuelle).Cases(x, y)
                            .Sup1Set = 0
                            .Sup1 = 0
                        End With
                    Next
                Next

            ElseIf CoucheActuelle = 5 Then ' Sup 2

                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        With Map(MapActuelle).Cases(x, y)
                            .Sup2Set = 0
                            .Sup2 = 0
                        End With
                    Next
                Next

            ElseIf CoucheActuelle = 6 Then ' Sup 3

                For x = 0 To MAX_MAPX
                    For y = 0 To MAX_MAPY
                        With Map(MapActuelle).Cases(x, y)
                            .Sup3Set = 0
                            .Sup3 = 0
                        End With
                    Next
                Next
            End If
        End If
        Call DessinerCouche(CoucheActuelle)
    End Sub

    ' - Place les tiles selectionnés
    Public Sub PlacerTiles(ByVal X As Byte, ByVal Y As Byte)
        If lstTiles.Text = "Attribut" Then
            ' 
        ElseIf CoucheActuelle = 0 Then ' Sol

            If Not Gomme Then
                If RecSelect.Height = 32 And RecSelect.Width = 32 Then
                    Map(MapActuelle).Cases(X, Y).Sol = TileClic
                    Map(MapActuelle).Cases(X, Y).SolSet = lstTiles.SelectedIndex
                Else
                    For y2 = 0 To Int(RecSelect.Height / 32) - 1
                        For x2 = 0 To Int(RecSelect.Width / 32) - 1
                            If X + x2 <= MAX_MAPX Then
                                If Y + y2 <= MAX_MAPY Then
                                    With Map(MapActuelle).Cases(X + x2, Y + y2)
                                        .SolSet = lstTiles.SelectedIndex
                                        .Sol = EncodeXY((DecodeX(TileClic) + x2), (DecodeY(TileClic) + y2))
                                    End With
                                End If
                            End If
                        Next
                    Next
                End If
            Else
                Map(MapActuelle).Cases(X, Y).Sol = 0
                Map(MapActuelle).Cases(X, Y).SolSet = 0
            End If


            ElseIf CoucheActuelle = 1 Then ' Inf1

            If Not Gomme Then
                If RecSelect.Height = 32 And RecSelect.Width = 32 Then
                    Map(MapActuelle).Cases(X, Y).Inf1 = TileClic
                    Map(MapActuelle).Cases(X, Y).Inf1Set = lstTiles.SelectedIndex
                Else
                    For y2 = 0 To Int(RecSelect.Height / 32) - 1
                        For x2 = 0 To Int(RecSelect.Width / 32) - 1
                            If X + x2 <= MAX_MAPX Then
                                If Y + y2 <= MAX_MAPY Then
                                    With Map(MapActuelle).Cases(X + x2, Y + y2)
                                        .Inf1Set = lstTiles.SelectedIndex
                                        .Inf1 = EncodeXY((DecodeX(TileClic) + x2), (DecodeY(TileClic) + y2))
                                    End With
                                End If
                            End If
                        Next
                    Next
                End If
            Else
                Map(MapActuelle).Cases(X, Y).Inf1 = 0
                Map(MapActuelle).Cases(X, Y).Inf1Set = 0
            End If

        ElseIf CoucheActuelle = 2 Then ' Inf2

            If Not Gomme Then
                If RecSelect.Height = 32 And RecSelect.Width = 32 Then
                    Map(MapActuelle).Cases(X, Y).Inf2 = TileClic
                    Map(MapActuelle).Cases(X, Y).Inf2Set = lstTiles.SelectedIndex
                Else
                    For y2 = 0 To Int(RecSelect.Height / 32) - 1
                        For x2 = 0 To Int(RecSelect.Width / 32) - 1
                            If X + x2 <= MAX_MAPX Then
                                If Y + y2 <= MAX_MAPY Then
                                    With Map(MapActuelle).Cases(X + x2, Y + y2)
                                        .Inf2Set = lstTiles.SelectedIndex
                                        .Inf2 = EncodeXY((DecodeX(TileClic) + x2), (DecodeY(TileClic) + y2))
                                    End With
                                End If
                            End If
                        Next
                    Next
                End If
            Else
                Map(MapActuelle).Cases(X, Y).Inf2 = 0
                Map(MapActuelle).Cases(X, Y).Inf2Set = 0
            End If

            ElseIf CoucheActuelle = 3 Then ' Inf3

            If Not Gomme Then
                If RecSelect.Height = 32 And RecSelect.Width = 32 Then
                    Map(MapActuelle).Cases(X, Y).Inf3 = TileClic
                    Map(MapActuelle).Cases(X, Y).Inf3Set = lstTiles.SelectedIndex
                Else
                    For y2 = 0 To Int(RecSelect.Height / 32) - 1
                        For x2 = 0 To Int(RecSelect.Width / 32) - 1
                            If X + x2 <= MAX_MAPX Then
                                If Y + y2 <= MAX_MAPY Then
                                    With Map(MapActuelle).Cases(X + x2, Y + y2)
                                        .Inf3Set = lstTiles.SelectedIndex
                                        .Inf3 = EncodeXY((DecodeX(TileClic) + x2), (DecodeY(TileClic) + y2))
                                    End With
                                End If
                            End If
                        Next
                    Next
                End If
            Else
                Map(MapActuelle).Cases(X, Y).Inf3 = 0
                Map(MapActuelle).Cases(X, Y).Inf3Set = 0
            End If

            ElseIf CoucheActuelle = 4 Then ' Sup1

            If Not Gomme Then
                If RecSelect.Height = 32 And RecSelect.Width = 32 Then
                    Map(MapActuelle).Cases(X, Y).Sup1 = TileClic
                    Map(MapActuelle).Cases(X, Y).Sup1Set = lstTiles.SelectedIndex
                Else
                    For y2 = 0 To Int(RecSelect.Height / 32) - 1
                        For x2 = 0 To Int(RecSelect.Width / 32) - 1
                            If X + x2 <= MAX_MAPX Then
                                If Y + y2 <= MAX_MAPY Then
                                    With Map(MapActuelle).Cases(X + x2, Y + y2)
                                        .Sup1Set = lstTiles.SelectedIndex
                                        .Sup1 = EncodeXY((DecodeX(TileClic) + x2), (DecodeY(TileClic) + y2))
                                    End With
                                End If
                            End If
                        Next
                    Next
                End If
            Else
                Map(MapActuelle).Cases(X, Y).Sup1 = 0
                Map(MapActuelle).Cases(X, Y).Sup1Set = 0
            End If

            ElseIf CoucheActuelle = 5 Then ' Sup2

            If Not Gomme Then
                If RecSelect.Height = 32 And RecSelect.Width = 32 Then
                    Map(MapActuelle).Cases(X, Y).Sup2 = TileClic
                    Map(MapActuelle).Cases(X, Y).Sup2Set = lstTiles.SelectedIndex
                Else
                    For y2 = 0 To Int(RecSelect.Height / 32) - 1
                        For x2 = 0 To Int(RecSelect.Width / 32) - 1
                            If X + x2 <= MAX_MAPX Then
                                If Y + y2 <= MAX_MAPY Then
                                    With Map(MapActuelle).Cases(X + x2, Y + y2)
                                        .Sup2Set = lstTiles.SelectedIndex
                                        .Sup2 = EncodeXY((DecodeX(TileClic) + x2), (DecodeY(TileClic) + y2))
                                    End With
                                End If
                            End If
                        Next
                    Next
                End If
            Else
                Map(MapActuelle).Cases(X, Y).Sup2 = 0
                Map(MapActuelle).Cases(X, Y).Sup2Set = 0
            End If

        ElseIf CoucheActuelle = 6 Then ' Sup3

            If Not Gomme Then
                If RecSelect.Height = 32 And RecSelect.Width = 32 Then
                    Map(MapActuelle).Cases(X, Y).Sup3 = TileClic
                    Map(MapActuelle).Cases(X, Y).Sup3Set = lstTiles.SelectedIndex
                Else
                    For y2 = 0 To Int(RecSelect.Height / 32) - 1
                        For x2 = 0 To Int(RecSelect.Width / 32) - 1
                            If X + x2 <= MAX_MAPX Then
                                If Y + y2 <= MAX_MAPY Then
                                    With Map(MapActuelle).Cases(X + x2, Y + y2)
                                        .Sup3Set = lstTiles.SelectedIndex
                                        .Sup3 = EncodeXY((DecodeX(TileClic) + x2), (DecodeY(TileClic) + y2))
                                    End With
                                End If
                            End If
                        Next
                    Next
                End If
            Else
                Map(MapActuelle).Cases(X, Y).Sup3 = 0
                Map(MapActuelle).Cases(X, Y).Sup3Set = 0
            End If

        End If

    End Sub

#End Region

    Private Sub InformatiosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformatiosToolStripMenuItem.Click
        frmInformations.Show()
    End Sub

    Private Sub SauvegarderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SauvegarderToolStripMenuItem.Click
        frmSauvegardeMap.Show()
    End Sub

    Private Sub EnregistrerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnregistrerToolStripButton.Click
        frmSauvegardeMap.Show()
    End Sub

    Private Sub lstMaps_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMaps.SelectedIndexChanged
        If MsgBox("Voulez-vous vraiment changer de map ? Les modifications non enregistrées seront perdues", MsgBoxStyle.YesNo, "Attention") = MsgBoxResult.Yes Then
            MapActuelle = lstMaps.SelectedIndex
            Call ChargerMap(MapActuelle)
            For i = 0 To 6
                Call DessinerCouche(i)
            Next
        End If
    End Sub

    Private Sub RechercherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechercherToolStripMenuItem.Click
        frmRecherche.Show()
    End Sub

    Private Sub ProprietésToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProprietésToolStripMenuItem.Click
        frmProprietés.Show()
    End Sub
End Class