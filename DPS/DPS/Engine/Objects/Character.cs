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
        int _health, _damage, _speed, _maxHealth;
        double _attackSpeed, _attackTime;
        bool _tryAttack, _attacking, _death;

        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                if(_health > _maxHealth)
                {
                    _maxHealth = _health;
                }
            }
        }

        public bool TryAttack
        {
            get { return _tryAttack; }
            set { _tryAttack = value; }
        }

        public string OnDamagedSFX
        {
            set { SFX.Add("Damaged", GameInstance.AssetManager.GetSoundEffect(value)); }
        }

        public string AttackSFX
        {
            set { SFX.Add("Attack", GameInstance.AssetManager.GetSoundEffect(value)); }
        }

        public int MaxHealth
        {
            get { return _maxHealth; }
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

        public bool Death
        {
            get { return _death; }
            set { _death = value; }
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
            UpdateCombat(elapsedTime);
        }

        //Updates the attack state
        protected virtual void UpdateCombat(float elapsedTime)
        {
            _attackTime += elapsedTime;
            //TODO sync attackSpeed with anim speed
            /* if tryAttack && canAttack -> attack
             * This variable may be set to false when the fitting animation has ended
             * else when attackTime took longer then the attackSpeed*/
             IsAttackReady();
        }

        protected virtual void OnAttack()
        {
            SFX.SwitchTo("Attack");
        }

        protected void IsAttackReady()
        {
            if (_attackTime > _attackSpeed)
            {
                if (_tryAttack)
                {
                    //OnAttack
                    _tryAttack = false;
                    _attacking = true;
                    _attackTime = 0;
                    OnAttack();
                }
            }
        }
    }
}
