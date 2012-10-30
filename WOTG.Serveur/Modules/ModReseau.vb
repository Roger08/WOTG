Imports System.Net
Imports System.Net.Sockets

Module ModReseau

    ' #######################
    ' ## Gestion du reseau ##
    ' #######################

    Public Sub Init()
        ' Initialisation du socket
        _Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        _Socket.Bind(New IPEndPoint(IPAddress.Any, 6550))
        _Socket.Listen(0)
        Call ShowInfo("Serveur ouvert sur le port 6550")

        ' Lancement de l'écoute
        _Socket.BeginAccept(AddressOf AccepterClient, Nothing)
    End Sub

    Public Sub AccepterClient(ByVal IR As IAsyncResult)
        _Socket.EndAccept(IR)
        Console.WriteLine("Connecté")
        _Socket.BeginAccept(AddressOf AccepterClient, Nothing)
    End Sub
End Module
