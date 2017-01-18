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
            MainGameMode gameMode = new MainGameMode("MainGM", GameModeManager);
            gameMode.AddWorld(new DungeonWorld1("Dungeon1", 50000, 50000, gameMode));
            gameMode.AddWorld(new MainWorld("MainWorld", 50000, 50000, gameMode));
            gameMode.SwitchTo("Dungeon1");
            gameMode.Setup();
            GameModeManager.Add(gameMode);
            GameModeManager.SwitchTo("MainGM");

        }
    }
}
