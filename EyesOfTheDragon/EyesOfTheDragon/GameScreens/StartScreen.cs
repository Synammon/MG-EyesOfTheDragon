using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MGRpgLibrary;

namespace EyesOfTheDragon.GameScreens
{
    public class StartMenuScreen : BaseGameState
    {
        #region Field region
        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public StartMenuScreen(Game game, GameStateManager manager)
        : base(game, manager)
        {
        }

        #endregion

        #region XNA Method Region

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
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (InputHandler.KeyReleased(Keys.Escape))
            {
                Game.Exit();
            }

            base.Draw(gameTime);
        }

        #endregion

        #region Game State Method Region
        #endregion
    }
}
