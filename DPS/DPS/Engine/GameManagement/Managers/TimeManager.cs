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
        private int _milliseconds;
        private int _minutes;
        private int _hours;
        private int _days;

        public int Seconds
        {
            get { return _milliseconds / 1000; }
        }

        public int Minutes
        {
            get { return _minutes; }              
        }

        public int Hours
        {
            get { return _hours; }
        }

        public int Days
        {
            get { return _days; }
        }

        public TimeManager()
        {
            _hours = 0;
            _minutes = 0; ;
            _milliseconds = 0;
            _days = 0;
        }

        public void Update(GameTime gameTime)
        {
            _milliseconds += gameTime.ElapsedGameTime.Milliseconds;
            if(_milliseconds > 999)
            {
                _milliseconds -= 1000;
                _minutes++;
                if(_minutes > 59)
                {
                    _minutes -= 60;
                    _hours++;
                    if(_hours > 23)
                    {
                        _hours -= 24;
                        _days++;
                    }
                }
            }
        }
    }
}
