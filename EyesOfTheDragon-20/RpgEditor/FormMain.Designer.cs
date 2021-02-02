
namespace RpgEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.armorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weaponToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.classesToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.keysToolStripMenuItem,
            this.chestsToolStripMenuItem,
            this.skillsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1621, 37);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.openGameToolStripMenuItem,
            this.saveGameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(209, 34);
            this.newGameToolStripMenuItem.Text = "&New Game";
            // 
            // openGameToolStripMenuItem
            // 
            this.openGameToolStripMenuItem.Name = "openGameToolStripMenuItem";
            this.openGameToolStripMenuItem.Size = new System.Drawing.Size(209, 34);
            this.openGameToolStripMenuItem.Text = "&Open Game";
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(209, 34);
            this.saveGameToolStripMenuItem.Text = "&Save Game";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(206, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(209, 34);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // classesToolStripMenuItem
            // 
            this.classesToolStripMenuItem.Enabled = false;
            this.classesToolStripMenuItem.Name = "classesToolStripMenuItem";
            this.classesToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.classesToolStripMenuItem.Text = "&Classes";
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.armorToolStripMenuItem,
            this.shieldToolStripMenuItem,
            this.weaponToolStripMenuItem});
            this.itemsToolStripMenuItem.Enabled = false;
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(72, 29);
            this.itemsToolStripMenuItem.Text = "&Items";
            // 
            // armorToolStripMenuItem
            // 
            this.armorToolStripMenuItem.Name = "armorToolStripMenuItem";
            this.armorToolStripMenuItem.Size = new System.Drawing.Size(180, 34);
            this.armorToolStripMenuItem.Text = "&Armor";
            // 
            // shieldToolStripMenuItem
            // 
            this.shieldToolStripMenuItem.Name = "shieldToolStripMenuItem";
            this.shieldToolStripMenuItem.Size = new System.Drawing.Size(180, 34);
            this.shieldToolStripMenuItem.Text = "&Shield";
            // 
            // weaponToolStripMenuItem
            // 
            this.weaponToolStripMenuItem.Name = "weaponToolStripMenuItem";
            this.weaponToolStripMenuItem.Size = new System.Drawing.Size(180, 34);
            this.weaponToolStripMenuItem.Text = "&Weapon";
            // 
            // keysToolStripMenuItem
            // 
            this.keysToolStripMenuItem.Enabled = false;
            this.keysToolStripMenuItem.Name = "keysToolStripMenuItem";
            this.keysToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.keysToolStripMenuItem.Text = "&Keys";
            // 
            // chestsToolStripMenuItem
            // 
            this.chestsToolStripMenuItem.Enabled = false;
            this.chestsToolStripMenuItem.Name = "chestsToolStripMenuItem";
            this.chestsToolStripMenuItem.Size = new System.Drawing.Size(80, 29);
            this.chestsToolStripMenuItem.Text = "C&hests";
            // 
            // skillsToolStripMenuItem
            // 
            this.skillsToolStripMenuItem.Enabled = false;
            this.skillsToolStripMenuItem.Name = "skillsToolStripMenuItem";
            this.skillsToolStripMenuItem.Size = new System.Drawing.Size(67, 29);
            this.skillsToolStripMenuItem.Text = "&Skills";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1621, 851);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eyes of the Dragon Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem armorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weaponToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skillsToolStripMenuItem;
    }
}

