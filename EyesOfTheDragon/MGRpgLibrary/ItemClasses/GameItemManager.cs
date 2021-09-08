using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.ItemClasses;

namespace MGRpgLibrary.ItemClasses
{
    public static class GameItemManager
    {
        #region Field Region

        static readonly Dictionary<string, GameItem> gameItems = new Dictionary<string, GameItem>();
        static SpriteFont spriteFont;

        #endregion

        #region Property Region

        public static Dictionary<string, GameItem> GameItems
        {
            get { return gameItems; }
        }

        public static SpriteFont SpriteFont
        {
            get { return spriteFont; }
            private set { spriteFont = value; }
        }

        #endregion

        #region Constructor Region
        #endregion

        #region Method Region

        public static void AddItem(string name, GameItem item)
        {
            if (!GameItems.ContainsKey(name))
            {
                GameItems.Add(name, item);
            }
        }

        public static GameItem GetItem(string name)
        {
            if (GameItems.ContainsKey(name))
            {
                return (GameItem)GameItems[name].Clone();
            }

            return null;
        }

        #endregion

        #region Virtual Method region
        #endregion
    }
}
