using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MGRpgLibrary.Controls
{
    public class SpinBox : Control
    {
        #region Event Region

        public event EventHandler SelectionChanged;

        #endregion

        #region Field Region
        int current;
        int minValue;
        int maxValue;
        int increment;

        Texture2D leftTexture;
        Texture2D rightTexture;
        Texture2D stopTexture;

        Color selectedColor = Color.Red;

        int width;

        #endregion

        #region Property Region

        public int MinimumValue
        {
            get { return minValue; }
            set
            {
                if (value > maxValue)
                    minValue = maxValue;
                else
                    minValue = value;
            }
        }

        public int MaximumValue
        {
            get { return maxValue; }
            set
            {
                if (value < minValue)
                    maxValue = minValue;
                else
                    maxValue = value;
            }
        }

        public int Value
        {
            get { return current; }
            set
            {
                if (value < minValue)
                    current = minValue;
                else if (value > maxValue)
                    current = maxValue;
                else
                    current = value;
            }
        }

        public int Increment
        {
            get { return increment; }
            set { increment = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        #endregion

        #region Constructor Region

        public SpinBox(Texture2D leftArrow, Texture2D rightArrow, Texture2D stop)
        {
            minValue = 0;
            maxValue = 100;
            increment = 1;
            width = 50;
            leftTexture = leftArrow;
            rightTexture = rightArrow;
            stopTexture = stop;
            TabStop = true;
            Color = Color.White;
        }

        #endregion

        #region Method Region

        #endregion

        #region Virtual Method region

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 drawTo = position;

            if (current != minValue)
                spriteBatch.Draw(leftTexture, drawTo, Color.White);
            else
                spriteBatch.Draw(stopTexture, drawTo, Color.White);

            drawTo.X += leftTexture.Width + 5f;

            string currentValue = current.ToString();
            float itemWidth = spriteFont.MeasureString(currentValue).X;
            float offset = (width - itemWidth) / 2;

            drawTo.X += offset;

            if (hasFocus)
                spriteBatch.DrawString(spriteFont, currentValue, drawTo, selectedColor);
            else
                spriteBatch.DrawString(spriteFont, currentValue, drawTo, Color);

            drawTo.X += -1 * offset + width + 5f;

            if (current != maxValue)
                spriteBatch.Draw(rightTexture, drawTo, Color.White);
            else
                spriteBatch.Draw(stopTexture, drawTo, Color.White);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickLeft, playerIndex) ||
                InputHandler.ButtonReleased(Buttons.DPadLeft, playerIndex) ||
                InputHandler.KeyReleased(Keys.Left))
            {
                current -= increment;
        
                if (current < minValue)
                    current = minValue;
                
                OnSelectionChanged();
            }
            
            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickRight, playerIndex) ||
                InputHandler.ButtonReleased(Buttons.DPadRight, playerIndex) ||
                InputHandler.KeyReleased(Keys.Right))
            {
                current += increment;
                
                if (current > maxValue)
                    current = maxValue;
                
                OnSelectionChanged();
            }
        }
        
        protected virtual void OnSelectionChanged()
        {
            if (SelectionChanged != null)
                SelectionChanged(this, null);
        }

        #endregion
    }
}
