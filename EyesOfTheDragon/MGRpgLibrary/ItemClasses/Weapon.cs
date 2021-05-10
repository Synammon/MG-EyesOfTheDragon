using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgLibrary.EffectClasses;
namespace RpgLibrary.ItemClasses
{
    public class Weapon : BaseItem
    {
        #region Field Region

        Hands hands;
        int attackValue;
        int attackModifier;
        List<DamageEffectData> damageEffectDatas;

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
        
        public List<DamageEffectData> DamageEffects
        {
            get { return damageEffectDatas; }
            protected set { damageEffectDatas = value; }
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
            List<DamageEffectData> damageEffectData,
            params string[] allowableClasses)
            : base(weaponName, weaponType, price, weight, allowableClasses)
        {
            NumberHands = hands;
            AttackValue = attackValue;
            AttackModifier = attackModifier;
            DamageEffects = damageEffectData;
        }

        public Weapon(WeaponData weaponData)
            : base(weaponData.Name, weaponData.Type, weaponData.Price, weaponData.Weight, weaponData.AllowableClasses)
        {
            NumberHands = weaponData.NumberHands;
            AttackValue = weaponData.AttackValue;
            AttackModifier = weaponData.AttackModifier;
            DamageEffects = weaponData.DamageEffectData;
        }

        #endregion

        #region Abstract Method Region

        public override object Clone()
        {
            string[] allowedClasses = new string[allowableClasses.Count];
            List<DamageEffectData> effects = new List<DamageEffectData>();
            
            for (int i = 0; i < allowableClasses.Count; i++)
            {
                allowedClasses[i] = allowableClasses[i];
            }

            foreach (DamageEffectData e in DamageEffects)
            {
                effects.Add(e);
            }

            Weapon weapon = new Weapon(
                Name,
                Type,
                Price,
                Weight,
                NumberHands,
                AttackValue,
                AttackModifier,
                effects,
                allowedClasses);

            return weapon;
        }

        public override string ToString()
        {
            string weaponString = base.ToString() + ", ";
        
            weaponString += NumberHands.ToString() + ", ";
            weaponString += AttackValue.ToString() + ", ";
            weaponString += AttackModifier.ToString();

            foreach (DamageEffectData e in DamageEffects)
            {
                weaponString += ", " + e.ToString();
            }
            
            foreach (string s in allowableClasses)
            {
                weaponString += ", " + s;
            }

            return weaponString;
        }

        #endregion
    }
}
