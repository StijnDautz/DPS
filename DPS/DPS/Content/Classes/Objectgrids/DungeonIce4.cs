using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Content
{
    class Level1 : ObjectGrid
    {
        public Level1(string id, Engine.Object parent, string assetName, int tileSize) : base(id, parent, assetName, tileSize)
        {

        }

        private TexturedObject SetupCollisionTile(string id, string assetName)
        {
            TexturedObject Tile = new TexturedObject(id, this, "Textures/Tiles/" + assetName);
            Tile.CanCollide = true;
            Tile.CanBlock = true;
            return Tile;
        }

        protected override Engine.Object FindType(char type)
        {
            switch (type)
            {
                case '1': return SetupCollisionTile("walltile", "1.TileSet4");
                case '2': return SetupCollisionTile("walltile", "2.TileSet4");
                case '3': return SetupCollisionTile("walltile", "3.TileSet4");
                case '4': return SetupCollisionTile("walltile", "4.TileSet4");
                case '5': return SetupCollisionTile("walltile", "5.TileSet4");
                case '6': return SetupCollisionTile("walltile", "6.TileSet4");
                case '7': return SetupCollisionTile("walltile", "7.TileSet4");
                case '8': return SetupCollisionTile("walltile", "8.TileSet4");
                case 't':
                case 's':
                case 'u':
                case 'x':
                case 'v':
                case 'w':
                case '9': return SetupCollisionTile("walltile", "9.TileSet4");
                case 'a': return SetupCollisionTile("walltile", "9.TileSet4");
                case 'b': return SetupCollisionTile("walltile", "9.TileSet4");
                case 'c': return SetupCollisionTile("walltile", "9.TileSet4");

                case 'd': return SetupCollisionTile("door", "d.TileSet4");
                case 'e': return SetupCollisionTile("door", "e.TileSet4");

                case 'f': return SetupCollisionTile("platformtile", "f.TileSet4");
                case 'g': return SetupCollisionTile("platformtile", "g.TileSet4");
                case 'h': return SetupCollisionTile("platformtile", "h.TileSet4");

                case 'i': return SetupCollisionTile("ladder", "i.TileSet4");

                case 'j': return SetupCollisionTile("walltile", "j.TileSet4");
                case 'k': return SetupCollisionTile("emptytile", "9.TileSet4");
                case 'l': return SetupCollisionTile("walltile", "l.TileSet4");
                case 'm': return SetupCollisionTile("walltile", "m.TileSet4");
                case 'n': return SetupCollisionTile("walltile", "n.TileSet4");
                case 'o': return SetupCollisionTile("walltile", "o.TileSet4");
                case 'p': return SetupCollisionTile("walltile", "p.TileSet4");

                case 'q': return SetupCollisionTile("spike", "q.TileSet4");
                case 'r': return SetupCollisionTile("spike", "r.TileSet4");
                case '0':
                case '-': return new TexturedObject("emptytile", this, "Textures/Tiles/0.Overworld");

                default: throw new Exception("character of type: " + type + "was not associated with an Object");
            }
        }
    }
}


