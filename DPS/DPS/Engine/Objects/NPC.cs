using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class NPC : TexturedObject
    {
        private Inventory _inventory;

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public NPC(string id, string assetName) : base(id, assetName)
        {
            _inventory = new Inventory(id + "inventory");
        }
    }
}
