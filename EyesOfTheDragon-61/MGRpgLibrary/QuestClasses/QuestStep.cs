using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.QuestClasses
{
    public abstract class QuestStep
    {
        #region Field Region
        #endregion

        #region Property Region

        public string Source { get; protected set; }
        public string Target { get; protected set; }
        public int Required { get; protected set; }
        public int Current { get; protected set; }
        public bool Finished { get; protected set; }
        public int Level { get; protected set; }
        public bool IsActive { get; protected set; }
        #endregion

        #region Constructor Region

        protected QuestStep()
        {
        }

        protected QuestStep(string source, string target, int required, int level)
        {
            Source = source;
            Target = target;
            Required = required;
            Finished = false;
            Level = level;
            IsActive = false;
            Current = 0;
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region

        public abstract void Update(string target);
        
        public virtual void Start()
        {
            IsActive = true;
        }

        public virtual void End()
        {
            IsActive = false;
        }

        #endregion
    }
}
