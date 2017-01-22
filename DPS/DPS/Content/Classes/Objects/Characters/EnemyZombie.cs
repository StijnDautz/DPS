using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Content
{
    //TODO fix SFX bug, where after playing attack sound the scream is not played again until changing orignal speed before attack
    class EnemyZombie : Engine.NPC
    {
        Engine.Weapon _weapon;
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

        public EnemyZombie(string id, Engine.Object parent, Engine.SpriteSheet spriteSheet, string chillScreamSFX, string crazyScreamSFX) : base(id, parent, spriteSheet)
        {
            _reactionRange = 400;
            _attackRange = 130;
            _sprintSpeed = 250;
            _walkSpeed = 25;
            _walkLeftBoundary = -96;
            _walkRightBoudary = 96;
            AttackSpeed = 2300;
            Health = 500;
            Mass = 1.1f;
            SFX.Add("chillScream", Engine.GameInstance.AssetManager.GetSoundEffect(chillScreamSFX + Engine.GameInstance.RNG.Next(1, 5).ToString()));
            SFX.Add("crazyScream", Engine.GameInstance.AssetManager.GetSoundEffect(crazyScreamSFX));
            OnDamagedSFX = "ZombieDamaged";
            AttackSFX = "zombieAttack";
            _weapon = new Engine.Weapon("weapon", World, new Engine.SpriteSheet("Hud/TimerFrame"), this, 75);
            World.Add(_weapon);
        }

        public override void Update(GameTime gameTime)
        {
            _weapon.Visible = false;
            int tempSpeed = Speed;
            base.Update(gameTime);
            if(tempSpeed != Speed)
            {
                string soundToPlay = Speed == _walkSpeed ? "chillScream" : "crazyScream";
                SFX.SwitchTo(soundToPlay);
            }
        }

        protected override void UpdateBehaviour(GameTime gameTime)
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

        protected override void OnAttack()
        {
            base.OnAttack();
            _weapon.Visible = true;
        }

        protected override void UpdateCombat(float elapsedTime)
        {
            base.UpdateCombat(elapsedTime);
        }
    }
}