using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{

    class TextObject : Object
    {
        private SpriteFont _spriteFont;
        private Color _color;
        private string _text;


        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public Vector2 Size
        {
            get
            { return _spriteFont.MeasureString(_text); }
        }

        public TextObject(string id, string assetname) : base(id)
        {
            _spriteFont = GameInstance.assetManager.GetFont(assetname);
            _color = Color.White;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            if(Visible)
            {
                spriteBatch.DrawString(_spriteFont, _text, Position, _color);
            }
        }
    }
}



