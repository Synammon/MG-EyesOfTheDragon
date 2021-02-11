using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;
using RpgLibrary.SkillClasses;
using RpgLibrary.SpellClasses;
using RpgLibrary.TalentClasses;
using RpgLibrary.TrapClasses;

namespace EyesOfTheDragon.Components
{
    static class DataManager
    {
        #region Field Region

        static Dictionary<string, ArmorData> armor = new Dictionary<string, ArmorData>();
        static Dictionary<string, WeaponData> weapons = new Dictionary<string, WeaponData>();
        static Dictionary<string, ShieldData> shields = new Dictionary<string, ShieldData>();
        static Dictionary<string, KeyData> keys = new Dictionary<string, KeyData>();
        static Dictionary<string, ChestData> chests = new Dictionary<string, ChestData>();
        static Dictionary<string, EntityData> entities = new Dictionary<string, EntityData>();
        static Dictionary<string, SkillData> skills = new Dictionary<string, SkillData>();

        #endregion

        #region Property Region

        public static Dictionary<string, ArmorData> ArmorData
        {
            get { return armor; }
        }

        public static Dictionary<string, WeaponData> WeaponData
        {
            get { return weapons; }
        }

        public static Dictionary<string, ShieldData> ShieldData
        {
            get { return shields; }
        }

        public static Dictionary<string, EntityData> EntityData
        {
            get { return entities; }
        }

        public static Dictionary<string, ChestData> ChestData
        {
            get { return chests; }
        }

        public static Dictionary<string, KeyData> KeyData
        {
            get { return keys; }
        }

        public static Dictionary<string, SkillData> SkillData
        {
            get { return skills; }
        }

        #endregion

        #region Constructor Region
        #endregion

        #region Method Region

        public static void ReadEntityData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Classes", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Classes\" + Path.GetFileNameWithoutExtension(name);

                EntityData data = Content.Load<EntityData>(filename);
                EntityData.Add(data.EntityName, data);
            }
        }

        public static void ReadArmorData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Items\Armor", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Items\Armor\" + Path.GetFileNameWithoutExtension(name);

                ArmorData data = Content.Load<ArmorData>(filename);
                ArmorData.Add(data.Name, data);
            }
        }

        public static void ReadWeaponData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Items\Weapon", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Items\Weapon\" + Path.GetFileNameWithoutExtension(name);

                WeaponData data = Content.Load<WeaponData>(filename);
                WeaponData.Add(data.Name, data);
            }
        }

        public static void ReadShieldData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Items\Shield", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Items\Shield\" + Path.GetFileNameWithoutExtension(name);

                ShieldData data = Content.Load<ShieldData>(filename);
                ShieldData.Add(data.Name, data);
            }
        }

        public static void ReadKeyData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Keys", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Keys\" + Path.GetFileNameWithoutExtension(name);

                KeyData data = Content.Load<KeyData>(filename);
                KeyData.Add(data.Name, data);
            }
        }

        public static void ReadChestData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Chests", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Chests\" + Path.GetFileNameWithoutExtension(name);

                ChestData data = Content.Load<ChestData>(filename);
                ChestData.Add(data.Name, data);
            }
        }

        public static void ReadSkillData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Skills", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Skills\" + Path.GetFileNameWithoutExtension(name);
                SkillData data = Content.Load<SkillData>(filename);
                SkillData.Add(data.Name, data);
            }
        }

        #endregion

        #region Virtual Method region
        #endregion
    }
}

