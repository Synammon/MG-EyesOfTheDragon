using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RpgEditor
{
    public partial class FormWeapon : FormDetails
    {
        #region Field Region
        #endregion
        
        #region Property Region
        #endregion
        
        #region Constructor Region
        
        public FormWeapon()
        {
            InitializeComponent();
        }

        #endregion

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.ItemManager.WeaponData.Keys)
                lbDetails.Items.Add(FormDetails.ItemManager.WeaponData[s]);
        }
    }
}