using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Content
{
    class ButtonAllowTyping : Engine.Button
    {
        private bool _canType;

        public bool CanType
        {
            get { return _canType; }
            set { _canType = value; }
        }

        public ButtonAllowTyping(Engine.Object parent) : base("buttonAllowTyping", parent, new Engine.SpriteSheet("Textures/HUD/TextBoxBackGround"), "")
        {

        }

        protected override void ActionWhenPressed()
        {
            base.ActionWhenPressed();
            _canType = true;
        }

        protected override void ActionWhenNotPressed()
        {
            base.ActionWhenNotPressed();
            _canType = false;
        }
    }
}
