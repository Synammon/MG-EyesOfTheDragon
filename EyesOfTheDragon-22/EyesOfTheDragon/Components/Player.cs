using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MGRpgLibrary;
using MGRpgLibrary.TileEngine;
using MGRpgLibrary.SpriteClasses;
using MGRpgLibrary.CharacterClasses;

namespace EyesOfTheDragon.Components
{
    public class Player
    {
        #region Field Region

        Camera camera;
        Game1 gameRef;
        readonly Character character;

        #endregion

        #region Property Region

        public Camera Camera
        {
            get { return camera; }
            set { camera = value; }
        }

        public AnimatedSprite Sprite
        {
            get { return character.Sprite; }
        }

        public Character Character
        {
            get { return character; }
        }

        #endregion

        #region Constructor Region

        public Player(Game game, Character character)
        {
            gameRef = (Game1)game;
            camera = new Camera(gameRef.ScreenRectangle);
            this.character = character;
        }

        #endregion
        
        #region Method Region
        
        public void Update(GameTime gameTime)
        {
            camera.Update(gameTime);
            Sprite.Update(gameTime);

            if (InputHandler.KeyReleased(Keys.PageUp) ||
                InputHandler.ButtonReleased(Buttons.LeftShoulder, PlayerIndex.One))
            {
                camera.ZoomIn();
                if (camera.CameraMode == CameraMode.Follow)
                    camera.LockToSprite(Sprite);
            }
            else if (InputHandler.KeyReleased(Keys.PageDown) ||
                InputHandler.ButtonReleased(Buttons.RightShoulder, PlayerIndex.One))
            {
                camera.ZoomOut();
                if (camera.CameraMode == CameraMode.Follow)
                    camera.LockToSprite(Sprite);
            }
            
            Vector2 motion = new Vector2();

            if (InputHandler.KeyDown(Keys.W) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickUp, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Up;
                motion.Y = -1;
            }
            else if (InputHandler.KeyDown(Keys.S) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickDown, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Down;
                motion.Y = 1;
            }
            
            if (InputHandler.KeyDown(Keys.A) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickLeft, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Left;
                motion.X = -1;
            }
            else if (InputHandler.KeyDown(Keys.D) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickRight, PlayerIndex.One))
            {
                    Sprite.CurrentAnimation = AnimationKey.Right;
                motion.X = 1;
            }

            if (motion != Vector2.Zero)
            {
                motion.Normalize();

                Sprite.IsAnimating = true;
                Sprite.Position += motion * Sprite.Speed;
                Sprite.LockToMap();
            
                if (camera.CameraMode == CameraMode.Follow)
                    camera.LockToSprite(Sprite);
            }
            else
            {
                Sprite.IsAnimating = false;
            }

            if (InputHandler.KeyReleased(Keys.F) ||
                InputHandler.ButtonReleased(Buttons.RightStick, PlayerIndex.One))
            {
                camera.ToggleCameraMode();
            
                if (camera.CameraMode == CameraMode.Follow)
                    camera.LockToSprite(Sprite);
            }
    
            if (camera.CameraMode != CameraMode.Follow)
            {
                if (InputHandler.KeyReleased(Keys.C) ||
                    InputHandler.ButtonReleased(Buttons.LeftStick, PlayerIndex.One))
                {
                    camera.LockToSprite(Sprite);
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)

        {
            character.Draw(gameTime, spriteBatch);
        }
        #endregion
    }
}
