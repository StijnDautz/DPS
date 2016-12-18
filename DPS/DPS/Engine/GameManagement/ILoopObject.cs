using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    interface ILoopObject
    {
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        void Reset();
    }
}
