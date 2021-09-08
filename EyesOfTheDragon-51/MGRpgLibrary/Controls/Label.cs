using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MGRpgLibrary.Controls
{
    public class Label : Control
    {
        #region Constructor Region
        
        public Label()
        {
            tabStop = false;
        }

        #endregion
        
        #region Abstract Methods
        
        public override void Update(GameTime gameTime)
        {
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFont, Text, Position, Color);
        }
        
        public override void HandleInput(PlayerIndex playerIndex)
        {
        }
        
        #endregion
    }
}
