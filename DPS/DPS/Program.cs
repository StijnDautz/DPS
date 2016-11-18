using System;

namespace DPS
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
            using (var game = new GameInstance())
                game.Run();
        }

        protected override void LoadContent()
        {
            base.LoadContent();


        }
    }
}
