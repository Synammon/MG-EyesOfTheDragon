using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MGRpgLibrary;
using EyesOfTheDragon.GameScreens;

namespace EyesOfTheDragon
{
    public class Game1 : Game
    {
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

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            ScreenRectangle = new Rectangle(
                0,
                0,
                ScreenWidth,
                ScreenHeight);
            
            Content.RootDirectory = "Content";
            
            Components.Add(new InputHandler(this));
            
            _gameStateManager = new GameStateManager(this);
            Components.Add(_gameStateManager);

            TitleScreen = new TitleScreen(this, _gameStateManager);
            StartMenuScreen = new StartMenuScreen(this, _gameStateManager);
            GamePlayScreen = new GamePlayScreen(this, _gameStateManager);
            CharacterGeneratorScreen = new CharacterGeneratorScreen(this, _gameStateManager);
            SkillScreen = new SkillScreen(this, _gameStateManager);

            _gameStateManager.ChangeState(TitleScreen);
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

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
