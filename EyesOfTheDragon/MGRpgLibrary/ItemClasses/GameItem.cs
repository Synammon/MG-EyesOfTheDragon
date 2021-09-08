using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.ItemClasses;

namespace MGRpgLibrary.ItemClasses
{
    public class GameItem : ICloneable
    {
        #region Field Region

        public Vector2 Position;
        private string image;
        private Rectangle? sourceRectangle;
        private BaseItem baseItem;
        private Type type;

        #endregion

        #region Property Region

        public string Image
        {
            get { return image; }
        }

        public Rectangle? SourceRectangle
        {
            get { return sourceRectangle; }
            set { sourceRectangle = value; }
        }

        public BaseItem Item
        {
            get { return baseItem; }
        }

        public Type Type
        {
            get { return type; }
        }

        #endregion

        #region Constructor Region

        private GameItem()
        {

        }

        public GameItem(BaseItem item, string texture, Rectangle? source)
        {
            baseItem = item;
            image = texture;
            sourceRectangle = source;
            type = item.GetType();
        }

        #endregion

        #region Method Region

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.GetTexture(image), Position, sourceRectangle, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination)
        {
            spriteBatch.Draw(TextureManager.GetTexture(Image), destination, sourceRectangle, Color.White);
        }

        public object Clone()
        {
            GameItem item = new GameItem()
            {
                baseItem = this.baseItem,
                Position = this.Position,
                image = this.image,
                sourceRectangle = this.sourceRectangle,
                type = this.type
            };

            return item;
        }

        #endregion

        #region Virtual Method region
        #endregion
    }
}
