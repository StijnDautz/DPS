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
     * and handles input for objects of type Pawn in world
     */
    class GameMode
    {
        private string _id;
        private World _world;
        private GameStateManager _gameStateManager;

        public string Id
        {
            get { return _id; }
        }

        public World World
        {
            get { return _world; }
        }



        GameMode(string id, GameStateManager g)
        {
            _id = id;
            _gameStateManager = g;
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
        }
    }
}
