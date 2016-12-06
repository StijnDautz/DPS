using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Inventory : ObjectList 
    {
        private ObjectGrid _grid;

        Inventory(string id) : base (id)
        {
            _grid = new ObjectGrid("inventorygrid", 5, 5, 60);
            Add(_grid);
        }

        public bool AddPickup(Object o)
        {
            return _grid.AddToFirstFreeSpot(o);
        }

        public void RemovePickup(Object o)
        {
            _grid.RemoveObject(o);
        }

        public void MovePickup(Object o, Vector2 m)
        {
            _grid.GetPositionInGrid

            if(_grid.getTile(p) == null)
            {

            }
        }

        public void SwapPickup(Object o, Object p)
        {

        }


        /*field van het type wapen
         *functie find strongest weapon
         *in addpickup functie als er een wapen is toegevoegd, opnieuw uitrekenen, if(o is weapon)
         *in removepickup als het sterkste wapen is geremoved, ook opnieuw uitrekenen, if(field==removedpickup)
         *functi
         * 
         * */
    }
}
