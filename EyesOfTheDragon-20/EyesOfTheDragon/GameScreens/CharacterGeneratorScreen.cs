using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MGRpgLibrary;
using MGRpgLibrary.Controls;
using MGRpgLibrary.ItemClasses;
using MGRpgLibrary.SpriteClasses;
using MGRpgLibrary.TileEngine;
using MGRpgLibrary.WorldClasses;
using RpgLibrary.ItemClasses;
using EyesOfTheDragon.Components;

namespace EyesOfTheDragon.GameScreens
{
    public class CharacterGeneratorScreen : BaseGameState
    {
        #region Field Region

        LeftRightSelector nameSelector;
        LeftRightSelector genderSelector;
        LeftRightSelector classSelector;
        PictureBox backgroundImage;
        PictureBox characterImage;
        Texture2D[,] characterImages;

        readonly string[] genderItems = { "Male", "Female", "Non-Binary" };
        readonly string[] classItems = { "Fighter", "Wizard", "Rogue", "Priest" };
        readonly string[] maleName = { "Balthazar", "Logan", "Alfred", "Johnson" };
        readonly string[] femaleName = { "Lucinda", "Cynthia", "Ezmarelda", "Millicent" };
        readonly string[] nbName = { "Jaime", "Kelly", "Jordan", "Pat" };

        #endregion

        #region Property Region

        public string SelectedGender
        {
            get 
            { 
                return genderSelector.SelectedIndex < 2 ?
                    genderSelector.SelectedItem :
                    genderItems[1]; 
            }
        }

        public string SelectedClass
        {
            get { return classSelector.SelectedItem; }
        }

        #endregion

        #region Constructor Region

        public CharacterGeneratorScreen(Game game, GameStateManager stateManager)
            : base(game, stateManager)
        {
        }
        
        #endregion
        
        #region MonoGame Method Region

        public override void Initialize()
        {
            base.Initialize();
        }
        Texture2D containers;
        protected override void LoadContent()
        {
            base.LoadContent();
            LoadImages();
            CreateControls();
            containers = Game.Content.Load<Texture2D>(@"ObjectSprites\containers");
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

        private void CreateControls()
        {
            Texture2D leftTexture = Game.Content.Load<Texture2D>(@"GUI\leftarrowUp");
            Texture2D rightTexture = Game.Content.Load<Texture2D>(@"GUI\rightarrowUp");
            Texture2D stopTexture = Game.Content.Load<Texture2D>(@"GUI\StopBar");

            backgroundImage = new PictureBox(
                Game.Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                GameRef.ScreenRectangle);

            ControlManager.Add(backgroundImage);

            Label label1 = new Label
            {
                Text = "Who will search for the Eyes of the Dragon?"
            };
            label1.Size = label1.SpriteFont.MeasureString(label1.Text);
            label1.Position = new Vector2(
                (GameRef.Window.ClientBounds.Width - label1.Size.X) /2, 150);

            ControlManager.Add(label1);

            nameSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            nameSelector.SetItems(maleName, 125);
            nameSelector.Position = new Vector2(label1.Position.X, 200);

            ControlManager.Add(nameSelector);

            genderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            genderSelector.SetItems(genderItems, 125);
            genderSelector.Position = new Vector2(label1.Position.X, 250);
            genderSelector.SelectionChanged += GenderSelector_SelectionChanged;

            ControlManager.Add(genderSelector);

            classSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            classSelector.SetItems(classItems, 125);
            classSelector.Position = new Vector2(label1.Position.X, 300);
            classSelector.SelectionChanged += ClassSelector_SelectionChanged;

            ControlManager.Add(classSelector);

            LinkLabel linkLabel1 = new LinkLabel
            {
                Text = "Accept this character.",
                Position = new Vector2(label1.Position.X, 350)
            };

            linkLabel1.Selected += new EventHandler(LinkLabel1_Selected);

            ControlManager.Add(linkLabel1);

            characterImage = new PictureBox(
                characterImages[0, 0],
                new Rectangle(600, 200, 96, 96),
                new Rectangle(0, 0, 32, 32));

            ControlManager.Add(characterImage);

            ControlManager.NextControl();
        }

        private void LoadImages()
        {
            characterImages = new Texture2D[genderItems.Length, classItems.Length];
            for (int i = 0; i < genderItems.Length - 1; i++)
            {
                for (int j = 0; j < classItems.Length; j++)
                {
                    characterImages[i, j] = Game.Content.Load<Texture2D>(@"PlayerSprites\" +
                    genderItems[i] + classItems[j]);
                }
            }
        }

        private void ClassSelector_SelectionChanged(object sender, EventArgs e)
        {
            if (genderSelector.SelectedIndex != 2)
            {
                characterImage.Image = characterImages[genderSelector.SelectedIndex,
                    classSelector.SelectedIndex];
            }
            else
            {
                characterImage.Image = characterImages[1, classSelector.SelectedIndex];
            }
        }

        private void GenderSelector_SelectionChanged(object sender, EventArgs e)
        {
            if (genderSelector.SelectedIndex == 0)
                nameSelector.SetItems(maleName, 125);
            else if (genderSelector.SelectedIndex == 1)
                nameSelector.SetItems(femaleName, 125);
            else
                nameSelector.SetItems(nbName, 125);

            ClassSelector_SelectionChanged(this, null);
        }

        void LinkLabel1_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();

            CreatePlayer();
            CreateWorld();

            GameRef.SkillScreen.SkillPoints = 25;

            StateManager.ChangeState(GameRef.SkillScreen);
        }

        private void CreatePlayer()
        {
            Dictionary<AnimationKey, Animation> animations = 
                new Dictionary<AnimationKey, Animation>();

            Animation animation = new Animation(3, 32, 32, 0, 0);
            animations.Add(AnimationKey.Down, animation);

            animation = new Animation(3, 32, 32, 0, 32);
            animations.Add(AnimationKey.Left, animation);

            animation = new Animation(3, 32, 32, 0, 64);
            animations.Add(AnimationKey.Right, animation);

            animation = new Animation(3, 32, 32, 0, 96);
            animations.Add(AnimationKey.Up, animation);

            int gender = genderSelector.SelectedIndex < 2 ? genderSelector.SelectedIndex : 1;

            AnimatedSprite sprite = new AnimatedSprite(
                characterImages[gender, classSelector.SelectedIndex],
                animations);

            GamePlayScreen.Player = new Player(GameRef, sprite);
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
            
            ChestData chestData = Game.Content.Load<ChestData>(@"Game\Chests\Plain Chest");
            Chest chest = new Chest(chestData);
             
            BaseSprite chestSprite = new BaseSprite(
                containers,
                new Rectangle(0, 0, 32, 32),
                new Point(10, 10));

            ItemSprite itemSprite = new ItemSprite(
                chest,
                chestSprite);
            
            level.Chests.Add(itemSprite);
            
            World world = new World(GameRef, GameRef.ScreenRectangle);
            
            world.Levels.Add(level);
            world.CurrentLevel = 0;
         
            GamePlayScreen.World = world;
        }
        #endregion
    }
}
