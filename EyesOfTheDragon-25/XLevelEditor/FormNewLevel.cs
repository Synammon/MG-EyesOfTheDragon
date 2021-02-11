using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.WorldClasses;

namespace XLevelEditor
{
    public partial class FormNewLevel : Form
    {
        #region Field Region

        bool okPressed;
        LevelData levelData;

        #endregion

        #region Property Region

        public bool OKPressed
        {
            get { return okPressed; }
        }

        public LevelData LevelData
        {
            get { return levelData; }
        }

        #endregion

        #region Constructor Region

        public FormNewLevel()
        {
            InitializeComponent();
 
            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);

            SetDefaultValues();
        }
 
        private void SetDefaultValues()
        {
            tbLevelName.Text = "Starting Level";
            tbMapName.Text = "Village";
            mtbWidth.Text = "100";
            mtbHeight.Text = "100";
        }

        #endregion

        #region Button Event Handler Region

        void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbLevelName.Text))
            {
                MessageBox.Show("You must enter a name for the level.", "Missing Level Name");
                return;
            }
            
            if (string.IsNullOrEmpty(tbMapName.Text))
            {
                MessageBox.Show("You must enter a name for the map of the level.", "Missing Map Name");
                return;
            }
    
            int mapWidth = 0;
            int mapHeight = 0;

            if (!int.TryParse(mtbWidth.Text, out mapWidth) || mapWidth < 1)
            {
                MessageBox.Show("The width of the map must be greater than or equal to one.",
                    "Map Size Error");
                return;
            }

            if (!int.TryParse(mtbHeight.Text, out mapHeight) || mapHeight < 1)
            {
                MessageBox.Show("The height of the map must be greater than or equal to one.",
                    "Map Size Error");
                return;
            }

            levelData = new RpgLibrary.WorldClasses.LevelData(
                tbLevelName.Text,
                tbMapName.Text,
                mapWidth,
                mapHeight,
                new List<string>(),
                new List<string>(),
                new List<string>());

            okPressed = true;
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            okPressed = false;
            this.Close();
        }

        #endregion
    }
}
