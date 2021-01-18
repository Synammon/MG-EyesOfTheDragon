using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MGRpgLibrary.TileEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGRpgLibrary.WorldClasses
{
    public class Level
    {
        #region Field Region

        readonly TileMap map;

        #endregion

        #region Property Region

        public TileMap Map
        {
            get { return map; }
        }

        #endregion

        #region Constructor Region

        public Level(TileMap tileMap)
        {
            map = tileMap;
        }

        #endregion

        #region Method Region

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spiteBatch, Camera camera)
        {
            map.Draw(spiteBatch, camera);
        }

        #endregion
    }
}
