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
        Pickup _draggedPickup;

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
            IsMouseVisible = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void HandleInput(GameTime gameTime)
        {
            base.HandleInput(gameTime);
            InputManager input = GameInstance.InputManager;

            if(input.isKeyPressed(Keys.I) || input.isKeyPressed(Keys.Escape))
            {
                GameStateManager.SwitchTo("StartPlayGS");
            }
            if(input.LeftMouseButtonPressed)
            {
                Pickup p = getPickupOnClick(input.MousePosition);
                if(p != null)
                {
                    p.OnClicked();
                }
            }
            
            if(input.LeftMouseButtonHolding)
            {
                if(_draggedPickup == null)
                {
                    _draggedPickup = getPickupOnClick(input.MousePosition);
                }
                else
                {
                    _draggedPickup.Position = input.MousePosition - (_draggedPickup.GlobalOrigin - _draggedPickup.Position);
                }
            }
            
            if(input.LeftMouseButtonReleased)
            {
                if(_draggedPickup != null)
                {
                    Pickup p = getPickupOnClick(input.MousePosition);
                    if(p != null)
                    {
                        World.Player.Inventory.SwapObjects(_draggedPickup, p);
                    }
                    _draggedPickup = null;
                }
            }
        }

        private Pickup getPickupOnClick(Vector2 mouseposition)
        {
            return World.Player.Inventory.getPickupOnClick(GameInstance.InputManager.MousePosition);
        }
    }
}