using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Content
{
    class StartPlayGS : GameState
    {
        public StartPlayGS(string id) : base(id)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
        }

        public override void HandleInput(GameTime gameTime)
        {
            base.HandleInput(gameTime);
            if (GameInstance.InputManager.isKeyPressed(Keys.I))
            {
                GameStateManager.SwitchTo("inventory");
            }
        }
    }
}
