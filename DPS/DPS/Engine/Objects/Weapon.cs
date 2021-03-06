﻿using Microsoft.Xna.Framework;

namespace Engine
{
    class Weapon : TexturedObject
    {
        private int _damage;
        private Object _owner;

        public int Damage
        {
            set { _damage = value; }
            get { return _damage; }
        }

        public Object Owner
        {
            get { return _owner; }
        }

        public Weapon(string id, Object parent, SpriteSheet spriteSheet, Object owner, int damage) : base(id, parent, spriteSheet)
        {
            _damage = damage;
            _owner = owner;
            CanCollide = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //as long as object doesnt move, make sure it is positioned according to its owner position
        }

        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);

            if (collider != _owner && collider is Character)
            {
                var character = collider as Character;
                //deal damage to the character that is hit
                DealDamage(character);

                //call OnDamaged
                character.OnDamaged(_damage);

                //if characters health is <= 0 the character is death and it should be removed from the worldd
                if (character.Health <= 0)
                {
                    character.OnDeath();
                    if (!(character is Player))
                    {
                        World.Remove(character);
                    }
                }
            }
            if (collider != _owner && collider is DestructableObject && (collider as DestructableObject).Type == "Normal")
            {
                DealDamage(collider as DestructableObject);
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

            //add to damage to totaldamage taken
            if(character is Player)
            {
                Content.HighScoreManager.TotalDamageTaken += _damage;
            }

            //check if collision was on left or right
            character.Velocity = character.GlobalPosition.X > GlobalPosition.X ? new Vector2(200, 100) : new Vector2(-200, 100);

            //stagger the character, this way the velocity wont be changed immediately in next Update cycle and will result in a knockback effect
            character.IsStaggered = true;
        }

        protected void DealDamage(DestructableObject block)
        {
            block.Visible = false;
            block.CanCollide = false;
            World.Remove(block);
        }
    }
}