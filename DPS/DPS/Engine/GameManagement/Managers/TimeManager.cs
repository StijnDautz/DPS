using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class TimeManager
    {
        private int _milliseconds, _seconds, _minutes;

        public int Seconds
        {
            get { return _seconds; }
        }

        public int Minutes
        {
            get { return _minutes; }              
        }

        public int TotalSeconds
        {
            get { return _minutes * 60 + _seconds; }
        }

        public TimeManager()
        {

        }

        public void Update(GameTime gameTime)
        {
            _milliseconds += gameTime.ElapsedGameTime.Milliseconds;
            if (_milliseconds > 999)
            {
                _milliseconds -= 1000;
                _seconds++;
                if (_seconds > 59)
                {
                    _seconds -= 60;
                    _minutes++;
                    if (_minutes > 59)
                    {
                        _minutes -= 60;
                    }
                }
            }
        }
    }
}
