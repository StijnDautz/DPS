using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class GameModeManager : IControlledLoopObject
    {
        private List<GameMode> _gameModes;
        private GameMode _current;
        private static TimeManager _timeManager;
        private GameInstance _gameInstance;
        private bool _canUpdateWorldTime;

        public GameInstance GameInstance
        {
            get { return _gameInstance; }
            set { _gameInstance = value; }
        }

        public static TimeManager TimeManager
        {
            get { return _timeManager; }
        }

        public bool CanUpdateGameTime
        {
            set { _canUpdateWorldTime = value; }
        }

        public GameModeManager()
        {
            _timeManager = new TimeManager();
            _gameModes = new List<GameMode>();
            _canUpdateWorldTime = false;
        }

        public void SwitchTo(string id)
        {
            foreach(GameMode g in _gameModes)
            {
                if (g.Id == id)
                {
                    _current = g;
                    return;
                }
            }
            throw new Exception("gameMode was not found");
        }

        public void Add(GameMode g)
        {
            g.GameModeManager = this;
            _gameModes.Add(g);
        }

        public void Reset()
        {
            _current.Reset();
        }

        public void Update(GameTime gameTime)
        {
            if(_canUpdateWorldTime)
            {
                _timeManager.Update(gameTime);
            }
            _current.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _current.Draw(gameTime, spriteBatch);
        }

        public void HandleInput(GameTime gameTime)
        {
            _current.HandleInput(gameTime);
        }
    }
}