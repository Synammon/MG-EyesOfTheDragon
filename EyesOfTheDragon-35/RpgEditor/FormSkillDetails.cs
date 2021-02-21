using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.SkillClasses;

namespace RpgEditor
{
    public partial class FormSkillDetails : Form
    {
        #region Field Region

        SkillData skill;

        #endregion

        #region Property Region
        public SkillData Skill
        {
            get { return skill; }
            set { skill = value; }
        }

        #endregion

        #region Constructor Region

        public FormSkillDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormSkillDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormSkillDetails_FormClosing);

            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion

        #region Form Event Handler Region

        void FormSkillDetails_Load(object sender, EventArgs e)
        {
            if (Skill != null)
            {
                tbName.Text = Skill.Name;

                switch (Skill.PrimaryAttribute.ToLower())
                {
                    case "strength":
                        rbStrength.Checked = true;
                        break;
                    case "dexterity":
                        rbDexterity.Checked = true;
                        break;
                    case "cunning":
                        rbCunning.Checked = true;
                        break;
                    case "willpower":
                        rbWillpower.Checked = true;
                        break;
                    case "magic":
                        rbMagic.Checked = true;
                        break;
                    case "constitution":
                        rbConstitution.Checked = true;
                        break;
                }

                foreach (string s in Skill.ClassModifiers.Keys)
                {
                    string data = s + ", " + Skill.ClassModifiers[s].ToString();
                    lbModifiers.Items.Add(data);
                }
            }
        }

        void FormSkillDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Button Event Handler Region

        void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must provide a name for the skill.");
                return;
            }

            SkillData newSkill = new SkillData();
            newSkill.Name = tbName.Text;

            if (rbStrength.Checked)
                newSkill.PrimaryAttribute = "Strength";
            else if (rbDexterity.Checked)
                newSkill.PrimaryAttribute = "Dexterity";
            else if (rbCunning.Checked)
                newSkill.PrimaryAttribute = "Cunning";
            else if (rbWillpower.Checked)
                newSkill.PrimaryAttribute = "Willpower";
            else if (rbMagic.Checked)
                newSkill.PrimaryAttribute = "Magic";
            else if (rbConstitution.Checked)
                newSkill.PrimaryAttribute = "Constitution";

            skill = newSkill;

            this.FormClosing -= FormSkillDetails_FormClosing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            skill = null;
            this.FormClosing -= FormSkillDetails_FormClosing;
            this.Close();
        }
        #endregion
    }
}
