using Microsoft.Xna.Framework;

namespace Engine
{
    partial class Object
    {
        private bool _hasPhysics, _canCollide, _canBlock, _inAir;
        private bool[] _collisionDimension;
        private Engine.SFXManager _sfxManager;

        public bool HasPhysics
        {
            set { _hasPhysics = value; }
            get { return _hasPhysics; }
        }

        public bool CanCollide
        {
            get { return _canCollide; }
            set { _canCollide = value; }
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

        public SFXManager SFXManager
        {
            set { _sfxManager = value; }
        }

        public virtual void Update(GameTime gameTime)
        {
            //update sfx manager
            if(_sfxManager != null)
            {
                _sfxManager.Update(gameTime, World.Player);
            }
        }
       
        public virtual void ApplyPhysics(float elapsedTime)
        {
            if (_hasPhysics && !World.IsTopDown)
            {
                _velocity.Y += World.Gravity * elapsedTime * _mass;
            }
            _velocity.X /= 1 + _mass * elapsedTime;
        }

        public virtual void OnCollision(Object collider)
        {

        }

        public virtual void SetupCollision(Object collider, float elapsedTime)
        {
            if (_visible && collider._visible)
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
            if (!_collisionDimension[0] && Velocity.X != 0)
            {
                if (CollisionHelper.CollidesWith(this, new Vector2(Velocity.X, 0), collider, collider._velocity, elapsedTime))
                {
                    _collisionDimension[0] = true;
                }
            }
            //Y
            if (!_collisionDimension[1] && Velocity.Y != 0)
            {
                if (CollisionHelper.CollidesWith(this, new Vector2(0, Velocity.Y), collider, collider._velocity, elapsedTime))
                {
                    if (_velocity.Y > 0)
                    {
                        float downWardsOffset = collider.GlobalPosition.Y - (GlobalPosition.Y + Height + 0.001f);
                        if(downWardsOffset > 0)
                        {
                            _position.Y += collider.GlobalPosition.Y - (GlobalPosition.Y + Height + 0.001f);
                        }
                    }
                    _collisionDimension[1] = true;
                    InAir = false;
                }
            }
        }

        public void ApplyPosition(float elapsedTime)
        {
            if (!_collisionDimension[0])
            {
                _position.X += _velocity.X * elapsedTime;
            }
            else
            {
                _collisionDimension[0] = false;
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