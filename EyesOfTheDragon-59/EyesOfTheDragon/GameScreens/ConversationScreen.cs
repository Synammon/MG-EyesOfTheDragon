﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EyesOfTheDragon.Components;
using MGRpgLibrary;
using MGRpgLibrary.CharacterClasses;
using MGRpgLibrary.ConversationComponents;

namespace EyesOfTheDragon.GameScreens
{
    public class ConversationScreen : BaseGameState
    {
        private ConversationManager conversations = ConversationManager.Instance;
        private Conversation conversation;
        private Player player;
        private NonPlayerCharacter npc;
        
        public ConversationScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
        }
        
        public override void Initialize()
        {
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            conversation.Update(gameTime);
    
            if (InputHandler.KeyReleased(Keys.Enter) || InputHandler.KeyReleased(Keys.Space) ||
                InputHandler.ButtonReleased(Buttons.A, PlayerIndex.One) ||
                (InputHandler.CheckMouseReleased(MouseButton.Left) && conversation.CurrentScene.IsOver))
            {
                InputHandler.Flush();
                SceneAction action = conversation.CurrentScene.OptionAction;

                switch (action.Action)
                {
                    case ActionType.Talk:
                        conversation.ChangeScene(conversation.CurrentScene.OptionScene);
                        break;
                    case ActionType.Quest:
                        conversation.ChangeScene(conversation.CurrentScene.OptionScene);
                        break;
                    case ActionType.Change:
                        conversation =
                        conversations.GetConversation(conversation.CurrentScene.OptionScene);
                        conversation.StartConversation();
                        break;
                    case ActionType.End:
                        StateManager.PopState();
                        break;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        
            GameRef.SpriteBatch.Begin();
            
            conversation.Draw(gameTime, GameRef.SpriteBatch, null);
            
            GameRef.SpriteBatch.End();
        }
    
        public void SetConversation(Player player, NonPlayerCharacter npc, string
            conversation)
        {
            this.player = player;
            this.npc = npc;
            this.conversation = conversations.GetConversation(conversation);
        }

        public void StartConversation()
        {
            conversation.StartConversation();
        }
    }
}
