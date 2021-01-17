using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.CharacterClasses;

namespace RpgEditor
{
    public partial class FormEntityData : Form
    {
        #region Field Region

        EntityData entityData = null;

        #endregion

        #region Property Region

        public EntityData EntityData
        {
            get { return entityData; }
            set { entityData = value; }
        }

        #endregion

        #region Constructor Region

        public FormEntityData()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormEntityData_Load);
            this.FormClosing += new FormClosingEventHandler(FormEntityData_FormClosing);

            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion

        #region Event Handler Region

        void FormEntityData_Load(object sender, EventArgs e)
        {
            if (entityData != null)
            {
                tbName.Text = entityData.EntityName;
                mtbStrength.Text = entityData.Strength.ToString();
                mtbDexterity.Text = entityData.Dexterity.ToString();
                mtbCunning.Text = entityData.Cunning.ToString();
                mtbWillpower.Text = entityData.Willpower.ToString();
                mtbConstitution.Text = entityData.Constitution.ToString();
                tbHealth.Text = entityData.HealthFormula;
                tbStamina.Text = entityData.StaminaFormula;
                tbMana.Text = entityData.MagicFormula;
            }
        }

        void FormEntityData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbHealth.Text) ||
                string.IsNullOrEmpty(tbStamina.Text) || string.IsNullOrEmpty(tbMana.Text))
            {
                MessageBox.Show("Name, Health Formula, Stamina Formula and Mana Formula must have values.");                
                return;
            }

            int str = 0;
            int dex = 0;
            int cun = 0;
            int wil = 0;
            int mag = 0;
            int con = 0;

            if (!int.TryParse(mtbStrength.Text, out str))
            {
                MessageBox.Show("Strength must be numeric.");
                return;
            }

            if (!int.TryParse(mtbDexterity.Text, out dex))
            {
                MessageBox.Show("Dexterity must be numeric.");
                return;
            }

            if (!int.TryParse(mtbCunning.Text, out cun))
            {
                MessageBox.Show("Cunning must be numeric.");
                return;
            }

            if (!int.TryParse(mtbWillpower.Text, out wil))
            {
                MessageBox.Show("Willpower must be numeric.");
                return;
            }

            if (!int.TryParse(mtbMagic.Text, out mag))
            {
                MessageBox.Show("Magic must be numeric.");
                return;
            }

            if (!int.TryParse(mtbConstitution.Text, out con))
            {
                MessageBox.Show("Constitution must be numeric.");
                return;
            }

            entityData = new EntityData(
                tbName.Text,
                str,
                dex,
                cun,
                wil,
                mag,
                con,
                tbHealth.Text,
                tbStamina.Text,
                tbMana.Text);

            this.FormClosing -= FormEntityData_FormClosing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            entityData = null;

            this.FormClosing -= FormEntityData_FormClosing;
            this.Close();
        }

        #endregion
    }
}
