using RpgLibrary.EffectClasses;
using RpgLibrary.SpellClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpgEditor
{
    public partial class FormSpellDetails : Form
    {
        public SpellData Spell { get; set; }

        public FormSpellDetails()
        {
            InitializeComponent();

            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;

            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;

            btnMoveAllowed.Click += BtnMoveAllowed_Click;
            btnRemoveAllowed.Click += BtnRemoveAllowed_Click;
            Spell = new SpellData();
        }

        private void BtnRemoveAllowed_Click(object sender, EventArgs e)
        {
            if (lbAllowedClasses.SelectedItem != null)
            {
                lbClasses.Items.Add(lbAllowedClasses.SelectedItem);
                lbAllowedClasses.Items.RemoveAt(lbAllowedClasses.SelectedIndex);
            }
        }

        private void BtnMoveAllowed_Click(object sender, EventArgs e)
        {
            if (lbClasses.SelectedItem != null)
            {
                lbAllowedClasses.Items.Add(lbClasses.SelectedItem);
                lbClasses.Items.RemoveAt(lbClasses.SelectedIndex);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Spell = null;
            Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("The spell must have a name.");
                return;
            }

            if (lbEffects.Items.Count == 0)
            {
                MessageBox.Show("Spell must have at least one effect.");
                return;
            }

            if (lbAllowedClasses.Items.Count == 0)
            {
                MessageBox.Show("Spell mustg belong to at least one class.");
                return;
            }

            Spell.Name = tbName.Text;

            Spell.ActivationCost = (int)sbMana.Value;
            Spell.LevelRequirement = (int)sbLevel.Value;
            Spell.Duration = (float)sbDuration.Value;
            Spell.AreaOfEffect = (int)sbAreaOfEffect.Value;
            Spell.SpellType = (SpellType)Enum.Parse(typeof(SpellType), cboSpellType.SelectedItem.ToString());
            Spell.AllowedClasses = new string[lbAllowedClasses.Items.Count];

            for (int i = 0; i < lbAllowedClasses.Items.Count; i++)
            {
                Spell.AllowedClasses[i] = lbAllowedClasses.Items[i].ToString();
            }

            Close();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lbEffects.SelectedIndex >= 0)
            {
                Spell.Effects.RemoveAt(lbEffects.SelectedIndex);
                lbEffects.Items.RemoveAt(lbEffects.SelectedIndex);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormBaseEffect frm = new FormBaseEffect();

            frm.ShowDialog();

            if (frm.BaseEffectData != null)
            {
                lbEffects.Items.Add(frm.BaseEffectData.ToString());
                Spell.Effects.Add(frm.BaseEffectData);
            }
        }

        private void FormSpellDetails_Load(object sender, EventArgs e)
        {
            foreach (string s in FormDetails.EntityDataManager.EntityData.Keys)
            {
                lbClasses.Items.Add(s);
            }

            foreach (var v in Enum.GetNames(typeof(SpellType)))
            {
                cboSpellType.Items.Add(v.ToString());
            }
        }
    }
}
