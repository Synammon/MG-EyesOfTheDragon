using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgLibrary.CharacterClasses;
namespace RpgLibrary.EffectClasses
{
    public abstract class BaseEffect
    {
        #region Field Region

        protected string name;

        #endregion

        #region Property Region

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        #endregion

        #region Constructor Region
        protected BaseEffect()
        {
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method Region

        public abstract void Apply(Entity entity);

        #endregion
    }
}
