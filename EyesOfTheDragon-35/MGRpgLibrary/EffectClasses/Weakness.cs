using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.EffectClasses
{
    public class Weakness
    {
        #region Field Region

        DamageType weakness;
        int amount;

        #endregion

        #region Property Region

        public DamageType WeaknessType
        {
            get { return weakness; }
            private set { weakness = value; }
        }

        public int Amount
        {
            get { return amount; }
            private set
            {
                amount = MathHelper.Clamp(amount, 0, 100);
            }
        }

        #endregion

        #region Constructor Region
        public Weakness(WeaknessData data)
        {
            WeaknessType = data.WeaknessType;
            Amount = data.Amount;
        }

        #endregion

        #region Method Region

        public int Apply(int damage)
        {
            return (damage + damage * amount / 100);
        }

        #endregion

        #region Virtual Method Region
        #endregion
    }
}
