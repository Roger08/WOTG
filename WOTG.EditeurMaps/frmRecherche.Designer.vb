<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecherche
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCherche = New System.Windows.Forms.TextBox()
        Me.lstMaps = New System.Windows.Forms.ListBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCherche)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(342, 58)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Recherche"
        '
        'txtCherche
        '
        Me.txtCherche.Location = New System.Drawing.Point(6, 24)
        Me.txtCherche.Name = "txtCherche"
        Me.txtCherche.Size = New System.Drawing.Size(330, 20)
        Me.txtCherche.TabIndex = 0
        '
        'lstMaps
        '
        Me.lstMaps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstMaps.FormattingEnabled = True
        Me.lstMaps.Location = New System.Drawing.Point(15, 81)
        Me.lstMaps.Name = "lstMaps"
        Me.lstMaps.Size = New System.Drawing.Size(342, 249)
        Me.lstMaps.TabIndex = 1
        '
        'frmRecherche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 341)
        Me.Controls.Add(Me.lstMaps)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmRecherche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rechercher une map"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCherche As System.Windows.Forms.TextBox
    Friend WithEvents lstMaps As System.Windows.Forms.ListBox
End Class
