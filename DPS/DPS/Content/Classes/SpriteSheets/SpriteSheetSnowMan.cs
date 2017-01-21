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

        public SpriteSheetSnowMan(string assetName) : base(assetName)
        {
            IsAnimated = true;
            ResetAnimation(0, 2, 400, 224);
            Maxindex = 2;
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

        protected override void UpdateAnimationState(Engine.Object obj)
        {
            base.UpdateAnimationState(obj);
            Mirrored = obj.World.Player.GlobalPosition.X > obj.GlobalPosition.X ? true : false;
            if(obj is EnemySnowMan)
            {
                EnemySnowMan snowMan = obj as EnemySnowMan;
                _animation = snowMan.Attacking ? animation.THROWING : animation.IDLE;
            }
        }

        protected override void SetupAnimation(Engine.Object obj)
        {
            base.SetupAnimation(obj);
            switch(_animation)
            {
                case animation.IDLE:
                    ResetAnimation(0, 2, 400, 224);
                    break;
                case animation.THROWING:
                    ResetAnimation(1, 5, 200, 560);
                    break;
            }
        }

        protected override void AfterLastFrame(Engine.Object obj)
        {
            base.AfterLastFrame(obj);
            if(obj is EnemySnowMan)
            {
                EnemySnowMan snowMan = obj as EnemySnowMan;
                if (_animation == animation.THROWING)
                {
                    snowMan.Attacking = false;
                }
            }
        }
    }
}
