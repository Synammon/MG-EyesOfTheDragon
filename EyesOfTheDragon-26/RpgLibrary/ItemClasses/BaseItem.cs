using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public enum Hands { Main, Off, Both }

    public enum ArmorLocation { Body, Head, Hands, Feet }

    public abstract class BaseItem
    {
        #region Field Region
        
        protected List<string> allowableClasses = new List<string>();
        string name;
        string type;
        int price;
        float weight;
        bool equipped;
        
        #endregion
        
        #region Property Region
        
        public List<string> AllowableClasses
        {
            get { return allowableClasses; }
            protected set { allowableClasses = value; }
        }
        
        public string Type
        {
            get { return type; }
            protected set { type = value; }
        }
        
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }
        
        public int Price
        {
            get { return price; }
            protected set { price = value; }
        }
        
        public float Weight
        {
            get { return weight; }
            protected set { weight = value; }
        }
        
        public bool IsEquiped
        {
            get { return equipped; }
            protected set { equipped = value; }
        }

        #endregion

        #region Constructor Region

        public BaseItem(
            string name, 
            string type, 
            int price, 
            float weight, 
            params string[] allowableClasses)
        {
            foreach (string t in allowableClasses)
                AllowableClasses.Add(t);

            Name = name;
            Type = type;
            Price = price;
            Weight = weight;
            IsEquiped = false;
        }

        #endregion

        #region Abstract Method Region

        public abstract object Clone();

        public virtual bool CanEquip(string characterType)
        {
            return allowableClasses.Contains(characterType);
        }

        public override string ToString()
        {
            string itemString = "";
            itemString += Name + ", ";
            itemString += Type + ", ";
            itemString += Price.ToString() + ", ";
            itemString += Weight.ToString();
            return itemString;
        }

        #endregion
    }
}
