using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary;
using RpgLibrary.EffectClasses;
using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormWeaponDetail : Form
    {
        #region Field Region
        
        WeaponData weapon = null;
        List<DamageEffectData> damageEffects = new List<DamageEffectData>();

        #endregion
        
        #region Property Region
        
        public WeaponData Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }
        
        #endregion
        
        #region Constructor Region
        
        public FormWeaponDetail()
        {
            InitializeComponent();
            
            this.Load += new EventHandler(FormWeaponDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormWeaponDetails_FormClosing);
        
            btnMoveAllowed.Click += new EventHandler(btnMoveAllowed_Click);
            btnRemoveAllowed.Click += new EventHandler(btnRemoveAllowed_Click);

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;

            lbDamageEffects.SelectedIndexChanged += LbDamageEffects_SelectedIndexChanged;

            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        private void LbDamageEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DamageEffectData effect = new DamageEffectData
            {
                AttackType = (AttackType)Enum.Parse(
                    typeof(AttackType),
                    cboAttackType.Text),
                DamageType = (DamageType)Enum.Parse(
                    typeof(DamageType),
                    cboDamageType.SelectedItem.ToString()),
                NumberOfDice = (int)nudDice.Value,
                Modifier = int.Parse(mtbModifier.Text),
                DieType = (DieType)Enum.Parse(
                    typeof(DieType),
                    cboDieType.Text)
            };

            damageEffects.Add(effect);
            lbDamageEffects.Items.Add(effect);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lbDamageEffects.SelectedIndex < 0)
            {
                return;
            }

            damageEffects.RemoveAt(lbDamageEffects.SelectedIndex);
            lbDamageEffects.Items.RemoveAt(lbDamageEffects.SelectedIndex);
        }

        #endregion

        #region Event Handler Region
        void FormWeaponDetails_Load(object sender, EventArgs e)
        {
            foreach (string s in FormDetails.EntityDataManager.EntityData.Keys)
            {
                lbClasses.Items.Add(s);
            }

            foreach (AttackType attackType in Enum.GetValues(typeof(AttackType)))
            {
                cboAttackType.Items.Add(attackType);
            }

            foreach (Hands location in Enum.GetValues(typeof(Hands)))
            {
                cboHands.Items.Add(location);
            }

            foreach (DieType die in Enum.GetValues(typeof(DieType)))
            {
                cboDieType.Items.Add(die);
            }

            foreach (DamageType d in Enum.GetValues(typeof(DamageType)))
            {
                cboDamageType.Items.Add(d);
            }

            cboHands.SelectedIndex = 0;
            cboDieType.SelectedIndex = 0;
            cboDieType.SelectedValue = Enum.GetName(typeof(DieType), DieType.D4);

            if (weapon != null)
            {
                tbName.Text = weapon.Name;
                cboAttackType.Text = weapon.Type;
                mtbPrice.Text = weapon.Price.ToString();
                nudWeight.Value = (decimal)weapon.Weight;
                cboHands.SelectedIndex = (int)weapon.NumberHands;
                mtbAttackValue.Text = weapon.AttackValue.ToString();
                mtbAttackModifier.Text = weapon.AttackModifier.ToString();
                
                foreach (DamageEffectData effect in weapon.DamageEffectData)
                {
                    lbDamageEffects.Items.Add(effect);
                    damageEffects.Add(effect);
                }

                foreach (string s in weapon.AllowableClasses)
                {
                    if (lbClasses.Items.Contains(s))
                        lbClasses.Items.Remove(s);
        
                    lbAllowedClasses.Items.Add(s);
                }
            }
        }

        void FormWeaponDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        void btnMoveAllowed_Click(object sender, EventArgs e)
        {
            if (lbClasses.SelectedItem != null)
            {
                lbAllowedClasses.Items.Add(lbClasses.SelectedItem);
                lbClasses.Items.RemoveAt(lbClasses.SelectedIndex);
            }
        }

        void btnRemoveAllowed_Click(object sender, EventArgs e)
        {
            
            if (lbAllowedClasses.SelectedItem != null)
            {
                lbClasses.Items.Add(lbAllowedClasses.SelectedItem);
                lbAllowedClasses.Items.RemoveAt(lbAllowedClasses.SelectedIndex);
            }
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            int price = 0;
            float weight = 0f;
            int attVal = 0;
            int attMod = 0;
            int damVal = 0;
            int damMod = 0;
            
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the item.");
                return;
            }

            if (!int.TryParse(mtbPrice.Text, out price))
            {
                MessageBox.Show("Price must be an integer value.");
                return;
            }

            weight = (float)nudWeight.Value;

            if (!int.TryParse(mtbAttackValue.Text, out attVal))
            {
                MessageBox.Show("Attack value must be an interger value.");
                return;
            }

            if (!int.TryParse(mtbAttackModifier.Text, out attMod))
            {
                MessageBox.Show("Attack value must be an interger value.");
                return;
            }

            if (damageEffects.Count == 0)
            {
                MessageBox.Show("Weapons require at least one damage effect.");
                return;
            }

            List<string> allowedClasses = new List<string>();
            List<DamageEffectData> effects = new List<DamageEffectData>();

            foreach (object o in lbAllowedClasses.Items)
            {
                allowedClasses.Add(o.ToString());
            }

            weapon = new WeaponData
            {
                Name = tbName.Text,
                Type = cboAttackType.Text,
                NumberHands = (Hands)Enum.Parse(typeof(Hands), cboHands.Text),
                Price = price,
                Weight = weight,
                AttackValue = attVal,
                AttackModifier = attMod,
                AllowableClasses = allowedClasses.ToArray(),
                DamageEffectData = damageEffects
            };

            this.FormClosing -= FormWeaponDetails_FormClosing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            weapon = null;

            this.FormClosing -= FormWeaponDetails_FormClosing;
            this.Close();
        }

        #endregion
    }
}
