using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    partial class World : ObjectList
    {
        public override void Update(GameTime gameTime)
        {
            if (_canUpdate)
            {
                UpdateCollision(gameTime);
                UpdateCamera();
                foreach (Object o in Objects)
                {
                    if (_canUpdate && o != null && o.Visible)
                    {
                        o.Update(gameTime);
                    }
                }
                UpdateObjectsList();
            }
        }

        private void UpdateCamera()
        {
            if (Player != null)
            {
                int screenWidth = GameInstance.GraphicsDeviceManager.PreferredBackBufferWidth;
                int screenHeight = GameInstance.GraphicsDeviceManager.PreferredBackBufferHeight;

                Vector2 halfedScreen = new Vector2(screenWidth / 2, screenHeight / 2);
                Vector2 newCameraPosition = new Vector2(Player.Position.X - halfedScreen.X + Player.Width / 2, Player.Position.Y - halfedScreen.Y + Player.Height / 2);
                //make sure camera will stay within world dimensions
                //X
                var temp = Width - screenWidth;
                if (newCameraPosition.X < 0)
                {
                    newCameraPosition.X = 0;
                }
                else if (newCameraPosition.X > temp)
                {
                    newCameraPosition.X = temp;
                }
                //Y
                temp = Width - screenHeight;
                if (newCameraPosition.Y < 0)
                {
                    newCameraPosition.Y = 0;
                }
                else if (newCameraPosition.Y > temp)
                {
                    newCameraPosition.Y = temp;
                }
                //set new CameraPosition
                CameraPosition = newCameraPosition;
            }     
        }

        private void UpdateCollision(GameTime gameTime)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            //Update velocity
            if (!IsTopDown)
            {
                foreach (Object o in Objects)
                {
                    o.ApplyPhysics(elapsedTime);
                    o.InAir = true;
                }
            }

            //loop through all objects and check for collision with the ones with a higher index, so collisions only get detected ones
            //if collision, call onCollision
            for (int i = 0; i < _collisionObjects.Count; i++)
            {
                for(int j = i + 1; j < _collisionObjects.Count; j++)
                {
                    _collisionObjects[i].SetupCollision(_collisionObjects[j], elapsedTime);
                }
            }

            //resolve positionChange of objects that collided
            foreach(Object o in _collisionObjects)
            {
                o.ApplyPosition(elapsedTime);
            }
        }

        private void UpdateObjectsList()
        {
            foreach(Object o in _objectsToAdd)
            {
                Objects.Add(o);
            }
            _objectsToAdd.Clear();
            foreach(Object o in _objectsToRemove)
            {
                Objects.Remove(o);
                if(o.CanCollide)
                {
                    _collisionObjects.Remove(o);

                }
                if(o is Player)
                {
                    _characters.Remove(o as Player);
                }
            }
            _objectsToRemove.Clear();
        }
    }
}