using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MGRpgLibrary.TileEngine
{
    public class AnimatedTileLayer
    {
        private Dictionary<Point, AnimatedTile> animatedTiles = new Dictionary<Point,
            AnimatedTile>();
    
        [ContentSerializer]
        public Dictionary<Point, AnimatedTile> AnimatedTiles
        {
            get { return animatedTiles; }
            private set { animatedTiles = value; }
        }
        
        public AnimatedTileLayer()
        {
        }
        
        public void Update(GameTime gameTime)
        {
            foreach (Point p in AnimatedTiles.Keys)
                AnimatedTiles[p].Update(gameTime);
        }
        
        public void Draw(SpriteBatch spriteBatch, AnimatedTileset tileSet)
        {
            Rectangle destination = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);

            foreach (Point p in AnimatedTiles.Keys)
            {
                destination.X = p.X * Engine.TileWidth;
                destination.Y = p.Y * Engine.TileHeight;
                spriteBatch.Draw(
                    tileSet.Texture, 
                    destination,
                    tileSet.SourceFrames[AnimatedTiles[p].TileIndex][AnimatedTiles[p].CurrentFrame],
                    Color.White);
            }
        }
    }
}
