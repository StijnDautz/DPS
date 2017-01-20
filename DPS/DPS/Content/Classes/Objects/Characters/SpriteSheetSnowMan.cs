using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class SpriteSheetSnowMan : Engine.SpriteSheet
    {
        private enum animation
        {
            IDLE, THROWING
        }

        animation _animation;

        SpriteSheetSnowMan(string assetName) : base(assetName)
        {
            IsAnimated = true;
            ResetAnimation(0, 1, 1000, 64);
        }

        public override void Update(GameTime gameTime, Engine.Object obj)
        {
            animation tempAnim = _animation;
            base.Update(gameTime, obj);
            if(tempAnim != _animation)
            {
                SetupAnimation(obj);
            }
        }

        public override void UpdateAnimationState(Engine.Object obj)
        {
            base.UpdateAnimationState(obj);
            if(obj is EnemySnowMan)
            {
                EnemySnowMan snowMan = obj as EnemySnowMan;
                _animation = snowMan.Attacking ? animation.THROWING : animation.IDLE;
            }
        }

        public override void SetupAnimation(Engine.Object obj)
        {
            base.SetupAnimation(obj);
            switch(_animation)
            {
                case animation.IDLE:
                    ResetAnimation(0, 1, 1000, 64);
                    break;
                case animation.THROWING:
                    ResetAnimation(1, 5, 100, 320);
                    break;
            }
        }
    }
}
