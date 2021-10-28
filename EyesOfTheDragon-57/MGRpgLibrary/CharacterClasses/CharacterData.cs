using MGRpgLibrary.ItemClasses;
using RpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.CharacterClasses
{
    public class CharacterData
    {
        public string Name { get; set; }
        public EntityGender Gender { get; set; }
        public EntityData EntityData { get; set; }
        public string TextureName { get; set; }
        public GameItemData Head { get; set; }
        public GameItemData Torso { get; set; }
        public GameItemData Hands { get; set; }
        public GameItemData Feet { get; set; }
        public GameItemData MainHand { get; set; }
        public GameItemData OffHand { get; set; }
    }
}
