Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Imports WOTG.Format.Structures

Module ModBDD

    ' ###############################
    ' ## Gestion de la BDD binaire ##
    ' ###############################

    ' - Chargement de la BDD du jeu
    Public Sub ChargerBDD()

    End Sub

    ' - Charge en mémoire un joueur
    Public Sub ChargerJoueur(ByVal index As Byte, ByVal Pseudo As String)
        Dim FluxFichier As Stream
        Dim Deserialiseur As New BinaryFormatter

        FluxFichier = File.OpenRead("Comptes/" & Pseudo.ToLower & ".wotg")
        Joueur(index) = CType(Deserialiseur.Deserialize(FluxFichier), JoueurRec)
        FluxFichier.Close() : FluxFichier.Dispose()
    End Sub

    ' - Efface un joueur de la mémoire
    Public Sub ViderJoueur(ByVal index As Byte)
        Joueur(index) = New JoueurRec
    End Sub

    ' - Sauvegarde un joueur
    Public Sub SauvegarderJoueur(ByVal index As Byte)
        Dim FluxFichier As Stream
        Dim Serialiseur As New BinaryFormatter

        If Not Joueur(index).Nom = Nothing Then
            FluxFichier = File.Create("Comptes/" & Joueur(index).Nom.ToLower & ".wotg")
            Serialiseur.Serialize(FluxFichier, Joueur(index))
            FluxFichier.Close()
        End If
    End Sub
End Module
