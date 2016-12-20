using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    partial class Object
    {
        private bool _canCollide;
        private bool _hasPhysics;
        private bool _canBlock;
        private bool _inAir;

        public bool HasPhysics
        {
            set { _hasPhysics = value; }
        }

        public bool CanCollide
        {
            get { return _canCollide; }
            set
            {
                _canCollide = value;
                if (_parent is Map)
                {
                    Map m = _parent as Map;
                    m.UpdateCollisionMap(this);
                }
            }
        }

        public bool canBlock
        {
            get { return _canBlock; }
            set { _canBlock = value; }
        }

        public bool InAir
        {
            get { return _inAir; }
        }

        public virtual void Update(GameTime gameTime)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            Vector2 newPos = Vector2.Zero;

            if (_hasPhysics)
            {
                newPos += UpdatePhysics(elapsedTime);
            }
            newPos += _position + _velocity * elapsedTime;

            if ((newPos - _position).Length() > 0)
            {
                UpdateMovementAndColllision(newPos, elapsedTime);
                if(_inAir)
                {
                    _velocity.Y += ObjectList.World.Gravity * elapsedTime;
                    _velocity.X /= 1.007f;
                }
            }
        }

        private void UpdateMovementAndColllision(Vector2 newPos, float elapsedTime)
        {
            if (_canCollide)
            {
                Vector2 direction = newPos - _position;
                _inAir = canMoveDown(newPos);
                if (direction.Y > 0 && _inAir || direction.Y < 0 && canMoveUp(newPos))
                {
                    _position.Y = newPos.Y;
                }
                if (direction.X > 0 && canMoveRight(newPos) || direction.X < 0 && canMoveLeft(newPos))
                {
                    _position.X = newPos.X;
                }
            }
        }
    
        private Vector2 UpdatePhysics(float elapsedTime)
        {
            World world = ObjectList.World;
            if (world.IsTopDown)
            {
                return new Vector2(0, world.Gravity * elapsedTime);
            }
            else { return Vector2.Zero; }
        }

        public virtual void OnCollision(Object collider)
        {

        }

        private bool canMoveDown(Vector2 newPos)
        {
            foreach (Object o in ObjectList.Objects)
            {
                if (o._canCollide && this != o && CollisionHelper.CollidesWith(this, new Vector2(_position.X, newPos.Y), o) && CollisionHelper.CollidedAtBottom(this, newPos, o))
                {
                    return false;
                }
            }
            return true;
        }

        private bool canMoveUp(Vector2 newPos)
        {
            foreach (Object o in ObjectList.Objects)
            {
                if (o._canCollide && this != o && CollisionHelper.CollidesWith(this, new Vector2(_position.X, newPos.Y), o) && CollisionHelper.CollidedAtTop(this, newPos, o))
                {
                    return false;
                }
            }
            return true;
        }

        private bool canMoveLeft(Vector2 newPos)
        {
            foreach (Object o in ObjectList.Objects)
            {
                if (o._canCollide && this != o && CollisionHelper.CollidesWith(this, new Vector2(newPos.X, _position.Y), o) && CollisionHelper.CollidedAtLeft(this, newPos, o))
                {
                    return false;
                }
            }
            return true;
        }

        private bool canMoveRight(Vector2 newPos)
        {
            foreach (Object o in ObjectList.Objects)
            {
                if (o._canCollide && this != o && CollisionHelper.CollidesWith(this, new Vector2(newPos.X, _position.Y), o) && CollisionHelper.CollidedAtRight(this, newPos, o))
                {
                    return false;
                }
            }
            return true;
        }
    }
}