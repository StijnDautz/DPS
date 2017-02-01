using Engine;

namespace Content
{
    class UpgradePickup : Pickup
    {
        private int _damage;
        private int _speed;
        private int _health;
        private float _attackSpeed;

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public float AttackSpeed
        {
            get { return _attackSpeed; }
            set { _attackSpeed = value; }
        }

        public UpgradePickup(string id, Object parent, SpriteSheet spriteSheet, string description) : base(id, parent, spriteSheet, description)
        {

        }

        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            if (collider is Player)
            {
                World.Player.Health += _health;
                World.Player.TopDownSpeed += _speed;
                World.Player.SideSpeed += _speed;
                World.Player.AttackSpeed += _attackSpeed;
                World.Player.Damage += _damage;
            }
        }
    }
}