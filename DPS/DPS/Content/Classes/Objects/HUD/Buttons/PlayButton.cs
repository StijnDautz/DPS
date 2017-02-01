using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class PlayButton : Engine.Button
    {
        public PlayButton(string id, Engine.Object parent, Engine.SpriteSheet spriteSheet, string soundName) : base(id, parent, spriteSheet,soundName)
        {

        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
            World.GameMode.GameStateManager.SwitchTo("StartPlay");

            //on start play scale the enemies according to highscore
            World.ScaleEnemies();
        }
    }
}
