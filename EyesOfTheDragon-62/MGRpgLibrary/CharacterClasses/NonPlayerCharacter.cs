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

        readonly List<Quest> quests;
        private string currentConversation;
        private string currentQuest;

        #endregion
        #region Property Region

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
            get { return !string.IsNullOrEmpty(currentConversation); }
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

            SpriteFont font = FontManager.GetFont("testfont");

            if (HasConversation || HasQuest)
            {
                spriteBatch.DrawString(
                    font,
                    "F",
                    new Vector2(
                        Sprite.Bounds.X + (Sprite.Bounds.Width - font.MeasureString("F").X) / 2,
                        Sprite.Bounds.Y - font.LineSpacing),
                    Color.Yellow);
            }
        }
        
        public void SetConversation(string conversation)
        {
            currentConversation = conversation;
        }

        #endregion
    }
}
