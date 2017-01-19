using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class UpgradePickup : Engine.Pickup
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

        public UpgradePickup(string id, Engine.Object parent, Engine.SpriteSheet spriteSheet, string description) : base(id, parent, spriteSheet, description)
        {

        }
    }
}
