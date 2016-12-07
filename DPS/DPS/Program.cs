using Content;
using System;

namespace Engine
{
    /// <summary>
    /// The main class.
    /// </summary>
    class DPS : GameInstance
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new DPS())
                game.Run();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            GameModeManager.Add(new MainGameMode("MainGM", new MainWorld(new Character("player", "Textures/Tiles/spr_wall", "BaasFrank", 19, true))));
            GameModeManager.SwitchTo("MainGM");
        }
    }
}
