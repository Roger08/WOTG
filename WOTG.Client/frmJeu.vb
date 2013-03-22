Public Class frmJeu

    Private Sub frmJeu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        EnJeu = False
        Call DechargGraph()
        End
    End Sub

    Private Sub frmJeu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub frmJeu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmCreationPerso.Visible Then frmCreationPerso.Close()
        frmLogin.Hide()
        Call InitGraph()
    End Sub

    Private Sub frmJeu_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    End Sub
End Class