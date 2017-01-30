using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class ButtonBack : Engine.Button
    {
        private string _gameStateId;

        public ButtonBack(Engine.Object parent, string gameStateId) : base("buttonBack", parent, new Engine.SpriteSheet("Textures/HUD/ButtonBack"), "Rocket")
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
