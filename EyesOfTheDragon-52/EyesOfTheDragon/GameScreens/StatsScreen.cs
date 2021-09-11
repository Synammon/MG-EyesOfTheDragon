using MGRpgLibrary;
using MGRpgLibrary.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace EyesOfTheDragon.GameScreens
{
    public class StatsScreen : BaseGameState
    {
        protected Texture2D _background;
        protected Label _str;
        protected Label _dex;
        protected Label _cun;
        protected Label _mag;
        protected Label _wil;
        protected Label _con;
        protected Label _lvl;
        protected Label _xp;
        protected Label _next;
        protected Label _hp;
        protected Label _res;
        protected Label _resName;

        public StatsScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            Color[] data = new Color[500 * 500];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Color.Black;
            }

            _background = new Texture2D(GraphicsDevice, 500, 500);
            _background.SetData(data);

            int yOffset = (720 - 500) / 2;
            int xOffset = (1280 - 500) / 2 + 20;

            Label label = new Label()
            {
                Position = new Vector2(xOffset, 40 + yOffset),
                Text = "Strength: ",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _str = new Label()
            {
                Position = new Vector2(xOffset + 160, 40 + yOffset),
                Text = $"{GamePlayScreen.Player.Character.Entity.Strength}",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(_str);

            label = new Label()
            {
                Position = new Vector2(xOffset, 80 + yOffset),
                Text = "Dexterity: ",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _dex = new Label()
            {
                Position = new Vector2(xOffset + 160, 80 + yOffset),
                Text = $"{GamePlayScreen.Player.Character.Entity.Dexterity}",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(_dex);

            label = new Label()
            {
                Position = new Vector2(xOffset, 120 + yOffset),
                Text = "Cunning: ",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _cun = new Label()
            {
                Position = new Vector2(xOffset + 160, 120 + yOffset),
                Text = $"{GamePlayScreen.Player.Character.Entity.Cunning}",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(_cun);

            label = new Label()
            {
                Position = new Vector2(xOffset, 160 + yOffset),
                Text = "Magic: ",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _mag = new Label()
            {
                Position = new Vector2(xOffset + 160, 160 + yOffset),
                Text = $"{GamePlayScreen.Player.Character.Entity.Magic}",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(_mag);

            label = new Label()
            {
                Position = new Vector2(xOffset, 200 + yOffset),
                Text = "Will Power: ",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _wil = new Label()
            {
                Position = new Vector2(xOffset + 160, 200 + yOffset),
                Text = $"{GamePlayScreen.Player.Character.Entity.Willpower}",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(_wil);
            label = new Label()
            {
                Position = new Vector2(xOffset, 240 + yOffset),
                Text = "Constitution: ",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _con = new Label()
            {
                Position = new Vector2(xOffset + 160, 240 + yOffset),
                Text = $"{GamePlayScreen.Player.Character.Entity.Constitution}",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(_con);

            label = new Label()
            {
                Position = new Vector2(xOffset + 250, yOffset + 40),
                Text = "Level:",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _lvl = new Label
            {
                Position = new Vector2(xOffset + 250 + 80, yOffset + 40),
                Text = $"{GamePlayScreen.Player.Character.Entity.Level}",
                Color = Color.Yellow,
                TabStop = false
            };

            ControlManager.Add(_lvl);

            label = new Label()
            {
                Position = new Vector2(xOffset + 250, yOffset + 80),
                Text = "XP:",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _xp = new Label
            {
                Position = new Vector2(xOffset + 250 + 80, yOffset + 80),
                Text = $"{GamePlayScreen.Player.Character.Entity.Experience}",
                Color = Color.Yellow,
                TabStop = false
            };

            ControlManager.Add(_xp);

            label = new Label()
            {
                Position = new Vector2(xOffset + 250, yOffset + 120),
                Text = "HP:",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _hp = new Label
            {
                Position = new Vector2(xOffset + 250 + 80, yOffset + 120),
                Text = $"{GamePlayScreen.Player.Character.Entity.Health.CurrentValue} / {GamePlayScreen.Player.Character.Entity.Health.MaximumValue}",
                Color = Color.Yellow,
                TabStop = false
            };

            ControlManager.Add(_hp);

            _resName = new Label
            {
                Position = new Vector2(xOffset + 250, yOffset + 160),
                Color = Color.White,
                TabStop = false
            };

            _resName.Text = GamePlayScreen.Player.Character.Entity.Mana.MaximumValue > 0 ? "MP:" : "SP:";

            ControlManager.Add(_resName);

            _res = new Label
            {
                Position = new Vector2(xOffset + 250 + 80, yOffset + 160),
                Color = Color.Yellow,
                TabStop = false
            };

            _res.Color = GamePlayScreen.Player.Character.Entity.Mana.MaximumValue > 0 ? Color.Yellow : Color.Blue;

            _res.Text = GamePlayScreen.Player.Character.Entity.Mana.MaximumValue > 0 ?
                $"{GamePlayScreen.Player.Character.Entity.Mana.CurrentValue} / " +
                $"{GamePlayScreen.Player.Character.Entity.Mana.MaximumValue}" :
                $"{GamePlayScreen.Player.Character.Entity.Stamina.CurrentValue} / " +
                $"{GamePlayScreen.Player.Character.Entity.Stamina.MaximumValue}";

            ControlManager.Add(_res);
            LinkLabel close = new LinkLabel()
            {
                Position = new Vector2(390 + (500 - FontManager.GetFont("testfont").MeasureString("Close").X) / 2,
                    (720 - 500) / 2 + 500 - FontManager.GetFont("testfont").LineSpacing - 10),
                Color = Color.White,
                TabStop = true,
                HasFocus = true,
                Text = "Close"
            };

            ControlManager.Add(close);

            close.Selected += Close_Selected;
        }

        private void Close_Selected(object sender, EventArgs e)
        {
            OnCloseSelected();
        }

        protected virtual void OnCloseSelected()
        {
            StateManager.PopState();
        }
        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _str.Text = $"{GamePlayScreen.Player.Character.Entity.Strength}";
            _dex.Text = $"{GamePlayScreen.Player.Character.Entity.Dexterity}";
            _cun.Text = $"{GamePlayScreen.Player.Character.Entity.Cunning}";
            _mag.Text = $"{GamePlayScreen.Player.Character.Entity.Magic}";
            _wil.Text = $"{GamePlayScreen.Player.Character.Entity.Willpower}";
            _con.Text = $"{GamePlayScreen.Player.Character.Entity.Constitution}";
            _lvl.Text = $"{GamePlayScreen.Player.Character.Entity.Level}";
            _xp.Text = $"{GamePlayScreen.Player.Character.Entity.Experience}";
            _hp.Text = $"{GamePlayScreen.Player.Character.Entity.Health.CurrentValue} / {GamePlayScreen.Player.Character.Entity.Health.MaximumValue}";
            _resName.Text = GamePlayScreen.Player.Character.Entity.Mana.MaximumValue > 0 ? "MP:" : "SP:";
            _res.Color = GamePlayScreen.Player.Character.Entity.Mana.MaximumValue > 0 ? Color.Yellow : Color.Blue;
            _res.Text = GamePlayScreen.Player.Character.Entity.Mana.MaximumValue > 0 ?
                $"{GamePlayScreen.Player.Character.Entity.Mana.CurrentValue} / " +
                $"{GamePlayScreen.Player.Character.Entity.Mana.MaximumValue}" :
                $"{GamePlayScreen.Player.Character.Entity.Stamina.CurrentValue} / " +
                $"{GamePlayScreen.Player.Character.Entity.Stamina.MaximumValue}";

            GameRef.SpriteBatch.Begin();

            GameRef.SpriteBatch.Draw(_background, new Rectangle((1280 - 500) / 2, (720 - 500) / 2, 500, 500), Color.White);
            ControlManager.Draw(GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }
    }
}
