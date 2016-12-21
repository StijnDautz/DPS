using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
namespace Content
{
    class DungeonIce4 : ObjectGrid
    {
            public DungeonIce4(string id, string assetName, int tileSize) : base(id, assetName, tileSize)
            {

            }

            protected override Engine.Object FindType(char type)
            {
                switch (type)
                {
                    case '1': return new TexturedObject("walltile", "Textures/Tiles/1.TileSet4");
                case '2': return new TexturedObject("walltile", "Textures/Tiles/2.TileSet4");
                case '3': return new TexturedObject("walltile", "Textures/Tiles/3.TileSet4");
                case '4': return new TexturedObject("walltile", "Textures/Tiles/4.TileSet4");
                case '5': return new TexturedObject("walltile", "Textures/Tiles/5.TileSet4");
                case '6': return new TexturedObject("walltile", "Textures/Tiles/6.TileSet4");
                case '7': return new TexturedObject("walltile", "Textures/Tiles/7.TileSet4");
                case '8': return new TexturedObject("walltile", "Textures/Tiles/8.TileSet4");
                case 'j': return new TexturedObject("walltile", "Textures/Tiles/j.TileSet4");
                case 'k': return new TexturedObject("walltile", "Textures/Tiles/k.TileSet4");
                case 'l': return new TexturedObject("walltile", "Textures/Tiles/l.TileSet4");
                case 'm': return new TexturedObject("walltile", "Textures/Tiles/m.TileSet4");
                case 'n': return new TexturedObject("walltile", "Textures/Tiles/n.TileSet4");
                case 'o': return new TexturedObject("walltile", "Textures/Tiles/o.TileSet4");


                default: throw new Exception("character of type: " + type + "was not associated with an Object");
                }
            }
        }
    }


