using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Engine
{
    class Button : TexturedObject
    {

        public Button(string id, string assetName) : base(id, assetName)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (GameInstance.inputManager.LeftMouseButtonPressed)
            {
                Vector2 mousePosition = GameInstance.inputManager.mousePosition;
                if (mousePosition.X > BoundingBox.X && mousePosition.X < BoundingBox.X + BoundingBox.Width && mousePosition.Y > BoundingBox.Y && mousePosition.Y < BoundingBox.Y + BoundingBox.Height)
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
