using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MGRpgLibrary;
using MGRpgLibrary.Controls;
using MGRpgLibrary.ItemClasses;
using MGRpgLibrary.SpriteClasses;
using MGRpgLibrary.TileEngine;
using MGRpgLibrary.WorldClasses;
using RpgLibrary.ItemClasses;
using EyesOfTheDragon.Components;
using RpgLibrary.CharacterClasses;
using MGRpgLibrary.CharacterClasses;
using RpgLibrary.SkillClasses;
using MGRpgLibrary.ConversationComponents;
using System.IO;
using MGRpgLibrary.Mobs;

namespace EyesOfTheDragon.GameScreens
{
    public class CharacterGeneratorScreen : BaseGameState
    {
        #region Field Region

        LeftRightSelector nameSelector;
        LeftRightSelector genderSelector;
        LeftRightSelector classSelector;
        PictureBox backgroundImage;
        PictureBox characterImage;
        Texture2D[,] characterImages;

        readonly string[] genderItems = { "Male", "Female", "Non-Binary" };
        string[] classItems;
        readonly string[] maleName = { "Balthazar", "Logan", "Alfred", "Johnson" };
        readonly string[] femaleName = { "Lucinda", "Cynthia", "Ezmarelda", "Millicent" };
        readonly string[] nbName = { "Jaime", "Kelly", "Jordan", "Pat" };

        #endregion

        #region Property Region

        public string SelectedGender
        {
            get 
            { 
                return genderSelector.SelectedIndex < 2 ?
                    genderSelector.SelectedItem :
                    genderItems[1]; 
            }
        }

        public string SelectedClass
        {
            get { return classSelector.SelectedItem; }
        }

        #endregion

        #region Constructor Region

        public CharacterGeneratorScreen(Game game, GameStateManager stateManager)
            : base(game, stateManager)
        {
        }
        
        #endregion
        
        #region MonoGame Method Region

        public override void Initialize()
        {
            base.Initialize();
        }

        Texture2D containers;
        
