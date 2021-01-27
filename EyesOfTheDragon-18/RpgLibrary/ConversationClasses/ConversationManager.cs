using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ConversationClasses
{
    public class ConversationManager
    {
        #region Field Region

        readonly Dictionary<string, Conversation> conversations;

        #endregion

        #region Property Region

        public Dictionary<string, Conversation> Conversations
        {
            get { return conversations; }
        }

        #endregion

        #region Constructor Region

        public ConversationManager()
        {
            conversations = new Dictionary<string, Conversation>();
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region
        #endregion
    }
}
