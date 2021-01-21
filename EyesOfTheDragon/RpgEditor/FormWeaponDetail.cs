using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormWeaponDetail : Form
    {
        #region Field Region
        
        WeaponData weapon = null;
        
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
            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }
        
        #endregion

        #region Event Handler Region
        void FormWeaponDetails_Load(object sender, EventArgs e)
        {
            foreach (string s in FormDetails.EntityDataManager.EntityData.Keys)
                lbClasses.Items.Add(s);
            
            foreach (Hands location in Enum.GetValues(typeof(Hands)))
                cboHands.Items.Add(location);
            
            cboHands.SelectedIndex = 0;
            
            if (weapon != null)
            {
                tbName.Text = weapon.Name;
                tbType.Text = weapon.Type;
                mtbPrice.Text = weapon.Price.ToString();
                nudWeight.Value = (decimal)weapon.Weight;
                cboHands.SelectedIndex = (int)weapon.NumberHands;
                mtbAttackValue.Text = weapon.AttackValue.ToString();
                mtbAttackModifier.Text = weapon.AttackModifier.ToString();
                mtbDamageValue.Text = weapon.DamageValue.ToString();
                mtbDamageModifier.Text = weapon.DamageModifier.ToString();
                
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

            if (!int.TryParse(mtbDamageValue.Text, out damVal))
            {
                MessageBox.Show("Damage value must be an interger value.");
                return;
            }

            if (!int.TryParse(mtbDamageModifier.Text, out damMod))
            {
                MessageBox.Show("Damage value must be an interger value.");
                return;
            }

            List<string> allowedClasses = new List<string>();

            foreach (object o in lbAllowedClasses.Items)
                allowedClasses.Add(o.ToString());

            weapon = new WeaponData();

            weapon.Name = tbName.Text;
            weapon.Type = tbType.Text;
            weapon.Price = price;
            weapon.Weight = weight;
            weapon.AttackValue = attVal;
            weapon.AttackModifier = attMod;
            weapon.DamageValue = damVal;
            weapon.DamageModifier = damMod;
            weapon.AllowableClasses = allowedClasses.ToArray();

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