        protected override void LoadContent()
        {
            base.LoadContent();

            classItems = new string[DataManager.EntityData.Count];

            int counter = 0;

            foreach (string className in DataManager.EntityData.Keys)
            {
                classItems[counter] = className;
                counter++;
            }

            LoadImages();
            CreateControls();

            containers = Game.Content.Load<Texture2D>(@"ObjectSprites\containers");
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();
        
            base.Draw(gameTime);
            
            ControlManager.Draw(GameRef.SpriteBatch);
            
            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Method Region

        private void CreateControls()
        {
            Texture2D leftTexture = Game.Content.Load<Texture2D>(@"GUI\leftarrowUp");
            Texture2D rightTexture = Game.Content.Load<Texture2D>(@"GUI\rightarrowUp");
            Texture2D stopTexture = Game.Content.Load<Texture2D>(@"GUI\StopBar");

            backgroundImage = new PictureBox(
                Game.Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                GameRef.ScreenRectangle);

            ControlManager.Add(backgroundImage);

            Label label1 = new Label
            {
                Text = "Who will search for the Eyes of the Dragon?"
            };

            label1.Size = label1.SpriteFont.MeasureString(label1.Text);
            label1.Position = new Vector2(
                (GameRef.Window.ClientBounds.Width - label1.Size.X) /2, 150);

            ControlManager.Add(label1);

            nameSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            nameSelector.SetItems(maleName, 125);
            nameSelector.Position = new Vector2(label1.Position.X, 200);

            ControlManager.Add(nameSelector);

            genderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            genderSelector.SetItems(genderItems, 125);
            genderSelector.Position = new Vector2(label1.Position.X, 250);
            genderSelector.SelectionChanged += GenderSelector_SelectionChanged;

            ControlManager.Add(genderSelector);

            classSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            classSelector.SetItems(classItems, 125);
            classSelector.Position = new Vector2(label1.Position.X, 300);
            classSelector.SelectionChanged += ClassSelector_SelectionChanged;

            ControlManager.Add(classSelector);

            LinkLabel linkLabel1 = new LinkLabel
            {
                Text = "Accept this character.",
                Position = new Vector2(label1.Position.X, 350)
            };

            linkLabel1.Selected += new EventHandler(LinkLabel1_Selected);

            ControlManager.Add(linkLabel1);

            characterImage = new PictureBox(
                characterImages[0, 0],
                new Rectangle(600, 200, 96, 96),
                new Rectangle(0, 0, 32, 32));

            ControlManager.Add(characterImage);

            ControlManager.NextControl();
        }

        private void LoadImages()
        {
            characterImages = new Texture2D[genderItems.Length, classItems.Length];
            for (int i = 0; i < genderItems.Length - 1; i++)
            {
                for (int j = 0; j < classItems.Length; j++)
                {
                    characterImages[i, j] = Game.Content.Load<Texture2D>(@"PlayerSprites\" +
                    genderItems[i] + classItems[j]);
                }
            }
        }

        private void ClassSelector_SelectionChanged(object sender, EventArgs e)
        {
            if (genderSelector.SelectedIndex != 2)
            {
                characterImage.Image = characterImages[genderSelector.SelectedIndex,
                    classSelector.SelectedIndex];
            }
            else
            {
                characterImage.Image = characterImages[1, classSelector.SelectedIndex];
            }
        }

        private void GenderSelector_SelectionChanged(object sender, EventArgs e)
        {
            if (genderSelector.SelectedIndex == 0)
                nameSelector.SetItems(maleName, 125);
            else if (genderSelector.SelectedIndex == 1)
                nameSelector.SetItems(femaleName, 125);
            else
                nameSelector.SetItems(nbName, 125);

            ClassSelector_SelectionChanged(this, null);
        }

        void LinkLabel1_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();

            CreatePlayer();
            LoadWorld();

            GameRef.SkillScreen.SkillPoints = 10;

            Transition(ChangeType.Change, GameRef.SkillScreen);
            
            GameRef.SkillScreen.SetTarget(GamePlayScreen.Player.Character);
        }

