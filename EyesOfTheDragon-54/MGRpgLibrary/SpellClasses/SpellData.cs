﻿using RpgLibrary.EffectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.SpellClasses
{
    public enum SpellType { Passive, Sustained, Activated }
    public enum TargetType { Self, Enemy, Special }

    public class SpellData
    {
        #region Field Region

        public string Name;
        public string[] AllowedClasses;
        public Dictionary<string, int> AttributeRequirements;
        public string[] SpellPrerequisites;
        public int LevelRequirement;
        public SpellType SpellType;
        public int ActivationCost;
        public int CoolDown;
        public List<BaseEffect> Effects;

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public SpellData()
        {
            AttributeRequirements = new Dictionary<string, int>();
            Effects = new List<BaseEffect>();
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region

        public override string ToString()
        {
            string toString = Name;

            foreach (string s in AllowedClasses)
                toString += ", " + s;

            foreach (string s in AttributeRequirements.Keys)
                toString += ", " + s + "+" + AttributeRequirements[s].ToString();

            foreach (string s in SpellPrerequisites)
                toString += ", " + s;

            toString += ", " + LevelRequirement.ToString();
            toString += ", " + SpellType.ToString();
            toString += ", " + ActivationCost.ToString();
            toString += ", " + CoolDown.ToString();

            foreach (BaseEffect e in Effects)
                toString += ", " + e.ToString();

            return toString;
        }

        #endregion
    }
}
