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
        public static bool CollidesWith(Object objM, Vector2 posM, Object objC)
        {
            //set create temp BoundingBox on new position
            Rectangle BoundingBox = objM.BoundingBox;
            BoundingBox.X = (int)posM.X;
            BoundingBox.Y = (int)posM.Y;

            if(BoundingBox.X + objM.Width < objC.BoundingBox.X)
            { return false; }
            if(objC.BoundingBox.X + objC.Width < BoundingBox.X)
            { return false; }
            if(BoundingBox.Y + objM.Height < objC.BoundingBox.Y)
            { return false; }
            if(objC.BoundingBox.Y + objC.Height < BoundingBox.Y)
            { return false; }
            return true;
        }
    }
}
