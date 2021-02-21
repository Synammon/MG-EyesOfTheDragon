using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormWeapon : FormDetails
    {
        #region Field Region
        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public FormWeapon()
        {
            InitializeComponent();

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        #endregion

        #region Button Event Handler Region

        void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormWeaponDetail frmWeaponDetails = new FormWeaponDetail())
            {
                frmWeaponDetails.ShowDialog();

                if (frmWeaponDetails.Weapon != null)
                {
                    AddWeapon(frmWeaponDetails.Weapon);
                }
            }
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                WeaponData data = itemManager.WeaponData[entity];
                WeaponData newData = null;

                using (FormWeaponDetail frmWeaponData = new FormWeaponDetail())
                {
                    frmWeaponData.Weapon = data;
                    frmWeaponData.ShowDialog();

                    if (frmWeaponData.Weapon == null)
                        return;

                    if (frmWeaponData.Weapon.Name == entity)
                    {
                        itemManager.WeaponData[entity] = frmWeaponData.Weapon;
                        FillListBox();

                        return;
                    }

                    newData = frmWeaponData.Weapon;
                }

                DialogResult result = MessageBox.Show(
                    "Name has changed. Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (itemManager.WeaponData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                    return;
                }

                lbDetails.Items.Add(newData);
                itemManager.WeaponData.Add(newData.Name, newData);
            }
        }
        void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem;
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete " + entity + "?",
                    "Delete",
                    MessageBoxButtons.YesNo);
            
                if (result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    itemManager.WeaponData.Remove(entity);
                
                    if (File.Exists(FormMain.ItemPath + @"\Weapon\" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + @"\Weapon\" + entity + ".xml");
                }
            }
        }

        #endregion
            
        #region Method Region

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.ItemManager.WeaponData.Keys)
                lbDetails.Items.Add(FormDetails.ItemManager.WeaponData[s]);
        }

        private void AddWeapon(WeaponData weaponData)
        {
            if (FormDetails.ItemManager.WeaponData.ContainsKey(weaponData.Name))
            {
                DialogResult result = MessageBox.Show(
                    weaponData.Name + " already exists. Overwrite it?",
                    "Existing weapon",
                    MessageBoxButtons.YesNo);
            
                if (result == DialogResult.No)
                    return;
                
                itemManager.WeaponData[weaponData.Name] = weaponData;
                FillListBox();
                
                return;
            }

            itemManager.WeaponData.Add(weaponData.Name, weaponData);
            lbDetails.Items.Add(weaponData);
        }

        #endregion
    }
}
