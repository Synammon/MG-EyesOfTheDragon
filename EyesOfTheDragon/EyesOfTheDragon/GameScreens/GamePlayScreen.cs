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
using RpgLibrary.SpellClasses;
using RpgLibrary.TalentClasses;
using RpgLibrary.EffectClasses;
using RpgLibrary.QuestClasses;
using MGRpgLibrary.QuestClasses;
using MGRpgLibrary.ItemClasses;

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

        Texture2D target;

        bool targeting;
        double castTime;

        Activation currentActivation;
        public readonly static Activation[] HotKeys = new Activation[10];

        Rectangle playerSword;
        bool playerAttacking = false;
        double playerTimer = 0;
        int attackDirection = -1;

        double _healthTimer;

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
            target = GameRef.Content.Load<Texture2D>("GUI/target");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (targeting)
            {
                List<BaseEffect> effects = currentActivation is Spell
                    ? ((Spell)currentActivation).Effects
                    : ((Talent)currentActivation).Effects;

                if (effects[0].TargetType == TargetType.Self)
                {
                    targeting = false;
                    ActivateSelfEffect(effects);
                    return;
                }

                if (InputHandler.KeyPressed(Keys.Escape))
                {
                    targeting = false;
                }

                if (InputHandler.CheckMousePress(MouseButton.Left))
                {
                    castTime = 0;

                    if (castTime >= currentActivation.CastTime)
                    {
                        MobLayer mobLayer = (MobLayer)World.CurrentMap.Layers.Find(x => x is MobLayer);
                        Vector2 mouse = InputHandler.MouseAsVector2;
                        float scale = (float)currentActivation.AreaOfEffect / target.Width;

                        Vector2 targetPosition = Player.Camera.Position + InputHandler.MouseAsVector2;

                        foreach (Mob m in mobLayer.Mobs.Values)
                        {
                            float distance = Vector2.Distance(targetPosition, m.Sprite.Center);

                            if (distance > currentActivation.AreaOfEffect / 2)
                            {
                                continue;
                            }

                            ActivateEnemyEffect(effects, m);

                            targeting = false;
                        }

                    }
                }

                return;
            }

            world.Update(gameTime);
            player.Update(gameTime);

            player.Camera.LockToSprite(player.Sprite);

            HandleHotKeyInput();

            HandleConversation();

            HandleMobs(gameTime);

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

            if (player.Character.Entity.Health.CurrentValue <= 0)
            {
                StateManager.PushState(GameRef.GameOverScreen);
            }

            if (player.Character.Entity.Health.CurrentValue < player.Character.Entity.Health.MaximumValue)
            {
                _healthTimer += gameTime.ElapsedGameTime.TotalSeconds;

                if (_healthTimer > 1)
                {
                    _healthTimer = 0;
                    player.Character.Entity.Health.Heal(2);
                    player.Character.Entity.Mana.Heal(2);
                    player.Character.Entity.Stamina.Heal(2);
                }
            }

            base.Update(gameTime);
        }

        private void ActivateEnemyEffect(List<BaseEffect> effects, Mob m)
        {
            foreach (BaseEffect e in effects)
            {
                e.Apply(m.Entity);
            }
        }

        private void ActivateSelfEffect(List<BaseEffect> effects)
        {
            foreach (BaseEffect e in effects)
            {
                e.Apply(Player.Character.Entity);
            }
        }

        private void HandleMobs(GameTime gameTime)
        {
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
                foreach (Quest q in Player.Quests)
                {
                    foreach (QuestStep s in q.Steps)
                    {
                        s.Update(mob.Value.Entity.EntityName);
                    }
                }

                mobLayer.Mobs.Remove(mob.Key);
            }

            foreach (var mob in mobLayer.Mobs.Values)
            {
                mob.DoAttack(player.Sprite, player.Character.Entity);
                mob.ShouldAttack(player.Sprite);
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
        }

        private void HandleConversation()
        {
            if (InputHandler.KeyReleased(Keys.F) ||
                InputHandler.ButtonReleased(Buttons.A, PlayerIndex.One))
            {
                foreach (ILayer layer in World.Levels[World.CurrentLevel].Map.Layers)
                {
                    if (layer is CharacterLayer layer1)
                    {
                        foreach (Character c in layer1.Characters.Values)
                        {
                            float distance = Vector2.Distance(
                                player.Sprite.Center,
                                c.Sprite.Center);

                            if (distance < Character.SpeakingRadius && c is NonPlayerCharacter character)
                            {
                                NonPlayerCharacter npc = character;

                                if (npc.Quests.Count > 0 && npc.Quests[0].Finished)
                                {
                                    Reward r = npc.Quests[0].Reward;

                                    player.Gold += r.Gold;
                                    player.Character.Entity.AddExperience(r.Experience);

                                    npc.Quests.RemoveAt(0);
                                }

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
        }

        private void HandleHotKeyInput()
        {
            if (InputHandler.KeyPressed(Keys.D1))
            {
                if (HotKeys[0] != null)
                {
                    if (HotKeys[0].Range > 0)
                    {
                        targeting = true;
                        currentActivation = HotKeys[0];
                        castTime = 0;
                    }
                }
            }

            if (InputHandler.KeyPressed(Keys.D2))
            {
                if (HotKeys[1] != null)
                {
                    if (HotKeys[1].Range > 0)
                    {
                        targeting = true;
                        currentActivation = HotKeys[1];
                        castTime = 0;
                    }
                }
            }

            if (InputHandler.KeyPressed(Keys.D3))
            {
                if (HotKeys[2] != null)
                {
                    if (HotKeys[2].Range > 0)
                    {
                        targeting = true;
                        currentActivation = HotKeys[2];
                        castTime = 0;
                    }
                }
            }

            if (InputHandler.KeyPressed(Keys.D4))
            {
                if (HotKeys[3] != null)
                {
                    if (HotKeys[3].Range > 0)
                    {
                        targeting = true;
                        currentActivation = HotKeys[3];
                        castTime = 0;
                    }
                }
            }

            if (InputHandler.KeyPressed(Keys.D5))
            {
                if (HotKeys[4] != null)
                {
                    if (HotKeys[4].Range > 0)
                    {
                        targeting = true;
                        currentActivation = HotKeys[4];
                        castTime = 0;
                    }
                }
            }

            if (InputHandler.KeyPressed(Keys.D6))
            {
                if (HotKeys[5] != null)
                {
                    if (HotKeys[5].Range > 0)
                    {
                        targeting = true;
                        currentActivation = HotKeys[5];
                        castTime = 0;
                    }
                }
            }

            if (InputHandler.KeyPressed(Keys.D7))
            {
                if (HotKeys[6] != null)
                {
                    if (HotKeys[6].Range > 0)
                    {
                        targeting = true;
                        currentActivation = HotKeys[6];
                        castTime = 0;
                    }
                }
            }

            if (InputHandler.KeyPressed(Keys.D8))
            {
                if (HotKeys[7] != null)
                {
                    if (HotKeys[7].Range > 0)
                    {
                        targeting = true;
                        currentActivation = HotKeys[7];
                        castTime = 0;
                    }
                }
            }

            if (InputHandler.KeyPressed(Keys.D9))
            {
                if (HotKeys[8] != null)
                {
                    if (HotKeys[8].Range > 0)
                    {
                        targeting = true;
                        currentActivation = HotKeys[8];
                        castTime = 0;
                    }
                }
            }

            if (InputHandler.KeyPressed(Keys.D0))
            {
                if (HotKeys[9] != null)
                {
                    if (HotKeys[9].Range > 0)
                    {
                        targeting = true;
                        currentActivation = HotKeys[9];
                        castTime = 0;
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.IsMouseVisible = !targeting;

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

            if (targeting)
            {
                Color tint = Color.White;
                float scale = (float)currentActivation.AreaOfEffect / target.Width;
                
                Vector2 targetPosition = Player.Camera.Position + InputHandler.MouseAsVector2;
                targetPosition -= new Vector2(target.Width, target.Height) * scale / 2;

                if (Vector2.Distance(Player.Sprite.Center, targetPosition) > currentActivation.Range)
                {
                    tint = Color.Black;
                }

                GameRef.SpriteBatch.Draw(
                    target, 
                    targetPosition, 
                    null,
                    tint,
                    0f,
                    new Vector2(),
                    scale,
                    SpriteEffects.None,
                    1f);
            }
            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Abstract Method Region
        #endregion
    }
}
