using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Engine
{
    static class CollisionHelper
    {
        public static bool CollidesWith(Object obj1, Vector2 offset1, Object obj2, Vector2 offset2, float elapsedTime)
        {
            Vector2 pos1 = obj1.GlobalPosition + offset1 * elapsedTime;
            Vector2 pos2 = obj2.GlobalPosition + offset2 * elapsedTime;

            if (pos1.Y + obj1.Height < pos2.Y)
            { return false; }
            if (pos2.Y + obj2.Height < pos1.Y)
            { return false; }
            if (pos1.X + obj1.Width < pos2.X)
            { return false; }
            if (pos2.X + obj2.Width < pos1.X)
            { return false; }
            return true;
        }

        public static bool CollidesWith(Object obj1, Object obj2)
        {
            return CollidesWith(obj1, Vector2.Zero, obj2, Vector2.Zero, 0);
        }

        public static bool CollidedAtBottom(Object oldObj, Object objC)
        {
            return oldObj.GlobalPosition.Y + oldObj.Height <= objC.GlobalPosition.Y && oldObj.GlobalPosition.Y + oldObj.Height >= objC.GlobalPosition.Y;
        }

        public static bool CollidedAtLeft(Object oldObj, Vector2 newPos, Object objC)
        {
            return oldObj.GlobalPosition.X >= objC.GlobalPosition.X + objC.Width && newPos.X <= objC.GlobalPosition.X + objC.Width;
        }

        public static bool CollidedAtRight(Object oldObj, Vector2 newPos, Object objC)
        {
            return oldObj.GlobalPosition.X + oldObj.Width <= objC.GlobalPosition.X && newPos.X + oldObj.Width >= objC.GlobalPosition.X;
        }

        public static bool CollidedAtTop(Object oldObj, Vector2 newPos, Object objC)
        {
            return oldObj.GlobalPosition.Y >= objC.GlobalPosition.Y + objC.Height && newPos.Y <= objC.GlobalPosition.Y + objC.Height;
        }
    }
}
