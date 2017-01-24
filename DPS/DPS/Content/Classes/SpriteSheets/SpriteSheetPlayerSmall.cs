using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class SpriteSheetPlayerSmall : SpriteSheetPlayer
    {
        public SpriteSheetPlayerSmall(string assetName) : base(assetName)
        {
            IsAnimated = true;
            Add("idle", 0, 2, 320, 128, true);
            Add("walking", 1, 16, 40, 1024, true);
            Add("death", 2, 6, 110, 576, false);
            Add("jumping", 3, 4, 53, 256, false);
            Add("inAir", 4, 3, 120, 192, true);
            Add("falling", 5, 5, 45, 320, false);
            Add("attack", 6, 4, 40, 256, false);
            SwitchTo("idle");
        }

        public override void Update(GameTime gameTime, Engine.Object obj)
        {
            base.Update(gameTime, obj);
            obj.BoundingBox = new Rectangle(0, 0, 64, FrameHeight);
        }
    }
}
