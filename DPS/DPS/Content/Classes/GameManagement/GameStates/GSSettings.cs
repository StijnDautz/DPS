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

            var sliderMusicVolumeText = new TextObject("sliderMusicVolumeText", "Hud", HUD);
            sliderMusicVolumeText.Text = "Music Volume";
            sliderMusicVolumeText.Color = new Color(124, 93, 72);

            var sliderSFXVolumeText = new TextObject("sliderSFXvolume", "Hud", HUD);
            sliderSFXVolumeText.Text = "SFX Volume";
            sliderSFXVolumeText.Color = new Color(124, 93, 72);

            SliderMusicVolume sliderMusicVolume = new SliderMusicVolume(HUD);
            SliderSFXVolume sliderSFXVolume = new SliderSFXVolume(HUD);

            //add buttons
            var buttonBack = new ButtonBack(HUD, "GSMainMenu");
            buttonBack.Position = new Vector2(backGround.Width / 2 - buttonBack.Width / 2, 430);

            //center objects
            sliderMusicVolumeText.Position = new Vector2(backGround.Width / 2 - sliderMusicVolumeText.Width / 2, 225);
            sliderMusicVolume.Position = new Vector2(backGround.Width / 2 - sliderMusicVolume.Width / 2, 275);
            sliderSFXVolumeText.Position = new Vector2(backGround.Width / 2 - sliderSFXVolumeText.Width / 2, 325);
            sliderSFXVolume.Position = new Vector2(backGround.Width / 2 - sliderSFXVolume.Width / 2, 375);

            //Add objects to HUD
            AddToHud(backGround);
            AddToHud(sliderMusicVolume);
            AddToHud(sliderSFXVolume);
            AddToHud(buttonBack);
            AddToHud(sliderMusicVolumeText);
            AddToHud(sliderSFXVolumeText);
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
