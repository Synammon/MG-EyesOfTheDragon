using RpgLibrary.QuestClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.CharacterClasses
{
    public class NonPlayerCharacterData : CharacterData
    {
        public List<Quest> Quests { get; set; } = new List<Quest>();
        public string CurrentConversation { get; set; }
        public string CurrentQuest { get; set; }
    }
}
