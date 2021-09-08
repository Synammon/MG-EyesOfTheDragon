using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgLibrary.CharacterClasses;

namespace RpgLibrary
{
    public enum DieType { D4 = 4, D6 = 6, D8 = 8, D10 = 10, D12 = 12, D20 = 20, D100 = 100 }

    public static class Mechanics
    {
        #region Field Region

        static Random random = new Random();

        public static int GetModifier(int value)
        {
            if (value <= 3)
            {
                return -4;
            }

            if (value <= 5)
            {
                return -2;
            }

            if (value <= 8)
            {
                return -1;
            }

            if (value > 8 && value <= 12)
            {
                return 0;
            }

            if (value <= 14)
            {
                return 1;
            }

            if (value <= 16)
            {
                return 2;
            }

            if (value <= 18)
            {
                return 3;
            }

            if (value <= 20)
            {
                return 4;
            }

            return 5;
        }

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region
        #endregion

        #region Method Region

        public static int RollDie(DieType die)
        {
            return random.Next(0, (int)die) + 1;
        }

        public static int GetAttributeByString(Entity entity, string attribute)
        {
            int value = 0;

            switch (attribute.ToLower())
            {
                case "strength":
                    value = entity.Strength;
                    break;
                case "dexterity":
                    value = entity.Dexterity;
                    break;
                case "cunning":
                    value = entity.Cunning;
                    break;
                case "willpower":
                    value = entity.Willpower;
                    break;
                case "magic":
                    value = entity.Magic;
                    break;
                case "constitution":
                    value = entity.Constitution;
                    break;
            }

            return value;
        }

        #endregion

        #region Virtual Method Region
        #endregion
    }
}
