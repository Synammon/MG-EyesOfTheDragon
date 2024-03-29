﻿using System;
using System.Windows.Forms;
using System.IO;
using RpgLibrary;

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
        FormKey frmKey;
        FormChest frmChest;
        FormSkill frmSkill;
        FormSpell frmSpell;

        public static string SpellPath { get; private set; }

        static string gamePath = "";
        static string classPath = "";
        static string itemPath = "";
        static string chestPath = "";
        static string keyPath = "";
        static string skillPath = "";

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

        public static string ChestPath
        {
            get { return chestPath; }
        }

        public static string KeyPath
        {
            get { return keyPath; }
        }

        public static string SkillPath
        {
            get { return skillPath; }
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
            keysToolStripMenuItem.Click += new EventHandler(keysToolStripMenuItem_Click);
            chestsToolStripMenuItem.Click += new EventHandler(chestsToolStripMenuItem_Click);
            skillsToolStripMenuItem.Click += new EventHandler(skillsToolStripMenuItem_Click);
            spellsToolStripMenuItem.Click += SpellsToolStripMenuItem_Click;
        }

        void skillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSkill == null)
            {
                frmSkill = new FormSkill();
                frmSkill.MdiParent = this;
            }
        
            frmSkill.Show();
            frmSkill.BringToFront();
        }
        
        #endregion

        #region Menu Item Event Handler Region

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
                            keyPath = Path.Combine(gamePath, "Keys");
                            chestPath = Path.Combine(gamePath, "Chests");
                            skillPath = Path.Combine(gamePath, "Skills");
                            SpellPath = Path.Combine(gamePath, "Spells");

                            if (Directory.Exists(gamePath))
                                throw new Exception("Selected directory already exists.");
    
                            Directory.CreateDirectory(gamePath);
                            Directory.CreateDirectory(classPath);
                            Directory.CreateDirectory(itemPath + @"\Armor");
                            Directory.CreateDirectory(itemPath + @"\Shield");
                            Directory.CreateDirectory(itemPath + @"\Weapon");
                            Directory.CreateDirectory(keyPath);
                            Directory.CreateDirectory(chestPath);
                            Directory.CreateDirectory(skillPath);
                            Directory.CreateDirectory(SpellPath);

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
                        keysToolStripMenuItem.Enabled = true;
                        chestsToolStripMenuItem.Enabled = true;
                        skillsToolStripMenuItem.Enabled = true;
                        spellsToolStripMenuItem.Enabled = true;
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

        void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rolePlayingGame != null)
            {
                try
                {
                    XnaSerializer.Serialize<RolePlayingGame>(gamePath + @"\Game.xml", rolePlayingGame);

                    FormDetails.WriteEntityData();
                    FormDetails.WriteItemData();
                    FormDetails.WriteChestData();
                    FormDetails.WriteKeyData();
                    FormDetails.WriteSkillData();
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

        void chestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmChest == null)
            {
                frmChest = new FormChest();
                frmChest.MdiParent = this;
            }

            frmChest.Show();
            frmChest.BringToFront();
        }

        void keysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmKey == null)
            {
                frmKey = new FormKey();
                frmKey.MdiParent = this;
            }

            frmKey.Show();
            frmKey.BringToFront();
        }

        private void SpellsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSpell == null)
            {
                frmSpell = new FormSpell
                {
                    MdiParent = this
                };
            }

            frmSpell.Show();
            frmSpell.BringToFront();
        }

        #endregion

        #region Method Region

        private void OpenGame(string path)
        {
            gamePath = Path.Combine(path, "Game");
            classPath = Path.Combine(gamePath, "Classes");
            itemPath = Path.Combine(gamePath, "Items");
            keyPath = Path.Combine(gamePath, "Keys");
            chestPath = Path.Combine(gamePath, "Chests");            
            skillPath = Path.Combine(gamePath, "Skills");
            SpellPath = Path.Combine(gamePath, "Spells");

            if (!Directory.Exists(keyPath))
            {
                Directory.CreateDirectory(keyPath);
            }
            
            if (!Directory.Exists(chestPath))
            {
                Directory.CreateDirectory(chestPath);
            }
            
            if (!Directory.Exists(skillPath))
            {
                Directory.CreateDirectory(skillPath);
            }
    
            rolePlayingGame = XnaSerializer.Deserialize<RolePlayingGame>(
                gamePath + @"\Game.xml");

            FormDetails.ReadEntityData();
            FormDetails.ReadItemData();
            FormDetails.ReadKeyData();
            FormDetails.ReadChestData();
            FormDetails.ReadSkillData();

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

            if (frmKey == null)
            {
                frmKey = new FormKey();
                frmKey.MdiParent = this;
            }

            frmKey.FillListBox();

            if (frmChest == null)
            {
                frmChest = new FormChest();
                frmChest.MdiParent = this;
            }

            frmChest.FillListBox();

            if (frmSkill == null)
            {
                frmSkill = new FormSkill();
                frmSkill.MdiParent = this;
            }

            frmSkill.FillListBox();

            if (frmSpell == null)
            {
                frmSpell = new FormSpell();
                frmSpell.MdiParent = this;
            }

            frmSpell.FillListBox();

            classesToolStripMenuItem.Enabled = true;
            itemsToolStripMenuItem.Enabled = true;
            keysToolStripMenuItem.Enabled = true;
            chestsToolStripMenuItem.Enabled = true;
            skillsToolStripMenuItem.Enabled = true;
            spellsToolStripMenuItem.Enabled = true;
        }

        #endregion
    }
}
