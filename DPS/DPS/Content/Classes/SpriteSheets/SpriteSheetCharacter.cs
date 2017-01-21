using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
            Maxindex = 7;
            IsAnimated = true;
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

        protected override void SetupAnimation(Engine.Object obj)
        {
            switch (_animation)
            {
                case animation.IDLE:
                    ResetAnimation(0, 2, 320, 256);
                    break;
                case animation.WALKING:
                    ResetAnimation(1, 16, 40, 2048);
                    break;
                case animation.RUNNING:
                    ResetAnimation(1, 16, 20, 2048);
                    break;
                case animation.DEATH:
                    //TODO set proper width
                    ResetAnimation(2, 6, 110, 1152);
                    break;
                case animation.JUMPING:
                    ResetAnimation(3, 4, 53, 512);
                    break;
                case animation.INAIR:
                    ResetAnimation(4, 3, 120, 384);
                    break;
                case animation.FALLING:
                    ResetAnimation(5, 5, 45, 640);
                    break;
            }
            base.SetupAnimation(obj);
        }

        protected override void UpdateAnimationState(Engine.Object obj)
        {
            if (obj is Engine.Player && (obj as Engine.Player).Death)
            {
                _animation = animation.DEATH;
            }
            else
            {
                if (obj.Velocity.Y != 0)
                {
                    if (_animation != animation.INAIR)
                    {
                        _animation = animation.JUMPING;
                    }
                }
                else
                {
                    if (_animation == animation.INAIR)
                    {
                        _animation = animation.FALLING;
                    }
                    if (_animation != animation.FALLING)
                    {
                        if (obj.VelocityX != 0)
                        {
                            _animation = animation.WALKING;
                        }
                        else
                        {
                            _animation = animation.IDLE;
                        }
                    }
                }
            }
        }

        protected override void AfterLastFrame(Engine.Object obj)
        {
            base.AfterLastFrame(obj);
            if (_animation == animation.JUMPING)
            {
                _animation = animation.INAIR;
            }
            if(_animation == animation.FALLING)
            {
                _animation = animation.IDLE;
            }
            if(_animation == animation.DEATH)
            {
                IsLooping = false;
                CurrentFrame = 5;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            base.Draw(spriteBatch, position);
        }
    }
}
