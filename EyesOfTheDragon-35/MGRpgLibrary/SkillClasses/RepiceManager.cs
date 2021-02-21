using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.SkillClasses
{
    public class RecipeManager
    {
        #region Field Region

        readonly Dictionary<string, Recipe> recipies;

        #endregion
        #region Property Region

        public Dictionary<string, Recipe> Recipies
        {
            get { return recipies; }
        }

        #endregion

        #region Constructor Region

        public RecipeManager()
        {
            recipies = new Dictionary<string, Recipe>();
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region
        #endregion
    }
}
