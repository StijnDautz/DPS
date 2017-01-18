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
        public DungeonDirt5(string id, Engine.Object parent, string assetName, int tileSize) : base(id, parent, assetName, tileSize)
        {

        }

        protected override Engine.Object FindType(char type)
        {
            switch (type)
            {
                case '1': return getTile("1.TileSet5");
                case '2': return getTile("2.TileSet5");
                case '3': return getTile("3.TileSet5");
                case '4': return getTile("4.TileSet5");
                case '5': return getTile("5.TileSet5");
                case '6': return getTile("6.TileSet5");
                case '7': return getTile("7.TileSet5");
                case '8': return getTile("8.TileSet5");
                case 'j': return getTile("j.TileSet5");
                case 'k': return getTile("k.TileSet5");
                case 'l': return getTile("l.TileSet5");
                case 'm': return getTile("m.TileSet5");
                case 'n': return getTile("n.TileSet5");
                case 'o': return getTile("o.TileSet5");


                default: throw new Exception("character of type: " + type + "was not associated with an Object");
            }
        }

        private TexturedObject getTile(string s)
        {
            return new TexturedObject("walltile", this, "Textures/Tiles/" + s);
        }
    }
}


