using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EyesOfTheDragon.Components;
using MGRpgLibrary;
using MGRpgLibrary.TileEngine;
using MGRpgLibrary.SpriteClasses;
using MGRpgLibrary.WorldClasses;
using MGRpgLibrary.CharacterClasses;
using MGRpgLibrary.Mobs;
using RpgLibrary;
using RpgLibrary.ItemClasses;

namespace EyesOfTheDragon.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {
        #region Field Region
        
        Engine engine = new Engine(32, 32);
        static Player player;
        static World world;

        Texture2D swordUp;
        Texture2D swordRight;
        Texture2D swordDown;
        Texture2D swordLeft;

        Rectangle playerSword;
        bool playerAttacking = false;
        double playerTimer = 0;
        int attackDirection = -1;

        #endregion
        
        #region Property Region
        
        public static World World
        {
            get { return world; }
            set { world = value; }
        }
        
        public static Player Player
        {
            get { return player; }
            set { player = value; }
        }
        
        #endregion
        
        #region Constructor Region
    
        public GamePlayScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            swordUp = GameRef.Content.Load<Texture2D>("ObjectSprites/Sword-Up");
            swordRight = GameRef.Content.Load<Texture2D>("ObjectSprites/Sword-Right");
            swordDown = GameRef.Content.Load<Texture2D>("ObjectSprites/Sword-Down");
            swordLeft = GameRef.Content.Load<Texture2D>("ObjectSprites/Sword-Left");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            world.Update(gameTime);
            player.Update(gameTime);
            player.Camera.LockToSprite(player.Sprite);
        
            if (InputHandler.KeyReleased(Keys.Space) ||
                InputHandler.ButtonReleased(Buttons.A, PlayerIndex.One))
            {
                foreach (ILayer layer in World.Levels[World.CurrentLevel].Map.Layers)
                {
                    if (layer is CharacterLayer)
                    {
                        foreach (Character c in ((CharacterLayer)layer).Characters.Values)
                        {
                            float distance = Vector2.Distance(
                                player.Sprite.Center,
                                c.Sprite.Center);

                            if (distance < Character.SpeakingRadius && c is NonPlayerCharacter)
                            {
                                NonPlayerCharacter npc = (NonPlayerCharacter)c;

                                if (npc.HasConversation)
                                {
                                    StateManager.PushState(GameRef.ConversationScreen);

                                    GameRef.ConversationScreen.SetConversation(
                                        player,
                                        npc,
                                        npc.CurrentConversation);

                                    GameRef.ConversationScreen.StartConversation();
                                }
                            }
                            else if (distance < Character.SpeakingRadius && c is Merchant)
                            {
                                StateManager.PushState(GameRef.ShopScreen);
                                GameRef.ShopScreen.SetMerchant(c as Merchant);
                            }
                        }
                    }
                }
            }

            MobLayer mobLayer = World.Levels[World.CurrentLevel].Map.Layers.Find(x => x is MobLayer) as MobLayer;

            if (playerAttacking)
            {
                foreach (var mob in mobLayer.Mobs.Values)
                {
                    if (playerSword.Intersects(mob.Sprite.Bounds))
                    {
                        if (player.Character.Entity.MainHand != null &&
                            player.Character.Entity.MainHand.Item is Weapon)
                        {
                            mob.Entity.ApplyDamage(player.Character.Entity.MainHand);
                            playerAttacking = false;

                            if (mob.Entity.Health.CurrentValue <= 0)
                            {
                                StateManager.PushState(GameRef.LootScreen);
                                GamePlayScreen.Player.Character.Entity.AddExperience(mob.XPValue);
                                GameRef.LootScreen.Gold = mob.GoldDrop;

                                foreach (var i in mob.Drops)
                                {
                                    GameRef.LootScreen.Items.Add(i);
                                }
                            }
                        }
                    }
                }
            }

            foreach (var mob in mobLayer.Mobs.Where(kv => kv.Value.Entity.Health.CurrentValue <= 0).ToList())
            {
                mobLayer.Mobs.Remove(mob.Key);
            }

