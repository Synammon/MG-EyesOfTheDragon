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
    public partial class FormArmor : FormDetails
    {
        #region Field Region
        #endregion

        #region Property Region

        #endregion

        #region Constructor Region

        public FormArmor()
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
            using (FormArmorDetails frmArmorDetails = new FormArmorDetails())
            {
                frmArmorDetails.ShowDialog();

                if (frmArmorDetails.Armor != null)
                {
                    AddArmor(frmArmorDetails.Armor);
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

                ArmorData data = itemManager.ArmorData[entity];
                ArmorData newData = null;

                using (FormArmorDetails frmArmorData = new FormArmorDetails())
                {
                    frmArmorData.Armor = data;
                    frmArmorData.ShowDialog();

                    if (frmArmorData.Armor == null)
                        return;

                    if (frmArmorData.Armor.Name == entity)
                    {
                        itemManager.ArmorData[entity] = frmArmorData.Armor;
                        FillListBox();

                        return;
                    }

                    newData = frmArmorData.Armor;
                }

                DialogResult result = MessageBox.Show(
                    "Name has changed. Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (itemManager.ArmorData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                    return;
                }

                lbDetails.Items.Add(newData);
                itemManager.ArmorData.Add(newData.Name, newData);
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
                    itemManager.ArmorData.Remove(entity);
                  
                    if (File.Exists(FormMain.ItemPath + @"\Armor\" + entity + ".xml"))
                        File.Delete(FormMain.ItemPath + @"\Armor\" + entity + ".xml");
                }
            }
        }

        #endregion

        #region Method Region

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.ItemManager.ArmorData.Keys)
                lbDetails.Items.Add(FormDetails.ItemManager.ArmorData[s]);
        }

        private void AddArmor(ArmorData armorData)
        {
            if (FormDetails.ItemManager.ArmorData.ContainsKey(armorData.Name))
            {
                DialogResult result = MessageBox.Show(
                    armorData.Name + " already exists. Overwrite it?",
                    "Existing armor",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                itemManager.ArmorData[armorData.Name] = armorData;
                FillListBox();
                return;
            }
            itemManager.ArmorData.Add(armorData.Name, armorData);
            lbDetails.Items.Add(armorData);
        }

        #endregion
    }
}
