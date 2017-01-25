using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class RDRG4 : RandomDungeonGenerator
    {
        public RDRG4(Vector2 position) : base(position)
        {
            Height = 30;
            Width = 60;

            Door door9 = new Door(), door10 = new Door();
            door9.location = new Vector2(58, 24);
            door9.direc = Door.direction.left;
            door10.location = new Vector2(0, 24);
            door10.direc = Door.direction.right;

            Doors.Add(door9);
            Doors.Add(door10);
        }
    }
}
