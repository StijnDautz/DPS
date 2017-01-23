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
        Point _draggedPickupPoint;
        int _discription;

        public InventoryGS(string id, GameStateManager gameStateManager) : base(id, gameStateManager)
        {
            _discription = -1;
        }
        /*
        public override void Setup()
        {
            base.Setup();
            var inventoryBackGround = new TexturedObject("inventory background", HUD, new SpriteSheet("HUD/inventory"));
            inventoryBackGround.Position = new Vector2(240, 135);
            AddToHud(inventoryBackGround);
             
            var inventory = World.Player.Inventory;
            inventory.Position = new Vector2(575, 315);
            string discription = "test pickup up, most OP item in the game";
            inventory.AddPickup(new Pickup("pickup", inventory, new SpriteSheet("Textures/Tiles/a.Overworld"), discription));
            AddToHud(inventory);
        }

        public override void Init()
        {
            base.Init();
            World.CanUpdate = false;
            IsMouseVisible = true;
            CanUpdateGameTime = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void HandleInput(GameTime gameTime)
        {
            base.HandleInput(gameTime);
            InputManager input = GameInstance.InputManager;
            Vector2 mousePosition = input.MousePosition;
            Inventory inventory = World.Player.Inventory;

            if(input.isKeyPressed(Keys.I) || input.isKeyPressed(Keys.Escape))
            {
                GameStateManager.SwitchTo("StartPlay");
            }

            if(input.LeftMouseButtonPressed)
            {
                LeftMouseButtonPressed(mousePosition);
            }          
            else if(input.LeftMouseButtonHolding)
            {
                LeftMouseButtonHolding(inventory, mousePosition);
            }          
            else if(input.LeftMouseButtonReleased)
            {
                LeftMoussButtonReleased(inventory, mousePosition);
            }
            else
            {
                //HoverOver();
            }
        }

        private Pickup getPickupOnClick(Vector2 mouseposition)
        {
            return World.Player.Inventory.getPickupOnClick(GameInstance.InputManager.MousePosition);
        }

        private void LeftMouseButtonPressed(Vector2 mousePosition)
        {
            Pickup p = getPickupOnClick(mousePosition);
            if (p != null)
            {
                p.OnClicked();
            }
        }

        private void LeftMouseButtonHolding(Inventory inventory, Vector2 mousePosition)
        {
            //if draggedPickup is not null, move it according to the mouse
            if(_draggedPickup != null)
            {
                _draggedPickup.Position = mousePosition - (_draggedPickup.GlobalOrigin - _draggedPickup.Position);
            }
        }
        
        private void LeftMoussButtonReleased(Inventory inventory, Vector2 mousePosition)
        {
            if (_draggedPickup != null)
            {
                Point p = inventory.GetPositionInGrid(mousePosition);
                //if not draggedPickup is released outside Boundaries, remove it from the inventory and spawn it in the World
                if (!inventory.WithinBoudaries(p.X, p.Y))
                {
                    inventory.removeTile(p);
                    _draggedPickup.Depth = 1;
                    _draggedPickup.Parent = World;
                    _draggedPickup.CanCollide = true;

                    World.Add(_draggedPickup);
                    _draggedPickup.Position = World.Player.GlobalPosition;
                }
                else
                {
                    //if draggedPickup is released within the grid, swap both Pickups
                    inventory.SwapObjects(_draggedPickupPoint.X, _draggedPickupPoint.Y, inventory.getTile(p), p.X, p.Y, _draggedPickup);
                }
                _draggedPickup = null;
            }
        }
        /*
        private void HoverOver()
        {
            int temp = _discription;
            _discription = inventory.GetPositionInGrid(input.MousePosition);
            if (_discription > -1 && _discription < inventory.Size)
            {
                if (temp != _discription)
                {
                    Pickup p = inventory.getTile(_discription) as Pickup;
                    if (p != null)
                    {
                        p.UpdateDiscription(true);
                    }
                }
            }
            if (temp != _discription && temp > -1 && temp < inventory.Size)
            {
                Pickup p = inventory.getTile(temp) as Pickup;
                if (p != null)
                {
                    p.UpdateDiscription(false);
                }
            }
        }*/
    }
}