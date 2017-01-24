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
    class SpriteSheetPlayer : Engine.SpriteSheet
    {
        private bool _inAir;
        private Texture2D _spriteSheetBig;
        private Texture2D _spriteSheetSmall;

        

        public SpriteSheetPlayer(string spriteSheetBig, string spriteSheetSmall) : base(spriteSheetSmall)
        {
            IsAnimated = true;
            Add("idle", 0, 2, 320, 256, true);
            Add("walking", 1, 16, 40, 2048, true);
            Add("death", 2, 6, 110, 1152, false);
            Add("jumping", 3, 4, 53, 512, false);
            Add("inAir", 4, 3, 120, 384, true);
            Add("falling", 5, 5, 45, 640, false);
            Add("attack", 6, 7, 40, 1792, false);
            Add("attackUp", 7, 8, 150, 2048, false);
            SwitchTo("idle");
            _spriteSheetBig = GameInstance.AssetManager.GetTexture(spriteSheetBig);
            _spriteSheetSmall = GameInstance.AssetManager.GetTexture(spriteSheetSmall);
        }

        public override void Update(GameTime gameTime, Engine.Object obj)
        {
            base.Update(gameTime, obj);
            //update spriteSheet depending on world type
            if(obj.World.IsTopDown)
            {
                if(spriteSheet != _spriteSheetSmall)
                {
                    spriteSheet = _spriteSheetSmall;
                }
            }
            else
            {
                if(spriteSheet != _spriteSheetBig)
                {
                    spriteSheet = _spriteSheetBig;
                }
            }
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