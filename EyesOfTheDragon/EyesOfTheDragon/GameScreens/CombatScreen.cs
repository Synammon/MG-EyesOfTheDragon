using EyesOfTheDragon.Components;
using MGRpgLibrary;
using MGRpgLibrary.ConversationComponents;
using MGRpgLibrary.Mobs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.CharacterClasses;
using RpgLibrary.EffectClasses;
using RpgLibrary.SpellClasses;
using RpgLibrary.TalentClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace EyesOfTheDragon.GameScreens
{
    public class CombatScreen : BaseGameState
    {
        private Texture2D _menuTexture;
        private Texture2D _actionTexture;
        private Texture2D _selected;
        private bool _displayActionTexture = false;
        private Mob _mob;
        private GameScene _scene;
        private readonly List<string> _actions = new List<string>();
        private int _action;
        private Texture2D _hudTexture;
        private Texture2D _healthBorderTexture;
        private Texture2D _healthTexture;
        private double _queueTimer;

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
                data[i] = Color.Blue;
            }

            _actionTexture = new Texture2D(GraphicsDevice, 200, 720);
            _actionTexture.SetData(data);

            data = new Color[1280 * 40];

            for (int i = 0; i < 1280 * 40; i++)
            {
                data[i] = Color.Black;
            }

            _hudTexture = new Texture2D(GraphicsDevice, 1280, 40);
            _hudTexture.SetData(data);

            data = new Color[502 * 12];

            for (int i = 0; i < 502 * 12; i++)
            {
                data[i] = Color.Gray;
            }

            _healthBorderTexture = new Texture2D(GraphicsDevice, 502, 12);
            _healthBorderTexture.SetData(data);

            data = new Color[500 * 10];

            for (int i = 0; i < 500 * 10; i++)
            {
                data[i] = Color.White;
            }

            _healthTexture = new Texture2D(GraphicsDevice, 500, 10);
            _healthTexture.SetData(data);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            _queueTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (_queueTimer > 2)
            {
                if (GameState._descriptions.Count > 0)
                {
                    GameState._descriptions.Dequeue();
                }

                _queueTimer = 0;
            }

            if (!_displayActionTexture)
            {
                _scene.Update(gameTime, PlayerIndex.One);
            }

            if (GamePlayScreen.Player.Character.Entity.Health.CurrentValue <= 0)
            {
                StateManager.ChangeState(GameRef.GameOverScreen);
            }

            if (InputHandler.KeyReleased(Microsoft.Xna.Framework.Input.Keys.Space) && !_displayActionTexture)
            {
                switch (_scene.SelectedIndex)
                {
                    case 0:
                        _queueTimer = 0;
                        if (GamePlayScreen.Player.Character.Entity.Dexterity >= _mob.Entity.Dexterity)
                        {
                            _descriptions.Enqueue($"You attack the {_mob.Entity.EntityClass}.");
                            _mob.Attack(GamePlayScreen.Player.Character.Entity);

                            if (_mob.Entity.Health.CurrentValue <= 0)
                            {
                                StateManager.PopState();
                                StateManager.PushState(GameRef.LootScreen);
                                GameRef.LootScreen.Gold = _mob.GoldDrop;

                                foreach (var i in _mob.Drops)
                                {
                                    GameRef.LootScreen.Items.Add(i);
                                }

                                return;
                            }

                            _descriptions.Enqueue($"The {_mob.Entity.EntityClass} attacks you.");
                            _mob.DoAttack(GamePlayScreen.Player.Character.Entity);
                        }
                        else
                        {
                                _descriptions.Enqueue($"The {_mob.Entity.EntityClass} attacks you.");
                                _mob.DoAttack(GamePlayScreen.Player.Character.Entity);
                                _descriptions.Enqueue($"You attack the {_mob.Entity.EntityClass}.");
                                _mob.Attack(GamePlayScreen.Player.Character.Entity);

                                if (_mob.Entity.Health.CurrentValue <= 0)
                                {
                                    StateManager.PopState();
                                    StateManager.PushState(GameRef.LootScreen);

                                    GamePlayScreen.Player.Character.Entity.AddExperience(_mob.XPValue);
                                    foreach (var i in _mob.Drops)
                                    {
                                        GameRef.LootScreen.Items.Add(i);
                                    }

                                    return;
                            }
                        }
                        break;
                    case 1:
                        _displayActionTexture = true;

                        _actions.Clear();
                        Entity entity = GamePlayScreen.Player.Character.Entity;

                        if (entity.Mana.MaximumValue > 0)
                        {
                            foreach (SpellData s in DataManager.SpellData.SpellData.Values)
                            {
                                foreach (string c in s.AllowedClasses)
                                {
                                    if (c == entity.EntityClass && entity.Level >= s.LevelRequirement)
                                    {
                                        _actions.Add(s.Name);
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (TalentData s in DataManager.TalentData.TalentData.Values)
                            {
                                foreach (string c in s.AllowedClasses)
                                {
                                    if (c == entity.EntityClass && entity.Level >= s.LevelRequirement)
                                    {
                                        _actions.Add(s.Name);
                                    }
                                }
                            }
                        }
                        return;
                    case 2:
                        Vector2 center = GamePlayScreen.Player.Sprite.Center;
                        Vector2 mobCenter = _mob.Sprite.Center;
                        _action = 0;

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

            if (_displayActionTexture)
            {
                if (InputHandler.KeyReleased(Microsoft.Xna.Framework.Input.Keys.Escape))
                {
                    _displayActionTexture = false;
                    return;
                }
                else if (InputHandler.KeyReleased(Microsoft.Xna.Framework.Input.Keys.Space))
                {
                    DoAction();
                }
                else if (InputHandler.KeyReleased(Microsoft.Xna.Framework.Input.Keys.Down))
                {
                    _action++;

                    if (_action >= _actions.Count)
                    {
                        _action = 0;
                    }
                }
                else if (InputHandler.KeyReleased(Microsoft.Xna.Framework.Input.Keys.Up))
                {
                    _action--;

                    if (_action < 0)
                    {
                        _action = _actions.Count - 1;
                    }
                }
            }

            base.Update(gameTime);
        }

        private void DoAction()
        {
            Entity entity = GamePlayScreen.Player.Character.Entity;

            if (entity.Mana.MaximumValue > 0)
            {
                SpellData spell = DataManager.SpellData.SpellData[_actions[_action]];

                if (spell.ActivationCost > entity.Mana.CurrentValue)
                {
                    return;
                }

                entity.Mana.Damage((ushort)spell.ActivationCost);
                
                Spell s = Spell.FromSpellData(spell);

                if (s.SpellType == SpellType.Activated)
                {
                    foreach (BaseEffect e in s.Effects)
                    {
                        switch (e.TargetType)
                        {
                            case TargetType.Enemy:
                                e.Apply(_mob.Entity);
                                break;
                            case TargetType.Self:
                                e.Apply(entity);
                                break;
                        }
                    }
                }
            }
            else
            {
                TalentData talent = DataManager.TalentData.TalentData[_actions[_action]];

                if (talent.ActivationCost > entity.Stamina.CurrentValue)
                {
                    return;
                }

                entity.Stamina.Damage((ushort)talent.ActivationCost);

                Talent s = Talent.FromTalentData(talent);

                if (s.TalentType == TalentType.Activated)
                {
                    foreach (BaseEffect e in s.Effects)
                    {
                        switch (e.TargetType)
                        {
                            case TargetType.Enemy:
                                e.Apply(_mob.Entity);
                                break;
                            case TargetType.Self:
                                e.Apply(entity);
                                break;
                        }
                    }
                }
            }

            _displayActionTexture = false;

            if (_mob.Entity.Health.CurrentValue > 0)
            {
                _mob.DoAttack(entity);
            }

            if (_mob.Entity.Health.CurrentValue <= 0)
            {
                GameRef.LootScreen.Gold = _mob.GoldDrop;
                StateManager.PopState();
                StateManager.PushState(GameRef.LootScreen);

                GamePlayScreen.Player.Character.Entity.AddExperience(_mob.XPValue);

                foreach (var i in _mob.Drops)
                {
                    GameRef.LootScreen.Items.Add(i);
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            if (_selected == null)
                _selected = Game.Content.Load<Texture2D>(@"GUI\rightarrowUp");

            GameRef.SpriteBatch.Begin();

            Rectangle menuDest = new Rectangle(0, 720 - _menuTexture.Height, _menuTexture.Width, _menuTexture.Height);
            Rectangle hudDest = new Rectangle(0, menuDest.Top - _hudTexture.Height, _hudTexture.Width, _hudTexture.Height);

            GameRef.SpriteBatch.Draw(_menuTexture, menuDest, Color.White);
            GameRef.SpriteBatch.Draw(_hudTexture, hudDest, Color.White);

            Rectangle dest = new Rectangle(10, hudDest.Top + 12, _healthBorderTexture.Width, _healthBorderTexture.Height);
            GameRef.SpriteBatch.Draw(_healthBorderTexture, dest, Color.White);
            
            dest.X += 5;
            dest.Y += 2;
            dest.Height -= 5;
            dest.Width = (int)(dest.Width * ((float)GamePlayScreen.Player.Character.Entity.Health.CurrentValue / GamePlayScreen.Player.Character.Entity.Health.MaximumValue)) - 10;

            GameRef.SpriteBatch.Draw(_healthTexture, dest, Color.Red);

            dest = new Rectangle(Game1.ScreenWidth - _healthBorderTexture.Width - 10, hudDest.Top + 12, _healthBorderTexture.Width, _healthBorderTexture.Height);
            GameRef.SpriteBatch.Draw(_healthBorderTexture, dest, Color.White);

            dest.X += 5;
            dest.Y += 2;
            dest.Height -= 5;
            dest.Width = (int)(dest.Width * ((float)_mob.Entity.Health.CurrentValue / _mob.Entity.Health.MaximumValue)) - 10;

            GameRef.SpriteBatch.Draw(_healthTexture, dest, Color.Red);

            _scene.Draw(gameTime, GameRef.SpriteBatch);

            if (_displayActionTexture)
            {
                GameRef.SpriteBatch.Draw(_actionTexture, new Rectangle(_actionTexture.Width, 0, _actionTexture.Width, _actionTexture.Height), Color.White);
                Vector2 position = new Vector2(_actionTexture.Width + 50, 5);

                int count = 0;

                foreach (string s in _actions)
                {
                    Color myColor = Color.Black;

                    if (count == _action)
                    {
                        myColor = Color.White;
                        GameRef.SpriteBatch.Draw(_selected, new Rectangle((int)position.X - 35, (int)position.Y, _selected.Width, _selected.Height), Color.White);
                    }

                    GameRef.SpriteBatch.DrawString(FontManager.GetFont("testfont"), s, position, myColor);
                    position.Y += FontManager.GetFont("testfont").LineSpacing + 5;

                    count++;
                }
            }

            if (_descriptions.Count > 0)
            {
                string text = _descriptions.Peek();

                GameRef.SpriteBatch.DrawString(
                    FontManager.GetFont("testfont"),
                    text,
                    new Vector2(10, Game1.ScreenHeight - FontManager.GetFont("testfont").LineSpacing),
                    Color.White);
            }

            GameRef.SpriteBatch.End();
        }

        protected override void Show()
        {
            _queueTimer = 0;
            base.Show();
        }
    }
}
