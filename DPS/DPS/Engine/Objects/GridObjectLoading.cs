using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    partial class ObjectGrid
    {
        public void Load(string assetName)
        {
            ReadTiles(ReadFile(assetName), assetName);
        }

        private List<string> ReadFile(string assetName)
        {
            StreamReader stream = new StreamReader("Content/Maps/" + assetName + ".txt");
            List<string> lines = new List<string>();

            //read lines from file
            string line = stream.ReadLine();
            while (line != null)
            {
                lines.Add(line);
                line = stream.ReadLine();
            }
            return lines;
        }

        private void ReadTiles(List<string> lines, string assetName)
        {
            if (lines.Count != 0)
            {
                _collums = lines[0].Length;
                _rows = lines.Count;
                _grid = new Object[_collums, _rows];
            }

            for (int y = 0; y < lines.Count; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    AddTile(FindType(lines[y][x]), lines[y][x], x, y);
                }
            }
        }

        private void ReadTiles(char[,] grid)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    AddTile(FindType(grid[x, y]), grid[x, y], x, y);
                }
            }
        }

        protected virtual Object FindType(char type)
        {
            return null;
        }

        private void AddTile(Object tile, char type, int x, int y)
        {
            //if tile is null throw exception
            //else add it to the world/grid
            if (tile != null)
            {
                //if tile is Character, it should be added to the world and to the grid
                //instead fill the spot in the grid with an empty Object
                if(tile is Character)
                {
                    World.Add(tile);
                    //as characters parent will not this, but world, add GlobalPosition of this to it, as it happened to be in its txt file
                    tile.Position = new Vector2(x * _tileWidth, y * _tileHeight) + GlobalPosition;
                    setTile(x, y, new Object("", this));
                }
                else
                {
                    setTile(x, y, tile);
                }
            }
            else
            {
                throw new Exception("tile type: " + type + "was not found");
            }
        }
    }
}