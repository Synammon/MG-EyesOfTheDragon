using MGRpgLibrary;
using MGRpgLibrary.Controls;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EyesOfTheDragon.GameScreens
{
    public class LevelScreen : StatsScreen
    {
        private float _points;
        private LinkLabel _strBtn;
        private LinkLabel _dexBtn;
        private LinkLabel _cunBtn;
        private LinkLabel _magBtn;
        private LinkLabel _wilBtn;
        private LinkLabel _conBtn;

        public LevelScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            _strBtn = new LinkLabel
            {
                Text = "+",
                Position = _str.Position + new Vector2(50, 0),
                TabStop = true,
            };

            ControlManager.Add(_strBtn);


            _dexBtn = new LinkLabel
            {
                Text = "+",
                Position = _dex.Position + new Vector2(50, 0),
                TabStop = true,
            };

            ControlManager.Add(_dexBtn);

            _cunBtn = new LinkLabel
            {
                Text = "+",
                Position = _cun.Position + new Vector2(50, 0),
                TabStop = true,
            };

            ControlManager.Add(_cunBtn);

            _magBtn = new LinkLabel
            {
                Text = "+",
                Position = _mag.Position + new Vector2(50, 0),
                TabStop = true,
            };

            ControlManager.Add(_magBtn);

            _wilBtn = new LinkLabel
            {
                Text = "+",
                Position = _wil.Position + new Vector2(50, 0),
                TabStop = true,
            };

            ControlManager.Add(_wilBtn);

            _conBtn = new LinkLabel
            {
                Text = "+",
                Position = _con.Position + new Vector2(50, 0),
                TabStop = true,
            };

            ControlManager.Add(_conBtn);

            _strBtn.Selected += StrBtn_Selected;
            _dexBtn.Selected += DexBtn_Selected;
            _cunBtn.Selected += CunBtn_Selected;
            _magBtn.Selected += MagBtn_Selected;
            _wilBtn.Selected += WilBtn_Selected;
            _conBtn.Selected += ConBtn_Selected;
        }

        private void StrBtn_Selected(object sender, EventArgs e)
        {
            if (_points > 0)
            {
                GamePlayScreen.Player.Character.Entity.AdjustAttribut("Strength", 1);
                _points--;
            }
        }

        private void DexBtn_Selected(object sender, EventArgs e)
        {
            if (_points > 0)
            {
                GamePlayScreen.Player.Character.Entity.AdjustAttribut("Dexterity", 1);
                _points--;
            }
        }

        private void CunBtn_Selected(object sender, EventArgs e)
        {
            if (_points > 0)
            {
                GamePlayScreen.Player.Character.Entity.AdjustAttribut("Cunning", 1);
                _points--;
            }
        }

        private void MagBtn_Selected(object sender, EventArgs e)
        {
            if (_points > 0)
            {
                GamePlayScreen.Player.Character.Entity.AdjustAttribut("Magic", 1);
                _points--;
            }
        }

        private void WilBtn_Selected(object sender, EventArgs e)
        {
            if (_points > 0)
            {
                GamePlayScreen.Player.Character.Entity.AdjustAttribut("Will Power", 1);
                _points--;
            }
        }

        private void ConBtn_Selected(object sender, EventArgs e)
        {
            if (_points > 0)
            {
                GamePlayScreen.Player.Character.Entity.AdjustAttribut("Constitution", 1);
                _points--;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        protected override void Show()
        {
            base.Show();

            _points = 3;
        }

        protected override void OnCloseSelected()
        {
            if (_points == 0)
            {
                base.OnCloseSelected();
            }
        }
    }
}
