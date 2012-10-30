Imports System.Net
Imports System.Net.Sockets
Imports System.Threading.Tasks

Module ModReseau

    ' #######################
    ' ## Gestion du reseau ##
    ' #######################

    Public Sub Init()
        ' Initialisation du socket
        _Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        _Socket.Bind(New IPEndPoint(IPAddress.Any, Port))
        _Socket.Listen(0)
        Call ShowInfo("Serveur ouvert sur le port " & Port)

        ' Lancement de l'écoute
        _Socket.BeginAccept(AddressOf AccepterClient, Nothing)
    End Sub

    Public Sub AccepterClient(ByVal IR As IAsyncResult)
        'Try
        IndexActuel = TrouverSlotOuvert()

        With JoueurTemp(IndexActuel)
            .Socket = _Socket.EndAccept(IR)
            .IP = (CType(.Socket.RemoteEndPoint, IPEndPoint).Address.ToString)
            ListeIndex.Add(IndexActuel)
            .Connecte = True
            Call Info("Un client vient de se connecter sur le slot #" & IndexActuel & " depuis l'IP " & .IP & ".")
            .Flux = New NetworkStream(.Socket)
            .Thread = New task(AddressOf RecevoirPaquets)
            .Thread.Start()
        End With
        'Catch
        'End Try

        _Socket.BeginAccept(AddressOf AccepterClient, Nothing)
    End Sub

    Public Sub RecevoirPaquets()
        Dim index As Byte = ListeIndex(ListeIndex.Count - 1)
        Console.WriteLine(index)
    End Sub
End Module
