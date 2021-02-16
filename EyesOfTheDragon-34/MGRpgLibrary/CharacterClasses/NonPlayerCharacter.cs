using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MGRpgLibrary.SpriteClasses;
using RpgLibrary.CharacterClasses;
using MGRpgLibrary.ConversationComponents;
using RpgLibrary.QuestClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGRpgLibrary.CharacterClasses
{
    public class NonPlayerCharacter : Character
    {
        #region Field Region
        
        readonly List<Conversation> conversations;
        readonly List<Quest> quests;
        private string currentConversation;      
        private string currentQuest;

        #endregion
        
        #region Property Region
        
        public List<Conversation> Conversations
        {
            get { return conversations; }
        }
        
        public List<Quest> Quests
        {
            get { return quests; }
        }
        
        public string CurrentConversation
        {
            get { return currentConversation; }
        }
        
        public string CurrentQuest
        {
            get { return currentQuest; }
        }
        
        public bool HasConversation
        {
            get { return (conversations.Count > 0); }
        }
        
        public bool HasQuest
        {
            get { return (quests.Count > 0); }
        }
        
        #endregion
        
        #region Constructor Region
    
        public NonPlayerCharacter(Entity entity, AnimatedSprite sprite)
            : base(entity, sprite)
        {
            conversations = new List<Conversation>();
            quests = new List<Quest>();
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
        #endregion
    }
}
