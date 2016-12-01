using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /*
     * A GameMode contains a list of gameStates and a world
     */
    class GameMode
    {
        private string _id;
        private World _world;
        private bool _canUpdateWorldTime;
        private GameStateManager _gameStateManager;

        public string Id
        {
            get { return _id; }
        }

        public World World
        {
            get { return _world; }
        }

        public bool CanUpdateWorldTime
        {
            get { return _canUpdateWorldTime; }
            set { _canUpdateWorldTime = value; }
        }

        public GameStateManager GameStateManager
        {
            get { return _gameStateManager; }
        }

        public GameMode(string id, World world)
        {
            _id = id;
            _gameStateManager = new GameStateManager();
            _canUpdateWorldTime = true;
            _world = world;
        }

        public void Reset()
        {
            _world.Reset();
            _gameStateManager.Reset();
        }

        public void Update(GameTime gameTime)
        {
            _world.Update(gameTime);
            _gameStateManager.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _world.Draw(gameTime, spriteBatch);
            _gameStateManager.Draw(gameTime, spriteBatch);
        }

        public void HandleInput(GameTime gameTime)
        {
            _world.HandleInput(gameTime);
        }
    }
}
