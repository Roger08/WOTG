Public Class frmInformations


    Private Sub frmInformations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtVersion.Text = VersionEditeur
        txtClef.Text = Options.Clef
    End Sub
End Class