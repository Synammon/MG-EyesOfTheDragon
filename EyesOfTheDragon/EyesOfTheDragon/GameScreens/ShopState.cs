using MGRpgLibrary;
using MGRpgLibrary.CharacterClasses;
using MGRpgLibrary.ConversationComponents;
using MGRpgLibrary.ItemClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyesOfTheDragon.GameScreens
{
    public enum ShopStateType { Buy, Sell, Talk }

    public interface IShopState
    {
        ShopStateType State { get; set; }
        void SetMerchant(Merchant merchant);
    }

    public class ShopState : BaseGameState, IShopState
    {
        private GameScene scene;
        private Merchant merchant;
        private int selected;
        private bool mouseOver;
        private bool isFirst;

        public ShopStateType State { get; set; }

        public ShopState(Game game, GameStateManager manager)
            : base(game, manager)
        {
            State = ShopStateType.Talk;
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            scene = new GameScene(Game, "basic_scene", "", new List<SceneOption>());
            SceneOption option = new SceneOption("Buy", "Buy", new SceneAction());
            scene.Options.Add(option);

            option = new SceneOption("Sell", "Sell", new SceneAction());
            scene.Options.Add(option);

            option = new SceneOption("Leave", "Leave", new SceneAction());
            scene.Options.Add(option);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            scene.Update(gameTime, playerIndexInControl);

            switch (State)
            {
                case ShopStateType.Buy:
                    if (isFirst)
                    {
                        isFirst = false;
                        break;
                    }

                    if (InputHandler.KeyReleased(Keys.Down) ||
                        InputHandler.KeyReleased(Keys.S))
                    {
                        selected++;
                        if (selected >= merchant.Backpack.Items.Count)
                        {
                            selected = 0;
                        }
                    }

                    if (InputHandler.KeyReleased(Keys.Up) ||
                        InputHandler.KeyReleased(Keys.W))
                    {
                        selected--;
                        if (selected < 0)
                        {
                            selected = merchant.Backpack.Items.Count - 1;
                        }
                    }


                    if (InputHandler.KeyReleased(Keys.Space) ||
                        InputHandler.KeyReleased(Keys.Enter) ||
                        (InputHandler.CheckMouseReleased(MouseButton.Left) && mouseOver))
                    {
                        if (selected != -1 &&
                            GamePlayScreen.Player.Gold >=
                            merchant.Backpack.PeekItem(
                                merchant.Backpack.Items[selected].Item.Name).Price)
                        {
                            if (selected >= merchant.Backpack.Items.Count)
                            {
                                return;
                            }

                            GamePlayScreen.Player.Gold -=
                                merchant.Backpack.PeekItem(
                                    merchant.Backpack.Items[selected].Item.Name).Price;
                            GamePlayScreen.Player.Backpack.AddItem(
                                merchant.Backpack.GetItem(
                                    merchant.Backpack.Items[selected].Item.Name));
                        }
                    }
                    break;
                case ShopStateType.Sell:
                    if (isFirst)
                    {
                        isFirst = false;
                        break;
                    }
                    if (InputHandler.KeyReleased(Keys.Down) ||
                        InputHandler.KeyReleased(Keys.S))
                    {
                        selected++;

                        if (selected >= GamePlayScreen.Player.Backpack.Items.Count)
                        {
                            selected = 0;
                        }
                    }

                    if (InputHandler.KeyReleased(Keys.Up) ||
                        InputHandler.KeyReleased(Keys.W))
                    {
                        selected--;
                        if (selected < 0)
                        {
                            selected = GamePlayScreen.Player.Backpack.Items.Count - 1;
                        }
                    }


                    if ((InputHandler.KeyReleased(Keys.Space) ||
                        InputHandler.KeyReleased(Keys.Enter) ||
                        (InputHandler.CheckMouseReleased(MouseButton.Left) && mouseOver)))
                    {
                        if (selected >= 0)
                        {
                            GameItem item = GamePlayScreen.Player.Backpack.GetItem(
                                GamePlayScreen.Player.Backpack.Items[selected].Item.Name);
                            GamePlayScreen.Player.Gold += item.Item.Price * 3 / 4;
                        }
                    }
                    break;
                case ShopStateType.Talk:
                    if (InputHandler.KeyReleased(Keys.Space) ||
                        InputHandler.KeyReleased(Keys.Enter))
                    {
                        if (scene.SelectedIndex == 0)
                        {
                            isFirst = true;
                            State = ShopStateType.Buy;
                            //selected = -1;
                            return;
                        }

                        if (scene.SelectedIndex == 1)
                        {
                            isFirst = true;
                            State = ShopStateType.Sell;
                            //selected = -1;
                            return;
                        }

                        if (scene.SelectedIndex == 2 && State == ShopStateType.Talk)
                        {
                            StateManager.PopState();
                        }
                    }
                    break;
            }

            if (InputHandler.CheckMouseReleased(MouseButton.Right) || InputHandler.KeyReleased(Keys.Escape))
            {
                switch (State)
                {
                    case ShopStateType.Buy:
                    case ShopStateType.Sell:
                        State = ShopStateType.Talk;
                        break;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            GameRef.SpriteBatch.Begin();

            int i = 0;
            Color tint;

            switch (State)
            {
                case ShopStateType.Buy:
                    mouseOver = false;
                    if (isFirst)
                    {
                        break;
                    }
                    GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("testfont"),
                        "Item",
                        new Vector2(120, 5),
                        Color.Red);

                    GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("testfont"),
                        "Quantity",
                        new Vector2(800, 5),
                        Color.Red);

                    GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("testfont"),
                        "Price",
                        new Vector2(1100, 5),
                        Color.Red);

                    foreach (var v in merchant.Backpack.Items)
                    {
                        tint = Color.White;
                        if (i == selected)
                        {
                            tint = Color.Red;
                        }

                        BaseItem item = merchant.Backpack.PeekItem(v.Item.Name);

                        if (item != null)
                        {
                            Rectangle r = new Rectangle(0, 74 * i + 24, 1200, 64);

                            if (r.Contains(InputHandler.MouseAsPoint))
                            {
                                selected = i;
                                mouseOver = true;
                            }

                            GameRef.SpriteBatch.DrawString(
                                FontManager.GetFont("testfont"),
                                v.Item.Name,
                                new Vector2(120, 74 * i + 45),
                                tint);

                            GameRef.SpriteBatch.DrawString(
                                FontManager.GetFont("testfont"),
                                1.ToString(),
                                new Vector2(800, 74 * i + 45),
                                tint);

                            GameRef.SpriteBatch.DrawString(
                                FontManager.GetFont("testfont"),
                                item.Price.ToString(),
                                new Vector2(1100, 74 * i + 45),
                                tint);

                            i++;
                        }
                    }
                    break;
                case ShopStateType.Sell:
                    mouseOver = false;
                    if (isFirst)
                    {
                        break;
                    }
                    GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("testfont"),
                        "Item",
                        new Vector2(120, 5),
                        Color.Red);

                    GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("testfont"),
                        "Quantity",
                        new Vector2(800, 5),
                        Color.Red);

                    GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("testfont"),
                        "Price",
                        new Vector2(1100, 5),
                        Color.Red);

                    foreach (var v in GamePlayScreen.Player.Backpack.Items)
                    {
                        tint = Color.White;

                        if (i == selected)
                        {
                            tint = Color.Red;
                        }

                        BaseItem item = GamePlayScreen.Player.Backpack.PeekItem(v.Item.Name);

                        if (item != null)
                        {
                            Rectangle r = new Rectangle(0, 74 * i + 24, 1280, 64);

                            if (r.Contains(InputHandler.MouseAsPoint))
                            {
                                selected = i;
                                mouseOver = true;
                            }

                            GameRef.SpriteBatch.DrawString(
                                FontManager.GetFont("testfont"),
                                v.Item.Name,
                                new Vector2(120, 74 * i + 45),
                                tint);

                            GameRef.SpriteBatch.DrawString(
                                FontManager.GetFont("testfont"),
                                1.ToString(),
                                new Vector2(800, 74 * i + 45),
                                tint);

                            GameRef.SpriteBatch.DrawString(
                                FontManager.GetFont("testfont"),
                                item.Price.ToString(),
                                new Vector2(1100, 74 * i + 45),
                                tint);

                            i++;
                        }
                    }
                    break;
                case ShopStateType.Talk:
                    scene.Draw(gameTime, GameRef.SpriteBatch, null);
                    break;
            }

            GameRef.SpriteBatch.End();
        }

        public void SetMerchant(Merchant merchant)
        {
            this.merchant = merchant;
        }
    }
}
