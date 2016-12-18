using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class Portal : Object
    {
        private string _identifier;
        private string _destination;

        string Identifier
        {
            get { return _identifier; }
            set { _identifier = value; }
        }
        string Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        public Portal(string id) : base(id)
        {

        }

        void Teleport()
        {

        }
    }
}
