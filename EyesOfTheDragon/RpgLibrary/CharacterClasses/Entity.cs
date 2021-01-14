using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RpgLibrary.CharacterClasses
{
    public enum EntityGender { Male, Female, NonBinary, Unknown }
    public abstract class Entity
    {
        #region Vital Field and Property Region

        protected string entityName;
        protected string entityType;
        protected EntityGender gender;

        public string EntityName
        {
            get { return entityName; }
        }

        public string EntityType
        {
            get { return entityType; }
        }

        public EntityGender Gender
        {
            get { return gender; }
            protected set { gender = value; }
        }

        #endregion

        #region Basic Attribute and Property Region

        protected int strength;
        protected int dexterity;
        protected int cunning;
        protected int willpower;
        protected int magic;
        protected int constitution;
        protected int strengthModifier;
        protected int dexterityModifier;
        protected int cunningModifier;
        protected int willpowerModifier;
        protected int magicModifier;
        protected int constitutionModifier;

        public int Strength
        {
            get { return strength + strengthModifier; }
            protected set { strength = value; }
        }

        public int Dexterity
        {
            get { return dexterity + dexterityModifier; }
            protected set { dexterity = value; }
        }

        public int Cunning
        {
            get { return cunning + cunningModifier; }
            protected set { cunning = value; }
        }

        public int Willpower
        {
            get { return willpower + willpowerModifier; }
            protected set { willpower = value; }
        }

        public int Magic
        {
            get { return magic + magicModifier; }
            protected set { magic = value; }
        }

        public int Constitution
        {
            get { return constitution + constitutionModifier; }
            protected set { constitution = value; }
        }

        #endregion

        #region Calculated Attribute Field and Property Region

        protected AttributePair health;
        protected AttributePair stamina;
        protected AttributePair mana;

        public AttributePair Health
        {
            get { return health; }
        }

        public AttributePair Stamina
        {
            get { return stamina; }
        }

        public AttributePair Mana
        {
            get { return mana; }
        }

        protected int attack;
        protected int damage;
        protected int defense;

        #endregion

        #region Level Field and Property Region

        protected int level;
        protected long experience;

        public int Level
        {
            get { return level; }
            protected set { level = value; }
        }

        public long Experience
        {
            get { return experience; }
            protected set { experience = value; }
        }

        #endregion

        #region Constructor Region

        private Entity()
        {
            Strength = 0;
            Dexterity = 0;
            Cunning = 0;
            Willpower = 0;
            Magic = 0;
            Constitution = 0;
            health = new AttributePair(0);
            stamina = new AttributePair(0);
            mana = new AttributePair(0);
        }

        public Entity(EntityData entityData)
        {
            entityType = entityData.ClassName;
            Strength = entityData.Strength;
            Dexterity = entityData.Dexterity;
            Cunning = entityData.Cunning;
            Willpower = entityData.Willpower;
            Magic = entityData.Magic;
            Constitution = entityData.Constitution;
            health = new AttributePair(0);
            stamina = new AttributePair(0);
            mana = new AttributePair(0);
        }
        #endregion
    }
}
