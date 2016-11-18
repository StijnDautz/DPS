using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    class DungeonLoader
    {
        string path = "DungeonLoader.txt";
        int width = 4;
        int height = 4;
        Random r = new Random();
        string dungeon = "Fire";
        string[,] writeString;

        public DungeonLoader(string path, string dungeon)
        {
            writeString = new string[width, height];
            this.path = path;
            this.dungeon = dungeon;
        }

        // Reads a file and outputs processed data into writeString.
        void Load()
        {
            StreamReader fileReader = new StreamReader(path);
            for (int y = 0; y < height; y++)
            {
                string line = fileReader.ReadLine();
                for (int x = 0; x < line.Length; x++)
                {
                    writeString[x, y] = LevelLoader(line[x]);
                }
            }
            fileReader.Close();
        }

        // Outputs a string for use in the writeString array. In the case of 0(47) to 9(57), it adds a random number for the randomness of the dungeon.
        string LevelLoader(char input)
        {
            switch (input)
            {
                case 's': return dungeon + "StartRoom";
                case 'b': return dungeon + "BossRoom";
                case 'i': return dungeon + "ItemRoom";
                case 'k': return dungeon + "KeyRoom";
                default:
                    if (input > 47 && input < 58)
                    {
                        return input + "." + (char)r.Next(47, 58);
                    }
                    else return null;
            }
        }
    }
}
