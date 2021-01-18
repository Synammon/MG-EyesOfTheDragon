using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public class EntityData
    {
        #region Field Region

        public string EntityName;
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

        public EntityData(
            string entityName,
            int strength,
            int dexterity,
            int cunning,
            int willpower,
            int magic,
            int constitution,
            string health,
            string stamina,
            string mana)
        {
            EntityName = entityName;
            Strength = strength;
            Dexterity = dexterity;
            Cunning = cunning;
            Willpower = willpower;
            Cunning = cunning;
            Willpower = willpower;
            Magic = magic;
            Constitution = constitution;
            HealthFormula = health;
            StaminaFormula = stamina;
            MagicFormula = mana;
        }

        #endregion

        #region Method Region

        public override string ToString()
        {
            string toString = "Name = " + EntityName + ", ";

            toString += "Strength = " + Strength.ToString() + ", ";
            toString += "Dexterity = " + Dexterity.ToString() + ", ";
            toString += "Cunning = " + Cunning.ToString() + ", ";
            toString += "Willpower = " + Willpower.ToString() + ", ";
            toString += "Magic = " + Magic.ToString() + ", ";
            toString += "Constitution = " + Constitution.ToString() + ", ";
            toString += "Health Formula = " + HealthFormula + ", ";
            toString += "Stamina Formula = " + StaminaFormula + ", ";
            toString += "Magic Formula = " + MagicFormula;

            return toString;
        }

        public object Clone()
        {
            EntityData data = new EntityData
            {
                EntityName = EntityName,
                Strength = Strength,
                Dexterity = Dexterity,
                Cunning = Cunning,
                Willpower = Willpower,
                Magic = Magic,
                Constitution = Constitution,
                HealthFormula = HealthFormula,
                StaminaFormula = StaminaFormula,
                MagicFormula = MagicFormula
            };

            return data;
        }
 
        #endregion
    }
}