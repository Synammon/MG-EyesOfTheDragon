using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RpgLibrary.ItemClasses
{
    public class ArmorData
    {
        public string Name;
        public string Type;
        public int Price;
        public float Weight;
        public bool Equipped;
        public ArmorLocation ArmorLocation;
        public int DefenseValue;
        public int DefenseModifier;
        public string[] AllowableClasses;
    }
}
