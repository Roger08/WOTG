Public Class frmProprietés

    Private Sub frmProprietés_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Map(MapActuelle)
            ' Position
            txtMapNord.Text = .Haut
            txtMapSud.Text = .Bas
            txtMapOuest.Text = .Gauche
            txtMapEst.Text = .Droite

            ' Général
            txtNomMap.Text = .Nom
        End With
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With Map(MapActuelle)
            ' Position
            .Haut = Int(txtMapNord.Text)
            .Bas = Int(txtMapSud.Text)
            .Gauche = Int(txtMapOuest.Text)
            .Droite = Int(txtMapEst.Text)

            ' Général
            .Nom = txtNomMap.Text
        End With
        Me.Close()
    End Sub
End Class