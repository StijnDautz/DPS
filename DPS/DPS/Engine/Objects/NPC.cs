using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Engine
{
    class NPC : Character
    {
        public NPC(string id, Object parent, SpriteSheet spriteSheet) : base(id, parent, spriteSheet)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            UpdateBehaviour(gameTime);
        }

        protected virtual void UpdateBehaviour(GameTime gameTime)
        {

        }
    }
}
