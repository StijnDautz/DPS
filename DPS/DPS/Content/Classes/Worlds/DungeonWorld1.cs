using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class DungeonWorld1 : Engine.World
    {
        public DungeonWorld1(int width, int height) : base(width, height)
        {
            for(int i = 1; i < 101; i++)
            {
                Add(new Level1("level1", this, i.ToString(), 96));
            }
        }
    }
}
