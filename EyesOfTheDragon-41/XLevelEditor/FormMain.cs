﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GDIBitmap = System.Drawing.Bitmap;
using GDIColor = System.Drawing.Color;
using GDIImage = System.Drawing.Image;
using GDIGraphics = System.Drawing.Graphics;
using GDIGraphicsUnit = System.Drawing.GraphicsUnit;
using GDIRectangle = System.Drawing.Rectangle;
using RpgLibrary.WorldClasses;
using MGRpgLibrary.TileEngine;
using MGRpgLibrary.CharacterClasses;
using MGRpgLibrary.ItemClasses;
using RpgLibrary.CharacterClasses;
using MGRpgLibrary.SpriteClasses;

namespace XLevelEditor
{
    public partial class FormMain : Form
    {
        #region Field Region

        public static AnimatedTileset animatedSet;
        AnimatedTilesetData animatedSetData;
        public static AnimatedTileLayer animatedLayer = new AnimatedTileLayer();
        public static CollisionLayer collisionLayer = new CollisionLayer();

        LevelData levelData;
        public static TileMap map;
        public static List<Tileset> tileSets = new List<Tileset>();
        public static List<ILayer> layers = new List<ILayer>();
        public static CharacterLayer characters = new CharacterLayer();
        List<GDIImage> tileSetImages = new List<GDIImage>();
        public static Camera camera;
        Engine engine;
        Point mouse = new Point();
        bool isMouseDown = false;
        bool trackMouse = false;

        private Dictionary<AnimationKey, Animation> Animations =
            new Dictionary<AnimationKey, Animation>();

        #endregion
        #region Property Region

        public GraphicsDevice GraphicsDevice
        {
            get { return mapDisplay.GraphicsDevice; }
        }

        public static bool DrawGrid { get; set; } = true;

        public static int SelectedTileset
        {
            get; set;
        }

        public static int SelectedTile
        {
            get; set;
        }

        #endregion

        #region Constructor Region

        public static Color gridColor = Color.White;

        public FormMain()
        {
            InitializeComponent();

            Animation animation = new Animation(3, 32, 32, 0, 0);
            Animations.Add(AnimationKey.Down, animation);

            animation = new Animation(3, 32, 32, 0, 32);
            Animations.Add(AnimationKey.Left, animation);

            animation = new Animation(3, 32, 32, 0, 64);
            Animations.Add(AnimationKey.Right, animation);

            animation = new Animation(3, 32, 32, 0, 96);
            Animations.Add(AnimationKey.Up, animation);

            this.Load += new EventHandler(FormMain_Load);
            this.FormClosing += new FormClosingEventHandler(FormMain_FormClosing);

            tilesetToolStripMenuItem.Enabled = false;
            mapLayerToolStripMenuItem.Enabled = false;
            charactersToolStripMenuItem.Enabled = false;
            chestsToolStripMenuItem.Enabled = false;
            keysToolStripMenuItem.Enabled = false;
            chkPaintAnimated.Enabled = false;
            chkPaintCollision.Enabled = false;

            newLevelToolStripMenuItem.Click += new EventHandler(newLevelToolStripMenuItem_Click);
            newTilesetToolStripMenuItem.Click += new EventHandler(newTilesetToolStripMenuItem_Click);
            newLayerToolStripMenuItem.Click += new EventHandler(newLayerToolStripMenuItem_Click);
            saveLevelToolStripMenuItem.Click += new EventHandler(saveLevelToolStripMenuItem_Click);
            openLevelToolStripMenuItem.Click += new EventHandler(openLevelToolStripMenuItem_Click);
        
            x1ToolStripMenuItem.Click += new EventHandler(x1ToolStripMenuItem_Click);
            x2ToolStripMenuItem.Click += new EventHandler(x2ToolStripMenuItem_Click);
            x4ToolStripMenuItem.Click += new EventHandler(x4ToolStripMenuItem_Click);
            x8ToolStripMenuItem.Click += new EventHandler(x8ToolStripMenuItem_Click);
            
            blackToolStripMenuItem.Click += new EventHandler(blackToolStripMenuItem_Click);
            blueToolStripMenuItem.Click += new EventHandler(blueToolStripMenuItem_Click);
            redToolStripMenuItem.Click += new EventHandler(redToolStripMenuItem_Click);
            greenToolStripMenuItem.Click += new EventHandler(greenToolStripMenuItem_Click);
            yellowToolStripMenuItem.Click += new EventHandler(yellowToolStripMenuItem_Click);
            whiteToolStripMenuItem.Click += new EventHandler(whiteToolStripMenuItem_Click);
            
            saveTilesetToolStripMenuItem.Click += new EventHandler(saveTilesetToolStripMenuItem_Click);
            saveLayerToolStripMenuItem.Click += new EventHandler(saveLayerToolStripMenuItem_Click);
            
            openTilesetToolStripMenuItem.Click += new EventHandler(openTilesetToolStripMenuItem_Click);
            openLayerToolStripMenuItem.Click += new EventHandler(openLayerToolStripMenuItem_Click);
            
            animatedTIlesetToolStripMenuItem.Click += new EventHandler(animatedTIlesetToolStripMenuItem_Click);
            
            chkPaintAnimated.CheckedChanged += new EventHandler(chkPaintAnimated_CheckChanged);
            chkPaintCollision.CheckedChanged += new EventHandler(chkPaintCollision_CheckChanged);

            mapDisplay.MouseEnter += mapDisplay_MouseEnter;
            mapDisplay.MouseDown += mapDisplay_MouseDown;
            mapDisplay.MouseMove += mapDisplay_MouseMove;
            mapDisplay.MouseUp += mapDisplay_MouseUp;
            mapDisplay.MouseLeave += mapDisplay_MouseLeave;

            charactersToolStripMenuItem.Click += CharactersToolStripMenuItem_Click;
        }

