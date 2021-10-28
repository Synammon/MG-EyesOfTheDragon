namespace XLevelEditor
{
    partial class FormNewAnimatedTileset
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbTileHeight = new System.Windows.Forms.MaskedTextBox();
            this.lblTileHeight = new System.Windows.Forms.Label();
            this.tbTileWidth = new System.Windows.Forms.MaskedTextBox();
            this.lblTileWidth = new System.Windows.Forms.Label();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.tbTilesetImage = new System.Windows.Forms.TextBox();
            this.lblTilesetImageName = new System.Windows.Forms.Label();
            this.tbRows = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFrames = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(138, 77);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 19);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(65, 77);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 19);
            this.btnOK.TabIndex = 24;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // tbTileHeight
            // 
            this.tbTileHeight.Location = new System.Drawing.Point(168, 53);
            this.tbTileHeight.Margin = new System.Windows.Forms.Padding(2);
            this.tbTileHeight.Mask = "000";
            this.tbTileHeight.Name = "tbTileHeight";
            this.tbTileHeight.Size = new System.Drawing.Size(26, 20);
            this.tbTileHeight.TabIndex = 23;
            // 
            // lblTileHeight
            // 
            this.lblTileHeight.AutoSize = true;
            this.lblTileHeight.Location = new System.Drawing.Point(104, 56);
            this.lblTileHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTileHeight.Name = "lblTileHeight";
            this.lblTileHeight.Size = new System.Drawing.Size(61, 13);
            this.lblTileHeight.TabIndex = 22;
            this.lblTileHeight.Text = "Tile Height:";
            // 
            // tbTileWidth
            // 
            this.tbTileWidth.Location = new System.Drawing.Point(74, 53);
            this.tbTileWidth.Margin = new System.Windows.Forms.Padding(2);
            this.tbTileWidth.Mask = "000";
            this.tbTileWidth.Name = "tbTileWidth";
            this.tbTileWidth.Size = new System.Drawing.Size(26, 20);
            this.tbTileWidth.TabIndex = 21;
            // 
            // lblTileWidth
            // 
            this.lblTileWidth.AutoSize = true;
            this.lblTileWidth.Location = new System.Drawing.Point(14, 59);
            this.lblTileWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTileWidth.Name = "lblTileWidth";
            this.lblTileWidth.Size = new System.Drawing.Size(58, 13);
            this.lblTileWidth.TabIndex = 20;
            this.lblTileWidth.Text = "Tile Width:";
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(198, 5);
            this.btnSelectImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(21, 19);
            this.btnSelectImage.TabIndex = 19;
            this.btnSelectImage.Tag = "";
            this.btnSelectImage.Text = "...";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            // 
            // tbTilesetImage
            // 
            this.tbTilesetImage.Enabled = false;
            this.tbTilesetImage.Location = new System.Drawing.Point(118, 5);
            this.tbTilesetImage.Margin = new System.Windows.Forms.Padding(2);
            this.tbTilesetImage.Name = "tbTilesetImage";
            this.tbTilesetImage.Size = new System.Drawing.Size(76, 20);
            this.tbTilesetImage.TabIndex = 18;
            // 
            // lblTilesetImageName
            // 
            this.lblTilesetImageName.AutoSize = true;
            this.lblTilesetImageName.Location = new System.Drawing.Point(11, 9);
            this.lblTilesetImageName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTilesetImageName.Name = "lblTilesetImageName";
            this.lblTilesetImageName.Size = new System.Drawing.Size(104, 13);
            this.lblTilesetImageName.TabIndex = 17;
            this.lblTilesetImageName.Text = "Tileset Image Name:";
            // 
            // tbRows
            // 
            this.tbRows.Location = new System.Drawing.Point(168, 29);
            this.tbRows.Margin = new System.Windows.Forms.Padding(2);
            this.tbRows.Mask = "000";
            this.tbRows.Name = "tbRows";
            this.tbRows.Size = new System.Drawing.Size(26, 20);
            this.tbRows.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Rows:";
            // 
            // tbFrames
            // 
            this.tbFrames.Location = new System.Drawing.Point(74, 29);
            this.tbFrames.Margin = new System.Windows.Forms.Padding(2);
            this.tbFrames.Mask = "000";
            this.tbFrames.Name = "tbFrames";
            this.tbFrames.Size = new System.Drawing.Size(26, 20);
            this.tbFrames.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Frames:";
            // 
            // FormNewAnimatedTileset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 108);
            this.Controls.Add(this.tbRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFrames);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbTileHeight);
            this.Controls.Add(this.lblTileHeight);
            this.Controls.Add(this.tbTileWidth);
            this.Controls.Add(this.lblTileWidth);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.tbTilesetImage);
            this.Controls.Add(this.lblTilesetImageName);
            this.Name = "FormNewAnimatedTileset";
            this.Text = "Animated Tileset";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.MaskedTextBox tbTileHeight;
        private System.Windows.Forms.Label lblTileHeight;
        private System.Windows.Forms.MaskedTextBox tbTileWidth;
        private System.Windows.Forms.Label lblTileWidth;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.TextBox tbTilesetImage;
        private System.Windows.Forms.Label lblTilesetImageName;
        private System.Windows.Forms.MaskedTextBox tbRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox tbFrames;
        private System.Windows.Forms.Label label2;
    }
}