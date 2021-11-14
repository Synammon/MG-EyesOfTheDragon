using MGRpgLibrary.Mobs;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.TileEngine
{
    public class MobLayerData
    {
        public Dictionary<Rectangle, Mob> Mobs = new Dictionary<Rectangle, Mob>();
    }
}
