using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.EffectClasses
{
    public class BaseEffectDataManager
    {
        #region Field Region
        readonly Dictionary<string, BaseEffectData> effectData;

        #endregion

        #region Property Region

        public Dictionary<string, BaseEffectData> EffectData
        {
            get { return effectData; }
        }

        #endregion
        #region Constructor Region

        public BaseEffectDataManager()
        {
            effectData = new Dictionary<string, BaseEffectData>();
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method Region
        #endregion
    }
}
