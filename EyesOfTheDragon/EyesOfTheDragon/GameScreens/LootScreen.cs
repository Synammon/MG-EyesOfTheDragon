using MGRpgLibrary;
using MGRpgLibrary.Controls;
using MGRpgLibrary.ItemClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace EyesOfTheDragon.GameScreens
{
    public class LootScreen : BaseGameState
    {
        public readonly List<GameItem> Items;
        private bool _over;
        private int _index;

        public LootScreen(Game game, GameStateManager manager) : base(game, manager)
        {
            Items = new List<GameItem>();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            LinkLabel linkLabel = new LinkLabel()
            {
                Text = "Close",
                TabStop = true,
                Color = Color.White,
                SelectedColor = Color.Red,
                Position = new Vector2(
                    (Game1.ScreenWidth - FontManager.GetFont("testfont").MeasureString("Close").X) / 2,
                    Game1.ScreenHeight - FontManager.GetFont("testfont").LineSpacing * 2)
            };

            linkLabel.Selected += LinkLabel_Selected;
            ControlManager.Add(linkLabel);
        }

        private void LinkLabel_Selected(object sender, EventArgs e)
        {
            StateManager.PopState();
        }

        public override void Update(GameTime gameTime)
        {
            if (_over)
            {
                if (InputHandler.CheckMouseReleased(MouseButton.Left) && _index > -1 && _index < Items.Count)
                {
                    GamePlayScreen.Player.Backpack.Items.Add(Items[_index]);
                    Items.RemoveAt(_index);
                }
            }

            if (InputHandler.KeyReleased(Keys.Escape))
            {
                StateManager.PopState();
            }

            ControlManager.Update(gameTime, PlayerIndex.One);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            GameRef.SpriteBatch.Begin();

            ControlManager.Draw(GameRef.SpriteBatch);

            Rectangle destination = new Rectangle(50, 50, 32, 32);
            Point mouse = InputHandler.MouseAsPoint;

            int i = 0;

            _over = false;
            _index = -1;

            foreach (GameItem item in Items)
            {
                item.Draw(GameRef.SpriteBatch, destination);

                if (destination.Contains(mouse))
                {
                    _over = true;
                    _index = i;
                }

                destination.X += 50;

                if (destination.X > GameRef.ScreenRectangle.Width - 50 - 32)
                {
                    destination.X = 50;
                    destination.Y += 50;
                }

                i++;
            }

            GameRef.SpriteBatch.End();
        }

        protected override void Show()
        {
            Items.Clear();

            base.Show();
        }
    }
}
