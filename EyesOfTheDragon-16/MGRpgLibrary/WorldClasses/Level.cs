using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MGRpgLibrary.TileEngine;
using MGRpgLibrary.CharacterClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGRpgLibrary.WorldClasses
{
    public class Level
    {
        #region Field Region

        readonly TileMap map;
        readonly List<Character> characters;

        #endregion

        #region Property Region

        public TileMap Map
        {
            get { return map; }
        }

        public List<Character> Characters
        {
            get { return characters; }
        }

        #endregion

        #region Constructor Region

        public Level(TileMap tileMap)
        {
            map = tileMap;
            characters = new List<Character>();
        }

        #endregion

        #region Method Region

        public void Update(GameTime gameTime)
        {
            foreach (Character character in characters)
                character.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
        {
            map.Draw(spriteBatch, camera);

            foreach (Character character in characters)
                character.Draw(gameTime, spriteBatch);
        }

        #endregion
    }
}
