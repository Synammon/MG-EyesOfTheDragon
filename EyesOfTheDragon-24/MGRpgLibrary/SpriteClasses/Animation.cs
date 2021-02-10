using System;
using Microsoft.Xna.Framework;

namespace MGRpgLibrary.SpriteClasses
{
    public enum AnimationKey { Down, Left, Right, Up }
 
    public class Animation : ICloneable
    {
        #region Field Region
        
        Rectangle[] frames;
        int framesPerSecond;
        TimeSpan frameLength;
        TimeSpan frameTimer;
        int currentFrame;
        int frameWidth;
        int frameHeight;
        
        #endregion
        
        #region Property Region
        
        public int FramesPerSecond
        {
            get { return framesPerSecond; }
            set
            {
                if (value < 1)
                    framesPerSecond = 1;
                else if (value > 60)
                    framesPerSecond = 60;
                else
                    framesPerSecond = value;
                frameLength = TimeSpan.FromSeconds(1 / (double)framesPerSecond);
            }
        }
        
        public Rectangle CurrentFrameRect
        {
            get { return frames[currentFrame]; }
        }
        
        public int CurrentFrame
        {
            get { return currentFrame; }
            set
            {
                currentFrame = (int)MathHelper.Clamp(value, 0, frames.Length - 1);
            }
        }
        
        public int FrameWidth
        {
            get { return frameWidth; }
        }
        
        public int FrameHeight
        {
            get { return frameHeight; }
        }
        
        #endregion
        
        #region Constructor Region
        
        public Animation(
            int frameCount, 
            int frameWidth, 
            int frameHeight, 
            int xOffset, 
            int yOffset)
        {
            frames = new Rectangle[frameCount];

            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;

            for (int i = 0; i < frameCount; i++)
            {
                frames[i] = new Rectangle(
                xOffset + (frameWidth * i),
                yOffset,
                frameWidth,
                frameHeight);
            }

            FramesPerSecond = 5;

            Reset();
        }

        private Animation(Animation animation)
        {
            this.frames = animation.frames;

            FramesPerSecond = 5;
        }

        #endregion

        #region Method Region

        public void Update(GameTime gameTime)
        {
            frameTimer += gameTime.ElapsedGameTime;

            if (frameTimer >= frameLength)
            {
                frameTimer = TimeSpan.Zero;
                currentFrame = (currentFrame + 1) % frames.Length;
            }
        }

        public void Reset()
        {
            currentFrame = 0;
            frameTimer = TimeSpan.Zero;
        }

        #endregion

        #region Interface Method Region

        public object Clone()
        {
            Animation animationClone = new Animation(this)
            {
                frameWidth = this.frameWidth,
                frameHeight = this.frameHeight
            };

            animationClone.Reset();

            return animationClone;
        }

        #endregion
    }
}
