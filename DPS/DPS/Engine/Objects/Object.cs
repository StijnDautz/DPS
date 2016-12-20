using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    partial class Object : ILoopObject
    {
        private string _id;
        private float _depth;
        private bool _visible;
        private Object _parent;
        private Vector2 _position;
        private Vector2 _velocity;
        private Rectangle _boundingBox;

        public string Id
        {
            get { return _id; }
        }

        public float Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public Object Parent
        {
            get
            {
                if (_parent != null)
                {
                    return _parent.Parent;
                }
                return this;
            }
            set { _parent = value; }
        }

        public ObjectList ObjectList
        {
            get { return Parent as ObjectList; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                _boundingBox.X = (int)value.X;
                _boundingBox.Y = (int)value.Y;
            }
        }

        public Vector2 GlobalPosition
        {
            get { return ObjectList.Position + Position; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Rectangle BoundingBox
        {
            get { return _boundingBox; }
            set { _boundingBox = value; }
        }

        public int Width
        {
            get { return BoundingBox.Width; }
        }

        public int Height
        {
            get { return BoundingBox.Height; }
        }

        public Object(string id)
        {
            _id = id;
            _depth = 1;
            _hasPhysics = false;
            _visible = true;
            _canCollide = false;
            _inAir = true;
            _position = Vector2.Zero;
            _velocity = Vector2.Zero;
            _boundingBox = new Rectangle((int)Position.X, (int)Position.Y, 0, 0);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        public virtual void Reset()
        {

        }
    }
}