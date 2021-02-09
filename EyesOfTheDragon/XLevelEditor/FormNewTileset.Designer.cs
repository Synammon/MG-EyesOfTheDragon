namespace XLevelEditor
{
    partial class FormNewTileset
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
            this.lblTilesetName = new System.Windows.Forms.Label();
            this.tbTilesetName = new System.Windows.Forms.TextBox();
            this.lblTilesetImageName = new System.Windows.Forms.Label();
            this.tbTilesetImage = new System.Windows.Forms.TextBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.lblTileWidth = new System.Windows.Forms.Label();
            this.mtbTileWidth = new System.Windows.Forms.MaskedTextBox();
            this.lblTileHeight = new System.Windows.Forms.Label();
            this.mtbTileHeight = new System.Windows.Forms.MaskedTextBox();
            this.lblTilesWide = new System.Windows.Forms.Label();
            this.mtbTilesWide = new System.Windows.Forms.MaskedTextBox();
            this.lblTilesHigh = new System.Windows.Forms.Label();
            this.mtbTilesHigh = new System.Windows.Forms.MaskedTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTilesetName
            // 
            this.lblTilesetName.AutoSize = true;
            this.lblTilesetName.Location = new System.Drawing.Point(54, 10);
            this.lblTilesetName.Name = "lblTilesetName";
            this.lblTilesetName.Size = new System.Drawing.Size(95, 17);
            this.lblTilesetName.TabIndex = 0;
            this.lblTilesetName.Text = "Tileset Name:";
            // 
            // tbTilesetName
            // 
            this.tbTilesetName.Location = new System.Drawing.Point(155, 5);
            this.tbTilesetName.Name = "tbTilesetName";
            this.tbTilesetName.Size = new System.Drawing.Size(100, 22);
            this.tbTilesetName.TabIndex = 1;
            // 
            // lblTilesetImageName
            // 
            this.lblTilesetImageName.AutoSize = true;
            this.lblTilesetImageName.Location = new System.Drawing.Point(12, 40);
            this.lblTilesetImageName.Name = "lblTilesetImageName";
            this.lblTilesetImageName.Size = new System.Drawing.Size(137, 17);
            this.lblTilesetImageName.TabIndex = 2;
            this.lblTilesetImageName.Text = "Tileset Image Name:";
            // 
            // tbTilesetImage
            // 
            this.tbTilesetImage.Enabled = false;
            this.tbTilesetImage.Location = new System.Drawing.Point(155, 34);
            this.tbTilesetImage.Name = "tbTilesetImage";
            this.tbTilesetImage.Size = new System.Drawing.Size(100, 22);
            this.tbTilesetImage.TabIndex = 3;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(261, 34);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(28, 23);
            this.btnSelectImage.TabIndex = 4;
            this.btnSelectImage.Tag = "";
            this.btnSelectImage.Text = "...";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            // 
            // lblTileWidth
            // 
            this.lblTileWidth.AutoSize = true;
            this.lblTileWidth.Location = new System.Drawing.Point(74, 69);
            this.lblTileWidth.Name = "lblTileWidth";
            this.lblTileWidth.Size = new System.Drawing.Size(75, 17);
            this.lblTileWidth.TabIndex = 5;
            this.lblTileWidth.Text = "Tile Width:";
            // 
            // mtbTileWidth
            // 
            this.mtbTileWidth.Location = new System.Drawing.Point(155, 62);
            this.mtbTileWidth.Mask = "000";
            this.mtbTileWidth.Name = "mtbTileWidth";
            this.mtbTileWidth.Size = new System.Drawing.Size(34, 22);
            this.mtbTileWidth.TabIndex = 6;
            // 
            // lblTileHeight
            // 
            this.lblTileHeight.AutoSize = true;
            this.lblTileHeight.Location = new System.Drawing.Point(69, 93);
            this.lblTileHeight.Name = "lblTileHeight";
            this.lblTileHeight.Size = new System.Drawing.Size(80, 17);
            this.lblTileHeight.TabIndex = 7;
            this.lblTileHeight.Text = "Tile Height:";
            // 
            // mtbTileHeight
            // 
            this.mtbTileHeight.Location = new System.Drawing.Point(155, 90);
            this.mtbTileHeight.Mask = "000";
            this.mtbTileHeight.Name = "mtbTileHeight";
            this.mtbTileHeight.Size = new System.Drawing.Size(34, 22);
            this.mtbTileHeight.TabIndex = 8;
            // 
            // lblTilesWide
            // 
            this.lblTilesWide.AutoSize = true;
            this.lblTilesWide.Location = new System.Drawing.Point(17, 121);
            this.lblTilesWide.Name = "lblTilesWide";
            this.lblTilesWide.Size = new System.Drawing.Size(132, 17);
            this.lblTilesWide.TabIndex = 9;
            this.lblTilesWide.Text = "Number Tiles Wide:";
            // 
            // mtbTilesWide
            // 
            this.mtbTilesWide.Location = new System.Drawing.Point(155, 118);
            this.mtbTilesWide.Mask = "000";
            this.mtbTilesWide.Name = "mtbTilesWide";
            this.mtbTilesWide.Size = new System.Drawing.Size(34, 22);
            this.mtbTilesWide.TabIndex = 10;
            // 
            // lblTilesHigh
            // 
            this.lblTilesHigh.AutoSize = true;
            this.lblTilesHigh.Location = new System.Drawing.Point(20, 150);
            this.lblTilesHigh.Name = "lblTilesHigh";
            this.lblTilesHigh.Size = new System.Drawing.Size(129, 17);
            this.lblTilesHigh.TabIndex = 11;
            this.lblTilesHigh.Text = "Number Tiles High:";
            // 
            // mtbTilesHigh
            // 
            this.mtbTilesHigh.Location = new System.Drawing.Point(155, 147);
            this.mtbTilesHigh.Mask = "000";
            this.mtbTilesHigh.Name = "mtbTilesHigh";
            this.mtbTilesHigh.Size = new System.Drawing.Size(33, 22);
            this.mtbTilesHigh.TabIndex = 12;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(57, 175);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(155, 175);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormNewTileset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.mtbTilesHigh);
            this.Controls.Add(this.lblTilesHigh);
            this.Controls.Add(this.mtbTilesWide);
            this.Controls.Add(this.lblTilesWide);
            this.Controls.Add(this.mtbTileHeight);
            this.Controls.Add(this.lblTileHeight);
            this.Controls.Add(this.mtbTileWidth);
            this.Controls.Add(this.lblTileWidth);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.tbTilesetImage);
            this.Controls.Add(this.lblTilesetImageName);
            this.Controls.Add(this.tbTilesetName);
            this.Controls.Add(this.lblTilesetName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormNewTileset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Tileset";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTilesetName;
        private System.Windows.Forms.TextBox tbTilesetName;
        private System.Windows.Forms.Label lblTilesetImageName;
        private System.Windows.Forms.TextBox tbTilesetImage;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Label lblTileWidth;
        private System.Windows.Forms.MaskedTextBox mtbTileWidth;
        private System.Windows.Forms.Label lblTileHeight;
        private System.Windows.Forms.MaskedTextBox mtbTileHeight;
        private System.Windows.Forms.Label lblTilesWide;
        private System.Windows.Forms.MaskedTextBox mtbTilesWide;
        private System.Windows.Forms.Label lblTilesHigh;
        private System.Windows.Forms.MaskedTextBox mtbTilesHigh;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}