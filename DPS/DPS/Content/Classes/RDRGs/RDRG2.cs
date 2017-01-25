using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    public class RDRG2 : RandomDungeonGenerator
    {
        public RDRG2(Vector2 position) : base(position)
        {
            Height = 20;
            Width = 40;
            Door door5 = new Door();
            door5.location = new Vector2(0, 14);
            door5.direc = Door.direction.right;
            Doors.Add(door5);
        }
    }
}
