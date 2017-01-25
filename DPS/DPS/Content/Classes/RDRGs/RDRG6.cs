using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class RDRG6 : RandomDungeonGenerator
    {
        public RDRG6(Vector2 position) : base(position)
        {
            Height = 10;
            Width = 20;
            Door door13 = new Door();
            door13.location = new Vector2(8, 9);
            door13.direc = Door.direction.down;
            Doors.Add(door13);
        }
    }
}