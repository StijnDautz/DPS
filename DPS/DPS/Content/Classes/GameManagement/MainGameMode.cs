using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class MainGameMode : Engine.GameMode
    {
        public MainGameMode(string id, Engine.World world, Engine.GameModeManager gm) : base(id, world, gm)
        {
            GameStateManager.Add(new StartPlayGS("StartPlayGS", GameStateManager));
            GameStateManager.Add(new InventoryGS("inventory", GameStateManager));
            GameStateManager.SwitchTo("StartPlayGS");
        }
    }
}
