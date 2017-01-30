using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    //TODO make this an objectList and add background object, which is used to set collisionBox as well
    class TextBox : ObjectList
    {
        TextObject _textObject;
        StringBuilder _text;
        Content.ButtonAllowTyping _buttonAllowTyping;

        public int Capacity
        {
            set { _text.Capacity = value; }
        }

        public TextBox(Object parent) : base("textBox", parent)
        {
            _text = new StringBuilder();

            _textObject = new TextObject("text", "Hud", this);
            _textObject.Color = Color.Gray;
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
                _textObject.FitIntoRectangle(BoundingBox);
                //center text on y axis
                _textObject.Position = new Vector2(0, Height / 2 - _textObject.Height / 2);

            }
        }
    }
}
