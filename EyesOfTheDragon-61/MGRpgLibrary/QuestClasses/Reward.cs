using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.QuestClasses
{
    public class Reward
    {
        public int Experience { get; set; }
        public int Gold { get; set; }
        public List<string> Items { get; set; } = new List<string>();
    }
}
