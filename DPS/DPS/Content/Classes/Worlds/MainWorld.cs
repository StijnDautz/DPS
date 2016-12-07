using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class MainWorld : World
    {
        public MainWorld(Character character) : base(character)
        {
            Map m = new Map("MainMap", new MainObjectGrid("mainGrid", "MainMap", 60), TileSize);
            m.Add(character);
            AddMap(m);
        }
    }
}