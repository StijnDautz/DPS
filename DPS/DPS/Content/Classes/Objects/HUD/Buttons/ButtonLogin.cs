using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class ButtonLogin : Engine.Button
    {
        private Engine.TextBox _userNameBox, _passWordBox;

        public ButtonLogin(Engine.Object parent, Engine.TextBox userNameBox, Engine.TextBox passWordBox) : base("buttonLogin", parent, new Engine.SpriteSheet("Textures/HUD/ButtonSignIn"), "Rocket")
        {
            _userNameBox = userNameBox;
            _passWordBox = passWordBox;
        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
        }
    }
}
