using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
            var inventoryBackGround = new TexturedObject("inventory background", "HUD/inventory");
            inventoryBackGround.Position = new Vector2(240, 135);
            Add(inventoryBackGround);

            var inventory = World.Player.Inventory;
            inventory.Position = new Vector2(575, 315);
            inventory.AddPickup(new Pickup("testPickup", "Textures/Tiles/spr_wall"));
            inventory.AddPickup(new Pickup("testPickup", "Textures/Tiles/spr_wall"));
            inventory.AddPickup(new Pickup("testPickup", "Textures/Tiles/spr_wall"));
            inventory.AddPickup(new Pickup("testPickup", "Textures/Tiles/spr_wall"));
            inventory.AddPickup(new Pickup("testPickup", "Textures/Tiles/spr_wall"));
            inventory.AddPickup(new Pickup("testPickup", "Textures/Tiles/spr_wall"));
            inventory.AddPickup(new Pickup("testPickup", "Textures/Tiles/spr_wall"));
            inventory.AddPickup(new Pickup("testPickup", "Textures/Tiles/spr_wall"));


            Add(inventory);
        }

        public override void Init()
        {
            base.Init();
            World.Player.CanMove = false;
        }

        public override void HandleInput(GameTime gameTime)
        {
            base.HandleInput(gameTime);
            if(GameInstance.InputManager.isKeyPressed(Keys.I) || GameInstance.InputManager.isKeyPressed(Keys.Escape))
            {
                GameStateManager.SwitchTo("StartPlayGS");
            }
        }
    }
}