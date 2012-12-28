Public Class frmLogin

    Private Sub frmLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SauvegarderOptions()
        End
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' - Options du client
        Call ChargerOptions()
        txtNom.Text = Options.Pseudo
        If Options.Memoriser Then txtPass.Text = Options.MotDePasse
        chkmdp.Checked = Options.Memoriser
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Call Init()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Options.Pseudo = txtNom.Text
        If Options.Memoriser Then Options.MotDePasse = txtPass.Text Else Options.MotDePasse = Nothing
        Call SauvegarderOptions()
        Call Connexion(txtNom.Text, txtPass.Text)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        ' TODO : Ouvrir la page d'inscription du site
        Call EnvoyerPaquet(PaquetClient.Inscription & SEP & txtNom.Text & SEP & txtPass.Text)
    End Sub

    Private Sub chkmdp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkmdp.CheckedChanged
        Options.Memoriser = chkmdp.Checked
    End Sub
End Class
