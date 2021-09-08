using MGRpgLibrary.ItemClasses;
using RpgLibrary.EffectClasses;
using RpgLibrary.ItemClasses;
using RpgLibrary.SkillClasses;
using RpgLibrary.SpellClasses;
using RpgLibrary.TalentClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public enum EntityGender { Male, Female, NonBinary, Unknown }
    public enum EntityType { Character, NPC, Monster, Creature, Merchant }

    public class Entity
    {
        #region Vital Field and Property Region

        private string entityName;
        private string entityClass;
        private EntityType entityType;
        private EntityGender gender;

        public string EntityName
        {
            get { return entityName; }
            private set { entityName = value; }
        }

        public string EntityClass
        {
            get { return entityClass; }
            private set { entityClass = value; }
        }

        public EntityType EntityType
        {
            get { return entityType; }
            private set { entityType = value; }
        }

        public EntityGender Gender
        {
            get { return gender; }
            private set { gender = value; }
        }

        #endregion

        #region Resistance and Weakness Field and Property Region

        private readonly List<Resistance> resistances;

        public List<Resistance> Resistances
        {
            get { return resistances; }
        }

        private readonly List<Weakness> weaknesses;

        public List<Weakness> Weaknesses
        {
            get { return weaknesses; }
        }

        #endregion


    #region Basic Attribute and Property Region

        private int strength;
        private int dexterity;
        private int cunning;
        private int willpower;
        private int magic;
        private int constitution;
        private int strengthModifier;
        private int dexterityModifier;
        private int cunningModifier;
        private int willpowerModifier;
        private int magicModifier;
        private int constitutionModifier;

        public int Strength
        {
            get { return strength + strengthModifier; }
            private set { strength = value; }
        }

        public int Dexterity
        {
            get { return dexterity + dexterityModifier; }
            private set { dexterity = value; }
        }

        public int Cunning
        {
            get { return cunning + cunningModifier; }
            private set { cunning = value; }
        }

        public int Willpower
        {
            get { return willpower + willpowerModifier; }
            private set { willpower = value; }
        }

        public int Magic
        {
            get { return magic + magicModifier; }
            private set { magic = value; }
        }

        public int Constitution
        {
            get { return constitution + constitutionModifier; }
            private set { constitution = value; }
        }

        #endregion

        #region Calculated Attribute Field and Property Region

        private AttributePair health;
        private AttributePair stamina;
        private AttributePair mana;

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

        private int attack;
        private int damage;
        private int defense;

        #endregion

        #region Level Field and Property Region

        private int level;
        private long experience;

        public int Level
        {
            get { return level; }
            private set { level = value; }
        }

        public long Experience
        {
            get { return experience; }
            private set { experience = value; }
        }

        #endregion

        #region Skill Field and Property Region

        readonly Dictionary<string, Skill> skills;
        readonly List<Modifier> skillModifiers;

        public Dictionary<string, Skill> Skills
        {
            get { return skills; }
        }

        public List<Modifier> SkillModifiers
        {
            get { return skillModifiers; }
        }

        #endregion

        #region Spell Field and Property Region

        readonly Dictionary<string, Spell> spells;
        readonly List<Modifier> spellModifiers;

        public Dictionary<string, Spell> Spells
        {
            get { return spells; }
        }

        public List<Modifier> SpellModifiers
        {
            get { return spellModifiers; }
        }

        #endregion

        #region Talent Field and Property Region

        readonly Dictionary<string, Talent> talents;
        readonly List<Modifier> talentModifiers;

        public Dictionary<string, Talent> Talents
        {
            get { return talents; }
        }

        public List<Modifier> TalentModifiers
        {
            get { return talentModifiers; }
        }

        public string HealthCalculation { get; set; }
        public string StaminaCalculation { get; set; }
        public string ManaCalculation { get; set; }

        #endregion

        #region Item Region

        // Armor fields
        protected GameItem head;
        protected GameItem body;
        protected GameItem hands;
        protected GameItem feet;

        // Weapon/Shield fields
        protected GameItem mainHand;
        protected GameItem offHand;
        protected int handsFree;


        // Armor properties
        public GameItem Head
        {
            get { return head; }
        }

        public GameItem Body
        {
            get { return body; }
        }

        public GameItem Hands
        {
            get { return hands; }
        }

        public GameItem Feet
        {
            get { return feet; }
        }

        // Weapon/Shield properties

        public GameItem MainHand
        {
            get { return mainHand; }
        }

        public GameItem OffHand
        {
            get { return offHand; }
        }

        public int HandsFree
        {
            get { return handsFree; }
        }

        #endregion
        #region Constructor Region

        private Entity()
        {
            Strength = 10;
            Dexterity = 10;
            Cunning = 10;
            Willpower = 10;
            Magic = 10;
            Constitution = 10;

            health = new AttributePair(0);
            stamina = new AttributePair(0);
            mana = new AttributePair(0);

            skills = new Dictionary<string, Skill>();
            spells = new Dictionary<string, Spell>();
            talents = new Dictionary<string, Talent>();

            skillModifiers = new List<Modifier>();
            spellModifiers = new List<Modifier>();
            talentModifiers = new List<Modifier>();
            resistances = new List<Resistance>();
            weaknesses = new List<Weakness>();
        }

        public Entity(
            string name,
            EntityData entityData,
            EntityGender gender,
            EntityType entityType) : this()
        {
            EntityName = name;
            Level = entityData.Level;
            EntityClass = entityData.EntityName;
            Gender = gender;
            EntityType = entityType;
            Strength = entityData.Strength;
            Dexterity = entityData.Dexterity;
            Cunning = entityData.Cunning;
            Willpower = entityData.Willpower;
            Magic = entityData.Magic;
            Constitution = entityData.Constitution;

            if (!string.IsNullOrEmpty(entityData.HealthFormula))
            {
                health = new AttributePair(CalculateAttribute(entityData.HealthFormula));
            }
            else
            {
                health = new AttributePair(entityData.MaximumHealth);
            }

            if (!string.IsNullOrEmpty(entityData.StaminaFormula))
            {
                stamina = new AttributePair(CalculateAttribute(entityData.StaminaFormula));
            }
            else
            {
                stamina = new AttributePair(entityData.MaximumStamina);
            }

            if (!string.IsNullOrEmpty(entityData.MagicFormula))
            {
                mana = new AttributePair(CalculateAttribute(entityData.MagicFormula));
            }
            else
            {
                mana = new AttributePair(entityData.MaximumMana);
            }
        }

        public int CalculateAttribute(string formula)
        {
            int value = 0;

            string[] parts = formula.Split('|');

            value = int.Parse(parts[0]);

            for (int i = 1; i < level; i++)
            {
                value += int.Parse(parts[2]);
            }

            return value;
        }

        #endregion

        #region Method Region

        public void Update(TimeSpan elapsedTime)
        {
            foreach (Modifier modifier in skillModifiers)
                modifier.Update(elapsedTime);

            foreach (Modifier modifier in spellModifiers)
                modifier.Update(elapsedTime);

            foreach (Modifier modifier in talentModifiers)
                modifier.Update(elapsedTime);
        }

        public void Equip(GameItem item)
        {
            if (!item.Item.AllowableClasses.Contains(EntityClass) && EntityType != EntityType.Monster)
            {
                return;
            }

            if (item.Item is Weapon weapon)
            {
                if (mainHand == null)
                {
                    mainHand = item;
                    item.Item.IsEquiped = true;
                }
                else
                {
                    if (mainHand != item)
                    {
                        mainHand.Item.IsEquiped = false;
                        mainHand = item;
                        mainHand.Item.IsEquiped = true;
                    }
                    else
                    {
                        mainHand = null;
                        item.Item.IsEquiped = false;
                    }
                }

                if (weapon.NumberHands == ItemClasses.Hands.Both && offHand != null)
                {
                    offHand.Item.IsEquiped = false;
                    offHand = null;
                }
            }

            if (item.Item is Shield shield)
            {
                if (offHand != null)
                {
                    offHand.Item.IsEquiped = false;
                }

                offHand = item;
                offHand.Item.IsEquiped = true;
            }

            if (item.Item is Armor armor)
            {
                if (armor.Location == ArmorLocation.Body)
                {
                    if (body != null)
                    {
                        body.Item.IsEquiped = false;
                    }

                    body = item;
                    body.Item.IsEquiped = true;
                }

                if (armor.Location == ArmorLocation.Head)
                {
                    if (head != null)
                    {
                        head.Item.IsEquiped = false;
                    }

                    head = item;
                    head.Item.IsEquiped = true;
                }

                if (armor.Location == ArmorLocation.Hands)
                {
                    if (hands != null)
                    {
                        hands.Item.IsEquiped = false;
                    }

                    hands = item;
                    hands.Item.IsEquiped = true;
                }

                if (armor.Location == ArmorLocation.Head)
                {
                    if (feet != null)
                    {
                        feet.Item.IsEquiped = false;
                    }

                    feet = item;
                    feet.Item.IsEquiped = true;
                }
            }
        }

        public void ApplyDamage(GameItem mainHand)
        {
            int defense = 0;

            if (offHand != null && offHand.Item is Shield shield)
            {
                defense += shield.DefenseValue;
            }

            if (head != null && head.Item is Armor armor)
            {
                defense += armor.DefenseValue;
            }

            if (body != null && body.Item is Armor bodyArmor)
            {
                defense += bodyArmor.DefenseValue;
            }

            if (hands != null && hands.Item is Armor handArmor)
            {
                defense += handArmor.DefenseValue;
            }

            if (feet != null && feet.Item is Armor footArmor)
            {
                defense += footArmor.DefenseValue;
            }

            int attack = 0;

            if (mainHand != null && mainHand.Item is Weapon weapon)
            {
                attack = weapon.AttackValue + weapon.AttackModifier;

                if (attack > defense)
                {
                    ushort damage = 0;

                    foreach (DamageEffectData e in weapon.DamageEffects)
                    {
                        for (int i = 0; i < e.NumberOfDice; i++)
                        {
                            damage += (ushort)Mechanics.RollDie(e.DieType);
                        }
                    }

                    Health.Damage(damage);
                }
            }
        }

        #endregion
    }
}
