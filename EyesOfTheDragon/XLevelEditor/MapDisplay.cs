using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLevelEditor
{
    public class MapDisplay : MonoGame.Forms.Controls.MonoGameControl
    {
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            if (FormMain.map == null)
                return;

            Editor.spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                FormMain.camera.Transformation);

            for (int i = 0; i < FormMain.layers.Count; i++)
                FormMain.layers[i].Draw(Editor.spriteBatch, FormMain.camera, FormMain.tileSets);
                
            Editor.spriteBatch.End();
        }
    }
}
