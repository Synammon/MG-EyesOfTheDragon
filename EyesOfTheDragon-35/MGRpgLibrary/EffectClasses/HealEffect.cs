using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgLibrary.CharacterClasses;

namespace RpgLibrary.EffectClasses
{
    public class HealEffect : BaseEffect
    {
        #region Field Region

        HealType healType;
        DieType dieType;
        int numberOfDice;
        int modifier;

        #endregion
        #region Property Region
        #endregion

        #region Constructor Region

        private HealEffect()
        {
        }

        #endregion
        #region Method Region

        public static HealEffect FromHealEffectData(HealEffectData data)
        {
            HealEffect effect = new HealEffect
            {
                healType = data.HealType,
                dieType = data.DieType,
                numberOfDice = data.NumberOfDice,
                modifier = data.Modifier
            };

            return effect;
        }

        #endregion

        #region Virtual Method Region

        public override void Apply(Entity entity)
        {
            int amount = modifier;

            for (int i = 0; i < numberOfDice; i++)
                amount += Mechanics.RollDie(dieType);

            if (amount < 1)
                amount = 1;

            switch (healType)
            {
                case HealType.Health:
                    entity.Health.Heal((ushort)amount);
                    break;
                case HealType.Mana:
                    entity.Mana.Heal((ushort)amount);
                    break;
                case HealType.Stamina:
                    entity.Stamina.Heal((ushort)amount);
                    break;
            }
        }

        #endregion
    }
}
