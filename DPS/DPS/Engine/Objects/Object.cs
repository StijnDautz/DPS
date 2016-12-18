using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class Object : ILoopObject
    {
        private string _id;
        private float _depth;
        private bool _visible;
        private bool _canCollide;
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

        public bool CanCollide
        {
            get { return _canCollide; }
            set
            {
                _canCollide = value;
                if(_parent is Map)
                {
                    Map m = _parent as Map;
                    m.UpdateCollisionMap(this);
                }
            }
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
            _position = Vector2.Zero;
            _velocity = Vector2.Zero;
            _visible = true;
            _canCollide = false;
            _boundingBox = new Rectangle((int)Position.X, (int)Position.Y, 0, 0);
        }

        public virtual void Update(GameTime gameTime)
        {
            Vector2 newPos = _position + _velocity;
            if(!IsColliding(newPos))
            { UpdateMovement(newPos); }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        public virtual void Reset()
        {

        }

        public virtual void OnCollision(Object collider)
        {

        }

        private bool IsColliding(Vector2 newPos)
        {
            bool collided = false;
            //has Object moved?
            if (Velocity.Length() > 0)
            {
                //can the object collide, if so check if it has collided, if so call OnCollision
                if (_canCollide)
                {
                    foreach (Object o in ObjectList.Objects)
                    {
                        if (CollisionHelper.CollidesWith(this, newPos, o))
                        {
                            OnCollision(o);
                            o.OnCollision(this);
                            collided = true;
                        }
                    }
                }
            }
            return collided;
        }

        private void UpdateMovement(Vector2 newPos)
        {
            _position = newPos;
        }
    }
}