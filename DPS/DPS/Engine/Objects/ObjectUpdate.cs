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
        private bool _hasPhysics;
        private bool _canCollide;
        private bool _canBlock;
        private bool _inAir;
        private bool[] _collisionDimension;
        private Engine.SFX _soundEffects;

        public bool HasPhysics
        {
            set { _hasPhysics = value; }
            get { return _hasPhysics; }
        }

        public bool CanCollide
        {
            get { return _canCollide; }
            set
            {
                if (!(_parent is ObjectGrid))
                {
                    if (value && !_canCollide)
                    {
                        World.CollisionObjects.Add(this);
                    }
                    if (!value && _canCollide)
                    {
                        World.CollisionObjects.Remove(this);
                    }
                }
                _canCollide = value;
            }
        }

        public bool CanBlock
        {
            get { return _canBlock; }
            set { _canBlock = value; }
        }

        public bool InAir
        {
            get { return _inAir; }
            set { _inAir = value; }
        }

        public SFX SFX
        {
            get { return _soundEffects; }
        }

        public virtual void Update(GameTime gameTime)
        {
            _soundEffects.Update(gameTime, World.Player);
        }
       
        public virtual void ApplyPhysics(float elapsedTime)
        {
            if (_hasPhysics && !World.IsTopDown && InAir)
            {
                _velocity.Y += World.Gravity * elapsedTime;
            }
        }

        public virtual void OnCollision(Object collider)
        {

        }

        public virtual void SetupCollision(Object collider, float elapsedTime)
        {
            if (collider is ObjectList || collider is ObjectGrid)
            {
                collider.SetupCollision(this, elapsedTime);
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
                if (CanBlock && collider.CanBlock)
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
                if (!CollisionHelper.CollidesWith(this, new Vector2(0, Velocity.Y), collider, collider._velocity, elapsedTime))
                {                   
                    _collisionDimension[0] = true;
                }
            }

            //Y
            if (!_collisionDimension[1] && _velocity.Y != 0)
            {
                if (!CollisionHelper.CollidesWith(this, new Vector2(Velocity.X, 0), collider, collider._velocity, elapsedTime))
                {
                    if (this is Character)
                    {
                        int x = 0;
                    }
                    if (_velocity.Y > 0)
                    {
                        _position.Y += collider.GlobalPosition.Y - (GlobalPosition.Y + Height + 0.001f);
                    }
                    _collisionDimension[1] = true;
                    InAir = false;
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
               // _velocity.X = 0;
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