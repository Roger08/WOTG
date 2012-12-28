Public Class frmLogin

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Options.Pseudo = txtNom.Text
        If Options.Memoriser Then Options.MotDePasse = txtPass.Text Else Options.MotDePasse = Nothing
        Call Connexion(txtNom.Text, txtPass.Text)
    End Sub

    Private Sub frmLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SauvegarderOptions()
        End
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' - Options de l'éditeur
        Call ChargerOptions()
        txtNom.Text = Options.Pseudo
        If Options.Memoriser Then txtPass.Text = Options.MotDePasse
        CheckBox1.Checked = Options.Memoriser

        If Options.Clef = Nothing Then
            Options.Clef = KeyGen(9)
            txtNom.Text = Options.Clef
            Call SauvegarderOptions()
        End If
    End Sub

    Private Sub frmLogin_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Call Init()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Options.Memoriser = CheckBox1.Checked
    End Sub
End Class
