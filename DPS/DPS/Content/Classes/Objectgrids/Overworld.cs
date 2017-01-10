using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
namespace Content
{
    class Overworld : ObjectGrid
    {
        public Overworld(string id, string assetName, int tileSize) : base(id, assetName, tileSize)
        {

        }

        private TexturedObject SetupCollisionTile(string id, string assetName)
        {
            TexturedObject Tile = new TexturedObject(id, "Textures/Tiles/" + assetName);
            Tile.CanCollide = true;
            Tile.canBlock = true;
            return Tile;
        }

        private TexturedObject WalkableTile(string id, string assetName)
        {
            TexturedObject Tile = new TexturedObject(id, "Textures/Tiles/" + assetName);
            Tile.CanCollide = false;
            Tile.canBlock = false;
            return Tile;
        }

        protected override Engine.Object FindType(char type)
        {
            switch (type)
            {
                case 'a': return WalkableTile("Overworldtile", "a.Overworld");
                case 'b': return WalkableTile("Overworldtile", "b.Overworld");
                case 'c': return WalkableTile("Overworldtile", "c.Overworld");
                case 'd': return SetupCollisionTile("Overworldtile", "d.Overworld");
                case 'e': return SetupCollisionTile("Overworldtile", "e.Overworld");
                case 'f': return SetupCollisionTile("Overworldtile", "f.Overworld");
                case 'g': return SetupCollisionTile("Overworldtile", "g.Overworld");
                case 'h': return SetupCollisionTile("Overworldtile", "h.Overworld");
                case 'i': return SetupCollisionTile("Overworldtile", "i.Overworld");
                case 'j': return SetupCollisionTile("Overworldtile", "j.Overworld");
                case 'k': return SetupCollisionTile("Overworldtile", "k.Overworld");
                case 'l': return SetupCollisionTile("Overworldtile", "l.Overworld");
                case 'm': return SetupCollisionTile("Overworldtile", "m.Overworld");
                case 'n': return SetupCollisionTile("Overworldtile", "n.Overworld");
                case 'o': return SetupCollisionTile("Overworldtile", "o.Overworld");
                case 'p': return SetupCollisionTile("Overworldtile", "p.Overworld");
                case 'q': return WalkableTile("Overworldtile", "q.Overworld");
                case 'r': return SetupCollisionTile("Overworldtile", "r.Overworld");
                case 's': return SetupCollisionTile("Overworldtile", "s.Overworld");
                case 't': return SetupCollisionTile("Overworldtile", "t.Overworld");
                case 'u': return SetupCollisionTile("Overworldtile", "u.Overworld");
                case 'v': return SetupCollisionTile("Overworldtile", "v.Overworld");
                case 'w': return WalkableTile("Overworldtile", "w.Overworld");
                case 'x': return SetupCollisionTile("Overworldtile", "x.Overworld");
                case 'y': return SetupCollisionTile("Overworldtile", "y.Overworld");
                case 'z': return SetupCollisionTile("Overworldtile", "z.Overworld");
                case 'A': return SetupCollisionTile("Overworldtile", "A.Overworld(1)");
                case 'B': return WalkableTile("Overworldtile", "B.Overworld(1)");
                case 'C': return WalkableTile("Overworldtile", "C.Overworld(1)");
                case 'D': return WalkableTile("Overworldtile", "D.Overworld(1)");
                case 'E': return WalkableTile("Overworldtile", "E.Overworld(1)");
                case 'F': return WalkableTile("Overworldtile", "F.Overworld(1)");
                case 'G': return SetupCollisionTile("Overworldtile", "G.Overworld(1)");
                case 'H': return SetupCollisionTile("Overworldtile", "H.Overworld(1)");
                case 'I': return SetupCollisionTile("Overworldtile", "I.Overworld(1)");
                case 'J': return SetupCollisionTile("Overworldtile", "J.Overworld(1)");
                case 'K': return SetupCollisionTile("Overworldtile", "K.Overworld(1)");
                case 'L': return SetupCollisionTile("Overworldtile", "L.Overworld(1)");
                case 'M': return SetupCollisionTile("Overworldtile", "M.Overworld(1)");
                case 'N': return SetupCollisionTile("Overworldtile", "N.Overworld(1)");
                case 'O': return SetupCollisionTile("Overworldtile", "O.Overworld(1)");
                case 'P': return SetupCollisionTile("Overworldtile", "P.Overworld(1)");
                case 'Q': return SetupCollisionTile("Overworldtile", "Q.Overworld(1)");
                case 'R': return SetupCollisionTile("Overworldtile", "R.Overworld(1)");
                case 'S': return SetupCollisionTile("Overworldtile", "S.Overworld(1)");
                case 'T': return SetupCollisionTile("Overworldtile", "T.Overworld(1)");
                case 'U': return SetupCollisionTile("Overworldtile", "U.Overworld(1)");
                case 'V': return SetupCollisionTile("Overworldtile", "V.Overworld(1)");
                case 'W': return SetupCollisionTile("Overworldtile", "W.Overworld(1)");
                case '6': return SetupCollisionTile("Overworldtile", "6.Overworld");
                case '0': return WalkableTile("Overworldtile", "0.Overworld");


                default: throw new Exception("character of type: " + type + "was not associated with an Object");
            }
        }
    }
}


