﻿using Microsoft.Xna.Framework;
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

        public GameModeManager()
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

        public void Reset()
        {
            _current.Reset();
        }

        public void Update(GameTime gameTime)
        {
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