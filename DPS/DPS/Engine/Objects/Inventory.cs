using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Inventory : ObjectGrid
    {
        public Inventory(string id, Object parent) : base(id, parent, 4, 2, 109, 109)
        {

        }

        public bool AddPickup(Pickup o)
        {
            if(AddToFirstFreeSpot(o))
            {
                o.Parent = this;
                o.Depth = 0;
                return true;
            }
            return false;
        }

        public void RemovePickup(Pickup o)
        {
            RemoveObject(o);
        }

        public void MovePickup(Pickup movingPickup, Vector2 MousePosition)
        {
            Point p = GetPositionInGrid(MousePosition);
            Pickup switchPickup = getTile(p) as Pickup;

            if(switchPickup == null)
            {
 //               setTile(p.X, p.Y, movingPickup);
            }
            else
            {
 //               SwapPickup(p, GetPositionInGrid(movingPickup));
            }
        } 

        public Pickup getPickupOnClick(Vector2 mousePosition)
        {
            return getTile(mousePosition) as Pickup;
        }
    }
}