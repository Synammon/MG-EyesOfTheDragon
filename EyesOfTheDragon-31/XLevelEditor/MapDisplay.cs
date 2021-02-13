using MGRpgLibrary.TileEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XLevelEditor
{
    public class MapDisplay : MonoGame.Forms.Controls.MonoGameControl
    {
        Texture2D grid;
        Texture2D cursor;
        MouseState mouseState;
        private Texture2D shadow;
        private Vector2 shadowPosition;

        protected override void Initialize()
        {
            shadow = new Texture2D(GraphicsDevice, 20, 20, false, SurfaceFormat.Color);

            Color[] data = new Color[shadow.Width * shadow.Height];
            Color tint = Color.LightSteelBlue;

            tint.A = 25;

            for (int i = 0; i < shadow.Width * shadow.Height; i++)
                data[i] = tint;

            shadow.SetData<Color>(data);

            try
            {
                using (Stream stream = new FileStream(@"Content\grid.png", FileMode.Open,
                    FileAccess.Read))
                {
                    grid = Texture2D.FromStream(GraphicsDevice, stream);
                    stream.Close();
                }
    
                using (Stream stream = new FileStream(@"Content\cursor.png", FileMode.Open,
                    FileAccess.Read))
                {
                    cursor = Texture2D.FromStream(GraphicsDevice, stream);
                    stream.Close();
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message, "Error reading images");
                grid = null;
                cursor = null;
            }

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            shadowPosition = new Vector2(mouseState.Position.X, mouseState.Position.Y) +
                FormMain.camera.Position;
            Point p = Engine.VectorToCell(shadowPosition);

            for (int i = 0; i < FormMain.layers.Count; i++)
            {
                Editor.spriteBatch.Begin(
                    SpriteSortMode.Deferred,
                    BlendState.AlphaBlend,
                    SamplerState.PointClamp,
                    null,
                    null,
                    null,
                    FormMain.camera.Transformation);

                FormMain.layers[i].Draw(Editor.spriteBatch, FormMain.camera, FormMain.tileSets);

                Rectangle destination = new Rectangle(
                    (int)p.X * Engine.TileWidth,
                    (int)p.Y * Engine.TileHeight,
                    FormMain.brushWidth * Engine.TileWidth,
                    FormMain.brushWidth * Engine.TileHeight);
                Color tint = Color.White;
                tint.A = 1;
                Editor.spriteBatch.Draw(shadow, destination, tint);
                Editor.spriteBatch.End();
            }

            DrawDisplay();
        }

        private void DrawDisplay()
        {
            if (FormMain.layers.Count == 0)
                return;

            Rectangle destination = new Rectangle(
                0,
                0,
                Engine.TileWidth,
                Engine.TileHeight);

            mouseState = Mouse.GetState();

            if (FormMain.DrawGrid)
            {
                int maxX = this.Width / Engine.TileWidth + 1;
                int maxY = this.Height / Engine.TileHeight + 1;
                
                Editor.spriteBatch.Begin();

                for (int y = 0; y < maxY; y++)
                {
                    destination.Y = y * Engine.TileHeight;

                    for (int x = 0; x < maxX; x++)
                    {
                        destination.X = x * Engine.TileWidth;
                        Editor.spriteBatch.Draw(grid, destination, FormMain.gridColor);
                    }
                }

                Editor.spriteBatch.End();
            }

            Editor.spriteBatch.Begin();

            destination.X = mouseState.X;
            destination.Y = mouseState.Y;

            Editor.spriteBatch.Draw(
                FormMain.tileSets[FormMain.SelectedTileset].Texture,
                destination,
                FormMain.tileSets[FormMain.SelectedTileset].SourceRectangles[FormMain.SelectedTile],
                Color.White);

            Editor.spriteBatch.Draw(cursor, destination, Color.White);
            Editor.spriteBatch.End();
        }
    }
}
