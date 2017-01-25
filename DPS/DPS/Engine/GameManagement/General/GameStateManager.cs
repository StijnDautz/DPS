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
    class GameStateManager
    {
        private List<GameState> _gameStates;
        private GameState _current;
        private GameMode _gameMode;

        public GameMode GameMode
        {
            set { _gameMode = value; }
            get { return _gameMode; }
        }

        public GameStateManager(GameMode gameMode)
        {
            _gameMode = gameMode;
            _gameStates = new List<GameState>();
        }

        public void SwitchTo(string id)
        {
            foreach(GameState g in _gameStates)
            {
                if(g.Id == id)
                {
                    _current = g;
                    //intitialize the gameState
                    g.Init();
                    if (_current.SongPlay != null)
                    {
                        MediaPlayer.Play(_current.SongPlay);
                        MediaPlayer.IsRepeating = true;
                    }
                    return;
                }
            }
            throw new Exception("gameState was not found");
        }

        public void Add(GameState g)
        {
            _gameStates.Add(g);
            g.Setup();
        }

        public void Update(GameTime gameTime)
        {
            _current.Update(gameTime);
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _current.Draw(gameTime, spriteBatch);
        }

        public void Reset()
        {
            _current.Reset();
        }

        public void HandleInput(GameTime gameTime)
        {
            _current.HandleInput(gameTime);
        }
    }
}
