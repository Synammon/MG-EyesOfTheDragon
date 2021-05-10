using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Shield : BaseItem
    {
        #region Field Region

        int defenseValue;
        int defenseModifier;

        #endregion

        #region Property Region

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

        public Shield(
            string shieldName,
            string shieldType,
            int price,
            float weight,
            int defenseValue,
            int defenseModifier,
            params string[] allowableClasses)
            : base(shieldName, shieldType, price, weight, allowableClasses)
        {
            DefenseValue = defenseValue;
            DefenseModifier = defenseModifier;
        }

        public Shield(ShieldData shieldData)
            : base(shieldData.Name, shieldData.Type, shieldData.Price, shieldData.Weight, shieldData.AllowableClasses)
        {
            DefenseValue = shieldData.DefenseValue;
            DefenseModifier = shieldData.DefenseModifier;
        }

        #endregion

        #region Abstract Method Region

        public override object Clone()
        {
            string[] allowedClasses = new string[allowableClasses.Count];

            for (int i = 0; i < allowableClasses.Count; i++)
                allowedClasses[i] = allowableClasses[i];

            Shield shield = new Shield(
                Name,
                Type,
                Price,
                Weight,
                DefenseValue,
                DefenseModifier,
                allowedClasses);

            return shield;
        }
        public override string ToString()
        {
            string shieldString = base.ToString() + ", ";

            shieldString += DefenseValue.ToString() + ", ";
            shieldString += DefenseModifier.ToString();

            foreach (string t in allowableClasses)
                shieldString += ", " + t;

            return shieldString;
        }
        #endregion
    }
}
