using RpgLibrary;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.ItemClasses
{
    public class Potion : BaseItem
    {
        public string Target { get; private set; }
        public int Minimum { get; private set; }
        public int Maximum { get; private set; }

        public Potion(
            string name, 
            string type,
            int price,
            float weight, 
            string target, 
            int minimum, 
            int maximum, 
            params string[] allowableClasses) 
            : base(name, type, price, weight, allowableClasses)
        {
            Target = target;
            Minimum = minimum;
            Maximum = maximum;
        }


        public Potion(PotionData potion)
            : base(potion.Name, potion.Type, potion.Price, potion.Weight, potion.AllowableClasses)
        {
            Target = potion.Target;
            Minimum = potion.Minimum;
            Maximum = potion.Maximum;
        }

        public void Apply(Entity entity)
        {
            switch (Target)
            {
                case "Health":
                    entity.Health.Heal((ushort)Mechanics.Random.Next(Minimum, Maximum));
                    break;
                case "Stamina":
                    entity.Stamina.Heal((ushort)Mechanics.Random.Next(Minimum, Maximum));
                    break;
                case "Mana":
                    entity.Mana.Heal((ushort)Mechanics.Random.Next(Minimum, Maximum));
                    break;
            }
        }

        public override object Clone()
        {
            Potion p = new Potion(Name, Type, Price, Weight, Target, Minimum, Maximum, AllowableClasses.ToArray());

            return p;
        }
    }
}
