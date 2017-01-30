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

        public Button(string id, Object parent, SpriteSheet spriteSheet, string soundName) : base(id, parent, spriteSheet)
        {
            clickSound = GameInstance.AssetManager.GetSoundEffect("Rocket");
            
        }
    
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            if (GameInstance.InputManager.LeftMouseButtonPressed)
            {
                if(CollisionHelper.CollidesWith(this, GameInstance.InputManager.MousePosition))
                {
                    ActionWhenPressed();
                }
                else
                {
                    ActionWhenNotPressed();
                }
            }       
        }

        protected virtual void ActionWhenPressed()
        {
            clickSound.Play();
        }

        protected virtual void ActionWhenNotPressed()
        {

        }
    }
}
