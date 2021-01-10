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

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;
            SpriteFont menuFont = Content.Load<SpriteFont>(@"Fonts\ControlFont");
            ControlManager = new ControlManager(menuFont);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        #endregion
    }
}
