Module ModProgramme

    ' ####################################
    ' ## Module de gestion du programme ##
    ' ####################################

    ' - Affiche un statut
    Public Sub Statut(ByVal Texte As String)
        frmChargement.Show()
        frmChargement.lblStatut.Text = Texte
    End Sub

    ' - Change la valeur max du statut
    Public Sub StatutMax(ByVal Max As Integer)
        frmChargement.StatutBar.Maximum = Max
    End Sub

    ' - Change la valeur du statut
    Public Sub StatutValeur(ByVal Valeur As Integer)
        frmChargement.StatutBar.Value = Valeur
    End Sub
End Module
