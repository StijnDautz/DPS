using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Content
{
    class DescriptionBox : Engine.ObjectList
    {
        Engine.TexturedObject _box;
        Engine.TextObject _description;

        public int Spacing
        {
            set
            {
                //calculate new textBox
                var textBox = new Rectangle(0, 0, _box.Width - value * 2, _box.Height);

                //fit text into box and center it
                _description.FitIntoRectangle(textBox);
                _description.Position = new Vector2((Width - textBox.Width) / 2, Height / 2 - _description.Height / 2);
            }
        }

        public DescriptionBox(Engine.Object parent, string text) : base("DescriptionBox", parent)
        {
            //create TextObject
            _description = new Engine.TextObject("description", "Hud", this);
            _description.Text = text;
            _description.Color = Color.Gray;

            //create the box and its frame
            _box = new Engine.TexturedObject("box", this, new Engine.SpriteSheet("Textures/HUD/DescriptionBox"));
            var textBox = new Rectangle(0, 0, _box.Width - 10, _box.Height);

            //set boundingBox equal to the boundingBox of box
            BoundingBox = _box.BoundingBox;

            //make sure the text fits perfectly into the _textBox and center it
            _description.FitIntoRectangle(textBox);
            _description.Position = new Vector2((Width - textBox.Width) / 2, Height / 2 - _description.Height / 2);

            //add both parts of the descriptionBox in the correct order
            Add(_box);
            Add(_description);
        }
    }
}
