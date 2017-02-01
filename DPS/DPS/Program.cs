using Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

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

            var worlds = new List<World>();
            worlds.Add(new DungeonWorld1(94080, 26880));
            worlds.Add(new MainWorld("MainWorld", 50000, 50000));
            worlds.Add(new MiniDungeon1("MiniDungeon1", 7680, 2880));
            worlds.Add(new MiniDungeon2("MiniDungeon2", 5760, 2880));
            MainGameMode gameMode = new MainGameMode("MainGM", GameModeManager, worlds);

            gameMode.SwitchTo("MainWorld");
            gameMode.Player = new Player("player", gameMode.World, new SpriteSheetPlayerTopDown("Textures/Characters/CharacterOverWorld"), new SpriteSheetPlayerSide("Textures/Characters/Character"));
            gameMode.Player.Position = new Microsoft.Xna.Framework.Vector2(600 , 300);

            gameMode.Setup();
            
            gameMode.SetupWorlds();
            gameMode.World.Add(gameMode.Player);
            
            GameModeManager.Add(gameMode);
            GameModeManager.SwitchTo("MainGM");
        }
    }
}
