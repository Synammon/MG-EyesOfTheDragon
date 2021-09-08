using MGRpgLibrary;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EyesOfTheDragon.GameScreens
{
    public class GameOverScreen : BaseGameState
    {
        public GameOverScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (InputHandler.KeyReleased(Microsoft.Xna.Framework.Input.Keys.Space) ||
                InputHandler.KeyReleased(Microsoft.Xna.Framework.Input.Keys.Enter) ||
                InputHandler.CheckMouseReleased(MouseButton.Left))
            {
                StateManager.ChangeState(GameRef.StartMenuScreen);
            }

            base.Update(gameTime);
        }
    }
}
