using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class GameStateManager : IControlledLoopObject
    {
        private List<GameState> _gameStates;
        private GameState _current;
        private GameMode _parent;

        public GameMode Parent
        {
            set { _parent = value; }
            get { return _parent; }
        }

        public GameStateManager()
        {
            _gameStates = new List<GameState>();
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
            g.Parent = this;
            _gameStates.Add(g);
            g.HUD.World = Parent.World;
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
