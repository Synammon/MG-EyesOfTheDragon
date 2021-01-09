using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MGRpgLibrary;
namespace EyesOfTheDragon.GameScreens
{
    public class TitleScreen : BaseGameState
    {
        #region Field region
        Texture2D backgroundImage;
        #endregion

        #region Constructor region
        public TitleScreen(Game game, GameStateManager manager)
        : base(game, manager)
        {
        }

        #endregion

        #region MG Method region
        protected override void LoadContent()
        {
            ContentManager Content = GameRef.Content;
            backgroundImage = Content.Load<Texture2D>(@"Backgrounds\titlescreen");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();
            base.Draw(gameTime);
            
            GameRef.SpriteBatch.Draw(
                backgroundImage,
                GameRef.ScreenRectangle,
                Color.White);
        
            GameRef.SpriteBatch.End();
        }

        #endregion
    }
}
