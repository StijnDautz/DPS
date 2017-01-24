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
    class SpriteSheetPlayerSide : Engine.SpriteSheet
    {
        private bool _inAir;

        public SpriteSheetPlayerSide(string spriteSheet) : base(spriteSheet)
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
        }

        protected override string UpdateAnimationState(Engine.Object o)
        {
            string anim = "";
            if (o is Engine.Player)
            {
                var player = o as Engine.Player;
                anim = player.InAir ? "inAir" : "idle";
                if (player.Death)
                {
                    anim = "death";
                }
                else if(player.Attacking)
                {
                    anim = "attack";
                }
                else if(!_inAir && player.InAir)
                {
                    anim = "jumping";
                }
                else if(_inAir && !player.InAir)
                {
                    anim = "falling";
                }
                else if(player.Velocity.Y == 0 && player.Velocity.X != 0)
                {
                    anim = "walking";
                }
                _inAir = player.InAir;
            }
            return anim;
        }

        protected override void AfterLastFrame(Engine.Object obj)
        {
            base.AfterLastFrame(obj);
            if (obj is Player)
            {
                switch (CurrentSprite.name)
                {
                    case "jumping":
                        SwitchTo("inAir");
                        break;
                    case "inAir":
                        CanUpdate = true;
                        break;
                    case "falling":
                        CanUpdate = true;
                        break;
                    case "attack":
                        CanUpdate = true;
                        (obj as Player).Attacking = false;
                        break;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            base.Draw(spriteBatch, position);
        }
    }
}