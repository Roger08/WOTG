Public Class frmRecherche

    Private Sub frmRecherche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i = 0 To MAX_MAPS
            If i < NomMap.Length Then
                lstMaps.Items.Add(i & " : " & NomMap(i))
            Else
                lstMaps.Items.Add(i & " : ")
            End If
        Next
    End Sub

    Private Sub txtCherche_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCherche.TextChanged
        If Not txtCherche.Text = "" Then
            lstMaps.Items.Clear()
            For i = 0 To MAX_MAPS
                If i < NomMap.Length Then
                    If NomMap(i).ToLower.Contains(txtCherche.Text.ToLower) Then
                        lstMaps.Items.Add(i & " : " & NomMap(i))
                    End If
                End If
            Next
        Else
            lstMaps.Items.Clear()
            For i = 0 To MAX_MAPS
                If i < NomMap.Length Then
                    lstMaps.Items.Add(i & " : " & NomMap(i))
                Else
                    lstMaps.Items.Add(i & " : ")
                End If
            Next
        End If
    End Sub
End Class