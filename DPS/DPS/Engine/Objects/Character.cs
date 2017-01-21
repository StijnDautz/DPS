using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Engine
{
    class Character : TexturedObject
    {
        Weapon _weapon;
        int _health, _damage, _speed, _maxHealth;
        double _attackSpeed, _attackTime;
        bool _tryAttack, _attacking;

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

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
        
        public double AttackSpeed
        {
            get { return _attackSpeed; }
            set { _attackSpeed = value; }
        }

        public bool Attacking
        {
            get { return _attacking; }
            set { _attacking = value; }
        }

        public Weapon Weapon
        {
            set { _weapon = value; }
        }

        public Character(string id, Object parent, SpriteSheet spriteSheet) : base(id, parent, spriteSheet)
        {
            HasPhysics = true;
            CanCollide = true;
            CanBlock = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float elapsedTime = (float)gameTime.ElapsedGameTime.Milliseconds;
            if(_weapon != null)
            {
                UpdateCombat(elapsedTime);
            }
        }

        //Updates the attack state
        private void UpdateCombat(float elapsedTime)
        {
            _attackTime += elapsedTime;
            //TODO sync attackSpeed with anim speed
            /* if tryAttack && canAttack -> attack
             * This variable may be set to false when the fitting animation has ended
             * else when attackTime took longer then the attackSpeed*/
            if(_attackTime > _attackSpeed)
            {
                if(_tryAttack)
                {
                    _attacking = true;
                    _attackTime = 0;
                }
                else
                {
                    _attacking = false;
                }
            }
        }
    }
}
