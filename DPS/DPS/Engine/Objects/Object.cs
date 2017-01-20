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
            set { _parent = value; }
        }

        private Object ParentTemp
        {
            get
            {
                if (_parent != null)
                {
                    return _parent.ParentTemp;
                }
                return this;
            }
            set { _parent = value; }
        }

        public World World
        {
            get { return ParentTemp as World; }
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

        public float PositionX
        {
            get { return _position.X; }
            set { _position.X = value; }
        }

        public float PositionY
        {
            get { return _position.Y; }
            set { _position.Y = value; }
        }

        public Vector2 GlobalPosition
        {
            get
            {
                if (_parent != null)
                {
                    return _parent.GlobalPosition + Position;
                }
                else
                {
                    return Position;
                }
            }
        }

        public Vector2 GlobalOrigin
        {
            get
            {
                Vector2 g = GlobalPosition;
                return new Vector2(g.X + Width / 2, g.Y + Height / 2);
            }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public float VelocityY
        {
            get { return _velocity.Y; }
            set { _velocity.Y = value; }
        }

        public float VelocityX
        {
            get { return _velocity.X; }
            set { _velocity.X = value; }
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

        public Object(string id, Object parent)
        {
            _id = id;
            _depth = 1;
            _visible = true;
            _inAir = true;
            _parent = parent;
            _boundingBox = new Rectangle((int)Position.X, (int)Position.Y, 0, 0);
            _collisionDimension = new bool[2];
            _soundEffects = new SFX(this);
        }

        public void setBoundingBoxDimensions(int width, int height)
        {
            _boundingBox.Size = new Point(width, height);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        public virtual void Reset()
        {

        }
    }
}