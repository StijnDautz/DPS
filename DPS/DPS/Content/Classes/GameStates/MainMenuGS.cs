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
            World.CanUpdate = false;
            AddToHud(new TexturedObject("background", HUD, "HUD/MainMenu"));
            PlayButton playButton = new PlayButton("playButton", HUD, "HUD/PlayButton");
            playButton.Position = new Microsoft.Xna.Framework.Vector2(500, 400);
            AddToHud(playButton);
            GameInstance.IsMouseVisible = true;
        }
    }
}
