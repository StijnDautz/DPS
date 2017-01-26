using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Engine;

namespace Content
{
    class GSSettings : GameState
    {
        public GSSettings(GameStateManager gameStateManager) : base("GSSettings", gameStateManager)
        {
            var sliderVolumeText = new Engine.TextObject("sliderVolumeText", "Hud", HUD);
            sliderVolumeText.Text = "Volume";
            sliderVolumeText.Color = new Color(124, 93, 72);

            SliderVolume sliderVolume = new SliderVolume(HUD, new SpriteSheet("Textures/HUD/SliderBar"), new SpriteSheet("Textures/HUD/Slider"));

            //center objects
            sliderVolumeText.Position = new Vector2(GameInstance.GraphicsDeviceManager.PreferredBackBufferWidth / 2 - sliderVolumeText.Width / 2, 225);
            sliderVolume.Position = new Vector2(GameInstance.GraphicsDeviceManager.PreferredBackBufferWidth / 2 - sliderVolume.Width / 2, 275);

            //Add objects to HUD
            AddToHud(new TexturedObject("background", HUD, new SpriteSheet("Textures/HUD/MainMenu")));
            AddToHud(sliderVolume);
            AddToHud(sliderVolumeText);
        }

        public override void HandleInput(GameTime gameTime)
        {
            base.HandleInput(gameTime);
            if(Engine.GameInstance.InputManager.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                GameStateManager.SwitchTo("GSMainMenu");
            }
        }
    }
}
