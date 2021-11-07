using MGRpgLibrary.CharacterClasses;
using MGRpgLibrary.QuestClasses;
using RpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.QuestClasses
{
    public class Quest
    {
        #region Field Region

        public List<QuestStep> Steps { get; private set; } = new List<QuestStep>();
        public int CurrentStep { get; private set; }
        public string Source { get; private set; }
        public bool Finished { get; private set; }
        public Reward Reward { get; private set; }

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public Quest(string source, List<QuestStepData> steps, Reward reward)
        {
            Source = source;
            Reward = reward;

            foreach (var step in steps)
            {
                switch (step.StepType)
                {
                    case QuestStepType.Fight:
                        Steps.Add(FightQuestStep.Create(step));
                        break;
                }
            }
        }

        #endregion

        #region Method Region

        public bool Update(Character character, string target)
        {
            if (CurrentStep < Steps.Count)
            {
                Steps[CurrentStep].Update(target);

                if (Steps[CurrentStep].Finished)
                {
                    CurrentStep++;
                }
            }

            if (!Finished && CurrentStep >= Steps.Count)
            {
                Finished = true;
                character.Entity.AddExperience(Reward.Experience);
                character.UpdateGold(Reward.Gold);
            }

            return Finished;
        }

        #endregion

        #region Virtual Method region
        #endregion
    }
}
