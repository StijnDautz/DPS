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
        public static bool CollidesWith(Object oldObj, Vector2 newPos, Object objC)
        {
            if (newPos.Y + oldObj.Height < objC.Position.Y)
            { return false; }
            if (objC.BoundingBox.Y + objC.Height < newPos.Y)
            { return false; }
            if (newPos.X + oldObj.Width < objC.BoundingBox.X)
            { return false; }
            if (objC.BoundingBox.X + objC.Width < newPos.X)
            { return false; }
            return true;
        }

        public static bool CollidedAtBottom(Object oldObj, Vector2 newPos, Object objC)
        {
            return oldObj.GlobalPosition.Y + oldObj.Height <= objC.GlobalPosition.Y && newPos.Y + oldObj.Height >= objC.GlobalPosition.Y;
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
