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
                If Camera.Y < CInt(MAX_MAPY / 2) - 1 Then
                    Camera.Y += 1
                End If
            Case Keys.Down
                If Camera.Y > CInt((-MAX_MAPY) / 2) + 1 Then
                    Camera.Y -= 1
                End If
            Case Keys.Left
                If Camera.X < CInt(MAX_MAPX / 2) - 1 Then
                    Camera.X += 1
                End If
            Case Keys.Right
                If Camera.X > CInt((-MAX_MAPX) / 2) + 1 Then
                    Camera.X -= 1
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