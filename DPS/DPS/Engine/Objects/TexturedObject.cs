using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class TexturedObject : Object
    {
        private Texture _sprite;

        public TexturedObject(string id, string assetName) : base(id)
        {
            _sprite = new Texture(assetName);
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, _sprite.Width, _sprite.Height);
        }

        public override void Reset()
        {
            base.Reset();
            _sprite.Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _sprite.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            if(Parent is Map)
            {
                Map map = Parent as Map;
                _sprite.Draw(spriteBatch, Position + map.Position - map.World.CameraPosition);
            }
            else
            { _sprite.Draw(spriteBatch, Position); }
        }
    }
}