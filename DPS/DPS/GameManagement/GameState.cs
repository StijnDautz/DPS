using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{ 
    class GameState
    {
        private string _id;
        private ObjectList _HUD;

        public string Id
        {
            get { return _id; }
        }

        public ObjectList HUD
        {
            set { _HUD = value; }
        }

        public GameState(string id)
        {
            _id = id;
        }

        public void Update(GameTime gameTime)
        {
            foreach(Object o in _HUD.Objects)
            {
                if(o is ObjectList)
                {
                    ObjectList subList = o as ObjectList;
                    subList.Update(gameTime);
                }
                o.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Object o in _HUD.Objects)
            {
                if (o is ObjectList)
                {
                    ObjectList subList = o as ObjectList;
                    subList.Draw(gameTime);
                }
                o.Draw(gameTime);
            }
        }

        public void Reset()
        {
            foreach (Object o in _HUD.Objects)
            {
                if (o is ObjectList)
                {
                    ObjectList subList = o as ObjectList;
                    subList.Reset();
                }
                o.Reset();
            }
        }
    }
}