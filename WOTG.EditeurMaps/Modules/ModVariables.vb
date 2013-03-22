Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports WOTG.Format.Structures
Imports System.Collections
Imports SFML.Graphics
Imports SFML.Window
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Threading

Module ModVariables

    ' ########################################
    ' ## Déclaration des variables globales ##
    ' ########################################

    ' - Variables reseau
    Public _Socket As Socket
    Public _Flux As NetworkStream
    Public Port As Integer = 2556
    Public MonIndex As Byte
    Public SEP As Char = Chr(0)
    Public FIN As Char = Chr(237)
    Public ListeIndex As New ArrayList
    Public PaquetHandler As New Dictionary(Of Byte, Action(Of String))

    ' - Variables Graphiques
    Public FenetreRendu As RenderWindow
    Public CoucheRendu(6) As RenderTexture
    Public CoucheGrille As RenderTexture
    Public imgSprite As Texture
    Public sprtSprite As Sprite
    Public imgTiles() As Texture
    Public sprtTiles As Sprite
    Public PoliceJeu As Font
    Public MoteurTexte As New clsMoteurTexte
    Public Canvas As New ShapeContainer
    Public RecSelect As New PowerPacks.RectangleShape

    ' - Variables de structures
    Public Joueur() As JoueurRec
    Public JoueurTemp() As JoueurTempRec
    Public Map() As MapRec
    Public Secteur() As SecteurRec
    Public Objet() As ObjetRec
    Public Sort() As SortRec
    Public Quete() As QueteRec
    Public PNJ() As PNJRec
    Public Classe() As ClasseRec
    Public Race() As RaceRec
    Public Options As OptionsRec

    ' - Variables Max
    Public MAX_JOUEURS As Byte = 250
    Public MAX_MAPS As Integer = 500
    Public MAX_MAPX As Byte = 19
    Public MAX_MAPY As Byte = 15
    Public MAX_SECTEURS As Byte = 10
    Public MAX_OBJETS As Integer = 500
    Public MAX_SORTS As Integer = 500
    Public MAX_QUETES As Integer = 500
    Public MAX_PNJS As Integer = 500
    Public MAX_CLASSES As Byte = 12
    Public MAX_RACES As Byte = 6
    Public MAX_MAP_PNJS As Byte = 10

    ' - Variables diverses
    Public VersionEditeur As String = "0.0.1"
    Public FTP As String = "hugo.m57.free.fr"
    Public FTPPass As String = "froggy"
    Public TotalTiles As Byte
    Public FPS As Byte
    Public Minuteur As Byte
    Public NomMap() As String

    ' - Variables d'édition
    Public MapActuelle As Integer
    Public CoucheActuelle As Byte
    Public EnJeu As Boolean = False
    Public PicscreenX As Byte
    Public PicscreenY As Byte
    Public TileCliqué As Boolean
    Public TileClic As Short
    Public PicscreenClic As Boolean
    Public Gomme As Boolean
    Public Grille As Boolean = True

#Region "Strutures"

    <Serializable()>
    Public Structure OptionsRec
        Dim Pseudo As String
        Dim MotDePasse As String
        Dim Memoriser As Boolean
        Dim Clef As String
    End Structure
#End Region
End Module

