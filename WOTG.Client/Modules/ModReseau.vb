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
        ' Initialisation des structures
        Call InitStructures()

        ' Initialisation des paquets
        Call InitPaquets()

        ' Initialisation + connexion du socket
        _Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        _Socket.BeginConnect("localhost", Port, AddressOf ConnectCallBack, Nothing)
    End Sub

    ' - Connexion asynchrone au serveur
    Sub ConnectCallBack(ByVal IR As IAsyncResult)
        _Socket.EndConnect(IR)
        _Flux = New NetworkStream(_Socket)
        Call Gameloop()
    End Sub

    ' - Initialisation des différents paquets provenant du serveur
    Public Sub InitPaquets()
        PaquetHandler.Add(PaquetServeur.BonMSG, AddressOf BonMessage)
        PaquetHandler.Add(PaquetServeur.MauvaisMSG, AddressOf MauvaisMessage)
        PaquetHandler.Add(PaquetServeur.RepConnexion, AddressOf RepConnexion)
        PaquetHandler.Add(PaquetServeur.EnvoieJoueur, AddressOf RecevoirJoueur)
    End Sub

    ' - Deconnecte le client
    Public Sub Deconnexion()
        _Socket.Close()
        _Flux = Nothing
        _Flux.Dispose()
    End Sub

    ' - Envoi de paquet
    Public Sub EnvoyerPaquet(ByVal Paquet As String)
        Dim PaquetByte() As Byte

        If _Socket.Connected Then
            Try
                PaquetByte = ASCIIEncoding.UTF8.GetBytes(Paquet & SEP & FIN)
                _Flux.Write(PaquetByte, 0, PaquetByte.Length)
                _Flux.Flush()
            Catch
                MsgBox("Erreur lors de l'envoi du paquet", MsgBoxStyle.Critical, "Erreur fatale")
                End
            End Try
        End If
    End Sub

    ' - Récéption du paquet
    Public Sub RecevoirPaquets()

        ' - Variables utilisées pour la récéption + le traitement du paquet
        Dim PaquetByte() As Byte
        Dim PaquetString As String
        Dim Paquet() As String
        Dim temp() As String

        ' - Boucle de récéption des paquets
        With _Socket
            While .Connected
                If .Poll(10, SelectMode.SelectRead) And .Available = 0 Then
                    ' Socket serveur semble déconnecté
                    Call Deconnexion()

                ElseIf .Available > 0 Then
                    ' - Socket client semble connecté et à envoyé un paquet
                    ReDim PaquetByte(.Available) ' Défini la taille du paquet
                    _Flux.Read(PaquetByte, 0, PaquetByte.Length) ' Lecture du paquet
                    PaquetString = ASCIIEncoding.UTF8.GetString(PaquetByte) ' Convertion du paquet
                    Paquet = PaquetString.Split(FIN) ' Découpe des paquets possiblement collés

                    ' - Boucle vérifiant que plusieurs paquet ne sont pas collés
                    For i = 0 To Paquet.Length - 2
                        ' - Traite le paquet
                        temp = Paquet(i).Split(SEP) ' Récupère l'entête
                        PaquetHandler(CByte(temp(0)))(Paquet(i)) ' Apelle la fonction correspondante au paquet
                    Next
                End If
            End While
        End With
    End Sub

#Region "Actions enclanchées par les paquets entrants"

    ' - Affichage d'un bon message
    Public Sub BonMessage(ByVal Datas As String)
        ' Récupère le corps du paquet
        Dim Data() As String = Datas.Split(SEP)

        ' Affiche le message
        MsgBox(Data(1), MsgBoxStyle.Information, "Information")
    End Sub

    ' - Affichage d'un mauvais message
    Public Sub MauvaisMessage(ByVal Datas As String)
        ' Récupère le corps du paquet
        Dim Data() As String = Datas.Split(SEP)

        ' Affiche le message
        MsgBox(Data(1), MsgBoxStyle.Critical, "Erreur")
    End Sub

    ' - Valide la connexion du joueur
    Public Sub RepConnexion(ByVal Datas As String)
        ' - Récupère le corps du paquet
        Dim Data() As String = Datas.Split(SEP)

        MonIndex = Data(1)

        ' Connecte le joueur
        If Not Joueur(MonIndex).NomPerso = "" Then
            ' TODO : Connexion
        Else
            MsgBox("création perso")
        End If
    End Sub

    ' - Récéption d'un joueur
    Public Sub RecevoirJoueur(ByVal Datas As String)
        ' - Récupère le corps du paquet
        Dim Data() As String = Datas.Split(SEP)

        Dim tempIndex As Byte = Data(1)

        ' Téléchargement du joueur
        With Joueur(tempIndex)
            .NomPerso = Data(2)
        End With
    End Sub

#End Region

#Region "Actions necessitant des paquets"

    ' - Envoi de la connexion du client
    Public Sub Connexion(ByVal Pseudo As String, ByVal MotDePasse As String)
        If Not Pseudo.Length < 3 Then
            If Not MotDePasse.Length < 3 Then
                Call EnvoyerPaquet(PaquetClient.Connexion & SEP & VersionClient & SEP & Pseudo & SEP & MotDePasse)
            Else
                MsgBox("Votre mot de passe doit faire au moins 3 carractères.", MsgBoxStyle.Critical, "Erreur")
            End If
        Else
            MsgBox("Votre pseudo doit faire au moins 3 carractères.", MsgBoxStyle.Critical, "Erreur")
        End If
    End Sub

#End Region
End Module
