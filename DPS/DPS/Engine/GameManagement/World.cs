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
    class World : IControlledLoopObject
    {
        private bool _isTopDown;
        private List<Map> _maps;

        public bool IsTopDown
        {
            get { return _isTopDown; }
            set { _isTopDown = value; }
        }

        public World() : base()
        {
            _isTopDown = true;
            _maps = new List<Map>();
        }

        public void Reset()
        {

        }

        public void Update(GameTime gameTime)
        {
            foreach(Map m in _maps)
            {
                //Maps get updated, whether they are visible or not
                m.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach(Map m in _maps)
            {
                if (m.Visible)
                { m.Draw(gameTime, spriteBatch); }
            }
        }

        public void HandleInput(GameTime gameTime)
        {
            foreach(Map m in _maps)
            {
                if (m.Visible)
                { m.HandleInput(gameTime); }
            }
        }

        protected void AddMap(Map map)
        {
            _maps.Add(map);
            map.World = this;
        }
    }
}