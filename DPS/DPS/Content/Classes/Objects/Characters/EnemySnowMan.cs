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
        private int _reactionRange, _delay, _elapsedTime;
        public EnemySnowMan(string id, Engine.Object parent, Engine.SpriteSheet spriteSheet) : base(id, parent, spriteSheet)
        {
            _reactionRange = 1500;
            _delay = 1800;
            Damage = 100;
            Health = 200;
        }

        protected override void UpdateBehaviour(GameTime gameTime)
        {
            base.UpdateBehaviour(gameTime);
            Vector2 distanceToPlayer = World.Player.GlobalPosition - GlobalOrigin;
            _elapsedTime += gameTime.ElapsedGameTime.Milliseconds;

            if(_reactionRange > distanceToPlayer.Length() && _elapsedTime > _delay)
            {
                _elapsedTime = 0;
                var snowball = new WeaponSnowBall("snowball", World, new Engine.SpriteSheet("Textures/Weapons/Snowball"), this, Damage);
                snowball.Position = Mirrored ? new Vector2(PositionX, PositionY + 30) : new Vector2(PositionX + Width - 20, PositionY + 30);
                distanceToPlayer.Normalize();
                snowball.Velocity = distanceToPlayer * 600;
                World.Add(snowball);
                Attacking = true;
            }
        }
    }
}
