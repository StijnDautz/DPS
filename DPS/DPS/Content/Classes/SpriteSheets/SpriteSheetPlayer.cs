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
    abstract class SpriteSheetPlayer : Engine.SpriteSheet
    {
        private bool _inAir;

        public SpriteSheetPlayer(string spriteSheet) : base(spriteSheet)
        {

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