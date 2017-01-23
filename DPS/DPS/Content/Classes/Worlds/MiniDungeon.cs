using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class MiniDungeon : Engine.World
    {
        public MiniDungeon(string id, int width, int height) : base(id, width, height)
        {

        }

        protected void AddGridToLevelGrid(int x, int y, Engine.ObjectGrid levelGrid, string[] assetNames)
        {
            levelGrid.Grid[x, y] = new GridDungeon("subGrid", this, assetNames[Engine.GameInstance.RNG.Next(0, assetNames.Length)], 96);
        }
    }
}
