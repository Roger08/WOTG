Imports SFML.Graphics
Imports SFML.Window

Public Class frmCreationPerso

    ' - Variables de création du perso
    Dim RenduJoueur As RenderWindow
    Dim imgCorps As Texture
    Dim imgCheveux As Texture
    Dim imgVetements As Texture
    Dim Sprt As Sprite
    Dim RaceActuelle As Byte = 1
    Dim ClasseActuelle As Byte = 1
    Dim CheveuxActuels As Byte = 0
    Dim PeauActuelle As Byte = 0
    Dim VetementsActuels As Byte = 0
    Dim Creation As Boolean = False

    Private Sub frmCreationPerso_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Creation = False
        End
    End Sub

    Private Sub frmCreationPerso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RenduJoueur = New RenderWindow(PicPrevJoueur.Handle)
        RenduJoueur.SetFramerateLimit(10)
        lblEntete.Text = "Félicitations " & Joueur(MonIndex).Nom & ", vous êtes inscrit à Wrath Of The Gods, il vous ne vous reste plus qu'à vous créer un personnage !"
    End Sub

    Private Sub frmCreationPerso_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        frmLogin.Hide()
        Creation = True
        Call AfficherInfos()
        Call AfficherPrevJoueur()
    End Sub

    Private Sub tmrEntete_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEntete.Tick
        lblEntete.Visible = False
        tmrEntete.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        ' Cheveux +
        If CheveuxActuels <> 5 Then
            CheveuxActuels += 1
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        ' Cheveux -
        If CheveuxActuels <> 0 Then
            CheveuxActuels -= 1
        End If
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        ' Vetements +
        If VetementsActuels <> 5 Then
            VetementsActuels += 1
        End If
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        ' Vetements -
        If VetementsActuels <> 0 Then
            VetementsActuels -= 0
        End If
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        ' Peau +
        If PeauActuelle <> 5 Then
            PeauActuelle += 1
        End If
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        ' Peau -
        If PeauActuelle <> 0 Then
            PeauActuelle -= 1
        End If
    End Sub

    Sub AfficherPrevJoueur()
        While Creation
            RenduJoueur.Clear(Color.White)

            imgCorps = New Texture(Application.StartupPath & "/Graphique/Peaux/" & RaceActuelle & "x" & PeauActuelle & ".png")
            imgVetements = New Texture(Application.StartupPath & "/Graphique/Vetements/" & RaceActuelle & "x" & VetementsActuels & ".png")
            imgCheveux = New Texture(Application.StartupPath & "/Graphique/Cheveux/" & RaceActuelle & "x" & CheveuxActuels & ".png")

            ' Corps
            Sprt = New Sprite(imgCorps)
            Sprt.TextureRect = New IntRect(0, 0, 32, 64)
            RenduJoueur.Draw(Sprt)

            ' Vetements
            Sprt = New Sprite(imgVetements)
            Sprt.TextureRect = New IntRect(0, 0, 32, 64)
            RenduJoueur.Draw(Sprt)

            ' Cheveux
            Sprt = New Sprite(imgCheveux)
            Sprt.TextureRect = New IntRect(0, 0, 32, 64)
            RenduJoueur.Draw(Sprt)

            RenduJoueur.Display()
            Sprt.Dispose()
            Application.DoEvents()
        End While
    End Sub

    Sub AfficherInfos()
        lblNomRace.Text = Race(RaceActuelle).Nom
        lblDescRace.Text = Race(RaceActuelle).Description
        lblNomClasse.Text = Classe(ClasseActuelle).Nom
        lblDescClasse.Text = Classe(ClasseActuelle).Description
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        ' Hovis
        RaceActuelle = 1
        Call AfficherInfos()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        ' Elfe
        RaceActuelle = 2
        Call AfficherInfos()
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        ' Nigane
        RaceActuelle = 3
        Call AfficherInfos()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        ' Humain
        RaceActuelle = 4
        Call AfficherInfos()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        ' Sylvain
        RaceActuelle = 5
        Call AfficherInfos()
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        ' Prang
        RaceActuelle = 6
        Call AfficherInfos()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtNomPerso.Text.Length < 3 Then
            MsgBox("Le nom de personnage doit faire au moins 4 caractères.", MsgBoxStyle.Critical, "Erreur")
        Else
            Creation = False
            Call EnvoyerPaquet(PaquetClient.CreationPersonnage & SEP & txtNomPerso.Text & SEP & RaceActuelle & SEP & ClasseActuelle & SEP & PeauActuelle & SEP & CheveuxActuels & SEP & VetementsActuels)
        End If
    End Sub
End Class