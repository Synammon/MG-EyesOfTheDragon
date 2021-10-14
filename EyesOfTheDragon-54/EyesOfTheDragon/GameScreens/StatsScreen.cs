using MGRpgLibrary;
using MGRpgLibrary.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RpgLibrary.CharacterClasses;
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
        protected Rectangle _closeArea = new Rectangle(1175, 45, 45, 30);
        protected Rectangle _headGear;
        protected Rectangle _bodyGear;
        protected Rectangle _handGear;
        protected Rectangle _footGear;
        protected Rectangle _neckGear;
        protected Rectangle _mainGear;
        protected Rectangle _offGear;
        protected Rectangle _fingerGear;

        public StatsScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            _background = GameRef.Content.Load<Texture2D>("GUI/character-gui");

            int yOffset = 110;
            int xOffset = 630;

            Label label = new Label()
            {
                Position = new Vector2(xOffset, yOffset),
                Text = "Strength: ",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _str = new Label()
            {
                Position = new Vector2(xOffset + 160, yOffset),
                Text = $"{GamePlayScreen.Player.Character.Entity.Strength}",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(_str);

            label = new Label()
            {
                Position = new Vector2(xOffset, 40 + yOffset),
                Text = "Dexterity: ",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _dex = new Label()
            {
                Position = new Vector2(xOffset + 160, 40 + yOffset),
                Text = $"{GamePlayScreen.Player.Character.Entity.Dexterity}",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(_dex);

            label = new Label()
            {
                Position = new Vector2(xOffset, 80 + yOffset),
                Text = "Cunning: ",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _cun = new Label()
            {
                Position = new Vector2(xOffset + 160, 80 + yOffset),
                Text = $"{GamePlayScreen.Player.Character.Entity.Cunning}",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(_cun);

            label = new Label()
            {
                Position = new Vector2(xOffset, 120 + yOffset),
                Text = "Magic: ",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _mag = new Label()
            {
                Position = new Vector2(xOffset + 120, 120 + yOffset),
                Text = $"{GamePlayScreen.Player.Character.Entity.Magic}",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(_mag);

            label = new Label()
            {
                Position = new Vector2(xOffset, 160 + yOffset),
                Text = "Will Power: ",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _wil = new Label()
            {
                Position = new Vector2(xOffset + 160, 160 + yOffset),
                Text = $"{GamePlayScreen.Player.Character.Entity.Willpower}",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(_wil);
            label = new Label()
            {
                Position = new Vector2(xOffset, 200 + yOffset),
                Text = "Constitution: ",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _con = new Label()
            {
                Position = new Vector2(xOffset + 160, 200 + yOffset),
                Text = $"{GamePlayScreen.Player.Character.Entity.Constitution}",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(_con);

            label = new Label()
            {
                Position = new Vector2(xOffset + 250, yOffset),
                Text = "Level:",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _lvl = new Label
            {
                Position = new Vector2(xOffset + 250 + 80, yOffset),
                Text = $"{GamePlayScreen.Player.Character.Entity.Level}",
                Color = Color.Yellow,
                TabStop = false
            };

            ControlManager.Add(_lvl);

            label = new Label()
            {
                Position = new Vector2(xOffset + 250, yOffset + 40),
                Text = "XP:",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _xp = new Label
            {
                Position = new Vector2(xOffset + 250 + 80, yOffset + 40),
                Text = $"{GamePlayScreen.Player.Character.Entity.Experience}",
                Color = Color.Yellow,
                TabStop = false
            };

            ControlManager.Add(_xp);

            label = new Label()
            {
                Position = new Vector2(xOffset + 250, yOffset + 80),
                Text = "HP:",
                Color = Color.White,
                TabStop = false
            };

            ControlManager.Add(label);

            _hp = new Label
            {
                Position = new Vector2(xOffset + 250 + 80, yOffset + 80),
                Text = $"{GamePlayScreen.Player.Character.Entity.Health.CurrentValue} / {GamePlayScreen.Player.Character.Entity.Health.MaximumValue}",
                Color = Color.Yellow,
                TabStop = false
            };

            ControlManager.Add(_hp);

            _resName = new Label
            {
                Position = new Vector2(xOffset + 250, yOffset + 120),
                Color = Color.White,
                TabStop = false
            };

            _resName.Text = GamePlayScreen.Player.Character.Entity.Mana.MaximumValue > 0 ? "MP:" : "SP:";

            ControlManager.Add(_resName);

            _res = new Label
            {
                Position = new Vector2(xOffset + 250 + 80, yOffset + 120),
                Color = Color.Yellow,
                TabStop = false
            };

            _res.Color = GamePlayScreen.Player.Character.Entity.Mana.MaximumValue > 0 ? Color.Yellow : Color.Blue;

            _res.Text = GamePlayScreen.Player.Character.Entity.Mana.MaximumValue > 0 ?
                $"{GamePlayScreen.Player.Character.Entity.Mana.CurrentValue} / " +
                $"{GamePlayScreen.Player.Character.Entity.Mana.MaximumValue}" :
                $"{GamePlayScreen.Player.Character.Entity.Stamina.CurrentValue} / " +
                $"{GamePlayScreen.Player.Character.Entity.Stamina.MaximumValue}";

            _headGear = new Rectangle(55, 157, 101, 73);
            _bodyGear = new Rectangle(55, 247, 101, 73);
            _handGear = new Rectangle(55, 337, 101, 73);
            _footGear = new Rectangle(55, 427, 101, 73);
            _neckGear = new Rectangle(500, 157, 101, 73);
            _mainGear = new Rectangle(500, 247, 101, 73);
            _offGear = new Rectangle(500, 337, 101, 73);
            _fingerGear = new Rectangle(500, 427, 101, 73);
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

            if (InputHandler.KeyReleased(Keys.Escape))
            {
                StateManager.PopState();
            }

            if (InputHandler.CheckMouseReleased(MouseButton.Left))
            {
                if (_closeArea.Contains(InputHandler.MouseAsPoint))
                {
                    StateManager.PopState();
                }
            }
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

            GameRef.SpriteBatch.Draw(_background, new Rectangle(0, 0, 1280, 720), Color.White);

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

            ControlManager.Draw(GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }
    }
}
