using RpgLibrary;
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
    public partial class FormBaseEffect : Form
    {
        public BaseEffectData BaseEffectData { get; set; }

        public FormBaseEffect()
        {
            InitializeComponent();

            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;

            Load += FormBaseEffect_Load;
            rbDamage.CheckedChanged += RbDamage_CheckedChanged;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter the name for the effect.");
                return;
            }

            if (rbDamage.Checked)
            {
                DamageEffectData data = new DamageEffectData();

                data.Name = tbName.Text;
                data.TargetType = (TargetType)Enum.Parse(typeof(TargetType), cboTarget.SelectedItem.ToString());
                data.DamageType = (DamageType)Enum.Parse(typeof(DamageType), cboDamage.SelectedItem.ToString());
                data.DieType = (DieType)Enum.Parse(typeof(DieType), cboDieType.SelectedIndex.ToString());
                data.NumberOfDice = (int)sbNumOfDice.Value;
                data.Modifier = (int)sbModifier.Value;

                BaseEffectData = data;
            }
            else
            {
                HealEffectData data = new HealEffectData();

                data.Name = tbName.Text;
                data.TargetType = (TargetType)Enum.Parse(typeof(TargetType), cboTarget.SelectedItem.ToString());
                data.DieType = (DieType)Enum.Parse(typeof(DieType), cboDieType.SelectedIndex.ToString());
                data.NumberOfDice = (int)sbNumOfDice.Value;
                data.Modifier = (int)sbModifier.Value;

                BaseEffectData = data;
            }

            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            BaseEffectData = null;
            Close();
        }

        private void RbDamage_CheckedChanged(object sender, EventArgs e)
        {
            cboDamage.Enabled = rbDamage.Checked;
        }

        private void FormBaseEffect_Load(object sender, EventArgs e)
        {
            foreach (var v in Enum.GetNames(typeof(DamageType)))
            {
                cboDamage.Items.Add(v);
            }

            foreach (var v in Enum.GetNames(typeof(TargetType)))
            {
                cboTarget.Items.Add(v);
            }

            foreach (var v in Enum.GetValues(typeof(DieType)))
            {
                cboDieType.Items.Add(v);
            }
        }
    }
}
