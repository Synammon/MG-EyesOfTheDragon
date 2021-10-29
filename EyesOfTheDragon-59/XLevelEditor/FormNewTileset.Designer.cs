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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTilesetName
            // 
            this.lblTilesetName.AutoSize = true;
            this.lblTilesetName.Location = new System.Drawing.Point(61, 12);
            this.lblTilesetName.Name = "lblTilesetName";
            this.lblTilesetName.Size = new System.Drawing.Size(105, 20);
            this.lblTilesetName.TabIndex = 0;
            this.lblTilesetName.Text = "Tileset Name:";
            // 
            // tbTilesetName
            // 
            this.tbTilesetName.Location = new System.Drawing.Point(174, 6);
            this.tbTilesetName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTilesetName.Name = "tbTilesetName";
            this.tbTilesetName.Size = new System.Drawing.Size(112, 26);
            this.tbTilesetName.TabIndex = 1;
            // 
            // lblTilesetImageName
            // 
            this.lblTilesetImageName.AutoSize = true;
            this.lblTilesetImageName.Location = new System.Drawing.Point(14, 50);
            this.lblTilesetImageName.Name = "lblTilesetImageName";
            this.lblTilesetImageName.Size = new System.Drawing.Size(154, 20);
            this.lblTilesetImageName.TabIndex = 2;
            this.lblTilesetImageName.Text = "Tileset Image Name:";
            // 
            // tbTilesetImage
            // 
            this.tbTilesetImage.Enabled = false;
            this.tbTilesetImage.Location = new System.Drawing.Point(174, 42);
            this.tbTilesetImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTilesetImage.Name = "tbTilesetImage";
            this.tbTilesetImage.Size = new System.Drawing.Size(112, 26);
            this.tbTilesetImage.TabIndex = 3;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(294, 42);
            this.btnSelectImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(32, 29);
            this.btnSelectImage.TabIndex = 4;
            this.btnSelectImage.Tag = "";
            this.btnSelectImage.Text = "...";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            // 
            // lblTileWidth
            // 
            this.lblTileWidth.AutoSize = true;
            this.lblTileWidth.Location = new System.Drawing.Point(83, 86);
            this.lblTileWidth.Name = "lblTileWidth";
            this.lblTileWidth.Size = new System.Drawing.Size(82, 20);
            this.lblTileWidth.TabIndex = 5;
            this.lblTileWidth.Text = "Tile Width:";
            // 
            // mtbTileWidth
            // 
            this.mtbTileWidth.Location = new System.Drawing.Point(174, 78);
            this.mtbTileWidth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtbTileWidth.Mask = "000";
            this.mtbTileWidth.Name = "mtbTileWidth";
            this.mtbTileWidth.Size = new System.Drawing.Size(38, 26);
            this.mtbTileWidth.TabIndex = 6;
            // 
            // lblTileHeight
            // 
            this.lblTileHeight.AutoSize = true;
            this.lblTileHeight.Location = new System.Drawing.Point(78, 116);
            this.lblTileHeight.Name = "lblTileHeight";
            this.lblTileHeight.Size = new System.Drawing.Size(88, 20);
            this.lblTileHeight.TabIndex = 7;
            this.lblTileHeight.Text = "Tile Height:";
            // 
            // mtbTileHeight
            // 
            this.mtbTileHeight.Location = new System.Drawing.Point(174, 112);
            this.mtbTileHeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtbTileHeight.Mask = "000";
            this.mtbTileHeight.Name = "mtbTileHeight";
            this.mtbTileHeight.Size = new System.Drawing.Size(38, 26);
            this.mtbTileHeight.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(64, 146);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 29);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(174, 146);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 29);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormNewTileset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 230);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
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
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}