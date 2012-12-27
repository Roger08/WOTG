Public Class frmJeu

    Private Sub frmJeu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmCreationPerso.Visible Then frmCreationPerso.Close()
        frmLogin.Hide()
    End Sub

    Private Sub frmJeu_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    End Sub
End Class