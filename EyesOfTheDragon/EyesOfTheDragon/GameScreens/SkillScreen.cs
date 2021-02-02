using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using MGRpgLibrary;
using MGRpgLibrary.Controls;
using RpgLibrary.SkillClasses;

namespace EyesOfTheDragon.GameScreens
{
    internal class SkillLabelSet
    {
        internal Label Label;
        internal Label Value;
        internal LinkLabel LinkLabel;

        internal SkillLabelSet(Label label, Label value, LinkLabel linkLabel)
        {
            Label = label;
            Value = value;
            LinkLabel = linkLabel;
        }

    }

    public class SkillScreen : BaseGameState
    {
        #region Field Region
        
        int skillPoints;
        int unassignedPoints;
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
        #endregion
        
        #region Virtual Method region
        
        #endregion
        
        #region MonoGame Method Region
        
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
            
            string skillPath = Content.RootDirectory + @"\Game\Skills\";
            string[] skillFiles = Directory.GetFiles(skillPath, "*.xnb");
            
            for (int i = 0; i < skillFiles.Length; i++)
                skillFiles[i] = @"Game\Skills\" +
                Path.GetFileNameWithoutExtension(skillFiles[i]);
            
            List<SkillData> skillData = new List<SkillData>();
            
            Vector2 nextControlPosition = new Vector2(300, 150);
            
            pointsRemaining = new Label();
            pointsRemaining.Text = "Skill Points: " + unassignedPoints.ToString();
            pointsRemaining.Position = nextControlPosition;
            
            nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 10f;
            
            ControlManager.Add(pointsRemaining);
           
            foreach (string s in skillFiles)
            {
                SkillData data = Content.Load<SkillData>(s);

                Label label = new Label
                {
                    Text = data.Name,
                    Type = data.Name,
                    Position = nextControlPosition
                };

                Label value = new Label
                {
                    Text = "0",
                    Position = new Vector2(
                        nextControlPosition.X + 350,
                        nextControlPosition.Y)
                };

                LinkLabel linkLabel = new LinkLabel
                {
                    TabStop = true,
                    Text = "+",
                    Type = data.Name,
                    Position = new Vector2(
                      nextControlPosition.X + 450,
                      nextControlPosition.Y)
                };

                nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 10f;
                linkLabel.Selected += addSkillLabel_Selected;
                ControlManager.Add(label);
                ControlManager.Add(value);
                ControlManager.Add(linkLabel);
                skillLabels.Add(new SkillLabelSet(label, value, linkLabel));
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
            StateManager.ChangeState(GameRef.GamePlayScreen);
        }

        void undoLabel_Selected(object sender, EventArgs e)
        {
            if (unassignedPoints == skillPoints)
                return;

            string skillName = undoSkill.Peek();
            SkillLabelSet set = skillLabels.FirstOrDefault(x => x.Label.Text == skillName);

            if (set != null)
            {
                int.TryParse(set.Value.Text, out int value);

                if (value == 0)
                    return;

                value--;
                set.Value.Text = value.ToString();
            }

            undoSkill.Pop();
            unassignedPoints++;

            // Update the skill points for the appropriate skill
            pointsRemaining.Text = "Skill Points: " + unassignedPoints.ToString();
        }

        void addSkillLabel_Selected(object sender, EventArgs e)
        {
            if (unassignedPoints <= 0)
                return;

            string skillName = ((LinkLabel)sender).Type;

            undoSkill.Push(skillName);

            unassignedPoints--;

            SkillLabelSet set = skillLabels.FirstOrDefault(x => x.Label.Text == skillName);

            if (set != null)
            {
                int.TryParse(set.Value.Text, out int value);
                value++;
                set.Value.Text = value.ToString();
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
