using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ItemManager
    {
        #region Fields Region

        static readonly Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();
        static readonly Dictionary<string, Armor> armors = new Dictionary<string, Armor>();
        static readonly Dictionary<string, Shield> shields = new Dictionary<string, Shield>();

        #endregion

        #region Keys Property Region

        public static Dictionary<string, Weapon>.KeyCollection WeaponKeys
        {
            get { return weapons.Keys; }
        }

        public static Dictionary<string, Armor>.KeyCollection ArmorKeys
        {
            get { return armors.Keys; }
        }

        public static Dictionary<string, Shield>.KeyCollection ShieldKeys
        {
            get { return shields.Keys; }
        }

        #endregion

        #region Constructor Region
        public ItemManager()
        {
        }

        #endregion

        #region Weapon Methods

        public static void AddWeapon(Weapon weapon)
        {
            if (!weapons.ContainsKey(weapon.Name))
            {
                weapons.Add(weapon.Name, weapon);
            }
        }

        public static Weapon GetWeapon(string name)
        {
            if (weapons.ContainsKey(name))
            {
                return (Weapon)weapons[name].Clone();
            }

            return null;
        }

        public static bool ContainsWeapon(string name)
        {
            return weapons.ContainsKey(name);
        }

        #endregion

        #region Armor Methods

        public static void AddArmor(Armor armor)
        {
            if (!armors.ContainsKey(armor.Name))
            {
                armors.Add(armor.Name, armor);
            }
        }

        public static Armor GetArmor(string name)
        {
            if (armors.ContainsKey(name))
            {
                return (Armor)armors[name].Clone();
            }

            return null;
        }

        public static bool ContainsArmor(string name)
        {
            return armors.ContainsKey(name);
        }

        #endregion

        #region Shield Methods

        public static void AddShield(Shield shield)
        {
            if (!shields.ContainsKey(shield.Name))
            {
                shields.Add(shield.Name, shield);
            }
        }

        public static Shield GetShield(string name)
        {
            if (shields.ContainsKey(name))
            {
                return (Shield)shields[name].Clone();
            }

            return null;
        }

        public static bool ContainsShield(string name)
        {
            return shields.ContainsKey(name);
        }

        #endregion
    }
}
