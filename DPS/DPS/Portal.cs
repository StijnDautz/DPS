using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DPS
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

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        public override void Reset()
        {
            base.Reset();
        }
    }
}
