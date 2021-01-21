using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormMain : Form
    {
        #region Field Region

        RolePlayingGame rolePlayingGame;
        FormClasses frmClasses;
        FormArmor frmArmor;
        FormShield frmShield;
        FormWeapon frmWeapon;
        static string gamePath = "";
        static string classPath = "";
        static string itemPath = "";

        #endregion

        #region Property Region

        public static string GamePath
        {
            get { return gamePath; }
        }

        public static string ClassPath
        {
            get { return classPath; }
        }

        public static string ItemPath
        {
            get { return itemPath; }
        }

        #endregion

        #region Constructor Region

        public FormMain()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormMain_FormClosing);

            newGameToolStripMenuItem.Click += new EventHandler(newGameToolStripMenuItem_Click);
            openGameToolStripMenuItem.Click += new EventHandler(openGameToolStripMenuItem_Click);
            saveGameToolStripMenuItem.Click += new EventHandler(saveGameToolStripMenuItem_Click);
            exitToolStripMenuItem.Click += new EventHandler(exitToolStripMenuItem_Click);
            classesToolStripMenuItem.Click += new EventHandler(classesToolStripMenuItem_Click);
            armorToolStripMenuItem.Click += new EventHandler(armorToolStripMenuItem_Click);
            shieldToolStripMenuItem.Click += new EventHandler(shieldToolStripMenuItem_Click);
            weaponToolStripMenuItem.Click += new EventHandler(weaponToolStripMenuItem_Click);
        }

        void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Unsaved changes will be lost. Are you sure you want to exit?",
                "Exit?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                e.Cancel = true;
        }
        #endregion

        #region Menu Item Event Handler Region
        void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewGame frmNewGame = new FormNewGame())
            {
                DialogResult result = frmNewGame.ShowDialog();

                if (result == DialogResult.OK && frmNewGame.RolePlayingGame != null)
                {
                    FolderBrowserDialog folderDialog = new FolderBrowserDialog();

                    folderDialog.Description = "Select folder to create game in.";
                    folderDialog.SelectedPath = Application.StartupPath;

                    DialogResult folderResult = folderDialog.ShowDialog();

                    if (folderResult == DialogResult.OK)
                    {
                        try
                        {
                            gamePath = Path.Combine(folderDialog.SelectedPath, "Game");
                            classPath = Path.Combine(gamePath, "Classes");
                            itemPath = Path.Combine(gamePath, "Items");

                            if (Directory.Exists(gamePath))
                                throw new Exception("Selected directory already exists.");

                            Directory.CreateDirectory(gamePath);
                            Directory.CreateDirectory(classPath);
                            Directory.CreateDirectory(itemPath + @"\Armor");
                            Directory.CreateDirectory(itemPath + @"\Shield");
                            Directory.CreateDirectory(itemPath + @"\Weapon");

                            rolePlayingGame = frmNewGame.RolePlayingGame;

                            XnaSerializer.Serialize<RolePlayingGame>(gamePath + @"\Game.xml",
                            rolePlayingGame);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            return;
                        }

                        classesToolStripMenuItem.Enabled = true;
                        itemsToolStripMenuItem.Enabled = true;
                    }
                }
            }
        }

        void openGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            
            folderDialog.Description = "Select Game folder";
            folderDialog.SelectedPath = Application.StartupPath;
            
            bool tryAgain = false;
            
            do
            {
                DialogResult folderResult = folderDialog.ShowDialog();
                DialogResult msgBoxResult;

                if (folderResult == DialogResult.OK)
                {
                    if (File.Exists(folderDialog.SelectedPath + @"\Game\Game.xml"))
                    {
                        try
                        {
                            OpenGame(folderDialog.SelectedPath);
                            tryAgain = false;
                        }
                        catch (Exception ex)
                        {
                            msgBoxResult = MessageBox.Show(
                                ex.ToString(),
                                "Error opening game.",
                                MessageBoxButtons.RetryCancel);
                            
                            if (msgBoxResult == DialogResult.Cancel)
                                tryAgain = false;
                            else if (msgBoxResult == DialogResult.Retry)
                                tryAgain = true;
                        }
                    }
                    else
                    {
                        msgBoxResult = MessageBox.Show(
                            "Game not found, try again?",
                            "Game does not exist",
                            MessageBoxButtons.RetryCancel);
            
                        if (msgBoxResult == DialogResult.Cancel)
                            tryAgain = false;
                        else if (msgBoxResult == DialogResult.Retry)
                            tryAgain = true;
                    }
                }
            } while (tryAgain);
        }
        private void OpenGame(string path)
        {
            gamePath = Path.Combine(path, "Game");
            classPath = Path.Combine(gamePath, "Classes");
            itemPath = Path.Combine(gamePath, "Items");

            rolePlayingGame = XnaSerializer.Deserialize<RolePlayingGame>(
                gamePath + @"\Game.xml");

            FormDetails.ReadEntityData();
            FormDetails.ReadItemData();

            PrepareForms();
        }
        private void PrepareForms()
        {
            if (frmClasses == null)
            {
                frmClasses = new FormClasses();
                frmClasses.MdiParent = this;
            }

            frmClasses.FillListBox();

            if (frmArmor == null)
            {
                frmArmor = new FormArmor();
                frmArmor.MdiParent = this;
            }

            frmArmor.FillListBox();

            if (frmShield == null)
            {
                frmShield = new FormShield();
                frmShield.MdiParent = this;
            }

            frmShield.FillListBox();

            if (frmWeapon == null)
            {
                frmWeapon = new FormWeapon();
                frmWeapon.MdiParent = this;
            }

            frmWeapon.FillListBox();

            classesToolStripMenuItem.Enabled = true;
            itemsToolStripMenuItem.Enabled = true;
        }

        void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rolePlayingGame != null)
            {
                try
                {
                    XnaSerializer.Serialize<RolePlayingGame>(gamePath + @"\Game.xml", rolePlayingGame);

                    FormDetails.WriteEntityData();
                    FormDetails.WriteItemData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error saving game.");
                }
            }
        }

        void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmClasses == null)
            {
                frmClasses = new FormClasses();
                frmClasses.MdiParent = this;
            }

            frmClasses.Show();
            frmClasses.BringToFront();
        }

        void armorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmArmor == null)
            {
                frmArmor = new FormArmor();
                frmArmor.MdiParent = this;
            }

            frmArmor.Show();
            frmArmor.BringToFront();
        }

        void shieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmShield == null)
            {
                frmShield = new FormShield();
                frmShield.MdiParent = this;
            }

            frmShield.Show();
            frmShield.BringToFront();
        }

        void weaponToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmWeapon == null)
            {
                frmWeapon = new FormWeapon();
                frmWeapon.MdiParent = this;
            }
        
            frmWeapon.Show();
            frmWeapon.BringToFront();
        }
        
        #endregion


        #region Method Region
        #endregion
    }
}
