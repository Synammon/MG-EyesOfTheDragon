using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGRpgLibrary.TileEngine
{
    public class TileMap
    {
        #region Field Region
        
        List<Tileset> tilesets;
        List<MapLayer> mapLayers;
        
        #endregion
        
        #region Property Region
        #endregion
        
        #region Constructor Region
        
        public TileMap(List<Tileset> tilesets, List<MapLayer> layers)
        {
            this.tilesets = tilesets;
            this.mapLayers = layers;
        }
        public TileMap(Tileset tileset, MapLayer layer)
        {
            tilesets = new List<Tileset>();
            tilesets.Add(tileset);
            mapLayers = new List<MapLayer>();
            mapLayers.Add(layer);
        }
        
        #endregion
        
        #region Method Region

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destination = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);
            Tile tile;

            foreach (MapLayer layer in mapLayers)
            {
                for (int y = 0; y < layer.Height; y++)
                {
                    destination.Y = y * Engine.TileHeight;
                    
                    for (int x = 0; x < layer.Width; x++)
                    {
                        tile = layer.GetTile(x, y);
                        
                        destination.X = x * Engine.TileWidth;
            
                        spriteBatch.Draw(
                            tilesets[tile.Tileset].Texture,
                            destination,
                            tilesets[tile.Tileset].SourceRectangles[tile.TileIndex],
                        Color.White);
                    }
                }
            }
        }

        #endregion
    }
}
