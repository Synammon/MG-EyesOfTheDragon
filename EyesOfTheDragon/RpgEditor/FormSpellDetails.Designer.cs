 
namespace RpgEditor
{
    partial class FormSpellDetails
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbConstitution = new System.Windows.Forms.RadioButton();
            this.rbMagic = new System.Windows.Forms.RadioButton();
            this.rbWillpower = new System.Windows.Forms.RadioButton();
            this.rbCunning = new System.Windows.Forms.RadioButton();
            this.rbDexterity = new System.Windows.Forms.RadioButton();
            this.rbStrength = new System.Windows.Forms.RadioButton();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbEffects = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnRemoveAllowed = new System.Windows.Forms.Button();
            this.btnMoveAllowed = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbAllowedClasses = new System.Windows.Forms.ListBox();
            this.lbClasses = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sbLevel = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.sbMana = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.sbCoolDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.sbAreaOfEffect = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.rbRange = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.sbDuration = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cboSpellType = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbMana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbCoolDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbAreaOfEffect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbConstitution);
            this.groupBox1.Controls.Add(this.rbMagic);
            this.groupBox1.Controls.Add(this.rbWillpower);
            this.groupBox1.Controls.Add(this.rbCunning);
            this.groupBox1.Controls.Add(this.rbDexterity);
            this.groupBox1.Controls.Add(this.rbStrength);
            this.groupBox1.Location = new System.Drawing.Point(13, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(110, 186);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Primary Attribute";
            // 
            // rbConstitution
            // 
            this.rbConstitution.AutoSize = true;
            this.rbConstitution.Location = new System.Drawing.Point(5, 128);
            this.rbConstitution.Margin = new System.Windows.Forms.Padding(2);
            this.rbConstitution.Name = "rbConstitution";
            this.rbConstitution.Size = new System.Drawing.Size(80, 17);
            this.rbConstitution.TabIndex = 5;
            this.rbConstitution.Text = "Constitution";
            this.rbConstitution.UseVisualStyleBackColor = true;
            // 
            // rbMagic
            // 
            this.rbMagic.AutoSize = true;
            this.rbMagic.Location = new System.Drawing.Point(5, 106);
            this.rbMagic.Margin = new System.Windows.Forms.Padding(2);
            this.rbMagic.Name = "rbMagic";
            this.rbMagic.Size = new System.Drawing.Size(54, 17);
            this.rbMagic.TabIndex = 4;
            this.rbMagic.Text = "Magic";
            this.rbMagic.UseVisualStyleBackColor = true;
            // 
            // rbWillpower
            // 
            this.rbWillpower.AutoSize = true;
            this.rbWillpower.Location = new System.Drawing.Point(5, 84);
            this.rbWillpower.Margin = new System.Windows.Forms.Padding(2);
            this.rbWillpower.Name = "rbWillpower";
            this.rbWillpower.Size = new System.Drawing.Size(71, 17);
            this.rbWillpower.TabIndex = 3;
            this.rbWillpower.Text = "Willpower";
            this.rbWillpower.UseVisualStyleBackColor = true;
            // 
            // rbCunning
            // 
            this.rbCunning.AutoSize = true;
            this.rbCunning.Location = new System.Drawing.Point(5, 63);
            this.rbCunning.Margin = new System.Windows.Forms.Padding(2);
            this.rbCunning.Name = "rbCunning";
            this.rbCunning.Size = new System.Drawing.Size(64, 17);
            this.rbCunning.TabIndex = 2;
            this.rbCunning.Text = "Cunning";
            this.rbCunning.UseVisualStyleBackColor = true;
            // 
            // rbDexterity
            // 
            this.rbDexterity.AutoSize = true;
            this.rbDexterity.Location = new System.Drawing.Point(5, 41);
            this.rbDexterity.Margin = new System.Windows.Forms.Padding(2);
            this.rbDexterity.Name = "rbDexterity";
            this.rbDexterity.Size = new System.Drawing.Size(66, 17);
            this.rbDexterity.TabIndex = 1;
            this.rbDexterity.Text = "Dexterity";
            this.rbDexterity.UseVisualStyleBackColor = true;
            // 
            // rbStrength
            // 
            this.rbStrength.AutoSize = true;
            this.rbStrength.Checked = true;
            this.rbStrength.Location = new System.Drawing.Point(5, 18);
            this.rbStrength.Margin = new System.Windows.Forms.Padding(2);
            this.rbStrength.Name = "rbStrength";
            this.rbStrength.Size = new System.Drawing.Size(65, 17);
            this.rbStrength.TabIndex = 0;
            this.rbStrength.TabStop = true;
            this.rbStrength.Text = "Strength";
            this.rbStrength.UseVisualStyleBackColor = true;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(76, 14);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(113, 20);
            this.tbName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Spell Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.lbEffects);
            this.groupBox2.Location = new System.Drawing.Point(145, 44);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(310, 186);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Effects";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(192, 163);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(56, 19);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(131, 163);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(56, 19);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(70, 163);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 19);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lbEffects
            // 
            this.lbEffects.FormattingEnabled = true;
            this.lbEffects.Location = new System.Drawing.Point(22, 17);
            this.lbEffects.Margin = new System.Windows.Forms.Padding(2);
            this.lbEffects.Name = "lbEffects";
            this.lbEffects.Size = new System.Drawing.Size(272, 134);
            this.lbEffects.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(797, 44);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 19);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(797, 21);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 19);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAllowed
            // 
            this.btnRemoveAllowed.Location = new System.Drawing.Point(585, 126);
            this.btnRemoveAllowed.Name = "btnRemoveAllowed";
            this.btnRemoveAllowed.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAllowed.TabIndex = 54;
            this.btnRemoveAllowed.Text = "<<";
            this.btnRemoveAllowed.UseVisualStyleBackColor = true;
            // 
            // btnMoveAllowed
            // 
            this.btnMoveAllowed.Location = new System.Drawing.Point(585, 97);
            this.btnMoveAllowed.Name = "btnMoveAllowed";
            this.btnMoveAllowed.Size = new System.Drawing.Size(75, 23);
            this.btnMoveAllowed.TabIndex = 55;
            this.btnMoveAllowed.Text = ">>";
            this.btnMoveAllowed.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(663, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "Allowed Classes:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(459, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Character Classes:";
            // 
            // lbAllowedClasses
            // 
            this.lbAllowedClasses.FormattingEnabled = true;
            this.lbAllowedClasses.Location = new System.Drawing.Point(666, 53);
            this.lbAllowedClasses.Name = "lbAllowedClasses";
            this.lbAllowedClasses.Size = new System.Drawing.Size(120, 173);
            this.lbAllowedClasses.TabIndex = 50;
            // 
            // lbClasses
            // 
            this.lbClasses.FormattingEnabled = true;
            this.lbClasses.Location = new System.Drawing.Point(459, 53);
            this.lbClasses.Name = "lbClasses";
            this.lbClasses.Size = new System.Drawing.Size(120, 173);
            this.lbClasses.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Level:";
            // 
            // sbLevel
            // 
            this.sbLevel.Location = new System.Drawing.Point(57, 246);
            this.sbLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sbLevel.Name = "sbLevel";
            this.sbLevel.Size = new System.Drawing.Size(66, 20);
            this.sbLevel.TabIndex = 57;
            this.sbLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Mana Cost:";
            // 
            // sbMana
            // 
            this.sbMana.Location = new System.Drawing.Point(196, 246);
            this.sbMana.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sbMana.Name = "sbMana";
            this.sbMana.Size = new System.Drawing.Size(62, 20);
            this.sbMana.TabIndex = 59;
            this.sbMana.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Cool Down:";
            // 
            // sbCoolDown
            // 
            this.sbCoolDown.DecimalPlaces = 3;
            this.sbCoolDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.sbCoolDown.Location = new System.Drawing.Point(332, 246);
            this.sbCoolDown.Name = "sbCoolDown";
            this.sbCoolDown.Size = new System.Drawing.Size(69, 20);
            this.sbCoolDown.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(407, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "Area of Effect";
            // 
            // sbAreaOfEffect
            // 
            this.sbAreaOfEffect.Location = new System.Drawing.Point(485, 246);
            this.sbAreaOfEffect.Name = "sbAreaOfEffect";
            this.sbAreaOfEffect.Size = new System.Drawing.Size(81, 20);
            this.sbAreaOfEffect.TabIndex = 63;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(582, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "Range:";
            // 
            // rbRange
            // 
            this.rbRange.Location = new System.Drawing.Point(630, 246);
            this.rbRange.Name = "rbRange";
            this.rbRange.Size = new System.Drawing.Size(65, 20);
            this.rbRange.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(716, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "Duration:";
            // 
            // sbDuration
            // 
            this.sbDuration.Location = new System.Drawing.Point(772, 246);
            this.sbDuration.Name = "sbDuration";
            this.sbDuration.Size = new System.Drawing.Size(59, 20);
            this.sbDuration.TabIndex = 67;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(212, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 68;
            this.label8.Text = "Spell Type:";
            // 
            // cboSpellType
            // 
            this.cboSpellType.FormattingEnabled = true;
            this.cboSpellType.Location = new System.Drawing.Point(289, 14);
            this.cboSpellType.Name = "cboSpellType";
            this.cboSpellType.Size = new System.Drawing.Size(121, 21);
            this.cboSpellType.TabIndex = 69;
            // 
            // FormSpellDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 282);
            this.Controls.Add(this.cboSpellType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sbDuration);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rbRange);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sbAreaOfEffect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sbCoolDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sbMana);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sbLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRemoveAllowed);
            this.Controls.Add(this.btnMoveAllowed);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbAllowedClasses);
            this.Controls.Add(this.lbClasses);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "FormSpellDetails";
            this.Text = "FormSpellDetails";
            this.Load += new System.EventHandler(this.FormSpellDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sbLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbMana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbCoolDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbAreaOfEffect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbConstitution;
        private System.Windows.Forms.RadioButton rbMagic;
        private System.Windows.Forms.RadioButton rbWillpower;
        private System.Windows.Forms.RadioButton rbCunning;
        private System.Windows.Forms.RadioButton rbDexterity;
        private System.Windows.Forms.RadioButton rbStrength;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbEffects;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnRemoveAllowed;
        private System.Windows.Forms.Button btnMoveAllowed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lbAllowedClasses;
        private System.Windows.Forms.ListBox lbClasses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown sbLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown sbMana;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown sbCoolDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown sbAreaOfEffect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown rbRange;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown sbDuration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboSpellType;
    }
}