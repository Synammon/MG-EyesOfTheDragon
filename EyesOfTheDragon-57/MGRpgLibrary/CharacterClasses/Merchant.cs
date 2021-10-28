using MGRpgLibrary.ItemClasses;
using MGRpgLibrary.SpriteClasses;
using RpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.CharacterClasses
{
    public class Merchant : Character
    {
        private Backpack _backpack;

        public Backpack Backpack { get => _backpack; private set => _backpack = value; }

        public Merchant(Entity entity, AnimatedSprite sprite) : base(entity, sprite)
        {
            Backpack = new Backpack();
        }
    }
}
