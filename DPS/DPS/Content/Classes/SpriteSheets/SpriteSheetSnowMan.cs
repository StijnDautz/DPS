using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Content
{
    class SpriteSheetSnowMan : Engine.SpriteSheet
    {
        public SpriteSheetSnowMan(string assetName) : base(assetName)
        {
            IsAnimated = true;
            Add("idle", 0, 2, 400, 224, true);
            Add("attack", 1, 5, 200, 560, false);
            SwitchTo("idle");
            CanUpdate = true;
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

        protected override void AfterLastFrame(Engine.Object obj)
        {
            base.AfterLastFrame(obj);
            if(CurrentSprite.name == "attack")
            {
                CanUpdate = true;
            }
        }
    }
}