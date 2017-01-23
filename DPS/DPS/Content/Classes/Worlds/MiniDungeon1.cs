using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Content
{
    class MiniDungeon1 : MiniDungeon
    {
        public MiniDungeon1(string id, int width, int height) : base(id, width, height)
        {

        }

        public override void Setup(GameMode gameMode)
        {
            base.Setup(gameMode);
            IsTopDown = false;
            var levelGrid = new ObjectGrid("levelGrid", this, 4, 3, 1920, 960);
            levelGrid.CanCollide = true;
            AddGridToLevelGrid(0, 0, levelGrid, new string[] { "19", "102", "50" });
            AddGridToLevelGrid(1, 0, levelGrid, new string[] { "94", "43" });
            AddGridToLevelGrid(2, 0, levelGrid, new string[] { "95", "44" });
            AddGridToLevelGrid(0, 1, levelGrid, new string[] { "20", "39", "51" });
            AddGridToLevelGrid(0, 2, levelGrid, new string[] { "21", "40", "52" });
            AddGridToLevelGrid(1, 2, levelGrid, new string[] { "94", "43" });
            AddGridToLevelGrid(2, 2, levelGrid, new string[] { "95", "44" });
            AddGridToLevelGrid(3, 2, levelGrid, new string[] { "93"});
            Add(levelGrid);
        }
    }
}