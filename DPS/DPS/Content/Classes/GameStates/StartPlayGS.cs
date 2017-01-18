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
        public StartPlayGS(string id, GameStateManager gameStateManager) : base(id, gameStateManager)
        {

        }

        public override void Init()
        {
            base.Init();
            IsMouseVisible = false;
            World.CanUpdate = true;
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
