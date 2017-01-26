using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Engine
{
    class Slider : ObjectList
    {
        bool _dragged;
        TexturedObject _bar;
        TexturedObject _slider;

        public Slider(string id, Object parent, SpriteSheet spriteSheetBar, SpriteSheet spriteSheetSlider) : base(id, parent)
        {
            _bar = new TexturedObject("bar", this, spriteSheetBar);
            _slider = new TexturedObject("slider", this, spriteSheetSlider);

            //set Slider boundingbox equal to boundingBox of bar
            BoundingBox = _bar.BoundingBox;

            //centerSlider
            _slider.Position = new Vector2(_bar.Width / 2 - _slider.Width / 2, _bar.Height / 2 - _slider.Height / 2);

            //only slider itself can collide, the bar cannot
            _slider.CanCollide = true;

            CanCollide = true;

            //add objects
            Add(_bar);
            Add(_slider);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            var input = GameInstance.InputManager;

            //check whether or not the mouse is on top of _slider
            if (CollisionHelper.CollidesWith(_slider, input.MousePosition))
            {
                //make sure the player started holding leftMouseButton on top of _slider
                if (input.LeftMouseButtonPressed)
                {
                    _dragged = true;
                }
            }
            if (_dragged)
            {
                if (input.LeftMouseButtonHolding)
                {
                    float mouseX = input.MousePosition.X;

                    //calculate boundaries - when center of slider is aligned with bar boundaries
                    float xMin = _bar.GlobalPosition.X - _slider.Width / 2;
                    float xMax = xMin + _bar.Width - 1.5f * _slider.Width / 2;

                    //if slider is within boundaries of _bar, update _slider positionX and call UseNewSliderValue
                    if (mouseX >= xMin && mouseX <= xMax)
                    {
                        _slider.PositionX = mouseX - xMin;
                        //calculate value between 0 and 1 that represents the position of the slider on the bar
                        UseNewSliderValue((_slider.Position.X - _slider.Width / 2) / (_bar.Width - 1.5f * _slider.Width / 2));
                    }
                }
                else if (input.LeftMouseButtonReleased)
                {
                    _dragged = false;
                }
            }
        }

        protected virtual void UseNewSliderValue(float value)
        {

        }
    }
}
