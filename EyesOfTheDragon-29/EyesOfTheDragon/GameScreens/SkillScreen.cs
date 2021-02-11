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
using MGRpgLibrary.CharacterClasses;
using RpgLibrary.SkillClasses;
using EyesOfTheDragon.Components;

namespace EyesOfTheDragon.GameScreens
{
    internal class SkillLabelSet
    {
        internal Label Label;
        internal Label SkillLabel;
        internal LinkLabel LinkLabel;
        internal int SkillValue;

        internal SkillLabelSet(Label label, Label skillLabel, LinkLabel linkLabel)
        {
            Label = label;
            SkillLabel = skillLabel;
            LinkLabel = linkLabel;
            SkillValue = 0;
        }
    }

    public class SkillScreen : BaseGameState
    {
        #region Field Region

        int skillPoints;
        int unassignedPoints;
        Character target;
        PictureBox backgroundImage;
        Label pointsRemaining;
        List<SkillLabelSet> skillLabels = new List<SkillLabelSet>();
        Stack<string> undoSkill = new Stack<string>();
        EventHandler linkLabelHandler;

        #endregion

        #region Property Region

        public int SkillPoints
        {
            get { return skillPoints; }
            set
            {
                skillPoints = value;
                unassignedPoints = value;
            }
        }

        #endregion

        #region Constructor Region

        public SkillScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
            linkLabelHandler = new EventHandler(addSkillLabel_Selected);
        }

        #endregion

        #region Method Region

        public void SetTarget(Character character)
        {
            target = character;

            foreach (SkillLabelSet set in skillLabels)
            {
                set.SkillValue = character.Entity.Skills[set.Label.Text].SkillValue;
                set.SkillLabel.Text = set.SkillValue.ToString();
            }
        }

        #endregion

        #region Virtual Method region

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            ContentManager Content = GameRef.Content;
            CreateControls(Content);
        }

        private void CreateControls(ContentManager Content)
        {
            backgroundImage = new PictureBox(
            Game.Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
            GameRef.ScreenRectangle);
            ControlManager.Add(backgroundImage);

            Vector2 nextControlPosition = new Vector2(300, 150);

            pointsRemaining = new Label
            {
                Text = "Skill Points: " + unassignedPoints.ToString(),
                Position = nextControlPosition
            };
            nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 10f;
            ControlManager.Add(pointsRemaining);

            foreach (string s in DataManager.SkillData.Keys)
            {
                SkillData data = DataManager.SkillData[s];
                Label label = new Label
                {
                    Text = data.Name,
                    Type = data.Name,
                    Position = nextControlPosition
                };

                Label sLabel = new Label
                {
                    Text = "0",
                    Position = new Vector2(
                        nextControlPosition.X + 300,
                        nextControlPosition.Y)
                };

                LinkLabel linkLabel = new LinkLabel
                {
                    TabStop = true,
                    Text = "Add",
                    Type = data.Name,
                    Position = new Vector2(
                        nextControlPosition.X + 390,
                        nextControlPosition.Y)
                };
        
                nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 10f;
                linkLabel.Selected += addSkillLabel_Selected;
                
                ControlManager.Add(label);
                ControlManager.Add(sLabel);
                ControlManager.Add(linkLabel);
                
                skillLabels.Add(new SkillLabelSet(label, sLabel, linkLabel));
            }
            
            nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 10f;

            LinkLabel undoLabel = new LinkLabel
            {
                Text = "Undo",
                Position = nextControlPosition,
                TabStop = true
            };
            
            undoLabel.Selected += new EventHandler(undoLabel_Selected);
            nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 10f;
            
            ControlManager.Add(undoLabel);

            LinkLabel acceptLabel = new LinkLabel
            {
                Text = "Accept Changes",
                Position = nextControlPosition,
                TabStop = true
            };
            
            acceptLabel.Selected += new EventHandler(acceptLabel_Selected);
            
            ControlManager.Add(acceptLabel);
            ControlManager.NextControl();
        }
        void acceptLabel_Selected(object sender, EventArgs e)
        {
            undoSkill.Clear();
            Transition(ChangeType.Change, GameRef.GamePlayScreen);
        }

        void undoLabel_Selected(object sender, EventArgs e)
        {
            if (unassignedPoints == skillPoints)
                return;
        
            string skillName = undoSkill.Peek();
            
            undoSkill.Pop();
            unassignedPoints++;
            
            foreach (SkillLabelSet set in skillLabels)
            {
                if (set.LinkLabel.Type == skillName)
                {
                    set.SkillValue--;
                    set.SkillLabel.Text = set.SkillValue.ToString();
            
                    target.Entity.Skills[skillName].DecreaseSkill(1);
                }
            }
            
            pointsRemaining.Text = "Skill Points: " + unassignedPoints.ToString();
        }
     
        void addSkillLabel_Selected(object sender, EventArgs e)
        {
            if (unassignedPoints <= 0)
                return;
        
            string skillName = ((LinkLabel)sender).Type;
            
            undoSkill.Push(skillName);
            unassignedPoints--;
            
            // Update the skill points for the appropriate skill
            foreach (SkillLabelSet set in skillLabels)
            {
                if (set.LinkLabel.Type == skillName)
                {
                    set.SkillValue++;
                    set.SkillLabel.Text = set.SkillValue.ToString();
            
                    target.Entity.Skills[skillName].IncreaseSkill(1);
                }
            }

            pointsRemaining.Text = "Skill Points: " + unassignedPoints.ToString();
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
    }
}
