using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class SliderSFXVolume : Engine.Slider
    {
        public SliderSFXVolume(Engine.Object parent) : base("sliderSFXVolume", parent, new Engine.SpriteSheet("Textures/HUD/SliderBar"), new Engine.SpriteSheet("Textures/HUD/Slider"))
        {

        }

        protected override void UseNewSliderValue(float value)
        {
            base.UseNewSliderValue(value);
            Engine.SFXManager.VolumeModifier = value;
        }
    }
}
