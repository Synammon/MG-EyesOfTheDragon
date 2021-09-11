using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MGRpgLibrary;
using EyesOfTheDragon.Components;
using EyesOfTheDragon.GameScreens;
using RpgLibrary.ItemClasses;
using MGRpgLibrary.ItemClasses;
using System.IO;

namespace EyesOfTheDragon
{
    public class Game1 : Game
    {
        #region Frames Per Second Field Region
     
        private float fps;
        private float updateInterval = 1.0f;
        private float timeSinceLastUpdate = 0.0f;
        private float frameCount = 0;
        
        #endregion

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameStateManager _gameStateManager;

        public const int ScreenWidth = 1280;
        public const int ScreenHeight = 720;

        public readonly Rectangle ScreenRectangle = new Rectangle(
            0,
            0,
            ScreenWidth,
            ScreenHeight);

        public SpriteBatch SpriteBatch { get { return _spriteBatch; } }
        public TitleScreen TitleScreen { get; private set; }
        public StartMenuScreen StartMenuScreen { get; private set; }
        public GamePlayScreen GamePlayScreen { get; private set; }
        public CharacterGeneratorScreen CharacterGeneratorScreen { get; private set; }
        public SkillScreen SkillScreen { get; private set; }
        public LoadGameScreen LoadGameScreen { get; private set; }
        public InventoryScreen InventoryScreen { get; private set; }
        public ConversationScreen ConversationScreen { get; private set; }
        public ShopState ShopScreen { get; }
        public CombatScreen CombatScreen { get; private set; }

