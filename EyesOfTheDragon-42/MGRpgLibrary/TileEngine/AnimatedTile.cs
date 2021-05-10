using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.WorldClasses;

namespace MGRpgLibrary.TileEngine
{
    public class AnimatedTile
    {
        private int framesPerSecond;
        public int TileIndex;
        public int CurrentFrame;
        public int FrameCount;
        public TimeSpan Elapsed;
        public TimeSpan Length;

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

                Length = TimeSpan.FromSeconds(1 / (double)framesPerSecond);
            }
        }

        public AnimatedTile(int tileIndex, int frames)
        {
            TileIndex = tileIndex;
            CurrentFrame = 0;
            framesPerSecond = 8;
            FrameCount = frames;
            Elapsed = TimeSpan.Zero;
            Length = TimeSpan.Zero;
            Length = TimeSpan.FromSeconds(1 / (double)framesPerSecond);
        }

        public void Update(GameTime gameTime)
        {
            Elapsed += gameTime.ElapsedGameTime;

            if (Elapsed >= Length)
            {
                Elapsed = TimeSpan.Zero;
                CurrentFrame = (CurrentFrame + 1) % FrameCount;
            }
        }
    }
    public class AnimatedTileset
    {
        #region Fields and Properties

        Texture2D image;
        int tileWidthInPixels;
        int tileHeightInPixels;
        int frameCount;
        int tilesHigh;
        List<Rectangle[]> sourceFrames = new List<Rectangle[]>();

        #endregion

        #region Property Region

        public Texture2D Texture
        {
            get { return image; }
            private set { image = value; }
        }

        public int TileWidth
        {
            get { return tileWidthInPixels; }
            private set { tileWidthInPixels = value; }
        }

        public int TileHeight
        {
            get { return tileHeightInPixels; }
            private set { tileHeightInPixels = value; }
        }

        public int FrameCount
        {
            get { return frameCount; }
            private set { frameCount = value; }
        }

        public int TilesHigh
        {
            get { return tilesHigh; }
            private set { tilesHigh = value; }
        }

        public List<Rectangle[]> SourceFrames
        {
            get { return sourceFrames; }
        }

        #endregion

        #region Constructor Region

        public AnimatedTileset(
            Texture2D image, 
            int frameCount, 
            int tilesHigh, 
            int tileWidth, 
            int tileHeight)
        {
            Texture = image;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            FrameCount = frameCount;
            TilesHigh = tilesHigh;
            
            for (int y = 0; y < tilesHigh; y++)
            {
                Rectangle[] frames = new Rectangle[frameCount];
            
                for (int x = 0; x < frameCount; x++)
                {
                    frames[x] = new Rectangle(
                        x * tileWidth,
                        y * tileHeight,
                        tileWidth,
                        tileHeight);
                }
        
                SourceFrames.Add(frames);
            }
        }

        #endregion
        
        #region Method Region
        #endregion
    }
}
