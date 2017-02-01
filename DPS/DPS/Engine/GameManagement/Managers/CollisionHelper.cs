using Microsoft.Xna.Framework;

namespace Engine
{
    static class CollisionHelper
    {
        public static bool CollidesWith(Object obj1, Vector2 offset1, Object obj2, Vector2 offset2, float elapsedTime)
        {
            //calculate new position of both objects
            Vector2 pos1 = obj1.GlobalPosition + offset1 * elapsedTime;
            Vector2 pos2 = obj2.GlobalPosition + offset2 * elapsedTime;

            //check collision
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

        public static bool CollidesWith(Object obj1, Vector2 mousePos)
        {
            if (obj1.GlobalPosition.Y + obj1.Height < mousePos.Y)
            { return false; }
            if (obj1.GlobalPosition.Y > mousePos.Y)
            { return false; }
            if(obj1.GlobalPosition.X + obj1.Width < mousePos.X)
            { return false; }
            if(obj1.GlobalPosition.X > mousePos.X)
            { return false; }
            return true;
        }
    }
}