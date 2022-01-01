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
    public partial class FormSpell : FormDetails
    {
        public FormSpell()
        {
            InitializeComponent();

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormSpellDetails frmSpell = new FormSpellDetails();
            frmSpell.ShowDialog();

            if (frmSpell.Spell != null)
            {
                AddSpell(frmSpell.Spell);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
        }

        private void BtnDelete_Click(object sender, EventArgs e)
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
                    SpellDataManager.SpellData.Remove(entity);
                }
            }
        }

        private void AddSpell(SpellData spellData)
        {
            if (FormDetails.SpellDataManager.SpellData.ContainsKey(spellData.Name))
            {
                DialogResult result = MessageBox.Show(
                    spellData.Name + " already exists. Overwrite it?",
                    "Existing spell",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                SpellDataManager.SpellData[spellData.Name] = spellData;
                FillListBox();

                return;
            }

            SpellDataManager.SpellData.Add(spellData.Name, spellData);
            lbDetails.Items.Add(spellData);
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.SpellDataManager.SpellData.Keys)
                lbDetails.Items.Add(FormDetails.SpellDataManager.SpellData[s]);
        }
    }
}
