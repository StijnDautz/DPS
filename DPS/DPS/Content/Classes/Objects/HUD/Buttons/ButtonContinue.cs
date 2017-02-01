using Engine;

namespace Content
{
    class ButtonContinue : Button
    {
        private string _gameStateId;

        public ButtonContinue(Object parent, string gameStateId) : base("buttonContinue", parent, new SpriteSheet("Textures/HUD/ButtonContinue"), "Rocket")
        {
            _gameStateId = gameStateId;
        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
            //switch to the gamestate with _gameStateId
            World.GameMode.GameStateManager.SwitchTo(_gameStateId);
        }
    }
}