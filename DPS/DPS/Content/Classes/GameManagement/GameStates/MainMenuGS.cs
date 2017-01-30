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
            AddToHud(new TexturedObject("background", HUD, new SpriteSheet("Textures/HUD/MainMenu")));

            PlayButton playButton = new PlayButton("playButton", HUD, new SpriteSheet("Textures/HUD/PlayButton"), "Rocket");
            playButton.Position = new Microsoft.Xna.Framework.Vector2(550, 225);
            AddToHud(playButton);

            ExitButton exitButton = new ExitButton("exitButton", HUD, new SpriteSheet("Textures/HUD/ExitButton"), "Rocket");
            exitButton.Position = new Microsoft.Xna.Framework.Vector2(550, 425);
            AddToHud(exitButton);

            var buttonSettings = new ButtonSettings(HUD);
            buttonSettings.Position = new Microsoft.Xna.Framework.Vector2(550, 325);
            AddToHud(buttonSettings);

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