        public GameOverScreen GameOverScreen { get; private set; }
        public LootScreen LootScreen { get; private set; }
        public StatsScreen StatsScreen { get; private set; }
        public LevelScreen LevelScreen { get; private set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            ScreenRectangle = new Rectangle(
                0,
                0,
                ScreenWidth,
                ScreenHeight);
            IsMouseVisible = true;

            Content.RootDirectory = "Content";
            
            Components.Add(new InputHandler(this));
            
            _gameStateManager = new GameStateManager(this);
            Components.Add(_gameStateManager);

            _ = new TextureManager();

            TitleScreen = new TitleScreen(this, _gameStateManager);
            StartMenuScreen = new StartMenuScreen(this, _gameStateManager);
            GamePlayScreen = new GamePlayScreen(this, _gameStateManager);
            CharacterGeneratorScreen = new CharacterGeneratorScreen(this, _gameStateManager);
            SkillScreen = new SkillScreen(this, _gameStateManager);
            LoadGameScreen = new LoadGameScreen(this, _gameStateManager);
            ConversationScreen = new ConversationScreen(this, _gameStateManager);
            ShopScreen = new ShopState(this, _gameStateManager);
            InventoryScreen = new InventoryScreen(this, _gameStateManager);
            CombatScreen = new CombatScreen(this, _gameStateManager);
            GameOverScreen = new GameOverScreen(this, _gameStateManager);
            LootScreen = new LootScreen(this, _gameStateManager);
            StatsScreen = new StatsScreen(this, _gameStateManager);
            LevelScreen = new LevelScreen(this, _gameStateManager);

            _gameStateManager.ChangeState(TitleScreen);

            IsFixedTimeStep = false;
            _graphics.SynchronizeWithVerticalRetrace = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            DataManager.ReadEntityData(Content);
            DataManager.ReadArmorData(Content);
            DataManager.ReadShieldData(Content);
            DataManager.ReadWeaponData(Content);
            DataManager.ReadChestData(Content);
            DataManager.ReadKeyData(Content);
            DataManager.ReadSkillData(Content);

            FontManager.AddFont("testfont", Content.Load<SpriteFont>("Fonts/scenefont"));
            TextureManager.AddTexture("FullSheet", Content.Load<Texture2D>("GUI/ProjectUtumno_full"));
            string[] fileNames = Directory.GetFiles(
                Path.Combine("Content/Game/Items", "Armor"),
                "*.xnb");

            foreach (string a in fileNames)
            {
                string path = "Game/Items/Armor/" + Path.GetFileNameWithoutExtension(a);

                ArmorData armorData = Content.Load<ArmorData>(path);
                ItemManager.AddArmor(new Armor(armorData));
            }

            fileNames = Directory.GetFiles(
                Path.Combine("Content/Game/Items", "Shield"),
                "*.xnb");

            foreach (string a in fileNames)
            {
                string path = "Game/Items/Shield/" + Path.GetFileNameWithoutExtension(a);

                ShieldData shieldData = Content.Load<ShieldData>(path);
                ItemManager.AddShield(new Shield(shieldData));
            }

            fileNames = Directory.GetFiles(
                Path.Combine("Content/Game/Items", "Weapon"),
                "*.xnb");

            foreach (string a in fileNames)
            {
                string path = "Game/Items/Weapon/" + Path.GetFileNameWithoutExtension(a);

                WeaponData weaponData = Content.Load<WeaponData>(path);
                ItemManager.AddWeapon(new Weapon(weaponData));
            }

            PotionData potionData = new PotionData
            {
                Name = "Minor Healing Potion",
                Type = "Potion",
                Target = "Health",
                Price = 100,
                Weight = .25f,
                Minimum = 6,
                Maximum = 13,
                AllowableClasses = new[] { "Fighter", "Wizard", "Rogue", "Priest" }
            };

            Potion potion = new Potion(potionData);

            ItemManager.AddPotion(potion);

            potionData = new PotionData
            {
                Name = "Minor Mana Potion",
                Type = "Potion",
                Target = "Mana",
                Price = 100,
                Weight = .25f,
                Minimum = 6,
                Maximum = 13,
                AllowableClasses = new[] { "Wizard", "Priest" }
            };

            potion = new Potion(potionData);

            ItemManager.AddPotion(potion);

            potionData = new PotionData
            {
                Name = "Minor Stamina Potion",
                Type = "Potion",
                Target = "Stamina",
                Price = 100,
                Weight = .25f,
                Minimum = 6,
                Maximum = 13,
                AllowableClasses = new[] { "Fighter", "Rogue" }
            };

            potion = new Potion(potionData);

            ItemManager.AddPotion(potion);

            GameItemManager.AddItem("Long Sword", new GameItem(ItemManager.GetWeapon("Long Sword"), "FullSheet", new Rectangle(1696, 1408, 32, 32)));
            GameItemManager.AddItem("Short Sword", new GameItem(ItemManager.GetWeapon("Short Sword"), "FullSheet", new Rectangle(800, 1504, 32, 32)));
            GameItemManager.AddItem("Apprentice Staff", new GameItem(ItemManager.GetWeapon("Apprentice Staff"), "FullSheet", new Rectangle(224, 1408, 32, 32)));
            GameItemManager.AddItem("Acolyte Staff", new GameItem(ItemManager.GetWeapon("Acolyte Staff"), "FullSheet", new Rectangle(256, 1408, 32, 32)));
            GameItemManager.AddItem("Leather Armor", new GameItem(ItemManager.GetArmor("Leather Armor"), "FullSheet", new Rectangle(1248, 1216, 32, 32)));
            GameItemManager.AddItem("Chain Mail", new GameItem(ItemManager.GetArmor("Chain Mail"), "FullSheet", new Rectangle(1472, 1184, 32, 32)));
            GameItemManager.AddItem("Studded Leather Armor", new GameItem(ItemManager.GetArmor("Studded Leather Armor"), "FullSheet", new Rectangle(1984, 1120, 32, 32)));
            GameItemManager.AddItem("Light Robes", new GameItem(ItemManager.GetArmor("Light Robes"), "FullSheet", new Rectangle(992, 1216, 32, 32)));
            GameItemManager.AddItem("Medium Robes", new GameItem(ItemManager.GetArmor("Medium Robes"), "FullSheet", new Rectangle(1024, 1216, 32, 32)));
            GameItemManager.AddItem("Minor Healing Potion", new GameItem(ItemManager.GetPotion("Minor Healing Potion"), "FullSheet", new Rectangle(832, 1344, 32, 32)));
            GameItemManager.AddItem("Minor Mana Potion", new GameItem(ItemManager.GetPotion("Minor Mana Potion"), "FullSheet", new Rectangle(576, 1344, 32, 32)));
            GameItemManager.AddItem("Minor Stamina Potion", new GameItem(ItemManager.GetPotion("Minor Stamina Potion"), "FullSheet", new Rectangle(704, 1344, 32, 32)));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.F10))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCount++;
            timeSinceLastUpdate += elapsed;

            if (timeSinceLastUpdate > updateInterval)
            {
                fps = frameCount / timeSinceLastUpdate;
                
                System.Diagnostics.Debug.WriteLine("FPS: " + fps.ToString());
                this.Window.Title = "FPS: " + fps.ToString();
                
                frameCount = 0;
                timeSinceLastUpdate -= updateInterval;
            }
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
    }
}
