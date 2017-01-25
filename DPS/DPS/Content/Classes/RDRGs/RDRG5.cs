using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class RDRG5 : RandomDungeonGenerator
    {
        public RDRG5(Vector2 position) : base(position)
        {
            Height = 20;
            Width = 60;
            Door door11 = new Door(), door12 = new Door();

            door11.location = new Vector2(58, 13);
            door11.direc = Door.direction.left;
            door12.location = new Vector2(0, 13);
            door12.direc = Door.direction.right;

            Doors.Add(door11);
            Doors.Add(door12);
        }
    }
}