Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Imports WOTG.Format.Structures

Module ModBDD

    ' ###############################
    ' ## Gestion de la BDD binaire ##
    ' ###############################

    ' - Chargement de la BDD du jeu
    Public Sub ChargerBDD()
        Try
            For i = 0 To MAX_CLASSES
                Call ChargerClasse(i)
            Next
            Call Success("Classes chargées")
        Catch
            Call Erreur("Une erreur est survenue lors du chargement du serveur")
            Call Show("Appuyez sur une touche pour quitter...")
            Console.Read()
            End
        End Try
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

    ' - Chargemement d'une classe
    Public Sub ChargerClasse(ByVal classenum As Byte)
        Dim FluxFichier As Stream
        Dim Deserialiseur As New BinaryFormatter

        If File.Exists("BDD/Classes/Classe" & classenum & ".wotg") Then
            FluxFichier = File.OpenRead("BDD/Classes/Classe" & classenum & ".wotg")
            Classe(classenum) = CType(Deserialiseur.Deserialize(FluxFichier), ClasseRec)
            FluxFichier.Close() : FluxFichier.Dispose()
        Else
            Call NettoyerClasse(classenum)
        End If
    End Sub

    ' - Nettoyage d'une classe
    Public Sub NettoyerClasse(ByVal classenum As Byte)
        With Classe(classenum)
            .Nom = vbNullString
            .Description = vbNullString
        End With
    End Sub

    ' - Sauvegarde d'une classe
    Public Sub SauvegarderClasse(ByVal classenum As Byte)
        Dim FluxFichier As Stream
        Dim Serialiseur As New BinaryFormatter

        FluxFichier = File.Create("BDD/Classes/Classe" & classenum & ".wotg")
        Serialiseur.Serialize(FluxFichier, Classe(classenum))
        FluxFichier.Close()
    End Sub
End Module
