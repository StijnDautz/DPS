using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Content
{
    class MiniDungeon2 : MiniDungeon
    {
        public MiniDungeon2(string id, int width, int height) : base(id, width, height)
        {

        }

        public override void Setup(GameMode gameMode)
        {
            base.Setup(gameMode);
            var levelGrid = new Engine.ObjectGrid("levelGrid", this, 3, 3, 1920, 960);
            AddGridToLevelGrid(0, 0, levelGrid, new string[] { "96" });
            AddGridToLevelGrid(1, 0, levelGrid, new string[] { "97" });
            AddGridToLevelGrid(2, 0, levelGrid, new string[] { "98" });
            AddGridToLevelGrid(2, 1, levelGrid, new string[] { "46" });
            AddGridToLevelGrid(0, 1, levelGrid, new string[] { "26" });
            AddGridToLevelGrid(0, 2, levelGrid, new string[] { "100"});
            AddGridToLevelGrid(1, 1, levelGrid, new string[] { "99" });
            AddGridToLevelGrid(1, 2, levelGrid, new string[] { "93" });
        }
    }
}
