Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports WOTG.Format.Structures

Module ModVariables

    ' ########################################
    ' ## Déclaration des variables globales ##
    ' ########################################

    ' - Variables reseau
    Public _Socket As Socket

    ' - Variables de structures
    Public Joueur() As JoueurRec
    Public JoueurTemp() As JoueurTempRec

    ' - Variables diverses
    Public VersionClient As String = "0.0.1"
    Public VersionServeur As String = "0.0.1"
End Module
