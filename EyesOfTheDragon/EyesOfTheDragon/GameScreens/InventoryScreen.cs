using MGRpgLibrary;
using MGRpgLibrary.ItemClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace EyesOfTheDragon.GameScreens
{
    public class InventoryScreen : BaseGameState
    {
        private Texture2D _background;
        private Rectangle _destination;
        private List<Rectangle> _backpackDestinations = new List<Rectangle>();

        public InventoryScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        public override void Initialize()
        {
            int x = 622, y = 96;

            for (int i = 0; i < 30; i++)
            {
                _backpackDestinations.Add(new Rectangle(x, y, 106, 78));

                x += 123;

                if (x >= 1220)
                {
                    x = 622;
                    y += 78;
                }
            }

            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            _background = Game.Content.Load<Texture2D>(@"GUI/inventory-gui");
            _destination = new Rectangle(0, 0, Game1.ScreenWidth, Game1.ScreenHeight);
        }

        public override void Update(GameTime gameTime)
        {
            if (InputHandler.CheckMouseReleased(MouseButton.Right) || InputHandler.KeyReleased(Keys.Escape))
            {
                StateManager.PopState();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            GameRef.SpriteBatch.Begin();

            GameRef.SpriteBatch.Draw(_background, _destination, Color.White);

            int c = 0;

            foreach (GameItem item in GamePlayScreen.Player.Backpack.Items)
            {
                item.Draw(GameRef.SpriteBatch, _backpackDestinations[c]);
                c++;
                if (c >= _backpackDestinations.Count)
                {
                    break;
                }
            }
            GameRef.SpriteBatch.End();
        }
    }
}
