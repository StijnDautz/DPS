using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class SpriteSheetPlayerBig : SpriteSheetPlayer
    {
        public SpriteSheetPlayerBig(string assetName) : base(assetName)
        {
            IsAnimated = true;
            Add("idle", 0, 2, 320, 256, true);
            Add("walking", 1, 16, 40, 2048, true);
            Add("death", 2, 6, 110, 1152, false);
            Add("jumping", 3, 4, 53, 512, false);
            Add("inAir", 4, 3, 120, 384, true);
            Add("falling", 5, 5, 45, 640, false);
            Add("attack", 6, 4, 40, 1024, false);
            SwitchTo("idle");
        }

        public override void Update(GameTime gameTime, Engine.Object obj)
        {
            base.Update(gameTime, obj);
            obj.BoundingBox = new Rectangle(0, 0, 128, FrameHeight);
        }
    }
}
