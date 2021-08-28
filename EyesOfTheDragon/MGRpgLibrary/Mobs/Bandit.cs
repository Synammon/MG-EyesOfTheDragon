using MGRpgLibrary.SpriteClasses;
using RpgLibrary;
using RpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.Mobs
{
    public class Bandit : Mob
    {
        public Bandit(Entity entity, AnimatedSprite sprite) 
            : base(entity, sprite)
        {
        }

        public override void Attack(Entity target)
        {
            if (Mechanics.RollDie(DieType.D20) >= 10 + Mechanics.GetModifier(target.Dexterity))
            {
                target.ApplyDamage(entity.MainHand);
            }
        }
    }
}
