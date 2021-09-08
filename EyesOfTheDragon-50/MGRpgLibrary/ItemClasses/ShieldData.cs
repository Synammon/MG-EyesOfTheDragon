using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ShieldData
    {
        public string Name;
        public string Type;
        public int Price;
        public float Weight;
        public bool Equipped;
        public int DefenseValue;
        public int DefenseModifier;
        public string[] AllowableClasses;

        public ShieldData()
        {
        }

        public override string ToString()
        {
            string toString = Name + ", ";

            toString += Type + ", ";
            toString += Price.ToString() + ", ";
            toString += Weight.ToString() + ", ";
            toString += DefenseValue.ToString() + ", ";
            toString += DefenseModifier.ToString();

            foreach (string s in AllowableClasses)
                toString += ", " + s;

            return toString;
        }
    }
}
