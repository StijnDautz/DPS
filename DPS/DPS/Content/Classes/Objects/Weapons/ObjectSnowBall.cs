using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Content
{
    class ObjectSnowBall : Engine.TexturedObject
    {
        public ObjectSnowBall(string id, Engine.Object parent, Engine.SpriteSheet spriteSheet) : base(id, parent, spriteSheet)
        {
            HasPhysics = true;
            CanCollide = true;
            CanBlock = true;
        }

        public override void OnCollision(Engine.Object collider)
        {
            base.OnCollision(collider);
            if(!(collider is EnemySnowMan))
            {
                World.Remove(this);
            }
        }
    }
}