        private void LoadWorld()
        {
            RpgLibrary.WorldClasses.LevelData levelData = 
                Game.Content.Load<RpgLibrary.WorldClasses.LevelData>(@"Game\Levels\Starting Level");

            RpgLibrary.WorldClasses.MapData mapData = 
                Game.Content.Load<RpgLibrary.WorldClasses.MapData>(@"Game\Levels\Maps\" + levelData.MapName);


            string[] fileNames = Directory.GetFiles(
                Path.Combine("Content/Game/Items", "Armor"),
                "*.xnb");

            foreach (string a in fileNames)
            {
                string path = "Game/Items/Armor/" + Path.GetFileNameWithoutExtension(a);

                ArmorData armorData = Game.Content.Load<ArmorData>(path);
                ItemManager.AddArmor(new Armor(armorData));
            }

            fileNames = Directory.GetFiles(
                Path.Combine("Content/Game/Items", "Shield"),
                "*.xnb");

            foreach (string a in fileNames)
            {
                string path = "Game/Items/Shield/" + Path.GetFileNameWithoutExtension(a);

                ShieldData shieldData = Game.Content.Load<ShieldData>(path);
                ItemManager.AddShield(new Shield(shieldData));
            }

            fileNames = Directory.GetFiles(
                Path.Combine("Content/Game/Items", "Weapon"),
                "*.xnb");

            foreach (string a in fileNames)
            {
                string path = "Game/Items/Weapon/" + Path.GetFileNameWithoutExtension(a);

                WeaponData weaponData = Game.Content.Load<WeaponData>(path);
                ItemManager.AddWeapon(new Weapon(weaponData));
            }

            CharacterLayerData charData =
                Game.Content.Load<CharacterLayerData>(@"Game\Levels\Chars\Starting Level");
            CharacterLayer characterLayer = new CharacterLayer();
            MobLayer mobLayer = new MobLayer();

            TileMap map = TileMap.FromMapData(mapData, Game.Content);

            foreach (var c in charData.Characters)
            {
                Character character;

                if (c.Value is NonPlayerCharacterData data)
                {
                    Entity entity = new Entity(c.Value.Name, c.Value.EntityData, c.Value.Gender, EntityType.NPC);

                    using (Stream stream = new FileStream(c.Value.TextureName, FileMode.Open, FileAccess.Read))
                    {
                        Texture2D texture = Texture2D.FromStream(GraphicsDevice, stream);
                        AnimatedSprite sprite = new AnimatedSprite(texture, AnimationManager.Instance.Animations)
                        {
                            Position = new Vector2(c.Key.X * Engine.TileWidth, c.Key.Y * Engine.TileHeight)
                        };
                    
                        character = new NonPlayerCharacter(entity, sprite);

                        ((NonPlayerCharacter)character).SetConversation(
                            data.CurrentConversation);
                    }

                    characterLayer.Characters.Add(c.Key, character);
                }
            }

            map.AddLayer(characterLayer);
            map.AddLayer(mobLayer);

            Level level = new Level(map);

            ChestData chestData = Game.Content.Load<ChestData>(@"Game\Chests\Plain Chest");

            Chest chest = new Chest(chestData);

            BaseSprite chestSprite = new BaseSprite(
                containers,
                new Rectangle(0, 0, 32, 32),
                new Point(10, 10));

            ItemSprite itemSprite = new ItemSprite(
                chest,
                chestSprite);

            level.Chests.Add(itemSprite);

            World world = new World(GameRef, GameRef.ScreenRectangle);

            world.Levels.Add(level);
            world.CurrentLevel = 0;

            AnimatedSprite s = new AnimatedSprite(
                GameRef.Content.Load<Texture2D>(@"SpriteSheets\Eliza"),
                AnimationManager.Instance.Animations)
            {
                Position = new Vector2(0 * Engine.TileWidth, 5 * Engine.TileHeight)
            };

            EntityData ed = new EntityData("Eliza", 1, 10, 10, 10, 10, 10, 10, "20|CON|12", "16|WIL|16",
                "0|0|0");

            Entity e = new Entity("Eliza", ed, EntityGender.Female, EntityType.NPC);

            NonPlayerCharacter npc = new NonPlayerCharacter(e, s);

            npc.SetConversation("eliza1");
            //world.Levels[world.CurrentLevel].Characters.Add(npc);

            s = new AnimatedSprite(
                GameRef.Content.Load<Texture2D>(@"SpriteSheets\Eliza"),
                AnimationManager.Instance.Animations)
            {
                Position = new Vector2(10 * Engine.TileWidth, 0)
            };

            ed = new EntityData("Barbra", 2, 10, 10, 10, 10, 10, 10, "20|CON|12", "16|WIL|16", "0|0|0");

            e = new Entity("Barbra", ed, EntityGender.Female, EntityType.Merchant);

            Merchant m = new Merchant(e, s);
            Texture2D items = Game.Content.Load<Texture2D>("ObjectSprites/roguelikeitems");
            m.Backpack.AddItem(new GameItem(ItemManager.GetWeapon("Long Sword"), "FullSheet", new Rectangle(1696, 1408, 32, 32)));
            m.Backpack.AddItem(new GameItem(ItemManager.GetWeapon("Short Sword"), "FullSheet", new Rectangle(800, 1504, 32, 32)));
            m.Backpack.AddItem(new GameItem(ItemManager.GetWeapon("Apprentice Staff"), "FullSheet", new Rectangle(224, 1408, 32, 32)));
            m.Backpack.AddItem(new GameItem(ItemManager.GetWeapon("Acolyte Staff"), "FullSheet", new Rectangle(256, 1408, 32, 32)));
            m.Backpack.AddItem(new GameItem(ItemManager.GetArmor("Leather Armor"), "FullSheet", new Rectangle(1248, 1216, 32, 32)));
            m.Backpack.AddItem(new GameItem(ItemManager.GetArmor("Chain Mail"), "FullSheet", new Rectangle(1472, 1184, 32, 32)));
            m.Backpack.AddItem(new GameItem(ItemManager.GetArmor("Studded Leather Armor"), "FullSheet", new Rectangle(1984, 1120, 32, 32)));
            m.Backpack.AddItem(new GameItem(ItemManager.GetArmor("Light Robes"), "FullSheet", new Rectangle(992, 1216, 32, 32)));
            m.Backpack.AddItem(new GameItem(ItemManager.GetArmor("Medium Robes"), "FullSheet", new Rectangle(1024, 1216, 32, 32)));
            world.Levels[world.CurrentLevel].Characters.Add(m);
            ((CharacterLayer)world.Levels[world.CurrentLevel].Map.Layers.Find(x => x is CharacterLayer)).Characters.Add(new Point(10, 0), m);
            GamePlayScreen.World = world;

            ed = new EntityData("Bandit", 1, 10, 12, 12, 10, 10, 10, "20|CON|10", "12|WIL|12", "0|0|0");

            e = new Entity("Bandit", ed, EntityGender.Male, EntityType.Monster);

            s = new AnimatedSprite(
                GameRef.Content.Load<Texture2D>(@"PlayerSprites/malerogue"),
                AnimationManager.Instance.Animations);

            Mob mob = new Bandit(e, s);
            ((MobLayer)world.Levels[world.CurrentLevel].Map.Layers.Find(x => x is MobLayer)).Mobs.Add(new Rectangle(0, 512, 32, 32), mob);
            mob.Entity.Equip(new GameItem(ItemManager.GetWeapon("Short Sword"), "FullSheet", new Rectangle(800, 1504, 32, 32)));

            // ((NonPlayerCharacter)world.Levels[world.CurrentLevel].Characters[0]).SetConversation("eliza1");
        }

        private void CreatePlayer()
        {
            int gender = genderSelector.SelectedIndex < 2 ? genderSelector.SelectedIndex : 1;

            AnimatedSprite sprite = new AnimatedSprite(
                characterImages[gender, classSelector.SelectedIndex],
                AnimationManager.Instance.Animations);
            EntityGender g = EntityGender.Unknown;

            switch (genderSelector.SelectedIndex)
            {
                case 0:
                    g = EntityGender.Male;
                    break;
                case 1:
                    g = EntityGender.Female;
                    break;
                case 2:
                    g = EntityGender.NonBinary;
                    break;
            }

            Entity entity = new Entity(
                nameSelector.SelectedItem,
                DataManager.EntityData[classSelector.SelectedItem],
                g,
                EntityType.Character);

            foreach (string s in DataManager.SkillData.Keys)
            {
                Skill skill = Skill.FromSkillData(DataManager.SkillData[s]);
                entity.Skills.Add(s, skill);
            }

            Character character = new Character(entity, sprite);
            GamePlayScreen.Player = new Player(GameRef, character)
            {
                Gold = 200
            };
        }

        private void CreateWorld()
        {
            Texture2D tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset1");
            Tileset tileset1 = new Tileset(tilesetTexture, 8, 8, 32, 32);

            tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset2");

            Tileset tileset2 = new Tileset(tilesetTexture, 8, 8, 32, 32);

            tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\fire-tiles");
            TextureManager.AddTexture("FullSheet", Game.Content.Load<Texture2D>(@"GUI\ProjectUtumno_full"));
            TextureManager.AddTexture("SuppSheet", Game.Content.Load<Texture2D>(@"GUI\ProjectUtumno_supplemental"));
            AnimatedTileset animatedSet = new AnimatedTileset(tilesetTexture, 8, 1, 64, 64);
            MapLayer layer = new MapLayer(100, 100);

            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    Tile tile = new Tile(0, 0);
                    layer.SetTile(x, y, tile);
                }
            }

