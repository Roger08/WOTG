Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Imports WOTG.Format.Structures

Module ModBDD

    ' ############################################
    ' ## Gestion de la BDD binaire et graphique ##
    ' ############################################

    Public Sub InitStructures()
        ReDim Joueur(MAX_JOUEURS)
        ReDim JoueurTemp(MAX_JOUEURS)
        ReDim Classe(MAX_CLASSES)
        ReDim Race(MAX_RACES)
    End Sub

    ' - Sauvegarde des options
    Public Sub SauvegarderOptions()
        Dim FluxFichier As Stream
        Dim Serialiseur As New BinaryFormatter

        FluxFichier = File.Create("Options.wotg")
        Serialiseur.Serialize(FluxFichier, Options)
        FluxFichier.Close()
    End Sub

    ' - Chargement des options
    Public Sub ChargerOptions()
        Dim FluxFichier As Stream
        Dim Deserialiseur As New BinaryFormatter

        If File.Exists("Options.wotg") Then
            FluxFichier = File.OpenRead("Options.wotg")
            Options = CType(Deserialiseur.Deserialize(FluxFichier), OptionsRec)
            FluxFichier.Close() : FluxFichier.Dispose()
        Else
            Call SauvegarderOptions()
        End If
    End Sub
End Module
