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

            var pickup = new Pickup("testPickup", this, new SpriteSheet("Textures/Items/SnowShoes"), "timerFrame");
            pickup.Position = new Vector2(1000, 100);
            Add(pickup);

            Teleporter teleporterDungeon1 = new Teleporter("teleporter", this, "Dungeon1", new Vector2(33920, 15840));
            teleporterDungeon1.Position = new Vector2(576, 4032);
            teleporterDungeon1.BoundingBox = new Rectangle(0, 0, 96, 96);

            Teleporter teleporterMiniDungeon1 = new Teleporter("teleporter", this, "MiniDungeon1", new Vector2(5360, 300));
            teleporterMiniDungeon1.Position = new Vector2(3456, 192);
            teleporterMiniDungeon1.BoundingBox = new Rectangle(0, 0, 96, 96);

            Teleporter teleporterMiniDungeon2 = new Teleporter("teleporter", this, "MiniDungeon2", new Vector2(2220, 1200));
            teleporterMiniDungeon2.Position = new Vector2(4608, 5184);
            teleporterMiniDungeon2.BoundingBox = new Rectangle(0, 0, 96, 96);

            UpgradePickup RocketCape = new UpgradePickup("SnowShoes", this , new SpriteSheet("Textures/Items/SnowShoes"), "SnowShoes");
            RocketCape.Position = new Vector2(2400,2688);
            Add(RocketCape);

            Add(teleporterDungeon1);
            Add(teleporterMiniDungeon1);
            Add(teleporterMiniDungeon2);
        }
    }
}