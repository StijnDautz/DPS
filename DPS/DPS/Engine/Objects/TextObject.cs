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
        private float _scale;


        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;

                //set new size, as the text has changed
                var textSize = _spriteFont.MeasureString(_text).ToPoint();
                BoundingBox = new Rectangle(0, 0, textSize.X, textSize.Y);
            }
        }

        public Vector2 Size
        {
            get
            { return _spriteFont.MeasureString(_text); }
        }

        public TextObject(string id, string assetname, Object parent) : base(id, parent)
        {
            _spriteFont = GameInstance.AssetManager.GetFont("Fonts/" + assetname);
            _color = Color.White;
            _text = "";
            _scale = 1;

            //calculate size of text and set boudingbox
            var textSize = _spriteFont.MeasureString(_text).ToPoint();
            BoundingBox = new Rectangle(0, 0, textSize.X, textSize.Y);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            if(Visible)
            {
                spriteBatch.DrawString(_spriteFont, _text, GlobalPosition - World.CameraPosition * Depth, _color, 0, Vector2.Zero, _scale, SpriteEffects.None, 0);
            }
        }

        public void FitIntoRectangle(Rectangle box)
        {
            //get the string Size
            var stringSize = _spriteFont.MeasureString(_text).ToPoint();

            //find the smallest axisScale and set _scale to that value
            float scaleX = (float)box.Width / stringSize.X;
            float scaleY = (float)box.Height / stringSize.Y;
            _scale = Math.Min(scaleX, scaleY);

            //change boundingBox, as scale was altered
            BoundingBox = new Rectangle(0, 0, (int)(Width * _scale), (int)(Height * _scale));
        }
    }
}



