using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGRpgLibrary.TileEngine
{
    public interface ILayer
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Camera camera, List<Tileset> tilesets);
    }
}
