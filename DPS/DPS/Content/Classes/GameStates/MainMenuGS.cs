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
        public MainMenuGS(string id, GameStateManager gameStateManager) : base(id, gameStateManager)
        {
            AddToHud(new TexturedObject("background", HUD, "HUD/MainMenu"));
            PlayButton playButton = new PlayButton("playButton", HUD, "HUD/PlayButton");
            playButton.Position = new Microsoft.Xna.Framework.Vector2(550, 250);
            AddToHud(playButton);

            ExitButton exitButton = new ExitButton("exitButton", HUD, "HUD/ExitButton");
            exitButton.Position = new Microsoft.Xna.Framework.Vector2(550,400);
            AddToHud(exitButton);
        }

        public override void Init()
        {
            base.Init();
            World.CanUpdate = false;
            GameInstance.IsMouseVisible = true;
        }
    }
}
