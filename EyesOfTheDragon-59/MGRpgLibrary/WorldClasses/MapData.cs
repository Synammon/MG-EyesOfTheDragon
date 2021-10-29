using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MGRpgLibrary.TileEngine;

namespace RpgLibrary.WorldClasses
{
    public class MapData
    {
        public string MapName;
        public MapLayerData[] Layers;
        public TilesetData[] Tilesets;
        
        [ContentSerializer(Optional = true)]
        public AnimatedTilesetData AnimatedTileset;
        
        [ContentSerializer(Optional = true)]
        public AnimatedTileLayer AnimatedTiles;
        
        [ContentSerializer(Optional = true)]
        public CollisionLayer Collisions;
        
        private MapData()
        {
        }

        public MapData(
            string mapName, 
            List<TilesetData> tilesets, 
            AnimatedTilesetData animatedSet, 
            List<MapLayerData> layers, 
            CollisionLayer collisionLayer, 
            AnimatedTileLayer animatedLayer)
        {
            MapName = mapName;
            AnimatedTileset = animatedSet;
            Tilesets = tilesets.ToArray();
            Layers = layers.ToArray();
            Collisions = collisionLayer;
            AnimatedTiles = animatedLayer;
        }
    }
}
