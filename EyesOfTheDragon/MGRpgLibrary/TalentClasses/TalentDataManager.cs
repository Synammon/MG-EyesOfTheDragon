using RpgLibrary.EffectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.TalentClasses
{
    public class TalentDataManager
    {
        #region Field Region

        readonly Dictionary<string, TalentData> talentData;

        #endregion

        #region Property Region

        public Dictionary<string, TalentData> TalentData
        {
            get { return talentData; }
        }

        #endregion

        #region Constructor Region

        public TalentDataManager()
        {
            talentData = new Dictionary<string, TalentData>();
        }

        #endregion

        #region Method Region

        public void FillTalents()
        {
            TalentData data = new TalentData
            {
                Name = "Bash",
                TalentPrerequisites = new string[0],
                LevelRequirement = 1,
                TalentType = TalentType.Activated,
                ActivationCost = 5,
                AllowedClasses = new string[] { "Fighter" },
                AttributeRequirements = new Dictionary<string, int>() { { "Strength", 10 } }                
            };

            DamageEffect effect = DamageEffect.FromDamageEffectData(new DamageEffectData
            {
                TargetType = SpellClasses.TargetType.Enemy,
                AttackType = AttackType.Health,
                DamageType = DamageType.Crushing,
                DieType = DieType.D8,
                Modifier = 2,
                Name = "Bash",
                NumberOfDice = 2
            });

            data.Effects.Add(effect);

            talentData.Add("Bash", data);

            data = new TalentData()
            {
                Name = "Below The Belt",
                TalentPrerequisites = new string[0],
                LevelRequirement = 1,
                TalentType = TalentType.Activated,
                ActivationCost = 5,
                AllowedClasses = new string[] { "Rogue" },
                AttributeRequirements = new Dictionary<string, int>() { { "Dexterity", 10 } }
            };

            effect = DamageEffect.FromDamageEffectData(new DamageEffectData()
            {
                TargetType = SpellClasses.TargetType.Enemy,
                AttackType = AttackType.Health,
                DamageType = DamageType.Piercing,
                DieType = DieType.D4,
                Modifier = 2,
                Name = "Below The Belt",
                NumberOfDice = 3
            });

            data.Effects.Add(effect);

            talentData.Add("Below The Belt", data);
        }

        #endregion

        #region Virtual Method region
        #endregion
    }
}
