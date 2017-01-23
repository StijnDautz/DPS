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
            var levelGrid = new ObjectGrid("levelGrid", this, 4, 3, 96, 96);
            AddGridToLevelGrid(0, 0, levelGrid, new string[] { "17", "70", "65" });
            AddGridToLevelGrid(1, 0, levelGrid, new string[] { "94", "41" });
            AddGridToLevelGrid(2, 0, levelGrid, new string[] { "95", "42" });
            AddGridToLevelGrid(0, 1, levelGrid, new string[] { "18" });
            AddGridToLevelGrid(0, 2, levelGrid, new string[] { "19" });
            AddGridToLevelGrid(1, 2, levelGrid, new string[] { "94", "41" });
            AddGridToLevelGrid(2, 2, levelGrid, new string[] { "95", "42" });
            AddGridToLevelGrid(3, 2, levelGrid, new string[] { "93", "9" });
        }
    }
}