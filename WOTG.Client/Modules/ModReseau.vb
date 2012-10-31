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

        ' Initialisation + connexion du socket
        _Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        _Socket.BeginConnect("localhost", Port, AddressOf ConnectCallBack, Nothing)
    End Sub

    ' - Connexion asynchrone au serveur
    Sub ConnectCallBack(ByVal IR As IAsyncResult)
        _Socket.EndConnect(IR)
    End Sub

    ' - Initialisation des différents paquets provenant du client
    Public Sub InitPaquets()

    End Sub
End Module
