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
        public enum movementState
        {
            IDLE, WALKING, RUNNING, JUMPING, FALLING, ATTACK, JUMPATTACK, DEATH,
        }

        movementState _movementState;
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
           
        public Character(string id, Object parent, string assetName) : base(id, parent, assetName)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float elapsedTime = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            UpdateCombat(elapsedTime);
            UpdateMovementState(elapsedTime);
            UpdateAnimationState();
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
            }
            //else the character cannot attack
            else
            {
                _attacking = false;
            }
        }


        private void UpdateMovementState(float elapsedTime)
        {
            if (_attacking && (_attackTime += elapsedTime) > _attackSpeed)
            {
                _attacking = false;
                _attackTime = 0;
            }
            if (_attacking)
            {
                _movementState = InAir ? movementState.JUMPATTACK : movementState.ATTACK;
            }
            if(InAir)
            {
                _movementState = VelocityY > 0 ? movementState.JUMPING : movementState.FALLING;
            }
            else
            {
                if(Velocity.X == 0)
                {
                    _movementState = movementState.IDLE;
                }
                else
                {
                    _movementState = movementState.WALKING;
                }
            }
        }

        public override void UpdateAnimationState()
        {
            switch(_movementState)
            {
                case movementState.IDLE: SetupAnimation(0, 2, 320, 128, new Rectangle((int)Position.X + 15, (int)Position.Y, 34, 72));
                    break;                
                case movementState.WALKING: SetupAnimation(1, 16, 150, 1024, new Rectangle((int)Position.X + 15, (int)Position.Y, 34, 72));
                    break;
                case movementState.RUNNING: SetupAnimation(1, 16, 20, 1024, new Rectangle((int)Position.X + 15, (int)Position.Y, 34, 72));
                    break;
                case movementState.DEATH: SetupAnimation(2, 6, 50, 976, new Rectangle((int)Position.X + 15, (int)Position.Y, 34, 72));
                    break;
                case movementState.JUMPING: SetupAnimation(3, 12, 35, 768, new Rectangle((int)Position.X + 15, (int)Position.Y, 34, 72));
                    break;
            }

        }
    }
}
