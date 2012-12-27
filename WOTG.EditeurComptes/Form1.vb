Imports System.IO
Imports WOTG.Format.Structures
Imports System.Runtime.Serialization.Formatters.Binary


Public Class Form1

    Public Joueur As JoueurRec

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If File.Exists(Application.StartupPath & "/" & Me.TextBox1.Text.ToLower & ".wotg") Then
            Call ChargerJoueur(Me.TextBox1.Text)
            Joueur.Acces = 1
            Call SauvegarderJoueur(Me.TextBox1.Text)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    ' - Charge en mémoire un joueur
    Public Sub ChargerJoueur(ByVal Pseudo As String)
        Dim FluxFichier As Stream
        Dim Deserialiseur As New BinaryFormatter

        FluxFichier = File.OpenRead(Application.StartupPath & "/" & Pseudo & ".wotg")
        Joueur = CType(Deserialiseur.Deserialize(FluxFichier), JoueurRec)
        FluxFichier.Close() : FluxFichier.Dispose()
    End Sub


    ' - Sauvegarde un joueur
    Public Sub SauvegarderJoueur(ByVal pseudo As String)
        Dim FluxFichier As Stream
        Dim Serialiseur As New BinaryFormatter

        If Not Joueur.Nom = Nothing Then
            FluxFichier = File.Create(Application.StartupPath & "/" & pseudo & ".wotg")
            Serialiseur.Serialize(FluxFichier, Joueur)
            FluxFichier.Close()
        End If
    End Sub
End Class
