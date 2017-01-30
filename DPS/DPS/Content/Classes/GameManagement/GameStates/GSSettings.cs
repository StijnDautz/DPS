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
            //add background
            var backGround = new TexturedObject("background", HUD, new SpriteSheet("Textures/HUD/MainMenuGeneralBackGround"));

            var sliderVolumeText = new Engine.TextObject("sliderVolumeText", "Hud", HUD);
            sliderVolumeText.Text = "Volume";
            sliderVolumeText.Color = new Color(124, 93, 72);

            SliderVolume sliderVolume = new SliderVolume(HUD, new SpriteSheet("Textures/HUD/SliderBar"), new SpriteSheet("Textures/HUD/Slider"));

            //add buttons
            var buttonBack = new ButtonBack(HUD, "GSMainMenu");
            buttonBack.Position = new Vector2(backGround.Width / 2 - buttonBack.Width / 2, 400);

            //center objects
            sliderVolumeText.Position = new Vector2(backGround.Width / 2 - sliderVolumeText.Width / 2, 225);
            sliderVolume.Position = new Vector2(backGround.Width / 2 - sliderVolume.Width / 2, 275);

            //Add objects to HUD
            AddToHud(backGround);
            AddToHud(sliderVolume);
            AddToHud(buttonBack);
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
