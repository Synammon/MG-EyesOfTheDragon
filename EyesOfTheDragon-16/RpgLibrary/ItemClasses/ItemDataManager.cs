using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ItemDataManager
    {
        #region Field Region

        readonly Dictionary<string, ArmorData> armorData = new Dictionary<string, 
             ArmorData>();
        readonly Dictionary<string, ShieldData> shieldData = new Dictionary<string,
            ShieldData>();
        readonly Dictionary<string, WeaponData> weaponData = new Dictionary<string,
            WeaponData>();
        readonly Dictionary<string, ReagentData> reagentData = new Dictionary<string,
            ReagentData>();

        #endregion

        #region Property Region

        public Dictionary<string, ArmorData> ArmorData
        {
            get { return armorData; }
        }

        public Dictionary<string, ShieldData> ShieldData
        {
            get { return shieldData; }
        }

        public Dictionary<string, WeaponData> WeaponData
        {
            get { return weaponData; }
        }

        public Dictionary<string, ReagentData> ReagentData
        {
            get { return reagentData; }
        }

        #endregion

        #region Constructor Region
        #endregion

        #region Method Region
        #endregion
    }
}
