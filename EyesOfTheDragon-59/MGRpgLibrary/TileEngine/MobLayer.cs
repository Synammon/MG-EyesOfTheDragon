using MGRpgLibrary.Mobs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.TileEngine
{
    public class MobLayer : ILayer
    {
        private Dictionary<Rectangle, Mob> _mobs = new Dictionary<Rectangle, Mob>();

        public Dictionary<Rectangle, Mob> Mobs { get => _mobs; }

        public void Draw(SpriteBatch spriteBatch, Camera camera, List<Tileset> tilesets)
        {
            foreach (Rectangle r in _mobs.Keys)
            {
                //_mobs[r].Sprite.Position = new Vector2(r.X, r.Y);
                _mobs[r].Draw(new GameTime(), spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Mob m in _mobs.Values)
            {
                m.Update(gameTime);
            }
        }
    }
}
