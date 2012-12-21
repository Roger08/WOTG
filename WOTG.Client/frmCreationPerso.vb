Public Class frmCreationPerso

    Private Sub frmCreationPerso_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub frmCreationPerso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblEntete.Text = "Félicitations " & Joueur(MonIndex).Nom & ", vous êtes inscrit à Wrath Of The Gods, il vous ne vous reste plus qu'à vous créer un personnage !"
    End Sub

    Private Sub frmCreationPerso_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        frmLogin.Hide()
    End Sub

    Private Sub tmrEntete_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEntete.Tick
        lblEntete.Visible = False
        tmrEntete.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub
End Class