using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    class Character : Pawn
    {
        private Inventory _inventory;
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

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public Character(string id, string assetName, string name, int age, bool gender) : base(id, assetName)
        {
            _name = name;
            _age = age;
            _gender = gender;
            _inventory = new Inventory(id + "inventory");
            HasPhysics = true;
            CanCollide = true;
            canBlock = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void HandleInput(GameTime gameTime)
        {
            base.HandleInput(gameTime);
            if(GameInstance.InputManager.isKeyHolding(Keys.D))
            {
                Velocity = new Vector2(250, Velocity.Y);
            }
            else if(GameInstance.InputManager.isKeyHolding(Keys.A))
            {
                Velocity = new Vector2(-250, Velocity.Y);
            }
            else
            {
                Velocity = new Vector2(0, Velocity.Y);
            }

            if(GameInstance.InputManager.isKeyPressed(Keys.Space))
            {
                Velocity = new Vector2(Velocity.X, -1200);
            }
        }
    }
}