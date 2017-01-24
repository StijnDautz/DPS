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
    class SpriteSheetZombie : Engine.SpriteSheet
    {
        public SpriteSheetZombie(string assetName) : base(assetName)
        {
            IsAnimated = true;
            Add("walking", 0, 4, 300, 256, true);
            Add("running", 0, 4, 40, 256, true);
            SwitchTo("walking"); 
            MaxIndex = 1;
        }

        protected override string UpdateAnimationState(Engine.Object obj)
        {
            string anim = "walking";
            if (obj is EnemyZombie)
            {
                var zombie = obj as EnemyZombie;
                if (zombie.Speed == zombie.SprintSpeed)
                {
                    anim = "running";
                }
                Mirrored = obj.Velocity.X < 0 ? false : true;
            }
            return anim;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            base.Draw(spriteBatch, position);
        }
    }
}