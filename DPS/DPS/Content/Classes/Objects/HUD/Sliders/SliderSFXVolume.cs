using Engine;

namespace Content
{
    class SliderSFXVolume : Slider
    {
        public SliderSFXVolume(Object parent) : base("sliderSFXVolume", parent, new SpriteSheet("Textures/HUD/SliderBar"), new SpriteSheet("Textures/HUD/Slider"))
        {

        }

        protected override void UseNewSliderValue(float value)
        {
            base.UseNewSliderValue(value);
            SFXManager.VolumeModifier = value;
        }
    }
}