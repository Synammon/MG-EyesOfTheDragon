using RpgLibrary.CharacterClasses;
using RpgLibrary.QuestClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.QuestClasses
{
    public class FightQuestStep : QuestStep
    {
        private FightQuestStep() : base()
        {
        }

        private FightQuestStep(string source, string target, int required, int level) 
            : base(source, target, required, level)
        {
        }

        public static QuestStep Create(QuestStepData data)
        {
            return new FightQuestStep(data.Source, data.Target, data.Required, data.Level);
        }

        public void Start(Entity entity)
        {
            if (entity.Level >= Level)
            {
                IsActive = true;
            }
        }
        public override void Update(string target)
        {
            if (Target.ToLower() == target.ToLower())
            {
                Current++;

                if (Current >= Required)
                {
                    Finished = true;
                }
            }
        }
    }
}
