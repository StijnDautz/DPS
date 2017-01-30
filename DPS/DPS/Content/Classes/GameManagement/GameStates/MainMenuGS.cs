using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Content
{
    class MainMenuGS : GameState
    {
        public MainMenuGS(GameStateManager gameStateManager) : base("GSMainMenu", gameStateManager)
        {
            //Add background
            var background = new TexturedObject("background", HUD, new SpriteSheet("Textures/HUD/MainMenu"));
            AddToHud(background);

            PlayButton playButton = new PlayButton("playButton", HUD, new SpriteSheet("Textures/HUD/PlayButton"), "Rocket");
            playButton.Position = new Microsoft.Xna.Framework.Vector2(550, 225);
            AddToHud(playButton);

            ExitButton exitButton = new ExitButton("exitButton", HUD, new SpriteSheet("Textures/HUD/ExitButton"), "Rocket");
            exitButton.Position = new Microsoft.Xna.Framework.Vector2(550, 425);
            AddToHud(exitButton);

            var buttonSettings = new ButtonSettings(HUD);
            buttonSettings.Position = new Microsoft.Xna.Framework.Vector2(550, 325);
            AddToHud(buttonSettings);

            var loginPopUpWindow = new LoginPopUp(HUD);
            loginPopUpWindow.Position = new Microsoft.Xna.Framework.Vector2(background.Width / 2 - loginPopUpWindow.Width / 2, background.Height / 2 - loginPopUpWindow.Height / 2);
            AddToHud(loginPopUpWindow);

            SongPlay = Engine.GameInstance.AssetManager.GetSong("Main Menu");
        }

        public override void Init()
        {
            base.Init();
            World.CanUpdate = false;
            IsMouseVisible = true;
            CanUpdateGameTime = false;
        }
    }
}
