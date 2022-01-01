namespace RpgEditor
{
    partial class FormBaseEffect
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbHealing = new System.Windows.Forms.RadioButton();
            this.rbDamage = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDamage = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTarget = new System.Windows.Forms.ComboBox();
            this.cboDieType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sbNumOfDice = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.sbModifier = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbNumOfDice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbModifier)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(56, 6);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(110, 20);
            this.tbName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbHealing);
            this.groupBox1.Controls.Add(this.rbDamage);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(84, 73);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Effect Type";
            // 
            // rbHealing
            // 
            this.rbHealing.AutoSize = true;
            this.rbHealing.Location = new System.Drawing.Point(6, 42);
            this.rbHealing.Name = "rbHealing";
            this.rbHealing.Size = new System.Drawing.Size(61, 17);
            this.rbHealing.TabIndex = 1;
            this.rbHealing.Text = "Healing";
            this.rbHealing.UseVisualStyleBackColor = true;
            // 
            // rbDamage
            // 
            this.rbDamage.AutoSize = true;
            this.rbDamage.Checked = true;
            this.rbDamage.Location = new System.Drawing.Point(6, 19);
            this.rbDamage.Name = "rbDamage";
            this.rbDamage.Size = new System.Drawing.Size(65, 17);
            this.rbDamage.TabIndex = 0;
            this.rbDamage.TabStop = true;
            this.rbDamage.Text = "Damage";
            this.rbDamage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Damage:";
            // 
            // cboDamage
            // 
            this.cboDamage.FormattingEnabled = true;
            this.cboDamage.Location = new System.Drawing.Point(72, 108);
            this.cboDamage.Name = "cboDamage";
            this.cboDamage.Size = new System.Drawing.Size(94, 21);
            this.cboDamage.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Target:";
            // 
            // cboTarget
            // 
            this.cboTarget.FormattingEnabled = true;
            this.cboTarget.Location = new System.Drawing.Point(72, 135);
            this.cboTarget.Name = "cboTarget";
            this.cboTarget.Size = new System.Drawing.Size(94, 21);
            this.cboTarget.TabIndex = 6;
            // 
            // cboDieType
            // 
            this.cboDieType.FormattingEnabled = true;
            this.cboDieType.Location = new System.Drawing.Point(72, 162);
            this.cboDieType.Name = "cboDieType";
            this.cboDieType.Size = new System.Drawing.Size(94, 21);
            this.cboDieType.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Die Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "# of Dice:";
            // 
            // sbNumOfDice
            // 
            this.sbNumOfDice.Location = new System.Drawing.Point(72, 189);
            this.sbNumOfDice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sbNumOfDice.Name = "sbNumOfDice";
            this.sbNumOfDice.Size = new System.Drawing.Size(94, 20);
            this.sbNumOfDice.TabIndex = 10;
            this.sbNumOfDice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(172, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(172, 32);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "a";
            // 
            // sbModifier
            // 
            this.sbModifier.Location = new System.Drawing.Point(72, 215);
            this.sbModifier.Name = "sbModifier";
            this.sbModifier.Size = new System.Drawing.Size(94, 20);
            this.sbModifier.TabIndex = 10;
            // 
            // FormBaseEffect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 240);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.sbModifier);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sbNumOfDice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboDieType);
            this.Controls.Add(this.cboTarget);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboDamage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBaseEffect";
            this.Text = "FormBaseEffect";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbNumOfDice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbModifier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbHealing;
        private System.Windows.Forms.RadioButton rbDamage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDamage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTarget;
        private System.Windows.Forms.ComboBox cboDieType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown sbNumOfDice;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown sbModifier;
    }
}