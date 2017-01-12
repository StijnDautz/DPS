using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class InventoryGS : GameState
    {
        public InventoryGS(string id) : base(id)
        {

        }

        public override void Setup()
        {
            base.Setup();
            var inventoryBackGround = new TexturedObject("inventory background", "HUD/inventory2");
            inventoryBackGround.Position = new Vector2(240, 135);
            Add(inventoryBackGround);

            var inventory = World.Player.Inventory;
            inventory.Position = new Vector2(240, 135);
            Add(inventory);
        }
    }
}