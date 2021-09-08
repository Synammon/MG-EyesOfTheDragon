using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RpgLibrary.EffectClasses
{
    public enum DamageType { Crushing, Piercing, Slashing, Magic, Poison, Disease, Fire, Water, Air, Earth }

    public enum AttackType { Health, Mana, Stamina }

    public class DamageEffectData : BaseEffectData
    {
        #region Field Region

        public DamageType DamageType;
        public AttackType AttackType;
        public DieType DieType;
        public int NumberOfDice;
        public int Modifier;

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region
        #endregion

        #region Method Region
        #endregion

        #region Virtual Method Region

        public override string ToString()
        {
            string toString = Name + ", " + DamageType.ToString() + ", ";

            toString += AttackType.ToString() + ", ";
            toString += DieType.ToString() + ", ";
            toString += NumberOfDice.ToString() + ", ";
            toString += Modifier.ToString();

            return toString;
        }

        #endregion
    }
}
