using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class Pawn : TexturedObject, IControlledLoopObject
    {
        public Pawn(string id, string assetName) : base(id, assetName)
        {

        }

        public virtual void HandleInput(GameTime gameTime)
        {
            
        }
    }
}