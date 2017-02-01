using Engine;
using System.Collections.Generic;

namespace Content
{
    class MainGameMode : GameMode
    {
        public MainGameMode(string id, GameModeManager gm, List<World> worlds) : base(id, gm, worlds)
        {
            
        }

        public override void Setup()
        {
            base.Setup();
            GameStateManager.Add(new StartPlayGS("StartPlay", GameStateManager));
            GameStateManager.Add(new MainMenuGS(GameStateManager));
            GameStateManager.Add(new GSSettings(GameStateManager));
            GameStateManager.Add(new GSLogin(GameStateManager));
            GameStateManager.Add(new GSGameFinished(GameStateManager));
            GameStateManager.SwitchTo("GSMainMenu");
        }

        public override void Reset()
        {
            base.Reset();
            ClearWorlds();
            SetupWorlds();

            SwitchTo("MainWorld");
            Player = new Player("player", World, new SpriteSheetPlayerTopDown("Textures/Characters/CharacterOverWorld"), new SpriteSheetPlayerSide("Textures/Characters/Character"));
            Player.Position = new Microsoft.Xna.Framework.Vector2(600, 300);
            World.Add(Player);
        }
    }
}
