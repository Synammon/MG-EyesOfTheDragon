using RpgLibrary.EffectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.SpellClasses
{
    public class SpellDataManager
    {
        #region Field Region

        readonly Dictionary<string, SpellData> spellData;

        #endregion

        #region Property Region

        public Dictionary<string, SpellData> SpellData
        {
            get { return spellData; }
        }

        public object EffectData { get; private set; }

        #endregion

        #region Constructor Region

        public SpellDataManager()
        {
            spellData = new Dictionary<string, SpellData>();
        }

        #endregion

        #region Method Region

        public void FillSpellData()
        {
            SpellData data = new SpellData()
            {
                Name = "Spark Jolt",
                SpellPrerequisites = new string[0],
                SpellType = SpellType.Activated,
                LevelRequirement = 1,
                ActivationCost = 8,
                AllowedClasses = new string[] { "Wizard" },
                AttributeRequirements = new Dictionary<string, int>() { { "Magic", 10 } }
            };

            BaseEffect effect = DamageEffect.FromDamageEffectData(new DamageEffectData
            {
                Name = "Spark Jolt",
                TargetType = TargetType.Enemy,
                AttackType = AttackType.Health,
                DamageType = DamageType.Air,
                DieType = DieType.D6,
                NumberOfDice = 3,
                Modifier = 2
            });

            data.Effects.Add(effect);

            spellData.Add("Spark Jolt", data);

            data = new SpellData()
            {
                Name = "Mend",
                SpellPrerequisites = new string[0],
                SpellType = SpellType.Activated,
                LevelRequirement = 1,
                ActivationCost = 6,
                AllowedClasses = new string[] { "Priest" },
                AttributeRequirements = new Dictionary<string, int>() { { "Magic", 10 } }
            };

            BaseEffect healEffect = HealEffect.FromHealEffectData(new HealEffectData
            {
                Name = "Mend",
                TargetType = TargetType.Self,
                HealType = HealType.Health,
                DieType = DieType.D8,
                NumberOfDice = 2,
                Modifier = 2
            });

            data.Effects.Add(healEffect);
            spellData.Add("Mend", data);
        }

        #endregion

        #region Virtual Method region
        #endregion
    }
}
