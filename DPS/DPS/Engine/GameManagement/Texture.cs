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
        private int _frames;
        private int _currentFrame;
        private int _frameTime;
        private int _elapsedTime;
        private bool _isAnimated;
        private bool _mirror;

        public Texture2D Sprite
        {
            get { return _sprite; }
        }

        public int Width
        {
            get { return _sprite.Width / _frames; }
        }

        public int Height
        {
            get { return _sprite.Height; }
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

        public bool Mirror
        {
            set { _mirror = value; }
        }

        public int FrameTime
        {
            set { _frameTime = value; }
        }

        public Texture(string assetName)
        {
            _sprite = GameInstance.AssetManager.GetTexture(assetName);
            _frames = 1;
            _currentFrame = 1;
            _frameTime = 200;
            _isAnimated = false;
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
                    if (_currentFrame > _frames)
                    {
                        _currentFrame = 1;
                    }
                    _elapsedTime = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(_sprite, position);
        }
    }
}