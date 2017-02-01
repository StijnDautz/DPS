using Engine;

namespace Content
{
    class ButtonAllowTyping : Button
    {
        private bool _canType;

        public bool CanType
        {
            get { return _canType; }
            set { _canType = value; }
        }

        public ButtonAllowTyping(Object parent) : base("buttonAllowTyping", parent, new SpriteSheet("Textures/HUD/TextBoxBackGround"), "")
        {

        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
            _canType = true;
        }

        protected override void ActionWhenNotPressed()
        {
            base.ActionWhenNotPressed();
            _canType = false;
        }
    }
}