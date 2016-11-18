using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    class World : ObjectList
    {
        public World(string id) : base(id)
        {

        }

        public virtual void Load(string assetName)
        {

            
        }

        private List<string> ReadFile(string assetName)
        {
            StreamReader stream = new StreamReader(assetName);
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
            foreach(string tile in lines)
            {
                //for(int i = 0; i < tile.Length;)
            }
        }
    }
}
