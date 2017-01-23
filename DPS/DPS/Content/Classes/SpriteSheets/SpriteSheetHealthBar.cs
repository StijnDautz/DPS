using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Content
{
    class SpriteSheetHealthBar : Engine.SpriteSheet
    {
        private double _healthPercentage;

        public SpriteSheetHealthBar(string assetName) : base(assetName)
        {

        }

        public override void Update(GameTime gameTime, Engine.Object obj)
        {
            base.Update(gameTime, obj);
            var player = obj.World.Player;
            _healthPercentage = (double)player.Health / player.MaxHealth;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int offset = (int)((1 - _healthPercentage) * Height);
            spriteBatch.Draw(Sprite, new Vector2(position.X, position.Y + offset), new Rectangle(0, offset, Width, Height), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }
    }
}
