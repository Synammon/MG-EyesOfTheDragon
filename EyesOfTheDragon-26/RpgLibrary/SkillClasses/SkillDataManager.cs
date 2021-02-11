using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.SkillClasses
{
    public class SkillDataManager
    {
        #region Field Region

        readonly Dictionary<string, SkillData> skillData;

        #endregion

        #region Property Region

        public Dictionary<string, SkillData> SkillData
        {
            get { return skillData; }
        }

        #endregion

        #region Constructor Region

        public SkillDataManager()
        {
            skillData = new Dictionary<string, SkillData>();
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region
        #endregion
    }
}
