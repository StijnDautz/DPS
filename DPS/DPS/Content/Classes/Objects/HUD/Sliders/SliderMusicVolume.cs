using Microsoft.Xna.Framework.Media;

namespace Content
{
    class SliderMusicVolume : Engine.Slider
    {
        public SliderMusicVolume(Engine.Object parent) : base("sliderVolume", parent, new Engine.SpriteSheet("Textures/HUD/SliderBar"), new Engine.SpriteSheet("Textures/HUD/Slider"))
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