using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary
{
    public class RolePlayingGame
    {
        #region Field Region
        
        string name;
        string description;
        
        #endregion
        
        #region Property Region
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        
        #endregion
        
        #region Constructor Region

        private RolePlayingGame()
        {
        }

        public RolePlayingGame(string name, string description)
        {
            Name = name;
            Description = description;
        }

        #endregion
    }
}
