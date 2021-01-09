using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MGRpgLibrary
{
    public enum MouseButton { Left, Middle, Right }

    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        #region Keyboard Field Region
        
        static KeyboardState keyboardState;
        static KeyboardState lastKeyboardState;

        #endregion

        #region Mouse Region

        static MouseState mouseState;
        static MouseState lastMouseState;

        #endregion

        #region Game Pad Field Region

        static GamePadState[] gamePadStates;
        static GamePadState[] lastGamePadStates;
        
        #endregion
        
        #region Keyboard Property Region
        
        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }

        #endregion

        #region Mouse Property Region

        public static MouseState MouseState
        {
            get { return mouseState; }
        }

        public static MouseState LastMouseState
        {
            get { return lastMouseState; }
        }

        #endregion

        #region Game Pad Property Region

        public static GamePadState[] GamePadStates
        {
            get { return gamePadStates; }
        }
        public static GamePadState[] LastGamePadStates
        {
            get { return lastGamePadStates; }
        }

        #endregion

        #region Constructor Region

        public InputHandler(Game game)
            : base(game)
        {
            keyboardState = Keyboard.GetState();
            gamePadStates = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];
            mouseState = Mouse.GetState();
            
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
                gamePadStates[(int)index] = GamePad.GetState(index);
        }

        #endregion
        
        #region MonoGame methods

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            lastMouseState = mouseState;
            mouseState = Mouse.GetState();

            lastGamePadStates = (GamePadState[])gamePadStates.Clone();
            
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
                gamePadStates[(int)index] = GamePad.GetState(index);
        
            base.Update(gameTime);
        }
        
        #endregion
        
        #region General Method Region
        
        public static void Flush()
        {
            lastKeyboardState = keyboardState;
            lastMouseState = mouseState;
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

        #region Mouse Region
        public static Point MouseAsPoint
        {
            get { return new Point(mouseState.X, mouseState.Y); }
        }

        public static Vector2 MouseAsVector2
        {
            get { return new Vector2(mouseState.X, mouseState.Y); }
        }

        public static Point LastMouseAsPoint
        {
            get { return new Point(lastMouseState.X, lastMouseState.Y); }
        }

        public static Vector2 LastMouseAsVector2
        {
            get { return new Vector2(lastMouseState.X, lastMouseState.Y); }
        }

        public static bool CheckMousePress(MouseButton button)
        {
            bool result = false;

            switch (button)
            {
                case MouseButton.Left:
                    result = mouseState.LeftButton == ButtonState.Pressed &&
                        lastMouseState.LeftButton == ButtonState.Released;
                    break;
                case MouseButton.Right:
                    result = mouseState.RightButton == ButtonState.Pressed &&
                        lastMouseState.RightButton == ButtonState.Released;
                    break;
                case MouseButton.Middle:
                    result = mouseState.MiddleButton == ButtonState.Pressed &&
                        lastMouseState.MiddleButton == ButtonState.Released;
                    break;
            }
            return result;
        }

        public static bool CheckMouseReleased(MouseButton button)
        {
            bool result = false;

            switch (button)
            {
                case MouseButton.Left:
                    result = mouseState.LeftButton == ButtonState.Released &&
                        lastMouseState.LeftButton == ButtonState.Pressed;
                    break;
                case MouseButton.Right:
                    result = mouseState.RightButton == ButtonState.Released &&
                        lastMouseState.RightButton == ButtonState.Pressed;
                    break;
                case MouseButton.Middle:
                    result = mouseState.MiddleButton == ButtonState.Released &&
                        lastMouseState.MiddleButton == ButtonState.Pressed;
                    break;
            }

            return result;
        }

        public static bool IsMouseDown(MouseButton button)
        {
            bool result = false;

            switch (button)
            {
                case MouseButton.Left:
                    result = mouseState.LeftButton == ButtonState.Pressed;
                    break;
                case MouseButton.Right:
                    result = mouseState.RightButton == ButtonState.Pressed;
                    break;
                case MouseButton.Middle:
                    result = mouseState.MiddleButton == ButtonState.Pressed;
                    break;
            }

            return result;
        }

        public static bool IsMouseUp(MouseButton button)
        {
            bool result = false;

            switch (button)
            {
                case MouseButton.Left:
                    result = mouseState.LeftButton == ButtonState.Released;
                    break;
                case MouseButton.Right:
                    result = mouseState.RightButton == ButtonState.Released;
                    break;
                case MouseButton.Middle:
                    result = mouseState.MiddleButton == ButtonState.Released;
                    break;
            }

            return result;
        }

        #endregion

        #region Game Pad Region

        public static bool ButtonReleased(Buttons button, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonUp(button) &&
            lastGamePadStates[(int)index].IsButtonDown(button);
        }

        public static bool ButtonPressed(Buttons button, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonDown(button) &&
            lastGamePadStates[(int)index].IsButtonUp(button);
        }

        public static bool ButtonDown(Buttons button, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonDown(button);
        }
        #endregion
    }
}
