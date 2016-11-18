using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    class GameMode
    {
        private GameStateManager _gameStateManager;
        private string _id;

        public string Id
        {
            get { return _id; }
        }

        GameMode(string id, GameStateManager g)
        {
            _id = id;
            _gameStateManager = g;
        }

        public void Update(GameTime gameTime)
        {
            _gameStateManager.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _gameStateManager.Draw(gameTime);
        }

        public void Reset()
        {
            _gameStateManager.Reset();
        }
    }
}
