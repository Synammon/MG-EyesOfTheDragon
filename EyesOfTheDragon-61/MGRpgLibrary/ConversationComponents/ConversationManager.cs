using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace MGRpgLibrary.ConversationComponents
{
    public sealed class ConversationManager
    {
        #region Field Region

        private static readonly ConversationManager instance = new ConversationManager();
        private Dictionary<string, Conversation> conversationList = new Dictionary<string,
            Conversation>();
    
        #endregion
        #region Property Region
        
        [ContentSerializer]
        public Dictionary<string, Conversation> ConversationList
        {
            get { return conversationList; }
            private set { conversationList = value; }
        }
        
        public static ConversationManager Instance
        {
            get { return instance; }
        }
        
        #endregion
        
        #region Constructor Region
        
        private ConversationManager()
        {
        }
        
        #endregion
        
        #region Method Region
        
        public void AddConversation(string name, Conversation conversation)
        {
            if (!conversationList.ContainsKey(name))
            {
                conversationList.Add(name, conversation);
            }
        }
        
        public Conversation GetConversation(string name)
        {
            return conversationList.ContainsKey(name) ? conversationList[name] : null;
        }

        public bool ContainsConversation(string name)
        {
            return conversationList.ContainsKey(name);
        }

        public void ClearConversations()
        {
            conversationList = new Dictionary<string, Conversation>();
        }

        #endregion
    }
}
