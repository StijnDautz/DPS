using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class ExitButton : Engine.Button
    {
        public ExitButton(string id, Engine.Object parent, Engine.SpriteSheet spriteSheet, string soundName) : base(id, parent, spriteSheet, soundName)
        {

        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
            World.GameMode.Parent.GameInstance.Exit();
        }
    }
}
