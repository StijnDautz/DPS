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
        int _health, _damage, _speed;
        double _attackSpeed, _attackTime;
        bool _attacking;

        public int Health
        {
            get { return _health; }
            set { _health = value; }
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
            float elapsedTime = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            UpdateCombat(elapsedTime);
        }

        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            if (collider is Character)
            {
                Character character = collider as Character;
                if (_attacking && _attackTime < _attackSpeed)
                {
                     character._health -= _damage;
                    _attacking = false;
                }
            }
        }

        private void UpdateCombat(float elapsedTime)
        {
            //update attackTime
            _attackTime += elapsedTime;

            //if attackTime has been long enough and character wants to attack, start new attack by resetting attackTime to 0 
            if (_attacking && _attackTime > _attackSpeed)
            {
                _attackTime = 0;
                _attacking = false;
            }
        }
    }
}
