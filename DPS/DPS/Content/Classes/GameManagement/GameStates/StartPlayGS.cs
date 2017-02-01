using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Content
{
    class StartPlayGS : GameState
    {
        public StartPlayGS(string id, GameStateManager gameStateManager) : base(id, gameStateManager)
        {
            var timer = new Timer("timer", HUD);
            timer.Position = new Vector2(GameInstance.GraphicsDeviceManager.PreferredBackBufferWidth - 130, 640);
            AddToHud(timer);

            var healthBar = new HealthBar("healthBar", HUD);
            healthBar.Position = new Vector2(50, 600);
            AddToHud(healthBar);

            SongPlay = GameInstance.AssetManager.GetSong("Main Song");
        }

        public override void Init()
        {
            base.Init();
            IsMouseVisible = true;
            World.CanUpdate = true;
            CanUpdateGameTime = true;          
        }
    }
}
