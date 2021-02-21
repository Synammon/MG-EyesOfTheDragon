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

            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            tbTilesetName.Text = "Village Tileset";
            mtbTileWidth.Text = "32";
            mtbTileHeight.Text = "32";
        }

        #endregion

        #region Button Event Handler Region

        void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.BMP;*.GIF;*.JPG;*.TGA;*.PNG",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false
            };

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
            else if (tileWidth < 1)
            {
                MessageBox.Show("Tile width must me greater than zero.");
                return;
            }

            if (!int.TryParse(mtbTileHeight.Text, out tileHeight))
            {
                MessageBox.Show("Tile height must be an integer value.");
                return;
            }
            else if (tileHeight < 1)
            {
                MessageBox.Show("Tile height must be greater than zero.");
                return;
            }

            Image tileSet = (Image)Bitmap.FromFile(tbTilesetImage.Text);

            tilesWide = tileSet.Width / tileWidth;
            tilesHigh = tileSet.Height / tileHeight;

            tilesetData = new TilesetData
            {
                TilesetName = tbTilesetName.Text,
                TilesetImageName = tbTilesetImage.Text,
                TileWidthInPixels = tileWidth,
                TileHeightInPixels = tileHeight,
                TilesWide = tilesWide,
                TilesHigh = tilesHigh
            };

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
