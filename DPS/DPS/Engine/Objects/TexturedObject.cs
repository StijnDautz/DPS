using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class TexturedObject : Object
    {
        private SpriteSheet _sprite;

        public bool Mirrored
        {
            get { return _sprite.Mirrored; }
            set { _sprite.Mirrored = value; }
        }

        public SpriteSheet SpriteSheet
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public TexturedObject(string id, Object parent, SpriteSheet spriteSheet) : base(id, parent)
        {
            _sprite = spriteSheet;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, _sprite.Width, _sprite.Height);
        }

        public override void Reset()
        {
            base.Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _sprite.Update(gameTime, this);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            if (Visible)
            {
                _sprite.Draw(spriteBatch, GlobalPosition - World.CameraPosition * Depth);
            }
        }
    }
}