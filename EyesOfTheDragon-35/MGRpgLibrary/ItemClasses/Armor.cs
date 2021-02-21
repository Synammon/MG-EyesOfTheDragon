using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Armor : BaseItem
    {
        #region Field Region

        ArmorLocation location;
        int defenseValue;
        int defenseModifier;

        #endregion

        #region Property Region
        public ArmorLocation Location
        {
            get { return location; }
            protected set { location = value; }
        }

        public int DefenseValue
        {
            get { return defenseValue; }
            protected set { defenseValue = value; }
        }

        public int DefenseModifier
        {
            get { return defenseModifier; }
            protected set { defenseModifier = value; }
        }

        #endregion

        #region Constructor Region

        public Armor(
            string armorName,
            string armorType,
            int price,
            float weight,
            ArmorLocation locaion,
            int defenseValue,
            int defenseModifier,
            params string[] allowableClasses)
            : base(armorName, armorType, price, weight, allowableClasses)
        {
            Location = location;
            DefenseValue = defenseValue;
            DefenseModifier = defenseModifier;
        }

        #endregion

        #region Abstract Method Region

        public override object Clone()
        {
            string[] allowedClasses = new string[allowableClasses.Count];

            for (int i = 0; i < allowableClasses.Count; i++)
                allowedClasses[i] = allowableClasses[i];

            Armor armor = new Armor(
                Name,
                Type,
                Price,
                Weight,
                Location,
                DefenseValue,
                DefenseModifier,
                allowedClasses);

            return armor;
        }

        public override string ToString()
        {
            string armorString = base.ToString() + ", ";

            armorString += Location.ToString() + ", ";
            armorString += DefenseValue.ToString() + ", ";
            armorString += DefenseModifier.ToString();

            foreach (string t in allowableClasses)
                armorString += ", " + t;

            return armorString;
        }
        #endregion
    }
}
