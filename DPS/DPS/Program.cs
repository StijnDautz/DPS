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
            Character Frank = new Character("player", "Textures/Tiles/spr_wall", "BaasFrank", 19, true);
            Frank.Position = new Microsoft.Xna.Framework.Vector2(200, 300);

            GameModeManager.Add(new MainGameMode("MainGM", new MainWorld(Frank), GameModeManager));
            GameModeManager.SwitchTo("MainGM");

        }
    }
}
