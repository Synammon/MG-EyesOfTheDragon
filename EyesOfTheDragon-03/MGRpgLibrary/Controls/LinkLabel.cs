using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MGRpgLibrary.Controls
{
    public class LinkLabel : Control
    {
        #region Fields and Properties

        Color selectedColor = Color.Red;

        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        #endregion

        #region Constructor Region

        public LinkLabel()
        {
            TabStop = true;
            HasFocus = false;
            Position = Vector2.Zero;
        }

        #endregion

        #region Abstract Methods

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (hasFocus)
                spriteBatch.DrawString(SpriteFont, Text, Position, selectedColor);
            else
                spriteBatch.DrawString(SpriteFont, Text, Position, Color);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (!HasFocus)
                return;

            if (InputHandler.KeyReleased(Keys.Enter) ||
                InputHandler.ButtonReleased(Buttons.A, playerIndex))
                base.OnSelected(null);

            if (InputHandler.CheckMouseReleased(MouseButton.Left))
            {
                size = SpriteFont.MeasureString(Text);

                Rectangle r = new Rectangle(
                    (int)Position.X, 
                    (int)Position.Y, 
                    (int)size.X, 
                    (int)size.Y);
                
                if (r.Contains(InputHandler.MouseAsPoint))
                    base.OnSelected(null);
            }
        }

        #endregion
    }
}
