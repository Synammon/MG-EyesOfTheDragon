using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpgEditor
{
    public partial class FormArmor : FormDetails
    {
        public FormArmor()
        {
            InitializeComponent();
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.ItemManager.ArmorData.Keys)
                lbDetails.Items.Add(FormDetails.ItemManager.ArmorData[s]);
        }
    }
}
