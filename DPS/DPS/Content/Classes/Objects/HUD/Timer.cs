using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Content
{
    class Timer : Engine.ObjectList
    {
        Engine.TextObject _time;

        public Timer(string id, Engine.Object parent) : base(id, parent)
        {
            _time = new Engine.TextObject("time", "Hud", this);
            var _timerFrame = new Engine.TexturedObject("frame", this, new Engine.SpriteSheet("Textures/Hud/TimerFrame"));
            _timerFrame.Position = new Vector2(-22, -25);
            Add(_timerFrame);
            Add(_time);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            var time = Engine.GameModeManager.TimeManager;
            _time.Text = time.Minutes + " : " + time.Seconds;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}