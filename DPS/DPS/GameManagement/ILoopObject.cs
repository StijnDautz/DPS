using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DPS
{
    interface ILoopObject
    {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
        void Reset();
    }
}
