Public Class frmSauvegardeMap

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not txtPass.Text.Length = 0 Then
            Call EnvoiSauvegarde(MapActuelle, txtPass.Text)
            Me.Close()
        End If
    End Sub
End Class