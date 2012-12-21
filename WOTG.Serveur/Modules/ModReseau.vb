﻿Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text
Imports System.IO

Module ModReseau

    ' #######################
    ' ## Gestion du reseau ##
    ' #######################

    ' - Initialisation du protocole réseau
    Public Sub Init()
        ' Initialisation des paquets
        Call InitPaquets()

        ' Initialisation du socket
        _Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        _Socket.Bind(New IPEndPoint(IPAddress.Any, Port))
        _Socket.Listen(0)
        Call ShowInfo("Serveur ouvert sur le port " & Port)

        ' Lancement de l'écoute
        _Socket.BeginAccept(AddressOf AccepterClient, Nothing)
    End Sub

    ' - Initialisation des différents paquets provenant du client
    Public Sub InitPaquets()
        PaquetHandler.Add(PaquetClient.Connexion, AddressOf Connexion)
        PaquetHandler.Add(PaquetClient.Inscription, AddressOf Inscription)
    End Sub

    ' - Accepte un client de manière asynchrone
    Public Sub AccepterClient(ByVal IR As IAsyncResult)
        Try
            IndexActuel = TrouverSlotOuvert()

            With JoueurTemp(IndexActuel)
                .Socket = _Socket.EndAccept(IR)
                .IP = (CType(.Socket.RemoteEndPoint, IPEndPoint).Address.ToString)
                ListeIndex.Add(IndexActuel)
                .Connecte = True
                Call ShowConnexion("Un client vient de se connecter sur le slot #" & IndexActuel & " depuis l'IP " & .IP & ".")
                .Flux = New NetworkStream(.Socket)
                .Thread = New thread(AddressOf RecevoirPaquets)
                .Thread.Start()
            End With
        Catch
        End Try

        _Socket.BeginAccept(AddressOf AccepterClient, Nothing)
    End Sub

    ' - Déconnecte un client
    Public Sub Deconnexion(ByVal index)
        Dim tempPseudo As String = Joueur(index).NomPerso
        ListeIndex.Remove(index)

        If Not Joueur(index).Nom = Nothing Then
            Call ShowDeconnexion(Joueur(index).Nom & "/" & Joueur(index).NomPerso & " vient de se deconnecter")
            ' TODO : Nettoyage des infos du joueur
        End If

        ' TODO : Envoie aux autres client le joueur "vide"

        ' TODO : Afficher aux autres joueur la déconnexion

        With JoueurTemp(index)
            Call ShowDeconnexion("Client sur le slot #" & index & " vient de se deconnecter")
            .Socket.Close()
            .Connecte = False
            .EnJeu = False
            .Flux = Nothing
            .Thread.abort()
        End With
    End Sub

    ' - Envoyer un paquet à tous les clients
    Public Sub EnvoyerTousClients(ByVal Paquet As String)
        For i = 0 To ListeIndex.Count - 1
            Call EnvoyerPaquet(ListeIndex(i), Paquet)
        Next
    End Sub

    ' - Envoyer un paquet à tous les joueurs
    Public Sub EnvoyerTousJoueurs(ByVal Paquet As String)
        For i = 0 To ListeIndex.Count - 1
            If JoueurTemp(ListeIndex(i)).EnJeu Then
                Call EnvoyerPaquet(ListeIndex(i), Paquet)
            End If
        Next
    End Sub

    ' - Envoyer un Paquet à un client
    Public Sub EnvoyerPaquet(ByVal index As Byte, ByVal Paquet As String)
        Dim PaquetByte() As Byte

        If JoueurTemp(index).Connecte Then
            Try
                PaquetByte = ASCIIEncoding.UTF8.GetBytes(Paquet & SEP & FIN)
                JoueurTemp(index).Flux.Write(PaquetByte, 0, PaquetByte.Length)
                JoueurTemp(index).Flux.Flush()
                Thread.Sleep(5)
            Catch
                Call Erreur("Erreur lors de l'envoie du paquet au client #" & index)
            End Try
        End If
    End Sub

    ' - Récéption du paquet
    Public Sub RecevoirPaquets()
        Dim index As Byte = ListeIndex(ListeIndex.Count - 1)

        ' - Variables utilisées pour la récéption + le traitement du paquet
        Dim PaquetByte() As Byte
        Dim PaquetString As String
        Dim Paquet() As String
        Dim temp() As String

        ' - Boucle de récéption des paquets
        With JoueurTemp(index)
            While .Socket.Connected
                If .Socket.Poll(10, SelectMode.SelectRead) And .Socket.Available = 0 Then
                    ' Socket client semble déconnecté
                    Call Deconnexion(index)

                ElseIf .Socket.Available > 0 Then
                    ' - Socket client semble connecté et à envoyé un paquet
                    ReDim PaquetByte(.Socket.Available) ' Défini la taille du paquet
                    .Flux.Read(PaquetByte, 0, PaquetByte.Length) ' Lecture du paquet
                    PaquetString = ASCIIEncoding.UTF8.GetString(PaquetByte) ' Convertion du paquet
                    Paquet = PaquetString.Split(FIN) ' Découpe des paquets possiblement collés

                    ' - Boucle vérifiant que plusieurs paquet ne sont pas collés
                    For i = 0 To Paquet.Length - 2
                        ' - Traite le paquet
                        temp = Paquet(i).Split(SEP) ' Récupère l'entête
                        PaquetHandler(CByte(temp(0)))(index, Paquet(i)) ' Apelle la fonction correspondante au paquet
                    Next
                End If
            End While
        End With
    End Sub

