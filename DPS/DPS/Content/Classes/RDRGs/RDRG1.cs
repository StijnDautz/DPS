using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class RDRG1 : RandomDungeonGenerator
    {
        public RDRG1(Vector2 position) : base(position)
        {
            Height = 20;
            Width = 60;
            Door door1 = new Door(), door2 = new Door(), door3 = new Door(), door4 = new Door();
            door1.location = new Vector2(0, 14);
            door1.direc = Door.direction.right;
            door2.location = new Vector2(58, 13);
            door2.direc = Door.direction.left;
            door3.location = new Vector2(28, 0);
            door3.direc = Door.direction.up;
            door4.location = new Vector2(48, 19);
            door4.direc = Door.direction.down;
            Doors.Add(door1);
            Doors.Add(door2);
            Doors.Add(door3);
            Doors.Add(door4);
        }
    }
}
