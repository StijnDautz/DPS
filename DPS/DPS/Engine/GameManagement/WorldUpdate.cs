using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    partial class World
    {
        public void Update(GameTime gameTime)
        {
            foreach (Map m in _maps)
            {
                //Maps get updated, whether they are visible or not
                m.Update(gameTime);
            }
            UpdateCollision(gameTime);
            if (_canUpdateCamera)
            {
                UpdateCamera();
            }
        }

        private void UpdateCamera()
        {
            if (_player.ObjectList is Map)
            {
                Map map = _player.ObjectList as Map;
                Vector2 halfedScreen = new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2, GraphicsDeviceManager.DefaultBackBufferHeight / 2);
                Vector2 newCameraPosition = new Vector2(_player.Position.X - halfedScreen.X + _player.Width / 2, _player.Position.Y - halfedScreen.Y + _player.Height / 2);
                //make sure camera will stay within world dimensions
                //X
                if (newCameraPosition.X < 0)
                {
                    newCameraPosition.X = 0;
                }
                else if (newCameraPosition.X > Width - GraphicsDeviceManager.DefaultBackBufferWidth)
                {
                    newCameraPosition.X = Width - GraphicsDeviceManager.DefaultBackBufferWidth;
                }
                //Y
                if (newCameraPosition.Y < 0)
                {
                    newCameraPosition.Y = 0;
                }
                else if (newCameraPosition.Y > Heigth - GraphicsDeviceManager.DefaultBackBufferHeight)
                {
                    newCameraPosition.Y = Heigth - GraphicsDeviceManager.DefaultBackBufferHeight;
                }
                //set new CameraPosition
                CameraPosition = newCameraPosition;
            }
        }

        private void UpdateCollision(GameTime gameTime)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            //Update velocity
            foreach(Map m in _maps)
            {
                foreach(Object o in m.Objects)
                {
                    o.ApplyPhysics(elapsedTime);
                }
            }
            //loop through all objects and check for collision with the ones with a higher index, so collisions only get detected ones
            //if collision, call onCollision and set the bool to true, so the positionChange will be resolved
            foreach (Map m1 in _maps)
            {
                for (int i = 0; i < m1.Objects.Count; i++)
                {
                    foreach (Map m2 in _maps)
                    {
                        //set to true, if false it will be detected and set properly
                        m1.Objects[i].InAir = true;
                        for (int j = i + 1; j < m2.Objects.Count; j++)
                        {
                            if (m1.Objects[i].CanCollide && m2.Objects[j].CanCollide)
                            {
                                m1.Objects[i].SetupCollision(m2.Objects[j], elapsedTime);
                            }
                        }
                    }
                }
            }

            //resolve positionChange of objects that collided
            foreach (Map m in _maps)
            {
                foreach(Object o in m.Objects)
                {
                    o.ApplyPosition(elapsedTime);
                }
            }
        }
    }
}