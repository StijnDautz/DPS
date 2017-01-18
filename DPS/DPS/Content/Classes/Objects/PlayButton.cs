using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class PlayButton : Engine.Button
    {
        public PlayButton(string id, Engine.Object parent, string assetName) : base(id, parent, assetName)
        {

        }

        protected override void ActionWhenPressed()
        {
            World.GameMode.SwitchTo("MainWorld");
            World.GameMode.GameStateManager.SwitchTo("StartPlay");
        }
    }
}
