using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Engine
{
    abstract class Button : TexturedObject
    {
        SoundEffect clickSound; 

        public Button(string id, Object parent, string assetName, string soundName) : base(id, parent, assetName)
        {
            clickSound = GameInstance.AssetManager.GetSoundEffect("Rocket");
            
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
            clickSound.Play();
        }
    }
}
