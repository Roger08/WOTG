Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text

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
                Call Info("Un client vient de se connecter sur le slot #" & IndexActuel & " depuis l'IP " & .IP & ".")
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
            Call ShowInfo(Joueur(index).Nom & "/" & Joueur(index).NomPerso & " vient de se deconnecter")
            ' TODO : Nettoyage des infos du joueur
        End If

        ' TODO : Envoie aux autres client le joueur "vide"

        ' TODO : Afficher aux autres joueur la déconnexion

        With JoueurTemp(index)
            Call Info("Client sur le slot #" & index & " vient de se deconnecter")
            .Socket.Close()
            .Connecte = False
            .EnJeu = False
            .Flux = Nothing
            .Thread.abort()
        End With
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
                        ' Met le paquet dans la file d'attente
                        PaquetData.Add(Paquet(i))

                        temp = Paquet(i).Split(SEP) ' Récupère l'entête
                        PaquetHandler(CByte(temp(0))).Invoke() ' Apelle la fonction correspondante au paquet
                    Next
                End If
            End While
        End With
    End Sub

#Region "Actions enclanchées par des paquets entrants"

#End Region
End Module
