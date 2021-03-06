﻿using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class EnemyZombie : Enemy
    {
        Weapon _weapon;
        private int _walkSpeed, _sprintSpeed, _reactionRange, _attackRange, _walkLeftBoundary, _walkRightBoudary;
        private float _walkPath;
        
        public int WalkSpeed
        {
            get { return _walkSpeed; }
        }

        public int SprintSpeed
        {
            get { return _sprintSpeed; }
        }

        public EnemyZombie(Engine.Object parent) : base("zombie", parent, new SpriteSheetZombie("Textures/Characters/IceZombie"))
        {
            _reactionRange = 400;
            _attackRange = 130;
            _sprintSpeed = 250;
            _walkSpeed = 25;
            _walkLeftBoundary = -96;
            _walkRightBoudary = 96;
            AttackSpeed = 2300;
            Health = 300;
            Damage = 75;
            Mass = 1.1f;
            SFXManager = new SFXZombie(this);
            _weapon = new Weapon("weapon", World, new SpriteSheet("Textures/Hud/TimerFrame"), this, Damage);
            World.Add(_weapon);
            BoundingBox = new Rectangle(0, 0, 64, 89);
        }

        public override void Update(GameTime gameTime)
        {
            _weapon.Visible = false;
            base.Update(gameTime);
        }

        /*
         * Reset damage as well, as that has been affected by the highScoreScaling of enemies
         */
        public override void Reset()
        {
            base.Reset();
            Health = 300;
            Damage = 75;
            _weapon = new Weapon("weapon", World, new SpriteSheet("Textures/Hud/TimerFrame"), this, Damage);
            World.Add(_weapon);
        }

        protected override void UpdateBehaviour(GameTime gameTime)
        {
            //if not staggered update behaviour
            if (!IsStaggered)
            {
                base.UpdateBehaviour(gameTime);

                float elapedTime = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;

                Vector2 distanceToPlayer = World.Player.GlobalOrigin - GlobalOrigin;

                //Update player following behaviour
                //Check if player is in range to attack
                if (_attackRange > distanceToPlayer.Length())
                {
                    TryAttack = true;
                }
                //Check if player is in range to follow
                else if (_reactionRange > distanceToPlayer.Length())
                {
                    Speed = _sprintSpeed;
                    VelocityX = distanceToPlayer.X < 0 ? -_sprintSpeed : _sprintSpeed;
                }
                //if none of the above, walk and TryAttack = false
                else
                {
                    TryAttack = false;
                    Speed = _walkSpeed;
                    VelocityX = VelocityX < 0 && _walkPath > _walkLeftBoundary ? -_walkSpeed : _walkSpeed;
                    VelocityX = VelocityX > 0 && _walkPath < _walkRightBoudary ? _walkSpeed : -_walkSpeed;
                    _walkPath += Velocity.X * elapedTime;
                }
                _weapon.Position = Mirrored ? new Vector2(Position.X + Width, Position.Y + 30) : new Vector2(Position.X - _weapon.Width, Position.Y + 30);
            }
        }

        protected override void OnAttack()
        {
            base.OnAttack();
            _weapon.Visible = true;
        }

        protected override void UpdateCombat(int elapsedTime)
        {
            base.UpdateCombat(elapsedTime);
        }

        public override void OnDeath()
        {
            base.OnDeath();
            //if dead remove weapon from world
            World.Remove(_weapon);
        }

        public override void ScaleStatsWithHighScore(float highScoreModifier)
        {
            base.ScaleStatsWithHighScore(highScoreModifier);
            Damage = (int)(Damage * highScoreModifier);
            Health = (int)(Health * highScoreModifier);
        }
    }
}