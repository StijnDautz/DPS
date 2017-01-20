using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Content
{
    class SpriteSheetZombie : Engine.SpriteSheet
    {
        private enum animation
        {
            WALKING, RUNNING
        }

        animation _animation;

        public SpriteSheetZombie(string assetName) : base(assetName)
        {
            IsAnimated = true;
            ResetAnimation(0, 4, 300, 248);
        }

        public override void UpdateAnimationState(Engine.Object obj)
        {
            animation tempAnim = _animation;
            if(obj is EnemyZombie)
            {
                EnemyZombie zombie = obj as EnemyZombie;
                _animation = obj.VelocityX > zombie.WalkSpeed || obj.VelocityX < -zombie.WalkSpeed ? animation.RUNNING : animation.WALKING;
            }     
            if(tempAnim != _animation)
            {
                SetupAnimation(obj);
            }
            Mirrored = obj.Velocity.X < 0 ? false : true;
        }

        public override void SetupAnimation(Engine.Object obj)
        {
            if(obj is EnemyZombie)
            {
                EnemyZombie zombie = obj as EnemyZombie;
                base.SetupAnimation(obj);
                switch (_animation)
                {
                    case animation.WALKING:
                        ResetAnimation(0, 4, 300, 248);
                        break;
                    case animation.RUNNING:
                        ResetAnimation(0, 4, 40, 248);
                        break;
                }
            }
        }
    }
}