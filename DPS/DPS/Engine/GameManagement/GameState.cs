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
     * GameState contains a HUD
     * Therefore a GameMode can have multiple HUD overlays
     */
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
            _HUD = new ObjectList("HUD");
        }

        public virtual void Update(GameTime gameTime)
        {
            _HUD.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _HUD.Draw(gameTime, spriteBatch);
        }

        public virtual void Reset()
        {
            _HUD.Reset();
        }
    }
}