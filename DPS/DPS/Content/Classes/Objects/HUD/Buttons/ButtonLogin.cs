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
        private Engine.TextObject _warningMessage;

        public ButtonLogin(Engine.Object parent, Engine.TextBox userNameBox, Engine.TextBox passWordBox, Engine.TextObject warningMessage) : base("buttonLogin", parent, new Engine.SpriteSheet("Textures/HUD/ButtonSignIn"), "Rocket")
        {
            _userNameBox = userNameBox;
            _passWordBox = passWordBox;
            _warningMessage = warningMessage;
        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
            if(HighScoreManager.IsAccountValid(_userNameBox.Text, _passWordBox.Text))
            {
                World.GameMode.GameStateManager.SwitchTo("GSMainMenu");
                HighScoreManager.GetHighscore(_userNameBox.Text);
            }
            else
            {
                _warningMessage.Visible = true;
            }
        }
    }
}
