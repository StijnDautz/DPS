using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class GridDungeon : ObjectGrid
    {
        public GridDungeon(string id, Engine.Object parent, string assetName, int tileSize, Vector2 position) : base(id, parent, assetName, tileSize, position)
        {

        }

        public GridDungeon(string id, Engine.Object parent, char[,] grid, int tileWidth, int tileHeight) : base(id, parent, grid, tileWidth, tileHeight)
        {
            CanCollide = true;
        }

        private TexturedObject SetupCollisionTile(string id, string assetName)
        {
            TexturedObject Tile = new TexturedObject(id, this, new SpriteSheet("Textures/Tiles/" + assetName));
            Tile.CanCollide = true;
            Tile.CanBlock = true;
            return Tile;
        }

        private TexturedObject Door(string id, string assetName)
        {
            TexturedObject Tile = new TexturedObject(id, this, new SpriteSheet("Textures/Tiles/" + assetName));
            Tile.CanCollide = false;
            Tile.CanBlock = true;
            return Tile;
        }

        private DestructableObject DestructionBlock(string id, string assetName, string type)
        {
            DestructableObject Tile = new DestructableObject(id, this, new SpriteSheet("Textures/Tiles/" + assetName));
            Tile.CanCollide = true;
            Tile.CanBlock = true;
            Tile.Type = type;
            return Tile;           
        }

        private TexturedObject Platform(string id, string assetName, int size)
        {
            TexturedObject Tile = new TexturedObject(id, this, new SpriteSheet("Textures/Tiles/" + assetName));
            Tile.CanCollide = true;
            Tile.CanBlock = true;
            if (size == 1)
            {
                Tile.BoundingBox = new Rectangle((int)Tile.PositionX, (int)Tile.PositionY, 144, 96);
            }
            if (size == 2)
            {
                Tile.BoundingBox = new Rectangle((int)Tile.PositionX, (int)Tile.PositionY, 240, 96);
            }
            if (size == 3)
            {
                Tile.BoundingBox = new Rectangle((int)Tile.PositionX, (int)Tile.PositionY, 500, 96);
            }

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
                case 't': return DestructionBlock("SuperJumpBlock", "9.TileSet4", "SuperJump");
                case 's':
                case 'u':
                case 'x':
                case 'v':
                case 'w':
                case '9': return SetupCollisionTile("walltile", "9.TileSet4");
                case 'a': return SetupCollisionTile("walltile", "9.TileSet4");
                case 'b': return SetupCollisionTile("walltile", "9.TileSet4");
                case 'c': return SetupCollisionTile("walltile", "9.TileSet4");

                case 'd': return Door("door", "d.TileSet4");
                case 'e': return Door("door", "e.TileSet4");

                case 'f': return Platform("platformtile", "f.TileSet4", 1);
                case 'g': return Platform("platformtile", "g.TileSet4", 2);
                case 'h': return Platform("platformtile", "h.TileSet4", 3);

                case 'i': return SetupCollisionTile("ladder", "i.TileSet4");

                case 'j': return SetupCollisionTile("walltile", "j.TileSet4");
                case 'k': return SetupCollisionTile("emptytile", "9.TileSet4");
                case 'l': return SetupCollisionTile("walltile", "l.TileSet4");
                case 'm': return SetupCollisionTile("walltile", "m.TileSet4");
                case 'n': return SetupCollisionTile("walltile", "n.TileSet4");
                case 'o': return SetupCollisionTile("walltile", "o.TileSet4");
                case 'p': return DestructionBlock("walltile", "p.TileSet4", "Normal");

                case 'q': return SetupCollisionTile("spike", "q.TileSet4");
                case 'r': return SetupCollisionTile("spike", "r.TileSet4");
                case '0': return new Engine.Object("emptyobj", this);
                case '-': return LoadEmptyCollisionBlock();
                case '!': return new EnemyZombie("zombie", this, new SpriteSheetZombie("Textures/Characters/IceZombie"), "zombieNormal", "Sound Effects - Zombie scream");
                case '@': return new EnemySnowMan("snowman", this, new SpriteSheetSnowMan("Textures/Characters/SnowmanThrower"));

                default: throw new Exception("character of type: " + type + "was not associated with an Object");
            }
        }

        private Engine.Object LoadEmptyCollisionBlock()
        {
            var obj = new Engine.Object("emptytile", this);
            obj.BoundingBox = new Rectangle(0, 0, 96, 96);
            obj.CanCollide = true;
            obj.CanBlock = true;
            return obj;
        }
    }
}