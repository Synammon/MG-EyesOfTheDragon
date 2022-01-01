using MGRpgLibrary.ItemClasses;
using MGRpgLibrary.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.CharacterClasses
{
    public class Merchant : Character
    {
        private Backpack _backpack;

        public Backpack Backpack { get => _backpack; private set => _backpack = value; }

        public Merchant(Entity entity, AnimatedSprite sprite) : base(entity, sprite)
        {
            Backpack = new Backpack();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            SpriteFont font = FontManager.GetFont("testfont");

            spriteBatch.DrawString(
                font,
                "F",
                new Vector2(
                    Sprite.Bounds.X + (Sprite.Bounds.Width - font.MeasureString("F").X) / 2,
                    Sprite.Bounds.Y - font.LineSpacing),
                Color.Yellow);
        }

    }
}
