using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Engine
{
    class Weapon : TexturedObject
    {
        private int _damage;
        private Character _owner;

        public int Damage
        {
            set { _damage = value; }
        }

        public Weapon(string id, Object parent, SpriteSheet spriteSheet, Character owner, int damage) : base(id, parent, spriteSheet)
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

                //if characters health is <= 0 the character is death and it should be removed from the world
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

            //get vector from player to character
            int x = 200;
            if(World.Player.GlobalPosition.X - character.GlobalPosition.X > 0)
            {
                x = -x;
            }
            character.Velocity += new Vector2(x, -100);

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