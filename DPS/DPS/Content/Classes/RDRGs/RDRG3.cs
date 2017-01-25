using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class RDRG3 : RandomDungeonGenerator
    {
        public RDRG3(Vector2 position) : base(position)
        {
            Height = 30;
            Width = 60;
            Door door6 = new Door(), door7 = new Door(), door8 = new Door();
            door6.location = new Vector2(58, 23);
            door6.direc = Door.direction.left;
            door7.location = new Vector2(0, 23);
            door7.direc = Door.direction.right;
            door8.location = new Vector2(0, 3);
            door8.direc = Door.direction.right;
            Doors.Add(door6);
            Doors.Add(door7);
            Doors.Add(door8);
        }
    }
}
