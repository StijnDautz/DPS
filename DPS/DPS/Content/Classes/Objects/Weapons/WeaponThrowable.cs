using Engine;

namespace Content
{
    class WeaponThrowable : Engine.Weapon
    {
        private bool _destroyOnCollision;

        public bool DestroyOnCollision
        {
            set { _destroyOnCollision = value; }
        }

        public WeaponThrowable(string id, Engine.Object parent, Engine.SpriteSheet spriteSheet, Engine.Object owner, int damage) : base(id, parent, spriteSheet, owner, damage)
        {

        }

        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            if(_destroyOnCollision)
            {
                World.Remove(this);
            }
        }
    }
}
