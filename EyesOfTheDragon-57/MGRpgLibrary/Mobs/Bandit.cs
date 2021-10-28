using MGRpgLibrary.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.Mobs
{
    public class Bandit : Mob
    {
        static Texture2D swordUp;
        static Texture2D swordRight;
        static Texture2D swordDown;
        static Texture2D swordLeft;
        static Game _game;
        Rectangle sword;
        
        public Bandit(Entity entity, AnimatedSprite sprite, Game game) 
            : base(entity, sprite, game)
        {
            _minGold = 20;
            _maxGold = 50;
            _xpValue = 100;

            if (_game == null)
            {
                _game = game;
                LoadContent();
            }
        }

        private void LoadContent()
        {
            swordDown = _game.Content.Load<Texture2D>("ObjectSprites/sword-down");
            swordLeft = _game.Content.Load<Texture2D>("ObjectSprites/sword-left");
            swordRight = _game.Content.Load<Texture2D>("ObjectSprites/sword-right");
            swordUp = _game.Content.Load<Texture2D>("ObjectSprites/sword-up");
        }

        public override void Update(GameTime gameTime)
        {
            attackTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (attackTimer >= 0.25)
            {
                isAttacking = false;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (isAttacking)
            {
                switch (attackingDirection)
                {
                    case 0:
                        sword = new Rectangle(
                            (int)Sprite.Position.X + (32 - swordUp.Width) / 2,
                            (int)Sprite.Position.Y - swordUp.Height,
                            swordUp.Width,
                            swordUp.Height);
                        spriteBatch.Draw(swordUp, sword, Color.White);
                        break;
                    case 2:
                        sword = new Rectangle(
                            (int)Sprite.Position.X + (32 - swordDown.Width) / 2,
                            (int)Sprite.Position.Y + 32,
                            swordDown.Width,
                            swordDown.Height);
                        spriteBatch.Draw(swordDown, sword, Color.White);
                        break;
                    case 1:
                        sword = new Rectangle(
                            (int)Sprite.Position.X + 32,
                            (int)Sprite.Position.Y + (32 - swordRight.Height) / 2,
                            swordRight.Width,
                            swordRight.Height);
                        spriteBatch.Draw(swordRight, sword, Color.White);
                        break;
                    case 3:
                        sword = new Rectangle(
                            (int)Sprite.Position.X - swordLeft.Width,
                            (int)Sprite.Position.Y + (32 - swordLeft.Height) / 2,
                            swordLeft.Width,
                            swordLeft.Height);
                        spriteBatch.Draw(swordLeft, sword, Color.White);
                        break;
                }
            }

            base.Draw(gameTime, spriteBatch);
        }

        public override void Attack(Entity source)
        {
            if (Mechanics.RollDie(DieType.D20) >= 10 + Mechanics.GetModifier(entity.Dexterity))
            {
                entity.ApplyDamage(source.MainHand);
            }
        }

        public override void DoAttack(Entity target)
        {
            if (Mechanics.RollDie(DieType.D20) >= 10 + Mechanics.GetModifier(target.Dexterity))
            {
                target.ApplyDamage(entity.MainHand);
            }
        }

        public override void ShouldAttack(AnimatedSprite sprite)
        {
            float distance = Vector2.Distance(sprite.Center, Sprite.Center);

            if (distance < sprite.Width * 2 && attackTimer >= 1.25 && !isAttacking)
            {
                isAttacking = true;
                attackTimer = 0;

                if (Sprite.Position.X < sprite.Position.X)
                {
                    attackingDirection = 1;
                }
                else if (Sprite.Position.X > sprite.Position.X)
                {
                    attackingDirection = 3;
                }
                else if (Sprite.Position.Y < sprite.Position.Y)
                {
                    attackingDirection = 2;
                }
                else
                {
                    attackingDirection = 0;
                }

                switch (attackingDirection)
                {
                    case 0:
                        sword = new Rectangle(
                            (int)Sprite.Position.X + (32 - swordUp.Width) / 2,
                            (int)Sprite.Position.Y - swordUp.Height,
                            swordUp.Width,
                            swordUp.Height);
                        break;
                    case 2:
                        sword = new Rectangle(
                            (int)Sprite.Position.X + (32 - swordDown.Width) / 2,
                            (int)Sprite.Position.Y + 32,
                            swordDown.Width,
                            swordDown.Height);
                        break;
                    case 1:
                        sword = new Rectangle(
                            (int)Sprite.Position.X + 32,
                            (int)Sprite.Position.Y + (32 - swordRight.Height) / 2,
                            swordRight.Width,
                            swordRight.Height);
                        break;
                    case 3:
                        sword = new Rectangle(
                            (int)Sprite.Position.X - swordLeft.Width,
                            (int)Sprite.Position.Y + (32 - swordLeft.Height) / 2,
                            swordLeft.Width,
                            swordLeft.Height);
                        break;
                }
            }
        }

        public override void DoAttack(AnimatedSprite sprite, Entity entity)
        {
            if (sword.Intersects(sprite.Bounds) && isAttacking)
            {
                if (Entity.MainHand != null && Entity.MainHand.Item is Weapon)
                {
                    entity.ApplyDamage(Entity.MainHand);
                }

                isAttacking = false;
            }
        }
    }
}
