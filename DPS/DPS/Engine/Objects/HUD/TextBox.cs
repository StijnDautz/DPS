using System.Text;
using Microsoft.Xna.Framework;

namespace Engine
{
    class TextBox : ObjectList
    {
        private TextObject _textObject;
        private StringBuilder _text;
        private Content.ButtonAllowTyping _buttonAllowTyping;

        public string Text
        {
            get { return _text.ToString(); }
        }

        public int Capacity
        {
            set { _text.Capacity = value; }
        }

        public TextBox(Object parent) : base("textBox", parent)
        {
            _text = new StringBuilder();

            //setup textObject
            _textObject = new TextObject("text", "Hud", this);
            _textObject.Color = new Color(124, 93, 72);

            _buttonAllowTyping = new Content.ButtonAllowTyping(this);

            //set boundingbox equal to the boundingbox of button
            BoundingBox = _buttonAllowTyping.BoundingBox;

            //add Objects
            Add(_buttonAllowTyping);
            Add(_textObject);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (_buttonAllowTyping.CanType)
            {
                //add pressed keys to string displayed on screen
                _text = GameInstance.InputManager.WriteToString(_text);

                //set the text, which is printed to the screen and resize it relative to the boundingBox
                _textObject.Text = _text.ToString();
                _textObject.FitIntoRectangle(new Rectangle((int)Position.X, (int)Position.Y, Width - 5, Height - 5));
                //center text on y axis
                _textObject.Position = new Vector2(0, Height / 2 - _textObject.Height / 2);
            }
        }
    }
}