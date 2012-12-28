Public Class frmEditeur

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
    End Sub

    Private Sub PicJeu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicJeu.Click

    End Sub

    ' - Mouvement de la souris sur le picscreen
    Private Sub PicJeu_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicJeu.MouseMove
        PicscreenX = CByte(e.X / 32)
        PicscreenY = CByte(e.Y / 32)

        lblPosition.Text = ("X : " & PicscreenX & " Y : " & PicscreenY)
    End Sub
End Class