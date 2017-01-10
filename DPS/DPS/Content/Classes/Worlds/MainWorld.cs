using Engine;
using Microsoft.Xna.Framework;
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
            IsTopDown = true;
            Map m = new Map("Overworld", new Overworld("mainGrid", "Overworld", 96), TileSize);
            AddMap(m);
            m.Add(character);            
        }
    }
}