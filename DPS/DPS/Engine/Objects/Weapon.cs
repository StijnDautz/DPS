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
        
        public Weapon(string id, string assetName, int damage) : base(id, assetName)
        {
            _damage = damage;

        }
    }
}
