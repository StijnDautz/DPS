using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Content
{
    class LoginPopUp : ObjectList
    {
        private TextBox _userNameBox, _passWordBox;

        public LoginPopUp(Engine.Object parent) : base("LoginPopUp", parent)
        {
            //create texturedObjects
            var backGround = new TexturedObject("background", this, new SpriteSheet("Textures/HUD/LoginPopUpWindow"));

            //set boundingBox equal to boundingBox of background
            BoundingBox = backGround.BoundingBox;

            //create textBoxes
            _userNameBox = new TextBox(this);
            _passWordBox = new TextBox(this);
            _userNameBox.Position = new Microsoft.Xna.Framework.Vector2(119, 138);
            _passWordBox.Position = new Microsoft.Xna.Framework.Vector2(119, 176);

            //create buttons
            var buttonLogin = new ButtonLogin(this, _userNameBox, _passWordBox);
            var buttonSignUp = new ButtonSignUp(this);
            buttonLogin.Position = new Microsoft.Xna.Framework.Vector2(193, 228);
            buttonSignUp.Position = new Microsoft.Xna.Framework.Vector2(193, 338);

            //add Objects
            Add(backGround);
            Add(_userNameBox);
            Add(_passWordBox);
            Add(buttonLogin);
            Add(buttonSignUp);
        }
    }
}
