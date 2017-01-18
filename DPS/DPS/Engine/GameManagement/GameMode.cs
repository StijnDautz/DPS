﻿using Microsoft.Xna.Framework;
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
        private List<World> _worlds;
        private World _current;
        //is set in GameState and used in GameModeManager
        private GameStateManager _gameStateManager;
        private GameModeManager _parent;

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

        public GameModeManager Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public GameMode(string id, GameModeManager gm)
        {
            _id = id;
            _gameStateManager = new GameStateManager(this);
            _parent = gm;
            _worlds = new List<World>();
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

        public void AddWorld(World world)
        {
            _worlds.Add(world);
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
    }
}
