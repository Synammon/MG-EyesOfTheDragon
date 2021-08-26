using MGRpgLibrary.CharacterClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.TileEngine
{
    public class CharacterLayer : ILayer
    {
        public Dictionary<Point, Character> Characters { get; private set; } = new Dictionary<Point, Character>();

        public CharacterLayer()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, List<Tileset> tilesets)
        {
            foreach (Character c in Characters.Values)
            {
                c.Draw(new GameTime(), spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Character c in Characters.Values)
            {
                c.Update(gameTime);
            }
        }
    }
}
