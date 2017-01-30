using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class ButtonSettings : Engine.Button
    {
        public ButtonSettings(Engine.Object parent) : base("buttonOptions", parent, new Engine.SpriteSheet("Textures/HUD/ButtonSettings"), "Rocket")
        {

        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
            World.GameMode.GameStateManager.SwitchTo("GSSettings");
        }
    }
}
