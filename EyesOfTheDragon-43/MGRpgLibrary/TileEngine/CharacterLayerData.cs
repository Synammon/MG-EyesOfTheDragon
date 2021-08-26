using MGRpgLibrary.CharacterClasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.TileEngine
{
    public class CharacterLayerData
    {
        public Dictionary<Point, CharacterData> Characters { get; set; } = new Dictionary<Point, CharacterData>();
    }
}
