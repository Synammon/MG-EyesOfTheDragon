using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary
{
    public abstract class Activation
    {
        public bool InUse { get; set; }
        public double CastTime { get; set; }
        public double Duration { get; set; }
        public double Range { get; set; }
        public double AreaOfEffect { get; set; }
        public double AngleOfEffect { get; set; }
    }
}
