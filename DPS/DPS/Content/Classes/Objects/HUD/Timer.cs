using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Content
{
    class Timer : Engine.ObjectList
    {
        Engine.TextObject _time;

        public Timer(string id, Engine.Object parent) : base(id, parent)
        {
            //TODO get frame sprite from TickTick
            _time = new Engine.TextObject("time", "Hud", this);
            //Add(new Engine.TexturedObject("frame", this, new Engine.SpriteSheet()));
            Add(_time);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            var time = Engine.GameModeManager.TimeManager;
            _time.Text = time.Minutes + " : " + time.Seconds;
        }
    }
}
