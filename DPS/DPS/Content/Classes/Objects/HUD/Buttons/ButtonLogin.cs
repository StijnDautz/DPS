using Engine;

namespace Content
{
    class ButtonLogin : Button
    {
        private TextBox _userNameBox, _passWordBox;
        private TextObject _warningMessage;

        public ButtonLogin(Object parent, TextBox userNameBox, TextBox passWordBox, TextObject warningMessage) : base("buttonLogin", parent, new SpriteSheet("Textures/HUD/ButtonSignIn"), "Rocket")
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
                HighScoreManager.GetHighscore();
            }
            else
            {
                _warningMessage.Visible = true;
            }
        }
    }
}