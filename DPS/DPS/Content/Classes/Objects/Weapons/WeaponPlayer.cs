using Microsoft.Xna.Framework;
using Engine;
using Microsoft.Xna.Framework.Graphics;

namespace Content
{
    class WeaponPlayer : Engine.Weapon
    {
        public WeaponPlayer(string id, Engine.Object parent, SpriteSheet spriteSheet, Character owner, int damage) : base(id, parent, spriteSheet, owner, damage)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var v = (GameInstance.InputManager.MousePosition + World.CameraPosition) - World.Player.GlobalOrigin;
            v.Normalize();
            v *= 120;
            Position = v + World.Player.Position;
            base.Draw(gameTime, spriteBatch);
        }
    }
}