using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.ItemClasses
{
    public class PotionData
    {
        public string Name;
        public string Type;
        public string Target;
        public int Price;
        public float Weight;
        public int Minimum;
        public int Maximum;
        public string[] AllowableClasses;

        public override string ToString()
        {
            string s = Name + ", ";
            s += Type + ", ";
            s += Target + ", ";
            s += Price + ", ";
            s += Weight + " , ";
            s += Minimum + ", ";
            s += Maximum;

            return s;
        }
    }
}
