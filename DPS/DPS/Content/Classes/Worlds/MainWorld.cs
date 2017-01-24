using Engine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class MainWorld : World
    {
        public MainWorld(string id, int width, int height) : base(id, width, height)
        {
            IsTopDown = true;
            CanUpdate = true;
        }

        public override void Setup(GameMode gameMode)
        {
            base.Setup(gameMode);

            Overworld grid = new Overworld("mainGrid", this, "OverWorld", 96);
            grid.CanCollide = true;
            Add(grid);

            Teleporter teleporterMiniDungeon1 = new Teleporter("teleporter", this, "MiniDungeon2", new Vector2(300, 300));
            teleporterMiniDungeon1.Position = new Vector2(690, 690);
            Add(teleporterMiniDungeon1);
        }
    }
}