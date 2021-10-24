using MGRpgLibrary.CharacterClasses;
using MGRpgLibrary.SpriteClasses;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XLevelEditor
{
    public partial class FormNewCharacter : Form
    {
        public static Dictionary<AnimationKey, Animation> Animations = 
            new Dictionary<AnimationKey, Animation>();
        public Character Character { get; private set; }
        public Microsoft.Xna.Framework.Point Tile { get; private set; }
        public bool OKPressed { get; private set; }
        public GraphicsDevice GraphicsDevice { get; private set; }

        public FormNewCharacter(GraphicsDevice graphicsDevice)
        {
            InitializeComponent();

            foreach (var gender in Enum.GetValues(typeof(EntityGender)))
            {
                cboGender.Items.Add(gender);
            }

            Animation animation = new Animation(3, 32, 32, 0, 0);
            Animations.Add(AnimationKey.Down, animation);

            animation = new Animation(3, 32, 32, 0, 32);
            Animations.Add(AnimationKey.Left, animation);

            animation = new Animation(3, 32, 32, 0, 64);
            Animations.Add(AnimationKey.Right, animation);

            animation = new Animation(3, 32, 32, 0, 96);
            Animations.Add(AnimationKey.Up, animation);

            GraphicsDevice = graphicsDevice;

            btnBrowse.Click += BtnBrowse_Click;
            btnCancel.Click += BtnCancel_Click;
            btnOK.Click += BtnOK_Click;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("You must enter the name of the character");
                return;
            }

            if (!int.TryParse(mtbLevel.Text, out int level))
            {
                MessageBox.Show("Level must be numeric.");
                return;
            }

            if (!int.TryParse(mtbStrength.Text, out int Strength))
            {
                MessageBox.Show("Strength must be numeric.");
                return;
            }

            if (!int.TryParse(mtbDexterity.Text, out int Dexterity))
            {
                MessageBox.Show("Dexterity must be numeric.");
                return;
            }

            if (!int.TryParse(mtbCunning.Text, out int Cunning))
            {
                MessageBox.Show("Cunning must be numeric.");
                return;
            }

            if (!int.TryParse(mtbMagic.Text, out int Magic))
            {
                MessageBox.Show("Magic must be numeric.");
                return;
            }

            if (!int.TryParse(mtbWillPower.Text, out int WillPower))
            {
                MessageBox.Show("WillPower must be numeric.");
                return;
            }

            if (!int.TryParse(mtbConstitution.Text, out int Constitution))
            {
                MessageBox.Show("Constitution must be numeric.");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbHitPoints.Text))
            {
                MessageBox.Show("Hit Point forumla cannot be empty");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbMagicPoints.Text))
            {
                MessageBox.Show("Magic Point forumla cannot be empty");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbStamina.Text))
            {
                MessageBox.Show("Stamina Point forumla cannot be empty");
                return;
            }

            if (!int.TryParse(mtbX.Text, out int X))
            {
                MessageBox.Show("X must be numeric.");
                return;
            }

            if (!int.TryParse(mtbY.Text, out int Y))
            {
                MessageBox.Show("Y must be numeric.");
                return;
            }

            EntityData entity = new EntityData(
                tbName.Text,
                level,
                Strength,
                Dexterity,
                Cunning,
                Magic,
                WillPower,
                Constitution,
                tbHitPoints.Text,
                tbMagicPoints.Text,
                tbStamina.Text);

            Texture2D texture;

            using (Stream stream = new FileStream(tbFilePath.Text, FileMode.Open, FileAccess.Read))
            {
                texture = Texture2D.FromStream(GraphicsDevice, stream);
            }

            AnimatedSprite sprite = new AnimatedSprite(
                texture,
                Animations);

            sprite.Texture.Name = tbFilePath.Text;

            Character = new NonPlayerCharacter(
                new Entity(
                    tbName.Text, 
                    entity, 
                    (EntityGender)Enum.Parse(
                        typeof(EntityGender), 
                        cboGender.SelectedItem.ToString(), 
                        true), 
                    EntityType.NPC),
                sprite);
            Tile = new Microsoft.Xna.Framework.Point(X, Y);
            OKPressed = true;

            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Character = null;
            OKPressed = false;
            Close();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Image Files (*.jpg, *.png, *.gif, *.bmp)|*.jpg;*.png;*.gif;*.bmp",
            };

            DialogResult result = ofd.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            tbFilePath.Text = ofd.FileName;
        }
    }
}
