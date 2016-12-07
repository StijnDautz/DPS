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
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            UpdateCamera();
        }

        public override void HandleInput(GameTime gameTime)
        {
            base.HandleInput(gameTime);
            if(GameInstance.InputManager.isKeyHolding(Keys.W))
            {
                Velocity = new Vector2(Velocity.X, -10);
            }
            else if(GameInstance.InputManager.isKeyHolding(Keys.S))
            {
                Velocity = new Vector2(Velocity.X, 10);
            }
            else
            {
                Velocity = new Vector2(Velocity.X, 0);
            }
            if(GameInstance.InputManager.isKeyHolding(Keys.D))
            {
                Velocity = new Vector2(10, Velocity.Y);
            }
            else if(GameInstance.InputManager.isKeyHolding(Keys.A))
            {
                Velocity = new Vector2(-10, Velocity.Y);
            }
            else
            {
                Velocity = new Vector2(0, Velocity.Y);
            }
        }

        private void UpdateCamera()
        {
            if (Parent is Map)
            {
                Map map = Parent as Map;
                Vector2 halfedScreen = new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2, GraphicsDeviceManager.DefaultBackBufferHeight / 2);
                Vector2 newCameraPosition = new Vector2(Position.X - halfedScreen.X + Width / 2, Position.Y - halfedScreen.Y + Height / 2);
                //make sure camera will stay within world dimensions
                //X
                if (newCameraPosition.X < 0)
                {
                    newCameraPosition.X = 0;
                }
                else if (newCameraPosition.X > map.World.Width - GraphicsDeviceManager.DefaultBackBufferWidth)
                {
                    newCameraPosition.X = map.World.Width - GraphicsDeviceManager.DefaultBackBufferWidth;
                }
                //Y
                if (newCameraPosition.Y < 0)
                {
                    newCameraPosition.Y = 0;
                }
                else if (newCameraPosition.Y > map.World.Heigth - GraphicsDeviceManager.DefaultBackBufferHeight)
                {
                    newCameraPosition.Y = map.World.Heigth - GraphicsDeviceManager.DefaultBackBufferHeight;
                }
                //set new CameraPosition
                map.World.CameraPosition = newCameraPosition;
            }
        }
    }
}