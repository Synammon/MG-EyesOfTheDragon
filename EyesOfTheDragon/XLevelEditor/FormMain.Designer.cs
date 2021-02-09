namespace XLevelEditor
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.charactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabProperties = new System.Windows.Forms.TabControl();
            this.tabTilesets = new System.Windows.Forms.TabPage();
            this.lblTilesets = new System.Windows.Forms.Label();
            this.lbTileset = new System.Windows.Forms.ListBox();
            this.pbTilesetPreview = new System.Windows.Forms.PictureBox();
            this.lblCurrentTileset = new System.Windows.Forms.Label();
            this.nudCurrentTile = new System.Windows.Forms.NumericUpDown();
            this.gbDrawMode = new System.Windows.Forms.GroupBox();
            this.rbErase = new System.Windows.Forms.RadioButton();
            this.rbDraw = new System.Windows.Forms.RadioButton();
            this.lblTile = new System.Windows.Forms.Label();
            this.pbTilePreview = new System.Windows.Forms.PictureBox();
            this.tabLayers = new System.Windows.Forms.TabPage();
            this.clbLayers = new System.Windows.Forms.CheckedListBox();
            this.tabCharacters = new System.Windows.Forms.TabPage();
            this.tabChests = new System.Windows.Forms.TabPage();
            this.tabKeys = new System.Windows.Forms.TabPage();
            this.controlTimer = new System.Windows.Forms.Timer(this.components);
            this.mapDisplay = new XLevelEditor.MapDisplay();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.tabTilesets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTilesetPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentTile)).BeginInit();
            this.gbDrawMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTilePreview)).BeginInit();
            this.tabLayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelToolStripMenuItem,
            this.tilesetToolStripMenuItem,
            this.mapLayerToolStripMenuItem,
            this.charactersToolStripMenuItem,
            this.chestsToolStripMenuItem,
            this.keysToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1383, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // levelToolStripMenuItem
            // 
            this.levelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLevelToolStripMenuItem,
            this.openLevelToolStripMenuItem,
            this.saveLevelToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitEditorToolStripMenuItem});
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Size = new System.Drawing.Size(67, 30);
            this.levelToolStripMenuItem.Text = "&Level";
            // 
            // newLevelToolStripMenuItem
            // 
            this.newLevelToolStripMenuItem.Name = "newLevelToolStripMenuItem";
            this.newLevelToolStripMenuItem.Size = new System.Drawing.Size(202, 34);
            this.newLevelToolStripMenuItem.Text = "&New Level";
            // 
            // openLevelToolStripMenuItem
            // 
            this.openLevelToolStripMenuItem.Name = "openLevelToolStripMenuItem";
            this.openLevelToolStripMenuItem.Size = new System.Drawing.Size(202, 34);
            this.openLevelToolStripMenuItem.Text = "&Open Level";
            // 
            // saveLevelToolStripMenuItem
            // 
            this.saveLevelToolStripMenuItem.Name = "saveLevelToolStripMenuItem";
            this.saveLevelToolStripMenuItem.Size = new System.Drawing.Size(202, 34);
            this.saveLevelToolStripMenuItem.Text = "&Save Level";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(199, 6);
            // 
            // exitEditorToolStripMenuItem
            // 
            this.exitEditorToolStripMenuItem.Name = "exitEditorToolStripMenuItem";
            this.exitEditorToolStripMenuItem.Size = new System.Drawing.Size(202, 34);
            this.exitEditorToolStripMenuItem.Text = "E&xit Editor";
            // 
            // tilesetToolStripMenuItem
            // 
            this.tilesetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTilesetToolStripMenuItem,
            this.openTilesetToolStripMenuItem,
            this.loadTilesetToolStripMenuItem,
            this.removeTilesetToolStripMenuItem});
            this.tilesetToolStripMenuItem.Name = "tilesetToolStripMenuItem";
            this.tilesetToolStripMenuItem.Size = new System.Drawing.Size(77, 30);
            this.tilesetToolStripMenuItem.Text = "&Tileset";
            // 
            // newTilesetToolStripMenuItem
            // 
            this.newTilesetToolStripMenuItem.Name = "newTilesetToolStripMenuItem";
            this.newTilesetToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.newTilesetToolStripMenuItem.Text = "&New Tileset";
            // 
            // openTilesetToolStripMenuItem
            // 
            this.openTilesetToolStripMenuItem.Name = "openTilesetToolStripMenuItem";
            this.openTilesetToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.openTilesetToolStripMenuItem.Text = "&Open Tileset";
            // 
            // loadTilesetToolStripMenuItem
            // 
            this.loadTilesetToolStripMenuItem.Name = "loadTilesetToolStripMenuItem";
            this.loadTilesetToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.loadTilesetToolStripMenuItem.Text = "&Load Tileset";
            // 
            // removeTilesetToolStripMenuItem
            // 
            this.removeTilesetToolStripMenuItem.Name = "removeTilesetToolStripMenuItem";
            this.removeTilesetToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.removeTilesetToolStripMenuItem.Text = "&Remove Tileset";
            // 
            // mapLayerToolStripMenuItem
            // 
            this.mapLayerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLayerToolStripMenuItem,
            this.openLayerToolStripMenuItem,
            this.saveLayerToolStripMenuItem});
            this.mapLayerToolStripMenuItem.Name = "mapLayerToolStripMenuItem";
            this.mapLayerToolStripMenuItem.Size = new System.Drawing.Size(110, 30);
            this.mapLayerToolStripMenuItem.Text = "&Map Layer";
            // 
            // newLayerToolStripMenuItem
            // 
            this.newLayerToolStripMenuItem.Name = "newLayerToolStripMenuItem";
            this.newLayerToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
            this.newLayerToolStripMenuItem.Text = "&New Layer";
            // 
            // openLayerToolStripMenuItem
            // 
            this.openLayerToolStripMenuItem.Name = "openLayerToolStripMenuItem";
            this.openLayerToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
            this.openLayerToolStripMenuItem.Text = "&Open Layer";
            // 
            // saveLayerToolStripMenuItem
            // 
            this.saveLayerToolStripMenuItem.Name = "saveLayerToolStripMenuItem";
            this.saveLayerToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
            this.saveLayerToolStripMenuItem.Text = "&Save Layer";
            // 
            // charactersToolStripMenuItem
            // 
            this.charactersToolStripMenuItem.Name = "charactersToolStripMenuItem";
            this.charactersToolStripMenuItem.Size = new System.Drawing.Size(110, 30);
            this.charactersToolStripMenuItem.Text = "&Characters";
            // 
            // chestsToolStripMenuItem
            // 
            this.chestsToolStripMenuItem.Name = "chestsToolStripMenuItem";
            this.chestsToolStripMenuItem.Size = new System.Drawing.Size(80, 30);
            this.chestsToolStripMenuItem.Text = "C&hests";
            // 
            // keysToolStripMenuItem
            // 
            this.keysToolStripMenuItem.Name = "keysToolStripMenuItem";
            this.keysToolStripMenuItem.Size = new System.Drawing.Size(64, 30);
            this.keysToolStripMenuItem.Text = "&Keys";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 36);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mapDisplay);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabProperties);
            this.splitContainer1.Size = new System.Drawing.Size(1383, 976);
            this.splitContainer1.SplitterDistance = 1099;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabProperties
            // 
            this.tabProperties.Controls.Add(this.tabTilesets);
            this.tabProperties.Controls.Add(this.tabLayers);
            this.tabProperties.Controls.Add(this.tabCharacters);
            this.tabProperties.Controls.Add(this.tabChests);
            this.tabProperties.Controls.Add(this.tabKeys);
            this.tabProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProperties.Location = new System.Drawing.Point(0, 0);
            this.tabProperties.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.SelectedIndex = 0;
            this.tabProperties.Size = new System.Drawing.Size(278, 976);
            this.tabProperties.TabIndex = 1;
            // 
            // tabTilesets
            // 
            this.tabTilesets.Controls.Add(this.lblTilesets);
            this.tabTilesets.Controls.Add(this.lbTileset);
            this.tabTilesets.Controls.Add(this.pbTilesetPreview);
            this.tabTilesets.Controls.Add(this.lblCurrentTileset);
            this.tabTilesets.Controls.Add(this.nudCurrentTile);
            this.tabTilesets.Controls.Add(this.gbDrawMode);
            this.tabTilesets.Controls.Add(this.lblTile);
            this.tabTilesets.Controls.Add(this.pbTilePreview);
            this.tabTilesets.Location = new System.Drawing.Point(4, 33);
            this.tabTilesets.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabTilesets.Name = "tabTilesets";
            this.tabTilesets.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabTilesets.Size = new System.Drawing.Size(270, 939);
            this.tabTilesets.TabIndex = 0;
            this.tabTilesets.Text = "Tiles";
            this.tabTilesets.UseVisualStyleBackColor = true;
            // 
            // lblTilesets
            // 
            this.lblTilesets.Location = new System.Drawing.Point(10, 482);
            this.lblTilesets.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTilesets.Name = "lblTilesets";
            this.lblTilesets.Size = new System.Drawing.Size(248, 34);
            this.lblTilesets.TabIndex = 7;
            this.lblTilesets.Text = "Tilesets";
            this.lblTilesets.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbTileset
            // 
            this.lbTileset.FormattingEnabled = true;
            this.lbTileset.ItemHeight = 24;
            this.lbTileset.Location = new System.Drawing.Point(10, 528);
            this.lbTileset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbTileset.Name = "lbTileset";
            this.lbTileset.Size = new System.Drawing.Size(246, 388);
            this.lbTileset.TabIndex = 6;
            // 
            // pbTilesetPreview
            // 
            this.pbTilesetPreview.Location = new System.Drawing.Point(10, 207);
            this.pbTilesetPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbTilesetPreview.Name = "pbTilesetPreview";
            this.pbTilesetPreview.Size = new System.Drawing.Size(248, 270);
            this.pbTilesetPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTilesetPreview.TabIndex = 5;
            this.pbTilesetPreview.TabStop = false;
            // 
            // lblCurrentTileset
            // 
            this.lblCurrentTileset.Location = new System.Drawing.Point(10, 168);
            this.lblCurrentTileset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentTileset.Name = "lblCurrentTileset";
            this.lblCurrentTileset.Size = new System.Drawing.Size(248, 34);
            this.lblCurrentTileset.TabIndex = 4;
            this.lblCurrentTileset.Text = "Current Tileset";
            this.lblCurrentTileset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nudCurrentTile
            // 
            this.nudCurrentTile.Location = new System.Drawing.Point(10, 124);
            this.nudCurrentTile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudCurrentTile.Name = "nudCurrentTile";
            this.nudCurrentTile.Size = new System.Drawing.Size(248, 29);
            this.nudCurrentTile.TabIndex = 3;
            // 
            // gbDrawMode
            // 
            this.gbDrawMode.Controls.Add(this.rbErase);
            this.gbDrawMode.Controls.Add(this.rbDraw);
            this.gbDrawMode.Location = new System.Drawing.Point(87, 10);
            this.gbDrawMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbDrawMode.Name = "gbDrawMode";
            this.gbDrawMode.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbDrawMode.Size = new System.Drawing.Size(176, 105);
            this.gbDrawMode.TabIndex = 2;
            this.gbDrawMode.TabStop = false;
            this.gbDrawMode.Text = "Draw Mode";
            // 
            // rbErase
            // 
            this.rbErase.AutoSize = true;
            this.rbErase.Location = new System.Drawing.Point(10, 64);
            this.rbErase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbErase.Name = "rbErase";
            this.rbErase.Size = new System.Drawing.Size(84, 28);
            this.rbErase.TabIndex = 1;
            this.rbErase.Text = "Erase";
            this.rbErase.UseVisualStyleBackColor = true;
            // 
            // rbDraw
            // 
            this.rbDraw.AutoSize = true;
            this.rbDraw.Checked = true;
            this.rbDraw.Location = new System.Drawing.Point(10, 30);
            this.rbDraw.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbDraw.Name = "rbDraw";
            this.rbDraw.Size = new System.Drawing.Size(78, 28);
            this.rbDraw.TabIndex = 0;
            this.rbDraw.TabStop = true;
            this.rbDraw.Text = "Draw";
            this.rbDraw.UseVisualStyleBackColor = true;
            // 
            // lblTile
            // 
            this.lblTile.Location = new System.Drawing.Point(10, 10);
            this.lblTile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTile.Name = "lblTile";
            this.lblTile.Size = new System.Drawing.Size(69, 26);
            this.lblTile.TabIndex = 1;
            this.lblTile.Text = "Tile";
            this.lblTile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbTilePreview
            // 
            this.pbTilePreview.Location = new System.Drawing.Point(10, 40);
            this.pbTilePreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbTilePreview.Name = "pbTilePreview";
            this.pbTilePreview.Size = new System.Drawing.Size(69, 75);
            this.pbTilePreview.TabIndex = 0;
            this.pbTilePreview.TabStop = false;
            // 
            // tabLayers
            // 
            this.tabLayers.Controls.Add(this.clbLayers);
            this.tabLayers.Location = new System.Drawing.Point(4, 33);
            this.tabLayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabLayers.Name = "tabLayers";
            this.tabLayers.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabLayers.Size = new System.Drawing.Size(270, 939);
            this.tabLayers.TabIndex = 1;
            this.tabLayers.Text = "Map Layers";
            this.tabLayers.UseVisualStyleBackColor = true;
            // 
            // clbLayers
            // 
            this.clbLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbLayers.FormattingEnabled = true;
            this.clbLayers.Location = new System.Drawing.Point(4, 4);
            this.clbLayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clbLayers.Name = "clbLayers";
            this.clbLayers.Size = new System.Drawing.Size(262, 931);
            this.clbLayers.TabIndex = 0;
            // 
            // tabCharacters
            // 
            this.tabCharacters.Location = new System.Drawing.Point(4, 33);
            this.tabCharacters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCharacters.Name = "tabCharacters";
            this.tabCharacters.Size = new System.Drawing.Size(270, 939);
            this.tabCharacters.TabIndex = 2;
            this.tabCharacters.Text = "Characters";
            this.tabCharacters.UseVisualStyleBackColor = true;
            // 
            // tabChests
            // 
            this.tabChests.Location = new System.Drawing.Point(4, 33);
            this.tabChests.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabChests.Name = "tabChests";
            this.tabChests.Size = new System.Drawing.Size(270, 939);
            this.tabChests.TabIndex = 3;
            this.tabChests.Text = "Chests";
            this.tabChests.UseVisualStyleBackColor = true;
            // 
            // tabKeys
            // 
            this.tabKeys.Location = new System.Drawing.Point(4, 33);
            this.tabKeys.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabKeys.Name = "tabKeys";
            this.tabKeys.Size = new System.Drawing.Size(270, 939);
            this.tabKeys.TabIndex = 4;
            this.tabKeys.Text = "Keys";
            this.tabKeys.UseVisualStyleBackColor = true;
            // 
            // mapDisplay
            // 
            this.mapDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapDisplay.Location = new System.Drawing.Point(0, 0);
            this.mapDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.mapDisplay.MouseHoverUpdatesOnly = false;
            this.mapDisplay.Name = "mapDisplay";
            this.mapDisplay.Size = new System.Drawing.Size(1099, 976);
            this.mapDisplay.TabIndex = 0;
            this.mapDisplay.Text = "mapDisplay1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 1012);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Level Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabProperties.ResumeLayout(false);
            this.tabTilesets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTilesetPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentTile)).EndInit();
            this.gbDrawMode.ResumeLayout(false);
            this.gbDrawMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTilePreview)).EndInit();
            this.tabLayers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem charactersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keysToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MapDisplay mapDisplay;
        private System.Windows.Forms.TabControl tabProperties;
        private System.Windows.Forms.TabPage tabTilesets;
        private System.Windows.Forms.TabPage tabLayers;
        private System.Windows.Forms.TabPage tabCharacters;
        private System.Windows.Forms.TabPage tabChests;
        private System.Windows.Forms.TabPage tabKeys;
        private System.Windows.Forms.Label lblTilesets;
        private System.Windows.Forms.ListBox lbTileset;
        private System.Windows.Forms.PictureBox pbTilesetPreview;
        private System.Windows.Forms.Label lblCurrentTileset;
        private System.Windows.Forms.NumericUpDown nudCurrentTile;
        private System.Windows.Forms.GroupBox gbDrawMode;
        private System.Windows.Forms.RadioButton rbErase;
        private System.Windows.Forms.RadioButton rbDraw;
        private System.Windows.Forms.Label lblTile;
        private System.Windows.Forms.PictureBox pbTilePreview;
        private System.Windows.Forms.ToolStripMenuItem removeTilesetToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox clbLayers;
        private System.Windows.Forms.Timer controlTimer;
    }
}