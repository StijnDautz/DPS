using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class DestructableObject : TexturedObject
    {
        int health = 1;
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public DestructableObject(string id, Object parent, SpriteSheet spriteSheet) : base(id, parent, spriteSheet)
        {

        }
    }
}
