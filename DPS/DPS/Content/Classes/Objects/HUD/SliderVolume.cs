using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class SliderVolume : Engine.Slider
    {
        public SliderVolume(Engine.Object parent, Engine.SpriteSheet spriteSheetBar, Engine.SpriteSheet spriteSheetSlider) : base("sliderVolume", parent, spriteSheetBar, spriteSheetSlider)
        {

        }

        protected override void UseNewSliderValue(float value)
        {
            base.UseNewSliderValue(value);
            //set volume equal to value between 0 and 1
            MediaPlayer.Volume = value;
        }
    }
}
