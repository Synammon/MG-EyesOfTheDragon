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
    public partial class FormNewAnimatedTileset : Form
    {
        public AnimatedTilesetData Tileset { get; set; }
        
        public FormNewAnimatedTileset()
        {
            InitializeComponent();
        
            btnSelectImage.Click += new EventHandler(btnSelectImage_Click);
            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }
        
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
            if (string.IsNullOrEmpty(tbTilesetImage.Text))
            {
                MessageBox.Show("You must select an image for the tileset in order to proceed.");
                return;
            }

            int tileWidth = 0;
            int tileHeight = 0;
            int frames = 0;
            int rows = 0;

            if (!int.TryParse(tbTileWidth.Text, out tileWidth))
            {
                MessageBox.Show("Tile width must be an integer value.");
                return;
            }
            else if (tileWidth < 1)
            {
                MessageBox.Show("Tile width must me greater than zero.");
                return;
            }

            if (!int.TryParse(tbTileHeight.Text, out tileHeight))
            {
                MessageBox.Show("Tile height must be an integer value.");
                return;
            }
            else if (tileHeight < 1)
            {
                MessageBox.Show("Tile height must be greater than zero.");
                return;
            }

            if (!int.TryParse(tbFrames.Text, out frames))
            {
                MessageBox.Show("Frames must be an integer value.");
                return;
            }
            else if (frames < 1)
            {
                MessageBox.Show("Frames must me greater than zero.");
                return;
            }

            if (!int.TryParse(tbRows.Text, out rows))
            {
                MessageBox.Show("Rows must be an integer value.");
                return;
            }
            else if (rows < 1)
            {
                MessageBox.Show("Rows must be greater than zero.");
                return;
            }

            Tileset = new AnimatedTilesetData
            {
                TilesetName = tbTilesetImage.Text,
                TilesetImageName = tbTilesetImage.Text,
                FramesAcross = frames,
                TilesHigh = rows,
                TileWidthInPixels = tileWidth,
                TileHeightInPixels = tileHeight
            };

            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            Tileset = null;
            this.Close();
        }
    }
}
