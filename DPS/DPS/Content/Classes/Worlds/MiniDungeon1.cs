using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

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
            AddGridToLevelGrid(0, 0, levelGrid, new string[] { "19", "102", "103" });
            AddGridToLevelGrid(1, 0, levelGrid, new string[] { "94", "43" });
            AddGridToLevelGrid(2, 0, levelGrid, new string[] { "108", "109" });
            AddGridToLevelGrid(0, 1, levelGrid, new string[] { "20", "39", "51" });
            AddGridToLevelGrid(0, 2, levelGrid, new string[] { "21", "106" });
            AddGridToLevelGrid(1, 2, levelGrid, new string[] { "104", "105" });
            AddGridToLevelGrid(2, 2, levelGrid, new string[] { "95", "107" });
            AddGridToLevelGrid(3, 2, levelGrid, new string[] { "93"});
            Add(levelGrid);

            var teleporterback = new Teleporter("teleporter", this, "MainWorld", new Microsoft.Xna.Framework.Vector2(3456, 384));
            teleporterback.Position = new Microsoft.Xna.Framework.Vector2(7296,2688);
            teleporterback.BoundingBox = new Rectangle(0, 0, 96, 96);
            Add(teleporterback);

            var MinidungeonItem = new UpgradePickup("Damage150", this, new SpriteSheet("Textures/Items/Damage150"), "Increases damage by 150!");
            MinidungeonItem.Position = new Vector2(7200, 2688);
            MinidungeonItem.Damage = 150;

            Add(MinidungeonItem);
        }
    }
}