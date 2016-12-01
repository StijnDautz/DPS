using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Engine
{
    class Character : Pawn
    {
        private string _name;
        private int _age;
        private bool _gender;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public bool Gender
        {
            get { return _gender; }
        }

        Character(string id, string assetName, string name, int age, bool gender) : base(id, assetName)
        {
            _name = name;
            _age = age;
            _gender = gender;
        }

        public override void HandleInput(GameTime gameTime)
        {
            base.HandleInput(gameTime);
        }
    }
}
