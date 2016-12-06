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

        }

        public bool AddPickup()
        {
            foreach(Object o in _grid)
            {

            }
        }
    }
}
