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
        private bool _canMove;

        public bool CanMove
        {
            get { return _canMove; }
            set { _canMove = value; }
        }

        public Pawn(string id, string assetName) : base(id, assetName)
        {
            _canMove = true;
        }

        public virtual void HandleInput(GameTime gameTime)
        {
            
        }
    }
}