using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    class GameModeManager
    {
        private List<GameMode> _gameModes;
        private GameMode _current;

        GameModeManager()
        {

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
            _gameModes.Add(g);
        }

        public void Update(GameTime gameTime)
        {
            _current.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _current.Draw(gameTime);
        }

        public void Reset()
        {
            _current.Reset();
        }
    }
}
