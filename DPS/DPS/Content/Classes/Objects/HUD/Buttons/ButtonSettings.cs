using Engine;

namespace Content
{
    class ButtonSettings : Button
    {
        public ButtonSettings(Object parent) : base("buttonOptions", parent, new SpriteSheet("Textures/HUD/ButtonSettings"), "Rocket")
        {

        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
            World.GameMode.GameStateManager.SwitchTo("GSSettings");
        }
    }
}