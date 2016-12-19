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

        public virtual void Update(GameTime gameTime)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            Vector2 newPos = Vector2.Zero;

            if (_hasPhysics)
            {
                newPos += UpdatePhysics(elapsedTime);
            }
            newPos += _position + _velocity * elapsedTime;


            //set create temp BoundingBox on new position
            if ((newPos - _position).Length() > 0)
            {
                UpdateMovementAndColllision(newPos, elapsedTime);
            }
        }

        private void UpdateMovementAndColllision(Vector2 newPos, float elapsedTime)
        {
            bool collisionBottom = false;
            bool collisionTop = false;
            bool collisionLeft = false;
            bool collisionRight = false;

            //has Object moved?
            //can the object collide, if so check if it has collided, if so call OnCollision
            if (_canCollide)
            {
                foreach (Object o in ObjectList.Objects)
                {
                    if (o._canCollide && this != o)
                    {
                        bool collidesOnXAxis = CollisionHelper.CollidesWith(this, new Vector2(newPos.X, _position.Y), o);
                        bool collidesOnYAxis = CollisionHelper.CollidesWith(this, new Vector2(_position.X, newPos.Y), o);

                        if (collidesOnXAxis || collidesOnYAxis)
                        {
                            o.OnCollision(this);
                            if (o._canBlock)
                            {
                                if (collidesOnXAxis)
                                {
                                    if (!collisionLeft)
                                    {
                                        collisionLeft = CollisionHelper.CollidedAtLeft(this, newPos, o);
                                    }
                                    if (!collisionRight)
                                    { collisionRight = CollisionHelper.CollidedAtRight(this, newPos, o); }
                                }
                                if (collidesOnYAxis)
                                {
                                    if (!collisionBottom)
                                    { collisionBottom = CollisionHelper.CollidedAtBottom(this, newPos, o); }
                                    if (!collisionTop)
                                    { collisionTop = CollisionHelper.CollidedAtTop(this, newPos, o); }
                                }
                            }
                        }
                    }
                }
            }
            UpdateMovement(collisionBottom, collisionTop, collisionLeft, collisionRight, newPos, newPos - _position, elapsedTime);
        }

        private void UpdateMovement(bool down, bool up, bool left, bool right, Vector2 newPos, Vector2 direction, float elapsedTime)
        {
            if ((direction.Y > 0 && !down) || (direction.Y < 0 && !up))
            {
                _position.Y = newPos.Y;
            }
            if ((direction.X < 0 && !left) || (direction.X > 0 && !right))
            {
                _position.X = newPos.X;
            }
            if (!down)
            {
                _velocity.Y += ObjectList.World.Gravity * elapsedTime;
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
    }
}