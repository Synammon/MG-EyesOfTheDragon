namespace RpgEditor
{
    partial class FormWeaponDetail
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbPrice = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cboHands = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mtbAttackValue = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.mtbAttackModifier = new System.Windows.Forms.MaskedTextBox();
            this.lbClasses = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbAllowedClasses = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnMoveAllowed = new System.Windows.Forms.Button();
            this.btnRemoveAllowed = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDamageEffects = new System.Windows.Forms.Label();
            this.lbDamageEffects = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDieType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudDice = new System.Windows.Forms.NumericUpDown();
            this.mtbModifier = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboDamageType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboAttackType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDice)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(172, 15);
            this.tbName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(148, 26);
            this.tbName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Price:";
            // 
            // mtbPrice
            // 
            this.mtbPrice.Location = new System.Drawing.Point(172, 95);
            this.mtbPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mtbPrice.Mask = "000000";
            this.mtbPrice.Name = "mtbPrice";
            this.mtbPrice.Size = new System.Drawing.Size(148, 26);
            this.mtbPrice.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Weight:";
            // 
            // nudWeight
            // 
            this.nudWeight.DecimalPlaces = 2;
            this.nudWeight.Location = new System.Drawing.Point(172, 135);
            this.nudWeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(150, 26);
            this.nudWeight.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 182);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hands:";
            // 
            // cboHands
            // 
            this.cboHands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHands.FormattingEnabled = true;
            this.cboHands.Location = new System.Drawing.Point(172, 177);
            this.cboHands.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboHands.Name = "cboHands";
            this.cboHands.Size = new System.Drawing.Size(148, 28);
            this.cboHands.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 223);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Attack Value:";
            // 
            // mtbAttackValue
            // 
            this.mtbAttackValue.Location = new System.Drawing.Point(172, 218);
            this.mtbAttackValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mtbAttackValue.Mask = "000";
            this.mtbAttackValue.Name = "mtbAttackValue";
            this.mtbAttackValue.Size = new System.Drawing.Size(148, 26);
            this.mtbAttackValue.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(42, 263);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "Attack Modifier:";
            // 
            // mtbAttackModifier
            // 
            this.mtbAttackModifier.Location = new System.Drawing.Point(172, 258);
            this.mtbAttackModifier.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mtbAttackModifier.Mask = "000";
            this.mtbAttackModifier.Name = "mtbAttackModifier";
            this.mtbAttackModifier.Size = new System.Drawing.Size(148, 26);
            this.mtbAttackModifier.TabIndex = 6;
            // 
            // lbClasses
            // 
            this.lbClasses.FormattingEnabled = true;
            this.lbClasses.ItemHeight = 20;
            this.lbClasses.Location = new System.Drawing.Point(357, 55);
            this.lbClasses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbClasses.Name = "lbClasses";
            this.lbClasses.Size = new System.Drawing.Size(178, 224);
            this.lbClasses.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(357, 18);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Character Classes:";
            // 
            // lbAllowedClasses
            // 
            this.lbAllowedClasses.FormattingEnabled = true;
            this.lbAllowedClasses.ItemHeight = 20;
            this.lbAllowedClasses.Location = new System.Drawing.Point(668, 55);
            this.lbAllowedClasses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbAllowedClasses.Name = "lbAllowedClasses";
            this.lbAllowedClasses.Size = new System.Drawing.Size(178, 224);
            this.lbAllowedClasses.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(663, 18);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "Allowed Classes:";
            // 
            // btnMoveAllowed
            // 
            this.btnMoveAllowed.Location = new System.Drawing.Point(546, 123);
            this.btnMoveAllowed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveAllowed.Name = "btnMoveAllowed";
            this.btnMoveAllowed.Size = new System.Drawing.Size(112, 35);
            this.btnMoveAllowed.TabIndex = 10;
            this.btnMoveAllowed.Text = ">>";
            this.btnMoveAllowed.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAllowed
            // 
            this.btnRemoveAllowed.Location = new System.Drawing.Point(546, 189);
            this.btnRemoveAllowed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemoveAllowed.Name = "btnRemoveAllowed";
            this.btnRemoveAllowed.Size = new System.Drawing.Size(112, 35);
            this.btnRemoveAllowed.TabIndex = 11;
            this.btnRemoveAllowed.Text = "<<";
            this.btnRemoveAllowed.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(867, 11);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 35);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(869, 56);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblDamageEffects
            // 
            this.lblDamageEffects.AutoSize = true;
            this.lblDamageEffects.Location = new System.Drawing.Point(33, 292);
            this.lblDamageEffects.Name = "lblDamageEffects";
            this.lblDamageEffects.Size = new System.Drawing.Size(129, 20);
            this.lblDamageEffects.TabIndex = 16;
            this.lblDamageEffects.Text = "Damage Effects:";
            // 
            // lbDamageEffects
            // 
            this.lbDamageEffects.FormattingEnabled = true;
            this.lbDamageEffects.ItemHeight = 20;
            this.lbDamageEffects.Location = new System.Drawing.Point(172, 292);
            this.lbDamageEffects.Name = "lbDamageEffects";
            this.lbDamageEffects.Size = new System.Drawing.Size(363, 184);
            this.lbDamageEffects.TabIndex = 17;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(378, 482);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 35);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(459, 482);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 35);
            this.btnEdit.TabIndex = 19;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(540, 482);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 35);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cboDamageType);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.mtbModifier);
            this.groupBox1.Controls.Add(this.nudDice);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboDieType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(540, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 184);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Damage Effect";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Die Type:";
            // 
            // cboDieType
            // 
            this.cboDieType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDieType.FormattingEnabled = true;
            this.cboDieType.Location = new System.Drawing.Point(159, 31);
            this.cboDieType.Name = "cboDieType";
            this.cboDieType.Size = new System.Drawing.Size(121, 28);
            this.cboDieType.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Die Count:";
            // 
            // nudDice
            // 
            this.nudDice.Location = new System.Drawing.Point(160, 65);
            this.nudDice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDice.Name = "nudDice";
            this.nudDice.Size = new System.Drawing.Size(120, 26);
            this.nudDice.TabIndex = 3;
            this.nudDice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mtbModifier
            // 
            this.mtbModifier.Location = new System.Drawing.Point(160, 97);
            this.mtbModifier.Mask = "00";
            this.mtbModifier.Name = "mtbModifier";
            this.mtbModifier.Size = new System.Drawing.Size(121, 26);
            this.mtbModifier.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(78, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "Modifier:";
            // 
            // cboDamageType
            // 
            this.cboDamageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDamageType.FormattingEnabled = true;
            this.cboDamageType.Location = new System.Drawing.Point(160, 129);
            this.cboDamageType.Name = "cboDamageType";
            this.cboDamageType.Size = new System.Drawing.Size(121, 28);
            this.cboDamageType.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(42, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "Damage Type:";
            // 
            // cboAttackType
            // 
            this.cboAttackType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAttackType.FormattingEnabled = true;
            this.cboAttackType.Location = new System.Drawing.Point(172, 59);
            this.cboAttackType.Name = "cboAttackType";
            this.cboAttackType.Size = new System.Drawing.Size(148, 28);
            this.cboAttackType.TabIndex = 22;
            // 
            // FormWeaponDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 540);
            this.ControlBox = false;
            this.Controls.Add(this.cboAttackType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbDamageEffects);
            this.Controls.Add(this.lblDamageEffects);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnRemoveAllowed);
            this.Controls.Add(this.btnMoveAllowed);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbAllowedClasses);
            this.Controls.Add(this.lbClasses);
            this.Controls.Add(this.mtbAttackModifier);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.mtbAttackValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboHands);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudWeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mtbPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormWeaponDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Weapon Details";
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtbPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboHands;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mtbAttackValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox mtbAttackModifier;
        private System.Windows.Forms.ListBox lbClasses;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lbAllowedClasses;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnMoveAllowed;
        private System.Windows.Forms.Button btnRemoveAllowed;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDamageEffects;
        private System.Windows.Forms.ListBox lbDamageEffects;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox mtbModifier;
        private System.Windows.Forms.NumericUpDown nudDice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDieType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboDamageType;
        private System.Windows.Forms.ComboBox cboAttackType;
    }
}