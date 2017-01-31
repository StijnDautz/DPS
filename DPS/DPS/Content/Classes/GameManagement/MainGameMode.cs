﻿using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class MainGameMode : Engine.GameMode
    {
        public MainGameMode(string id, Engine.GameModeManager gm, List<Engine.World> worlds) : base(id, gm, worlds)
        {
            
        }


        public override void Setup()
        {
            base.Setup();
            GameStateManager.Add(new StartPlayGS("StartPlay", GameStateManager));
            GameStateManager.Add(new InventoryGS("inventory", GameStateManager));
            GameStateManager.Add(new MainMenuGS(GameStateManager));
            GameStateManager.Add(new GSSettings(GameStateManager));
            GameStateManager.Add(new GSLogin(GameStateManager));
            GameStateManager.Add(new GSGameFinished(GameStateManager));
            GameStateManager.SwitchTo("GSMainMenu");
        }
    }
}
