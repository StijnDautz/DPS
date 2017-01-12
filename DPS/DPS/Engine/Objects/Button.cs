using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Engine
{
    abstract class Button : TexturedObject
    {

        public Button(string id, string assetName) : base(id, assetName)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (GameInstance.InputManager.LeftMouseButtonPressed)
            {
                Vector2 mousePosition = GameInstance.InputManager.MousePosition;
                if (mousePosition.X > Position.X && mousePosition.X < Position.X + Width && mousePosition.Y > Position.Y && mousePosition.Y < Position.Y + Width)
                {
                    ActionWhenPressed();
                }
            }       
        }

        protected virtual void ActionWhenPressed()
        {

        }
    }
}
