using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGRpgLibrary.TileEngine
{
    public class TileMap
    {
        #region Field Region

        List<Tileset> tilesets;
        AnimatedTileset animatedSet;
        List<ILayer> mapLayers;
        CollisionLayer collisionLayer;
        AnimatedTileLayer animatedTileLayer;
        static int mapWidth;
        static int mapHeight;

        #endregion

        #region Property Region


        public CollisionLayer CollisionLayer
        {
            get { return collisionLayer; }
        }

        public AnimatedTileLayer AnimatedTileLayer
        {
            get { return animatedTileLayer; }
        }

        public static int WidthInPixels
        {
            get { return mapWidth * Engine.TileWidth; }
        }

        public static int HeightInPixels
        {
            get { return mapHeight * Engine.TileHeight; }
        }

        #endregion

        #region Constructor Region

        public TileMap(
            List<Tileset> tilesets, 
            AnimatedTileset animatedTileSet, 
            MapLayer baseLayer, 
            MapLayer buildingLayer, 
            MapLayer splatterLayer, 
            CollisionLayer collisionLayer,
            AnimatedTileLayer animatedLayer)
        {
            this.tilesets = tilesets;
            this.animatedSet = animatedTileSet;
            this.mapLayers = new List<ILayer>();
            this.collisionLayer = collisionLayer;
            this.animatedTileLayer = animatedLayer;
            
            mapLayers.Add(baseLayer);
            
            AddLayer(buildingLayer);
            AddLayer(splatterLayer);
            
            mapWidth = baseLayer.Width;
            mapHeight = baseLayer.Height;
        }

        public TileMap(Tileset tileset, AnimatedTileset animatedTileset, MapLayer baseLayer)
        {
            this.animatedSet = animatedTileset;
        
            tilesets = new List<Tileset>();
            tilesets.Add(tileset);
            
            collisionLayer = new CollisionLayer();
            animatedTileLayer = new AnimatedTileLayer();
            mapLayers = new List<ILayer>();
            
            mapLayers.Add(baseLayer);
            
            mapWidth = baseLayer.Width;
            mapHeight = baseLayer.Height;
        }

        #endregion
        
        #region Method Region
        
        public void AddLayer(ILayer layer)
        {
            if (layer is MapLayer)
            {
                if (!(((MapLayer)layer).Width == mapWidth && ((MapLayer)layer).Height == mapHeight))
                    throw new Exception("Map layer size exception");
            }

            mapLayers.Add(layer);
        }

        public void AddTileset(Tileset tileset)
        {
            tilesets.Add(tileset);
        }

        public void Update(GameTime gameTime)
        {
            foreach (ILayer layer in mapLayers)
            {
                layer.Update(gameTime);
            }

            animatedTileLayer.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (MapLayer layer in mapLayers)
            {
                layer.Draw(spriteBatch, camera, tilesets);
            }
            
            if (animatedSet != null)
                animatedTileLayer.Draw(spriteBatch, animatedSet);
        }

        #endregion
    }
}
