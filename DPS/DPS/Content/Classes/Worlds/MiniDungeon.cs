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
            int index = Engine.GameInstance.RNG.Next(0, assetNames.Length);
            var subGrid = new GridDungeon("subGrid", this, assetNames[index], 96, Microsoft.Xna.Framework.Vector2.Zero);
            subGrid.Position = new Microsoft.Xna.Framework.Vector2(x * 20 * 96, y * 10 * 96);
            subGrid.CanCollide = true;
            levelGrid.Grid[x, y] = subGrid;
        }
    }
}
