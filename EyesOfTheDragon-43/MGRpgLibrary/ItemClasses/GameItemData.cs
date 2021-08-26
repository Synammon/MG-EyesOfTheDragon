using Microsoft.Xna.Framework;
using RpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.ItemClasses
{
    public class GameItemData
    {
        public Vector2 Position { get; set; }
        public string TextureName { get; set; }
        public Rectangle? SourceRectangle { get; set; }
        public string BaseItem { get; set; }
        public string Type { get; set; }
    }
}
