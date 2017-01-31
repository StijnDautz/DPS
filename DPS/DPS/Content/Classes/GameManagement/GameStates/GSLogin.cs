using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class GSLogin : Engine.GameState
    {
        public GSLogin(Engine.GameStateManager gameStateManager) : base("GSLogin", gameStateManager)
        {
            var backGround = new Engine.TexturedObject("background", HUD, new Engine.SpriteSheet("Textures/HUD/MainMenu"));
            AddToHud(backGround);

            var loginPopUpScreen = new LoginPopUp(HUD);
            loginPopUpScreen.Position = new Microsoft.Xna.Framework.Vector2(backGround.Width / 2 - loginPopUpScreen.Width / 2, backGround.Height / 2 - loginPopUpScreen.Height / 2);
            AddToHud(loginPopUpScreen);
        }
    }
}