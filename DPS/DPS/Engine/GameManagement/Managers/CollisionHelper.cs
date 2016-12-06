using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    static class CollisionHelper
    {
        public static bool CollidesWith(Object o, Object p)
        {
            if(o.BoundingBox.X + o.Width < p.BoundingBox.X)
            { return false; }
            if(p.BoundingBox.X + p.Width < o.BoundingBox.X)
            { return false; }
            if(o.BoundingBox.Y + o.Height < p.BoundingBox.Y)
            { return false; }
            if(p.BoundingBox.Y + p.Height < o.BoundingBox.Y)
            { return false; }
            return true;
        }
    }
}