#Region "Actions enclanchées par des paquets entrants"

    ' - Connexion d'un joueur
    Public Sub Connexion(ByVal index As Byte, ByVal Datas As String)
        ' Récupère le corps du paquet
        Dim Data() As String = Datas.Split(SEP)

        If Data(1) = VersionClient Then ' vérifie la version du joueur
            If File.Exists("Comptes/" & Data(2).ToLower & ".wotg") Then ' vérifie l'existance du joueur
                Call ChargerJoueur(index, Data(2)) ' charge le joueur
                If Joueur(index).MotDePasse = Data(3) Then ' vérifie le mot de passe
                    If Not JoueurConnecté(Data(2)) Then
                        JoueurTemp(index).EnJeu = True
                        Call EnvoyerJoueurs(index)
                        Call EnvoyerPaquet(index, PaquetServeur.RepConnexion & SEP & index)
                        Call ShowConnexion(Joueur(index).Nom & "/" & Joueur(index).NomPerso & " vient de se connecter.")
                    Else
                        Call EnvoyerMauvaisMessage(index, "Le joueur est déjà connecté.")
                        Exit Sub
                    End If
                Else
                    Call EnvoyerMauvaisMessage(index, "Mot de passe incorrect.")
                    Exit Sub
                End If
            Else
                Call EnvoyerMauvaisMessage(index, "Le compte n'existe pas.")
                Exit Sub
            End If
        Else
            Call EnvoyerMauvaisMessage(index, "Votre version n'est pas à jour, mettez le à jour. Si le problème persiste, retéléchargez le jeu.")
            Exit Sub
        End If
    End Sub

    ' - Inscription d'un joueur
    Public Sub Inscription(ByVal index As Byte, ByVal Datas As String)
        ' Récupère le corps du paquet
        Dim Data() As String = Datas.Split(SEP)

        If Not Data(1).Length < 3 Or Not Data(2).Length < 3 Then
            If Not File.Exists("Comptes/" & Data(1).ToLower & ".wotg") Then
                Joueur(index).Nom = Data(1)
                Joueur(index).MotDePasse = Data(2)
                Call SauvegarderJoueur(index)
                Call Info("Le compte " & Data(1) & " vient d'être créé")
                Call ViderJoueur(index)
                Call EnvoyerBonMessage(index, "Votre compte vient d'être créé !")
            Else
                Call EnvoyerMauvaisMessage(index, "Le compte existe déjà !")
            End If
        End If
    End Sub

#End Region

#Region "Action necessitant des paquets"

    ' - Envoie d'un "bon message"
    Public Sub EnvoyerBonMessage(ByVal index As Byte, ByVal Message As String)
        Call EnvoyerPaquet(index, PaquetServeur.BonMSG & SEP & Message)
    End Sub

    ' - Envoie d'un "mauvais message"
    Public Sub EnvoyerMauvaisMessage(ByVal index As Byte, ByVal Message As String)
        Call EnvoyerPaquet(index, PaquetServeur.MauvaisMSG & SEP & Message)
    End Sub

    ' - Envoie d'un joueur au client
    Public Sub EnvoyerJoueur(ByVal index As Byte, ByVal indexE As Byte)
        With Joueur(indexE)
            Call EnvoyerPaquet(index, PaquetServeur.EnvoieJoueur & SEP & indexE & SEP & .Nom & SEP & .NomPerso)
        End With
    End Sub

    ' - Envoie de tous les joueurs à un joueur
    Public Sub EnvoyerJoueurs(ByVal index As Byte)
        For i = 0 To ListeIndex.Count - 1
            If JoueurTemp(ListeIndex(i)).EnJeu Then
                Call EnvoyerJoueur(index, ListeIndex(i))
            End If
        Next
    End Sub
#End Region
End Module
