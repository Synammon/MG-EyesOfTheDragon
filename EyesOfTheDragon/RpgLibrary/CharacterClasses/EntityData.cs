using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public class EntityData
    {
        #region Field Region

        public string ClassName;
        public int Strength;
        public int Dexterity;
        public int Cunning;
        public int Willpower;
        public int Magic;
        public int Constitution;
        public string HealthFormula;
        public string StaminaFormula;
        public string MagicFormula;

        #endregion

        #region Constructor Region

        private EntityData()
        {
        }

        #endregion

        #region Static Method Region

        public static void ToFile(string filename)
        {
        }

        public static EntityData FromFile(string filename)
        {
            EntityData entity = new EntityData();

            return entity;
        }
        #endregion
    }
}
