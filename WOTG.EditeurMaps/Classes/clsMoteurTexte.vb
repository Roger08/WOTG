Imports SFML.Graphics
Imports SFML.Window

Public Class clsMoteurTexte
    Dim DessinTexte As Text

    Sub Init()
        DessinTexte = New Text()
        DessinTexte.Font = PoliceJeu
    End Sub

    Sub Dessiner(ByVal Texte As String, ByVal Couleur As Color, ByVal Taille As Byte, ByVal X As Integer, ByVal Y As Integer)
        DessinTexte.DisplayedString = Texte
        DessinTexte.Color = Couleur
        DessinTexte.CharacterSize = Taille
        DessinTexte.Position = New Vector2f(X, Y)

        FenetreRendu.Draw(DessinTexte)
    End Sub
End Class
