using EyesOfTheDragon.Components;
using MGRpgLibrary;
using MGRpgLibrary.ItemClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace EyesOfTheDragon.GameScreens
{
    public class InventoryScreen : BaseGameState
    {
        private Texture2D _background;
        private Texture2D _disabledTexture;
        private Rectangle _destination;
        private List<Rectangle> _backpackDestinations = new List<Rectangle>();
        private Rectangle _headGear;
        private Rectangle _bodyGear;
        private Rectangle _handGear;
        private Rectangle _footGear;
        private Rectangle _neckGear;
        private Rectangle _mainGear;
        private Rectangle _offGear;
        private Rectangle _fingerGear;

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

            _headGear = new Rectangle(55, 157, 101, 73);
            _bodyGear = new Rectangle(55, 247, 101, 73);
            _handGear = new Rectangle(55, 337, 101, 73);
            _footGear = new Rectangle(55, 427, 101, 73);
            _neckGear = new Rectangle(500, 157, 101, 73);
            _mainGear = new Rectangle(500, 247, 101, 73);
            _offGear = new Rectangle(500, 337, 101, 73);
            _fingerGear = new Rectangle(500, 427, 101, 73);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            _background = Game.Content.Load<Texture2D>(@"GUI/inventory-gui");
            _destination = new Rectangle(0, 0, Game1.ScreenWidth, Game1.ScreenHeight);
            _disabledTexture = Game.Content.Load<Texture2D>(@"GUI/disabled");
        }

        public override void Update(GameTime gameTime)
        {
            if (InputHandler.CheckMouseReleased(MouseButton.Right) || InputHandler.KeyReleased(Keys.Escape))
            {
                StateManager.PopState();
            }

            if (InputHandler.CheckMouseReleased(MouseButton.Left))
            {
                if (new Rectangle(1175, 45, 42, 32).Contains(InputHandler.MouseAsPoint))
                {
                    StateManager.PopState();
                }

                for (int i = 0; i < _backpackDestinations.Count && i < GamePlayScreen.Player.Backpack.Items.Count; i++)
                {
                    if (_backpackDestinations[i].Contains(InputHandler.MouseAsPoint))
                    {
                        GamePlayScreen.Player.Character.Entity.Equip(GamePlayScreen.Player.Backpack.Items[i]);

                        if (GamePlayScreen.Player.Backpack.Items[i].Item is Potion)
                        {
                            GamePlayScreen.Player.Backpack.Items.RemoveAt(i);
                            break;
                        }
                        break;
                    }
                }
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

                if (item.Item.IsEquiped)
                {
                    GameRef.SpriteBatch.Draw(_disabledTexture, _backpackDestinations[c], Color.White);
                }

                c++;
                if (c >= _backpackDestinations.Count)
                {
                    break;
                }
            }

            Entity e = GamePlayScreen.Player.Character.Entity;

            if (e.MainHand != null)
            {
                e.MainHand.Draw(GameRef.SpriteBatch, _mainGear);
            }

            if (e.OffHand != null)
            {
                e.OffHand.Draw(GameRef.SpriteBatch, _offGear);
            }

            if (e.Head != null)
            {
                e.Head.Draw(GameRef.SpriteBatch, _headGear);
            }

            if (e.Body != null)
            {
                e.Body.Draw(GameRef.SpriteBatch, _bodyGear);
            }

            if (e.Hands != null)
            {
                e.Hands.Draw(GameRef.SpriteBatch, _handGear);
            }

            if (e.Feet != null)
            {
                e.Feet.Draw(GameRef.SpriteBatch, _footGear);
            }

            GameRef.SpriteBatch.End();
        }
    }
}
