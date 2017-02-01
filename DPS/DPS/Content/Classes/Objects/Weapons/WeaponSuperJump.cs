using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class WeaponSuperJump : Weapon
    {

        public WeaponSuperJump(string id, Engine.Object parent, SpriteSheet spriteSheet, Character owner, int damage) : base(id, parent, spriteSheet, owner, damage)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Position = World.Player.Position + new Vector2(-48, -100);
        }

        public override void OnCollision(Engine.Object collider)
        {
            base.OnCollision(collider);
            if (collider is DestructableObject)
            {
                if ((collider as DestructableObject).Type == "SuperJump")
                {
                    collider.Visible = false;
                    collider.CanCollide = false;
                    World.Remove(collider);
                }
                
            }
        }
    }
}