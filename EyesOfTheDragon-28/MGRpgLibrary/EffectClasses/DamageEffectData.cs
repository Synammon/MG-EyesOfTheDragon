using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RpgLibrary.EffectClasses
{
    public enum DamageType
    {
        Crushing, Slashing, Piercing, Poison, Disease, Fire, Ice, Lightning,
        Earth
    }

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
        #endregion
    }
}
