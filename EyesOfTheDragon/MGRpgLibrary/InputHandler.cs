using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MGRpgLibrary
{
    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        #region Field Region
        static KeyboardState keyboardState;
        static KeyboardState lastKeyboardState;
        #endregion

        #region Property Region
        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }
        #endregion

        #region Constructor Region
        
        public InputHandler(Game game)
        : base(game)
        {
            keyboardState = Keyboard.GetState();
        }
        
        #endregion
        
        #region MG methods
        
        public override void Initialize()
        {
            base.Initialize();
        }
        
        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            base.Update(gameTime);
        }
        
        #endregion
        
        #region General Method Region
        
        public static void Flush()
        {
            lastKeyboardState = keyboardState;
        }
        
        #endregion
        
        #region Keyboard Region
        
        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) &&
            lastKeyboardState.IsKeyDown(key);
        }
        
        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) &&
            lastKeyboardState.IsKeyUp(key);
        }
        
        public static bool KeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }
        
        #endregion
    }
}
