using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

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
            IsTopDown = false;
            var levelGrid = new Engine.ObjectGrid("levelGrid", this, 3, 3, 1920, 960);
            levelGrid.CanCollide = true;
            AddGridToLevelGrid(0, 0, levelGrid, new string[] { "96" });
            AddGridToLevelGrid(1, 0, levelGrid, new string[] { "97" });
            AddGridToLevelGrid(2, 0, levelGrid, new string[] { "98" });
            AddGridToLevelGrid(2, 1, levelGrid, new string[] { "46" });
            AddGridToLevelGrid(0, 1, levelGrid, new string[] { "26" });
            AddGridToLevelGrid(0, 2, levelGrid, new string[] { "100"});
            AddGridToLevelGrid(1, 1, levelGrid, new string[] { "99" });
            AddGridToLevelGrid(1, 2, levelGrid, new string[] { "93" });
            Add(levelGrid);

            var teleporterback = new Teleporter("teleporter", this, "MainWorld", new Microsoft.Xna.Framework.Vector2(4416, 5184)); 
            teleporterback.Position = new Microsoft.Xna.Framework.Vector2(3456, 2688);
            teleporterback.BoundingBox = new Rectangle(0, 0, 96, 96);
            Add(teleporterback);

            var MinidungeonItem = new UpgradePickup("Alles100", this, new SpriteSheet("Textures/Items/Alles100"), "Increases all stats by 100!");
            MinidungeonItem.Position = new Vector2(3360, 2688);
            MinidungeonItem.Health = 100;
            MinidungeonItem.Damage = 100;
            MinidungeonItem.AttackSpeed = 100;
            MinidungeonItem.Speed = 100;

            var MinidungeonItem2 = new UpgradePickup("Health100", this, new SpriteSheet("Textures/Items/Health100"), "Increases Health by 100!");
            MinidungeonItem2.Position = new Vector2(1536, 400);
            MinidungeonItem2.Health = 100;

            Add(MinidungeonItem);
            Add(MinidungeonItem2);
        }
    }
}
