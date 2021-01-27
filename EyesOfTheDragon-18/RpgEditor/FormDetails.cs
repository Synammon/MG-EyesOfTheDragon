using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.ItemClasses;
using RpgLibrary.CharacterClasses;

namespace RpgEditor
{
    public partial class FormDetails : Form
    {
        #region Field Region

        protected static ItemDataManager itemManager;
        protected static EntityDataManager entityDataManager;

        #endregion

        #region Property Region

        public static ItemDataManager ItemManager
        {
            get { return itemManager; }
            private set { itemManager = value; }
        }

        public static EntityDataManager EntityDataManager
        {
            get { return entityDataManager; }
            private set { entityDataManager = value; }
        }

        #endregion

        #region Constructor Region

        public FormDetails()
        {
            InitializeComponent();

            if (FormDetails.ItemManager == null)
                ItemManager = new ItemDataManager();

            if (FormDetails.EntityDataManager == null)
                EntityDataManager = new EntityDataManager();
            this.FormClosing += new FormClosingEventHandler(FormDetails_FormClosing);
        }

        #endregion

        #region Event Handler Region

        void FormDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }

            if (e.CloseReason == CloseReason.MdiFormClosing)
            {
                e.Cancel = false;
                this.Close();
            }
        }

        #endregion
        public static void WriteEntityData()
        {
            foreach (string s in EntityDataManager.EntityData.Keys)
            {
                XnaSerializer.Serialize<EntityData>(
                    FormMain.ClassPath + @"\" + s + ".xml",
                    EntityDataManager.EntityData[s]);
            }
        }

        public static void WriteItemData()
        {
            foreach (string s in ItemManager.ArmorData.Keys)
            {
                XnaSerializer.Serialize<ArmorData>(
                    FormMain.ItemPath + @"\Armor\" + s + ".xml",
                    ItemManager.ArmorData[s]);
            }

            foreach (string s in ItemManager.ShieldData.Keys)
            {
                XnaSerializer.Serialize<ShieldData>(
                    FormMain.ItemPath + @"\Shield\" + s + ".xml",
                    ItemManager.ShieldData[s]);
            }

            foreach (string s in ItemManager.WeaponData.Keys)
            {
                XnaSerializer.Serialize<WeaponData>(
                    FormMain.ItemPath + @"\Weapon\" + s + ".xml",
                    ItemManager.WeaponData[s]);
            }
        }

        public static void ReadEntityData()
        {
            entityDataManager = new EntityDataManager();
            
            string[] fileNames = Directory.GetFiles(FormMain.ClassPath, "*.xml");
            
            foreach (string s in fileNames)
            {
                EntityData entityData = XnaSerializer.Deserialize<EntityData>(s);
                entityDataManager.EntityData.Add(entityData.EntityName, entityData);
            }
        }
        public static void ReadItemData()
        {
            itemManager = new ItemDataManager();
     
            string[] fileNames = Directory.GetFiles(
                Path.Combine(FormMain.ItemPath, "Armor"),
                "*.xml");

            foreach (string s in fileNames)
            {
                ArmorData armorData = XnaSerializer.Deserialize<ArmorData>(s);
                itemManager.ArmorData.Add(armorData.Name, armorData);
            }

            fileNames = Directory.GetFiles(
                Path.Combine(FormMain.ItemPath, "Shield"),
                "*.xml");

            foreach (string s in fileNames)
            {
                ShieldData shieldData = XnaSerializer.Deserialize<ShieldData>(s);
                itemManager.ShieldData.Add(shieldData.Name, shieldData);
            }

            fileNames = Directory.GetFiles(
                Path.Combine(FormMain.ItemPath, "Weapon"),
                "*.xml");
            
            foreach (string s in fileNames)
            {
                WeaponData weaponData = XnaSerializer.Deserialize<WeaponData>(s);
                itemManager.WeaponData.Add(weaponData.Name, weaponData);
            }
        }

        public static void WriteKeyData()
        {
            foreach (string s in ItemManager.KeyData.Keys)
            {
                XnaSerializer.Serialize<KeyData>(
                    FormMain.KeyPath + @"\" + s + ".xml",
                    ItemManager.KeyData[s]);
            }
        }

        public static void WriteChestData()
        {
            foreach (string s in ItemManager.ChestData.Keys)
            {
                XnaSerializer.Serialize<ChestData>(
                    FormMain.ChestPath + @"\" + s + ".xml",
                    ItemManager.ChestData[s]);
            }
        }

        public static void ReadKeyData()
        {
            string[] fileNames = Directory.GetFiles(FormMain.KeyPath, "*.xml");

            foreach (string s in fileNames)
            {
                KeyData keyData = XnaSerializer.Deserialize<KeyData>(s);
                itemManager.KeyData.Add(keyData.Name, keyData);
            }
        }

        public static void ReadChestData()
        {
            string[] fileNames = Directory.GetFiles(FormMain.ChestPath, "*.xml");

            foreach (string s in fileNames)
            {
                ChestData chestData = XnaSerializer.Deserialize<ChestData>(s);
                itemManager.ChestData.Add(chestData.Name, chestData);
            }
        }

    }
}
