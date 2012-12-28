<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChargement
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.StatutBar = New System.Windows.Forms.ProgressBar()
        Me.lblStatut = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'StatutBar
        '
        Me.StatutBar.Location = New System.Drawing.Point(13, 41)
        Me.StatutBar.Name = "StatutBar"
        Me.StatutBar.Size = New System.Drawing.Size(256, 12)
        Me.StatutBar.TabIndex = 3
        '
        'lblStatut
        '
        Me.lblStatut.BackColor = System.Drawing.Color.Transparent
        Me.lblStatut.Location = New System.Drawing.Point(10, 5)
        Me.lblStatut.Name = "lblStatut"
        Me.lblStatut.Size = New System.Drawing.Size(254, 19)
        Me.lblStatut.TabIndex = 2
        Me.lblStatut.Text = "Chargement..."
        Me.lblStatut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmChargement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 59)
        Me.Controls.Add(Me.StatutBar)
        Me.Controls.Add(Me.lblStatut)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmChargement"
        Me.Text = "frmChargement"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StatutBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblStatut As System.Windows.Forms.Label
End Class
