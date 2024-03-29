﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MGRpgLibrary;
using RpgLibrary.CharacterClasses;
using RpgLibrary.EffectClasses;

namespace RpgLibrary.SpellClasses
{
    public class Spell : Activation
    {
        #region Field Region

        string name;
        List<string> allowedClasses;
        Dictionary<string, int> attributeRequirements;
        List<string> spellPrerequisites;
        int levelRequirement;
        SpellType spellType;
        int activationCost;
        double coolDown;
        List<BaseEffect> effects;

        #endregion

        #region Property Region

        public string Name
        {
            get { return name; }
        }

        public List<string> AllowedClasses
        {
            get { return allowedClasses; }
        }

        public Dictionary<string, int> AttributeRequirements
        {
            get { return attributeRequirements; }
        }

        public List<string> SpellPrerequisites
        {
            get { return spellPrerequisites; }
        }

        public int LevelRequirement
        {
            get { return levelRequirement; }
        }

        public SpellType SpellType
        {
            get { return spellType; }
        }

        public int ActivationCost
        {
            get { return activationCost; }
        }

        public double CoolDown
        {
            get { return coolDown; }
        }

        public List<BaseEffect> Effects
        {
            get { return effects; }
        }

        #endregion

        #region Constructor Region

        private Spell()
        {
            allowedClasses = new List<string>();
            attributeRequirements = new Dictionary<string, int>();
            spellPrerequisites = new List<string>();
            effects = new List<BaseEffect>();
        }

        #endregion

        #region Method Region

        public static Spell FromSpellData(SpellData data)
        {
            Spell spell = new Spell
            {
                name = data.Name,
                levelRequirement = data.LevelRequirement,
                spellType = data.SpellType,
                activationCost = data.ActivationCost,
                coolDown = data.CoolDown,
                Range = data.Range,
                AreaOfEffect = data.AreaOfEffect,
                AngleOfEffect = data.AngleOfEffect,
                CastTime = data.CastTime
            };

            foreach (string s in data.AllowedClasses)
                spell.allowedClasses.Add(s.ToLower());

            foreach (string s in data.AttributeRequirements.Keys)
                spell.attributeRequirements.Add(
                s.ToLower(),
                data.AttributeRequirements[s]);

            foreach (string s in data.SpellPrerequisites)
                spell.SpellPrerequisites.Add(s);

            foreach (BaseEffect s in data.Effects)
                spell.Effects.Add(s);

            return spell;
        }

        public static bool CanLearn(Entity entity, Spell spell)
        {
            bool canLearn = true;

            if (entity.Level < spell.LevelRequirement)
                canLearn = false;

            string entityClass = entity.EntityClass.ToLower();

            if (!spell.AllowedClasses.Contains(entityClass))
                canLearn = false;

            foreach (string s in spell.AttributeRequirements.Keys)
            {
                if (Mechanics.GetAttributeByString(entity, s) < spell.AttributeRequirements[s])
                {
                    canLearn = false;
                    break;
                }
            }

            foreach (string s in spell.SpellPrerequisites)
            {
                if (!entity.Spells.ContainsKey(s))
                {
                    canLearn = false;
                    break;
                }
            }

            return canLearn;
        }

        #endregion

        #region Virtual Method Region
        #endregion
    }
}
