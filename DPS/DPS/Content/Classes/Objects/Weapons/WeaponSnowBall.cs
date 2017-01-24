using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Content
{
    class WeaponSnowBall : Engine.Weapon
    {
        public WeaponSnowBall(string id, Engine.Object parent, Engine.SpriteSheet spriteSheet, Engine.Character owner, int damage) : base(id, parent, spriteSheet, owner, damage)
        {
            HasPhysics = true;
            CanCollide = true;
            Mass = 0.4f;
        }

        public override void OnCollision(Engine.Object collider)
        {
            if (!(collider is EnemySnowMan))
            {
                if (collider is Character)
                {
                     DealDamage(collider as Character);
                }
                World.Remove(this);
            }
        }
    }
}
