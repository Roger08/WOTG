Public Class frmJeu

    Private Sub frmJeu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        EnJeu = False
        Call DechargGraph()
        End
    End Sub

    ' - Gestion des touches
    Private Sub frmJeu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                If Joueur(MonIndex).Y > 0 Then
                    With Joueur(MonIndex)
                        If .Mouv = 0 Then
                            .Y -= 1
                            .Dir = 3
                            .Mouv = 32
                            Camera.Y += 1
                            Call EnvoyerDeplacement()
                        End If
                    End With
                End If
            Case Keys.Down
                If Joueur(MonIndex).Y < MAX_MAPY Then
                    With Joueur(MonIndex)
                        If .Mouv = 0 Then
                            .Y += 1
                            .Dir = 0
                            .Mouv = 32
                            Camera.Y -= 1
                            Call EnvoyerDeplacement()
                        End If
                    End With
                End If
            Case Keys.Left
                If Joueur(MonIndex).X > 0 Then
                    With Joueur(MonIndex)
                        If .Mouv = 0 Then
                            .X -= 1
                            .Dir = 1
                            .Mouv = 32
                            Camera.X += 1
                            Call EnvoyerDeplacement()
                        End If
                    End With
                End If
            Case Keys.Right
                If Joueur(MonIndex).X < MAX_MAPX Then
                    With Joueur(MonIndex)
                        If .Mouv = 0 Then
                            .X += 1
                            .Dir = 2
                            .Mouv = 32
                            Camera.X -= 1
                            Call EnvoyerDeplacement()
                        End If
                    End With
                End If
        End Select
    End Sub

    Private Sub frmJeu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmCreationPerso.Visible Then frmCreationPerso.Close()
        frmLogin.Hide()
        Call InitGraph()
    End Sub

    Private Sub frmJeu_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    End Sub

    Private Sub PicJeu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicJeu.Click

    End Sub
End Class