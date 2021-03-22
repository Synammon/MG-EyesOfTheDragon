
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(110, 217);
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
            this.tbName.Location = new System.Drawing.Point(76, 11);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(113, 20);
            this.tbName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
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
            this.btnCancel.Location = new System.Drawing.Point(239, 234);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 19);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(171, 234);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 19);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // FormSpellDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 272);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "FormSpellDetails";
            this.Text = "FormSpellDetails";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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
    }
}