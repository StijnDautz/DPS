using Engine;

namespace Content
{
    class PlayButton : Button
    {
        public PlayButton(string id, Object parent, SpriteSheet spriteSheet, string soundName) : base(id, parent, spriteSheet,soundName)
        {

        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
            World.GameMode.GameStateManager.SwitchTo("StartPlay");
        }
    }
}