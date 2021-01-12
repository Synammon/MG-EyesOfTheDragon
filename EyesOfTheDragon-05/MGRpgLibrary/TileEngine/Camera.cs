using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MGRpgLibrary.TileEngine
{
    public class Camera
    {
        #region Field Region
        
        Vector2 position;
        float speed;
        float zoom;
        Rectangle viewportRectangle;
        
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
        
        #endregion
        
        #region Constructor Region
        
        public Camera(Rectangle viewportRect)
        {
            speed = 4f;
            zoom = 1f;
            viewportRectangle = viewportRect;
        }
        
        public Camera(Rectangle viewportRect, Vector2 position)
        {
            speed = 4f;
            zoom = 1f;
            viewportRectangle = viewportRect;
            Position = position;
        }

        #endregion

        #region Method Region

        public void Update(GameTime gameTime)
        {
            Vector2 motion = Vector2.Zero;

            if (InputHandler.KeyDown(Keys.Left))
                motion.X = -speed;
            else if (InputHandler.KeyDown(Keys.Right))
                motion.X = speed;
            if (InputHandler.KeyDown(Keys.Up))
                motion.Y = -speed;
            else if (InputHandler.KeyDown(Keys.Down))
                motion.Y = speed;

            if (motion != Vector2.Zero)
                motion.Normalize();

            position += motion * speed;

            LockCamera();
        }

        private void LockCamera()
        {
            position.X = MathHelper.Clamp(position.X,
            0,
            TileMap.WidthInPixels - viewportRectangle.Width);
            position.Y = MathHelper.Clamp(position.Y,
            0,
            TileMap.HeightInPixels - viewportRectangle.Height);
        }

        #endregion
    }
}
