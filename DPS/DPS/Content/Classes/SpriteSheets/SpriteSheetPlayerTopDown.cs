using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Content
{ 
    class SpriteSheetPlayerTopDown : Engine.SpriteSheet
    {
        public SpriteSheetPlayerTopDown(string assetName) : base(assetName)
        {
            IsAnimated = true;
            Add("idle", 0, 2, 320, 128, true);
            Add("walking", 1, 16, 40, 1024, true);
            SwitchTo("idle");
        }

        protected override string UpdateAnimationState(Engine.Object o)
        {
            string anim = "idle";
            if(o.Velocity.Length() != 0)
            {
                anim = "walking";
            }
            return anim;
        }
    }
}