            MapLayer splatter = new MapLayer(100, 100);
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(0, 100);
                int y = random.Next(0, 100);
                int index = random.Next(2, 14);

                Tile tile = new Tile(index, 0);

                splatter.SetTile(x, y, tile);
            }

            splatter.SetTile(5, 0, new Tile(14, 0));
            splatter.SetTile(1, 0, new Tile(0, 1));
            splatter.SetTile(2, 0, new Tile(2, 1));
            splatter.SetTile(3, 0, new Tile(0, 1));

            TileMap map = new TileMap(tileset1, animatedSet, layer);

            map.AddTileset(tileset2);
            map.AddLayer(splatter);
            map.CollisionLayer.Collisions.Add(new Point(1, 0), CollisionType.Impassable);
            map.CollisionLayer.Collisions.Add(new Point(3, 0), CollisionType.Impassable);
            map.AnimatedTileLayer.AnimatedTiles.Add(new Point(5, 0), new AnimatedTile(0, 8));
        }

        private void CreateConversation()
        {
            Conversation c = new Conversation("eliza1", "welcome");
            GameScene scene = new GameScene(
            GameRef,
            "basic_scene",
            "The unthinkable has happened. A thief has stolen the eyes of the village guardian." +
            " With out his eyes the dragon will not animated if the village is attacked.",
            new List<SceneOption>());

            SceneAction action = new SceneAction
            {
                Action = ActionType.Talk,
                Parameter = "none"
            };

            SceneOption option = new SceneOption("Continue", "welcome2", action);
            scene.Options.Add(option);
            c.AddScene("welcome", scene);
            
            scene = new GameScene(
                GameRef,
                "basic_scene",
                "Will you retrieve the eyes of the dragon for us?",
                new List<SceneOption>());
            
            action = new SceneAction
            {
                Action = ActionType.Change,
                Parameter = "none"
            };
            
            option = new SceneOption("Yes", "eliza2", action);
            scene.Options.Add(option);
            
            action = new SceneAction
            {
                Action = ActionType.Talk,
                Parameter = "none"
            };
            
            option = new SceneOption("No", "pleasehelp", action);
            scene.Options.Add(option);
            
            c.AddScene("welcome2", scene);

            scene = new GameScene(
                GameRef,
                "basic_scene",
                "Please, you are the only one that can help us. If you change your mind " +
                "come back and see me.",
                new List<SceneOption>());

            action = new SceneAction
            {
                Action = ActionType.End,
                Parameter = "none"
            };

            option = new SceneOption("Bye", "welcome2", action);
            scene.Options.Add(option);
            
            c.AddScene("pleasehelp", scene);
            
            ConversationManager.Instance.AddConversation("eliza1", c);
            
            c = new Conversation("eliza2", "thankyou");
            
            scene = new GameScene(
                GameRef,
                "basic_scene",
                "Thank you for agreeing to help us! Please find Faulke in the inn and ask " +
                "him what he knows about this thief.",
                new List<SceneOption>());
            
            action = new SceneAction
            {
                Action = ActionType.Quest,
                Parameter = "Faulke"
            };

            option = new SceneOption("Continue", "thankyou2", action);
            scene.Options.Add(option);
            
            c.AddScene("thankyou", scene);
            
            scene = new GameScene(
                GameRef,
                "basic_scene",
                "Return to me once you've spoken with Faulke.",
                new List<SceneOption>());
            action = new SceneAction
            {
                Action = ActionType.End,
                Parameter = "none"
            };

            option = new SceneOption("Good Bye", "thankyou2", action);
            scene.Options.Add(option);

            c.AddScene("thankyou2", scene);

            ConversationManager.Instance.AddConversation("eliza2", c);
        }
        #endregion
    }
}
