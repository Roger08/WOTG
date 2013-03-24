Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports WOTG.Format.Structures
Imports System.Collections

Module ModVariables

    ' ########################################
    ' ## Déclaration des variables globales ##
    ' ########################################

    ' - Variables reseau
    Public _Socket As Socket
    Public Port As Integer = 2556
    Public IndexActuel As Byte
    Public SEP As Char = Chr(0)
    Public FIN As Char = Chr(237)
    Public ListeIndex As New ArrayList
    Public PaquetHandler As New Dictionary(Of Byte, Action(Of Byte, String))

    ' - Variables de structures
    Public Joueur() As JoueurRec
    Public JoueurTemp() As JoueurTempRec
    Public Classe() As ClasseRec
    Public Race() As RaceRec
    Public Map() As MapRec

    ' - Variables Max
    Public MAX_JOUEURS As Byte = 250
    Public MAX_MAPS As Integer = 500
    Public MAX_MAPX As Byte = 19
    Public MAX_MAPY As Byte = 15
    Public MAX_SECTEURS As Integer = 10
    Public MAX_OBJETS As Integer = 500
    Public MAX_SORTS As Integer = 500
    Public MAX_QUETES As Integer = 500
    Public MAX_PNJS As Integer = 500
    Public MAX_CLASSES As Byte = 12
    Public MAX_RACES As Byte = 6
    Public MAX_MAP_PNJS As Byte = 10

    ' - Variables diverses
    Public VersionClient As String = "0.0.1"
    Public VersionEditeur As String = "0.0.1"
    Public VersionServeur As String = "0.0.1"
    Public MotDePasseMapeurs As String = "lol"
End Module
