using MGRpgLibrary.ItemClasses;
using MGRpgLibrary.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary;
using RpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.Mobs
{
    public abstract class Mob
    {
        #region Constant Region

        public const int AttackRadius = 32;

        #endregion

        #region Field Region

        protected Entity entity;
        protected AnimatedSprite sprite;
        protected int _xpValue;
        protected double attackTimer;
        protected bool isAttacking;
        protected int attackingDirection;

        #endregion

        #region Property Region

        public Entity Entity
        {
            get { return entity; }
        }

        public AnimatedSprite Sprite
        {
            get { return sprite; }
        }

        public int XPValue
        {
            get { return _xpValue; }
        }

        public string Name { get; protected set; }

        #endregion

        #region Money Region

        private int _gold;

        public int Gold { get => _gold; }

        public void UpdateGold(int amount)
        {
            _gold += amount;
        }

        #endregion

        #region Item Drop Region

        protected List<GameItem> _drops = new List<GameItem>();

        public List<GameItem> Drops { get => _drops; }

        #endregion

        #region Money Drop Region

        protected int _minGold;
        protected int _maxGold;

        public int GoldDrop
        {
            get { return Mechanics.Random.Next(_minGold, _maxGold); }
        }

        #endregion

        #region Constructor Region

        public Mob(Entity entity, AnimatedSprite sprite, Game game)
        {
            this.entity = entity;
            this.sprite = sprite;
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region

        public virtual void Update(GameTime gameTime)
        {
            entity.Update(gameTime.ElapsedGameTime);
            sprite.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(gameTime, spriteBatch);

            SpriteFont font = FontManager.GetFont("testfont");

            Vector2 size = font.MeasureString(Name);
            Vector2 position = new Vector2(
                Sprite.Bounds.X + (Sprite.Bounds.Width - size.X) / 2,
                Sprite.Bounds.Y - font.LineSpacing);

            spriteBatch.DrawString(font, Name, position, Color.Red);
        }

        #endregion

        #region Abstract Method Region

        public abstract void Attack(Entity source);
        public abstract void DoAttack(Entity target);
        public abstract void ShouldAttack(AnimatedSprite sprite);
        public abstract void DoAttack(AnimatedSprite sprite, Entity entity);

        #endregion
    }
}
