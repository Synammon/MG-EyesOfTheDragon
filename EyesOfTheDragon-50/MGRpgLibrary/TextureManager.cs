using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary
{
    public class TextureManager
    {
        private static readonly Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();

        public static void AddTexture(string name, Texture2D texture)
        {
            if (!_textures.ContainsKey(name))
            {
                _textures.Add(name, texture);
            }
        }

        public static Texture2D GetTexture(string name)
        {
            if (_textures.ContainsKey(name))
            {
                return _textures[name];
            }

            return null;
        }
    }
}
