using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.WorldClasses
{
    public struct Tile
    {
        public int TileIndex;
        public int TileSetIndex;

        public Tile(int tileIndex, int tileSetIndex)
        {
            TileIndex = tileIndex;
            TileSetIndex = tileSetIndex;
        }
    }

    public class MapLayerData
    {
        public string MapLayerName;
        public int Width;
        public int Height;
        public Tile[] Layer;

        private MapLayerData()
        {
        }

        public MapLayerData(string mapLayerName, int width, int height)
        {
            MapLayerName = mapLayerName;
            Width = width;
            Height = height;
            Layer = new Tile[height * width];
        }

        public MapLayerData(string mapLayerName, int width, int height, int tileIndex, int tileSet)
        {
            MapLayerName = mapLayerName;
            Width = width;
            Height = height;
            Layer = new Tile[height * width];
            Tile tile = new Tile(tileIndex, tileSet);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    SetTile(x, y, tile);
        }

        public void SetTile(int x, int y, Tile tile)
        {
            Layer[y * Width + x] = tile;
        }

        public Tile GetTile(int x, int y)
        {
            return Layer[y * Width + x];
        }
    }
}
