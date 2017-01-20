using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Content
{
    class EnemySnowMan : Engine.NPC
    {
        private int _reactionRange, _elapsedTime, _delay;
        EnemySnowMan(string id, Engine.Object parent, Engine.SpriteSheet spriteSheet) : base(id, parent, spriteSheet)
        {

        }

        protected override void UpdateBehaviour(GameTime gameTime)
        {
            base.UpdateBehaviour(gameTime);
            Vector2 distanceToPlayer = World.Player.GlobalOrigin - GlobalOrigin;
            if(_reactionRange < distanceToPlayer.Length())
            {
                Engine.TexturedObject snowball = new Engine.TexturedObject("snowball", World, new Engine.SpriteSheet("Textures/Items/Frozen_Key"));
                distanceToPlayer.Normalize();
                snowball.Velocity = distanceToPlayer * 200;
                snowball.HasPhysics = true;
                snowball.CanCollide = true;
                World.Add(snowball);
            }
        }
    }
}
