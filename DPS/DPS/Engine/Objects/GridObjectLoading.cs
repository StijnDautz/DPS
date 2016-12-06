using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    abstract partial class ObjectGrid
    {
        public void Load(string assetName)
        {
            ReadTiles(ReadFile(assetName));
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

        private void ReadTiles(List<string> lines)
        {
            _grid = new Object[lines[0].Length, lines.Count];
            for (int y = 0; y < lines.Count; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    AddTile(FindType(lines[y][x]), lines[y][x], x, y);
                }
            }
        }

        protected virtual Object FindType(char type)
        {
            return null;
        }

        private void AddTile(Object tile, char type, int x, int y)
        {
            if (tile != null)
            {
                tile.Position = new Vector2(x * _tileSize, y * _tileSize);
                _grid[x, y] = tile;
            }
            else
            {
                throw new Exception("tile type: " + type + "was not found");
            }
        }
    }
}