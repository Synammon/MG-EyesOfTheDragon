using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Reagent : BaseItem
    {
        #region Field Region
        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public Reagent(
            string reagentName,
            string reagentType,
            int price,
            float weight)
            : base(reagentName, reagentType, price, weight, null)
        {
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region

        public override object Clone()
        {
            Reagent reagent = new Reagent(Name, Type, Price, Weight);

            return reagent;
        }

        #endregion
    }
}
