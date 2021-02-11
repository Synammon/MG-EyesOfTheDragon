using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.QuestClasses
{
    public class QuestManager
    {
        #region Field Region

        readonly Dictionary<string, Quest> quests;

        #endregion

        #region Property Region

        public Dictionary<string, Quest> Quests
        {
            get { return quests; }
        }

        #endregion

        #region Constructor Region

        public QuestManager()
        {
            quests = new Dictionary<string, Quest>();
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region
        #endregion
    }
}