            foreach (var mob in mobLayer.Mobs.Values)
            {
                float distance = Vector2.Distance(player.Sprite.Center, mob.Sprite.Center);

                if (distance < mob.Sprite.Width * 4)
                {
                    Vector2 motion = Vector2.Zero;

                    if (mob.Sprite.Position.X < player.Sprite.Position.X)
                    {
                        motion.X = 1;
                        mob.Sprite.CurrentAnimation = AnimationKey.Right;
                    }

                    if (mob.Sprite.Position.X > player.Sprite.Position.X)
                    {
                        motion.X = -1;
                        mob.Sprite.CurrentAnimation = AnimationKey.Left;
                    }

                    if (mob.Sprite.Position.Y < player.Sprite.Position.Y)
                    {
                        motion.Y = 1;
                        mob.Sprite.CurrentAnimation = AnimationKey.Down;
                    }

                    if (mob.Sprite.Position.Y > player.Sprite.Position.Y)
                    {
                        motion.Y = -1;
                        mob.Sprite.CurrentAnimation = AnimationKey.Up;
                    }

                    if (motion != Vector2.Zero)
                    {
                        motion.Normalize();
                    }

                    float speed = 200f;

                    motion *= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                    mob.Sprite.Position += motion;
                    mob.Sprite.IsAnimating = true;

                    if (mob.Sprite.Bounds.Intersects(player.Sprite.Bounds))
                    {
                        mob.Sprite.Position -= motion;
                    }
                }
                else
                {
                    mob.Sprite.IsAnimating = false;
                }
            }
            if (InputHandler.KeyReleased(Keys.I))
            {
                StateManager.PushState(GameRef.InventoryScreen);
            }

            if (InputHandler.KeyReleased(Keys.C))
            {
                StateManager.PushState(GameRef.StatsScreen);
                Visible = true;
            }

            if (Player.Character.Entity.Level < Mechanics.Experiences.Length)
            {
                if (Player.Character.Entity.Experience >= Mechanics.Experiences[Player.Character.Entity.Level])
                {
                    Player.Character.Entity.LevelUp();
                    StateManager.PushState(GameRef.LevelScreen);
                    Visible = true;
                }
            }

            if (InputHandler.CheckMousePress(MouseButton.Left) && playerTimer > 0.25 && !playerAttacking)
            {
                playerAttacking = true;
                playerTimer = 0;

                if (player.Sprite.CurrentAnimation == AnimationKey.Up)
                {
                    attackDirection = 0;
                }
                else if (player.Sprite.CurrentAnimation == AnimationKey.Right)
                {
                    attackDirection = 1;
                }
                else if (player.Sprite.CurrentAnimation == AnimationKey.Down)
                {
                    attackDirection = 2;
                }
                else
                {
                    attackDirection = 3;
                }
            }

            if (playerTimer >= 0.25)
            {
                playerAttacking = false;
            }
            playerTimer += gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                player.Camera.Transformation);

            base.Draw(gameTime);

            world.DrawLevel(gameTime, GameRef.SpriteBatch, player.Camera);

            if (playerAttacking)
            {
                switch (attackDirection)
                {
                    case 0:
                        playerSword = new Rectangle(
                            (int)player.Sprite.Position.X + (32 - swordUp.Width) / 2, 
                            (int)player.Sprite.Position.Y - swordUp.Height,
                            swordUp.Width, 
                            swordUp.Height);
                        GameRef.SpriteBatch.Draw(swordUp, playerSword, Color.White);
                        break;
                    case 2:
                        playerSword = new Rectangle(
                            (int)player.Sprite.Position.X + (32 - swordDown.Width) / 2,
                            (int)player.Sprite.Position.Y + 32,
                            swordDown.Width,
                            swordDown.Height);
                        GameRef.SpriteBatch.Draw(swordDown, playerSword, Color.White);
                        break;
                    case 1:
                        playerSword = new Rectangle(
                            (int)player.Sprite.Position.X + 32,
                            (int)player.Sprite.Position.Y + (32 - swordRight.Height) / 2,
                            swordRight.Width,
                            swordRight.Height);
                        GameRef.SpriteBatch.Draw(swordRight, playerSword, Color.White);
                        break;
                    case 3:
                        playerSword = new Rectangle(
                            (int)player.Sprite.Position.X - swordLeft.Width,
                            (int)player.Sprite.Position.Y + (32 - swordLeft.Height) / 2,
                            swordLeft.Width,
                            swordLeft.Height);
                        GameRef.SpriteBatch.Draw(swordLeft, playerSword, Color.White);
                        break;
                }
            }

            player.Draw(gameTime, GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Abstract Method Region
        #endregion
    }
}
