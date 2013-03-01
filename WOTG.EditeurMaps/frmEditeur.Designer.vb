<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditeur
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditeur))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.picTiles = New System.Windows.Forms.PictureBox()
        Me.PicJeu = New System.Windows.Forms.PictureBox()
        Me.lstMaps = New System.Windows.Forms.ListBox()
        Me.lstTiles = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.EnregistrerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton14 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblPosition = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblFPS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatut = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MettreEnVeilleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformatiosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SauvegarderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActualiserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProprietésToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScreenshotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EcranActuelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MapEntièreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RechercherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CoucheToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Inf1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Inf2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Inf3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sup1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sup2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sup3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.RemplirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AffichageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrilleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrFPS = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.picTiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicJeu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.picTiles)
        Me.Panel1.Location = New System.Drawing.Point(0, 79)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(212, 352)
        Me.Panel1.TabIndex = 17
        '
        'picTiles
        '
        Me.picTiles.Location = New System.Drawing.Point(0, 0)
        Me.picTiles.Name = "picTiles"
        Me.picTiles.Size = New System.Drawing.Size(100, 100)
        Me.picTiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picTiles.TabIndex = 9
        Me.picTiles.TabStop = False
        '
        'PicJeu
        '
        Me.PicJeu.BackColor = System.Drawing.Color.White
        Me.PicJeu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicJeu.Location = New System.Drawing.Point(218, 52)
        Me.PicJeu.Name = "PicJeu"
        Me.PicJeu.Size = New System.Drawing.Size(608, 480)
        Me.PicJeu.TabIndex = 16
        Me.PicJeu.TabStop = False
        '
        'lstMaps
        '
        Me.lstMaps.FormattingEnabled = True
        Me.lstMaps.Location = New System.Drawing.Point(0, 437)
        Me.lstMaps.Name = "lstMaps"
        Me.lstMaps.Size = New System.Drawing.Size(212, 95)
        Me.lstMaps.TabIndex = 15
        '
        'lstTiles
        '
        Me.lstTiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstTiles.FormattingEnabled = True
        Me.lstTiles.Location = New System.Drawing.Point(0, 52)
        Me.lstTiles.Name = "lstTiles"
        Me.lstTiles.Size = New System.Drawing.Size(212, 21)
        Me.lstTiles.TabIndex = 14
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnregistrerToolStripButton, Me.ToolStripSeparator1, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripSeparator2, Me.ToolStripButton6, Me.ToolStripSeparator4, Me.ToolStripButton7, Me.ToolStripButton8, Me.ToolStripButton9, Me.ToolStripSeparator5, Me.ToolStripButton10, Me.ToolStripButton11, Me.ToolStripButton12, Me.ToolStripSeparator6, Me.ToolStripButton13, Me.ToolStripSeparator7, Me.ToolStripButton14, Me.ToolStripSeparator8})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(836, 25)
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'EnregistrerToolStripButton
        '
        Me.EnregistrerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EnregistrerToolStripButton.Image = CType(resources.GetObject("EnregistrerToolStripButton.Image"), System.Drawing.Image)
        Me.EnregistrerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EnregistrerToolStripButton.Name = "EnregistrerToolStripButton"
        Me.EnregistrerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.EnregistrerToolStripButton.Text = "Enregistrer"
        Me.EnregistrerToolStripButton.ToolTipText = "Enregistrer (Ctrl+S)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Remplir la couche (R)"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        Me.ToolStripButton2.ToolTipText = "Vider la couche"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Effacer"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "ToolStripButton4"
        Me.ToolStripButton4.ToolTipText = "Outil Pipette"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "ToolStripButton5"
        Me.ToolStripButton5.ToolTipText = "Afficher/masquer la grille (Ctrl+G)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "ToolStripButton6"
        Me.ToolStripButton6.ToolTipText = "Couche Sol"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Couche Inférieure 1"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton8.Text = "Couche Inférieure 2"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton9.Text = "Couche Inférieure 3"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton10.Text = "Couche Supérieure 1"
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
        Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton11.Text = "Couche Supérieure 2"
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
        Me.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton12.Text = "Couche Supérieure 3"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton13
        '
        Me.ToolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton13.Image = CType(resources.GetObject("ToolStripButton13.Image"), System.Drawing.Image)
        Me.ToolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton13.Text = "Actualiser la map (Ctrl+A)"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton14
        '
        Me.ToolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton14.Image = CType(resources.GetObject("ToolStripButton14.Image"), System.Drawing.Image)
        Me.ToolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton14.Name = "ToolStripButton14"
        Me.ToolStripButton14.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton14.Text = "Mettre en veille"
        Me.ToolStripButton14.ToolTipText = "Mettre en veille (Ctrl+V)"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPosition, Me.ToolStripStatusLabel1, Me.lblFPS, Me.ToolStripStatusLabel2, Me.lblStatut})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(836, 24)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblPosition
        '
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(54, 19)
        Me.lblPosition.Text = "X : 0 Y : 0"
        Me.lblPosition.ToolTipText = "Position du curseur sur le picscreen"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(19, 19)
        Me.ToolStripStatusLabel1.Text = "    "
        '
        'lblFPS
        '
        Me.lblFPS.Name = "lblFPS"
        Me.lblFPS.Size = New System.Drawing.Size(41, 19)
        Me.lblFPS.Text = "FPS : 0"
        Me.lblFPS.ToolTipText = "Images par seconde"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(19, 19)
        Me.ToolStripStatusLabel2.Text = "    "
        '
        'lblStatut
        '
        Me.lblStatut.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatut.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblStatut.ForeColor = System.Drawing.Color.Green
        Me.lblStatut.Name = "lblStatut"
        Me.lblStatut.Size = New System.Drawing.Size(36, 19)
        Me.lblStatut.Text = "Actif"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem, Me.MapToolStripMenuItem, Me.CoucheToolStripMenuItem, Me.AffichageToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(836, 24)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MettreEnVeilleToolStripMenuItem, Me.InformatiosToolStripMenuItem, Me.QuitterToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.FichierToolStripMenuItem.Text = "Editeur"
        '
        'MettreEnVeilleToolStripMenuItem
        '
        Me.MettreEnVeilleToolStripMenuItem.Name = "MettreEnVeilleToolStripMenuItem"
        Me.MettreEnVeilleToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.MettreEnVeilleToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.MettreEnVeilleToolStripMenuItem.Text = "Mettre en veille"
        '
        'InformatiosToolStripMenuItem
        '
        Me.InformatiosToolStripMenuItem.Name = "InformatiosToolStripMenuItem"
        Me.InformatiosToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.InformatiosToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.InformatiosToolStripMenuItem.Text = "Informations"
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'MapToolStripMenuItem
        '
        Me.MapToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SauvegarderToolStripMenuItem, Me.ActualiserToolStripMenuItem, Me.ProprietésToolStripMenuItem, Me.ScreenshotToolStripMenuItem, Me.RechercherToolStripMenuItem})
        Me.MapToolStripMenuItem.Name = "MapToolStripMenuItem"
        Me.MapToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.MapToolStripMenuItem.Text = "Map"
        '
        'SauvegarderToolStripMenuItem
        '
        Me.SauvegarderToolStripMenuItem.Name = "SauvegarderToolStripMenuItem"
        Me.SauvegarderToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SauvegarderToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.SauvegarderToolStripMenuItem.Text = "Sauvegarder"
        '
        'ActualiserToolStripMenuItem
        '
        Me.ActualiserToolStripMenuItem.Name = "ActualiserToolStripMenuItem"
        Me.ActualiserToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.ActualiserToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ActualiserToolStripMenuItem.Text = "Actualiser"
        '
        'ProprietésToolStripMenuItem
        '
        Me.ProprietésToolStripMenuItem.Name = "ProprietésToolStripMenuItem"
        Me.ProprietésToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ProprietésToolStripMenuItem.Text = "Proprietés"
        '
        'ScreenshotToolStripMenuItem
        '
        Me.ScreenshotToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EcranActuelToolStripMenuItem, Me.MapEntièreToolStripMenuItem})
        Me.ScreenshotToolStripMenuItem.Name = "ScreenshotToolStripMenuItem"
        Me.ScreenshotToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ScreenshotToolStripMenuItem.Text = "Screenshot"
        '
        'EcranActuelToolStripMenuItem
        '
        Me.EcranActuelToolStripMenuItem.Name = "EcranActuelToolStripMenuItem"
        Me.EcranActuelToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.EcranActuelToolStripMenuItem.Text = "Ecran de jeu"
        '
        'MapEntièreToolStripMenuItem
        '
        Me.MapEntièreToolStripMenuItem.Name = "MapEntièreToolStripMenuItem"
        Me.MapEntièreToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.MapEntièreToolStripMenuItem.Text = "Map entière"
        '
        'RechercherToolStripMenuItem
        '
        Me.RechercherToolStripMenuItem.Name = "RechercherToolStripMenuItem"
        Me.RechercherToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.RechercherToolStripMenuItem.Text = "Rechercher"
        '
        'CoucheToolStripMenuItem
        '
        Me.CoucheToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SolToolStripMenuItem, Me.Inf1ToolStripMenuItem, Me.Inf2ToolStripMenuItem, Me.Inf3ToolStripMenuItem, Me.Sup1ToolStripMenuItem, Me.Sup2ToolStripMenuItem, Me.Sup3ToolStripMenuItem, Me.ToolStripSeparator9, Me.RemplirToolStripMenuItem, Me.ViderToolStripMenuItem})
        Me.CoucheToolStripMenuItem.Name = "CoucheToolStripMenuItem"
        Me.CoucheToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.CoucheToolStripMenuItem.Text = "Couche"
        '
        'SolToolStripMenuItem
        '
        Me.SolToolStripMenuItem.Name = "SolToolStripMenuItem"
        Me.SolToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.SolToolStripMenuItem.Text = "Sol"
        '
        'Inf1ToolStripMenuItem
        '
        Me.Inf1ToolStripMenuItem.Name = "Inf1ToolStripMenuItem"
        Me.Inf1ToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.Inf1ToolStripMenuItem.Text = "Inférieur 1"
        '
        'Inf2ToolStripMenuItem
        '
        Me.Inf2ToolStripMenuItem.Name = "Inf2ToolStripMenuItem"
        Me.Inf2ToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.Inf2ToolStripMenuItem.Text = "Inférieur 2"
        '
        'Inf3ToolStripMenuItem
        '
        Me.Inf3ToolStripMenuItem.Name = "Inf3ToolStripMenuItem"
        Me.Inf3ToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.Inf3ToolStripMenuItem.Text = "Inférieur 3"
        '
        'Sup1ToolStripMenuItem
        '
        Me.Sup1ToolStripMenuItem.Name = "Sup1ToolStripMenuItem"
        Me.Sup1ToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.Sup1ToolStripMenuItem.Text = "Supérieur 1"
        '
        'Sup2ToolStripMenuItem
        '
        Me.Sup2ToolStripMenuItem.Name = "Sup2ToolStripMenuItem"
        Me.Sup2ToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.Sup2ToolStripMenuItem.Text = "Supérieur 2"
        '
        'Sup3ToolStripMenuItem
        '
        Me.Sup3ToolStripMenuItem.Name = "Sup3ToolStripMenuItem"
        Me.Sup3ToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.Sup3ToolStripMenuItem.Text = "Supérieur 3"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(153, 6)
        '
        'RemplirToolStripMenuItem
        '
        Me.RemplirToolStripMenuItem.Name = "RemplirToolStripMenuItem"
        Me.RemplirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.RemplirToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.RemplirToolStripMenuItem.Text = "Remplir"
        '
        'ViderToolStripMenuItem
        '
        Me.ViderToolStripMenuItem.Name = "ViderToolStripMenuItem"
        Me.ViderToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.ViderToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ViderToolStripMenuItem.Text = "Vider"
        '
        'AffichageToolStripMenuItem
        '
        Me.AffichageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GrilleToolStripMenuItem})
        Me.AffichageToolStripMenuItem.Name = "AffichageToolStripMenuItem"
        Me.AffichageToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.AffichageToolStripMenuItem.Text = "Affichage"
        '
        'GrilleToolStripMenuItem
        '
        Me.GrilleToolStripMenuItem.Name = "GrilleToolStripMenuItem"
        Me.GrilleToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GrilleToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.GrilleToolStripMenuItem.Text = "Grille"
        '
        'tmrFPS
        '
        Me.tmrFPS.Interval = 1000
        '
        'frmEditeur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 564)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PicJeu)
        Me.Controls.Add(Me.lstMaps)
        Me.Controls.Add(Me.lstTiles)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmEditeur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editeur de maps"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picTiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicJeu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PicJeu As System.Windows.Forms.PictureBox
    Friend WithEvents lstMaps As System.Windows.Forms.ListBox
    Friend WithEvents lstTiles As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents EnregistrerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton13 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblPosition As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblFPS As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FichierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActualiserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProprietésToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScreenshotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EcranActuelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MapEntièreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CoucheToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Inf1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Inf2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Inf3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sup1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sup2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sup3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picTiles As System.Windows.Forms.PictureBox
    Friend WithEvents tmrFPS As System.Windows.Forms.Timer
    Friend WithEvents RechercherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MettreEnVeilleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatut As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripButton14 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SauvegarderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AffichageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrilleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RemplirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformatiosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
