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
        private int _reactionRange;
        private Vector2 _distanceToPlayer;

        public EnemySnowMan(string id, Engine.Object parent, Engine.SpriteSheet spriteSheet) : base(id, parent, spriteSheet)
        {
            _reactionRange = 1500;
            AttackSpeed = 1800;
            Damage = 100;
            Health = 500;
            Mass = 2;
            SFXManager = new SFXSnowMan(this);
            BoundingBox = new Rectangle(0, 0, 112, 116);
        }

        protected override void UpdateBehaviour(GameTime gameTime)
        {
            base.UpdateBehaviour(gameTime);
            //update distance to player
            _distanceToPlayer = World.Player.GlobalPosition - GlobalOrigin;
            //enemy tries to attack when player is in range
            TryAttack = _reactionRange > _distanceToPlayer.Length();
        }

        protected override void OnAttack()
        {
            base.OnAttack();
            //setup weapon
            var snowball = new WeaponSnowBall("snowball", World, new Engine.SpriteSheet("Textures/Weapons/Snowball"), this, Damage);
            snowball.Position = Mirrored ? new Vector2(PositionX, PositionY + 30) : new Vector2(PositionX + Width - 20, PositionY + 30);

            //setup snowball velocity
            _distanceToPlayer.Normalize();
            snowball.Velocity = _distanceToPlayer * 800;
            World.Add(snowball);
        }
    }
}
