using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class WeaponBomb : Engine.Weapon
    {
        public WeaponBomb(Object parent, Object owner) : base("bomb", parent, new Engine.SpriteSheet("Textures/Weapons/bomb"), owner, 300)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void OnCollision(Object collider)
        {
            //if weapon is not owner deal damage and spawn explosion
            if (collider != Owner)
            {
                //calculate damage based on distance to collider
                Damage = (int)(collider.GlobalOrigin - GlobalOrigin).Length();
                if (Damage < 20)
                {
                    Damage = 0;
                }
                base.OnCollision(collider);

                //remove this object and spawn explosion effect
                World.Remove(this);

                var explosion = new TexturedObject("explosion", World, new SpriteSheetExplosion());
                explosion.Position = new Vector2(GlobalPosition.X - 100, GlobalPosition.Y - 100);
                World.Add(explosion);
            }
        }
    }
}