        private void CharactersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewCharacter form = new FormNewCharacter(mapDisplay.GraphicsDevice);
            form.ShowDialog();

            if (!form.OKPressed)
            {
                return;
            }

            characters.Characters.Add(form.Tile, form.Character);

            form.Character.Sprite.Position = new Vector2(
                form.Tile.X * Engine.TileWidth, 
                form.Tile.Y * Engine.TileHeight);
        }

        private void animatedTIlesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewAnimatedTileset frm = new FormNewAnimatedTileset();
            
            frm.ShowDialog();
            
            if (frm.Tileset == null)
            {
                return;
            }

            animatedSetData = frm.Tileset;

            try
            {
                GDIImage image = (GDIImage)GDIBitmap.FromFile(animatedSetData.TilesetImageName);

                pbAnimatedSet.Image = image;

                Stream stream = new FileStream(animatedSetData.TilesetImageName, FileMode.Open,
                    FileAccess.Read);
    
                Texture2D texture = Texture2D.FromStream(GraphicsDevice, stream);
                animatedSet = new AnimatedTileset(
                    texture,
                    animatedSetData.FramesAcross,
                    animatedSetData.TilesHigh,
                    animatedSetData.TileWidthInPixels,
                    animatedSetData.TileHeightInPixels);

                if (map != null)
                    map.AddAnimatedTileset(animatedSet);
                sbAnimatedTile.Maximum = 0;
                chkPaintAnimated.Enabled = true;
                
                stream.Close();
                stream.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file.\n" + ex.Message, "Error reading image");
                return;
            }
        }

        void chkPaintCollision_CheckChanged(object sender, EventArgs e)
        {
            if (chkPaintCollision.Checked)
            {
                chkPaintAnimated.Checked = false;
            }
        }

        void chkPaintAnimated_CheckChanged(object sender, EventArgs e)
        {
            if (chkPaintAnimated.Checked)
            {
                chkPaintCollision.Checked = false;
            }
        }

        #region Grid Color Event Handler Region

        void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.White;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = true;
        }

        void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Yellow;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = true;
            whiteToolStripMenuItem.Checked = false;
        }

        void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Green;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = true;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }

        void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Red;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = true;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }

        void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Blue;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = true;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }

        void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Black;
            blackToolStripMenuItem.Checked = true;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }
        #endregion

        #endregion

        #region Save Menu Item Event Handler Region

        void saveLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map == null)
                return;

            List<MapLayerData> mapLayerData = new List<MapLayerData>();

            for (int i = 0; i < clbLayers.Items.Count; i++)
            {
                if (layers[i] is MapLayer)
                {
                    MapLayerData data = new MapLayerData(
                        clbLayers.Items[i].ToString(),
                        ((MapLayer)layers[i]).Width,
                        ((MapLayer)layers[i]).Height);

                    for (int y = 0; y < ((MapLayer)layers[i]).Height; y++)
                    {
                        for (int x = 0; x < ((MapLayer)layers[i]).Width; x++)
                        {
                            data.SetTile(
                                x,
                                y,
                                ((MapLayer)layers[i]).GetTile(x, y).TileIndex,
                                ((MapLayer)layers[i]).GetTile(x, y).Tileset);
                        }
                    }

                    mapLayerData.Add(data);
                }
            }

            MapData mapData = new MapData(levelData.MapName, tileSetData, animatedSetData,
                mapLayerData, collisionLayer, animatedLayer);

            CharacterLayerData charData = new CharacterLayerData();

            foreach (var c in FormMain.characters.Characters)
            {
                CharacterData character;

                if (c.Value is NonPlayerCharacter)
                {
                    character = new NonPlayerCharacterData();
                    ((NonPlayerCharacterData)character).Quests = ((NonPlayerCharacter)c.Value).Quests;
                    ((NonPlayerCharacterData)character).CurrentConversation = ((NonPlayerCharacter)c.Value).CurrentConversation;
                    ((NonPlayerCharacterData)character).CurrentQuest = ((NonPlayerCharacter)c.Value).CurrentQuest;
                }
                else
                {
                    character = new CharacterData();
                }

                character.Name = c.Value.Entity.EntityName;
                character.Gender = c.Value.Entity.Gender;
                character.TextureName = c.Value.Sprite.Texture.Name;
                character.Head = new GameItemData();
                character.Torso = new GameItemData();
                character.Feet = new GameItemData();
                character.Hands = new GameItemData();
                character.MainHand = new GameItemData();
                character.OffHand = new GameItemData();
                character.EntityData = new EntityData(
                    c.Value.Entity.EntityName,
                    c.Value.Entity.Level,
                    c.Value.Entity.Strength,
                    c.Value.Entity.Dexterity,
                    c.Value.Entity.Cunning,
                    c.Value.Entity.Willpower,
                    c.Value.Entity.Magic,
                    c.Value.Entity.Constitution,
                    c.Value.Entity.Health.MaximumValue,
                    c.Value.Entity.Stamina.MaximumValue,
                    c.Value.Entity.Mana.MaximumValue);

                charData.Characters.Add(c.Key, character);
            }

            FolderBrowserDialog fbDialog = new FolderBrowserDialog
            {
                Description = "Select Game Folder",
                SelectedPath = Application.StartupPath
            };
            
            DialogResult result = fbDialog.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                if (!File.Exists(fbDialog.SelectedPath + @"\Game.xml"))
                {
                    MessageBox.Show("Game not found", "Error");
                    return;
                }
            
                string LevelPath = Path.Combine(fbDialog.SelectedPath, @"Levels\");
                string MapPath = Path.Combine(LevelPath, @"Maps\");
                string CharPath = Path.Combine(LevelPath, @"Chars\");
                
                if (!Directory.Exists(LevelPath))
                {
                    Directory.CreateDirectory(LevelPath);
                }

                if (!Directory.Exists(MapPath))
                {
                    Directory.CreateDirectory(MapPath);
                }

                if (!Directory.Exists(CharPath))
                {
                    Directory.CreateDirectory(CharPath);
                }

                XnaSerializer.Serialize<LevelData>(
                    LevelPath + levelData.LevelName + ".xml",
                    levelData);

                XnaSerializer.Serialize<MapData>(
                    MapPath + mapData.MapName + ".xml", 
                    mapData);

                XnaSerializer.Serialize<CharacterLayerData>(
                    CharPath + levelData.LevelName + ".xml",
                    charData);
            }
        }

        void saveTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tileSetData.Count == 0)
                return;
            
            SaveFileDialog sfDialog = new SaveFileDialog
            {
                Filter = "Tileset Data (*.tdat)|*.tdat",
                CheckPathExists = true,
                OverwritePrompt = true,
                ValidateNames = true
            };

            DialogResult result = sfDialog.ShowDialog();
            
            if (result != DialogResult.OK)
                return;
        
            try
            {
                XnaSerializer.Serialize<TilesetData>(
                    sfDialog.FileName,
                    tileSetData[lbTileset.SelectedIndex]);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error saving tileset");
            }
        }

        void saveLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (layers.Count == 0)
                return;

            if (layers[clbLayers.SelectedIndex] is MapLayer)
            {
                SaveFileDialog sfDialog = new SaveFileDialog();
                sfDialog.Filter = "Map Layer Data (*.mldt)|*.mldt";
                sfDialog.CheckPathExists = true;
                sfDialog.OverwritePrompt = true;
                sfDialog.ValidateNames = true;

                DialogResult result = sfDialog.ShowDialog();

                if (result != DialogResult.OK)
                    return;

                MapLayerData data = new MapLayerData(
                    clbLayers.SelectedItem.ToString(),
                    ((MapLayer)layers[clbLayers.SelectedIndex]).Width,
                    ((MapLayer)layers[clbLayers.SelectedIndex]).Height);

                for (int y = 0; y < ((MapLayer)layers[clbLayers.SelectedIndex]).Height; y++)
                {
                    for (int x = 0; x < ((MapLayer)layers[clbLayers.SelectedIndex]).Width; x++)
                    {
                        data.SetTile(
                            x,
                            y,
                            ((MapLayer)layers[clbLayers.SelectedIndex]).GetTile(x, y).TileIndex,
                            ((MapLayer)layers[clbLayers.SelectedIndex]).GetTile(x, y).Tileset);
                    }
                }

                try
                {
                    XnaSerializer.Serialize<MapLayerData>(sfDialog.FileName, data);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error saving map layer data");
                }
            }
        }

        #endregion

        #region Open Menu Item Region

        void openLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();

            ofDialog.Filter = "Level Files (*.xml)|*.xml";
            ofDialog.CheckFileExists = true;
            ofDialog.CheckPathExists = true;

            DialogResult result = ofDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            string path = Path.GetDirectoryName(ofDialog.FileName);

            LevelData newLevel = null;
            MapData mapData = null;
            CharacterLayerData charData = null;

            try
            {
                newLevel = XnaSerializer.Deserialize<LevelData>(ofDialog.FileName);
                mapData = XnaSerializer.Deserialize<MapData>(path + @"\Maps\" + newLevel.MapName +
                    ".xml");
                charData = XnaSerializer.Deserialize<CharacterLayerData>(path + @"\Chars\" + newLevel.LevelName + ".xml");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error reading level");
                return;
            }
    
            tileSetImages.Clear();
            tileSetData.Clear();
            tileSets.Clear();
            
            layers.Clear();
            
            lbTileset.Items.Clear();
            clbLayers.Items.Clear();

            collisionLayer.Collisions.Clear();
            animatedLayer.AnimatedTiles.Clear();
            characters.Characters.Clear();

            levelData = newLevel;
            
            foreach (TilesetData data in mapData.Tilesets)
            {
                Texture2D texture = null;
            
                tileSetData.Add(data);
                lbTileset.Items.Add(data.TilesetName);
                
                GDIImage image = (GDIImage)GDIBitmap.FromFile(data.TilesetImageName);
                tileSetImages.Add(image);
                using (Stream stream = new FileStream(data.TilesetImageName, FileMode.Open,
                    FileAccess.Read))
                {
                    texture = Texture2D.FromStream(GraphicsDevice, stream);
                
                    tileSets.Add(
                        new Tileset(
                        texture,
                        data.TilesWide,
                        data.TilesHigh,
                        data.TileWidthInPixels,
                        data.TileHeightInPixels));
                }
            }

            using (Stream textureStream = new FileStream(mapData.AnimatedTileset.TilesetImageName,
                FileMode.Open, FileAccess.Read))
            {
                Texture2D aniamtedTexture = Texture2D.FromStream(GraphicsDevice, textureStream);

                animatedSet = new AnimatedTileset(
                    aniamtedTexture,
                    mapData.AnimatedTileset.FramesAcross,
                    mapData.AnimatedTileset.TilesHigh,
                    mapData.AnimatedTileset.TileWidthInPixels,
                    mapData.AnimatedTileset.TileHeightInPixels);
                animatedSetData = mapData.AnimatedTileset;
            }

            foreach (MapLayerData data in mapData.Layers)
            {
                clbLayers.Items.Add(data.MapLayerName, true);
                layers.Add(MapLayer.FromMapLayerData(data));
            }
            
            lbTileset.SelectedIndex = 0;
            clbLayers.SelectedIndex = 0;
            nudCurrentTile.Value = 0;
            sbAnimatedTile.Maximum = 0;
            
            map = new TileMap(tileSets[0], animatedSet, (MapLayer)layers[0]);
            
            for (int i = 1; i < tileSets.Count; i++)
            {
                map.AddTileset(tileSets[i]);
            }

            for (int i = 1; i < layers.Count; i++)
            {
                map.AddLayer(layers[i]);
            }

            foreach (var collision in mapData.Collisions.Collisions)
            {
                collisionLayer.Collisions.Add(collision.Key, collision.Value);
            }

            foreach (var tile in mapData.AnimatedTiles.AnimatedTiles)
            {
                animatedLayer.AnimatedTiles.Add(tile.Key, tile.Value);
            }

            foreach (var c in charData.Characters)
            {
                Character character;

                if (c.Value is NonPlayerCharacterData)
                {
                    Entity entity = new Entity(c.Value.Name, c.Value.EntityData, c.Value.Gender, EntityType.NPC);

                    using (Stream stream = new FileStream(c.Value.TextureName, FileMode.Open, FileAccess.Read))
                    {
                        Texture2D texture = Texture2D.FromStream(GraphicsDevice, stream);
                        AnimatedSprite sprite = new AnimatedSprite(texture, Animations);
                        sprite.Position = new Vector2(c.Key.X * Engine.TileWidth, c.Key.Y * Engine.TileHeight);
                        character = new NonPlayerCharacter(entity, sprite);

                        ((NonPlayerCharacter)character).SetConversation(
                            ((NonPlayerCharacterData)c.Value).CurrentConversation);

                        characters.Characters.Add(c.Key, character);
                    }
                }
            }
            tilesetToolStripMenuItem.Enabled = true;
            mapLayerToolStripMenuItem.Enabled = true;
            charactersToolStripMenuItem.Enabled = true;
            chestsToolStripMenuItem.Enabled = true;
            keysToolStripMenuItem.Enabled = true;
        }


        void openTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog
            {
                Filter = "Tileset Data (*.tdat)|*.tdat",
                CheckPathExists = true,
                CheckFileExists = true
            };

            DialogResult result = ofDialog.ShowDialog();
            
            if (result != DialogResult.OK)
                return;
            
            TilesetData data = null;
            Texture2D texture = null;
            Tileset tileset = null;
            GDIImage image = null;
            
            try
            {
                data = XnaSerializer.Deserialize<TilesetData>(ofDialog.FileName);
            
                using (Stream stream = new FileStream(data.TilesetImageName, FileMode.Open,
                    FileAccess.Read))
                {
                    texture = Texture2D.FromStream(GraphicsDevice, stream);
                    stream.Close();
                }

                image = (GDIImage)GDIBitmap.FromFile(data.TilesetImageName);

                tileset = new Tileset(
                    texture,
                    data.TilesWide,
                    data.TilesHigh,
                    data.TileWidthInPixels,
                    data.TileHeightInPixels);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error reading tileset");
                return;
            }

            for (int i = 0; i < lbTileset.Items.Count; i++)
            {
                if (lbTileset.Items[i].ToString() == data.TilesetName)
                {
                    MessageBox.Show("Level already contains a tileset with this name.", 
                        "Existing tileset");
                    return;
                }
            }

            tileSetData.Add(data);
            tileSets.Add(tileset);

            lbTileset.Items.Add(data.TilesetName);
            pbTilesetPreview.Image = image;

            tileSetImages.Add(image);
            lbTileset.SelectedIndex = lbTileset.Items.Count - 1;
            nudCurrentTile.Value = 0;
            mapLayerToolStripMenuItem.Enabled = true;
        }

        void openLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog
            {
                Filter = "Map Layer Data (*.mldt)|*.mldt",
                CheckPathExists = true,
                CheckFileExists = true
            };

            DialogResult result = ofDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            MapLayerData data = null;

            try
            {
                data = XnaSerializer.Deserialize<MapLayerData>(ofDialog.FileName);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error reading map layer");
                return;
            }

            for (int i = 0; i < clbLayers.Items.Count; i++)
            {
                if (clbLayers.Items[i].ToString() == data.MapLayerName)
                {
                    MessageBox.Show("Layer by that name already exists.", "Existing layer");
                    return;
                }
            }

            clbLayers.Items.Add(data.MapLayerName, true);
            layers.Add(MapLayer.FromMapLayerData(data));

            if (map == null)
            {
                map = new TileMap(tileSets[0], animatedSet, (MapLayer)layers[0]);

                for (int i = 1; i < tileSets.Count; i++)
                {
                    map.AddTileset(tileSets[i]);
                }
            }
        }

        #endregion

        #region Form Event Handler Region

        void FormMain_Load(object sender, EventArgs e)
        {
            lbTileset.SelectedIndexChanged += new EventHandler(lbTileset_SelectedIndexChanged);
            nudCurrentTile.ValueChanged += new EventHandler(nudCurrentTile_ValueChanged);

            Rectangle viewPort = new Rectangle(0, 0, mapDisplay.Width, mapDisplay.Height);

            camera = new Camera(viewPort);
            engine = new Engine(32, 32);

            controlTimer.Tick += new EventHandler(controlTimer_Tick);
            controlTimer.Enabled = true;
            controlTimer.Interval = 17;

            tbMapLocation.TextAlign = HorizontalAlignment.Center;

            pbTilesetPreview.MouseDown += new MouseEventHandler(pbTilesetPreview_MouseDown);
            mapDisplay.SizeChanged += new EventHandler(mapDisplay_SizeChanged);
            x1ToolStripMenuItem.Click += x1ToolStripMenuItem_Click;
            x2ToolStripMenuItem.Click += x2ToolStripMenuItem_Click;
            x4ToolStripMenuItem.Click += x4ToolStripMenuItem_Click;
            x8ToolStripMenuItem.Click += x8ToolStripMenuItem_Click;
        }

        private void DisplayGridToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            FormMain.DrawGrid = displayGridToolStripMenuItem.Checked;
        }

        void mapDisplay_SizeChanged(object sender, EventArgs e)
        {
            Rectangle viewPort = new Rectangle(0, 0, mapDisplay.Width, mapDisplay.Height);
            Vector2 cameraPosition = camera.Position;
                camera = new Camera(viewPort, cameraPosition);
    
            camera.LockCamera();
            mapDisplay.Invalidate();
        }

        void pbTilesetPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbTileset.Items.Count == 0)
                return;

            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            int index = lbTileset.SelectedIndex;

            float xScale = (float)tileSetImages[index].Width /
                pbTilesetPreview.Width;
            float yScale = (float)tileSetImages[index].Height /
                pbTilesetPreview.Height;
        
            Point previewPoint = new Point(e.X, e.Y);
            
            Point tilesetPoint = new Point(
                (int)(previewPoint.X * xScale),
                (int)(previewPoint.Y * yScale));
            
            Point tile = new Point(
                tilesetPoint.X / tileSets[index].TileWidth,
                tilesetPoint.Y / tileSets[index].TileHeight);

            nudCurrentTile.Value = tile.Y * tileSets[index].TilesWide + tile.X;
        }

        void controlTimer_Tick(object sender, EventArgs e)
        {
            frameCount = ++frameCount % 6;
            mapDisplay.Invalidate();
            Logic();
        }

        void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        void Application_Idle(object sender, EventArgs e)
        {
            mapDisplay.Invalidate();
        }

        #endregion

        #region Tile Tab Event Handler Region

        void nudCurrentTile_ValueChanged(object sender, EventArgs e)
        {
            if (lbTileset.SelectedItem != null)
            {
                FillPreviews();
            }
        }

        void lbTileset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTileset.SelectedItem != null)
            {
                nudCurrentTile.Value = 0;
                nudCurrentTile.Maximum = tileSets[lbTileset.SelectedIndex].SourceRectangles.Length - 1;

                FillPreviews();
            }
        }

        private void FillPreviews()
        {
            int selected = lbTileset.SelectedIndex;
            int tile = (int)nudCurrentTile.Value;

            FormMain.SelectedTileset = selected;
            FormMain.SelectedTile = tile;

            GDIImage preview = (GDIImage)new GDIBitmap(pbTilePreview.Width, pbTilePreview.Height);

            GDIRectangle dest = new GDIRectangle(0, 0, preview.Width, preview.Height);
            GDIRectangle source = new GDIRectangle(
                tileSets[selected].SourceRectangles[tile].X,
                tileSets[selected].SourceRectangles[tile].Y,
                tileSets[selected].SourceRectangles[tile].Width,
                tileSets[selected].SourceRectangles[tile].Height);

            GDIGraphics g = GDIGraphics.FromImage(preview);

            g.DrawImage(tileSetImages[selected], dest, source, GDIGraphicsUnit.Pixel);

            pbTilesetPreview.Image = tileSetImages[selected];
            pbTilePreview.Image = preview;
        }

        #endregion

        #region New Menu Item Event Handler Region

        void newLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewLevel frmNewLevel = new FormNewLevel())
            {
                frmNewLevel.ShowDialog();

                if (frmNewLevel.OKPressed)
                {
                    levelData = frmNewLevel.LevelData;
                    tilesetToolStripMenuItem.Enabled = true;
                }
            }

            animatedLayer = new AnimatedTileLayer();
        }

        List<TilesetData> tileSetData = new List<TilesetData>();
        private int frameCount;
        public static int brushWidth = 1;

        void newTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewTileset frmNewTileset = new FormNewTileset())
            {
                frmNewTileset.ShowDialog();
                
                if (frmNewTileset.OKPressed)
                {
                    TilesetData data = frmNewTileset.TilesetData;
                    
                    try
                    {
                        GDIImage image = (GDIImage)GDIBitmap.FromFile(data.TilesetImageName);
    
                        tileSetImages.Add(image);

                        Stream stream = new FileStream(data.TilesetImageName, FileMode.Open,
                            FileAccess.Read);

                        Texture2D texture = Texture2D.FromStream(GraphicsDevice, stream);

                        Tileset tileset = new Tileset(
                            texture,
                            data.TilesWide,
                            data.TilesHigh,
                            data.TileWidthInPixels,
                            data.TileHeightInPixels);

                        tileSets.Add(tileset);
                        tileSetData.Add(data);

                        if (map != null)
                            map.AddTileset(tileset);

                        stream.Close();
                        stream.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading file.\n" + ex.Message, "Error reading image");
                        return;
                    }

                    lbTileset.Items.Add(data.TilesetName);

                    if (lbTileset.SelectedItem == null)
                        lbTileset.SelectedIndex = 0;

                    mapLayerToolStripMenuItem.Enabled = true;
                }
            }
        }

        void newLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewLayer frmNewLayer = new FormNewLayer(levelData.MapWidth,
                levelData.MapHeight))
            {
                frmNewLayer.ShowDialog();
                
                if (frmNewLayer.OKPressed)
                {
                    MapLayerData data = frmNewLayer.MapLayerData;
    
                    if (clbLayers.Items.Contains(data.MapLayerName))
                    {
                        MessageBox.Show("Layer with name " + data.MapLayerName + " exists.",
                            "Existing layer");
                        return;
                    }

                    MapLayer layer = MapLayer.FromMapLayerData(data);

                    clbLayers.Items.Add(data.MapLayerName, true);
                    clbLayers.SelectedIndex = clbLayers.Items.Count - 1;

                    layers.Add(layer);

                    if (map == null)
                    {
                        map = new TileMap(tileSets[0], animatedSet, (MapLayer)layers[0]);

                        for (int i = 1; i < tileSets.Count; i++)
                        {
                            map.AddTileset(tileSets[1]);
                        }

                        for (int i = 1; i < layers.Count; i++)
                        {
                            map.AddLayer(layers[1]);
                        }
                    }

                    charactersToolStripMenuItem.Enabled = true;
                    chestsToolStripMenuItem.Enabled = true;
                    keysToolStripMenuItem.Enabled = true;

                    if (animatedSet != null)
                    {
                        chkPaintAnimated.Enabled = true;
                    }

                    chkPaintCollision.Enabled = true;
                }
            }
        }

        #endregion

        #region Map Display Event Handler Region

        void mapDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isMouseDown = false;
        }

        void mapDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isMouseDown = true;
        }

        void mapDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            mouse.X = e.X;
            mouse.Y = e.Y;
        }

        void mapDisplay_MouseLeave(object sender, EventArgs e)
        {
            trackMouse = false;
        }

        void mapDisplay_MouseEnter(object sender, EventArgs e)
        {
            trackMouse = true;
        }

        #endregion

        private void Logic()
        {
            if (layers.Count == 0)
                return;

            Vector2 position = camera.Position;

            if (trackMouse)
            {
                if (frameCount == 0)
                {
                    if (mouse.X < Engine.TileWidth)
                    {
                        position.X -= Engine.TileWidth;
                    }

                    if (mouse.X > mapDisplay.Width - Engine.TileWidth)
                    {
                        position.X += Engine.TileWidth;
                    }

                    if (mouse.Y < Engine.TileHeight)
                    {
                        position.Y -= Engine.TileHeight;
                    }

                    if (mouse.Y > mapDisplay.Height - Engine.TileHeight)
                    {
                        position.Y += Engine.TileHeight;
                    }

                    camera.Position = position;
                    camera.LockCamera();
                }

                position.X = mouse.X + camera.Position.X;
                position.Y = mouse.Y + camera.Position.Y;

                Point tile = Engine.VectorToCell(position);
                
                tbMapLocation.Text =
                    "( " + tile.X.ToString() + ", " + tile.Y.ToString() + " )";
                
                if (isMouseDown && !chkPaintAnimated.Checked && !chkPaintCollision.Checked)
                {
                    if (rbDraw.Checked)
                    {
                        SetTiles(tile, (int)nudCurrentTile.Value, lbTileset.SelectedIndex);
                    }

                    if (rbErase.Checked)
                    {
                        SetTiles(tile, -1, -1);
                    }
                }
                else if (isMouseDown && chkPaintAnimated.Checked)
                {
                    PaintAnimated(tile);
                }
                else if (isMouseDown && chkPaintCollision.Checked)
                {
                    CollisionType cType = CollisionType.Passable;
        
                    if (rbImpassable.Checked)
                    {
                        cType = CollisionType.Impassable;
                    }

                    PaintCollision(tile, cType);
                }
            }
        }

        private void PaintAnimated(Point tile)
        {
            if ((int)sbAnimatedTile.Value == -1 &&
                map.AnimatedTileLayer.AnimatedTiles.ContainsKey(tile))
            {
                map.AnimatedTileLayer.AnimatedTiles.Remove(tile);
                return;
            }
            
            if (map.AnimatedTileLayer.AnimatedTiles.ContainsKey(tile))
            {
                map.AnimatedTileLayer.AnimatedTiles[tile].TileIndex = (int)sbAnimatedTile.Value;
            }
            else
            {
                map.AnimatedTileLayer.AnimatedTiles.Add(tile, new
                    AnimatedTile((int)sbAnimatedTile.Value, animatedSet.FrameCount));
            }
        }
    
        private void PaintCollision(Point tile, CollisionType collisionValue)
        {
            if (collisionValue == CollisionType.Passable &&
                collisionLayer.Collisions.ContainsKey(tile))
            {
                collisionLayer.Collisions.Remove(tile);
                return;
            }

            if (collisionLayer.Collisions.ContainsKey(tile))
            {
                collisionLayer.Collisions[tile] = collisionValue;
            }
            else
            {
                collisionLayer.Collisions.Add(tile, collisionValue);
            }
        }

        private void SetTiles(Point tile, int tileIndex, int tileset)
        {
            int selected = clbLayers.SelectedIndex;
            if (layers[selected] is MapLayer)
            {
                for (int y = 0; y < brushWidth; y++)
                {
                    if (tile.Y + y >= ((MapLayer)layers[selected]).Height)
                        break;
                    for (int x = 0; x < brushWidth; x++)
                    {
                        if (tile.X + x < ((MapLayer)layers[selected]).Width)
                            ((MapLayer)layers[selected]).SetTile(
                            tile.X + x,
                            tile.Y + y,
                            tileIndex,
                            tileset);
                    }
                }
            }
        }

        #region Brush Event Handler Region

        void x1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = true;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = false;
            x8ToolStripMenuItem.Checked = false;
            brushWidth = 1;
        }

        void x2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = true;
            x4ToolStripMenuItem.Checked = false;
            x8ToolStripMenuItem.Checked = false;
            brushWidth = 2;
        }

        void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = true;
            x8ToolStripMenuItem.Checked = false;
            brushWidth = 4;
        }

        void x8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = false;
            x8ToolStripMenuItem.Checked = true;
            brushWidth = 8;
        }

        #endregion
    }
}
