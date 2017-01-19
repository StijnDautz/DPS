using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Texture
    {
        private Texture2D _sprite;
        private int _frames, _currentFrame, _frameTime, _elapsedTime, _maxIndex, _index, _width;
        private bool _isAnimated, _mirrored;

        public bool IsAnimated
        {
            get { return _isAnimated; }
            set { _isAnimated = value; }
        }

        public Texture2D Sprite
        {
            get { return _sprite; }
        }

        public int Width
        {
            get { return _width / _frames; }
        }

        public int Height
        {
            get { return _sprite.Height / _maxIndex; }
        }

        public int Frames
        {
            get { return _frames; }
            set
            {
                _frames = value;
                if(value > 1)
                { _isAnimated = true; }
            }
        }

        public int Maxindex
        {
            set { _maxIndex = value; }
        }

        public bool Mirrored
        {
            get { return _mirrored; }
            set { _mirrored = value; }
        }

        public int FrameTime
        {
            set { _frameTime = value; }
        }

        public Texture(string assetName)
        {
            _sprite = GameInstance.AssetManager.GetTexture(assetName);
            Frames = 1;
            _maxIndex = 1;
            _currentFrame = 0;
            _frameTime = 200;
            _width = _sprite.Width;
        }

        public void Reset()
        {
            _elapsedTime = 0;
            _currentFrame = 1;
        }

        public void Update(GameTime gameTime)
        {
            //if Texture isAnimated, Update it
            if (_isAnimated == true)
            {
                _elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (_elapsedTime > _frameTime)
                {
                    _currentFrame++;
                    if (_currentFrame > _frames - 1)
                    {
                        _currentFrame = 0;
                    }
                    _elapsedTime = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            SpriteEffects effect = SpriteEffects.None;
            int drawFrame = _currentFrame * Width;
            if(_mirrored)
            {
                drawFrame = (_frames - _currentFrame) * Width;
                effect = SpriteEffects.FlipHorizontally;
            }

            spriteBatch.Draw(_sprite, position, new Rectangle(drawFrame, _index * Height, Width, Height), Color.White, 0, Vector2.Zero, 1, effect, 0);
        }

        public void SetupAnimation(int index, int frames, int frameTime, int width)
        {
            _elapsedTime = 0;
            _currentFrame = 0;
            _index = index;
            _frames = frames;
            _frameTime = frameTime;
            _width = width;         
        }

    }
}