using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MGRpgLibrary;
using MGRpgLibrary.TileEngine;

namespace EyesOfTheDragon.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {
        #region Field Region

        Engine engine = new Engine(32, 32);
        Tileset tileset;
        TileMap map;

        #endregion

        #region Property Region
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
            Texture2D tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset1");
            tileset = new Tileset(tilesetTexture, 8, 8, 32, 32);
            MapLayer layer = new MapLayer(40, 40);

            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    Tile tile = new Tile(0, 0);
                    layer.SetTile(x, y, tile);
                }
            }

            map = new TileMap(tileset, layer);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin(
                SpriteSortMode.Immediate,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                Matrix.Identity);
            
            map.Draw(GameRef.SpriteBatch);
            base.Draw(gameTime);
        
            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Abstract Method Region
        #endregion
    }
}
