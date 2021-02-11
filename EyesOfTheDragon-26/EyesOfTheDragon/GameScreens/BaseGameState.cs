using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MGRpgLibrary;
using MGRpgLibrary.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EyesOfTheDragon.GameScreens
{
    public abstract partial class BaseGameState : GameState
    {
        #region Fields region

        protected Game1 GameRef;
        protected ControlManager ControlManager;
        protected PlayerIndex playerIndexInControl;
        protected BaseGameState TransitionTo;
        protected bool Transitioning;
        protected ChangeType changeType;
        protected TimeSpan transitionTimer;
        protected TimeSpan transitionInterval = TimeSpan.FromSeconds(0.5);

        #endregion

        #region Properties region
        #endregion

        #region Constructor Region
    
        public BaseGameState(Game game, GameStateManager manager)
            : base(game, manager)
        {
            GameRef = (Game1)game;
            playerIndexInControl = PlayerIndex.One;
        }
        
        #endregion
        
        #region XNA Method Region
        
        public override void Initialize()
        {
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;
            SpriteFont menuFont = Content.Load<SpriteFont>(@"Fonts\ControlFont");
        
            ControlManager = new ControlManager(menuFont);
            
            base.LoadContent();
        }

        
        public override void Update(GameTime gameTime)
        {
            if (Transitioning)
            {
                transitionTimer += gameTime.ElapsedGameTime;
        
                if (transitionTimer >= transitionInterval)
                {
                    Transitioning = false;
                
                    switch (changeType)
                    {
                        case ChangeType.Change:
                            StateManager.ChangeState(TransitionTo);
                            break;
                        case ChangeType.Pop:
                            StateManager.PopState();
                            break;
                        case ChangeType.Push:
                            StateManager.PushState(TransitionTo);
                            break;
                    }
                }
            }
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        
        #endregion
        
        #region Method Region
        
        public virtual void Transition(ChangeType change, BaseGameState gameState)
        {
            Transitioning = true;
            changeType = change;
            TransitionTo = gameState;
            transitionTimer = TimeSpan.Zero;
        }
        
        #endregion
    }
}
