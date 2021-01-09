using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MGRpgLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace EyesOfTheDragon.GameScreens
{
    public abstract partial class BaseGameState : GameState
    {
        #region Fields region
        protected Game1 GameRef;
        #endregion
        
        #region Properties region
        #endregion
        
        #region Constructor Region
        
        public BaseGameState(Game game, GameStateManager manager)
            : base(game, manager)
        {
            GameRef = (Game1)game;
        }
        
        #endregion
    }
}
