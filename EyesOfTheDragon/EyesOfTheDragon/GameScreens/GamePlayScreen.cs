using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EyesOfTheDragon.Components;
using MGRpgLibrary;
using MGRpgLibrary.TileEngine;
using MGRpgLibrary.SpriteClasses;
using MGRpgLibrary.WorldClasses;

namespace EyesOfTheDragon.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {
        #region Field Region
        
        Engine engine = new Engine(32, 32);
        static Player player;
        static World world;
        
        #endregion
        
        #region Property Region
        
        public static World World
        {
            get { return world; }
            set { world = value; }
        }
        
        public static Player Player
        {
            get { return player; }
            set { player = value; }
        }
        
        #endregion
        
        #region Constructor Region
    
        public GamePlayScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            world.Update(gameTime);
            player.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                player.Camera.Transformation);
            base.Draw(gameTime);

            world.DrawLevel(GameRef.SpriteBatch, player.Camera);
            player.Draw(gameTime, GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }
        #endregion

        #region Abstract Method Region
        #endregion
    }
}
