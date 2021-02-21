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
using EyesOfTheDragon.GameScreens;

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
                {
                    camera.LockToSprite(Sprite);
                }
            }
            else if (InputHandler.KeyReleased(Keys.PageDown) ||
                InputHandler.ButtonReleased(Buttons.RightShoulder, PlayerIndex.One))
            {
                camera.ZoomOut();
            
                if (camera.CameraMode == CameraMode.Follow)
                {
                    camera.LockToSprite(Sprite);
                }
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
                UpdatePosition(gameTime, motion);
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
                {
                    camera.LockToSprite(Sprite);
                }
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

        private void UpdatePosition(GameTime gameTime, Vector2 motion)
        {
            Sprite.IsAnimating = true;
            motion.Normalize();
            
            Vector2 distance = motion * Sprite.Speed *
                (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 next = distance + Sprite.Position;
    
            Rectangle playerRect = new Rectangle(
                (int)next.X + CollisionLayer.CollisionRadius,
                (int)next.Y + CollisionLayer.CollisionRadius,
                Engine.TileWidth - CollisionLayer.CollisionRadius,
                Engine.TileHeight - CollisionLayer.CollisionRadius);
            foreach (Point p in
                GamePlayScreen.World.CurrentMap.CollisionLayer.Collisions.Keys)
            {
                Rectangle r = new Rectangle(
                    p.X * Engine.TileWidth + CollisionLayer.CollisionRadius,
                    p.Y * Engine.TileHeight + CollisionLayer.CollisionRadius,
                    Engine.TileWidth - CollisionLayer.CollisionRadius,
                    Engine.TileHeight - CollisionLayer.CollisionRadius);
            
                if (r.Intersects(playerRect))
                {
                    return;
                }
            }

            foreach (Character c in
                GamePlayScreen.World.Levels[GamePlayScreen.World.CurrentLevel].Characters)
            {
                Rectangle r = new Rectangle(
                    (int)c.Sprite.Position.X + Character.CollisionRadius,
                    (int)c.Sprite.Position.Y + Character.CollisionRadius,
                    Engine.TileWidth - Character.CollisionRadius,
                    Engine.TileHeight - Character.CollisionRadius);

                if (r.Intersects(playerRect))
                {
                    return;
                }
            }

            Sprite.Position = next;
            Sprite.LockToMap();

            if (camera.CameraMode == CameraMode.Follow)
            {
                camera.LockToSprite(Sprite);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)

        {
            character.Draw(gameTime, spriteBatch);
        }
        #endregion
    }
}
