using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DPS
{
    class Object : ILoopObject
    {
        private string _id;
        private bool _visible;
        private ObjectList _parent;
        private Vector2 _position;
        private Vector2 _velocity;

        string Id
        {
            get { return _id; }
        }
        bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        ObjectList Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        Object(string id)
        {
            _id = id;
            _position = Vector2.Zero;
            _velocity = Vector2.Zero;
            _visible = true;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw()
        {

        }

        public virtual void Reset()
        {

        }
    }
}
