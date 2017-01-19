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

        public bool Mirrored
        {
            get { return _sprite.Mirrored; }
            set { _sprite.Mirrored = value; }
        }

        public bool IsAnimated
        {
            set { _sprite.IsAnimated = value; }
        }

        public TexturedObject(string id, Object parent, string assetName) : base(id, parent)
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
            if (this is Character)
            {
                int x = 0;
            }
            _sprite.Draw(spriteBatch, GlobalPosition - World.CameraPosition * Depth);
        }

        public virtual void UpdateAnimationState()
        {

        }

        public void SetupAnimation(int index, int frames, int frameTime, int width, Rectangle boudingBox)
        {
            _sprite.SetupAnimation(index, frames, frameTime, width);
            BoundingBox = boudingBox;
        }

        public void SetupSpriteSheet(int maxIndex)
        {
            _sprite.Maxindex = maxIndex;
        }
    }
}