using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using MGRpgLibrary;
using MGRpgLibrary.Controls;
using MGRpgLibrary.SpriteClasses;
using MGRpgLibrary.TileEngine;
using MGRpgLibrary.WorldClasses;
using EyesOfTheDragon.Components;
using MGRpgLibrary.CharacterClasses;
using RpgLibrary.CharacterClasses;

namespace EyesOfTheDragon.GameScreens
{
    public class LoadGameScreen : BaseGameState
    {
        #region Field Region
        
        PictureBox backgroundImage;
        ListBox loadListBox;
        LinkLabel loadLinkLabel;
        LinkLabel exitLinkLabel;
                
        #endregion
        
        #region Property Region
        #endregion
        
        #region Constructor Region
        public LoadGameScreen(Game game, GameStateManager manager)
        : base(game, manager)
        {
        }
        
        #endregion
        
        #region Method Region
      
        protected override void LoadContent()
        {
            base.LoadContent();

            ContentManager Content = Game.Content;
                backgroundImage = new PictureBox(
                Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                    GameRef.ScreenRectangle);
            
            ControlManager.Add(backgroundImage);
            
            loadLinkLabel = new LinkLabel();
            loadLinkLabel.Text = "Select game";
            loadLinkLabel.Position = new Vector2(50, 100);
            loadLinkLabel.Selected += new EventHandler(loadLinkLabel_Selected);
            
            ControlManager.Add(loadLinkLabel);
            
            exitLinkLabel = new LinkLabel();
            exitLinkLabel.Text = "Back";
            exitLinkLabel.Position = new Vector2(50, 100 + exitLinkLabel.SpriteFont.LineSpacing);
            exitLinkLabel.Selected += new EventHandler(exitLinkLabel_Selected);
            
            ControlManager.Add(exitLinkLabel);

            Texture2D texture = new Texture2D(GraphicsDevice, 300, 300);

            Color[] data = new Color[300 * 300];
            
            for (int i = 0; i < 300 * 300; i++)
            {
                data[i] = Color.White;
            }

            texture.SetData(data);

            loadListBox = new ListBox(
                texture,
                Content.Load<Texture2D>(@"GUI\rightarrowUp"));
         
            loadListBox.Position = new Vector2(400, 100);
            loadListBox.Selected += new EventHandler(loadListBox_Selected);
            loadListBox.Leave += new EventHandler(loadListBox_Leave);
        
            for (int i = 0; i < 20; i++)
                loadListBox.Items.Add("Game number: " + i.ToString());
            
            ControlManager.Add(loadListBox);
            ControlManager.NextControl();
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);
        
            base.Update(gameTime);
        }
        
        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();
            
            base.Draw(gameTime);
        
            ControlManager.Draw(GameRef.SpriteBatch);
            GameRef.SpriteBatch.End();
        }
        
        #endregion
        
        #region Method Region
        
        void loadListBox_Leave(object sender, EventArgs e)
        {
            ControlManager.AcceptInput = true;
        }

        void loadLinkLabel_Selected(object sender, EventArgs e)
        {
            ControlManager.AcceptInput = false;
            loadLinkLabel.HasFocus = false;
            loadListBox.HasFocus = true;
        }

        void loadListBox_Selected(object sender, EventArgs e)
        {
            loadLinkLabel.HasFocus = true;
            loadListBox.HasFocus = false;
            
            ControlManager.AcceptInput = true;
            StateManager.ChangeState(GameRef.GamePlayScreen);
        
            CreatePlayer();
            CreateWorld();
        }
  
        void exitLinkLabel_Selected(object sender, EventArgs e)
        {
            StateManager.PopState();
        }

        private void CreatePlayer()
        {
            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();
            
            Animation animation = new Animation(3, 32, 32, 0, 0);
            animations.Add(AnimationKey.Down, animation);
            
            animation = new Animation(3, 32, 32, 0, 32);
            animations.Add(AnimationKey.Left, animation);
            
            animation = new Animation(3, 32, 32, 0, 64);
            animations.Add(AnimationKey.Right, animation);
            
            animation = new Animation(3, 32, 32, 0, 96);
            animations.Add(AnimationKey.Up, animation);

            AnimatedSprite sprite = new AnimatedSprite(            
                GameRef.Content.Load<Texture2D>(@"PlayerSprites\malefighter"),
                animations);
            
            Entity entity = new Entity(
                "Encelwyn",
                DataManager.EntityData["Fighter"],
                EntityGender.Male,
                EntityType.Character);
            Character character = new Character(entity, sprite);

            GamePlayScreen.Player = new Player(GameRef, character);
        }

        private void CreateWorld()
        {
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
            World world = new World(GameRef, GameRef.ScreenRectangle);

            world.Levels.Add(level);
            world.CurrentLevel = 0;

            GamePlayScreen.World = world;
        }

        #endregion
    }
}
