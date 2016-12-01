using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class MainGameMode : Engine.GameMode
    {
        public MainGameMode(string id, Engine.World world) : base(id, world)
        {
            GameStateManager.Add(new StartPlayGS("StartPlayGS"));
            GameStateManager.SwitchTo("StartPlayGS");
        }
    }
}
