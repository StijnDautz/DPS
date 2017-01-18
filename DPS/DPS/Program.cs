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
            GameModeManager.Add(new MainGameMode("MainGM", new MainWorld(50000, 50000), GameModeManager));
            GameModeManager.SwitchTo("MainGM");

        }
    }
}
