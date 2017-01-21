using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class SpriteSheetHealthBar : Engine.SpriteSheet
    {
        private int _healthPercentage;

        public SpriteSheetHealthBar(string assetName) : base(assetName)
        {

        }

        public override void Update(GameTime gameTime, Engine.Object obj)
        {
            base.Update(gameTime, obj);
            var player = obj.World.Player;
            _healthPercentage = player.Health / player.MaxHealth;
        }

        protected override Rectangle getSourceRectangle(int frameToDraw)
        {
            return new Rectangle(frameToDraw, 0, _healthPercentage * Width, Height);
        }
    }
}
