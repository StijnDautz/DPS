using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class PlayButton : Engine.Button
    {
        public PlayButton(string id, Engine.Object parent, string assetName, string soundName) : base(id, parent, assetName,soundName)
        {

        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
            World.GameMode.SwitchTo("MainWorld");
            World.GameMode.GameStateManager.SwitchTo("StartPlay");
        }
    }
}
