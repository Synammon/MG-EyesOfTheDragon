using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MGRpgLibrary.Controls
{
    public class LeftRightSelector : Control
    {
        #region Event Region
        
        public event EventHandler SelectionChanged;
        
        #endregion
        
        #region Field Region
        
        List<string> items = new List<string>();
        Texture2D leftTexture;
        Texture2D rightTexture;
        Texture2D stopTexture;
        Color selectedColor = Color.Red;
        int maxItemWidth;
        int selectedItem;
        bool overLeft;
        bool overRight;

        #endregion
        
        #region Property Region
        
        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }
        
        public int SelectedIndex
        {
            get { return selectedItem; }
            set { selectedItem = (int)MathHelper.Clamp(value, 0f, items.Count); }
        }
        
        public string SelectedItem
        {
            get { return Items[selectedItem]; }
        }
        
        public List<string> Items
        {
            get { return items; }
        }
        
        #endregion
        
        #region Constructor Region
        
        public LeftRightSelector(Texture2D leftArrow, Texture2D rightArrow, Texture2D stop)
        {
            leftTexture = leftArrow;
            rightTexture = rightArrow;
            stopTexture = stop;
            TabStop = true;
            Color = Color.White;
        }
        
        #endregion
        
        #region Method Region
        public void SetItems(string[] items, int maxWidth)
        {
            this.items.Clear();
            foreach (string s in items)
                this.items.Add(s);
            maxItemWidth = maxWidth;
        }
        protected void OnSelectionChanged()
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(this, null);
            }
        }
        
        #endregion
        
        #region Abstract Method Region
        
        public override void Update(GameTime gameTime)
        {            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 drawTo = position;
            Rectangle dest = new Rectangle((int)position.X, (int)position.Y, 0, 0);
            Vector2 mouse = InputHandler.MouseAsVector2;

            if (selectedItem != 0)
            {
                spriteBatch.Draw(leftTexture, drawTo, Color.White);
                dest.Width = leftTexture.Width;
                dest.Height = leftTexture.Height;
            }
            else
            {
                spriteBatch.Draw(stopTexture, drawTo, Color.White);
                dest.Width = stopTexture.Width;
                dest.Height = stopTexture.Height;
            }

            overLeft = dest.Contains(mouse);

            drawTo.X += leftTexture.Width + 5f;
            
            float itemWidth = spriteFont.MeasureString(items[selectedItem]).X;
            float offset = (maxItemWidth - itemWidth) / 2;
            
            drawTo.X += offset;
            
            if (hasFocus)
                spriteBatch.DrawString(spriteFont, items[selectedItem], drawTo, selectedColor);
            else
                spriteBatch.DrawString(spriteFont, items[selectedItem], drawTo, Color);
            
            drawTo.X += -1 * offset + maxItemWidth + 5f;

            dest.X = (int)drawTo.X;

            if (selectedItem != items.Count - 1)
            {
                spriteBatch.Draw(rightTexture, drawTo, Color.White);
                dest.Width = rightTexture.Width;
                dest.Height = rightTexture.Height;
            }
            else
            {
                spriteBatch.Draw(stopTexture, drawTo, Color.White);
                dest.Width = stopTexture.Width;
                dest.Height = stopTexture.Height;
            }

            overRight = dest.Contains(mouse);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (items.Count == 0)
                return;
            
            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickLeft, playerIndex) ||
                InputHandler.ButtonReleased(Buttons.DPadLeft, playerIndex) ||
                InputHandler.KeyReleased(Keys.Left) ||
                (InputHandler.CheckMouseReleased(MouseButton.Left) && overLeft))
            {
                selectedItem--;

                if (selectedItem < 0)
                    selectedItem = 0;

                OnSelectionChanged();
            }
        
            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickRight, playerIndex) ||
                InputHandler.ButtonReleased(Buttons.DPadRight, playerIndex) ||
                InputHandler.KeyReleased(Keys.Right) ||
                (InputHandler.CheckMouseReleased(MouseButton.Left) && overRight))
            {
                selectedItem++;

                if (selectedItem >= items.Count)
                    selectedItem = items.Count - 1;

                OnSelectionChanged();
            }
        }

        public override Rectangle GetBounds()
        {
            return new Rectangle(
                (int)Position.X, 
                (int)Position.Y, 
                maxItemWidth + 10 + leftTexture.Width + rightTexture.Width, 
                rightTexture.Height);
        }

        #endregion
    }
}
