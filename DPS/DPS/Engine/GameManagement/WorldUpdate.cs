﻿using Microsoft.Xna.Framework;
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
            }
        }

        private void UpdateCamera()
        {
            if (_player != null)
            {
                int screenWidth = GameInstance.GraphicsDeviceManager.PreferredBackBufferWidth;
                int screenHeight = GameInstance.GraphicsDeviceManager.PreferredBackBufferHeight;

                Vector2 halfedScreen = new Vector2(screenWidth / 2, screenHeight / 2);
                Vector2 newCameraPosition = new Vector2(_player.Position.X - halfedScreen.X + _player.Width / 2, _player.Position.Y - halfedScreen.Y + _player.Height / 2);
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
                }
            }

            //loop through all objects and check for collision with the ones with a higher index, so collisions only get detected ones
            //if collision, call onCollision
            for (int i = 0; i < _collisionObjects.Count; i++)
            {
                for(int j = i + 1; j < _collisionObjects.Count; j++)
                {
                    _collisionObjects[i].InAir = true;
                    _collisionObjects[i].SetupCollision(_collisionObjects[j], elapsedTime);
                }
            }

            //resolve positionChange of objects that collided
            foreach(Object o in _collisionObjects)
            {
                o.ApplyPosition(elapsedTime);
            }
        }
    }
}