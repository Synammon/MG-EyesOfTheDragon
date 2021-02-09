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
    public partial class FormNewTileset : Form
    {
        #region Field Region

        bool okPressed;
        TilesetData tilesetData;

        #endregion

        #region Property Region

        public TilesetData TilesetData
        {
            get { return tilesetData; }
        }

        public bool OKPressed
        {
            get { return okPressed; }
        }

        #endregion

        #region Constructor Region

        public FormNewTileset()
        {
            InitializeComponent();

            btnSelectImage.Click += new EventHandler(btnSelectImage_Click);
            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        #endregion

        #region Button Event Handler Region

        void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();

            ofDialog.Filter = "Image Files|*.BMP;*.GIF;*.JPG;*.TGA;*.PNG";
            ofDialog.CheckFileExists = true;
            ofDialog.CheckPathExists = true;
            ofDialog.Multiselect = false;

            DialogResult result = ofDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                tbTilesetImage.Text = ofDialog.FileName;
            }
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTilesetName.Text))
            {
                MessageBox.Show("You must enter a name for the tileset.");
                return;
            }

            if (string.IsNullOrEmpty(tbTilesetImage.Text))
            {
                MessageBox.Show("You must select an image for the tileset.");
                return;
            }

            int tileWidth = 0;
            int tileHeight = 0;
            int tilesWide = 0;
            int tilesHigh = 0;

            if (!int.TryParse(mtbTileWidth.Text, out tileWidth))
            {
                MessageBox.Show("Tile width must be an integer value.");
                return;
            }
            else if (tileWidth < 0)
            {
                MessageBox.Show("Tile width must me greater than zero.");
                return;
            }

            if (!int.TryParse(mtbTileHeight.Text, out tileHeight))
            {
                MessageBox.Show("Tile height must be an integer value.");
                return;
            }
            else if (tileHeight < 0)
            {
                MessageBox.Show("Tile height must be greater than zero.");
                return;
            }

            if (!int.TryParse(mtbTilesWide.Text, out tilesWide))
            {
                MessageBox.Show("Tiles wide must be an integer value.");
                return;
            }
            else if (tilesWide < 0)
            {
                MessageBox.Show("Tiles wide must me greater than zero.");
                return;
            }

            if (!int.TryParse(mtbTilesHigh.Text, out tilesHigh))
            {
                MessageBox.Show("Tiles high must be an integer value.");
                return;
            }
            else if (tilesHigh < 0)
            {
                MessageBox.Show("Tiles high must be greater than zero.");
                return;
            }

            tilesetData = new TilesetData();
            tilesetData.TilesetName = tbTilesetName.Text;
            tilesetData.TilesetImageName = tbTilesetImage.Text;
            tilesetData.TileWidthInPixels = tileWidth;
            tilesetData.TileHeightInPixels = tileHeight;
            tilesetData.TilesWide = tilesWide;
            tilesetData.TilesHigh = tilesHigh;

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
