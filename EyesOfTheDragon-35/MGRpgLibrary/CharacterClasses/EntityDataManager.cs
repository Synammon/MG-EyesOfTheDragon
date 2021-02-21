using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public class EntityDataManager
    {
        #region Field Region

        readonly Dictionary<string, EntityData> entityData = 
            new Dictionary<string, EntityData>();

        #endregion

        #region Property Region
        public Dictionary<string, EntityData> EntityData
        {
            get { return entityData; }
        }

        #endregion

        #region Constructor Region
        #endregion

        #region Method Region
        #endregion
    }
}
