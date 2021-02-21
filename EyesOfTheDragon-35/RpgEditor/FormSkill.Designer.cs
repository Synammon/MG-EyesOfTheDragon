
namespace RpgEditor
{
    partial class FormSkill
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
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(421, 365);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(272, 365);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(124, 365);
            // 
            // lbDetails
            // 
            this.lbDetails.ItemHeight = 24;
            this.lbDetails.Size = new System.Drawing.Size(752, 340);
            // 
            // FormSkill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.MinimizeBox = false;
            this.Name = "FormSkill";
            this.Text = "FormSkill";
            this.ResumeLayout(false);

        }

        #endregion
    }
}