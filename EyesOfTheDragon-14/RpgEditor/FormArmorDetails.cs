using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormArmorDetails : Form
    {
        #region Field Region

        Armor armor = null;

        #endregion

        #region Property Region

        public Armor Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        #endregion

        #region Constructor Region

        public FormArmorDetails()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormArmorDetails_Load);
            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion

        #region Event Handler Region

        void FormArmorDetails_Load(object sender, EventArgs e)
        {
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
