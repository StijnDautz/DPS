using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    class Character : Pawn, ICharacter
    {
        private string _name;
        private movementState _movementState;
        private Inventory _inventory;
        private float _attackSpeed;
        private float _attackDuration;
        private float _walkSpeed;
        private float _runSpeed;
        private int _health;
        private bool _attacking;
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
            get { return _inventory; }
        }


        public Character(string id, string assetName, string name, int age, bool gender) : base(id, assetName)
        {
            _name = name;
            _inventory = new Inventory(id + "inventory");
            HasPhysics = true;
            CanCollide = true;
            canBlock = true;
            _attackSpeed = 1;
            _attackDuration = 0;
            _walkSpeed = 400;
            _runSpeed = 600;
            _attacking = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float elapsedTime = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            _movementState = UpdateMovementState(elapsedTime);
        }

        /*TODO Improve this method look at UpdateMovementState <3*/
        public override void HandleInput(GameTime gameTime)
        {
            base.HandleInput(gameTime);

            float speed = GameInstance.InputManager.isKeyHolding(Keys.LeftShift) ? _runSpeed : _walkSpeed;
            if (CanMove)
            {
                if (ObjectList.World.IsTopDown)
                {
                    HandleTopDownInput(speed);
                }
                else
                {
                    HandleSideInput(speed);
                }
            }
            else
            {
                Velocity = Vector2.Zero;
            }                  
        }

        private void HandleTopDownInput(float speed)
        {
            if (GameInstance.InputManager.isKeyHolding(Keys.D))
            {
                VelocityX = speed;
                Mirrored = false;
            }
            else if (GameInstance.InputManager.isKeyHolding(Keys.A))
            {
                VelocityX = -speed;
                Mirrored = true;
            }
            else
            {
                VelocityX = 0;
            }
            if(GameInstance.InputManager.isKeyHolding(Keys.S))
            {
                VelocityY = speed;
            }
            else if(GameInstance.InputManager.isKeyHolding(Keys.W))
            {
                VelocityY = -speed;
            }
            else
            {
                VelocityY = 0;
            }                                       
        }

        private void HandleSideInput(float speed)
        {
            if (GameInstance.InputManager.isKeyHolding(Keys.D))
            {
                VelocityX = speed;
                Mirrored = false;
            }
            else if (GameInstance.InputManager.isKeyHolding(Keys.A))
            {
                VelocityX = -speed;
                Mirrored = true;
            }
            else
            {
                VelocityX = 0;
            }
            if (GameInstance.InputManager.isKeyPressed(Keys.Space))
            {
                Velocity = new Vector2(VelocityX, -600);
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

        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            if(collider is ICharacter)
            {
                var character = collider as ICharacter;
                character.Health -= _inventory.EquipedWeapon.Damage;
            }
        }
    }
}