using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.ItemClasses;
using RpgLibrary.TrapClasses;
using RpgLibrary.SkillClasses;

namespace RpgEditor
{
    public partial class FormChestDetails : Form
    {
        #region Field Region

        ChestData chest;

        #endregion
        #region Property Region

        public ChestData Chest
        {
            get { return chest; }
            set { chest = value; }
        }

        #endregion

        #region Constructor Region

        public FormChestDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormChestDetails_Load);
            this.FormClosing += new FormClosingEventHandler(FormChestDetails_FormClosing);

            foreach (string s in Enum.GetNames(typeof(DifficultyLevel)))
            {
                cboDifficulty.Items.Add(s);
            }

            cboDifficulty.SelectedIndex = 0;

            cbLock.CheckedChanged += new EventHandler(cbLock_CheckedChanged);
            cbTrap.CheckedChanged += new EventHandler(cbTrap_CheckedChanged);

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnRemove.Click += new EventHandler(btnRemove_Click);

            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion

        #region Form Event Handler Region

        void FormChestDetails_Load(object sender, EventArgs e)
        {
            if (chest != null)
            {
                tbName.Text = chest.Name;
                cbLock.Checked = chest.IsLocked;
                tbKeyName.Text = chest.KeyName;
                tbKeyType.Text = chest.KeyType;
                nudKeys.Value = (decimal)chest.KeysRequired;
                tbKeyName.Enabled = chest.IsLocked;
                tbKeyType.Enabled = chest.IsLocked;
                nudKeys.Enabled = chest.IsLocked;
                cbTrap.Checked = chest.IsTrapped;
                tbTrap.Text = chest.TrapName;
                tbTrap.Enabled = chest.IsTrapped;
                nudMinGold.Value = (decimal)chest.MinGold;
                nudMaxGold.Value = (decimal)chest.MaxGold;
            }
        }

        void FormChestDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Check Box Event Handler Region

        void cbLock_CheckedChanged(object sender, EventArgs e)
        {
            cboDifficulty.Enabled = cbLock.Checked;

            tbKeyName.Enabled = cbLock.Checked;
            tbKeyType.Enabled = cbLock.Checked;

            nudKeys.Enabled = cbLock.Checked;
        }

        void cbTrap_CheckedChanged(object sender, EventArgs e)
        {
            tbTrap.Enabled = cbTrap.Checked;
        }

        #endregion

        #region Button Event Handler Region

        void btnAdd_Click(object sender, EventArgs e)
        {
        }

        void btnRemove_Click(object sender, EventArgs e)
        {
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the chest.");
                return;
            }

            if (cbTrap.Checked && string.IsNullOrEmpty(tbTrap.Text))
            {
                MessageBox.Show("You must supply a name for the trap on the chest.");
                return;
            }

            if (nudMaxGold.Value < nudMinGold.Value)
            {
                MessageBox.Show("Maximum gold in chest must be greater or equal to minimum gold.");
                return;
            }

            ChestData data = new ChestData();

            data.Name = tbName.Text;
            data.IsLocked = cbLock.Checked;

            if (cbLock.Checked)
            {
                data.DifficultyLevel = (DifficultyLevel)cboDifficulty.SelectedIndex;
                data.KeyName = tbKeyName.Text;
                data.KeyType = tbKeyType.Text;
                data.KeysRequired = (int)nudKeys.Value;
            }

            data.IsTrapped = cbTrap.Checked;

            if (cbTrap.Checked)
            {
                data.TrapName = tbTrap.Text;
            }

            data.MinGold = (int)nudMinGold.Value;
            data.MaxGold = (int)nudMaxGold.Value;

            chest = data;

            this.FormClosing -= FormChestDetails_FormClosing;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            chest = null;

            this.FormClosing -= FormChestDetails_FormClosing;
            this.Close();
        }

        #endregion
    }
}
