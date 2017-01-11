using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
        private bool[] _collisionDimension;

        protected bool HasPhysics
        {
            set { _hasPhysics = value; }
            get { return _hasPhysics; }
        }

        public bool CanCollide
        {
            get { return _canCollide; }
            set { _canCollide = value; }
        }

        public bool canBlock
        {
            get { return _canBlock; }
            set { _canBlock = value; }
        }

        public bool InAir
        {
            get { return _inAir; }
            set { _inAir = value; }
        }

        private Vector2 Vec_VelocityX
        {
            get { return new Vector2(_velocity.X, 0); }
        }

        private Vector2 Vec_VelocityY
        {
            get { return new Vector2(0, _velocity.Y); }
        }

        public virtual void Update(GameTime gameTime)
        {

        }
       
        public virtual void ApplyPhysics(float elapsedTime)
        {
            if (_hasPhysics && !ObjectList.World.IsTopDown && InAir)
            {
                _velocity.Y += ObjectList.World.Gravity * elapsedTime;
            }
        }

        public virtual void OnCollision(Object collider)
        {

        }

        public virtual void SetupCollision(Object collider, float elapsedTime)
        {
            if (collider is ObjectList)
            {
                var col = collider as ObjectList;
                foreach (Object o2 in col.Objects)
                {
                    CheckCollision(o2, elapsedTime);
                }
            }
            else
            {
                CheckCollision(collider, elapsedTime);
            }
        }

        public void CheckCollision(Object collider, float elapsedTime)
        {
            //are o and c colliding?
            if (CollisionHelper.CollidesWith(this, _velocity, collider, collider._velocity, elapsedTime))
            {
                //call onCollisionFunc
                OnCollision(collider);
                collider.OnCollision(this);

                //if both can block, check in which direction o can move
                if (canBlock && collider.canBlock)
                {
                    CheckCollisionDimensions(collider, elapsedTime);
                    collider.CheckCollisionDimensions(this, elapsedTime);
                }
            }
        }

        private void CheckCollisionDimensions(Object collider, float elapsedTime)
        {
            //X
            if (!_collisionDimension[0] && _velocity.X != 0)
            {
                if (!CollisionHelper.CollidesWith(this, Vec_VelocityY, collider, collider._velocity, elapsedTime))
                {
                    _collisionDimension[0] = true;
                }
            }
            //Y
            if (!_collisionDimension[1] && _velocity.Y != 0)
            {
                if (!CollisionHelper.CollidesWith(this, Vec_VelocityX, collider, collider._velocity, elapsedTime))
                {
                    _collisionDimension[1] = true;
                    if (_velocity.Y > 0 && _inAir)
                    {
                        InAir = false;
                    }
                }
            }
        }

        public void ApplyPosition(float elapsedTime)
        {
            if(!_collisionDimension[0])
            {
                _position.X += _velocity.X * elapsedTime;
            }
            else
            {
                _collisionDimension[0] = false;
                _velocity.X = 0;
            }
            if(!_collisionDimension[1])
            {
                _position.Y += _velocity.Y * elapsedTime;
            }
            else
            {
                _collisionDimension[1] = false;
                _velocity.Y = 0;
            }
        }
    }
}