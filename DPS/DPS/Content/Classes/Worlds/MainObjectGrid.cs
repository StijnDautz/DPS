using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class MainObjectGrid : ObjectGrid
    {
        public MainObjectGrid(string id, string assetName, int tileSize) : base(id, assetName, tileSize)
        {
            CanCollide = true;
        }

        protected override Engine.Object FindType(char type)
        {
            switch (type)
            {
                case '.': return new TexturedObject("walltile", "Textures/Tiles/spr_wall");
                default: throw new Exception("character of type: " + type + "was not associated with an Object");
            }
        }
    }
}
