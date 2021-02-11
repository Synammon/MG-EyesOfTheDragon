using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.EffectClasses
{
    public enum HealType { Health, Mana, Stamina }

    public class HealEffectData : BaseEffectData
    {
        #region Field Region

        public HealType HealType;
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
