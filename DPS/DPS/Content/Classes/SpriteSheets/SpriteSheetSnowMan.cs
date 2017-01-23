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
        public SpriteSheetSnowMan(string assetName) : base(assetName)
        {
            IsAnimated = true;
            Add("idle", 0, 2, 400, 224, true);
            Add("attack", 1, 5, 200, 260, false);
            SwitchTo("idle");
        }

        protected override string UpdateAnimationState(Engine.Object obj)
        {
            string anim = "idle";
            Mirrored = obj.World.Player.GlobalPosition.X > obj.GlobalPosition.X ? true : false;
            if(obj is EnemySnowMan)
            {
                if((obj as EnemySnowMan).Attacking)
                {
                    anim = "attack";
                }
            }
            return anim;
        }
    }
}