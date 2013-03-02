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

    ' - Charge le nom des maps
    Public Sub ChargerNomMaps()
        NomMap = File.ReadAllLines(Application.StartupPath & "/Maps/Maps.txt")

        For i = 0 To MAX_MAPS
            If i < NomMap.Length Then
                frmEditeur.lstMaps.Items.Add(i & " : " & NomMap(i))
            Else
                frmEditeur.lstMaps.Items.Add(i & " : ")
            End If
        Next
    End Sub

    ' - Charge les maps enregistrée
    Public Sub ChargerMap(ByVal mapnum As Integer)
        Dim FluxFichier As Stream
        Dim Deserialiseur As New BinaryFormatter

        'Call Statut("Chargement des maps en cours...")
        'Call StatutMax(MAX_MAPS)
        'For i = 1 To MAX_MAPS
        'Call StatutValeur(i)
        Call NettoyerMap(mapnum)
        If File.Exists("Maps/Map" & mapnum & ".wotg") Then
            FluxFichier = File.OpenRead("Maps/Map" & mapnum & ".wotg")
            Map(mapnum) = CType(Deserialiseur.Deserialize(FluxFichier), MapRec)
            FluxFichier.Close() : FluxFichier.Dispose()
        Else
            'Call TelechargerMap(i)
            'FluxFichier = File.OpenRead("Maps/Map" & i & ".wotg")
            'Map(i) = CType(Deserialiseur.Deserialize(FluxFichier), MapRec)
            'FluxFichier.Close() : FluxFichier.Dispose()
        End If

        'frmEditeur.lstMaps.Items.Add(i & " : " & Map(i).Nom)
        'Application.DoEvents()
        'Next
        'frmChargement.Close()
    End Sub

    ' - Télécharger une map
    Public Sub TelechargerMap(ByVal mapnum As Integer)
        If File.Exists("Maps/Map" & mapnum & ".wotg") Then
            File.Delete("Maps/Map" & mapnum & ".wotg")
        End If
        My.Computer.Network.DownloadFile("http://" & FTP & "/BDDWOTG/MapsEDITEUR/Map" & mapnum & ".wotg", "Maps/Map" & mapnum & ".wotg")
    End Sub

    ' - Sauvegarder la map en local + sur le FTP
    Public Sub SauvegarderMap(ByVal mapnum As Integer)
        Try
            ' --- Sauvegarder LOCALE ---
            Dim FluxFichier As Stream
            Dim Serialiseur As New BinaryFormatter

            FluxFichier = File.Create("Maps/Map" & mapnum & ".wotg")
            Serialiseur.Serialize(FluxFichier, Map(mapnum))
            FluxFichier.Close()

            ' --- Sauvegarde FTP ---
            Try
                My.Computer.Network.UploadFile("Maps/Map" & mapnum & ".wotg", "ftp://" & FTP & "/BDDWOTG/MapsEDITEUR/Map" & mapnum & ".wotg", "hugo.m57", FTPPass)
            Catch
                MsgBox("Accès au serveur FTP impossible...", MsgBoxStyle.Critical, "Erreur")
            End Try
            MsgBox("Map sauvegardée !", MsgBoxStyle.Information, "Sauvegarde")
        Catch
            MsgBox("Erreur lors de la sauvegarde...", MsgBoxStyle.Critical, "Erreur")
        End Try

        ' --- Recharge le nom de la map ---
        frmEditeur.lstMaps.Items.Clear()
        For i = 1 To MAX_MAPS
            frmEditeur.lstMaps.Items.Add(i & " : " & Map(i).Nom)
            Application.DoEvents()
        Next
    End Sub

    ' - Nettoie la structure de la map
    Public Sub NettoyerMap(ByVal mapnum As Integer)
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

    '' - Charge un PNJ
    'Public Sub ChargerPNJ(ByVal num As Integer)
    '    Dim FluxFichier As Stream
    '    Dim Deserialiseur As New BinaryFormatter

    '    My.Computer.Network.DownloadFile("http://" & FTP & "/BDDWOTG/PNJs/PNJ" & num & ".wotg", "temp.wotg")

    '    FluxFichier = File.OpenRead("temp.wotg")
    '    PNJ(num) = CType(Deserialiseur.Deserialize(FluxFichier), PNJRec)
    '    FluxFichier.Close() : FluxFichier.Dispose()

    '    File.Delete("temp.wotg")
    'End Sub

    '' - Charge une Classe
    'Public Sub ChargerClasse(ByVal num As Integer)
    '    Dim FluxFichier As Stream
    '    Dim Deserialiseur As New BinaryFormatter

    '    My.Computer.Network.DownloadFile("http://" & FTP & "/BDDWOTG/Classes/Classe" & num & ".wotg", "temp.wotg")

    '    FluxFichier = File.OpenRead("temp.wotg")
    '    Classe(num) = CType(Deserialiseur.Deserialize(FluxFichier), ClasseRec)
    '    FluxFichier.Close() : FluxFichier.Dispose()

    '    File.Delete("temp.wotg")
    'End Sub

    '' - Charge une Race
    'Public Sub ChargerRace(ByVal num As Integer)
    '    Dim FluxFichier As Stream
    '    Dim Deserialiseur As New BinaryFormatter

    '    My.Computer.Network.DownloadFile("http://" & FTP & "/BDDWOTG/Races/Race" & num & ".wotg", "temp.wotg")

    '    FluxFichier = File.OpenRead("temp.wotg")
    '    Race(num) = CType(Deserialiseur.Deserialize(FluxFichier), RaceRec)
    '    FluxFichier.Close() : FluxFichier.Dispose()

    '    File.Delete("temp.wotg")
    'End Sub
End Module
