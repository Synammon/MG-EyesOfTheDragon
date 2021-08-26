using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MGRpgLibrary.ConversationComponents
{
    public class Conversation
    {
        #region Field Region

        private string name;
        private string firstScene;
        private string currentScene;
        private Dictionary<string, GameScene> scenes;

        #endregion

        #region Property Region

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string FirstScene
        {
            get { return firstScene; }
            set { firstScene = value; }
        }

        [ContentSerializerIgnore]
        public GameScene CurrentScene
        {
            get { return scenes[currentScene]; }
        }

        public Dictionary<string, GameScene> GameScenes
        {
            get { return scenes; }
            set { scenes = value; }
        }

        #endregion

        #region Constructor Region

        private Conversation()
        {
        }

        public Conversation(string name, string firstScene)
        {
            this.scenes = new Dictionary<string, GameScene>();
            this.name = name;
            this.firstScene = this.currentScene = firstScene;
        }

        #endregion

        #region Method Region

        public void Update(GameTime gameTime)
        {
            CurrentScene.Update(gameTime, PlayerIndex.One);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D portrait)
        {
            CurrentScene.Draw(gameTime, spriteBatch, portrait);
        }

        public void AddScene(string sceneName, GameScene scene)
        {
            if (!scenes.ContainsKey(sceneName))
                scenes.Add(sceneName, scene);
        }

        public GameScene GetScene(string sceneName)
        {
            if (scenes.ContainsKey(sceneName))
                return scenes[sceneName];

            return null;
        }

        public void StartConversation()
        {
            currentScene = firstScene;
        }

        public void ChangeScene(string sceneName)
        {
            currentScene = sceneName;
        }

        #endregion
    }
}
