using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
namespace Content
{
    class DungeonDirt5 : ObjectGrid
    {
        public DungeonDirt5(string id, string assetName, int tileSize) : base(id, assetName, tileSize)
        {

        }

        protected override Engine.Object FindType(char type)
        {
            switch (type)
            {
                case '1': return new TexturedObject("walltile", "Textures/Tiles/1.TileSet5");
                case '2': return new TexturedObject("walltile", "Textures/Tiles/2.TileSet5");
                case '3': return new TexturedObject("walltile", "Textures/Tiles/3.TileSet5");
                case '4': return new TexturedObject("walltile", "Textures/Tiles/4.TileSet5");
                case '5': return new TexturedObject("walltile", "Textures/Tiles/5.TileSet5");
                case '6': return new TexturedObject("walltile", "Textures/Tiles/6.TileSet5");
                case '7': return new TexturedObject("walltile", "Textures/Tiles/7.TileSet5");
                case '8': return new TexturedObject("walltile", "Textures/Tiles/8.TileSet5");
                case 'j': return new TexturedObject("walltile", "Textures/Tiles/j.TileSet5");
                case 'k': return new TexturedObject("walltile", "Textures/Tiles/k.TileSet5");
                case 'l': return new TexturedObject("walltile", "Textures/Tiles/l.TileSet5");
                case 'm': return new TexturedObject("walltile", "Textures/Tiles/m.TileSet5");
                case 'n': return new TexturedObject("walltile", "Textures/Tiles/n.TileSet5");
                case 'o': return new TexturedObject("walltile", "Textures/Tiles/o.TileSet5");


                default: throw new Exception("character of type: " + type + "was not associated with an Object");
            }
        }
    }
}


