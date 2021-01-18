using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EyesOfTheDragon.Components;
using MGRpgLibrary;
using MGRpgLibrary.TileEngine;
using MGRpgLibrary.SpriteClasses;
using MGRpgLibrary.WorldClasses;

namespace EyesOfTheDragon.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {
        #region Field Region
        
        Engine engine = new Engine(32, 32);
        Player player;
        World world;
        
        #endregion
        
        #region Property Region
        #endregion
        
        #region Constructor Region
        
        public GamePlayScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
            world = new World(game, GameRef.ScreenRectangle);
        }
        
        #endregion
        
        #region MonoGame Method Region
        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            string gender = GameRef.CharacterGeneratorScreen.SelectedGender.ToLower() == "male" ?
                "male" : "female";

            Texture2D spriteSheet = Game.Content.Load<Texture2D>(
                @"PlayerSprites\" +
                gender +
                GameRef.CharacterGeneratorScreen.SelectedClass);
    
            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey,
                Animation>();

            Animation animation = new Animation(3, 32, 32, 0, 0);

            animations.Add(AnimationKey.Down, animation);
            animation = new Animation(3, 32, 32, 0, 32);
            animations.Add(AnimationKey.Left, animation);
            animation = new Animation(3, 32, 32, 0, 64);
            animations.Add(AnimationKey.Right, animation);
            animation = new Animation(3, 32, 32, 0, 96);
            animations.Add(AnimationKey.Up, animation);

            AnimatedSprite sprite = new AnimatedSprite(spriteSheet, animations);

            player = new Player(GameRef, sprite);

            base.LoadContent();

            Texture2D tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset1");
            Tileset tileset1 = new Tileset(tilesetTexture, 8, 8, 32, 32);

            tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset2");

            Tileset tileset2 = new Tileset(tilesetTexture, 8, 8, 32, 32);
            List<Tileset> tilesets = new List<Tileset>();

            tilesets.Add(tileset1);
            tilesets.Add(tileset2);

            MapLayer layer = new MapLayer(100, 100);

            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    Tile tile = new Tile(0, 0);

                    layer.SetTile(x, y, tile);
                }
            }

            MapLayer splatter = new MapLayer(100, 100);
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(0, 100);
                int y = random.Next(0, 100);
                int index = random.Next(2, 14);
                Tile tile = new Tile(index, 0);
                splatter.SetTile(x, y, tile);
            }

            splatter.SetTile(1, 0, new Tile(0, 1));
            splatter.SetTile(2, 0, new Tile(2, 1));
            splatter.SetTile(3, 0, new Tile(0, 1));

            List<MapLayer> mapLayers = new List<MapLayer>();

            mapLayers.Add(layer);
            mapLayers.Add(splatter);

            TileMap map = new TileMap(tilesets, mapLayers);
            Level level = new Level(map);

            world.Levels.Add(level);
            world.CurrentLevel = 0;
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                player.Camera.Transformation);

            world.DrawLevel(GameRef.SpriteBatch, player.Camera);
            player.Draw(gameTime, GameRef.SpriteBatch);
            base.Draw(gameTime);

            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Abstract Method Region
        #endregion
    }
}
