using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Content
{
    class SpriteSheetCharacter : Engine.SpriteSheet
    {
        public enum animation
        {
            IDLE, WALKING, RUNNING, JUMPING, INAIR, FALLING, ATTACK, JUMPATTACK, DEATH,
        }

        animation _animation;

        public SpriteSheetCharacter(string assetName) : base(assetName)
        {

        }

        public override void Update(GameTime gameTime, Engine.Object obj)
        {
            animation tempAnim = _animation;
            base.Update(gameTime, obj);
            if (tempAnim != _animation)
            {
                SetupAnimation(obj);
            }
        }

        public override void SetupAnimation(Engine.Object obj)
        {
            switch (_animation)
            {
                case animation.IDLE:
                    ResetAnimation(0, 2, 320, 128);
                    break;
                case animation.WALKING:
                    ResetAnimation(1, 16, 100, 1024);
                    break;
                case animation.RUNNING:
                    ResetAnimation(1, 16, 20, 1024);
                    break;
                case animation.DEATH:
                    ResetAnimation(2, 6, 50, 976);
                    break;
                case animation.JUMPING:
                    ResetAnimation(3, 12, 45, 768);
                    break;
                case animation.INAIR:
                    ResetAnimation(4, 3, 120, 192);
                    break;
                case animation.FALLING:
                    ResetAnimation(5, 5, 30, 320);
                    break;
            }
            base.SetupAnimation(obj);
        }

        public override void UpdateAnimationState(Engine.Object obj)
        {
            if (_animation == animation.JUMPING)
            {

            }
            /*
            if (_attacking && (_attackTime += elapsedTime) > _attackSpeed)
            {
                _attacking = false;
                _attackTime = 0;
            }
            if (_attacking)
            {
                _movementState = InAir ? movementState.JUMPATTACK : movementState.ATTACK;
            }*/
            if (obj.Velocity.Y != 0)
            {
                _animation = obj.Velocity.Y < 0 ? animation.JUMPING : animation.FALLING;
            }
            else
            {
                if (obj.Velocity.X == 0)
                {
                    _animation = animation.IDLE;
                }
                else
                {
                    _animation = animation.WALKING;
                }
            }
        }

        public override void AfterLastFrame()
        {
            base.AfterLastFrame();
            if (_animation == animation.JUMPING)
            {
                _animation = animation.INAIR;
            }
        }
    }
}
