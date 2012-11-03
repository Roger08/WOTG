Public Class frmLogin

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Call Init()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call Connexion(txtNom.Text, txtPass.Text)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        ' TODO : Ouvrir la page d'inscription du site
        Call EnvoyerPaquet(PaquetClient.Inscription & SEP & txtNom.Text & SEP & txtPass.Text & SEP)
    End Sub
End Class
