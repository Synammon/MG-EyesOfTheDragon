using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.WorldClasses
{
    public class LevelData
    {
        public string LevelName;
        public string MapName;
        public int MapWidth;
        public int MapHeight;
        public string[] CharacterNames;
        public string[] ChestNames;
        public string[] TrapNames;

        private LevelData()
        {
        }

        public LevelData(
            string levelName,
            string mapName,
            int mapWidth,
            int mapHeight,
            List<string> characterNames,
            List<string> chestNames,
            List<string> trapNames)
        {
            LevelName = levelName;
            MapName = mapName;
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            CharacterNames = characterNames.ToArray();
            ChestNames = chestNames.ToArray();
            TrapNames = trapNames.ToArray();
        }
    }
}
