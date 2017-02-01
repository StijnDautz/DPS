using Engine;

namespace Content
{
    class WeaponSnowBall : Weapon
    {
        public WeaponSnowBall(string id, Object parent, SpriteSheet spriteSheet, Character owner, int damage) : base(id, parent, spriteSheet, owner, damage)
        {
            HasPhysics = true;
            CanCollide = true;
            Mass = 0.4f;
        }

        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            if(collider != Owner)
            {
                World.Remove(this);
            }
        }
    }

}