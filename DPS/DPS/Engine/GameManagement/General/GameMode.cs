using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
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
        private List<World> _worlds;
        private World _current;
        //is set in GameState and used in GameModeManager
        private GameStateManager _gameStateManager;
        private GameModeManager _parent;
        private Player _player;

        public string Id
        {
            get { return _id; }
        }

        public World World
        {
            get { return _current; }
        }

        public GameStateManager GameStateManager
        {
            get { return _gameStateManager; }
        }

        public GameModeManager GameModeManager
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public GameMode(string id, GameModeManager gm, List<World> worlds)
        {
            _id = id;
            _gameStateManager = new GameStateManager(this);
            _parent = gm;
            _worlds = worlds;
        }

        public virtual void Setup()
        {

        }

        public void Reset()
        {
            if (_current != null)
            {
                _current.Reset();
            }
            _gameStateManager.Reset();
        }

        public void Update(GameTime gameTime)
        {
            if (_current != null)
            {
                _current.Update(gameTime);
            }
            _gameStateManager.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_current != null)
            {
                _current.Draw(gameTime, spriteBatch);
            }
            _gameStateManager.Draw(gameTime, spriteBatch);
        }

        public void HandleInput(GameTime gameTime)
        {
            if (_current != null)
            {
                _current.HandleInput(gameTime);
            }
            _gameStateManager.HandleInput(gameTime);
        }

        public void SwitchTo(string id)
        {
            foreach(World w in _worlds)
            {
                if(w.Id == id)
                {
                    
                    _current = w;
                    
                    return;
                }
            }
            throw new Exception("Could not find a world with id: " + id);
        }

        public void SetupWorlds()
        {
            foreach(World w in _worlds)
            {
                w.Setup(this);
            }
        }

    }
}
