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

            var grid = new Overworld("overWorldGrid", this, "OverWorld", 96);
            grid.CanCollide = true;
            Add(grid);

            /*var pickup = new Pickup("testPickup", this, new SpriteSheet("Textures/Items/SnowShoes"), "With these amazing snowBoots,\nyou'll be able to climb\nthe slippiest hills.");
            pickup.Position = new Vector2(600, 400);
            Add(pickup);*/

            //Add teleporters to different worlds
            Teleporter teleporterDungeon1 = new Teleporter("teleporter", this, "Dungeon1", new Vector2(33600, 6240));
            teleporterDungeon1.Position = new Vector2(576, 4032);
            teleporterDungeon1.BoundingBox = new Rectangle(0, 0, 96, 96);

            Teleporter teleporterMiniDungeon1 = new Teleporter("teleporter", this, "MiniDungeon1", new Vector2(5360, 300));
            teleporterMiniDungeon1.Position = new Vector2(3456, 192);
            teleporterMiniDungeon1.BoundingBox = new Rectangle(0, 0, 96, 96);

            Teleporter teleporterMiniDungeon2 = new Teleporter("teleporter", this, "MiniDungeon2", new Vector2(2220, 1200));
            teleporterMiniDungeon2.Position = new Vector2(4608, 5184);
            teleporterMiniDungeon2.BoundingBox = new Rectangle(0, 0, 96, 96);


            //Add Items available for pickup
            UpgradePickup Speed100 = new UpgradePickup("Speed100", this , new SpriteSheet("Textures/Items/Speed100"), "Increases speed by 100!");
            Speed100.Position = new Vector2(2400,2688);
            Speed100.Speed = 100;

            UpgradePickup Attackspeed100 = new UpgradePickup("Attackspeed100", this, new SpriteSheet("Textures/Items/Attackspeed100"), "Increases Attackspeed by 100!");
            Attackspeed100.Position = new Vector2(480, 1248);
            Attackspeed100.AttackSpeed = 100;

            UpgradePickup Damage100 = new UpgradePickup("Damage100", this, new SpriteSheet("Textures/Items/Damage100"), "Increases damage by 100!");
            Damage100.Position = new Vector2(5952, 768);
            Damage100.Damage = 100;

            UpgradePickup Health250 = new UpgradePickup("Health250", this, new SpriteSheet("Textures/Items/Health250"), "Increases Health by 250!");
            Health250.Position = new Vector2(10752, 1920);
            Health250.Health = 250;

            UpgradePickup Speed200 = new UpgradePickup("Speed200", this, new SpriteSheet("Textures/Items/Speed200"), "Increases speed by 200!");
            Speed200.Position = new Vector2(8544, 5664);
            Speed200.Speed = 200;


            Add(Speed100);
            Add(Attackspeed100);
            Add(Damage100);
            Add(Health250);
            Add(Speed200);

            Add(teleporterDungeon1);
            Add(teleporterMiniDungeon1);
            Add(teleporterMiniDungeon2);
        }
    }
}