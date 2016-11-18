using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{ 
    class GameState
    {
        //World
        private string _id;

        public string Id
        {
            get { return _id; }
        }

        public GameState(string id)
        {
            _id = id;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {

        }

        public void Reset()
        {

        }
    }
}
