using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.ConversationComponents
{
    public class CombatScene : GameScene
    {
        private string caption;

        public CombatScene(Game game, string text, List<SceneOption> options, string textureName = "basic_scene") : base(text, options, textureName)
        {
            menuPosition = new Vector2(50, 530);
            NormalColor = Color.White;
            HighLightColor = Color.Red;
            this.game = game;
        }

        public void SetCaption(string caption)
        {
            this.caption = caption;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D portrait = null)
        {
            Vector2 selectedPosition = new Vector2();
            Rectangle portraitRect = new Rectangle(25, 25, 425, 425);
            Color myColor;

            if (selected == null)
                selected = game.Content.Load<Texture2D>(@"GUI\rightarrowUp");

            if (textPosition == Vector2.Zero)
                SetText(text);

            if (portrait != null)
                spriteBatch.Draw(portrait, portraitRect, Color.White);

            font = FontManager.GetFont("testfont");

            Vector2 position = menuPosition;

            spriteBatch.DrawString(font, caption, menuPosition, Color.Yellow);

            position.Y += font.LineSpacing + 10;

            for (int i = 0; i < options.Count; i++)
            {
                if (i == SelectedIndex)
                {
                    myColor = HighLightColor;
                    selectedPosition.X = position.X - 35;
                    selectedPosition.Y = position.Y;
                    spriteBatch.Draw(selected, selectedPosition, Color.White);
                }
                else
                    myColor = NormalColor;

                spriteBatch.DrawString(font,
                    options[i].OptionText,
                    position,
                    myColor);

                position.Y += font.LineSpacing + 5;
            }
        }
    }
}
