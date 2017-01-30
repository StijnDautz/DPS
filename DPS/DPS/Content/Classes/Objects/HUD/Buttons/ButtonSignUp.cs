using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class ButtonSignUp : Engine.Button
    {
        public ButtonSignUp(Engine.Object parent) : base("buttonSignIn", parent, new Engine.SpriteSheet("Textures/HUD/ButtonSignUp"), "")
        {

        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
        }
    }
}
