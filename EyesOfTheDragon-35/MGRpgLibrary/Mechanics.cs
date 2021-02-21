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
