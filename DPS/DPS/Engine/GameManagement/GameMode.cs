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
    class GameMode : IControlledLoopObject
    {
        private string _id;
        private World _world;
        //is set in GameState and used in GameModeManager
        private GameStateManager _gameStateManager;
        private GameModeManager _parent;

        public string Id
        {
            get { return _id; }
        }

        public World World
        {
            get { return _world; }
        }

        public GameStateManager GameStateManager
        {
            get { return _gameStateManager; }
        }

        public GameModeManager Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public GameMode(string id, World world, GameModeManager gm)
        {
            _id = id;
            _gameStateManager = new GameStateManager(this);
            _parent = gm;
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
            _gameStateManager.HandleInput(gameTime);
        }
    }
}
