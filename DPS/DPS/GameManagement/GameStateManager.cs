using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    class GameStateManager
    {
        private List<GameState> _gameStates;
        private GameState _current;

        GameStateManager()
        {

        }

        public void SwitchTo(string id)
        {
            foreach(GameState g in _gameStates)
            {
                if(g.Id == id)
                {
                    _current = g;
                    return;
                }
            }
            throw new Exception("gameState was not found");
        }

        public void Add(GameState g)
        {
            _gameStates.Add(g);
        }

        public void Update(GameTime gameTime)
        {
            _current.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _current.Draw(gameTime);
        }

        public void Reset()
        {
            _current.Reset();
        }
    }
}
