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
        int _index;
        int _discription;

        public InventoryGS(string id, GameStateManager gameStateManager) : base(id, gameStateManager)
        {
            _discription = -1;
        }

        public override void Setup()
        {
            base.Setup();
            var inventoryBackGround = new TexturedObject("inventory background", HUD, "HUD/inventory");
            inventoryBackGround.Position = new Vector2(240, 135);
            AddToHud(inventoryBackGround);
             
            var inventory = World.Player.Inventory;
            inventory.Position = new Vector2(575, 315);
            string discription = "test pickup up, most OP item in the game";
            inventory.AddPickup(new Pickup("pickup", inventory, "Textures/Tiles/a.Overworld", discription));
            AddToHud(inventory);
        }

        public override void Init()
        {
            base.Init();
            World.CanUpdate = false;
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
            Inventory inventory = World.Player.Inventory;

            if(input.isKeyPressed(Keys.I) || input.isKeyPressed(Keys.Escape))
            {
                GameStateManager.SwitchTo("StartPlay");
            }

            if(input.LeftMouseButtonPressed)
            {
                _discription = -1;
                Pickup p = getPickupOnClick(input.MousePosition);
                if(p != null)
                {
                    p.OnClicked();
                }
            }          
            else if(input.LeftMouseButtonHolding)
            {
                _discription = -1;
                if(_draggedPickup == null)
                {
                    _index = inventory.GetPositionInGrid(input.MousePosition);
                    if (_index > -1 && _index < inventory.Size)
                    {
                        _draggedPickup = inventory.Objects[_index] as Pickup;
                    }
                }
                else
                {
                    _draggedPickup.Position = input.MousePosition - (_draggedPickup.GlobalOrigin - _draggedPickup.Position);
                }
            }          
            else if(input.LeftMouseButtonReleased)
            {
                _discription = -1;
                if(_draggedPickup != null)
                {
                    int i = inventory.GetPositionInGrid(input.MousePosition);
                    if (i < 0 || i > inventory.Size)
                    {
                        inventory.removeTile(_index);
                        _draggedPickup.Depth = 1;
                        _draggedPickup.Parent = World;
                        _draggedPickup.CanCollide = true;
                        
                        World.Add(_draggedPickup);
                        _draggedPickup.Position = World.Player.GlobalPosition;                      
                    }
                    else
                    {
                        if(inventory.Objects[i] == null)
                        {
                            inventory.setTile(_index, null);
                            inventory.setTile(i, _draggedPickup);
                        }
                        else
                        {
                            inventory.SwapObjects(_index, _draggedPickup, i, inventory.Objects[i]);
                        }
                    }                    
                    _draggedPickup = null;
                }
            }
            else
            {
                int temp = _discription;
                _discription = inventory.GetPositionInGrid(input.MousePosition);
                if(_discription > -1 && _discription < inventory.Size)
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
                if(temp != _discription && temp > -1 && temp < inventory.Size)
                {
                    Pickup p = inventory.getTile(temp) as Pickup;
                    if (p != null)
                    {
                        p.UpdateDiscription(false);
                    }
                }
            }
        }

        private Pickup getPickupOnClick(Vector2 mouseposition)
        {
            return World.Player.Inventory.getPickupOnClick(GameInstance.InputManager.MousePosition);
        }
    }
}