using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary
{
    public enum ChangeType { Change, Pop, Push }

    public class GameStateManager : GameComponent
    {
        #region Event Region

        public event EventHandler OnStateChange;

        #endregion

        #region Fields and Properties Region

        Stack<GameState> gameStates = new Stack<GameState>();
        const int startDrawOrder = 5000;
        const int drawOrderInc = 100;
        int drawOrder;
        public GameState CurrentState
        {
            get { return gameStates.Peek(); }
        }

        #endregion

        #region Constructor Region
        public GameStateManager(Game game)
        : base(game)
        {
            drawOrder = startDrawOrder;
        }

        #endregion

        #region XNA Method Region
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        #endregion

        #region Methods Region
        public void PopState()
        {
            if (gameStates.Count > 0)
            {
                RemoveState();
                drawOrder -= drawOrderInc;
                if (OnStateChange != null)
                    OnStateChange(this, null);
            }
        }
        private void RemoveState()
        {
            GameState State = gameStates.Peek();
            OnStateChange -= State.StateChange;
            Game.Components.Remove(State);
            gameStates.Pop();
        }

        public void PushState(GameState newState)
        {
            drawOrder += drawOrderInc;
            newState.DrawOrder = drawOrder;
            AddState(newState);

            if (OnStateChange != null)
                OnStateChange(this, null);
        }

        private void AddState(GameState newState)
        {
            gameStates.Push(newState);
            Game.Components.Add(newState);
            OnStateChange += newState.StateChange;
        }

        public void ChangeState(GameState newState)
        {
            while (gameStates.Count > 0)
                RemoveState();

            newState.DrawOrder = startDrawOrder;
            drawOrder = startDrawOrder;
            AddState(newState);

            if (OnStateChange != null)
                OnStateChange(this, null);
        }

        #endregion
    }
}
