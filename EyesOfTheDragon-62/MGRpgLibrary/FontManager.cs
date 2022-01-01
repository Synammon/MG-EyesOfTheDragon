using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary
{
    public class FontManager
    {
        private static Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();

        public static void AddFont(string fontName, SpriteFont font)
        {
            if (!fonts.ContainsKey(fontName))
            {
                fonts.Add(fontName, font);
            }
        }

        public static SpriteFont GetFont(string fontName)
        {
            if (fonts.ContainsKey(fontName))
            {
                return fonts[fontName];
            }

            return null;
        }
    }
}
