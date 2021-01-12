using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MGRpgLibrary;
using MGRpgLibrary.Controls;

namespace EyesOfTheDragon.GameScreens
{
    public class CharacterGeneratorScreen : BaseGameState
    {
        #region Field Region

        LeftRightSelector nameSelector;
        LeftRightSelector genderSelector;
        LeftRightSelector classSelector;
        PictureBox backgroundImage;

        readonly string[] genderItems = { "Male", "Female", "Non-Binary" };
        readonly string[] classItems = { "Fighter", "Wizard", "Rogue", "Priest" };
        readonly string[] maleName = { "Balthazar", "Logan", "Alfred", "Johnson" };
        readonly string[] femaleName = { "Lucinda", "Cynthia", "Ezmarelda", "Millicent" };
        readonly string[] nbName = { "Jaime", "Kelly", "Jordan", "Pat" };

        #endregion
        
        #region Property Region
        #endregion
        
        #region Constructor Region

        public CharacterGeneratorScreen(Game game, GameStateManager stateManager)
            : base(game, stateManager)
        {
        }
        
        #endregion
        
        #region MonoGame Method Region
        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            CreateControls();
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

        #region Method Region
        private void CreateControls()
        {
            Texture2D leftTexture = Game.Content.Load<Texture2D>(@"GUI\leftarrowUp");
            Texture2D rightTexture = Game.Content.Load<Texture2D>(@"GUI\rightarrowUp");
            Texture2D stopTexture = Game.Content.Load<Texture2D>(@"GUI\StopBar");

            backgroundImage = new PictureBox(
                Game.Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                GameRef.ScreenRectangle);

            ControlManager.Add(backgroundImage);

            Label label1 = new Label
            {
                Text = "Who will search for the Eyes of the Dragon?"
            };
            label1.Size = label1.SpriteFont.MeasureString(label1.Text);
            label1.Position = new Vector2(
                (GameRef.Window.ClientBounds.Width - label1.Size.X) /2, 150);

            ControlManager.Add(label1);

            nameSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            nameSelector.SetItems(maleName, 125);
            nameSelector.Position = new Vector2(label1.Position.X, 200);

            genderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            genderSelector.SetItems(genderItems, 125);
            genderSelector.Position = new Vector2(label1.Position.X, 250);
            genderSelector.SelectionChanged += GenderSelector_SelectionChanged;

            ControlManager.Add(genderSelector);

            classSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            classSelector.SetItems(classItems, 125);
            classSelector.Position = new Vector2(label1.Position.X, 300);

            ControlManager.Add(classSelector);

            LinkLabel linkLabel1 = new LinkLabel
            {
                Text = "Accept this character.",
                Position = new Vector2(label1.Position.X, 350)
            };
            linkLabel1.Selected += new EventHandler(LinkLabel1_Selected);

            ControlManager.Add(linkLabel1);
            ControlManager.NextControl();
        }

        private void GenderSelector_SelectionChanged(object sender, EventArgs e)
        {
            if (genderSelector.SelectedIndex == 0)
                nameSelector.SetItems(maleName, 125);
            else if (genderSelector.SelectedIndex == 1)
                nameSelector.SetItems(femaleName, 125);
            else
                nameSelector.SetItems(nbName, 125);
        }

        void LinkLabel1_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();
        
            StateManager.PopState();
            StateManager.PushState(GameRef.GamePlayScreen);
        }

        #endregion
    }
}
