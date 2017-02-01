using Engine;

namespace Content
{
    class ExitButton : Button
    {
        public ExitButton(string id, Object parent, SpriteSheet spriteSheet, string soundName) : base(id, parent, spriteSheet, soundName)
        {

        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
            World.GameMode.GameModeManager.GameInstance.Exit();
        }
    }
}