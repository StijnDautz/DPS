using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Content
{
    class TerrorSheetCharacter : Engine.SpriteSheet
    {
        private enum animation
        {
            WALKING, RUNNING
        }

        animation _animation;

        public TerrorSheetCharacter(string assetName) : base(assetName)
        {
            IsAnimated = true;
            ResetAnimation(0, 8, 40, 768);
        }

        public override void UpdateAnimationState(Engine.Object obj)
        {
            animation tempAnim = _animation;
            if (obj is Terror)
            {
                Terror zombie = obj as Terror;
                _animation = obj.VelocityX > zombie.WalkSpeed || obj.VelocityX < -zombie.WalkSpeed ? animation.RUNNING : animation.WALKING;
            }
            if (tempAnim != _animation)
            {
                SetupAnimation(obj);
            }
            Mirrored = obj.Velocity.X < 0 ? false : true;
        }

        public override void SetupAnimation(Engine.Object obj)
        {
            if (obj is Terror)
            {
                Terror zombie = obj as Terror;
                base.SetupAnimation(obj);
                switch (_animation)
                {
                    case animation.WALKING:
                        ResetAnimation(0, 8, 300, 768);
                        break;
                    case animation.RUNNING:
                        ResetAnimation(0, 8, 40, 768);
                        break;
                }
            }
        }
    }
}