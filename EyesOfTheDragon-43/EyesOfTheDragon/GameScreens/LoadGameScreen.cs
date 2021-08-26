using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using MGRpgLibrary;
using MGRpgLibrary.Controls;
using MGRpgLibrary.SpriteClasses;
using MGRpgLibrary.TileEngine;
using MGRpgLibrary.WorldClasses;
using EyesOfTheDragon.Components;
using MGRpgLibrary.CharacterClasses;
using RpgLibrary.CharacterClasses;
using MGRpgLibrary.ItemClasses;
using RpgLibrary.ItemClasses;
using MGRpgLibrary.ConversationComponents;
using System.IO;

namespace EyesOfTheDragon.GameScreens
{
    public class LoadGameScreen : BaseGameState
    {
        #region Field Region
        
        PictureBox backgroundImage;
        ListBox loadListBox;
        LinkLabel loadLinkLabel;
        LinkLabel exitLinkLabel;
                
        #endregion
        
        #region Property Region
        #endregion
        
        #region Constructor Region
        public LoadGameScreen(Game game, GameStateManager manager)
        : base(game, manager)
        {
        }

        #endregion

        #region Method Region

        Texture2D containers;

        protected override void LoadContent()
        {
            base.LoadContent();

            CreateControls();

            containers = Game.Content.Load<Texture2D>(@"ObjectSprites\containers");
        }
        private void CreateControls()
        {
            base.LoadContent();

            ContentManager Content = Game.Content;
                backgroundImage = new PictureBox(
                Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                    GameRef.ScreenRectangle);
            
            ControlManager.Add(backgroundImage);
            
            loadLinkLabel = new LinkLabel();
            loadLinkLabel.Text = "Select game";
            loadLinkLabel.Position = new Vector2(50, 100);
            loadLinkLabel.Selected += new EventHandler(loadLinkLabel_Selected);
            
            ControlManager.Add(loadLinkLabel);
            
            exitLinkLabel = new LinkLabel();
            exitLinkLabel.Text = "Back";
            exitLinkLabel.Position = new Vector2(50, 100 + exitLinkLabel.SpriteFont.LineSpacing);
            exitLinkLabel.Selected += new EventHandler(exitLinkLabel_Selected);
            
            ControlManager.Add(exitLinkLabel);

            Texture2D texture = new Texture2D(GraphicsDevice, 300, 300);

            Color[] data = new Color[300 * 300];
            
            for (int i = 0; i < 300 * 300; i++)
            {
                data[i] = Color.White;
            }

            texture.SetData(data);

            loadListBox = new ListBox(
                texture,
                Content.Load<Texture2D>(@"GUI\rightarrowUp"));
         
            loadListBox.Position = new Vector2(400, 100);
            loadListBox.Selected += new EventHandler(loadListBox_Selected);
            loadListBox.Leave += new EventHandler(loadListBox_Leave);
        
            for (int i = 0; i < 20; i++)
                loadListBox.Items.Add("Game number: " + i.ToString());
            
            ControlManager.Add(loadListBox);
            ControlManager.NextControl();
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
        
        void loadListBox_Leave(object sender, EventArgs e)
        {
            ControlManager.AcceptInput = true;
        }

        void loadLinkLabel_Selected(object sender, EventArgs e)
        {
            ControlManager.AcceptInput = false;
            loadLinkLabel.HasFocus = false;
            loadListBox.HasFocus = true;
        }

        void exitLinkLabel_Selected(object sender, EventArgs e)
        {
            Transition(ChangeType.Pop, null);
        }

        void loadListBox_Selected(object sender, EventArgs e)
        {
            loadLinkLabel.HasFocus = true;
            ControlManager.AcceptInput = true;
            
            Transition(ChangeType.Change, GameRef.GamePlayScreen);
        
            CreatePlayer();
            LoadWorld();
        }

        private void CreatePlayer()
        {
            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();
            
            Animation animation = new Animation(3, 32, 32, 0, 0);
            animations.Add(AnimationKey.Down, animation);
            
            animation = new Animation(3, 32, 32, 0, 32);
            animations.Add(AnimationKey.Left, animation);
            
            animation = new Animation(3, 32, 32, 0, 64);
            animations.Add(AnimationKey.Right, animation);
            
            animation = new Animation(3, 32, 32, 0, 96);
            animations.Add(AnimationKey.Up, animation);

            AnimatedSprite sprite = new AnimatedSprite(            
                GameRef.Content.Load<Texture2D>(@"PlayerSprites\malefighter"),
                animations);
            
            Entity entity = new Entity(
                "Encelwyn",
                DataManager.EntityData["Fighter"],
                EntityGender.Male,
                EntityType.Character);
            Character character = new Character(entity, sprite);

            GamePlayScreen.Player = new Player(GameRef, character);
        }

        private void LoadWorld()
        {
            RpgLibrary.WorldClasses.LevelData levelData =
                Game.Content.Load<RpgLibrary.WorldClasses.LevelData>(@"Game\Levels\Starting Level");

            RpgLibrary.WorldClasses.MapData mapData =
                Game.Content.Load<RpgLibrary.WorldClasses.MapData>(@"Game\Levels\Maps\" + levelData.MapName);

            CharacterLayerData charData =
                Game.Content.Load<CharacterLayerData>(@"Game\Levels\Chars\Starting Level");
            CharacterLayer characterLayer = new CharacterLayer();

            TileMap map = TileMap.FromMapData(mapData, Game.Content);

            foreach (var c in charData.Characters)
            {
                Character character;

                if (c.Value is NonPlayerCharacterData)
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
                            ((NonPlayerCharacterData)c.Value).CurrentConversation);
                    }

                    characterLayer.Characters.Add(c.Key, character);
                }
            }

            map.AddLayer(characterLayer);

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
                AnimationManager.Instance.Animations);

            s.Position = new Vector2(0 * Engine.TileWidth, 5 * Engine.TileHeight);

            EntityData ed = new EntityData("Eliza", 1, 10, 10, 10, 10, 10, 10, "20|CON|12", "16|WIL|16",
                "0|0|0");

            Entity e = new Entity("Eliza", ed, EntityGender.Female, EntityType.NPC);

            NonPlayerCharacter npc = new NonPlayerCharacter(e, s);

            npc.SetConversation("eliza1");
            world.Levels[world.CurrentLevel].Characters.Add(npc);

            GamePlayScreen.World = world;

            CreateConversation();

            ((NonPlayerCharacter)world.Levels[world.CurrentLevel].Characters[0]).SetConversation("eliza1");
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
