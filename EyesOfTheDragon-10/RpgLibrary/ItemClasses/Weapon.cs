using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Weapon : BaseItem
    {
        #region Field Region

        Hands hands;
        int attackValue;
        int attackModifier;
        int damageValue;
        int damageModifier;

        #endregion

        #region Property Region

        public Hands NumberHands
        {
            get { return hands; }
            protected set { hands = value; }
        }

        public int AttackValue
        {
            get { return attackValue; }
            protected set { attackValue = value; }
        }

        public int AttackModifier
        {
            get { return attackModifier; }
            protected set { attackModifier = value; }
        }

        public int DamageValue
        {
            get { return damageValue; }
            protected set { damageValue = value; }
        }

        public int DamageModifier
        {
            get { return damageModifier; }
            protected set { damageModifier = value; }
        }

        #endregion

        #region Constructor Region

        public Weapon(
            string weaponName,
            string weaponType,
            int price,
            float weight,
            Hands hands,
            int attackValue,
            int attackModifier,
            int damageValue,
            int damageModifier,
            params Type[] allowableClasses)
            : base(weaponName, weaponType, price, weight, allowableClasses)
        {
            NumberHands = hands;
            AttackValue = attackValue;
            AttackModifier = attackModifier;
            DamageValue = damageValue;
            DamageModifier = damageModifier;
        }

        #endregion

        #region Abstract Method Region

        public override object Clone()
        {
            Type[] allowedClasses = new Type[allowableClasses.Count];

            for (int i = 0; i < allowableClasses.Count; i++)
                allowedClasses[i] = allowableClasses[i];

            Weapon weapon = new Weapon(
                Name,
                Type,
                Price,
                Weight,
                NumberHands,
                AttackValue,
                AttackModifier,
                DamageValue,
                DamageModifier,
                allowedClasses);

            return weapon;
        }
        public override string ToString()
        {
            string weaponString = base.ToString() + ", ";

            weaponString += NumberHands.ToString() + ", ";
            weaponString += AttackValue.ToString() + ", ";
            weaponString += AttackModifier.ToString() + ", ";
            weaponString += DamageValue.ToString() + ", ";
            weaponString += DamageModifier.ToString();

            foreach (Type t in allowableClasses)
                weaponString += ", " + t.Name;

            return base.ToString();
        }

        #endregion
    }
}
