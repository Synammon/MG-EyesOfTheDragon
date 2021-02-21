using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using RpgLibrary.SkillClasses;

namespace RpgEditor
{
    public partial class FormSkill : FormDetails
    {
        #region Constructor Region
        
        public FormSkill()
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
            using (FormSkillDetails frmSkillDetails = new FormSkillDetails())
            {
                frmSkillDetails.ShowDialog();
        
                if (frmSkillDetails.Skill != null)
                {
                    AddSkill(frmSkillDetails.Skill);
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
                
                SkillData data = skillManager.SkillData[entity];
                SkillData newData = null;
                
                using (FormSkillDetails frmSkillData = new FormSkillDetails())
                {
                    frmSkillData.Skill = data;
                    frmSkillData.ShowDialog();
                    
                    if (frmSkillData.Skill == null)
                        return;
                   
                    if (frmSkillData.Skill.Name == entity)
                    {
                        skillManager.SkillData[entity] = frmSkillData.Skill;
                        FillListBox();
                
                        return;
                    }
                    newData = frmSkillData.Skill;
                }

                DialogResult result = MessageBox.Show(
                    "Name has changed. Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);
                
                if (result == DialogResult.No)
                    return;
                
                if (skillManager.SkillData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                    return;
                }
        
                lbDetails.Items.Add(newData);
                skillManager.SkillData.Add(newData.Name, newData);
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
                    itemManager.KeyData.Remove(entity);

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
        
            foreach (string s in FormDetails.SkillManager.SkillData.Keys)
                lbDetails.Items.Add(FormDetails.SkillManager.SkillData[s]);
        }
        
        private void AddSkill(SkillData skillData)
        {
            if (FormDetails.SkillManager.SkillData.ContainsKey(skillData.Name))
            {
                DialogResult result = MessageBox.Show(
                    skillData.Name + " already exists. Overwrite it?",
                    "Existing armor",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                skillManager.SkillData[skillData.Name] = skillData;
                FillListBox();

                return;
            }

            skillManager.SkillData.Add(skillData.Name, skillData);
            lbDetails.Items.Add(skillData);
        }

        #endregion
    }
}
