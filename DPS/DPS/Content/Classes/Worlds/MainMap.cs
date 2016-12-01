using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class MainMap : Map
    {
        public MainMap(string id, string assetName) : base(id, assetName)
        {
            
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
