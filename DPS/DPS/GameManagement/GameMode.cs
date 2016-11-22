using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    class GameMode
    {
        private World _world;
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
            foreach (Object o in _world.Objects)
            {
                if (o is ObjectList)
                {
                    ObjectList subList = o as ObjectList;
                    subList.Update(gameTime);
                }
                o.Update(gameTime);
            }

            _gameStateManager.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Object o in _world.Objects)
            {
                if (o is ObjectList)
                {
                    ObjectList subList = o as ObjectList;
                    subList.Draw(gameTime);
                }
                o.Draw(gameTime);
            }

            _gameStateManager.Draw(gameTime);
        }

        public void Reset()
        {
            foreach (Object o in _world.Objects)
            {
                if (o is ObjectList)
                {
                    ObjectList subList = o as ObjectList;
                    subList.Reset();
                }
                o.Reset();
            }

            _gameStateManager.Reset();
        }
    }
}
