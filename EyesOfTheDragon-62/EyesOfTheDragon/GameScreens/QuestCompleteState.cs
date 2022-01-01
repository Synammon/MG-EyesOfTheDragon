using MGRpgLibrary;
using MGRpgLibrary.Controls;
using MGRpgLibrary.ItemClasses;
using MGRpgLibrary.QuestClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace EyesOfTheDragon.GameScreens
{
    public class QuestCompleteState : BaseGameState
    {
        private Reward _reward;
        private Label _gold;
        private Label _exp;

        public QuestCompleteState(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        public void SetReward(Reward reward)
        {
            _reward = reward;
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            Vector2 size = FontManager.GetFont("testfont").MeasureString("Close");

            LinkLabel label = new LinkLabel()
            {
                Position = new Vector2(
                    (Game1.ScreenWidth - size.X) / 2, 
                    720 - FontManager.GetFont("testfont").LineSpacing * 2),
                Text = "Close",
                Visible = true
            };

            ControlManager.Add(label);

            Label l = new Label()
            {
                Position = new Vector2(50, 50),
                Text = "Thank you for helping me. Here is your reward.",
                Color = Color.White,
                Visible = true
            };

            ControlManager.Add(l);

            _gold = new Label
            {
                Position = new Vector2(50, 50 + size.Y * 2),
                Text = "",
                Color = Color.Yellow,
                TabStop = false,
                Visible = true
            };

            ControlManager.Add(_gold);

            _exp = new Label
            {
                Position = new Vector2(50, 50 + FontManager.GetFont("testfont").LineSpacing * 3),
                Text = "",
                Color = Color.Yellow,
                TabStop = false,
                Visible = true
            };

            ControlManager.Add(_exp);

            label.Selected += Label_Selected;
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, playerIndexInControl);

            _exp.Text = $"You have gained {_reward.Experience} experiene.";
            _gold.Text = $"You received {_reward.Gold} gold.";

            if (InputHandler.KeyReleased(Keys.Escape) || 
                InputHandler.KeyReleased(Keys.Space))
            {
                StateManager.PopState();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Rectangle r = new Rectangle(50, 400, 64, 64);

            int _width = 50;

            GameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            ControlManager.Draw(GameRef.SpriteBatch);

            foreach (var i in _reward.Items)
            {
                GameItem item = GameItemManager.GetItem(i);

                item.Draw(GameRef.SpriteBatch, r);

                _width += 72;
                r.X += 72;

                if (_width >= GameRef.ScreenRectangle.Width - 50)
                {
                    _width = 72;
                    r.Y += 72;
                }
            }

            GameRef.SpriteBatch.End();
        }

        private void Label_Selected(object sender, EventArgs e)
        {
            StateManager.PopState();
        }
    }
}
