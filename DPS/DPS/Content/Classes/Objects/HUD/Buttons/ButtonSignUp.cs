using Engine;
using System.Diagnostics;

namespace Content
{
    class ButtonSignUp : Button
    {
        public ButtonSignUp(Object parent) : base("buttonSignIn", parent, new SpriteSheet("Textures/HUD/ButtonSignUp"), "")
        {

        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
            //if button is pressed go to sign up page
            Process.Start("http://dpstudios.nl/register.php");
        }
    }
}