using Microsoft.Xna.Framework;

namespace Engine
{
    class Character : TexturedObject
    {
        int _health, _damage, _speed, _maxHealth, _elapsedStaggerTime, _staggerDuration;
        double _attackSpeed, _attackTime;
        bool _tryAttack, _attacking, _death, _isStaggered;

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

        public bool IsStaggered
        {
            get { return _isStaggered; }
            set { _isStaggered = value; }
        }

        public int StaggerDuration
        {
            set { _staggerDuration = value; }
        }

        public Character(string id, Object parent, SpriteSheet spriteSheet) : base(id, parent, spriteSheet)
        {
            HasPhysics = true;
            CanCollide = true;
            CanBlock = true;
            _staggerDuration = 1000;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            int elapsedTime = gameTime.ElapsedGameTime.Milliseconds;

            UpdateCombat(elapsedTime);
        }

        //Updates the attack state
        protected virtual void UpdateCombat(int elapsedTime)
        {
            UpdateStaggerSystem(elapsedTime);
            _attackTime += elapsedTime;
             IsAttackReady();
        }

        protected virtual void OnAttack()
        {
            
        }

        public virtual void OnDamaged(int damage)
        {

        }

        public virtual void OnDeath()
        {

        }

        protected void IsAttackReady()
        {
            if (_attackTime > _attackSpeed)
            {
                if (_tryAttack)
                {
                    _tryAttack = false;
                    _attacking = true;
                    _attackTime = 0;
                    OnAttack();
                }
                else
                {
                    Attacking = false;
                }
            }
        }

        private void UpdateStaggerSystem(int elapsedTime)
        {
            //if character is staggered update elapsedStaggerTime and check whether the staggereffect is over or not
            if (_isStaggered)
            {
                _elapsedStaggerTime += elapsedTime;
                if (_elapsedStaggerTime > _staggerDuration)
                {
                    _isStaggered = false;
                    _elapsedStaggerTime = 0;
                }
            }
        }

        public virtual void ScaleStatsWithHighScore(float highScoreModifier)
        {
            
        }
    }
}