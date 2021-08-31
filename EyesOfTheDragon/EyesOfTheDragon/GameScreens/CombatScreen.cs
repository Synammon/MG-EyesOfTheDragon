using MGRpgLibrary;
using MGRpgLibrary.ConversationComponents;
using MGRpgLibrary.Mobs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EyesOfTheDragon.GameScreens
{
    public class CombatScreen : BaseGameState
    {
        private Texture2D _menuTexture;
        private Texture2D _actionTexture;
        private bool _displayActionTexture = false;
        private Mob _mob;
        private GameScene _scene;

        public CombatScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        public void SetMob(Mob mob)
        {
            _mob = mob;

            _scene = new CombatScene(Game, "Combat Scene", new List<SceneOption>());

            SceneOption option = new SceneOption("Attack", "Attack", new SceneAction());

            _scene.Options.Add(option);

            if (GamePlayScreen.Player.Character.Entity.Mana.MaximumValue > 0)
            {
                option = new SceneOption("Spell", "Spell", new SceneAction());
            }
            else
            {
                option = new SceneOption("Talent", "Talent", new SceneAction());
            }
            _scene.Options.Add(option);

            option = new SceneOption("Run for your life!", "Run for your life!", new SceneAction());
            _scene.Options.Add(option);

            ((CombatScene)_scene).SetCaption($"You face death itself in the form of a {_mob.Entity.EntityName.ToLower()}.");
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Color[] data = new Color[1280 * 200];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Color.Black;
            }

            _menuTexture = new Texture2D(GraphicsDevice, 1280, 200);
            _menuTexture.SetData(data);

            data = new Color[200 * 720];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Color.AliceBlue;
            }

            _actionTexture = new Texture2D(GraphicsDevice, 200, 720);
            _actionTexture.SetData(data);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            _scene.Update(gameTime, PlayerIndex.One);

            if (GamePlayScreen.Player.Character.Entity.Health.CurrentValue <= 0)
            {
                StateManager.ChangeState(GameRef.GameOverScreen);
            }

            if (InputHandler.KeyReleased(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                switch (_scene.SelectedIndex)
                {
                    case 0:
                        if (GamePlayScreen.Player.Character.Entity.Dexterity >= _mob.Entity.Dexterity)
                        {
                            _mob.Attack(GamePlayScreen.Player.Character.Entity);

                            if (_mob.Entity.Health.CurrentValue <= 0)
                            {
                                StateManager.PopState();
                                return;
                            }

                            _mob.DoAttack(GamePlayScreen.Player.Character.Entity);
                        }
                        else
                        {
                            _mob.DoAttack(GamePlayScreen.Player.Character.Entity);
                            _mob.Attack(GamePlayScreen.Player.Character.Entity);

                            if (_mob.Entity.Health.CurrentValue <= 0)
                            {
                                StateManager.PopState();
                                return;
                            }
                        }
                        break;
                    case 2:
                        Vector2 center = GamePlayScreen.Player.Sprite.Center;
                        Vector2 mobCenter = _mob.Sprite.Center;

                        if (center.Y < mobCenter.Y)
                        {
                            GamePlayScreen.Player.Sprite.Position.Y -= 8;
                        }
                        else if (center.Y > mobCenter.Y)
                        {
                            GamePlayScreen.Player.Sprite.Position.Y += 8;
                        }
                        else if (center.X < mobCenter.X)
                        {
                            GamePlayScreen.Player.Sprite.Position.X -= 8;
                        }
                        else
                        {
                            GamePlayScreen.Player.Sprite.Position.X += 8;
                        }

                        StateManager.PopState();
                        break;
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            GameRef.SpriteBatch.Begin();

            GameRef.SpriteBatch.Draw(_menuTexture, new Rectangle(0, 720 - _menuTexture.Height, _menuTexture.Width, _menuTexture.Height), Color.White);

            _scene.Draw(gameTime, GameRef.SpriteBatch);

            if (_displayActionTexture)
            {
                GameRef.SpriteBatch.Draw(_actionTexture, new Rectangle(_actionTexture.Width, 0, _actionTexture.Width, _actionTexture.Height), Color.White);
            }

            GameRef.SpriteBatch.End();
        }
    }
}
