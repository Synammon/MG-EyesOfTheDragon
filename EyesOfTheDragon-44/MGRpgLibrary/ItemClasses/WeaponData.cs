﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgLibrary.EffectClasses;
namespace RpgLibrary.ItemClasses
{
    public class WeaponData
    {
        public string Name;
        public string Type;
        public int Price;
        public float Weight;
        public bool Equipped;
        public Hands NumberHands;
        public int AttackValue;
        public int AttackModifier;
        public List<DamageEffectData> DamageEffectData = new List<DamageEffectData>();
        public string[] AllowableClasses;

        public WeaponData()
        {
        }

        public override string ToString()
        {
            string toString = Name + ", ";

            toString += Type + ", ";
            toString += Price.ToString() + ", ";
            toString += Weight.ToString() + ", ";
            toString += NumberHands.ToString() + ", ";
            toString += AttackValue.ToString() + ", ";
            toString += AttackModifier.ToString();

            foreach (DamageEffectData effect in DamageEffectData)
            {
                toString += ", " + DamageEffectData.ToString();
            }

            foreach (string s in AllowableClasses)
            {
                toString += ", " + s;
            }

            return toString;
        }
    }
}
