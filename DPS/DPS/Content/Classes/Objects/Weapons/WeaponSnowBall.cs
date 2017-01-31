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
            Mass = 0.4f;
        }
    }
}
