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
    public partial class FormKey : FormDetails
    {
        #region Field Region
        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public FormKey()
        {
            InitializeComponent();

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        #endregion

        #region Event Handler Region

        void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormKeyDetails frmKeyDetails = new FormKeyDetails())
            {
                frmKeyDetails.ShowDialog();

                if (frmKeyDetails.Key != null)
                {
                    AddKey(frmKeyDetails.Key);
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

                KeyData data = itemManager.KeyData[entity];
                KeyData newData = null;

                using (FormKeyDetails frmKeyData = new FormKeyDetails())
                {
                    frmKeyData.Key = data;
                    frmKeyData.ShowDialog();

                    if (frmKeyData.Key == null)
                        return;

                    if (frmKeyData.Key.Name == entity)
                    {
                        itemManager.KeyData[entity] = frmKeyData.Key;
                        FillListBox();
                        return;
                    }

                    newData = frmKeyData.Key;
                }

                DialogResult result = MessageBox.Show(
                    "Name has changed. Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);
            
                if (result == DialogResult.No)
                    return;
                
                if (itemManager.KeyData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                    return;
                }
                
                lbDetails.Items.Add(newData);
                itemManager.KeyData.Add(newData.Name, newData);
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
                    itemManager.ChestData.Remove(entity);
                    if (File.Exists(FormMain.KeyPath + @"\" + entity + ".xml"))
                        File.Delete(FormMain.KeyPath + @"\" + entity + ".xml");
                }
            }
        }
        #endregion

        #region Method Region

        public void FillListBox()
        {
            lbDetails.Items.Clear();
        
            foreach (string s in FormDetails.ItemManager.KeyData.Keys)
                lbDetails.Items.Add(FormDetails.ItemManager.KeyData[s]);
        }

        private void AddKey(KeyData keyData)
        {
            if (FormDetails.ItemManager.KeyData.ContainsKey(keyData.Name))
            {
                DialogResult result = MessageBox.Show(
                    keyData.Name + " already exists. Overwrite it?",
                    "Existing key",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                itemManager.KeyData[keyData.Name] = keyData;

                FillListBox();

                return;
            }

            itemManager.KeyData.Add(keyData.Name, keyData);
            lbDetails.Items.Add(keyData);
        }

        #endregion
    }
}
