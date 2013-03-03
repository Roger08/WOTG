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

            For i = 0 To MAX_RACES
                Call Chargerrace(i)
            Next
            Call Success("Races chargées")

            For i = 0 To MAX_MAPS
                Call Chargermap(i)
            Next
            Call Success("Maps chargées")

            Console.WriteLine()
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
            ' Call NettoyerClasse(classenum)
            Call SauvegarderClasse(classenum)
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

    ' - Chargemement d'une race
    Public Sub Chargerrace(ByVal racenum As Byte)
        Dim FluxFichier As Stream
        Dim Deserialiseur As New BinaryFormatter

        If File.Exists("BDD/Races/Race" & racenum & ".wotg") Then
            FluxFichier = File.OpenRead("BDD/Races/Race" & racenum & ".wotg")
            Race(racenum) = CType(Deserialiseur.Deserialize(FluxFichier), RaceRec)
            FluxFichier.Close() : FluxFichier.Dispose()
        Else
            ' Call Nettoyerrace(racenum)
            Call Sauvegarderrace(racenum)
        End If
    End Sub

    ' - Nettoyage d'une race
    Public Sub Nettoyerrace(ByVal racenum As Byte)
        With race(racenum)
            .Nom = vbNullString
            .Description = vbNullString
            .SpawnMap = 0
            .SpawnX = 0
            .SpawnY = 0
        End With
    End Sub

    ' - Sauvegarde d'une race
    Public Sub Sauvegarderrace(ByVal racenum As Byte)
        Dim FluxFichier As Stream
        Dim Serialiseur As New BinaryFormatter

        FluxFichier = File.Create("BDD/Races/Race" & racenum & ".wotg")
        Serialiseur.Serialize(FluxFichier, race(racenum))
        FluxFichier.Close()
    End Sub

    ' - Chargemement d'une map
    Public Sub Chargermap(ByVal mapnum As Integer)
        Dim FluxFichier As Stream
        Dim Deserialiseur As New BinaryFormatter

        If File.Exists("BDD/Maps/Map" & mapnum & ".wotg") Then
            FluxFichier = File.OpenRead("BDD/Maps/Map" & mapnum & ".wotg")
            Map(mapnum) = CType(Deserialiseur.Deserialize(FluxFichier), MapRec)
            FluxFichier.Close() : FluxFichier.Dispose()
        Else
            ' Call Nettoyermap(mapnum)
            Call Sauvegardermap(mapnum)
        End If
    End Sub

    ' - Nettoyage d'une map
    Public Sub Nettoyermap(ByVal mapnum As Integer)
        With Map(mapnum)
            ReDim .Cases(MAX_MAPX, MAX_MAPY)
            ReDim .PNJMap(MAX_MAP_PNJS)

            For x = 0 To MAX_MAPX
                For y = 0 To MAX_MAPY
                    .Cases(x, y).Attribut = 0
                    .Cases(x, y).SolSet = vbNullString
                    .Cases(x, y).Sol = 0
                    .Cases(x, y).Inf1Set = vbNullString
                    .Cases(x, y).Inf1 = 0
                    .Cases(x, y).Inf2Set = vbNullString
                    .Cases(x, y).Inf2 = 0
                    .Cases(x, y).Inf3Set = vbNullString
                    .Cases(x, y).Inf3 = 0
                    .Cases(x, y).Sup1Set = vbNullString
                    .Cases(x, y).Sup1 = 0
                    .Cases(x, y).Sup2Set = vbNullString
                    .Cases(x, y).Sup2 = 0
                    .Cases(x, y).Sup3Set = vbNullString
                    .Cases(x, y).Sup3 = 0
                Next
            Next

            .Nom = vbNullString
            .Haut = 0
            .Bas = 0
            .Droite = 0
            .Gauche = 0
            .Continent = vbNullString
            .Region = vbNullString
            .Secteur = 0
            .Type = 0
        End With
    End Sub

    ' - Sauvegarde d'une map
    Public Sub Sauvegardermap(ByVal mapnum As Integer)
        Dim FluxFichier As Stream
        Dim Serialiseur As New BinaryFormatter

        FluxFichier = File.Create("BDD/Maps/Map" & mapnum & ".wotg")
        Serialiseur.Serialize(FluxFichier, Map(mapnum))
        FluxFichier.Close()
    End Sub
End Module
