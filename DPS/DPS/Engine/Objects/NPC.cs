using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Engine
{
    class NPC : TexturedObject, ICharacter
    {
        private string _name;
        private int _health;
        private Inventory _inventory;
        private movementState _movementState;
        private float _attackSpeed;
        private float _attackDuration;
        private float _walkSpeed;
        private float _runSpeed;
        private bool _attacking;

        public string Name
        {
            get { return _name; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public movementState MovementState
        {
            get { return _movementState; }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public NPC(string id, string assetName, string name) : base(id, assetName)
        {
            _name = name;
            _health = 100;
            _inventory = new Inventory(id + "inventory");
            _attackDuration = 0;
            _attacking = false;
            _attackSpeed = 1;
            _walkSpeed = 200;
            _runSpeed = 500;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float elapsedTime = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            _movementState = UpdateMovementState(elapsedTime);
        }

        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
        
            base.OnCollision(collider);
            if (collider is ICharacter)
            {
                var character = collider as ICharacter;
                character.Health -= _inventory.EquipedWeapon.Damage;
            }   
        }

        private movementState UpdateMovementState(float elapsedTime)
        {
            if (_attacking && (_attackDuration += elapsedTime) > _attackSpeed)
            {
                _attacking = false;
                _attackDuration = 0;
            }
            if (_attacking)
            {
                return InAir ? movementState.JUMPATTACK : movementState.ATTACK;
            }
            return InAir ? VelocityY > 0 ? movementState.JUMPING : movementState.FALLING :
                VelocityX == 0 ? movementState.IDLE :
                VelocityX == _walkSpeed ? movementState.WALKING :
                movementState.RUNNING;
        }
    }
}
