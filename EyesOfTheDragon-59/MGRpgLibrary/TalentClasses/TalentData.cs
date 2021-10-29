using RpgLibrary.EffectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.TalentClasses
{
    public enum TalentType { Passive, Sustained, Activated }

    public class TalentData
    {
        #region Field Region

        public string Name;
        public string[] AllowedClasses;
        public Dictionary<string, int> AttributeRequirements;
        public string[] TalentPrerequisites;
        public int LevelRequirement;
        public TalentType TalentType;
        public int ActivationCost;
        public double CoolDown;
        public List<BaseEffect> Effects = new List<BaseEffect>();

        #endregion

        #region Property Region

        public double CastTime { get; set; }
        public double Duration { get; set; }
        public double Range { get; set; }
        public double AreaOfEffect { get; set; }
        public double AngleOfEffect { get; set; }

        #endregion

        #region Constructor Region

        public TalentData()
        {
            AttributeRequirements = new Dictionary<string, int>();
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

            foreach (string s in TalentPrerequisites)
                toString += ", " + s;

            toString += ", " + LevelRequirement.ToString();
            toString += ", " + TalentType.ToString();
            toString += ", " + ActivationCost.ToString();
            toString += ", " + CoolDown.ToString();

            foreach (BaseEffect s in Effects)
                toString += ", " + s.ToString();

            return toString;
        }

        #endregion
    }
}
