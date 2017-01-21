using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Weapon : TexturedObject
    {
        private int _damage;
        private Character _owner;

        public int Damage
        {
            set { _damage = value; }
        }

        public Weapon(string id, Object parent, SpriteSheet spriteSheet, Character owner, int damage) : base(id, parent, spriteSheet)
        {
            _damage = damage;
            _owner = owner;
        }

        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            if (collider is Character)
            {
                DealDamage(collider as Character);
            }
        }

        protected void DealDamage(Character character)
        {
            //deal damage
            character.Health -= _damage;
            //if its health < 0, remove it cause it is death
            if (character.Health <= 0)
            {
                character.Death = true;
            }
        }
    }
}