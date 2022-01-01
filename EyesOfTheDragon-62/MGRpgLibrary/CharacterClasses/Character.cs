using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgLibrary.CharacterClasses;
using MGRpgLibrary.SpriteClasses;
using MGRpgLibrary.ItemClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGRpgLibrary.CharacterClasses
{
    public class Character
    {
        #region Constant Region

        public const int SpeakingRadius = 32;
        public const int CollisionRadius = 8;

        #endregion

        #region Field Region

        protected Entity entity;
        protected AnimatedSprite sprite;

        // Armor fields
        protected GameItem head;
        protected GameItem body;
        protected GameItem hands;
        protected GameItem feet;

        // Weapon/Shield fields
        protected GameItem mainHand;
        protected GameItem offHand;
        protected int handsFree;

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

        #endregion

        #region Money Region

        private int _gold;

        public int Gold { get => _gold; }

        public void UpdateGold(int amount)
        {
            _gold += amount;
        }

        #endregion

        #region Constructor Region

        public Character(Entity entity, AnimatedSprite sprite)
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
        }

        public virtual bool Equip(GameItem gameItem)
        {
            bool success = false;
            return success;
        }

        public virtual bool Unequip(GameItem gameItem)
        {
            bool success = false;
            return success;
        }

        #endregion
    }
}
