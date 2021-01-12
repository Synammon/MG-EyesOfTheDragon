using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MGRpgLibrary.SpriteClasses;
namespace MGRpgLibrary.TileEngine
{
    public enum CameraMode { Free, Follow }

    public class Camera
    {
        #region Field Region
        
        Vector2 position;
        float speed;
        float zoom;
        Rectangle viewportRectangle;
        CameraMode mode;
        
        #endregion
        
        #region Property Region
        
        public Vector2 Position
        {
            get { return position; }
            private set { position = value; }
        }
        
        public float Speed
        {
            get { return speed; }
            set
            {
                speed = (float)MathHelper.Clamp(speed, 1f, 16f);
            }
        }
        
        public float Zoom
        {
            get { return zoom; }
        }
        
        public CameraMode CameraMode
        {
            get { return mode; }
        }

        public Matrix Transformation
        {
            get
            {
                return Matrix.CreateScale(zoom) *
                    Matrix.CreateTranslation(new Vector3(-Position, 0f));
            }
        }
        
        public Rectangle ViewportRectangle
        {
            get
            {
                return new Rectangle(
                  viewportRectangle.X,
                  viewportRectangle.Y,
                  viewportRectangle.Width,
                  viewportRectangle.Height);
            }
        }        
        
        #endregion

        #region Constructor Region
        public Camera(Rectangle viewportRect)
        {
            speed = 4f;
            zoom = 1f;
            viewportRectangle = viewportRect;
            mode = CameraMode.Follow;
        }
        public Camera(Rectangle viewportRect, Vector2 position)
        {
            speed = 4f;
            zoom = 1f;
            viewportRectangle = viewportRect;
            Position = position;
            mode = CameraMode.Follow;
        }

        #endregion

        #region Method Region

        public void Update(GameTime gameTime)
        {
            if (mode == CameraMode.Follow)
                return;

            Vector2 motion = Vector2.Zero;

            if (InputHandler.KeyDown(Keys.Left) ||
                InputHandler.ButtonDown(Buttons.RightThumbstickLeft, PlayerIndex.One))
                motion.X = -speed;
            else if (InputHandler.KeyDown(Keys.Right) ||
                InputHandler.ButtonDown(Buttons.RightThumbstickRight, PlayerIndex.One))
                motion.X = speed;
        
            if (InputHandler.KeyDown(Keys.Up) ||
                InputHandler.ButtonDown(Buttons.RightThumbstickUp, PlayerIndex.One))
                motion.Y = -speed;
            else if (InputHandler.KeyDown(Keys.Down) ||
                InputHandler.ButtonDown(Buttons.RightThumbstickDown, PlayerIndex.One))
                motion.Y = speed;

            if (motion != Vector2.Zero)
            {
                motion.Normalize();
                position += motion * speed;
                
                LockCamera();
            }
        }

        public void LockToSprite(AnimatedSprite sprite)
        {
            position.X = (sprite.Position.X + sprite.Width / 2) * zoom
                - (viewportRectangle.Width / 2);

            position.Y = (sprite.Position.Y + sprite.Height / 2) * zoom
                - (viewportRectangle.Height / 2);

            LockCamera();
        }

        public void ZoomIn()

        {
            zoom += .25f;

            if (zoom > 2.5f)
                zoom = 2.5f;

            Vector2 newPosition = Position * zoom;

            SnapToPosition(newPosition);
        }

        public void ZoomOut()
        {
            zoom -= .25f;

            if (zoom < .5f)
                zoom = .5f;

            Vector2 newPosition = Position * zoom;

            SnapToPosition(newPosition);
        }

        private void SnapToPosition(Vector2 newPosition)
        {
            position.X = newPosition.X - viewportRectangle.Width / 2;
            position.Y = newPosition.Y - viewportRectangle.Height / 2;

            LockCamera();
        }

        private void LockCamera()
        {
            position.X = MathHelper.Clamp(position.X,
                0,
                TileMap.WidthInPixels * zoom - viewportRectangle.Width);

            position.Y = MathHelper.Clamp(position.Y,
                0,
                TileMap.HeightInPixels * zoom - viewportRectangle.Height);
        }
        
        public void ToggleCameraMode()
        {
            if (mode == CameraMode.Follow)
                mode = CameraMode.Free;
            else if (mode == CameraMode.Free)
                mode = CameraMode.Follow;
        }
     
        #endregion
    }
}
