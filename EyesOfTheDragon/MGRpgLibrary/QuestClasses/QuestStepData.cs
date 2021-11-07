using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.QuestClasses
{
    public enum QuestStepType { Talk, Buy, Sell, Deliver, Find, Fight }

    public class QuestStepData
    {
        public QuestStepType StepType { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public int Required { get; set; }
        public int Level { get; set; }
    }
}
