using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Weapon : Pickup
    {
        private int _damage;

        public int Damage
        {
            get { return _damage; }
        }
        
        public Weapon(string id, Object parent, string assetName, string discription, int damage) : base(id, parent, assetName, discription)
        {
            _damage = damage;

        }
    }
}
