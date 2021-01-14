using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;
using MGRpgLibrary.TileEngine;
using MGRpgLibrary.SpriteClasses;

namespace MGRpgLibrary.WorldClasses
{
    public class World
    {
        #region Graphic Field and Property Region

        Rectangle screenRect;

        public Rectangle ScreenRectangle
        {
            get { return screenRect; }
        }

        #endregion

        #region Item Field and Property Region

        ItemManager itemManager = new ItemManager();

        #endregion

        #region Level Field and Property Region
        #endregion

        #region Constructor Region

        public World(Rectangle screenRectangle)
        {
            screenRect = screenRectangle;
        }

        #endregion

        #region Method Region

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }

        #endregion
    }
}
