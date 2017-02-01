using Engine;

namespace Content
{
    class ButtonBack : Button
    {
        private string _gameStateId;

        public ButtonBack(Object parent, string gameStateId) : base("buttonBack", parent, new SpriteSheet("Textures/HUD/ButtonBack"), "Rocket")
        {
            _gameStateId = gameStateId;
        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
            World.GameMode.GameStateManager.SwitchTo(_gameStateId);
        }
    }
}