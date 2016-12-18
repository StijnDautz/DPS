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
            if(_canUpdateCamera)
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
    }
}