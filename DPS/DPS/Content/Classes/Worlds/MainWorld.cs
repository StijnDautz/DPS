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
            
            
            Teleporter teleporterMiniDungeon1 = new Teleporter("teleporter", this, "Dungeon1", new Vector2(32000, 8000));
            teleporterMiniDungeon1.Position = new Vector2(576, 4032);
            teleporterMiniDungeon1.BoundingBox = new Rectangle(0, 0, 96, 96);
            Add(teleporterMiniDungeon1);
        }
    }
}