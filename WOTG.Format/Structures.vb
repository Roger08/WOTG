Imports System.Net.Sockets
Imports System.IO
Imports System.Threading

Public Class Structures

    ' ######################################
    ' ## Classe de Gestion des structures ##
    ' ######################################

    <Serializable()>
    Public Structure ClasseRec
        Dim Nom As String
        Dim Description As String
    End Structure

    <Serializable()>
    Public Structure RaceRec
        Dim Nom As String
        Dim Description As String
        Dim SpawnMap As Integer
        Dim SpawnX As Byte
        Dim SpawnY As Byte
    End Structure

    Public Structure JoueurTempRec
        Dim Socket As TcpClient
        Dim Flux As NetworkStream
        Dim Thread As Thread
        Dim TempIP As String
        Dim Connecte As Boolean
        Dim EnJeu As Boolean
    End Structure

    <Serializable()>
    Public Structure JoueurRec
        ' Général
        Dim Nom As String
        Dim MotDePasse As String
        Dim IP As String
        Dim Map As Integer
        Dim X As Byte
        Dim Y As Byte
        Dim Dir As Byte
        Dim Mouv As Byte

        Dim NomPerso As String
        Dim Acces As Byte
        Dim Niveau As Byte
        Dim Guilde As Byte
        Dim Classe As Byte
        Dim Race As Byte
        Dim Rang As Byte
        Dim Empire As Byte
        Dim Reputation As Byte
        Dim Bouclier As Boolean

        ' Apparence
        Dim Peau As Byte
        Dim Cheveux As Byte
        Dim Vetements As Byte

        ' Carac
        Dim Max_PV As Long
        Dim PV As Long
        Dim MAX_PM As Long
        Dim PM As Long
        Dim MAX_Exp As Long
        Dim Exp As Long

        Dim Attaque As Integer
        Dim Defense As Integer
        Dim Esquive As Integer
        Dim Precision As Integer
        Dim Force As Integer
        Dim Vital As Integer
        Dim Intelligence As Integer
        Dim Sagesse As Integer
        Dim Resistance As Integer
        Dim Agilite As Integer

        Dim AttaqueMagique As Integer
        Dim AttaqueFeu As Integer
        Dim AttaqueEau As Integer
        Dim AttaqueMetal As Integer
        Dim AttaqueTerre As Integer
        Dim AttaqueBois As Integer
        Dim AttaquePhysique As Integer
        Dim AttaquePersante As Integer
        Dim AttaqueTranchante As Integer
        Dim AttaqueEcrasante As Integer

        Dim ResistanceFeu As Integer
        Dim ResistanceEau As Integer
        Dim ResistanceTerre As Integer
        Dim ResistanceBois As Integer
        Dim ResistanceMetal As Integer
        Dim ResistanceAttaqueTranchante As Integer
        Dim ResistanceAttaqueEcrasante As Integer
        Dim ResistanceAttaquePersantes As Integer

        Dim VitesseDeplacement As Integer
        Dim VitesseAttaque As Integer

        Dim DefenseMagique As Integer
        Dim DefensePhysique As Integer
    End Structure

    <Serializable()>
    Public Structure SecteurRec
        Dim Nom As String
        Dim Guilde As Byte
        Dim Nourriture As Integer
        Dim Bois As Integer
        Dim Pierre As Integer
        Dim POr As Integer
    End Structure

    <Serializable()>
    Public Structure CoucheRec
        Dim Attribut As Byte
        Dim AttributInt1 As Integer
        Dim AttributInt2 As Integer
        Dim AttributInt3 As Integer
        Dim AttributString1 As String
        Dim AttributString2 As String
        Dim SolSet As String
        Dim Sol As Long
        Dim Inf1Set As String
        Dim Inf1 As Long
        Dim Inf2Set As String
        Dim Inf2 As Long
        Dim Inf3Set As String
        Dim Inf3 As Long
        Dim Sup1Set As String
        Dim Sup1 As Long
        Dim Sup2Set As String
        Dim Sup2 As Long
        Dim Sup3Set As String
        Dim Sup3 As Long
    End Structure

    <Serializable()>
    Public Structure PNJMapRec
        Dim num As Integer
        Dim PositionAleatoire As Boolean
        Dim X As Byte
        Dim Y As Byte
        Dim Dir As Byte
        Dim Mouv As Byte
        Dim Immobile As Boolean
    End Structure

    <Serializable()>
    Public Structure MapRec
        Dim Nom As String
        Dim Type As Byte
        Dim Continent As String
        Dim Region As String
        Dim Secteur As Byte

        Dim Cases(,) As CoucheRec
        Dim PNJMap() As PNJMapRec

        Dim Haut As Integer
        Dim Bas As Integer
        Dim Gauche As Integer
        Dim Droite As Integer
    End Structure

    <Serializable()>
    Public Structure ObjetRec
        ' Général
        Dim Nom As String
        Dim Type As Byte
        Dim Description As String

        ' Ajouts
        Dim A_Force As Byte
        Dim A_Vital As Byte
        Dim A_Resistance As Byte
        Dim A_Agilite As Byte
        Dim A_Intelligence As Byte
        Dim A_Sagesse As Byte
        Dim A_PV As Integer
        Dim A_Mana As Integer
        Dim A_Attaque As Integer
        Dim A_Defense As Integer
        Dim A_Esquive As Integer
        Dim A_Precision As Integer

        ' Requis
        Dim R_Niveau As Byte
        Dim R_Classe As Byte
        Dim R_Race As Byte
        Dim R_Guilde As Byte
        Dim R_Empire As Byte
        Dim R_Reputation As Byte
        Dim R_Rang As Byte
        Dim R_Acces As Byte
        Dim R_Force As Byte
        Dim R_Vital As Byte
        Dim R_Resistance As Byte
        Dim R_Agilite As Byte
        Dim R_Intelligence As Byte
        Dim R_Sagesse As Byte
        Dim R_Quete As Integer
    End Structure

    <Serializable()>
    Public Structure SortRec
        ' Général
        Dim Nom As String
        Dim Description As String
        Dim ConsoMana As Integer
        Dim Recharge As Integer

        ' Ajouts
        Dim A_PV As Integer
        Dim A_Mana As Integer

        Dim A_Attaque As Integer
        Dim A_AttaqueSet As Integer
        Dim A_Defense As Integer
        Dim A_DefenseSet As Integer
        Dim A_Esquive As Integer
        Dim A_EsquiveSet As Integer
        Dim A_Precision As Integer
        Dim A_PrecisionSet As Integer
        Dim A_MaxPV As Integer
        Dim A_MaxPVSet As Integer
        Dim A_Force As Byte
        Dim A_ForceSet As Integer
        Dim A_Vital As Byte
        Dim A_VitalSet As Integer
        Dim A_Resistance As Byte
        Dim A_ResistenceSet As Integer
        Dim A_Agilite As Byte
        Dim A_AgiliteSet As Integer
        Dim A_Intelligence As Byte
        Dim A_IntelligenceSet As Integer
        Dim A_Sagesse As Byte
        Dim A_SagesseSet As Integer

        ' Diminution
        Dim D_PV As Integer
        Dim DegatsTranchants As Integer
        Dim DegatsPersants As Integer
        Dim DegatsEcrasants As Integer
        Dim DegatsFeu As Integer
        Dim DegatsTerre As Integer
        Dim DegatsMetal As Integer
        Dim DegatsEau As Integer
        Dim DegatsBois As Integer
        Dim D_Mana As Integer

        Dim D_Attaque As Integer
        Dim D_AttaqueSet As Integer
        Dim D_Defense As Integer
        Dim D_DefenseSet As Integer
        Dim D_Esquive As Integer
        Dim D_EsquiveSet As Integer
        Dim D_Precision As Integer
        Dim D_PrecisionSet As Integer
        Dim D_MaxPV As Integer
        Dim D_MaxPVSet As Integer
        Dim D_Force As Integer
        Dim D_ForceSet As Integer
        Dim D_Vital As Integer
        Dim D_VitalSet As Integer
        Dim D_Resistance As Integer
        Dim D_ResistenceSet As Integer
        Dim D_Agilite As Integer
        Dim D_AgiliteSet As Integer
        Dim D_Intelligence As Integer
        Dim D_IntelligenceSet As Integer
        Dim D_Sagesse As Integer
        Dim D_SagesseSet As Integer

        ' Requis
        Dim R_Niveau As Byte
        Dim R_Classe As Byte
        Dim R_Race As Byte
        Dim R_Guilde As Byte
        Dim R_Empire As Byte
        Dim R_Reputation As Byte
        Dim R_Rang As Byte
        Dim R_Acces As Byte
        Dim R_Force As Byte
        Dim R_Vital As Byte
        Dim R_Resistance As Byte
        Dim R_Agilite As Byte
        Dim R_Intelligence As Byte
        Dim R_Sagesse As Byte
        Dim R_Quete As Integer
        Dim R_Objet As Integer
        Dim R_Sort As Integer
    End Structure

    <Serializable()>
    Public Structure QueteRec
        ' Général
        Dim Nom As String
        Dim Description As String

        ' Récompenses
        Dim Rec_Or As Integer
        Dim Rec_Items() As Integer
        Dim Rec_Experience As Integer

        ' Requis
        Dim R_TuerMonstre() As Integer ' index du monstre
        Dim R_QuantMonstre() As Integer ' quantité du monstre à tuer
        Dim R_Niveau As Byte
        Dim R_Classe As Byte
        Dim R_Race As Byte
        Dim R_Guilde As Byte
        Dim R_Empire As Byte
        Dim R_Reputation As Byte
        Dim R_Rang As Byte
        Dim R_Quete As Integer
        Dim R_Objet As Integer
        Dim R_Sort As Integer

        ' Etapes
        Dim Etape() As EtapeQueteRec
    End Structure

    <Serializable()>
    Public Structure EtapeQueteRec
        ' Général
        Dim Nom As String
        Dim Description As String
        Dim DialoguePNJ1 As String ' avant acceptation l'etape
        Dim DialoguePNJ2 As String ' quand on vient d'accepter
        Dim DialoguePNJ3 As String ' quand quete accepté et qu'on revient
        Dim DialoguePNJ4 As String ' quand on refuse
        Dim DialoguePNJ5 As String ' quand on réussi l'étape
        Dim PNJDonneurEtape As Integer
        Dim Type As Byte

        ' Tuer un / plusieurs PNJ
        Dim Tuer_Index As Integer
        Dim Tuer_Quantite As Byte

        ' Ramener un / plusieurs objets
        Dim Ramener_Index As Integer
        Dim Ramener_Quentite As Byte
        Dim Ramener_Attente As Integer

        ' Effectuer une interaction
        ' Dim Interaction_OK As Boolean
    End Structure

    <Serializable()>
    Public Structure PNJRec
        ' Général
        Dim Nom As String
        Dim Sprite As Integer
        Dim Type As Byte

        ' Carac
        Dim Vision As Byte
        Dim PV As Integer
        Dim AttaquePhysique As Integer
        Dim AttaqueTranchante As Integer
        Dim AttaqueEcrasante As Integer
        Dim AttaquePersante As Integer
        Dim AttaqueFeu As Integer
        Dim AttaqueMetal As Integer
        Dim AttaqueTerre As Integer
        Dim AttaqueEau As Integer
        Dim AttaqueBois As Integer
        Dim Attaque As Integer
        Dim Esquive As Integer
        Dim Force As Integer
        Dim Vital As Integer
        Dim Resistance As Integer
        Dim Agilite As Integer
        Dim Intelligence As Integer
        Dim Sagesse As Integer
        Dim Precision As Integer
        Dim Defense As Integer
        Dim Empire As Byte
        Dim Guilde As Byte
    End Structure

End Class

