using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class ButtonContinue : Engine.Button
    {
        private string _gameStateId;

        public ButtonContinue(Engine.Object parent, string gameStateId) : base("buttonContinue", parent, new Engine.SpriteSheet("Textures/HUD/ButtonContinue"), "Rocket")
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
